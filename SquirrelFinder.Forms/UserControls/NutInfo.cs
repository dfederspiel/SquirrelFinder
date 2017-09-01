using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SquirrelFinder.Nuts;
using System.Diagnostics;

namespace SquirrelFinder.Forms.UserControls
{
    public partial class NutInfo : UserControl
    {
        private INut n2;
        NutManager monitor;

        public NutInfo()
        {
            InitializeComponent();
        }

        public NutInfo(INut n2, NutManager monitor)
        {
            this.n2 = n2;
            this.n2.NutChanged += N2_NutChanged;
            this.monitor = monitor;
            InitializeComponent();

            linkLabelUrl.Text = n2.Url.ToString();

            buttonRecycle.Click += ButtonRecycle_Click;
            buttonRemove.Click += ButtonRemove_Click;
            UpdateControl(n2.State);
        }

        private void UpdateControl(NutState state)
        {
            if (state == NutState.Lost)
                //buttonRecycle.Enabled = false;
                panelStatusLight.BackColor = Color.Red;
            if (state == NutState.Found)
                //buttonRecycle.Enabled = true;
            panelStatusLight.BackColor = Color.Green;
            if (state == NutState.Searching)
                panelStatusLight.BackColor = Color.Yellow;
        }

        private void N2_NutChanged(object sender, NutEventArgs e)
        {
            UpdateControl(n2.State);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            monitor.RemoveNut(n2);
        }

        private void ButtonRecycle_Click(object sender, EventArgs e)
        {
            if(n2.GetType().GetInterfaces().Where(i => i.Name == "ILocalNut").Count() > 0)
            {
                var n = (ILocalNut)n2;
                n.RecycleSite();
            }
        }

        private void linkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", n2.Url.ToString());
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (n2.GetType().GetInterfaces().Where(i => i.Name == "ILocalNut").Count() > 0)
            {
                var n = (ILocalNut)n2;
                n.StartSite();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (n2.GetType().GetInterfaces().Where(i => i.Name == "ILocalNut").Count() > 0)
            {
                var n = (ILocalNut)n2;
                n.StopSite();
            }
        }
    }
}
