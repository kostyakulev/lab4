using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XML {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            using (var filestream
                = new FileStream(
                    System.Environment.CurrentDirectory + "\\applicationSettings.xml",
                    FileMode.Create))
                new XmlSerializer(typeof(FormSize)).Serialize(filestream, new FormSize {
                    height = Height,
                    width = Width
                });
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            try {
                using (var filestream = new FileStream(System.Environment.CurrentDirectory
                    + "\\applicationSettings.xml", FileMode.Open)) {
                    var frmSizeSetup
                        = (FormSize)new XmlSerializer(typeof(FormSize)).Deserialize(filestream);
                    Height = frmSizeSetup.height;
                    Width = frmSizeSetup.width;
                }
            } catch (FileNotFoundException) {}
        }
    }
}
