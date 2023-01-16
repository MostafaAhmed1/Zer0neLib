//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Drawing;
//using System.Globalization;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Zer0ne.WinUI.Utilities;
////DateTimePickerWithBackground
//namespace Zer0ne.WinUI.Controls
//{
    
//    [DefaultProperty("Value"), DefaultEvent("ValueChanged")]
//     class ZDateTimeEx : Control
//    {
        
//        //Separator
//        public ZDateTimeEx()
//        {
//            CultureInfo.CurrentCulture.ClearCachedData();
//            DropDownMonthCalendar dropDownMonthCalendar = new DropDownMonthCalendar();

//            base.BackColor = this.BackColor;
//            txtYer = new TextBox ();
//            txtYer.BorderStyle = BorderStyle.None;
//            txtYer.TabStop = false;
//            txtYer.BackColor = this.BackColor;
//            txtYer.TextAlign = HorizontalAlignment.Center;
//            txtYer.Font = this.Font;
//            txtYer.ForeColor = this.ForeColor;
//            txtYer.GotFocus += TxtYer_GotFocus;
//            txtYer.Click += TxtYer_Click;
//            txtYer.Enter += TxtYer_Enter;
//            txtYer.KeyDown += TxtYer_KeyDown;
//            txtYer.KeyPress += Txt_KeyPress;
//            txtYer.KeyUp += Txt_KeyUp;
//            txtYer.MouseWheel += Txt_MouseWheel;
//            txtYer.TextChanged += TxtYer_TextChanged;


//            txtMonthNum = new TextBox();
//            txtMonthNum.BorderStyle = BorderStyle.None;
//            txtMonthNum.TabStop = false;
//            txtMonthNum.BackColor = this.BackColor;
//            txtMonthNum.TextAlign = HorizontalAlignment.Center;
//            txtMonthNum.Font = this.Font;
//            txtMonthNum.ForeColor = this.ForeColor;
//            txtMonthNum.GotFocus += TxtMonthNum_GotFocus;
//            txtMonthNum.Click += TxtMonthNum_Click;
//            txtMonthNum.Enter += TxtMonthNum_Enter;
//            txtMonthNum.KeyDown += TxtMonthNum_KeyDown;
//            txtMonthNum.KeyPress += Txt_KeyPress;
//            txtMonthNum.KeyUp += Txt_KeyUp;
//            txtMonthNum.MouseWheel += Txt_MouseWheel;
//            txtMonthNum.TextChanged += TxtMonthNum_TextChanged;


//            txtDayNum = new TextBox();
//            txtDayNum.BorderStyle = BorderStyle.None;
//            txtDayNum.TabStop = false;
//            txtDayNum.BackColor = this.BackColor;
//            txtDayNum.TextAlign = HorizontalAlignment.Center;
//            txtDayNum.Font = this.Font;
//            txtDayNum.ForeColor = this.ForeColor;
//            txtDayNum.MaxLength = 2;
//            txtDayNum.GotFocus += TxtDayNum_GotFocus;
//            txtDayNum.Click += TxtDayNum_Click;
//            txtDayNum.Enter += TxtDayNum_Enter;
//            txtDayNum.KeyDown += TxtDayNum_KeyDown;
//            txtDayNum.KeyPress += Txt_KeyPress;
//            txtDayNum.KeyUp += Txt_KeyUp;
//            txtDayNum.MouseWheel += Txt_MouseWheel;
//            txtDayNum.TextChanged += TxtDayNum_TextChanged;

//            txtDayText = new TextBox();
//            txtDayText.BorderStyle = BorderStyle.None;
//            txtDayText.TabStop = false;
//            txtDayText.BackColor = this.BackColor;
//            txtDayText.TextAlign = HorizontalAlignment.Center;
//            txtDayText.Font = this.Font;
//            txtDayText.ForeColor = this.ForeColor;
//            txtDayText.GotFocus += TxtDayText_GotFocus;
//            txtDayText.Click += TxtDayText_Click;
//            txtDayText.Enter += TxtDayText_Enter;
//            txtDayText.KeyDown += TxtDayText_KeyDown;
//            txtDayText.KeyPress += Txt_KeyPress;
//            txtDayText.KeyUp += Txt_KeyUp;
//            txtDayText.MouseWheel += Txt_MouseWheel;


//            #region Intalize
//            lblY = new Label();
//            lblY.TabStop = false;
//            lblY.BackColor = this.BackColor;
//            lblY.TextAlign = ContentAlignment.TopCenter;
//            lblY.Font = this.Font;
//            lblY.ForeColor = this.ForeColor;
//            lblY.AutoSize = false;

//            lblM = new Label();
//            lblM.TabStop = false;
//            lblM.BackColor = this.BackColor;
//            lblM.TextAlign = ContentAlignment.TopCenter;
//            lblM.Font = this.Font;
//            lblM.ForeColor = this.ForeColor;
//            lblM.AutoSize = false;

//            lblD = new Label();
//            lblD.TabStop = false;
//            lblD.BackColor = this.BackColor;
//            lblD.TextAlign = ContentAlignment.TopCenter;
//            lblD.Font = this.Font;
//            lblD.ForeColor = this.ForeColor;
//            lblD.AutoSize = false;

//            dropDownMonthCalendar.GetDate += DdCal_GetDate;

//            btn = new Button();
//            btn.TabStop = false;
//            btn.FlatStyle = FlatStyle.Flat;
//            btn.FlatAppearance.BorderSize = 0;
//            btn.FlatAppearance.BorderColor = this.BackColor;
//            btn.FlatAppearance.MouseDownBackColor = this.BackColor;
//            btn.FlatAppearance.MouseOverBackColor = this.BackColor;
//            btn.Name = "btnCal";
//            btn.TextImageRelation = TextImageRelation.ImageAboveText;
//            btn.Size = new Size(20, this.Font.Height / 2);
//            btn.UseVisualStyleBackColor = true;
//            //bmp = new Bitmap(original: Properties.Resources.Calender_32px, btn.Size.Width , this.Font.Height-2);
//            //btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
//            //dropDownMonthCalendar.MaxDate = this.MaxDate;
//            //dropDownMonthCalendar.MinDate = this.MinDate;
//            btn.Click += (S, E) =>
//            {
//                dropDownMonthCalendar.MaxDate = this.MaxDate;
//                dropDownMonthCalendar.MinDate = this.MinDate;

//                //nYer.Minimum = this.MinDate.Year;
//                //nYer.Maximum = this.MaxDate.Year;
//                dropDownMonthCalendar.Show(this);
//            };


//            Size = new Size(400, int.Parse(this.Font.GetHeight().ToString("#")));

//            this.Controls.Add(txtYer);
//            this.Controls.Add(txtMonthNum);
//            this.Controls.Add(txtDayNum);
//            this.Controls.Add(txtDayText);
//            this.Controls.Add(lblY);
//            this.Controls.Add(lblM);
//            this.Controls.Add(lblD);
//            this.Controls.Add(btn);
//            btn.BringToFront();
//            #endregion


//        }





//        #region Properties
//        string CtrlName = "txtYer";
//        TextBox txtYer;
//        TextBox txtMonthNum;
//        TextBox txtDayNum;
//        TextBox txtDayText;

//        Label lblY;
//        Label lblM;
//        Label lblD;

//        Button btn;
//        Bitmap bmp;
//        public bool flg = true;
//        public bool flgWheel = false ;
//        bool flgChanged = false;
//        int result = 0;
//        int DayCount = 1;
//        int MonthNum = 1;
//        int YearNumber = 1;
//        string resultStr = "";

//        DateTime DtValue;

//        private string errorText = string.Empty;
//        [Category("Zer0ne")]
//        public string ErrorText
//        {
//            get{ return errorText;}
//            set{errorText = value;}
//        }

//        [Category("Zer0ne")]
//        public Image ImageCalender
//        {
//            get { return btn.Image; }
//            set { btn.Image = value; }
//        }


//        private Color backColor = Color.Green;
//        [Category("Zer0ne")]
//        public new Color BackColor
//        {
//            get => backColor;
//            set
//            {
//                base.BackColor = value;
//                backColor = value;
//                txtYer.BackColor = value;
//                txtDayNum.BackColor = value;
//                txtMonthNum.BackColor = value;
//                txtDayText.BackColor = value;
//                btn.FlatAppearance.BorderColor = value;
//                btn.FlatAppearance.MouseDownBackColor = value;
//                btn.FlatAppearance.MouseOverBackColor = value;
//                this.Invalidate();
//            }
//        }


