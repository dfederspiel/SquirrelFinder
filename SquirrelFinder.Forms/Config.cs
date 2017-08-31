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

        NutMonitor _squirrelFinder;
        NotifyIcon _trayIcon;
        Timer _timer;

        public Config(NutMonitor finder, NotifyIcon trayIcon)
        {
            _squirrelFinder = finder == null ? new NutMonitor() : finder;
            _squirrelFinder.NutsChanged += _squirrelFinder_NutsChanged;
            _trayIcon = trayIcon;
            _trayIcon.BalloonTipClicked += _trayIcon_BalloonTipClicked;

            InitializeComponent();
            InitializeLocalSites();

            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Tick += _timer_Tick;
            _timer.Start();

            //Nut n1 = new Nut(new Uri("http://basitefinity.local"));
            //Nut n2 = new LocalNut(new Uri("http://examples.local"));
            //NutInfo c1 = new NutInfo(n1, _squirrelFinder);
            //NutInfo c2 = new NutInfo(n2, _squirrelFinder);
            //c1.Width = 377;
            //c2.Width = 377;

            //flowLayoutPanel1.Controls.Add(c1);
            //flowLayoutPanel1.Controls.Add(c2);
            
            UpdateWatchList();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {

        }

        private void _squirrelFinder_NutsChanged(object sender, NutCollectionEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach(var nut in _squirrelFinder.Nuts)
            {
                flowLayoutPanel1.Controls.Add(new NutInfo(nut, _squirrelFinder));
            }
        }

        private void _trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_squirrelFinder.Nuts.Select(n => n.Url.ToString()).First());
        }

        private void InitializeLocalSites()
        {
            comboBoxLocalSites.Items.AddRange(_squirrelFinder.GetAllSites().ToArray());
            comboBoxLocalSites.SelectedIndexChanged += ComboBoxLocalSites_SelectedIndexChanged;
        }

        private void ComboBoxLocalSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAvailableBindings.Items.Clear();
            listBoxAvailableBindings.Items.AddRange(_squirrelFinder.GetSiteBindings(comboBoxLocalSites.SelectedItem.ToString()).ToArray());
            UpdateWatchList();
        }

        private void UpdateWatchList()
        {
            //checkedListBoxWatching.Items.Clear();
            //checkedListBoxWatching.Items.AddRange(_squirrelFinder.Nuts.Select(n => n.Url).ToArray());
        }

        private void buttonAddPublicSite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPublicUrl.Text)) return;
            try
            {
                var uri = new Uri(textBoxPublicUrl.Text);
                var nut = new Nut(uri);
                nut.NutChanged += Nut_NutChanged;
                _squirrelFinder.AddNut(nut);
                UpdateWatchList();

                textBoxPublicUrl.Clear();
            }
            catch
            {
                return;
            }
        }

        private void Nut_NutChanged(object sender, NutEventArgs e)
        {
            var nut = e.Nut;

            var tone = SquirrelFinderSound.None;

            if (nut.State == NutState.Found)
            {
                _trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                tone = SquirrelFinderSound.Squirrel;
            }
            else if (nut.State == NutState.Searching)
            {
                _trayIcon.BalloonTipIcon = ToolTipIcon.Warning;
                tone = SquirrelFinderSound.Gears;
            }
            else if (nut.State == NutState.Lost)
            {
                _trayIcon.BalloonTipIcon = ToolTipIcon.Error;
                tone = SquirrelFinderSound.FlatLine;
            }
            else
                _trayIcon.BalloonTipIcon = ToolTipIcon.None;

            if (!nut.HasShownMessage)
            {
                _trayIcon.BalloonTipTitle = nut.GetBalloonTipTitle();
                _trayIcon.BalloonTipText = nut.GetBalloonTipInfo();
                _trayIcon.ShowBalloonTip(5000);
                _squirrelFinder.PlayTone(tone);
                nut.HasShownMessage = true;
            }
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            //foreach (var item in checkedListBoxWatching.CheckedItems)
            //{
            //    _squirrelFinder.RemoveNut(_squirrelFinder.Nuts.Where(n => n.Url.ToString() == item.ToString()).FirstOrDefault());
            //}
            //UpdateWatchList();
        }

        private void buttonAddToWatch_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableBindings.SelectedItem == null) return;
            var url = new Uri(listBoxAvailableBindings.SelectedItem.ToString());
            if (Directory.Exists(_squirrelFinder.GetSitePathFromUrl(url.ToString()) + "/App_Data/Sitefinity"))
            {
                var sitefinityLocalNut = new SitefinityLocalNut(url);
                sitefinityLocalNut.NutChanged += Nut_NutChanged;
                _squirrelFinder.AddNut(sitefinityLocalNut);
            }
            else
            {
                var localNut = new LocalNut(url);
                localNut.NutChanged += Nut_NutChanged;
                _squirrelFinder.AddNut(localNut);
            }

            UpdateWatchList();
        }

        private void iNutBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
