using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrySettings {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            var regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\RegApplication", true);
            if (regkey == null) {
                RegistryKey newregkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft", true);
                regkey = newregkey.CreateSubKey("RegApplication");
            }
            regkey.SetValue("Height", Height);
            regkey.SetValue("Width", Width);
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                var regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\RegApplication");
                Height = Convert.ToInt32(regkey.GetValue("Height"));
                Width = Convert.ToInt32(regkey.GetValue("Width"));
            } catch (NullReferenceException) {}
        }

        
    }
}