//        private bool showCalendar = true;
//        [Category("Zer0ne")]
//        public bool ShowCalendar
//        {
//            get { return showCalendar; }
//            set
//            {
//                showCalendar = value;
//                Reset();
//                this.Invalidate();
//            }
//        }


//        private DateTime dt = DateTime.Now;
//        [Browsable(true), Category("Zer0ne")]// DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
//        [RefreshProperties(RefreshProperties.All)]
//        public DateTime Value
//        {
//            get
//            {
//                //System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("he-IL");

             
//                    return dt;
//            }
//            set
//            {
//                if (flgWheel)
//                {
//                    if (value >= MaxDate)
//                    {
//                        dt = MaxDate;
//                        flgWheel = false;
//                        flgChanged = false;
//                    }
//                    else if (value <= MinDate)
//                    {
//                        dt = MinDate;
//                        flgWheel = false;
//                        flgChanged = false;
//                    }
//                    else
//                    {
//                        dt = value;
//                    }
                    
//                }
//                else if (flgWheel == false )
//                {
//                    dt = value;
//                    flgWheel = false;
//                    flgChanged = false;
//                    switch (Format)
//                    {
//                        case DateTimeFormat.Long:
//                            txtYer.Text = dt.ToString("yyyy");
//                            txtMonthNum.Text = dt.ToString("MMMM");
//                            txtDayNum.Text = dt.ToString("dd");
//                            txtDayText.Text = dt.ToString("dddd");
//                            break;
//                        case DateTimeFormat.Short:
//                            txtYer.Text = dt.ToString("yyyy");
//                            txtMonthNum.Text = dt.ToString("MM");
//                            txtDayNum.Text = dt.ToString("dd");
//                            break;
//                        case DateTimeFormat.Time:
//                            txtYer.Text = dt.ToString("hh");
//                            txtMonthNum.Text = dt.ToString("mm");
//                            txtDayNum.Text = dt.ToString("ss");
//                            txtDayText.Text = dt.ToString("tt");
//                            break;
//                        case DateTimeFormat.MonthYear:
//                            txtYer.Text = dt.ToString("yyyy");
//                            txtMonthNum.Text = dt.ToString("MMMM");
//                            break;
//                        default:
//                            break;
//                    }
//                }
//                this.ValueChanged?.Invoke(this, value);
//            }
//        }

      

//        private DateTime dtMax = DateTime.Now.AddYears(1000); //new DateTime(2999, 12, 31);
//        [Browsable(true), Category("Zer0ne")]// DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
//        public DateTime MaxDate
//        {
//            get
//            {
//                return dtMax;
//            }
//            set
//            {
//                if (value < MinDate)
//                {
//                    return;
//                }
//                else
//                {
//                    dtMax = value;
//                    if (Value > dtMax)
//                    {
//                        Value = value;
//                    }
//                }
//            }
//        }

//        private DateTime dtMin = new DateTime(1900, 1, 1);
//        [Browsable(true),  Category("Zer0ne")]//DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
//        public DateTime MinDate
//        {
//            get
//            {
//                return dtMin;
//            }
//            set
//            {
//                if (value > MaxDate)
//                {
//                    return;
//                }
//                else
//                {
//                    if (Value < value)
//                    {
//                        Value = value;
//                    }
//                    dtMin = value;
//                }
//            }
//        }

//        private DateTimeFormat format = DateTimeFormat.Long;
//        [Category("Zer0ne")]
//        public DateTimeFormat Format
//        {
//            get { return format; }
//            set
//            {
//                format = value;
//                Reset();
//                this.Invalidate();
//            }
//        }
//        #endregion

//        #region Method 
//        // 6 region GotFocus KeyDown Enter Click TextChanged  ===>(( Press KeyUp Wheel ))<

//        #region ---> Event GotFocus
//        private void TxtDayText_GotFocus(object sender, EventArgs e)
//        {
//            //txtDayText.Select(0, txtDayText.Text.Length);
//            HideCaret(txtDayText.Handle);
//        }

//        string OldMonth = "";

//        private void TxtDayNum_GotFocus(object sender, EventArgs e)
//        {
//            //txtDayNum.Select(0, txtDayNum.Text.Length);
//            HideCaret(txtDayNum.Handle);
//        }

//        private void TxtMonthNum_GotFocus(object sender, EventArgs e)
//        {
//            //txtMonthNum.Select(0, txtMonthNum.Text.Length);
//            HideCaret(txtMonthNum.Handle);
//            if (Format == DateTimeFormat.Long || Format == DateTimeFormat.MonthYear)
//            {
//                OldMonth = txtMonthNum.Text;
//                Debug.WriteLine(OldMonth);
//            }
//        }

//        private void TxtYer_GotFocus(object sender, EventArgs e)
//        {
//            HideCaret(txtYer.Handle);
//        } 
//        #endregion


//        private int GMonthNumber(string monthName , bool CurrentMonth= false ,bool NextMonth = false, bool BrevewsMonth = false)
//        {
//            int r = 1;
//            if (CurrentMonth )
//            {
//            r = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(monthName) + 1;
//            }
//            else if (NextMonth)
//            {
//                r= DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(monthName) + 2;
//            }
//            else if (BrevewsMonth)
//            {
//                r= DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(monthName) ;
//            }
//            return r;
//        }

//        private bool CheckDate(string y , string m , string d)
//        {
//            DateTime dBoll = new DateTime(int.Parse(y), int.Parse(m), int.Parse(d));
//            return (dBoll.Date >= MaxDate.Date) ? true : false;
//        }

//        #region ---> Event KeyDown
//        private void TxtYer_KeyDown(object sender, KeyEventArgs e)
//        {
            
//            if (e.KeyData == Keys.Up)
//            {
//                flgWheel = false;
//                flgChanged = false;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:

//                        //YearNumber = int.Parse(txtYer.Text);
//                        //MonthNum = int.Parse(txtMonthNum.Text);
//                        //DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                        chkDate = new DateTime(YearNumber, MonthNum, MaxDate.Day);

//                        if (txtYer.Text == MaxDate.Year.ToString())
//                        {
//                            txtYer.Text = MinDate.Year.ToString();
//                        }
//                        else
//                        {
//                            txtYer.Text = (int.Parse(txtYer.Text) + 1).ToString();
//                        }
//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);

//                        txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");
//                        break;

//                    case DateTimeFormat.MonthYear:
//                        if (txtYer.Text == MaxDate.Year.ToString())
//                        {
//                            txtYer.Text = MinDate.Year.ToString();
//                        }
//                        else
//                        {
//                            txtYer.Text = (int.Parse(txtYer.Text) + 1).ToString();
//                        }
//                        break;

//                    case DateTimeFormat.Short:
//                        if (txtYer.Text == MaxDate.Year.ToString())
//                        {
//                            txtYer.Text = MinDate.Year.ToString();
//                        }
//                        else
//                        {

//                            txtYer.Text = (int.Parse(txtYer.Text) + 1).ToString();
//                        }

//                        DayCount = DateTime.DaysInMonth(int.Parse(txtYer.Text), int.Parse(txtMonthNum.Text));
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        break;

//                    case DateTimeFormat.Time:
//                    default:

//                        if (txtYer.Text == "12")
//                        {
//                            txtYer.Text = "01";
//                        }
//                        else
//                        {
//                            resultStr = (int.Parse(txtYer.Text) + 1).ToString();
//                            txtYer.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;
//                        }
//                        break;
//                }

//            }
//            else if (e.KeyData == Keys.Down)
//            {
//                flgWheel = false;
//                flgChanged = false;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:
//                        if (txtYer.Text == MinDate.Year.ToString())
//                        {
//                            txtYer.Text = MaxDate.Year.ToString();
//                        }
//                        else
//                        {
//                            txtYer.Text = (int.Parse(txtYer.Text) - 1).ToString();
//                        }
//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);

//                        txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");
//                        break;

//                    case DateTimeFormat.MonthYear:
//                        if (txtYer.Text == MinDate.Year.ToString())
//                        {
//                            txtYer.Text = MaxDate.Year.ToString();
//                        }
//                        else
//                        {
//                            txtYer.Text = (int.Parse(txtYer.Text) - 1).ToString();
//                        }
//                        break;

//                    case DateTimeFormat.Short:
//                        if (txtYer.Text == MinDate.Year.ToString())
//                        {
//                            txtYer.Text = MaxDate.Year.ToString();
//                        }
//                        else
//                        {
//                            txtYer.Text = (int.Parse(txtYer.Text) - 1).ToString();
//                        }

