using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    public class ZButton : Button
    { 
        ContextMenuStrip dropMenu;
        bool EnableDropMenu;

        public ZButton()
        {
            Size = new Size(100, 100);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = true;
            TabStop = true;

            EnableDropMenu = false;
            // 
            // contextMenuStrip1
            // 
            dropMenu = new ContextMenuStrip();
            dropMenu.SuspendLayout();
            dropMenu.Name = "dropMenu";
            dropMenu.Size = new Size(200, 70);
            dropMenu.RightToLeft = RightToLeft.Yes;

            //ContextMenuStrip = contextMenuStrip1;
            base.Click += DevButton_Click;
            base.Font = ZTheme.Fontz;

            dropMenu.ResumeLayout(false);

            ZStyle = new ZControlStyle()
            {
                Radius = ZTheme.ControlStyle.Radius,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.AccentColor,
                GradientColor2 = ZTheme.AccentColor,
                BackColor = ZTheme.AccentColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
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
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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
            //base.Font = this.Font;
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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
      
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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
        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if(ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.Text = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.Text = value;
                }
                Invalidate();
            }
        }
       
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
        public int BorderSize
        {
            get
            {
                return ZStyle.BorderSize;
            }
            set
            {
                if (value > 1)
                {
                    ZStyle.BorderSize = value;
                }
                else
                {
                    ZStyle.BorderSize = 1;
                } 
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(typeof(Color), "Gray"), Category("Zer0ne")]
        public Color BorderColor1
        {
            get
            {
                return ZStyle.GradientColor1;
            }
            set
            {
                ZStyle.GradientColor1 = value;
                this.Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),DefaultValue(typeof(Color), "Gray"), Category("Zer0ne")]
        public Color BorderColor2
        {
            get
            {
                return ZStyle.GradientColor2;
            }
            set
            {
                ZStyle.GradientColor2 = value;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
            base.OnPaint(pe);
            if (ZStyle.BorderCornersStyle == BorderMode.Circle)
            {
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
        }

        private void DevButton_Click(object sender, EventArgs e)
        {
            if (EnableDropMenu)
            {
                var p = this.PointToScreen(Point.Empty);
                p = new Point(p.X + this.Width, p.Y + this.Height);
                dropMenu.Show(p, ToolStripDropDownDirection.BelowLeft);
            }
        }

        public void AddDropListItem(string text, EventHandler action)
        {
            EnableDropMenu = true;

            ZDropDownItem toolStripMenuItem1 = new ZDropDownItem();
            toolStripMenuItem1.Name = text + dropMenu.Items.Count;
            toolStripMenuItem1.Size = new Size(200, 30);
            toolStripMenuItem1.Text = text;
            toolStripMenuItem1.Click += action;

            dropMenu.Items.Add(toolStripMenuItem1);
        }

        public void ClearDropItems()
        {
            dropMenu.Items.Clear();
            EnableDropMenu = false;
        }

    }
}
