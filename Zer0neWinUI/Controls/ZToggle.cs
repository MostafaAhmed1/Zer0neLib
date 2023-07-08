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

namespace Zer0ne.WinUI.Controls
{
    [DefaultProperty("Value"), DefaultEvent("ValueChanged")]
    public class ZToggle : CheckBox
    {
        //Constructor
        public ZToggle()
        {
            this.MinimumSize = new Size(100, 20);
            //this.AutoSize = false;

            base.Font = ZTheme.Fontz;
            ZStyle = new ZControlStyle()
            {
                Radius = 8,
                BorderSize = 2,
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

        #region Properties
        
        Font fnt = ZTheme.Fontz;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
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

        private bool val = false;
        [Category("Zer0ne")]
        public bool Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
                this.Invalidate();
                ValueChanged?.Invoke(this, value);
            }
        }


        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OnBackColor
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
        public Color OnToggleColor
        {
            get
            {
                return ZStyle.ActiveColor;
            }

            set
            {
                ZStyle.ActiveColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OffBackColor
        {
            get
            {
                return ZStyle.HintColor;
            }

            set
            {
                ZStyle.HintColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OffToggleColor
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

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get
            {
                return ZStyle.TextColor ;
            }

            set
            {
                ZStyle.TextColor = value;
                this.Invalidate();
            }
        }

        private string ONText = "نعم";
        [Category("Zer0ne")]
        public  string OnText
        {
            get
            {
                return ONText;
            }
            set
            {
                ONText = value;
                Invalidate();
            }
        }

        private string OFFText = "لا";
        [Category("Zer0ne")]
        public string OffText
        {
            get
            {
                return OFFText;
            }
            set
            {
                OFFText = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text { get => base.Text; set => base.Text = value; }

        private bool solidStyle = true;
        [DefaultValue(true), Category("Zer0ne")]
        public bool SolidStyle
        {
            get
            {
                return solidStyle;
            }

            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Events override Methods

        public event EventHandler<bool> ValueChanged;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(Parent.BackColor);
            
            if (this.Value) //ON
            {
                //Draw the control surface
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(OnBackColor, 2), GetFigurePath());
                }
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                
                pevent.Graphics.DrawString(this.OnText, this.Font, new SolidBrush(this.ForeColor), 10,  (this.ClientRectangle.Height /2)- (this.Font.Height / 2)-3);
            }
            else //OFF
            {
                //Draw the control surface
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(OffBackColor, 2), GetFigurePath());
                }
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
                pevent.Graphics.DrawString(this.OffText, this.Font, new SolidBrush(this.ForeColor), (this.Width - (pevent.Graphics.MeasureString(this.OffText,this.Font).Width)-5), (this.ClientRectangle.Height / 2) - (this.Font.Height / 2) );
            }
        }
        
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (Value == true)
            {
                Value = false;
            }
            else
            {
                Value = true;
            }
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        void Recolor()
        {
            base.ForeColor = ZStyle.TextColor;
        }

        #endregion

    }
}