//                        DayCount = DateTime.DaysInMonth(int.Parse(txtYer.Text), int.Parse(txtMonthNum.Text));
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        break;

//                    case DateTimeFormat.Time:
//                    default:

//                        if (txtYer.Text == "01"|| txtYer.Text == "1")
//                        {
//                            txtYer.Text = "12";
//                        }
//                        else
//                        {
//                            resultStr = (int.Parse(txtYer.Text) - 1).ToString();
//                            txtYer.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;
//                        }
//                        break;
//                }
//            }
//            else
//            {
//                flgWheel = true ;
//                flgChanged = true;
//            }
            
//        }
//        DateTime chkDate;
//        private void TxtMonthNum_KeyDown(object sender, KeyEventArgs e)
//        {
            
//            if (e.KeyData == Keys.Up)
//            {
//                flgWheel = false;
//                flgChanged = false;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:

//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                        if (MonthNum >= 11 || CheckDate(txtYer.Text, GMonthNumber(txtMonthNum.Text, CurrentMonth: true).ToString(), MaxDate.Day.ToString())) // (chkDate.Date >= MaxDate.Date) //MaxDate.Month == (MonthNum + 1)
//                        {
//                            chkDate = new DateTime(YearNumber, MinDate.Month, MinDate.Day);
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName((chkDate.Date <= MinDate.Date)? MinDate.Date.Month: 1);
//                        }
//                        else
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(MonthNum + 2);
//                        }
//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text) >= DayCount) ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");
//                        break;

//                    case DateTimeFormat.MonthYear:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        chkDate = new DateTime(YearNumber, MonthNum, MaxDate.Day);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                        if (MonthNum == 11 || MonthNum == 12 || (chkDate.Date >= MaxDate.Date))//MaxDate.Month == (MonthNum + 1)
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                        }
//                        else
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(MonthNum + 2);
//                        }

//                        break;

//                    case DateTimeFormat.Short:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = int.Parse(txtMonthNum.Text);
//                        chkDate = new DateTime(YearNumber, MonthNum, MaxDate.Day);
//                        if (txtMonthNum.Text == "12" || (chkDate.Date >= MaxDate.Date)) //txtMonthNum.Text== MaxDate.Month.ToString() 
//                        {
//                            MonthNum = 1;
//                            txtMonthNum.Text = (MonthNum.ToString().Length == 1) ? "0" + MonthNum.ToString() : MonthNum.ToString();
//                        }
//                        else
//                        {
//                            MonthNum = int.Parse(txtMonthNum.Text) + 1;
//                            txtMonthNum.Text = (MonthNum.ToString().Length == 1) ? "0" + MonthNum.ToString() : MonthNum.ToString();
//                        }
//                        DayCount = DateTime.DaysInMonth(int.Parse(txtYer.Text), MonthNum);
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text) >= DayCount) ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        break;

//                    case DateTimeFormat.Time:
//                    default:
//                        if (txtMonthNum.Text == "59")
//                        {
//                            txtMonthNum.Text = "00";
//                        }
//                        else
//                        {
//                            resultStr = (int.Parse(txtMonthNum.Text) + 1).ToString();
//                            txtMonthNum.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;
//                        }
//                        break;
//                }

//            }
//            else if (e.KeyData == Keys.Down)
//            {
//                flgWheel = false;
//                flgChanged = false;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        chkDate = new DateTime(YearNumber, MonthNum, MinDate.Day);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                        if (MonthNum == 0 || MonthNum == 12 || (chkDate.Date <= MinDate.Date))//MaxDate.Month == (MonthNum + 1)
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(12);
//                        }
//                        else
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(MonthNum );
//                        }

//                        //MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                        //if (MonthNum == 0 || MonthNum == 12 || MinDate.Month == (MonthNum + 1))
//                        //{
//                        //    txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName( MaxDate.Month);
//                        //}
//                        //else
//                        //{
//                        //    txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(MonthNum);
//                        //}
//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text) >= DayCount) ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");
//                        break;

//                    case DateTimeFormat.MonthYear:
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                        if (MonthNum == 0 || MonthNum == 12 || MinDate.Month == (MonthNum + 1))
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(MaxDate.Month);
//                        }
//                        else
//                        {
//                            txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(MonthNum );
//                        }
//                        break;

//                    case DateTimeFormat.Short:

//                        if (txtMonthNum.Text == "01"|| txtMonthNum.Text == "1" || MinDate.Month == (MonthNum + 1))
//                        {
//                            MonthNum =  MaxDate.Month;
//                            txtMonthNum.Text = MaxDate.Month.ToString(); 
//                        }
//                        else
//                        {
//                            MonthNum = int.Parse(txtMonthNum.Text) - 1;
//                            txtMonthNum.Text = (MonthNum.ToString().Length == 1) ? "0" + MonthNum.ToString() : MonthNum.ToString();
//                        }
//                        DayCount = DateTime.DaysInMonth(int.Parse(txtYer.Text), MonthNum);
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text) >= DayCount) ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                        break;

//                    case DateTimeFormat.Time:
//                    default:
//                        if (txtMonthNum.Text == "00"|| txtMonthNum.Text == "0")
//                        {
//                            txtMonthNum.Text = "59";
//                        }
//                        else
//                        {
//                            resultStr = (int.Parse(txtMonthNum.Text) - 1).ToString();
//                            txtMonthNum.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;
//                        }
//                        break;
//                }
//            }
//            else
//            {
//                flgChanged = true;
//                flgWheel = true;
//            }
//        }

//        private void TxtDayNum_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyData == Keys.Up)
//            {
//                flgWheel = false;
//                flgChanged = false;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
                       
//                        if (int.Parse(txtDayNum.Text) >= DayCount || int.Parse(txtDayNum.Text) == MaxDate.Day)
//                        {
                           
//                            DayCount = MinDate.Day;
//                            resultStr = DayCount.ToString().Length == 1 ? "0" + DayCount.ToString() : DayCount.ToString();
//                        }
//                        else
//                        {
//                            DayCount = int.Parse(txtDayNum.Text) + 1;
//                            resultStr = DayCount.ToString().Length == 1 ? "0" + DayCount.ToString() : DayCount.ToString();
//                        }
                       
//                        txtDayNum.Text = resultStr;
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, DayCount).ToString("dddd");

//                        break;

//                    case DateTimeFormat.Short:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = int.Parse(txtMonthNum.Text);
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
                       
//                        if (int.Parse(txtDayNum.Text) >= DayCount || int.Parse(txtDayNum.Text) == MaxDate.Day)
//                        {
//                            DayCount = MinDate.Day;
//                            resultStr = DayCount.ToString().Length == 1 ? "0" + DayCount.ToString() : DayCount.ToString();
//                        }
//                        else
//                        {
//                            DayCount = int.Parse(txtDayNum.Text) + 1;
//                            resultStr = DayCount.ToString().Length == 1 ? "0" + DayCount.ToString() : DayCount.ToString();
//                        }
                       
//                        txtDayNum.Text = resultStr;
//                        //txtDayText.Text = new DateTime(YearNumber, MonthNum, DayCount).ToString("dddd");

                        
//                        break;

//                    case DateTimeFormat.Time:
//                    default:

//                        if (txtDayNum.Text == "59")
//                        {
//                            resultStr = "00";
//                        }
//                        else
//                        {
//                            resultStr = (int.Parse(txtDayNum.Text) + 1).ToString();
//                        }
                       
//                        txtDayNum.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;

                       
//                        break;
//                }

//            }
//            else if (e.KeyData == Keys.Down)
//            {
//                flgWheel = false;
//                flgChanged = false;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);

//                        if (txtDayNum.Text == "01" || txtDayNum.Text == "1" || int.Parse(txtDayNum.Text) == MinDate.Day)
//                        {
//                            resultStr = MinDate.Day.ToString();
//                        }
//                        else
//                        {
//                            DayCount = int.Parse(txtDayNum.Text) - 1;
//                            resultStr = DayCount.ToString().Length == 1 ? "0" + DayCount.ToString() : DayCount.ToString();
//                        }

//                        txtDayNum.Text = resultStr;
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, DayCount).ToString("dddd");

//                        break;


//                    case DateTimeFormat.Short:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = int.Parse(txtMonthNum.Text);
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);

//                        if (txtDayNum.Text == "01" || txtDayNum.Text == "1")
//                        {
//                            resultStr = DayCount.ToString();
//                        }
//                        else
//                        {
//                            DayCount = int.Parse(txtDayNum.Text) - 1;
//                            resultStr = DayCount.ToString().Length == 1 ? "0" + DayCount.ToString() : DayCount.ToString();
//                        }

