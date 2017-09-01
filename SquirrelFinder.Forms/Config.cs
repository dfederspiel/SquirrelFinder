using SquirrelFinder.Forms.UserControls;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SquirrelFinder.Forms
{
    public partial class Config : Form
    {

        static NutManager _nutMonitor;
        static NotifyIcon _trayIcon;

        public Config(NutManager nutMonitor, NotifyIcon trayIcon)
        {
            _nutMonitor = nutMonitor == null ? new NutManager() : nutMonitor;
            _nutMonitor.NutCollectionChanged += _squirrelFinder_NutsChanged;
            _trayIcon = trayIcon;
            InitializeComponent();
            InitializeLocalSites();

            foreach (var nut in _nutMonitor.Nuts)
            {
                flowLayoutPanel1.Controls.Add(new NutInfo(nut, _nutMonitor));
            }
        }

        private void _squirrelFinder_NutsChanged(object sender, NutCollectionEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var nut in _nutMonitor.Nuts)
            {
                flowLayoutPanel1.Controls.Add(new NutInfo(nut, _nutMonitor));
            }
        }

        private void InitializeLocalSites()
        {
            comboBoxLocalSites.Items.AddRange(_nutMonitor.GetAllSites().ToArray());
            comboBoxLocalSites.SelectedIndexChanged += ComboBoxLocalSites_SelectedIndexChanged;
        }

        private void ComboBoxLocalSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAvailableBindings.Items.Clear();
            listBoxAvailableBindings.Items.AddRange(_nutMonitor.GetSiteBindings(comboBoxLocalSites.SelectedItem.ToString()).ToArray());
        }

        private void buttonAddPublicSite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPublicUrl.Text) || 
                (comboBoxProtocol.SelectedItem != null && string.IsNullOrEmpty(comboBoxProtocol.SelectedItem.ToString()))) return;

            try
            {
                var uri = new Uri(comboBoxProtocol.SelectedItem.ToString() + "://" + textBoxPublicUrl.Text);
                var nut = new Nut(uri);
                _nutMonitor.AddNut(nut);

                textBoxPublicUrl.Clear();
            }
            catch
            {
                return;
            }
        }

        private void buttonAddToWatch_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableBindings.SelectedItem == null) return;
            var url = new Uri(listBoxAvailableBindings.SelectedItem.ToString());
            if (Directory.Exists(NutHelper.GetDirectoryFromUrl(url.ToString()) + "/App_Data/Sitefinity"))
            {
                var sitefinityLocalNut = new LocalSitefinityNut(url);
                _nutMonitor.AddNut(sitefinityLocalNut);
            }
            else
            {
                var localNut = new LocalNut(url);
                _nutMonitor.AddNut(localNut);
            }
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }
    }
}
