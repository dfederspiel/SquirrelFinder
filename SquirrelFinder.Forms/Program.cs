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
        static NutMonitor _finder;
        static System.Timers.Timer _timer;
        static NutState CurrentState;

        [STAThread]
        public static void Main()
        {
            Application.Run(new SquirrelFinderSysTrayApp());
        }
        NotifyIcon trayIcon;
        ContextMenuStrip trayMenu;

        public SquirrelFinderSysTrayApp()
        {
            _finder = new NutMonitor();

            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenuStrip();

            trayMenu.Items.Add("Configure...", null, OnConfigure);
            //trayMenu.Items.Add("Watch List", null, OnWatchList);
            //trayMenu.Items.Add("Watch Remote...", null, OnWatchRemote);
            //trayMenu.Items.Add("Watch Local...", null, OnWatchLocal);
            trayMenu.Items.Add("Exit", null, OnExit);

            //_finder = new SquirrelFinder("BASitefinityOOB", new SitefinityNut { Location = "http://basitefinityoob.local/" });

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Squirrel Finder";
            trayIcon.Icon = new Icon(SystemIcons.Information, 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenuStrip = trayMenu;

            trayIcon.Visible = true;

            trayIcon.DoubleClick += TrayIcon_DoubleClick;

            //trayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;

            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            OnConfigure(sender, e);
        }

        private void OnConfigure(object sender, EventArgs e)
        {
            Config configForm = new Config(_finder, trayIcon);
            configForm.Show();
        }

        //private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Watch w = new Watch(_finder);
        //    w.Show();
        //}

        private async void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //var publicSite = _finder.Nuts.FirstOrDefault();
            //var result = publicSite.Peek();
            if (_finder == null) return;
            await _finder.PeekAll();

            //switch (_finder.PeekAll())
            //{
            //    case State.Found:
            //        if (CurrentState != State.Found)
            //        {
            //            trayIcon.Text = "Squirrel Finder (OK!)";
            //            trayIcon.Icon = new Icon(SystemIcons.Information, 40, 40);

            //            // Add menu to tray icon and show it.
            //            trayIcon.ContextMenuStrip = trayMenu;
            //            trayIcon.Visible = true;

            //            _finder.PlayTone(SquirrelFinderSound.Squirrel);
            //            CurrentState = State.Found;
            //        }
            //        break;
            //    case State.Searching:
            //        if (CurrentState != State.Searching)
            //        {
            //            trayIcon.Text = "Squirrel Finder (WAITING!)";
            //            trayIcon.Icon = new Icon(SystemIcons.Warning, 40, 40);

            //            // Add menu to tray icon and show it.
            //            trayIcon.ContextMenuStrip = trayMenu;
            //            trayIcon.Visible = true;

            //            _finder.PlayTone(SquirrelFinderSound.Gears);
            //            CurrentState = State.Searching;
            //        }
            //        break;
            //    case State.Lost:
            //        if (CurrentState != State.Lost)
            //        {
            //            trayIcon.Text = "Squirrel Finder (Shit!)";
            //            trayIcon.Icon = new Icon(SystemIcons.Error, 40, 40);

            //            // Add menu to tray icon and show it.
            //            trayIcon.ContextMenuStrip = trayMenu;
            //            trayIcon.Visible = true;

            //            _finder.PlayTone(SquirrelFinderSound.FlatLine);
            //            CurrentState = State.Lost;
            //        }
            //        break;
            //}
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