//                        txtDayNum.Text = resultStr;
//                        txtDayText.Text = new DateTime(YearNumber, MonthNum, DayCount).ToString("dddd");


//                        break;

//                    case DateTimeFormat.Time:
//                    default:

//                        if (txtDayNum.Text == "00")
//                        {
//                            resultStr = "59";
//                        }
//                        else
//                        {
//                            resultStr = (int.Parse(txtDayNum.Text) - 1).ToString();
//                        }

//                        txtDayNum.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;

//                        break;
//                }
//            }
//            else
//            {
//                flgWheel = true ;
//                flgChanged = true ;
//            }
//        }

//        private void TxtDayText_KeyDown(object sender, KeyEventArgs e)
//        {

//            if (Format == DateTimeFormat.Time)
//            {
//                CultureInfo.CurrentCulture.ClearCachedData();
//                if (e.KeyData == Keys.Up)
//                {
//                    if (txtDayText.Text == DateTimeFormatInfo.CurrentInfo.AMDesignator)
//                    {
//                        txtDayText.Text = DateTimeFormatInfo.CurrentInfo.PMDesignator;
//                    }
//                    else
//                    {
//                        txtDayText.Text = DateTimeFormatInfo.CurrentInfo.AMDesignator;
//                    }
//                }
//                else if (e.KeyData == Keys.Down)
//                {
//                    if (txtDayText.Text == DateTimeFormatInfo.CurrentInfo.PMDesignator)
//                    {
//                        txtDayText.Text = DateTimeFormatInfo.CurrentInfo.AMDesignator;
//                    }
//                    else
//                    {
//                        txtDayText.Text = DateTimeFormatInfo.CurrentInfo.PMDesignator;
//                    }
//                }
//            }
//        }

//        #endregion

//        #region  ---> Event Enter

//        private void TxtYer_Enter(object sender, EventArgs e)
//        {
//            CtrlName = "txtYer";
//            //txtYer.SelectAll();
//        } 

//        private void TxtMonthNum_Enter(object sender, EventArgs e)
//        {
//            CtrlName = "txtMonthNum";
//            //txtMonthNum.SelectAll();
//        }

//        private void TxtDayNum_Enter(object sender, EventArgs e)
//        {
//            CtrlName ="txtDayNum" ;
//            //txtDayNum.SelectAll();
//        }

//        private void TxtDayText_Enter(object sender, EventArgs e)
//        {
//            CtrlName = "txtDayText";
//            //txtDayText.SelectAll();
//        }
//        #endregion

//        #region ---> Event Click
//        private void TxtYer_Click(object sender, EventArgs e)
//        {
//            CtrlName = "txtYer";
//            txtYer.SelectAll();
//            HideCaret(txtYer.Handle);
//        }

//        private void TxtMonthNum_Click(object sender, EventArgs e)
//        {
//            CtrlName = "txtMonthNum";
//            txtMonthNum.SelectAll();
//            HideCaret(txtMonthNum.Handle);
//        }

//        private void TxtDayNum_Click(object sender, EventArgs e)
//        {
//            CtrlName = "txtDayNum";
//            txtDayNum.SelectAll();
//            HideCaret(txtDayNum.Handle);
//        }

//        private void TxtDayText_Click(object sender, EventArgs e)
//        {
//            CtrlName = "txtDayText";
//            txtDayText.SelectAll();
//            HideCaret(txtDayText.Handle);
//        }
//        #endregion

//        #region ---> TextChanged

//        private void TxtYer_TextChanged(object sender, EventArgs e)
//        {
            
//            CultureInfo.CurrentCulture.ClearCachedData();
//            if (txtYer.Text.Length == 4 && Format != DateTimeFormat.Time && flgChanged == true )
//            {
//                DtValue = DateTime.Now;
//                flgWheel = true;
//                if (int.Parse(txtYer.Text) > 3001 || int.Parse(txtYer.Text) < 1899)
//                {
//                    txtYer.Text = DtValue.Year.ToString();
//                }
//                else
//                {
//                    YearNumber = int.Parse(txtYer.Text);
//                    switch (Format)
//                    {
//                        case DateTimeFormat.Long:
//                        case DateTimeFormat.MonthYear:
//                            MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                            txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");

//                            Value = DateTime.Parse(new DateTime(YearNumber, MonthNum,int.Parse(txtDayNum.Text),
//                                DtValue.Hour,DtValue.Minute, DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"),
//                                System.Globalization.CultureInfo.CurrentCulture);
//                            break;

//                        case DateTimeFormat.Short:
//                            MonthNum = int.Parse(txtMonthNum.Text);
//                            DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                            Value = DateTime.Parse(new DateTime(YearNumber,MonthNum,int.Parse(txtDayNum.Text),
//                                DtValue.Hour,DtValue.Minute,DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), 
//                                System.Globalization.CultureInfo.CurrentCulture);
//                            break;

//                        case DateTimeFormat.Time:
//                        default:
//                            break;

//                    }

//                }
//            }
//            else if ( Format == DateTimeFormat.Time && flgChanged == true )//txtYer.Text.Length == 2 &&
//            {
//                DtValue = DateTime.Now;
//                flgWheel = true;
//                if (int.Parse(txtYer.Text) >= 13 || int.Parse(txtYer.Text) <= 0 )
//                {
//                    txtYer.Text = "12";
//                }
//                else
//                {
//                    resultStr = (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator) ? " AM" : "PM";

//                    Value = DateTime.Parse(new DateTime(DtValue.Year, DtValue.Month, DtValue.Day,
//                        int.Parse(txtYer.Text), int.Parse(txtMonthNum.Text), int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr,
//                        System.Globalization.CultureInfo.CurrentCulture);
//                }
//            }
            
//        }

//        private void TxtMonthNum_TextChanged(object sender, EventArgs e)
//        {
//            if (txtMonthNum.ReadOnly == false && flgChanged == true && txtMonthNum.Text.Length <= 2)
//            {

//                if (Format == DateTimeFormat.Short)
//                {
//                    DtValue = DateTime.Now;
//                    if (int.Parse(txtMonthNum.Text) >= 13 || int.Parse(txtMonthNum.Text) <= 0)
//                    {
//                        flgChanged = true;
//                        txtMonthNum.Text = "12";
//                    }
//                    else
//                    {
//                        flgChanged = false;
//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = int.Parse(txtMonthNum.Text);
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                        txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                        Value = DateTime.Parse(new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text),
//                            DtValue.Hour, DtValue.Minute, DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"),
//                            System.Globalization.CultureInfo.CurrentCulture);
//                    }

//                }
//                else if (Format == DateTimeFormat.Time)
//                {
//                    DtValue = DateTime.Now;
//                    if (int.Parse(txtMonthNum.Text) > 59 )
//                    {
//                        flgChanged = true;
//                        txtMonthNum.Text = "59";
//                    }
//                    else
//                    {
//                        flgChanged = false;
//                        resultStr = (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator) ? " AM" : "PM";

//                        Value = DateTime.Parse(new DateTime(DtValue.Year, DtValue.Month, DtValue.Day,
//                            int.Parse(txtYer.Text), int.Parse(txtMonthNum.Text), int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr,
//                            System.Globalization.CultureInfo.CurrentCulture);
//                    }
//                }
//             }

//        }

//        private void TxtDayNum_TextChanged(object sender, EventArgs e)
//        {
//            if (flgChanged == true)
//            {
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:
//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);

//                        if (int.Parse(txtDayNum.Text) > DayCount || int.Parse(txtDayNum.Text) <= 0)
//                        {
//                            flgChanged = true;
//                            txtDayNum.Text = DayCount.ToString();
//                        }
//                        else
//                        {
//                            flgChanged = false;
//                            txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");
//                            DtValue = DateTime.Now;
//                            Value = DateTime.Parse(new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text),
//                                DtValue.Hour, DtValue.Minute, DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"),
//                                System.Globalization.CultureInfo.CurrentCulture);
//                        }

//                        break;
//                    case DateTimeFormat.Short:

//                        YearNumber = int.Parse(txtYer.Text);
//                        MonthNum = int.Parse(txtMonthNum.Text);
//                        DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);

//                        if (int.Parse(txtDayNum.Text) > DayCount || int.Parse(txtDayNum.Text) <= 0)
//                        {
//                            flgChanged = true;
//                            txtDayNum.Text = DayCount.ToString();
//                        }
//                        else
//                        {
//                            flgChanged = false;
//                            DtValue = DateTime.Now;
//                            Value = DateTime.Parse(new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text),
//                                DtValue.Hour, DtValue.Minute, DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"),
//                                System.Globalization.CultureInfo.CurrentCulture);
//                        }

