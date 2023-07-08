using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI.Forms;
using Zer0ne.WinUI.Properties;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Notifications
{
    public partial class ZAlert : ZForm
    {
        Timer timer = new Timer();
        private int x, y;
        private ActionZ action;

        public ZAlert()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;

            RoundCorners = false;
            //lblTitel.ZStyle = new ZControlStyle()
            //{
            //    Radius = 0,
            //    BorderSize = 0
            //};
            //lblMsg.ZStyle = lblTitel.ZStyle;
            //picType.ZStyle = lblTitel.ZStyle;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case ActionZ.wait:
                    timer.Interval = 5000;
                    action = ActionZ.close;
                    break;
                case ActionZ.start:
                    this.timer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = ActionZ.wait;
                        }
                    }
                    break;
                case ActionZ.close:
                    timer.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }
        
        private void picType_Click(object sender, EventArgs e)
        {
            timer.Interval = 1;
            action = ActionZ.close;
        }

        public void ShowAlert(string msg, string Title = "", AlertTypeZ type= AlertTypeZ.Success, PositionZ msgLocation= PositionZ.BottomRight)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            if (Title.Length > 0)
            {
                ShowTitelPanel = true;
            }
            else
            {
                ShowTitelPanel = false;
            }

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                ZAlert frm = (ZAlert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;

                    switch (msgLocation)
                    {
                        case PositionZ.BottomRight:
                            //BottomRight:
                            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                            this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                            break;
                        case PositionZ.TopRight:
                            //TopRight:
                            int ng = i - 1;
                            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                            this.y = Screen.PrimaryScreen.WorkingArea.Top + this.Height * ng + 5 * ng;
                            break;
                        case PositionZ.BottomLeft:
                            //BottomLeft:
                            this.x = Screen.PrimaryScreen.WorkingArea.X;
                            this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                            break;
                        case PositionZ.TopLeft:
                            // TopLeft:
                            int ng2 = i - 1;
                            this.x = Screen.PrimaryScreen.WorkingArea.X;
                            this.y = Screen.PrimaryScreen.WorkingArea.Top + this.Height * ng2 + 5 * ng2;
                            break;
                        default:
                            break;
                    }

                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            //lblMsg.ForeColor = ZTheme.TextColor;
            switch (type)
            {
                case AlertTypeZ.Success:
                    this.picType.Image = Resources.success;
                    this.BackColor = lblMsg.BackColor = picType.BackColor = Color.SeaGreen;
                    break;
                case AlertTypeZ.Error:
                    this.picType.Image = Resources.error;
                    this.BackColor = lblMsg.BackColor = picType.BackColor = Color.DarkRed;
                    break;
                case AlertTypeZ.Info:
                    this.picType.Image = Resources.info;
                    this.BackColor = lblMsg.BackColor = picType.BackColor = Color.RoyalBlue;
                    break;
                case AlertTypeZ.Warning:
                    this.picType.Image = Resources.warning;
                    this.BackColor = lblMsg.BackColor = picType.BackColor = Color.DarkOrange;
                    break;
            }


            this.lblMsg.Text = msg;
            var frmPrnt = Application.OpenForms[0];
            if (frmPrnt.InvokeRequired)
            {
                frmPrnt.Invoke(new MethodInvoker(() =>
                {
                    this.Show(frmPrnt);
                }));
            }
            else
            {
                this.Show(frmPrnt);
            }
            this.action = ActionZ.start;
            this.timer.Interval = 1;
            this.timer.Enabled = true;
            this.timer.Start();
        }

        private void ZAlert_Load(object sender, EventArgs e)
        {

        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

    }
}
