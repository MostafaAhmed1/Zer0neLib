using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{ 
    public class ZPictureBox : PictureBox
    {
        //Constructor
        public ZPictureBox()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.CenterImage;

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
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            base.Font = ZTheme.Fontz;
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
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [Category("Zer0ne")]
        public int BorderSize
        {
            get
            {
                return ZStyle.BorderSize;
            }

            set
            {
                ZStyle.BorderSize = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor1
        {
            get
            {
                return ZStyle.GradientColor1;
            }
            set
            {
                ZStyle.GradientColor1 = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor2
        {
            get
            {
                return ZStyle.GradientColor2;
            }
            set
            {
                ZStyle.GradientColor2 = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public DashStyle BorderLineStyle
        {
            get
            {
                return ZStyle.BorderLineStyle;
            }

            set
            {
                ZStyle.BorderLineStyle = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public DashCap BorderCapStyle
        {
            get
            {
                return ZStyle.BorderCapStyle;
            }

            set
            {
                ZStyle.BorderCapStyle = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public float GradientAngle
        {
            get
            {
                return ZStyle.GradientAngle;
            }

            set
            {
                ZStyle.GradientAngle = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public int Radius
        {
            get
            {
                return ZStyle.Radius;
            }
            set
            {
                ZStyle.Radius = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public BorderMode BorderCornerStyle
        {
            get
            {
                return ZStyle.BorderCornersStyle;
            }
            set
            {
                ZStyle.BorderCornersStyle = value;
                Invalidate();
            }
        }

        //Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (ZStyle.BorderCornersStyle == BorderMode.Circle)
            {
                this.Size = new Size(this.Width, this.Width);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (ZStyle.BorderCornersStyle == BorderMode.Circle)
            {
                //Fields
                var graph = pe.Graphics;
                var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
                var rectBorder = Rectangle.Inflate(rectContourSmooth, -ZStyle.BorderSize, -ZStyle.BorderSize);
                var smoothSize = ZStyle.BorderSize > 0 ? ZStyle.BorderSize * 3 : 1;
                using (var borderGColor = new LinearGradientBrush(rectBorder, ZStyle.GradientColor1, ZStyle.GradientColor2, ZStyle.GradientAngle))
                using (var pathRegion = new GraphicsPath())
                using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (var penBorder = new Pen(borderGColor, ZStyle.BorderSize))
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.DashStyle = ZStyle.BorderLineStyle;
                    penBorder.DashCap = ZStyle.BorderCapStyle;
                    pathRegion.AddEllipse(rectContourSmooth);
                    //Set rounded region 
                    this.Region = new Region(pathRegion);

                    //Drawing
                    graph.DrawEllipse(penSmooth, rectContourSmooth);//Draw contour smoothing 

                    if (ZStyle.BorderSize > 0) //Draw border
                    {
                        graph.DrawEllipse(penBorder, rectBorder); 
                    }
                }
            }
            else
            {
                //Fields
                var smthClr = this.Parent.BackColor;
                var graph = pe.Graphics;
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
            }

            base.OnPaint(pe);
        }
    }
}
