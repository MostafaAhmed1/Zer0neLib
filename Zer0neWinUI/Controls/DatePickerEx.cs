using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DateTimePicker))]
    [DefaultProperty("Value"), DefaultEvent("ValueChanged")]
    public class DatePickerEx : Control 
    {
        DateTimePickerEx ctrl;
        Button b;
        Bitmap bmp;
        //System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ar-eg");
        public DatePickerEx() 
        {
            ctrl = new DateTimePickerEx();
            b = new Button();

            ctrl.Location = new Point(-3, -2);
            ctrl.Font = this.Font;
            ctrl.ForeColor = this.ForeColor;
            ctrl.BackColor = this.BackColor;
            this.Size = new Size(ctrl.Size.Width -37, ctrl.Size.Height-4);

            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = this.BackColor;
            b.ImageAlign = ContentAlignment.MiddleCenter;
            //b.Location = new Point(this.Width - 20, 0);
            //b.Size = new Size(20, this.Height);
            //bmp = new Bitmap(ZTheme.ReplaceColor(Properties.Resources.Calender_32px, Color.Black, this.ForeColor), new Size(b.Size.Width-3, this.Height-3));
            //b.Image = bmp;
            Resiz();
            b.Click += B_Click;

            ctrl.ValueChanged += Ctrl_ValueChanged;

            this.Controls.Add(b);
            this.Controls.Add(ctrl);
        }

        #region Data Properties

        [RefreshProperties(RefreshProperties.Repaint), Category("Zer0ne")]
        public DateTimePickerFormat Format 
        {
            get { return ctrl.Format; }
            set { ctrl.Format = value; }
        }

        [DefaultValue(null) , Category("Zer0ne")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string CustomFormat 
        {
            get { return ctrl.CustomFormat; }
            set { ctrl.CustomFormat = value; }
        }

        [Bindable(true), Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.All)]
        public DateTime Value
        {
            get { return ctrl.Value; }
            set 
            { 
                ctrl.Value = value;
                this.ValueChanged?.Invoke(this, new EventArgs());
            }

        }

        [Category("Zer0ne")]
        public DateTime MaxDate
        {
            get { return ctrl.MaxDate; }
            set { ctrl.MaxDate = value; }
        }

        [Category("Zer0ne")]
        public DateTime MinDate
        {
            get { return ctrl.MinDate; }
            set { ctrl.MinDate = value; }
        }

        #endregion

        #region Methods Events

        public event EventHandler ValueChanged;
        private void Ctrl_ValueChanged(object sender, EventArgs e)
        {
            this.ValueChanged?.Invoke(this, new EventArgs());
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Resiz();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ctrl.Font = this.Font;
            Resiz();
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            ctrl.ForeColor = this.ForeColor;
            Bitmap bmp = new Bitmap(ZTheme.ReplaceColor(Properties.Resources.Calender_32px, Color.Black, this.ForeColor), new Size(b.Size.Width, this.Height / 2));
            b.Image = bmp;
        }
        private void B_Click(object sender, EventArgs e)
        {
            ctrl.Select();
            SendKeys.Send("%{DOWN}");
        }
        void Resiz()
        {
            this.Height = ctrl.Size.Height - 4;
            ctrl.Size = new Size(this.Width + 37, 20);
            b.Location = new Point(this.Width - 20, 0);
            b.Size = new Size(20, this.Height);
            //b.Height = ctrl.Size.Height - 4;
            bmp = new Bitmap(ZTheme.ReplaceColor(Properties.Resources.Calender_32px, Color.Black, this.ForeColor), new Size(b.Size.Width-3, this.Height-3));
            b.Image = bmp;
        }

        #endregion

        #region  Properties

        private Color bk = Color.Green;
        [ Category("Zer0ne")]
        public new Color BackColor
        {
            get
            {
                return bk;
            }

            set
            {
                bk = value;
                ctrl.BackColor = bk;
                b.BackColor = bk;
                Invalidate();
            }
        }

        private string eText = string.Empty;
        [Browsable(true), Category("Zer0ne")]
        public string ErrorText
        {
            get
            {
                return eText;
            }

            set
            {
                eText = value;
            }
        }

        [Category("Zer0ne")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get
            {
                return false;
            }

            set
            {
                value = false;
            }
        }

        #endregion
    }
}
