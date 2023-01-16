using System;
using System.Drawing;
using System.Windows.Forms;
using Zer0ne.WinUI.Forms;

namespace Zer0ne.WinUI.Notifications
{
    public partial class ZMessageBox : ZDataForm
    {
        public ZMessageBox(string messageText, MessageBoxButtons buttons, MessageBoxIcon Icon = MessageBoxIcon.Information)
        {
            InitializeComponent();

            RoundCorners = false;
            pnlBtns.ZStyle = new ZControlStyle()
            {
                Radius = 0,
                BorderSize = 3,
                BackColor = ZTheme.AccentColor,
                GradientColor1 = ZTheme.AccentColor,
                GradientColor2 = ZTheme.AccentColor
            };
            pnlTitel.ZStyle = btnClose.ZStyle;
            
            btnSave.Visible = false;
            btnDelete.Visible = false;
            btnExit.Visible = false;
             
            textBox1.Text = messageText;
            textBox1.BackColor = this.BackColor;
            textBox1.ForeColor = ZTheme.TextColor;

            if (buttons == MessageBoxButtons.OK)
            {
                btnDelete.Image = ReplaceColor((Bitmap)btnDelete.Image, Color.FromArgb(0, 0, 0), ZTheme.BacgroundColor);
                btnSave.Visible = false;
                btnDelete.Visible = true;
                btnExit.Visible = false;
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {

                btnSave.Visible = true;
                btnDelete.Visible = false;
                btnExit.Visible = true;
            }
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
