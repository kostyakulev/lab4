using System.Windows.Forms;

namespace UserInput {
    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e) {

        }

        private void txtName_Validated(object sender, System.EventArgs e) {
            if (nameValid())
                errorProvider1.SetError(txtName, "");
            else {
                //Поле не заполнено — выводим сообщение
                errorProvider1.SetError(txtName, "Name is required.");
                lbloutput.Text = "Введите имя!";
            }
        }

        private void numUDAge_Validated(object sender, System.EventArgs e) {
            if (ageLess()) {
                errorProvider1.SetError(numUDAge, "Age not old enough");
                lbloutput.Text = "Введите значение, большее или равное 25";
            } else if (ageMore()) {
                errorProvider1.SetError(numUDAge, "Age is too old");
                lbloutput.Text = "Введите значение, меньшее или равное 65";
            } else {
                errorProvider1.SetError(numUDAge, "");
            }
        }

        private bool nameValid() {
            return txtName.Text.Length > 0;
        }
        private bool ageLess() {
            return numUDAge.Value > 25;
        }
        private bool ageMore() {
            //Возраст больше 25
            return numUDAge.Value > 65;
        }
    }
}
