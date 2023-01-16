using System;
using System.Windows.Forms;
using Zer0ne.WinUI.Forms;

namespace Zer0ne.WinUI.Notifications
{
    public partial class ZInputMessageBox : ZDataForm
    {
        private decimal resultNumber;
        public decimal ResultNumber 
        {
            get
            {
                return resultNumber;
            }
            set
            {
                resultNumber = value;
            }
        }

        public ZInputMessageBox(string messageText)
        {
            InitializeComponent();

            textBox1.Text = messageText;
            textBox1.BackColor = this.BackColor;
            textBox1.ForeColor = ZTheme.BacgroundColor;

            numericUpDown1.ForeColor = ZTheme.AccentColor;

            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnExit.Visible = true;

            resultNumber = 0;
        }

        private void frmInputMessageBox_Load(object sender, EventArgs e)
        {
            keyBoard1.Keyboard = ZTheme.DevNumericKeyboard();

            numericUpDown1.Select();
            numericUpDown1.Focus();
            numericUpDown1.Select(0, numericUpDown1.Text.ToString().Length);
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            resultNumber = numericUpDown1.Value;
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            keyBoard1.Show();
        }
    }
}
