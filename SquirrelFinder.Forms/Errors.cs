using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquirrelFinder.Forms
{
    public partial class Errors : Form
    {
        public Errors(List<SquirrelFinderLogEntry> entries)
        {
            InitializeComponent();

            foreach(var entry in entries)
            {
                flowLayoutPanel1.Controls.Add(new Label() { Text = entry.LogEntry.Message, Size = new Size(539, 100) });
                flowLayoutPanel1.AutoScroll = true;
            }
        }
    }
}
