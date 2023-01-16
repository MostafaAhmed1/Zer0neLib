using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.NumericUpDown))]
    public class BaseNumeric : NumericUpDown
    {
        public BaseNumeric() : base()
        {
            var renderer = new UpDownButtonRenderer(Controls[0]);
            TextAlign = HorizontalAlignment.Center;
            this.BorderStyle = BorderStyle.None;
            this.Maximum = 999999999;
            this.Minimum = 0;
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

        private Color borderColor = Color.Black;
        [Category("Zer0ne")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    Invalidate();
                }
            }
        }

        private Color arrowFocus = Color.White;
        [Category("Zer0ne")]
        public Color ArrowFocus
        {
            get
            {
                return arrowFocus;
            }
            set
            {
                if (arrowFocus != value)
                {
                    arrowFocus = value;
                    Invalidate();
                }
            }
        }

        private Color arrowColor = Color.Blue;
        [Category("Zer0ne")]
        public Color ArrowColor
        {
            get
            {
                return arrowColor;
            }
            set
            {
                if (arrowColor != value)
                {
                    arrowColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Zer0ne")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Browsable(true), Category("Zer0ne")]
        public override string Text { get => base.Text; set => base.Text = value; }

        private string unit = "";
        [Category("Zer0ne")]
        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                UpdateEditText();
            }

        }

        private bool showUnit = true;
        [Category("Zer0ne")]
        public bool ShowUnit
        {
            get => showUnit;
            set
            {
                showUnit = value;
                UpdateEditText();
            }
        }
        
        private bool unitInRight = true;
        [Category("Zer0ne")]
        public bool UnitInRight
        {
            get => unitInRight;
            set
            {
                unitInRight = value;
                UpdateEditText();
            }
        }
        #endregion

        #region => overrides
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BorderStyle != BorderStyle.None)
            {
                using (var pen = new Pen(BorderColor, 1))
                {
                    e.Graphics.DrawRectangle(pen, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                }
            }
            else if (BorderStyle == BorderStyle.None)
            {
                using (var pen = new Pen(BackColor, 0))
                {
                    e.Graphics.DrawRectangle(pen, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                }
            }
        }

        protected override void UpdateEditText()
        {
            if (ShowUnit == true && Unit != string.Empty)
            {
                this.Text = UnitInRight ? this.Value + Unit : Unit + this.Value;
            }
            else
            {
                this.Text = this.Value.ToString();
            }
            this.Invalidate();
        }

        #endregion

        #region => C++ Paint Class
        private class UpDownButtonRenderer : NativeWindow
        {
            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
            private static extern IntPtr IntBeginPaint(IntPtr hWnd, [In, Out] ref PAINTSTRUCT lpPaint);
            [StructLayout(LayoutKind.Sequential)]
            public struct PAINTSTRUCT
            {
                public IntPtr hdc;
                public bool fErase;
                public int rcPaint_left;
                public int rcPaint_top;
                public int rcPaint_right;
                public int rcPaint_bottom;
                public bool fRestore;
                public bool fIncUpdate;
                public int reserved1;
                public int reserved2;
                public int reserved3;
                public int reserved4;
                public int reserved5;
                public int reserved6;
                public int reserved7;
                public int reserved8;
            }
            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
            private static extern bool IntEndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

            Control ctrl;
            //Control updown;
            public UpDownButtonRenderer(Control c)
            {
                this.ctrl = c;
                if (ctrl.IsHandleCreated)
                {
                    this.AssignHandle(ctrl.Handle);
                }
                else
                {
                    ctrl.HandleCreated += (s, e) => this.AssignHandle(ctrl.Handle);
                }
            }
            private Point[] GetDownArrow(Rectangle r)
            {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new Point[]
                {
                new Point(middle.X - 3, middle.Y - 2),
                new Point(middle.X + 4, middle.Y - 2),
                new Point(middle.X, middle.Y + 2)
                };
            }
            private Point[] GetUpArrow(Rectangle r)
            {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new Point[]
                {
                new Point(middle.X - 4, middle.Y + 2),
                new Point(middle.X + 4, middle.Y + 2),
                new Point(middle.X, middle.Y - 3)
                };
            }
            protected override void WndProc(ref Message m)
            {
                //if (m.Msg == 0xF /*WM_PAINT*/ && ((ZNumeric)updown.Parent).BorderStyle != BorderStyle.None)
                if (m.Msg == 0xF)
                {
                    var s = new PAINTSTRUCT();
                    IntBeginPaint(ctrl.Handle, ref s);
                    using (var g = Graphics.FromHdc(s.hdc))
                    {
                        using (var backBrush = new SolidBrush(ctrl.Enabled ? ((BaseNumeric)ctrl.Parent).BackColor : SystemColors.Control))
                        {
                            g.FillRectangle(backBrush, ctrl.ClientRectangle);
                        }
                        var r1 = new Rectangle(0, 0, ctrl.Width, ctrl.Height / 2);
                        var r2 = new Rectangle(0, ctrl.Height / 2, ctrl.Width, ctrl.Height / 2 + 1);
                        var p = ctrl.PointToClient(MousePosition);
                        if (ctrl.Enabled && ctrl.ClientRectangle.Contains(p))
                        {
                            using (var f = new SolidBrush((((BaseNumeric)ctrl.Parent).ReadOnly) ? ((BaseNumeric)ctrl.Parent).BackColor : ((BaseNumeric)ctrl.Parent).ArrowFocus))
                            {
                                if (r1.Contains(p))
                                {
                                    g.FillRectangle(f, r1);
                                }
                                else
                                {
                                    g.FillRectangle(f, r2);
                                }
                            }

                            //using (var pen = new Pen(((BaseNumeric)updown.Parent).BorderColor))
                            //{
                            //    //g.DrawLines(pen,
                            //    //    new[] { new Point(0, 0), new Point(0, updown.Height),
                            //    //        new Point(0, updown.Height / 2), new Point(updown.Width, updown.Height / 2)
                            //    //    });
                            //}
                        }
                        else if (ctrl.Enabled == false )
                        {
                            using (var f = new SolidBrush((((BaseNumeric)ctrl.Parent).ReadOnly) ? ((BaseNumeric)ctrl.Parent).BackColor : ((BaseNumeric)ctrl.Parent).BackColor))
                            {
                                g.FillRectangle(f, r1);
                                g.FillRectangle(f, r2);
                            }
                        }

                        using (var b = new SolidBrush((((BaseNumeric)ctrl.Parent).ReadOnly || !((BaseNumeric)ctrl.Parent).Enabled) ? ((BaseNumeric)ctrl.Parent).BackColor : ((BaseNumeric)ctrl.Parent).ArrowColor))
                        {
                            g.FillPolygon(b, GetUpArrow(r1));
                            g.FillPolygon(b, GetDownArrow(r2));

                        }

                    }
                    m.Result = (IntPtr)1;
                    base.WndProc(ref m);
                    IntEndPaint(ctrl.Handle, ref s);
                }
                else if (m.Msg == 0x0014/*WM_ERASEBKGND*/)
                {
                    using (var g = Graphics.FromHdcInternal(m.WParam))
                        g.FillRectangle(Brushes.White, ctrl.ClientRectangle);
                    m.Result = (IntPtr)1;
                }
                else
                    base.WndProc(ref m);
            }
        }
        #endregion
    }
}