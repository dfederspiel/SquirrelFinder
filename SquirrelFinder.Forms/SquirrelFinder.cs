using SquirrelFinder.Notifications;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SquirrelFinder.Forms
{
    public class SquirrelFinderSysTrayApp : Form
    {
        static NutManager _nutManager;
        static System.Windows.Forms.Timer _timer;
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
            _nutManager = new NutManager();

            _nutManager.NutCollectionChanged    += NutManager_NutsChanged;
            _nutManager.NutChanged              += NutManager_NutChanged;

            ConfigureTrayMenu();
            ConfigureTrayIcon();

            SetTimer(5000);
        }

        private void NutManager_NutsChanged(object sender, NutCollectionEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void NutManager_NutChanged(object sender, NutEventArgs e)
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
                _trayIcon.BalloonTipIcon = ToolTipIcon.Info;

            if (!nut.HasShownMessage)
            {
                var title = nut.GetBalloonTipTitle();
                var message = nut.GetBalloonTipInfo();
                _trayIcon.BalloonTipTitle = title;
                _trayIcon.BalloonTipText = message;
                NotificationManager.Add(nut, title, message);
                _trayIcon.ShowBalloonTip(nut.State != NutState.Found ? 2000 : 10000);

                _nutManager.PlayTone(tone);
                nut.HasShownMessage = true;
            }
        }

        #region Configuration
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SquirrelFinderSysTrayApp));
            this.SuspendLayout();
            // 
            // SquirrelFinderSysTrayApp
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SquirrelFinderSysTrayApp";
            this.Text = "Squirrel Finder";
            this.ResumeLayout(false);

        }
        private void SetTimer(int interval)
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private async void _timer_Tick(object sender, EventArgs e)
        {
            if (_nutManager == null) return;
            await _nutManager.PeekAllNuts();
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
            var icon = (NotifyIcon)sender;
            var notification = NotificationManager.GetNotificationForMessage(icon.BalloonTipText);
            switch (notification.State)
            {
                case NutState.NotChecked:
                    break;
                case NutState.Found:
                    Process.Start("chrome.exe", notification.Url);
                    break;
                case NutState.Searching:
                    
                    break;
                case NutState.Lost:
                    if (_configForm == null || _configForm.IsDisposed)
                    {
                        _configForm = new Config(_nutManager, _trayIcon);
                        _configForm.MinimizeBox = false;
                        _configForm.MaximizeBox = false;
                    }

                    _configForm.Show();
                    break;
            }
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
                _configForm = new Config(_nutManager, _trayIcon);
                _configForm.MinimizeBox = false;
                _configForm.MaximizeBox = false;
            }

            _configForm.Show();

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
