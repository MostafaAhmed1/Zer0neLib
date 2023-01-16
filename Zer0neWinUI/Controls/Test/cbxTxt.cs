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
     class cbxTxt : ComboBox 
    {

        public cbxTxt()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.FlatStyle = FlatStyle.Flat;

            //this.DrawMode = DrawMode.OwnerDrawVariable;
            //this.DrawItem += CbxTxt_DrawItem;

        }
         
        #region -> Properties

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

        private Color arrowColor = Color.MediumSlateBlue;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                arrowColor = value;
                this.Invalidate();
            }
        }

        private Color selectColor = Color.Green;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectionColor
        {
            get { return selectColor; }
            set
            {
                selectColor = value;
                this.Invalidate();
            }
        }

        private Color backColor = Color.WhiteSmoke;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color BackColor
        {
            get
            {
                base.BackColor = backColor;
                return backColor;
            }
            set
            {
                backColor = value;
                base.BackColor = backColor;
                this.Invalidate();
            }
        }

        #endregion


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case 0xf:

                    Rectangle rect;
                    using (Graphics g = this.CreateGraphics())
                    using (GraphicsPath pth = new GraphicsPath())
                    using (Pen p = new Pen(ArrowColor))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        rect = new Rectangle(0, 0, Width, Height);
                        ControlPaint.DrawBorder(g, rect, this.BackColor, ButtonBorderStyle.Solid);
                        //if (!this.Enabled)
                        //{
                        //    Bitmap b = new Bitmap(rect.Width, rect.Height, g);
                        //    g.DrawImage(b, rect);

                        //    //ControlPaint.DrawImageDisabled(g, b, 0, 0, Color.Red);

                        //}

                        PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                        PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                        PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);



                        if (this.RightToLeft == RightToLeft.No)
                        {
                            rect = new Rectangle(this.Width - 19, 0, 18, this.Height);
                            TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                            TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                            Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                        }
                        else
                        {
                            rect = new Rectangle(0, 0, 19, this.Height);
                            TopLeft = new PointF(ClientRectangle.X +13, (this.Height - 5) / 2);
                            TopRight = new PointF(ClientRectangle.X + 5, (this.Height - 5) / 2);
                            Bottom = new PointF(ClientRectangle.X + 9, (this.Height + 2) / 2);
                        }

                        g.FillRectangle(new SolidBrush(BackColor), rect);

                        pth.AddLine(TopLeft, TopRight);
                        pth.AddLine(TopRight, Bottom);


                        g.FillPath(new SolidBrush(ArrowColor), pth);

                    }

                    //g.Dispose();

                    break;
            }
        }

        
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            base.Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            base.Invalidate();
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            base.Invalidate();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            base.Invalidate();
        }

        protected override void OnMouseHover(System.EventArgs e)
        {
            base.OnMouseHover(e);
            base.Invalidate();
        }
        


        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }

        
    }
}
