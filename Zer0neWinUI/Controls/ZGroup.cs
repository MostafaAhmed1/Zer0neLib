using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    public class ZGroup : GroupBox
    {

        #region -> Constructor 
        public ZGroup()
        {
            ZStyle = new ZControlStyle()
            {
                Radius = 8,
                BorderSize = 2,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.ControlStyle.GradientColor1,
                GradientColor2 = ZTheme.ThirdColor,
                BackColor = ZTheme.SecondaryColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
            };

            this.DoubleBuffered = true;
            base.Padding = new Padding(0);
            Size = new Size(100, 100);
            base.Font = ZTheme.Fontz;

            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
            TitleBackColor = ZStyle.GradientColor2;
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        #endregion
        
        #region Properetis

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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public new Color BackColor
        {
            get => ZStyle.BackColor;
            set
            {
                ZStyle.BackColor = value;
                base.BackColor = ZStyle.BackColor;
                this.Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
        public int BorderSize
        {
            get => ZStyle.BorderSize;
            set
            {
                ZStyle.BorderSize = value;
                this.Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),Category("Zer0ne")]
        public int Radious
        {
            get => ZStyle.Radius;
            set
            {
                ZStyle.Radius = value;
                this.Invalidate();
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public Color TitleBackColor
        {
            get => ZStyle.GradientColor2;
            set
            {
                ZStyle.GradientColor2 = value;
                this.Invalidate();
            }
        }

        private HatchStyle titleHatchStyle;//= HatchStyle.DottedGrid;
        [Category("Zer0ne")]
        public HatchStyle TitleStyle
        {
            get
            {
                return titleHatchStyle;
            }
            set
            {
                titleHatchStyle = value;
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

        bool showTitle = true;
        [Category("Zer0ne")]
        public bool ShowTitle
        {
            get => showTitle;
            set
            {
                showTitle = value;
                this.Invalidate();
            }
        }

        private TextAlighnZ titleAlighn = TextAlighnZ.Right;
        [Category("Zer0ne")]
        public TextAlighnZ TitleAlignment
        {
            get { return titleAlighn; }
            set
            {
                titleAlighn = value;
                this.Invalidate();
            }
        }

        #endregion

        #region => Events overrides methods

        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            base.Font = ZTheme.Fontz;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GroupBoxRenderer.DrawParentBackground(e.Graphics, this.ClientRectangle, this);
            //var rect = ClientRectangle;

            using (var path = this.RoundRec(this.ClientRectangle, ZStyle.Radius))
            using (var brushBackColor = new SolidBrush(BackColor))
            using (var pen = new Pen(TitleBackColor, ZStyle.BorderSize))
            using (var brushTitle = new SolidBrush( TitleBackColor))
            {
                //using (var brushTitle = new HatchBrush(TitleStyle, TitleBackColor, ControlPaint.Dark(TitleBackColor)))
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                var rect = new Rectangle(0, 0, ClientRectangle.Width, this.Font.Height + Padding.Bottom + Padding.Top);

                // To Fill BackColor
                e.Graphics.FillPath(brushBackColor, path);

                var clip = e.Graphics.ClipBounds;

                // To Fill Hatch In Title Onley
                e.Graphics.SetClip(rect);

                if (ShowTitle)
                {
                    // To Fill Title BackColor
                    e.Graphics.FillPath(brushTitle, path);

                    // To Draw Text 
                    switch (TitleAlignment)
                    {
                        case TextAlighnZ.Right:
                            TextRenderer.DrawText(e.Graphics, Text, this.Font, rect, this.ForeColor, TextFormatFlags.Right);
                            break;
                        case TextAlighnZ.Left:
                            TextRenderer.DrawText(e.Graphics, Text, this.Font, rect, this.ForeColor, TextFormatFlags.Left);
                            break;
                        case TextAlighnZ.Center:
                            TextRenderer.DrawText(e.Graphics, Text, this.Font, rect, this.ForeColor);
                            break;
                        default:
                            break;
                    }
                }

                //To Draw Border In All
                e.Graphics.SetClip(clip);
                e.Graphics.DrawPath(pen, path);

            }
        }

        private GraphicsPath RoundRec(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radius - 1, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radius - 1, bounds.Y + bounds.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
        #endregion

    }

}
