using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
   public  class ZSeparator : Control
    {
        public ZSeparator()
        {
            ZStyle = new ZControlStyle()
            {
                Radius = 8,
                BorderSize = 2,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.ControlStyle.InactiveColor,
                GradientColor2 = ZTheme.ControlStyle.InactiveColor,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.BacgroundColor
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        #region Propereties

        ZControlStyle zStyle = new ZControlStyle();
        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZControlStyle ZStyle
        {
            get
            {
                return zStyle;
            }
            set
            {
                zStyle = value;
                Recolor();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                return ZStyle.BackColor;
            }
            set
            {
                ZStyle.BackColor = value;
                base.BackColor = ZStyle.BackColor;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get
            {
                return ZStyle.TextColor;
            }
            set
            {
                ZStyle.TextColor = value;
                base.ForeColor = ZStyle.TextColor;
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public Color LineColor
        {
            get
            {
                return ZStyle.ActiveColor;
            }

            set
            {
                ZStyle.ActiveColor = value;
                Invalidate();
            }
        }

        private bool _isVertical;
        [Category("Zer0ne")]
        public bool IsVertical
        {
            get => _isVertical;
            set
            {
                _isVertical = value;
                Invalidate();
            }
        }

        private int _thckness = 5;
        [Category("Zer0ne")]
        public int Thickness
        {
            get => _thckness;
            set
            {
                _thckness = value;
                if (Height < _thckness)
                {
                    Height = _thckness;
                }
                //else
                //{
                //    Invalidate();
                //}
                Invalidate();
            }
        }

        private DashStyle lineStyle = DashStyle.Solid;
        [Category("Zer0ne")]
        public DashStyle LineStyle
        {
            get
            {
                return lineStyle;
            }

            set
            {
                lineStyle = value;
                Invalidate();
            }
        }

        private LineCap startLine = LineCap.ArrowAnchor;
        [Category("Zer0ne"),DefaultValue(LineCap.ArrowAnchor)]
        public LineCap StartLine
        {
            get
            {
                return startLine;
            }

            set
            {
                startLine = value;
                Invalidate();
            }
        }

        private LineCap endLine = LineCap.ArrowAnchor;
        [Category("Zer0ne"), DefaultValue(LineCap.ArrowAnchor)]
        public LineCap EndLine
        {
            get
            {
                return endLine;
            }

            set
            {
                endLine = value;
                Invalidate();
            }
        }
        #endregion

        #region Methods Events

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }
        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            var sz = _isVertical ? Height / 2 : Width / 2;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(Width / 2f, Height / 2f);

            using (var pen = new Pen(LineColor, Thickness))
            {
                pen.DashStyle = this.lineStyle; //DashStyle.Solid;
                pen.StartCap = this.startLine; //LineCap.ArrowAnchor;
                pen.EndCap = this.EndLine; //LineCap.ArrowAnchor;
                if (!IsVertical)
                {
                    //e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.DisplayRectangle.Width / 4, this.DisplayRectangle.Height / 2);
                    e.Graphics.DrawLine(pen, -sz + Padding.Left, 0, sz - Padding.Right, 0);


                }
                else
                {
                    //e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.DisplayRectangle.Width / 4, this.DisplayRectangle.Height / 2);

                    e.Graphics.DrawLine(pen, 0, -sz + Padding.Top, 0, sz - Padding.Bottom);
                    //var s = new StringFormat();
                    //PointF b = new PointF(Width / 2, Height / 2);
                    //s.FormatFlags = StringFormatFlags.DirectionVertical;

                }
            }

        }
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }

        #endregion


      
    }
}