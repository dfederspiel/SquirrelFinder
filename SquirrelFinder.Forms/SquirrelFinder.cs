using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SquirrelFinder.Forms
{
    public class SquirrelFinderSysTrayApp : Form
    {
        static NutMonitor _nutMonitor;
        static System.Timers.Timer _timer;
        static NotifyIcon _trayIcon;
        static ContextMenuStrip _trayMenu;
        static Config _configForm;

        [STAThread]
        public static void Main()
        {
            Application.Run(new SquirrelFinderSysTrayApp());
        }

        public SquirrelFinderSysTrayApp()
        {
            _nutMonitor = new NutMonitor();

            ConfigureTrayMenu();
            ConfigureTrayIcon();

            SetTimer(5000);
        }

        #region Configuration
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SquirrelFinderSysTrayApp));
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SquirrelFinder";
            this.Text = "Squirrel Finder";
            this.ResumeLayout(false);
        }
        private void SetTimer(int interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }
        #endregion

        #region Toolbar Menu
        private void ConfigureTrayMenu()
        {
            _trayMenu = new ContextMenuStrip();

            _trayMenu.Items.Add("Configure...", null, OnConfigure);
            _trayMenu.Items.Add("Exit", null, OnExit);
        }

        private void ConfigureTrayIcon()
        {
            _trayIcon = new NotifyIcon();
            _trayIcon.Text = "Squirrel Finder";
            _trayIcon.Icon = new Icon(SystemIcons.Information, 40, 40);

            _trayIcon.ContextMenuStrip = _trayMenu;
            _trayIcon.Visible = true;
            _trayIcon.DoubleClick += TrayIcon_DoubleClick;
            _trayIcon.BalloonTipClicked += _trayIcon_BalloonTipClicked;
        }

        private void _trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            var url = _nutMonitor.Nuts.Select(n => n.Url.ToString()).First();
            System.Diagnostics.Process.Start(url);
        }
        #endregion

        #region Event Handlers
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            OnConfigure(sender, e);
        }

        private void OnConfigure(object sender, EventArgs e)
        {
            if (_configForm == null || _configForm.IsDisposed)
            {
                _configForm = new Config(_nutMonitor, _trayIcon);
                _configForm.MinimizeBox = false;
                _configForm.MaximizeBox = false;
            }

            _configForm.Show();

        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_nutMonitor == null) return;
            await _nutMonitor.PeekAll();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _trayIcon.Dispose();
            }
            base.Dispose(isDisposing);
        }
    }
}
