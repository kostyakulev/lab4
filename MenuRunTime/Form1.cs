using System;
using System.Windows.Forms;

namespace _4 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void mnuChangeColor_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e) {
            object[] sc = new object[Enum.GetValues(typeof(Shortcut)).Length];
            Enum.GetValues(typeof(Shortcut)).CopyTo(sc, 0);
            cmbShortCuts.Items.AddRange(sc);
        }

        private void btnAdd_Click(object sender, System.EventArgs e) {
            //Если значение текстового поля пустое, выводим сообщение
            if (txtMenuText.Text == " ") {
                //Текст сообщения
                MessageBox.Show("Введите текст для пункта меню");
                return;
            }
            //Если не выбрано значение сочетания клавиш, выводим сообщение
            if (cmbShortCuts.SelectedItem == null) {
                //Текст сообщения
                MessageBox.Show("Выберите сочетание клавиш");
                return;
            }
            //Создаем новый экземпляр mnu класса пунктов меню MenuItem
            ToolStripMenuItem mnu = new ToolStripMenuItem();
            //Устанавливаем в качестве текста пункта значение, введенное в txtMenuText
            mnu.Text = txtMenuText.Text;
            //Устанавливаем в качестве сочетания клавиш данного пункта
            //выбранное значение из cmbShortCuts
            mnu.ShortcutKeys = (Keys)cmbShortCuts.SelectedItem;
            //Добавляем пункт в контекстное меню contextMenu1
            contextMenuStrip1.Items.Add(mnu);
            //Определяем обработчик для события Click экземпляра mnu
            mnu.Click += new System.EventHandler(this.NewmnuChangeColor_Click);
        }

        private void NewmnuChangeColor_Click(object sender, System.EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                this.BackColor = colorDialog1.Color;
            }
        }
    }
}
