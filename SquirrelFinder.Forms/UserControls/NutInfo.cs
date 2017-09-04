﻿using System;
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
using Microsoft.Web.Administration;

namespace SquirrelFinder.Forms.UserControls
{
    public partial class NutInfo : UserControl
    {
        INut _nut;
        NutManager _nutMonitor;

        public NutInfo()
        {
            InitializeComponent();
        }

        public NutInfo(INut n2, NutManager nutMonitor)
        {
            _nut = n2;
            _nut.NutChanged += N2_NutChanged;
            _nutMonitor = nutMonitor;

            InitializeComponent();

            linkLabelUrl.Text = n2.Url.ToString();
            linkLabelUrl.LinkClicked += LinkLabelUrl_LinkClicked;

            if (n2 is ILocalNut)
            {
                linkLabelAppDirectory.Click += LinkLabelAppDirectory_Click;
                linkLabelLogs.Click += LinkLabelLogs_Click;

                buttonRecycle.Click += ButtonRecycle_Click;
                buttonToggle.Click += ButtonToggle_Click;

                (n2 as ILocalNut).SiteStateChanged += NutInfo_SiteStateChanged;
            }
            else
            {
                linkLabelAppDirectory.Visible = false;
                linkLabelLogs.Visible = false;
                buttonRecycle.Visible = false;
                buttonToggle.Visible = false;
            }

            ButtonRemove.Click += ButtonRemove_Click;

            UpdateControl();
            UpdateButtonToggleText();
        }

        private void NutInfo_SiteStateChanged(object sender, NutEventArgs e)
        {
            UpdateControl();
            UpdateButtonToggleText();
        }

        private void UpdateButtonToggleText()
        {
            if (_nut is ILocalNut)
            {
                SetButtonTextFromState((_nut as ILocalNut));
            }
        }

        delegate void SetTextCallback(ILocalNut nut);
        private void SetButtonTextFromState(ILocalNut localNut)
        {
            var text = "";
            switch (localNut.ApplicationPoolState)
            {
                case ObjectState.Started:
                case ObjectState.Starting:
                    text = "Stop";
                    break;
                case ObjectState.Stopped:
                case ObjectState.Stopping:
                    text = "Start";
                    break;
                case ObjectState.Unknown:
                    text = "...";
                    break;
            }

            if (buttonToggle.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetButtonTextFromState);
                Invoke(d, new object[] { localNut });
            }
            else
            {
                buttonToggle.Text = text;
            }
        }

        private void UpdateControl()
        {
            SetNutInfoColorStatus();
            if (_nut is ILocalNut)
            {
                var state = GetApplicationPoolState();
                SetButtonTextFromState(_nut as ILocalNut);
            }
        }

        private ObjectState GetApplicationPoolState()
        {
            return NutHelper.GetApplicationPoolFromUrl(_nut.Url).State;
        }

        private void SetNutInfoColorStatus()
        {
            if (_nut.State == NutState.Lost)
                panelStatusLight.BackColor = Color.Red;
            if (_nut.State == NutState.Found)
                panelStatusLight.BackColor = Color.Green;
            if (_nut.State == NutState.Searching)
                panelStatusLight.BackColor = Color.Yellow;
        }

        private void N2_NutChanged(object sender, NutEventArgs e)
        {
            UpdateControl();
        }

        private void ToggleApplicationPoolState()
        {
            if (_nut is ILocalNut)
            {
                var localNut = (_nut as ILocalNut);
                switch (localNut.ApplicationPoolState)
                {
                    case ObjectState.Started:
                    case ObjectState.Starting:
                        localNut.StopApplicationPool();
                        break;
                    case ObjectState.Stopped:
                    case ObjectState.Stopping:
                        localNut.StartApplicationPool();
                        break;
                    case ObjectState.Unknown:
                        break;
                }

            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            _nutMonitor.RemoveNut(_nut);
        }

        private void ButtonRecycle_Click(object sender, EventArgs e)
        {
            if (_nut is ILocalNut)
                (_nut as ILocalNut).RecycleApplicationPool();
        }

        private void LinkLabelLogs_Click(object sender, EventArgs e)
        {
            if (_nut is ILocalNut)
                Process.Start("explorer.exe", (_nut as ILocalNut).Path + "\\App_Data\\Sitefinity\\Logs");
        }

        private void LinkLabelAppDirectory_Click(object sender, EventArgs e)
        {
            var localNutType = (ILocalNut)_nut;
            Process.Start("explorer.exe", localNutType.Path);
        }

        private void ButtonToggle_Click(object sender, EventArgs e)
        {
            ToggleApplicationPoolState();
        }

        private void LinkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", _nut.Url.ToString());
        }
    }
}
