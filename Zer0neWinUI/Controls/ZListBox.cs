using System.Drawing;
using System.Windows.Forms; 
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System;

namespace Zer0ne.WinUI.Controls
{
    public class ZListBox : ListBox
    {
        public ZListBox()
        { 
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.FormattingEnabled = true;
            this.IntegralHeight = false;
            this.ItemHeight = 35;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(200, 300);

            ZStyle = new ZControlStyle()
            {
                Radius = 8,
                BorderSize = 1,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.HintColor,
                GradientColor2 = ZTheme.HintColor,
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
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            Graphics g = e.Graphics;
            
            ListBox lb = this;
            if (lb.Items.Count == 0)
            {
                return;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                g.FillRectangle(new SolidBrush(ZTheme.SelectColor), e.Bounds);
            }
            else
            {
                if (e.Index % 2 == 0)
                {
                    g.FillRectangle(new SolidBrush(ZTheme.SecondaryColor), e.Bounds);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(ZTheme.ThirdColor), e.Bounds);
                }
            }
            //g.DrawLine(new Pen(ZStyle.HintColor, 1), new Point(e.Bounds.X + (e.Bounds.Width / 9), e.Bounds.Y + (e.Bounds.Height - 1)), new Point(e.Bounds.Width - (e.Bounds.Width / 9), e.Bounds.Y + (e.Bounds.Height - 1)));

            // draw the text of the list item, Not doing this will only show the background color
            // you will need to get the text of item to display
            string txt = lb.GetItemText(lb.Items[e.Index]);
            var txSize = g.MeasureString(txt, e.Font);
            PointF locTxt;
            if (RightToLeft == RightToLeft.No)
            {
                locTxt = new PointF(e.Bounds.X, e.Bounds.Y + ((e.Bounds.Height / 2) - txSize.Height /2));
            }
            else
            {
                locTxt = new PointF(e.Bounds.Width - txSize.Width, e.Bounds.Y);
            }
            g.DrawString(txt, e.Font, new SolidBrush(ZTheme.TextColor), locTxt);

            //e.DrawFocusRectangle();
        }
    }
}
