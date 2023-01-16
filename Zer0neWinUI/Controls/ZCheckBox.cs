using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.CheckBox))]
    public class ZCheckBox : CheckBox
    {

        #region -> Constructor
        public ZCheckBox()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.Size = new Size(10, 30);
            //AutoSize = false;
            TabStop = true;
            Checked = false;

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
                BackColor = ZTheme.ControlStyle.BackColor,
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

        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            base.Font = ZTheme.Fontz;
        }

        #endregion

        #region Properties

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

        private ItemPositionZ chkAlighn = ItemPositionZ.Right;
        [Category("Zer0ne")]
        public new ItemPositionZ CheckAlign
        {
            get { return chkAlighn; }
            set
            { 
                chkAlighn = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color  ForeColor
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

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor 
        {
            get => ZStyle.BackColor;
            set
            {
                ZStyle.BackColor = value;
                base.BackColor = ZStyle.BackColor;
                Invalidate();
            }
        }

        Font fnt = ZTheme.Fontz;
        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
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
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
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

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                Invalidate();
            }
        }
        #endregion

        #region Events override Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            g.Clear(BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            
            Bitmap bmp = new Bitmap(ZTheme.ReplaceColor(Properties.Resources.checkmark_32px, Color.Black, ZStyle.GradientColor1), this.Height - 2, this.Height - 2);
            var txSize = g.MeasureString(Text, Font);
            int txtX = 1;
            float y = (ClientRectangle.Height / 2) - (bmp.Height / 2);

            if (Checked == true || CheckState == CheckState.Checked)
            {
                switch (CheckAlign)
                {
                    case ItemPositionZ.Left:
                        g.DrawImage(bmp, txtX, y);
                        break;
                    default:
                        g.DrawImage(bmp, ClientRectangle.Width - bmp.Width + txtX, y);
                        break;
                }
            }
            else
            {
                bmp = new Bitmap(ZTheme.ReplaceColor(Properties.Resources.Close_24px, Color.Black, ZStyle.HintColor), Height - 2, Height - 2);
                switch (CheckAlign)
                {
                    case ItemPositionZ.Left:
                        g.DrawImage(bmp, 1, y);
                        break;
                    default:
                        g.DrawImage(bmp, ClientRectangle.Width - bmp.Width + 1, y);
                        break;
                }
            }
            
            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    if (CheckAlign == ItemPositionZ.Right)
                    {
                        txtX = 1;
                    }
                    else
                    {
                        txtX = bmp.Width + 5;
                    }
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    txtX = (Width - (bmp.Width + int.Parse(txSize.Width.ToString("0")))) / 2;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    if (CheckAlign == ItemPositionZ.Right)
                    {
                        txtX = Width - (bmp.Width + 5) - int.Parse(txSize.Width.ToString("0"));
                    }
                    else
                    {
                        txtX = Width - int.Parse(txSize.Width.ToString("0"));
                    }
                    break;
                default:
                    break;
            }

            g.DrawString(Text, Font, new SolidBrush(ForeColor), txtX, (ClientRectangle.Height / 2) - (txSize.Height / 2));
            bmp.Dispose();
        }

        #endregion 

    }
}