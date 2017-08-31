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

namespace SquirrelFinder.Forms.UserControls
{
    public partial class NutInfo : UserControl
    {
        private INut n2;
        NutMonitor monitor;

        public NutInfo()
        {
            InitializeComponent();
        }

        public NutInfo(INut n2, NutMonitor monitor)
        {
            this.n2 = n2;
            this.monitor = monitor;
            InitializeComponent();

            linkLabelUrl.Text = n2.Url.ToString();

            buttonRecycle.Click += ButtonRecycle_Click;
            buttonRemove.Click += ButtonRemove_Click;
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
    }
}
