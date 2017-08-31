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

namespace SquirrelFinder.Forms
{
    public partial class Config : Form
    {
        NutMonitor _squirrelFinder;
        NotifyIcon _trayIcon;
        BindingSource _nutBindingSource;
        public Config(NutMonitor finder, NotifyIcon trayIcon)
        {
            _squirrelFinder = finder == null ? new NutMonitor() : finder;
 
            _trayIcon = trayIcon;
            _trayIcon.BalloonTipClicked += _trayIcon_BalloonTipClicked;

            InitializeComponent();
            InitializeLocalSites();

            _nutBindingSource = new BindingSource();
            _nutBindingSource.DataSource = typeof(SquirrelFinder.Nuts.INut);
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "IsLocal";
            col1.HeaderText = "Is Local";
            col1.Name = "column_is_local";
            dataGridView1.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Location";
            col2.HeaderText = "Location";
            col2.Name = "column_location";
            dataGridView1.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "State";
            col2.HeaderText = "State";
            col2.Name = "column_state";
            dataGridView1.Columns.Add(col3);

            _nutBindingSource.DataSource = _squirrelFinder.Nuts;
            dataGridView1.DataSource = _nutBindingSource;

            UpdateWatchList();
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
            checkedListBoxWatching.Items.Clear();
            checkedListBoxWatching.Items.AddRange(_squirrelFinder.Nuts.Select(n => n.Url).ToArray());

            _nutBindingSource.DataSource = _squirrelFinder.Nuts.ToList();
            dataGridView1.DataSource = _nutBindingSource;

        }

        private void buttonAddPublicSite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPublicUrl.Text)) return;

            var nut = new Nut(textBoxPublicUrl.Text);
            nut.NutChanged += Nut_NutChanged;
            _squirrelFinder.AddNut(nut);
            UpdateWatchList();

            textBoxPublicUrl.Clear();
        }

        private void Nut_NutChanged(object sender, NutEventArgs e)
        {
            var nut = e.Nut;
            var tone = SquirrelFinderSound.None;

            if (nut.State == NutState.Found) {
                _trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                tone = SquirrelFinderSound.Squirrel;
            }
            else if (nut.State == NutState.Searching) { 
                _trayIcon.BalloonTipIcon = ToolTipIcon.Warning;
                tone = SquirrelFinderSound.Gears;
            }
            else if (nut.State == NutState.Lost) { 
                _trayIcon.BalloonTipIcon = ToolTipIcon.Error;
                tone = SquirrelFinderSound.FlatLine;
            }
            else
                _trayIcon.BalloonTipIcon = ToolTipIcon.None;

            if (!nut.HasShownMessage)
            {
                _trayIcon.BalloonTipTitle = "Nut Activity: " + nut.Url.ToString();
                _trayIcon.BalloonTipText = nut.GetInfo();
                _trayIcon.ShowBalloonTip(5000);
                nut.HasShownMessage = true;
            }
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxWatching.CheckedItems)
            {
                _squirrelFinder.RemoveNut(_squirrelFinder.Nuts.Where(n => n.Url.ToString() == item.ToString()).FirstOrDefault());
            }
            UpdateWatchList();
        }

        private void buttonAddToWatch_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableBindings.SelectedItem == null) return;

            if (Directory.Exists(_squirrelFinder.GetSitePathFromUrl(listBoxAvailableBindings.SelectedItem.ToString()) + "/App_Data/Sitefinity"))
            {
                var sitefinityLocalNut = new SitefinityLocalNut(listBoxAvailableBindings.SelectedItem.ToString());
                sitefinityLocalNut.NutChanged += Nut_NutChanged;
                _squirrelFinder.AddNut(sitefinityLocalNut);
            }
            else
            {
                var localNut = new LocalNut(listBoxAvailableBindings.SelectedItem.ToString());
                localNut.NutChanged += Nut_NutChanged;
                _squirrelFinder.AddNut(localNut);
            }
                
            UpdateWatchList();
        }
    }
}
