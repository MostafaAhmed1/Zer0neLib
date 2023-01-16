using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    public partial class ZPanel : Panel
    {
        public ZPanel()
        {
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

        [Browsable(true)]//, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        private bool showTitle = false;
        [Browsable(true)]
        public bool  ShowTitle
        {
            get
            {
                return showTitle;
            }

            set
            {
                showTitle = value;
                Invalidate();
            }
        }

        private ContentAlignment titleAlign = ContentAlignment.MiddleCenter;
        [DefaultValue(ContentAlignment.TopCenter), Category("Zer0ne")]
        public ContentAlignment TitleAlign
        {
            get { return titleAlign; }
            set { titleAlign = value; Invalidate(); }
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

        protected override void OnResize(EventArgs eventargs)
        {
            Invalidate();
            base.OnResize(eventargs);
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
                if (ShowTitle)
                {
                TextRenderer.DrawText(graph, Text, this.Font, rectSmooth, this.ForeColor, Color.Transparent, TitleAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                }
            }
            base.OnPaint(e);
        }
    }
}
