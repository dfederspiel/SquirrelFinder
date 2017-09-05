using SquirrelFinder.Forms.UserControls;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SquirrelFinder.Forms
{
    public partial class Config : Form
    {

        static NutManager _nutManager;
        static NotifyIcon _trayIcon;

        public Config(NutManager nutManager, NotifyIcon trayIcon)
        {
            _nutManager = nutManager ?? new NutManager();
            _nutManager.NutCollectionChanged += _squirrelFinder_NutsChanged;
            _trayIcon = trayIcon;

            InitializeComponent();
            InitializeLocalSites();

            foreach (var nut in _nutManager.Nuts)
            {
                flowLayoutPanel1.Controls.Add(new NutInfo(nut, _nutManager));
            }
        }

        private void _squirrelFinder_NutsChanged(object sender, NutCollectionEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var nut in _nutManager.Nuts)
            {
                flowLayoutPanel1.Controls.Add(new NutInfo(nut, _nutManager));
            }
        }

        private void InitializeLocalSites()
        {
            comboBoxLocalSites.Items.AddRange(_nutManager.GetAllSites().ToArray());
            comboBoxLocalSites.SelectedIndexChanged += ComboBoxLocalSites_SelectedIndexChanged;
        }

        private void ComboBoxLocalSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAvailableBindings.Items.Clear();
            listBoxAvailableBindings.Items.AddRange(_nutManager.GetSiteBindings(comboBoxLocalSites.SelectedItem.ToString()).ToArray());
        }

        private void ButtonAddPublicSite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPublicUrl.Text) ||
                (comboBoxProtocol.SelectedItem != null && string.IsNullOrEmpty(comboBoxProtocol.SelectedItem.ToString()))) return;

            try
            {
                var uri = new Uri(comboBoxProtocol.SelectedItem.ToString() + "://" + textBoxPublicUrl.Text);
                if (checkBoxIsSitefinity.Checked)
                {
                    _nutManager.AddNut(new SitefinityNut(uri));
                }
                else
                {
                    _nutManager.AddNut(new Nut(uri));
                }
                textBoxPublicUrl.Clear();
            }
            catch
            {
                return;
            }
        }

        private void ButtonAddToWatch_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableBindings.SelectedItem == null) return;
            var url = new Uri(listBoxAvailableBindings.SelectedItem.ToString());
            if (Directory.Exists(NutHelper.GetDirectoryFromUrl(url.ToString()) + "/App_Data/Sitefinity"))
            {
                var sitefinityLocalNut = new LocalSitefinityNut(url);
                _nutManager.AddNut(sitefinityLocalNut);
            }
            else
            {
                var localNut = new LocalNut(url);
                _nutManager.AddNut(localNut);
            }
        }

        private void Config_FormClosed(object sender, FormClosedEventArgs e)
        {
            NutSaver.SaveNuts(_nutManager.Nuts);
        }

        private void loadPreviousConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("nutbox.json"))
            {
                var nutBox = NutSaver.GetNuts();
                _nutManager.Nuts.Clear();
                _nutManager.Nuts.AddRange(nutBox.LocalSitefinityNuts);
                _nutManager.Nuts.AddRange(nutBox.SitefinityNuts);
                _nutManager.Nuts.AddRange(nutBox.LocalNuts);
                _nutManager.Nuts.AddRange(nutBox.Nuts);

                var badNuts = new List<INut>();
                foreach (var nut in _nutManager.Nuts)
                {
                    if (nut is ILocalNut)
                        if (!NutHelper.LocalSiteExists(nut as ILocalNut))
                            badNuts.Add(nut);
                }

                _nutManager.Nuts.RemoveAll(n => badNuts.Contains(n));
                

                flowLayoutPanel1.Controls.Clear();
                foreach (var nut in _nutManager.Nuts)
                {
                    flowLayoutPanel1.Controls.Add(new NutInfo(nut, _nutManager));
                }
            }
        }
    }
}
