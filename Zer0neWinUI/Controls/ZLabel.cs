using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    public class ZLabel : Label
    { 
        public ZLabel()
        {
            this.Size = new Size(100, 100);

            ZStyle = new ZControlStyle()
            {
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                GradientColor1 = ZTheme.ControlStyle.GradientColor1,
                GradientColor2 = ZTheme.ControlStyle.GradientColor2,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                Radius = ZTheme.ControlStyle.Radius,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor
            };

            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
        }
         
        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        //Properties
        ZControlStyle zStyle = new ZControlStyle();
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

        void Recolor()
        {
            base.BackColor =ZStyle.BackColor ;
            base.ForeColor = ZStyle.TextColor;            
        }


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

        Font fnt = ZTheme.Fontz;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Font Font
        {
            get
            {
                fnt = base.Font;
                return fnt;
            }
            set
            {
                fnt = value;
                base.Font = fnt;
                Invalidate();
            }
        }

        private bool autoSize = false;
        public new bool AutoSize
        {
            get
            {
                return autoSize;
            }
            set
            {
                autoSize = value;
            }
        }

        [Category("Zer0ne")]
        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && value != null && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.Text = ZTheme.Language.DicLang[value];
                }
                else
                {
                    base.Text = value;
                }
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var smthClr = this.Parent.BackColor;
            var graph = e.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var rectSmooth = Rectangle.Inflate(rectBorder, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var smoothSize = ZStyle.BorderSize > 0 ? ZStyle.BorderSize * 3 : 1;
            using (var borderGColor = new LinearGradientBrush(rectSmooth, ZStyle.GradientColor1, ZStyle.GradientColor2, ZStyle.GradientAngle))
            using (var pathRegion = ZTheme.RoundedRect(rectContourSmooth, ZStyle.Radius)) // new GraphicsPath()) 
            using (var penSmooth = new Pen(smthClr, smoothSize))
            using (var penBorder = new Pen(borderGColor, ZStyle.BorderSize))
            {
                graph.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.DashStyle = ZStyle.BorderLineStyle;
                penBorder.DashCap = ZStyle.BorderCapStyle;

                //Set rounded region 
                this.Region = new Region(pathRegion);

                //Drawing 
                graph.DrawPath(penSmooth, pathRegion);//Draw contour smoothing

                if (ZStyle.BorderSize > 0) //Draw border
                {
                    graph.DrawPath(penBorder, ZTheme.RoundedRect(rectBorder, ZStyle.Radius));
                }
            }
            base.OnPaint(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
        }
    }
}