//                        break;
//                    case DateTimeFormat.Time:

//                        if (int.Parse(txtDayNum.Text) > 59 || int.Parse(txtDayNum.Text) <= 0)
//                        {
//                            flgChanged = true;
//                            txtDayNum.Text = "59";
//                        }
//                        else
//                        {
//                            flgChanged = false;
//                            DtValue = DateTime.Now;
//                            Value = DateTime.Parse(new DateTime(DtValue.Year, DtValue.Month, DtValue.Day,
//                                int.Parse(txtYer.Text), int.Parse(txtMonthNum.Text), int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss tt"),
//                                System.Globalization.CultureInfo.CurrentCulture);
//                        }

//                        break;
//                    default:
//                        break;
//                }

//            }
//        }


//        #endregion

//        #region ---> Press KeyUp Wheel

//        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsDigit(e.KeyChar))
//            {
//                e.Handled = true;
//            }
//        }
//        private void Txt_KeyUp(object sender, KeyEventArgs e)
//        {
            
//            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
//            {
//                flgChanged = false;
//                flgWheel = true;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                DtValue = DateTime.Now;
//                switch (CtrlName)
//                {
//                    case "txtYer":
//                        switch (Format)
//                        {
//                            case DateTimeFormat.Long:
//                            case DateTimeFormat.MonthYear:


//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1,
//                                    int.Parse(txtDayNum.Text),
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);
//                                break;

//                            case DateTimeFormat.Short:

//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    int.Parse(txtMonthNum.Text),
//                                    int.Parse(txtDayNum.Text),
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);

//                                break;

//                            case DateTimeFormat.Time:
//                            default:

//                                CultureInfo.CurrentCulture.ClearCachedData();
//                                if (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator)
//                                {
//                                    resultStr = " AM";
//                                }
//                                else
//                                {
//                                    resultStr = " PM";
//                                }

//                                Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                    DtValue.Month,
//                                    DtValue.Day,
//                                    int.Parse(txtYer.Text),
//                                    int.Parse(txtMonthNum.Text),
//                                    int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr
//                                    , System.Globalization.CultureInfo.CurrentCulture);
//                                break;
//                        }
//                        break;

//                    case "txtMonthNum":
//                        switch (Format)
//                        {
//                            case DateTimeFormat.Long:

//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1,
//                                    int.Parse(txtDayNum.Text),
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);

//                                break;
//                            case DateTimeFormat.MonthYear:

//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1,
//                                    1,
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);

//                                break;

//                            case DateTimeFormat.Short:


//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    int.Parse(txtMonthNum.Text),
//                                    int.Parse(txtDayNum.Text),
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);
//                                break;

//                            case DateTimeFormat.Time:
//                            default:

//                                CultureInfo.CurrentCulture.ClearCachedData();
//                                if (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator)
//                                {
//                                    resultStr = " AM";
//                                }
//                                else
//                                {
//                                    resultStr = " PM";
//                                }
//                                Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                    DtValue.Month,
//                                    DtValue.Day,
//                                    int.Parse(txtYer.Text),
//                                    int.Parse(txtMonthNum.Text),
//                                    int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr
//                                    , System.Globalization.CultureInfo.CurrentCulture);

//                                break;
//                        }
//                        break;

//                    case "txtDayNum":
//                        switch (Format)
//                        {
//                            case DateTimeFormat.Long:

//                                MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    MonthNum,
//                                    int.Parse(txtDayNum.Text),
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);
//                                break;

//                            case DateTimeFormat.Short:

//                                MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                                Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                    int.Parse(txtMonthNum.Text),
//                                    int.Parse(txtDayNum.Text),
//                                    DtValue.Hour,
//                                    DtValue.Minute,
//                                    DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                    , System.Globalization.CultureInfo.CurrentCulture);
//                                break;
//                            case DateTimeFormat.Time:
//                            default:

//                                CultureInfo.CurrentCulture.ClearCachedData();
//                                if (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator)
//                                {
//                                    resultStr = " AM";
//                                }
//                                else
//                                {
//                                    resultStr = " PM";
//                                }
//                                Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                    DtValue.Month,
//                                    DtValue.Day,
//                                    int.Parse(txtYer.Text),
//                                    int.Parse(txtMonthNum.Text),
//                                    int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr
//                                    , System.Globalization.CultureInfo.CurrentCulture);
//                                break;
//                        }
//                        break;

//                    case "txtDayText":
//                        if (Format == DateTimeFormat.Time)
//                        {
//                            CultureInfo.CurrentCulture.ClearCachedData();
//                            if (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator)
//                            {
//                                resultStr = " AM";
//                            }
//                            else
//                            {
//                                resultStr = " PM";
//                            }

//                            Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                DtValue.Month,
//                                DtValue.Day,
//                                int.Parse(txtYer.Text),
//                                int.Parse(txtMonthNum.Text),
//                                int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr
//                                , System.Globalization.CultureInfo.CurrentCulture);
//                        }
//                        break;
//                    default:
//                        break;
//                }
//            }
           
            
//        }
//        private void Txt_MouseWheel(object sender, MouseEventArgs e)
//        {
//            flgChanged = false;
//            CultureInfo.CurrentCulture.ClearCachedData();
//            DtValue = DateTime.Now;
//            switch (CtrlName)
//            {

//                case "txtYer":
//                    switch (Format)
//                    {
//                        case DateTimeFormat.Long:
//                        case DateTimeFormat.MonthYear:
//                            if (e.Delta > 0)
//                            {
//                                if (txtYer.Text == "3000")
//                                {
//                                    txtYer.Text = "1900";
//                                    goto Esc;
//                                }
//                                txtYer.Text = (int.Parse(txtYer.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtYer.Text == "1900")
//                                {
//                                    txtYer.Text = "3000";
//                                    goto Esc;
//                                }
//                                txtYer.Text = (int.Parse(txtYer.Text) - 1).ToString();
//                            }
//                        Esc:
//                            // number Days Count in month
//                            if (int.TryParse(txtMonthNum.Text, out result))
//                            {
//                                result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            }
//                            else
//                            {
//                                result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                                result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            }

//                            txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= result ? result.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                            txtDayText.Text = new DateTime(int.Parse(txtYer.Text), DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1, int.Parse(txtDayNum.Text)).ToString("dddd");


//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1,
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;

//                        case DateTimeFormat.Short:

//                            if (e.Delta > 0)
//                            {
//                                if (txtYer.Text == "3000")
//                                {
//                                    txtYer.Text = "1900";
//                                    goto Esc;
//                                }
//                                txtYer.Text = (int.Parse(txtYer.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtYer.Text == "1900")
//                                {
//                                    txtYer.Text = "3000";
//                                    goto Esce;
//                                }
//                                txtYer.Text = (int.Parse(txtYer.Text) - 1).ToString();
//                            }
//                        Esce:
//                            // number Days Count in month
//                            if (int.TryParse(txtMonthNum.Text, out result))
//                            {
//                                result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            }
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= result ? result.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                int.Parse(txtMonthNum.Text),
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture

//                            break;

//                        case DateTimeFormat.Time:
//                        default:
//                            if (e.Delta > 0)
//                            {
//                                if (txtYer.Text == "12")
//                                {
//                                    resultStr = "01";
//                                    goto Escep; ;
//                                }
//                                resultStr = (int.Parse(txtYer.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtYer.Text == "01" || txtYer.Text == "1")
//                                {
//                                    resultStr = "12";
//                                    goto Escep; ;
//                                }
//                                resultStr = (int.Parse(txtYer.Text) - 1).ToString();
//                            }
//                        Escep:
//                            txtYer.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;

//                            CultureInfo.CurrentCulture.ClearCachedData();
//                            if (txtDayText.Text == CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator)
//                            {
//                                resultStr = " AM";
//                            }
//                            else
//                            {
//                                resultStr = " PM";
//                            }

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                DtValue.Month,
//                                DtValue.Day,
//                                int.Parse(txtYer.Text),
//                                int.Parse(txtMonthNum.Text),
//                                int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + resultStr,
//                                System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;
//                    }
//                    break;

