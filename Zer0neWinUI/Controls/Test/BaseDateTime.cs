using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    [DefaultProperty("Value"), DefaultEvent("ValueChanged")]
     class BaseDateTime55 : Control
    {
        //DropDownMonthCalendar dropDownMonthCalendar = new DropDownMonthCalendar();
        public BaseDateTime55()
        {
            DropDownMonthCalendar dropDownMonthCalendar = new DropDownMonthCalendar();
            DateTime d = DateTime.Now;
            nYer = new BaseNumeric();
            nMth = new BaseNumeric();
            nDy = new BaseNumeric();
            nDy.AutoSize = false;
            nMth.AutoSize = false;
            nYer.AutoSize = false;

            nYer.Minimum = 1900;
            nYer.Maximum = 3000;
            nYer.Value = d.Year;
            nYer.BorderColor = base.BackColor;
            nYer.BackColor = base.BackColor;
            nYer.TabStop = false;

            nMth.Minimum = 1;
            nMth.Maximum = 12;
            nMth.Value = d.Month;
            nMth.BorderColor = base.BackColor;
            nMth.BackColor = base.BackColor;
            nMth.TabStop = false;

            nDy.Minimum = 1;
            nDy.Maximum = DateTime.DaysInMonth(d.Year, d.Month);
            nDy.Value = d.Day;
            nDy.BorderColor = base.BackColor;
            nDy.BackColor = base.BackColor;
            nDy.TabStop = false;

            nYer.ValueChanged += Nmrc_ValueChanged;
            nDy.ValueChanged += Nmrc_ValueChanged;
            nMth.ValueChanged += Nmrc_ValueChanged;

            nYer.KeyDown += NYer_KeyDown;
            nMth.KeyDown += NMth_KeyDown;
            nDy.KeyDown += NDy_KeyDown;
            dropDownMonthCalendar.GetDate += DdCal_GetDate;

            btn = new Button();
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.BorderColor = this.BackColor;
            btn.FlatAppearance.MouseDownBackColor = this.BackColor;
            btn.FlatAppearance.MouseOverBackColor = this.BackColor;
            btn.Name = "btnCal";
            btn.Size = new Size(30, this.Font.Height);
            btn.TextImageRelation = TextImageRelation.ImageAboveText;
            btn.UseVisualStyleBackColor = true;
            bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width - 5, nDy.Size.Height - 5);
            btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
            //dropDownMonthCalendar.MaxDate = this.MaxDate;
            //dropDownMonthCalendar.MinDate = this.MinDate;
            btn.Click += (S, E) => 
            {
                dropDownMonthCalendar.MaxDate = this.MaxDate;
                dropDownMonthCalendar.MinDate = this.MinDate;

                nYer.Minimum = this.MinDate.Year;
                nYer.Maximum = this.MaxDate.Year;
                dropDownMonthCalendar.Show(this); 
            };

            arowColor = nYer.ArrowColor;
            borderColor = nYer.BorderColor;
            arrowFocus = nYer.ArrowFocus;

            Size = new Size(400, int.Parse(this.Font.GetHeight().ToString("#")));
            //this.Reset();

            this.Controls.Add(nYer);
            this.Controls.Add(nMth);
            this.Controls.Add(nDy);
            this.Controls.Add(btn);

           
        }

        

        #region Properties

        BaseNumeric nYer;
        BaseNumeric nMth;
        BaseNumeric nDy;
        Button btn;
        Bitmap bmp;
       public  bool flg = true;

        private string errorText = string.Empty;
        [Category("Zer0ne")]
        public string ErrorText
        {
            get
            {
                return errorText;
            }
            set
            {
                errorText = value;
            }
        }

       

        
        [Category("Zer0ne")]
        public Image ImageCalender
        {
            get { return btn.Image; }
            set { btn.Image = value; }
        }

        [Category("Zer0ne")]
        public new Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                nYer.BackColor = value;
                nDy.BackColor = value;
                nMth.BackColor = value;
                btn.FlatAppearance.BorderColor = value;
                btn.FlatAppearance.MouseDownBackColor = value;
                btn.FlatAppearance.MouseOverBackColor = value;
            }
        }


        private Color arrowFocus;
        [Category("Zer0ne")]
        public Color ArrowFocus
        {
            get { return arrowFocus; }
            set
            {
                arrowFocus = value;
                nYer.ArrowFocus = arrowFocus;
                nMth.ArrowFocus = arrowFocus;
                nDy.ArrowFocus = arrowFocus;
            }
        }


        private Color borderColor;
        [Category("Zer0ne")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                nYer.BorderColor = borderColor;
                nMth.BorderColor = borderColor;
                nDy.BorderColor = borderColor;
            }
        }


        private Color arowColor;
        [Category("Zer0ne")]
        public Color ArrowColor
        {
            get { return arowColor; }
            set
            {
                arowColor = value;
                nYer.ArrowColor = arowColor;
                nMth.ArrowColor = arowColor;
                nDy.ArrowColor = arowColor;
            }
        }


        private bool showCalendar = true;
        [Category("Zer0ne")]
        public bool ShowCalendar
        {
            get { return showCalendar; }
            set
            {
                showCalendar = value;
                //Reset();
            }
        }

        
        private DateTime dt = DateTime.Now;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public DateTime Value
        {
            get
            {
                return dt;
            }
            set
            {
                dt = value;
                this.ValueChanged?.Invoke(this, value);
                flg = false;
                nDy.Value = dt.Day;
                nMth.Value = dt.Month;
                nYer.Value = dt.Year;
                flg = true;
            }
        }

        
        private DateTime dtMax = DateTime.Now.AddYears(1000); //new DateTime(2999, 12, 31);
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public DateTime MaxDate
        {
            get
            {
                return dtMax;
            }
            set
            {
                dtMax = value;
            }
        }

        private DateTime dtMin = new DateTime(1900, 1, 1);
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public DateTime MinDate
        {
            get
            {
                return dtMin;
            }
            set
            {
                dtMin = value;
            }
        }


        //private ShowDate displayDate = ShowDate.All;
        //[Category("Zer0ne")]
        //public ShowDate DisplayDate
        //{
        //    get { return displayDate; }
        //    set
        //    {
        //        displayDate = value;
        //        Reset();
        //        this.Invalidate();
        //    }
        //}
        #endregion

        #region -> Event - override - methods

        public event EventHandler<DateTime> ValueChanged;
        private void Nmrc_ValueChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                nDy.Maximum = DateTime.DaysInMonth(Convert.ToInt32(nYer.Value), Convert.ToInt32(nMth.Value));
                if ((int)nDy.Value > (int)nDy.Maximum)
                {
                    nDy.Value = nDy.Maximum;
                }
                this.Value = new DateTime((int)nYer.Value, (int)nMth.Value, (int)nDy.Value, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTime.Now.Kind);
            }
        }
        private void DdCal_GetDate(object sender, DateTime e)
        {
            flg = false;
            nDy.Maximum = DateTime.DaysInMonth(e.Year, e.Month);
            if ((int)nDy.Value > (int)nDy.Maximum)
            {
                nDy.Value = nDy.Maximum;
            }
            nDy.Value = e.Day;
            nMth.Value = e.Month;
            nYer.Value = e.Year;
            this.Value = e;
            flg = true;
        }
        private void NDy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                nMth.Select();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
        private void NYer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                nDy.Select();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
        private void NMth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                nYer.Select();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            nYer.Enabled = this.Enabled;
            nMth.Enabled = this.Enabled;
            nDy.Enabled = this.Enabled;
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            nYer.Font = this.Font;
            nMth.Font = this.Font;
            nDy.Font = this.Font;
            //Reset();
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            nYer.ForeColor = this.ForeColor;
            nMth.ForeColor = this.ForeColor;
            nDy.ForeColor = this.ForeColor;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //Reset();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
           //this.Reset();
        }

        /*
        private void Reset()
        {

            switch (DisplayDate)
            {
                case ShowDate.DayMonth:
                    nDy.Size = new Size(ShowCalendar ? (Size.Width / 2) - 12 : (Size.Width / 2), int.Parse(nDy.Font.GetHeight().ToString("#")));
                    nMth.Size = new Size(ShowCalendar ? (Size.Width / 2) - 12 : (Size.Width / 2), int.Parse(nMth.Font.GetHeight().ToString("#")));

                    nMth.Location = new Point( nYer.Location.X, nYer.Location.Y);
                    nYer.SendToBack();
                    nDy.Left =  nMth.Width;
                    Height = nDy.Font.Height + 1;

                    if (ShowCalendar == true)
                    {
                        btn.Size = new Size(Size.Width - (nMth.Width + nDy.Width), Height);
                        btn.Left =  nMth.Width + nDy.Width;
                        btn.Top = 0;
                        bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width, Height);
                        btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
                    }
                    break;
                case ShowDate.DayYear:
                    nDy.Size = new Size(ShowCalendar ? (Size.Width / 2) - 12 : (Size.Width / 2), int.Parse(nDy.Font.GetHeight().ToString("#")));
                    nYer.Size = new Size(ShowCalendar ? (Size.Width / 2) - 12 : (Size.Width / 2), int.Parse(nYer.Font.GetHeight().ToString("#")));

                    nDy.Location = new Point(nMth.Location.X, nMth.Location.Y);
                    nMth.SendToBack();
                    nDy.Left = nYer.Width;
                    Height = nDy.Font.Height + 1;

                    if (ShowCalendar == true)
                    {
                        btn.Size = new Size(Size.Width - (nYer.Width + nDy.Width), Height);
                        btn.Left = nYer.Width + nDy.Width;
                        btn.Top = 0;
                        bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width, Height);
                        btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
                    }
                    else
                    {
                        btn.Size = new Size(0, 0);
                    }
                    break;

                case ShowDate.MonthYear:
                    nDy.SendToBack();
                    nMth.Size = new Size(ShowCalendar ? (Size.Width / 2) - 12  : (Size.Width / 2), int.Parse(nMth.Font.GetHeight().ToString("#")));
                    nYer.Size = new Size(ShowCalendar ? (Size.Width / 2) - 12 : (Size.Width / 2), int.Parse(nYer.Font.GetHeight().ToString("#")));
                    nMth.Left = nYer.Width;
                    Height = nMth.Font.Height + 1;

                    if (ShowCalendar == true)
                    {
                        btn.Size = new Size(Size.Width - (nYer.Width + nMth.Width ), Height);
                        btn.Left = nYer.Width + nMth.Width;
                        btn.Top = 0;
                        bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width, Height);
                        btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
                    }
                    else
                    {
                        btn.Size = new Size(0, 0);
                    }
                    break;
                case ShowDate.All:
                default:
                    nYer.Size = new Size(ShowCalendar ? (Size.Width / 3) - 8 : (Size.Width / 3), int.Parse(nYer.Font.GetHeight().ToString("#")));
                    nMth.Size = new Size(ShowCalendar ? (Size.Width / 3) - 8 : (Size.Width / 3), int.Parse(nMth.Font.GetHeight().ToString("#")));
                    nDy.Size = new Size(ShowCalendar ? (Size.Width / 3) - 8 : (Size.Width / 3), int.Parse(nDy.Font.GetHeight().ToString("#")));

                    nMth.Left = nYer.Width;
                    nDy.Left = nYer.Width + nMth.Width;
                    Height = nDy.Font.Height + 1;

                    if (ShowCalendar == true)
                    {
                        btn.Size = new Size(Size.Width - (nYer.Width + nMth.Width + nDy.Width), Height);
                        btn.Left = nYer.Width + nMth.Width + nDy.Width;
                        btn.Top = 0;
                        bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width, Height);
                        btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
                    }
                    else
                    {
                        btn.Size = new Size(0, 0);
                    }
                    break;
            }
        }
        */
        #endregion

    }
}
