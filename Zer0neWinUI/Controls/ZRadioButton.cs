using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    public class ZRadioButton : RadioButton
    {
        public ZRadioButton() : base()
        {
            UseVisualStyleBackColor = true;
            TabStop = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Opaque, true);

            ZStyle = new ZControlStyle()
            {
                Radius = 8,
                BorderSize = 2,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.AccentColor,
                GradientColor2 = ZTheme.ControlStyle.GradientColor2,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
        }

        #region Properties

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

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CheckedColor
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

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color UnCheckedColor
        {
            get
            {
                return ZStyle.InactiveColor;
            }
            set
            {
                ZStyle.InactiveColor = value;
                this.Invalidate();
            }
        }

        private ItemPositionZ chkAlighn = ItemPositionZ.Right;
        [Browsable(true), Category("Zer0ne")]
        public new ItemPositionZ CheckAlign
        {
            get { return chkAlighn; }
            set
            {
                chkAlighn = value;
                this.Invalidate();
            }
        }
        #endregion

        #region -> Event - override - methods

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            //base.Font = ZTheme.Fontz;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            var fSize = pevent.Graphics.MeasureString(this.Text, this.Font);

            float rbBorderSize = 20F;
            float rbCheckSize = 16F;

            if (fSize.Height < 20)
            {
                rbBorderSize = fSize.Height;
                rbCheckSize = fSize.Height - 4F;
            }

            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.ClientRectangle.Height - rbBorderSize) / 2, //Center
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Center
                Y = (this.ClientRectangle.Height - rbCheckSize) / 2, //Center
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            switch (CheckAlign)
            {
                case ItemPositionZ.Left:
                    //Drawing
                    using (Pen penBorder = new Pen(CheckedColor, 1.6F))
                    using (SolidBrush brushRbCheck = new SolidBrush(CheckedColor))
                    using (SolidBrush brushText = new SolidBrush(this.ForeColor))
                    {
                        //Draw Radio Button
                        if (this.Checked)
                        {
                            pevent.Graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                            pevent.Graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
                        }
                        else
                        {
                            penBorder.Color = UnCheckedColor;
                            pevent.Graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
                        }
                        //Draw text
                        pevent.Graphics.DrawString(this.Text, this.Font, brushText, rbBorderSize + 3, (this.ClientRectangle.Height - fSize.Height) / 2);//Y=Center
                    }
                    break;
                default:
                    rectRbBorder = new RectangleF()
                    {
                        X = this.ClientRectangle.Width - rbBorderSize - 1.5f,
                        Y = (this.ClientRectangle.Height - rbBorderSize) / 2, //Center
                        Width = rbBorderSize,
                        Height = rbBorderSize
                    };
                    rectRbCheck = new RectangleF()
                    {
                        X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Center
                        Y = (this.ClientRectangle.Height - rbCheckSize) / 2, //Center
                        Width = rbCheckSize,
                        Height = rbCheckSize
                    };

                    //Drawing
                    using (Pen penBorder = new Pen(CheckedColor, 1.6F))
                    using (SolidBrush brushRbCheck = new SolidBrush(CheckedColor))
                    using (SolidBrush brushText = new SolidBrush(this.ForeColor))
                    {
                        //Draw Radio Button
                        if (this.Checked)
                        {
                            pevent.Graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                            pevent.Graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
                        }
                        else
                        {
                            penBorder.Color = UnCheckedColor;
                            pevent.Graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
                        }
                        //Draw text
                        pevent.Graphics.DrawString(this.Text, this.Font, brushText, 0, (this.Height - fSize.Height) / 2);//Y=Center
                    }
                    break;
            }
        }

        #endregion
    }
}