//                case "txtMonthNum":
//                    switch (Format)
//                    {
//                        case DateTimeFormat.Long:
//                            result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                            if (e.Delta > 0)
//                            {
//                                if (result == 11 || result == 12)
//                                {
//                                    txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                    goto Esc;
//                                }
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(result + 2);
//                            }
//                            else
//                            {
//                                if (result == 0 || result == 12)
//                                {
//                                    txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(12);
//                                    goto Esc;
//                                }
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(result);
//                            }
//                        Esc:
//                            result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text) >= result) ? result.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                            result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            txtDayText.Text = new DateTime(int.Parse(txtYer.Text), result, int.Parse(txtDayNum.Text)).ToString("dddd");

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                               DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1,
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt")
//                                , System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;
//                        case DateTimeFormat.MonthYear:

//                            result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text);
//                            if (e.Delta > 0)
//                            {
//                                if (result == 11 || result == 12)
//                                {
//                                    txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                    goto Esc1;
//                                }
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(result + 2);
//                            }
//                            else
//                            {
//                                if (result == 0 || result == 12)
//                                {
//                                    txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(12);
//                                    goto Esc1;
//                                }
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(result);
//                            }
//                        Esc1:
//                            result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text) >= result) ? result.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                            //result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            //txtDayText.Text = new DateTime(int.Parse(txtYer.Text), result, int.Parse(txtDayNum.Text)).ToString("dddd");

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1,
//                                1,
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;

//                        case DateTimeFormat.Short:

//                            if (e.Delta > 0)
//                            {
//                                if (txtMonthNum.Text == "12")
//                                {
//                                    txtMonthNum.Text = "01";
//                                    goto ETimem;
//                                }
//                                txtMonthNum.Text = (int.Parse(txtMonthNum.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtMonthNum.Text == "01" || txtMonthNum.Text == "0")
//                                {
//                                    txtMonthNum.Text = "12";
//                                    goto ETimem;
//                                }
//                                txtMonthNum.Text = (int.Parse(txtMonthNum.Text) - 1).ToString();
//                            }
//                        ETimem:
//                            txtMonthNum.Text = (txtMonthNum.Text.Length == 1) ? "0" + txtMonthNum.Text : txtMonthNum.Text;

//                            if (int.TryParse(txtMonthNum.Text, out result))
//                            {
//                                MonthNum = result;
//                                result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            }

//                            txtDayNum.Text = (int.Parse(txtDayNum.Text) >= result) ? result.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                MonthNum,
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;

//                        case DateTimeFormat.Time:
//                        default:
//                            if (e.Delta > 0)
//                            {
//                                if (txtMonthNum.Text == "59")
//                                {
//                                    txtMonthNum.Text = "00";
//                                    goto ETimes;
//                                }
//                                txtMonthNum.Text = (int.Parse(txtMonthNum.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtMonthNum.Text == "00" || txtMonthNum.Text == "0")
//                                {
//                                    txtMonthNum.Text = "59";
//                                    goto ETimes;
//                                }
//                                txtMonthNum.Text = (int.Parse(txtMonthNum.Text) - 1).ToString();
//                            }
//                        ETimes:
//                            txtMonthNum.Text = (txtMonthNum.Text.Length == 1) ? "0" + txtMonthNum.Text : txtMonthNum.Text;


//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                DtValue.Month,
//                                DtValue.Day,
//                                int.Parse(txtYer.Text),
//                                int.Parse(txtMonthNum.Text),
//                                int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + " " + txtDayText.Text,
//                                System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;
//                    }
//                    break;

//                case "txtDayNum":
//                    switch (Format)
//                    {
//                        case DateTimeFormat.Long:
//                        case DateTimeFormat.Short:
//                            MonthNum = 1;
//                            if (int.TryParse(txtMonthNum.Text, out MonthNum))
//                            {
//                                result = DateTime.DaysInMonth(int.Parse(txtYer.Text), MonthNum);
//                            }
//                            else
//                            {
//                                MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                                result = DateTime.DaysInMonth(int.Parse(txtYer.Text), MonthNum);
//                            }

//                            if (e.Delta > 0)
//                            {
//                                if (txtDayNum.Text == result.ToString())
//                                {
//                                    resultStr = "01";
//                                    goto Es;
//                                }
//                                resultStr = (int.Parse(txtDayNum.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtDayNum.Text == "01" || txtDayNum.Text == "1")
//                                {
//                                    resultStr = result.ToString();
//                                    goto Es;
//                                }
//                                resultStr = (int.Parse(txtDayNum.Text) - 1).ToString();
//                            }

//                        Es:

//                            //if (int.TryParse(txtMonthNum.Text, out result))
//                            //{
//                            //    result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            //}
//                            //else
//                            //{
//                            //    result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            //}
//                            result = DateTime.DaysInMonth(int.Parse(txtYer.Text), MonthNum);

//                            if (Convert.ToInt32(resultStr) > result)
//                            {
//                                resultStr = result.ToString();
//                            }
//                            txtDayNum.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;
//                            txtDayText.Text = new DateTime(int.Parse(txtYer.Text), MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");

//                            //if (int.TryParse(txtMonthNum.Text, out result))
//                            //{
//                            //    result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                            //}
//                            //else
//                            //{
//                            //    result = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            //}

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                MonthNum,
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;

