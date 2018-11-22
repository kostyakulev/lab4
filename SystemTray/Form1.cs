using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTray {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        private void mnuShow_Click(object sender, EventArgs e) {
            ShowInTaskbar = true;
            Show();
            mnuShow.Enabled = false;
            mnuHide.Enabled = true;
        }

        private void mnuHide_Click(object sender, EventArgs e) {
            ShowInTaskbar = false;
            Hide();
            mnuShow.Enabled = true;
            mnuHide.Enabled = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            mnuShow_Click(this, new EventArgs());
        }

       
    }
}
