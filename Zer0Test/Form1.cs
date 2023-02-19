using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI;
using Zer0ne.WinUI.Forms;

namespace Zer0Test
{
    public partial class Form1 : ZMasterForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //controlBase2.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Right, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });
            //controlBase2.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Left, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });
            //controlBase2.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Right, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });
            //controlBase2.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Left, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });

            txtBx1.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Right, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });
            txtBx1.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Left, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });
            txtBx1.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Right, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });
            txtBx1.AddItem(Zer0ne.WinUI.Utilities.ItemPositionZ.Left, btnMaximize.Image, (s, x) => { MsgBox.Alert("hi..!"); });

        }

        private void zButton1_Click(object sender, EventArgs e)
        {
            var res = MsgBox.Msg("wellcome..!", MessageBoxButtons.YesNo);

            MsgBox.Alert(res.ToString());
        }

        private void zButton2_Click(object sender, EventArgs e)
        {
            //controlBase1.ZStyle.BorderSize = 10;
            //controlBase1.ZStyle.Radius = 30;

            ////controlBase1.Size = new Size(400, 100);
            //controlBase1.Size = new Size(controlBase1.Width + 1, controlBase1.Height);

            //controlBase1.Font = new Font("Tahoma", 32);

            var frm = new ZForm();
            //frm.RoundCorners = true;
            frm.Show(this);

            ZTheme.AccentColor = Color.LightGreen;
        }

        private void zToggle1_ValueChanged(object sender, bool e)
        {
            MsgBox.Alert(e.ToString());
        }

        private void zComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zComboBox1.SelectedIndex == 0)
            {
                MsgBox.Alert(txtBx1.Text);
            }
            if (zComboBox1.SelectedIndex == 1)
            {
                MsgBox.Alert("Hi...");
            }
        }
    }
}
