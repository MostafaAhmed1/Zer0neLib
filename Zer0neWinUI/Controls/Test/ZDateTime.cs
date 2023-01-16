
//using System;
//using System.ComponentModel;
//using System.Drawing;
//using System.Linq;
//using Zer0ne.WinUI.Utilities;

//namespace Zer0ne.WinUI.Controls
//{
//    [DefaultEvent("ValueChanged"), DefaultProperty("Value")]
//     class ZDateTime : ZControl, IControlZ
//    {
//        public ZDateTime() : base(new BaseDateTime55())
//        {
//            ctrl = (BaseDateTime55)base.ChildControl;
//            ctrl.Font = base.Font;
//            ctrl.BackColor = base.BackColor;
//            ctrl.BorderColor = base.BackColor;
//            ctrl.ArrowColor = this.ArrowColor;
//            ctrl.ArrowFocus = this.ArrowFocus;
//            ctrl.Value = dt;
//            ctrl.ValueChanged += Ctrl_ValueChanged;
//        }

//        #region Propreties
//        private BaseDateTime55 ctrl;

//        //[Category("Zer0ne")]
//        //public ShowDate DisplayDate
//        //{
//        //    get { return ctrl.DisplayDate; }
//        //    set
//        //    {
//        //        ctrl.DisplayDate = value;
//        //        Invalidate();
//        //    }
//        //}

//        [Category("Zer0ne")]
//        public string ErrorText
//        {
//            get
//            {
//                return ctrl.ErrorText;
//            }
//            set
//            {
//                ctrl.ErrorText = value;
//            }
//        }

//        [Category("Zer0ne")]
//        public bool ShowCalendar
//        {
//            get { return ctrl.ShowCalendar; }
//            set
//            {
//                ctrl.ShowCalendar = value;
//                ctrl.Invalidate();
//            }
//        }

//        [Category("Zer0ne")]
//        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//        public Color ArrowColor
//        {
//            get
//            {
//                return base.ZStyle.HintColor;
//            }
//            set
//            {
//                base.ZStyle.HintColor = value;
//                ctrl.ArrowColor = base.ZStyle.HintColor;
//                ctrl.Invalidate();
//                Invalidate();
//            }
//        }

//        [Category("Zer0ne")]
//        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//        public Color ArrowFocus
//        {
//            get
//            {
//                return base.ZStyle.ActiveColor;
//            }
//            set
//            {
//                base.ZStyle.ActiveColor = value;
//                ctrl.ArrowFocus = base.ZStyle.ActiveColor;
//                ctrl.Invalidate();
//                this.Invalidate();
//            }
//        }

//        [Category("Zer0ne")]
//        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//        public new Color BackColor
//        {
//            get { return base.BackColor; }
//            set
//            {
//                base.BackColor = value;
//                ctrl.BackColor = base.BackColor;
//                ctrl.BorderColor = base.BackColor;
//                ctrl.Invalidate();
//            }
//        }

//        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//        public bool ReadOnly
//        {
//            get
//            {
//                return false;
//            }
//            set
//            {
//                value = false;
//            }
//        }

//        private DateTime dt = DateTime.Now;
//        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
//        public DateTime Value
//        {
//            get
//            {
//                return dt;
//            }
//            set
//            {
//                dt = value;
//                this.ValueChanged?.Invoke(this, value);

//                ctrl.flg = false;
//                foreach (var item in ctrl.Controls.OfType<BaseNumeric>())
//                {
//                    if (item.Maximum > 32)
//                    {
//                        item.Value = value.Year;
//                    }
//                    else if (item.Maximum == 12)
//                    {
//                        item.Value = value.Month;
//                    }
//                    else
//                    {
//                        item.Value = value.Day;
//                    }

//                }
//                ctrl.flg = true;
//            }
//        }

        
//        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
//        public DateTime MaxDate
//        {
//            get
//            {
//                return ctrl.MaxDate;
//            }
//            set
//            {
//                ctrl.MaxDate = value;
//            }
//        }

        
//        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
//        public DateTime MinDate
//        {
//            get
//            {
//                return ctrl.MinDate;
//            }
//            set
//            {
//                ctrl.MinDate = value;
//            }
//        }


//        #endregion

//        #region Events Methods

//        public event EventHandler<DateTime> ValueChanged;
//        private void Ctrl_ValueChanged(object sender, DateTime e)
//        {
//            this.Value = e;
//        }

//        #endregion



//    }
//}