//                        case DateTimeFormat.Time:
//                        default:
//                            if (e.Delta > 0)
//                            {
//                                if (txtDayNum.Text == "59")
//                                {
//                                    resultStr = "00";
//                                    goto EX; ;
//                                }
//                                resultStr = (int.Parse(txtDayNum.Text) + 1).ToString();
//                            }
//                            else
//                            {
//                                if (txtDayNum.Text == "00" || txtDayNum.Text == "0")
//                                {
//                                    resultStr = "59";
//                                    goto EX;
//                                }
//                                resultStr = (int.Parse(txtDayNum.Text) - 1).ToString();
//                            }
//                        EX:
//                            txtDayNum.Text = (resultStr.Length == 1) ? "0" + resultStr : resultStr;

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(DtValue.Year,
//                                DtValue.Month,
//                                DtValue.Day,
//                                int.Parse(txtYer.Text),
//                                int.Parse(txtMonthNum.Text),
//                                int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + " " + txtDayText.Text, System.Globalization.CultureInfo.CurrentCulture);
//                            //System.Globalization.CultureInfo.InvariantCulture
//                            break;
//                    }
//                    break;

//                case "txtDayText":
//                    if (Format == DateTimeFormat.Time)
//                    {
//                        if (e.Delta > 0)
//                        {
//                            if (txtDayText.Text == DateTimeFormatInfo.CurrentInfo.AMDesignator)
//                            {
//                                txtDayText.Text = DateTimeFormatInfo.CurrentInfo.PMDesignator;
//                            }
//                            else
//                            {
//                                txtDayText.Text = DateTimeFormatInfo.CurrentInfo.AMDesignator;
//                            }
//                        }
//                        else
//                        {
//                            if (txtDayText.Text == DateTimeFormatInfo.CurrentInfo.PMDesignator)
//                            {
//                                txtDayText.Text = DateTimeFormatInfo.CurrentInfo.AMDesignator;
//                            }
//                            else
//                            {
//                                txtDayText.Text = DateTimeFormatInfo.CurrentInfo.PMDesignator;
//                            }
//                        }

//                        flgWheel = true;
//                        Value = DateTime.Parse(new DateTime(DtValue.Year,
//                            DtValue.Month,
//                            DtValue.Day,
//                            int.Parse(txtYer.Text),
//                            int.Parse(txtMonthNum.Text),
//                            int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + " " + txtDayText.Text, System.Globalization.CultureInfo.CurrentCulture);
//                        //System.Globalization.CultureInfo.InvariantCulture
//                    }
//                    break;
//                default:
//                    break;
//            }

//        } 

//        #endregion

//        protected override void OnForeColorChanged(EventArgs e)
//        {
//            base.OnForeColorChanged(e);
//            txtYer.ForeColor = this.ForeColor;
//            txtMonthNum.ForeColor = this.ForeColor;
//            //txtMonthText.ForeColor = this.ForeColor;
//            txtDayNum.ForeColor = this.ForeColor;
//            txtDayText.ForeColor = this.ForeColor;
//            lblY.ForeColor = this.ForeColor;
//            lblM.ForeColor = this.ForeColor;
//            lblD.ForeColor = this.ForeColor;

//            bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width, Height-2);
//            btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
//            btn.Invalidate();
//        }
//        protected override void OnFontChanged(EventArgs e)
//        {
//            base.OnFontChanged(e);
//            txtYer.Font = this.Font;
//            txtMonthNum.Font = this.Font;
//            //txtMonthText.Font = this.Font;
//            txtDayNum.Font = this.Font;
//            txtDayText.Font = this.Font;

//            lblY.Font = this.Font ;
//            lblM.Font  = this.Font ;
//            lblD.Font  = this.Font ;

//            Reset();

//        }
//        protected override void OnResize(EventArgs e)
//        {
//            base.OnResize(e);
//            this.Reset();
//        }

//        //protected override void OnHandleCreated(EventArgs e)
//        //{
//        //    base.OnHandleCreated(e);
//        //    this.Reset();
//        //}

//        [DllImport("user32.dll")]
//        static extern bool HideCaret(System.IntPtr hWnd);
//        public void HideCaret(Control ctrl)
//        {
//            HideCaret(ctrl.Handle);
//        }

//        private void Reset()
//        {
//            flgChanged = false;
//            CultureInfo.CurrentCulture.ClearCachedData();
//            switch (Format)
//            {
//                case DateTimeFormat.Long:
//                    txtYer.MaxLength = 4;
//                    txtMonthNum.MaxLength = 20;
//                    txtDayText.MaxLength = 10;
                    
//                    txtYer.Text = Value.ToString("yyyy");
//                    txtYer.Size = new Size(GetFontSize(txtYer.Text), GetFontSize(txtYer.Text, false));

//                    txtMonthNum.Text = Value.ToString("MMMM");
//                    SizeF ctr = new SizeF(1, 1);
//                    foreach (String s in DateTimeFormatInfo.CurrentInfo.MonthNames.ToList())
//                    {
//                        if (this.CreateGraphics().MeasureString(s, this.Font).Width > ctr.Width)
//                        {
//                            ctr = new SizeF(this.CreateGraphics().MeasureString(s, this.Font).Width, this.CreateGraphics().MeasureString(s, this.Font).Height);
//                        }
//                    }
//                    txtMonthNum.Size = new Size(Convert.ToInt32(ctr.Width), Convert.ToInt32(ctr.Height));

//                    txtDayNum.Visible = true;
//                    txtDayNum.Text = Value.ToString("dd");
//                    txtDayNum.Size = new Size(GetFontSize(txtDayNum.Text), GetFontSize(txtDayNum.Text, false));

//                    txtMonthNum.ReadOnly = true;
//                    txtDayText.Visible = true;
//                    txtDayText.ReadOnly = true;

//                    ctr = new SizeF(1, 1);
//                    foreach (String s in DateTimeFormatInfo.CurrentInfo.DayNames.ToList())
//                    {
//                        if (this.CreateGraphics().MeasureString(s, this.Font).Width > ctr.Width)
//                        {
//                            ctr = new SizeF(this.CreateGraphics().MeasureString(s, this.Font).Width, this.CreateGraphics().MeasureString(s, this.Font).Height);
//                        }
//                    }

//                    txtDayText.Text = Value.ToString("dddd");
//                    txtDayText.Size = new Size(Convert.ToInt32(ctr.Width), Convert.ToInt32(ctr.Height));

//                    lblY.Visible = true;
//                    lblY.Text = "\\";
//                    lblY.Size = new Size(GetFontSize(lblY.Text), GetFontSize(lblY.Text, false));

//                    lblM.Visible = true;
//                    lblM.Text = "\\";
//                    lblM.Size = new Size(GetFontSize(lblM.Text), GetFontSize(lblM.Text, false));

//                    lblD.Visible = false;
//                    lblD.Text = "-";
//                    lblD.Size = new Size(GetFontSize(lblD.Text), GetFontSize(lblD.Text, false));

//                    lblY.Left = txtYer.Width;
//                    txtMonthNum.Left = txtYer.Width + lblY.Width;
//                    lblM.Left = txtYer.Width + lblY.Width + txtMonthNum.Width;
//                    txtDayNum.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width;
//                    lblD.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width + txtDayNum.Width;
//                    txtDayText.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width + txtDayNum.Width + lblD.Width;
//                    Height = txtYer.Font.Height;
//                    break;

//                case DateTimeFormat.Short:

//                    txtYer.MaxLength = 4;
//                    txtMonthNum.MaxLength = 2;

//                    txtYer.Text = Value.ToString("yyyy");
//                    txtYer.Size = new Size(GetFontSize(txtYer.Text), GetFontSize(txtYer.Text, false));

//                    txtMonthNum.Text = Value.ToString("MM");
//                    txtMonthNum.Size = new Size(GetFontSize(txtMonthNum.Text), GetFontSize(txtMonthNum.Text, false));

//                    txtDayNum.Text = Value.ToString("dd");
//                    txtDayNum.Size = new Size(GetFontSize(txtDayNum.Text), GetFontSize(txtDayNum.Text, false));
//                    txtDayNum.Visible = true;
//                    txtDayText.Visible = false;
//                    txtMonthNum.ReadOnly = false;

//                    lblY.Text = "\\";
//                    lblY.Size = new Size(GetFontSize(lblY.Text), GetFontSize(lblY.Text, false));

//                    lblM.Text = "\\";
//                    lblM.Size = new Size(lblY.Size.Width, lblY.Size.Height);

//                    lblM.Visible = true;
//                    lblD.Visible = false;

//                    lblY.Left = txtYer.Width;
//                    txtMonthNum.Left = txtYer.Width + lblY.Width;
//                    lblM.Left = txtYer.Width + lblY.Width + txtMonthNum.Width;
//                    txtDayNum.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width;
//                    Height = txtYer.Font.Height;
//                    break;

//                case DateTimeFormat.Time:

//                    txtYer.MaxLength = 2;
//                    txtMonthNum.MaxLength = 2;
//                    txtDayText.MaxLength = 2;

//                    txtYer.Text = Value.ToString("hh");
//                    txtYer.Size = new Size(GetFontSize(txtYer.Text), GetFontSize(txtYer.Text, false));

//                    txtMonthNum.Text = Value.ToString("mm");
//                    txtMonthNum.Size = new Size(GetFontSize(txtMonthNum.Text), GetFontSize(txtMonthNum.Text, false));

//                    txtDayNum.Text = Value.ToString("ss");
//                    txtDayNum.Size = new Size(GetFontSize(txtDayNum.Text), GetFontSize(txtDayNum.Text, false));
//                    txtDayNum.Visible = true;

//                    txtDayText.Text = Value.ToString("tt");
//                    txtDayText.Size = new Size(GetFontSize(txtDayText.Text), GetFontSize(txtDayText.Text, false));
//                    txtDayText.Visible = true;
//                    txtDayText.ReadOnly = false;
//                    txtMonthNum.ReadOnly = false;

//                    lblY.Text = ":";
//                    lblY.Size = new Size(GetFontSize(lblY.Text), GetFontSize(lblY.Text, false));

//                    lblM.Visible = true;
//                    lblM.Text = ":";
//                    lblM.Size = new Size(lblY.Size.Width, lblY.Size.Height);
//                    lblD.Visible = false;

//                    lblY.Left = txtYer.Width;
//                    txtMonthNum.Left = txtYer.Width + lblY.Width;
//                    lblM.Left = txtYer.Width + lblY.Width + txtMonthNum.Width;
//                    txtDayNum.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width;
//                    lblD.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width + txtDayNum.Width;
//                    txtDayText.Left = txtYer.Width + txtMonthNum.Width + lblY.Width + lblM.Width + txtDayNum.Width + lblD.Width;
//                    Height = txtYer.Font.Height;
//                    break;

//                case DateTimeFormat.MonthYear:

//                    txtYer.MaxLength = 4;
//                    txtMonthNum.MaxLength = 20;
//                    txtMonthNum.ReadOnly = true;

//                    txtYer.Text = Value.ToString("yyyy");
//                    txtYer.Size = new Size(GetFontSize(txtYer.Text) , GetFontSize(txtYer.Text, false));

//                    txtMonthNum.Text = Value.ToString("MMMM");
//                    txtMonthNum.Size = new Size(GetFontSize(txtMonthNum.Text) , GetFontSize(txtMonthNum.Text, false));
//                    txtDayNum.Visible = false;
//                    txtDayText.Visible = false;

//                    lblY.Text = "\\";
//                    lblY.Size = new Size(GetFontSize(lblY.Text), GetFontSize(lblY.Text, false));

//                    lblM.Visible = false;
//                    lblD.Visible = false;

//                    lblY.Left = txtYer.Width;
//                    txtMonthNum.Left = txtYer.Width + lblY.Width;
//                    Height = txtYer.Font.Height;
//                    break;
//                default:
//                    break;
//            }
            

//            if (ShowCalendar == true && Format != DateTimeFormat.Time)
//            {
//                btn.Size = new Size(20, Height);
//                btn.Left = this.Width - btn.Size.Width - 5;
//                btn.Top = 0;
//                bmp = new Bitmap(Properties.Resources.Calender_32px, btn.Size.Width, Height / 2);
//                btn.Image = ZTheme.ReplaceColor(bmp, Color.Black, this.ForeColor);
//                btn.Invalidate();
//            }
//            else
//            {
//                btn.Size = new Size(0, 0);
//            }

//        }
//        int GetFontSize(string text, bool isWidth = true)
//        {
//            if (isWidth)
//            {
//                return Convert.ToInt32(this.CreateGraphics().MeasureString(text, this.Font).Width);
//            }
//            else
//            {
//                return Convert.ToInt32(this.CreateGraphics().MeasureString(text, this.Font).Height);
//            }
//        }

//        void SetValue(string TextBoxName ,DateTime value)
//        {
//            switch (TextBoxName)
//            {

//             case "txtYer":

//                    switch (Format)
//                    {
//                        case DateTimeFormat.Long:
//                        case DateTimeFormat.MonthYear:

//                            MonthNum = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(txtMonthNum.Text) + 1;
//                            DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);
//                            txtDayText.Text = new DateTime(YearNumber, MonthNum, int.Parse(txtDayNum.Text)).ToString("dddd");


//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                                MonthNum,
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                            break;
//                        case DateTimeFormat.Short:

//                            MonthNum = int.Parse(txtMonthNum.Text);
//                            DayCount = DateTime.DaysInMonth(YearNumber, MonthNum);
//                            txtDayNum.Text = (int.Parse(txtDayNum.Text)) >= DayCount ? DayCount.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                            flgWheel = true;
//                            Value = DateTime.Parse(new DateTime(YearNumber,
//                                MonthNum,
//                                int.Parse(txtDayNum.Text),
//                                DtValue.Hour,
//                                DtValue.Minute,
//                                DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);


//                            break;

//                        case DateTimeFormat.Time:
//                        default:
//                            break;

//                    }

//                    break;
//                case "txtMonthNum":
//                    break;
//                case "txtDayNum":
//                    break;
//                case "txtDayText":
//                    break;
                    
//                default:
//                    break;
//            }
//        }

//        public event EventHandler<DateTime> ValueChanged;
//        private void DdCal_GetDate(object sender, DateTime e)
//        {
//            flgWheel = false;
//            //nDy.Maximum = DateTime.DaysInMonth(e.Year, e.Month);
//            //if ((int)nDy.Value > (int)nDy.Maximum)
//            //{
//            //    nDy.Value = nDy.Maximum;
//            //}
//            //nDy.Value = e.Day;
//            //nMth.Value = e.Month;
//            //nYer.Value = e.Year;
//            this.Value = e;
//        }

//        #endregion

//    }

//}
////   fHeight = Convert.ToInt32(this.CreateGraphics().MeasureString(DateTime.Now.ToString("dddd", CultureInfo.CreateSpecificCulture("US")), this.Font).Height);

///*
// if (flgChanged == true)
//            {
//                //DtValue = DateTime.Now;
//                //flgWheel = true;
//                CultureInfo.CurrentCulture.ClearCachedData();
//                switch (Format)
//                {
//                    case DateTimeFormat.Long:
//                    case DateTimeFormat.MonthYear:


//                        flgChanged = false;
//                        OldText = "0";
//                        OldValue = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(OldMonth) +1;

//                        if (OldValue == 1)
//                        {
//                            if (txtMonthNum.Text == "1" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("1" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(11);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(11);
//                            }
//                            else if (txtMonthNum.Text == "0" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("0" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                            }
//                            else if (txtMonthNum.Text == "2" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("2" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(12);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(12);
//                            }

//                        }
//                        else if (OldValue == 10)// && int.Parse(txtMonthNum.Text) == 1)
//                        {
//                            if (txtMonthNum.Text == "1" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("1" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                            }
//                            else if (txtMonthNum.Text == "0" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("0" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                            }
//                            else if (txtMonthNum.Text == "2" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("2" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                            }
//                        }
//                        else if (OldValue == 11)// && int.Parse(txtMonthNum.Text) == 1)
//                        {
//                            if (txtMonthNum.Text == "1" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("1" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                            }
//                            else if (txtMonthNum.Text == "0" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("0" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                            }
//                            else if (txtMonthNum.Text == "2" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("2" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                            }
//                        }
//                        else if (OldValue == 12)// && int.Parse(txtMonthNum.Text) == 1)
//                        {
//                            if (txtMonthNum.Text == "1" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("1" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
//                            }
//                            else if (txtMonthNum.Text == "0" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("0" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(10);
//                            }
//                            else if (txtMonthNum.Text == "2" || txtMonthNum.Text == OldMonth || txtMonthNum.Text == ("2" + OldMonth))
//                            {
//                                txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(2);
//                                OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(2);
//                            }
//                        }
//                        //OldMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(OldValue);
//                        //txtMonthNum.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(OldValue);
//                        return;
//                        //--
                       
//                    return;
                   
//                        break;

//                    case DateTimeFormat.Short:

//                        //if (e.Delta > 0)
//                        //{
//                        //    if (txtMonthNum.Text == "12")
//                        //    {
//                        //        txtMonthNum.Text = "01";
//                        //        goto ETimem;
//                        //    }
//                        //    txtMonthNum.Text = (int.Parse(txtMonthNum.Text) + 1).ToString();
//                        //}
//                        //else
//                        //{
//                        //    if (txtMonthNum.Text == "01" || txtMonthNum.Text == "0")
//                        //    {
//                        //        txtMonthNum.Text = "12";
//                        //        goto ETimem;
//                        //    }
//                        //    txtMonthNum.Text = (int.Parse(txtMonthNum.Text) - 1).ToString();
//                        //}
//                    ETimem:
//                        txtMonthNum.Text = (txtMonthNum.Text.Length == 1) ? "0" + txtMonthNum.Text : txtMonthNum.Text;

//                        if (int.TryParse(txtMonthNum.Text, out result))
//                        {
//                            MonthNum = result;
//                            result = DateTime.DaysInMonth(int.Parse(txtYer.Text), result);
//                        }

//                        txtDayNum.Text = (int.Parse(txtDayNum.Text) >= result) ? result.ToString() : ((txtDayNum.Text.Length == 1) ? "0" + txtDayNum.Text : txtDayNum.Text);

//                        flgWheel = true;
//                        Value = DateTime.Parse(new DateTime(int.Parse(txtYer.Text),
//                            MonthNum,
//                            int.Parse(txtDayNum.Text),
//                            DtValue.Hour,
//                            DtValue.Minute,
//                            DtValue.Second).ToString("yyyy,MM,dd hh:mm:ss tt"), System.Globalization.CultureInfo.CurrentCulture);
//                        //System.Globalization.CultureInfo.InvariantCulture
//                        break;

//                    case DateTimeFormat.Time:
//                    default:
//                        //if (e.Delta > 0)
//                        //{
//                        //    if (txtMonthNum.Text == "59")
//                        //    {
//                        //        txtMonthNum.Text = "00";
//                        //        goto ETimes;
//                        //    }
//                        //    txtMonthNum.Text = (int.Parse(txtMonthNum.Text) + 1).ToString();
//                        //}
//                        //else
//                        //{
//                        //    if (txtMonthNum.Text == "00" || txtMonthNum.Text == "0")
//                        //    {
//                        //        txtMonthNum.Text = "59";
//                        //        goto ETimes;
//                        //    }
//                        //    txtMonthNum.Text = (int.Parse(txtMonthNum.Text) - 1).ToString();
//                        //}
//                    ETimes:
//                        txtMonthNum.Text = (txtMonthNum.Text.Length == 1) ? "0" + txtMonthNum.Text : txtMonthNum.Text;


//                        flgWheel = true;
//                        Value = DateTime.Parse(new DateTime(DtValue.Year,
//                            DtValue.Month,
//                            DtValue.Day,
//                            int.Parse(txtYer.Text),
//                            int.Parse(txtMonthNum.Text),
//                            int.Parse(txtDayNum.Text)).ToString("yyyy,MM,dd hh:mm:ss") + " " + txtDayText.Text,
//                            System.Globalization.CultureInfo.CurrentCulture);
//                        //System.Globalization.CultureInfo.InvariantCulture
//                        break;

//                        //-- s if m
//                }
//            }
//            else if (OldText == "0" && txtMonthNum.Text != OldMonth)
//            {
//                txtMonthNum.Text = OldMonth;
//                OldText = "0";
//            }
            
// */