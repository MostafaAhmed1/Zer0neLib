using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Zer0ne.WinUI;
using Zer0ne.WinUI.Utilities;
using System.Drawing;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
    [DefaultEvent("TextChanged")]
    public class ZTextBox : ZControl, IControlZ
    {

        public ZTextBox() : base(new TextBox())
        {
            ctrl = (TextBox)base.ChildControl;
            ctrl.BorderStyle = BorderStyle.None;
            ctrl.TextChanged += Ctrl_TextChanged;
            ctrl.KeyPress += Ctrl_KeyPress;
            ctrl.KeyDown += Ctrl_KeyDown;
            ctrl.GotFocus += Ctrl_GotFocus;
            ctrl.LostFocus += Ctrl_LostFocus;
            Cursor = Cursors.IBeam;
        }

        #region Propereties

        private TextBox ctrl;

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

        [Category("Zer0ne")]
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return ctrl.TextAlign;
            }
            set
            {
                ctrl.TextAlign = value;
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Zer0ne")]
        public bool ReadOnly
        {
            get
            {
                return ctrl.ReadOnly;
            }
            set
            {
                ctrl.ReadOnly = value;
                this.Invalidate();
                base.Invalidate();
            }

        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public char PasswordChar
        {
            get => ctrl.PasswordChar;
            set => ctrl.PasswordChar = value;
        }

        [DefaultValue(false), Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool UseSystemPasswordChar
        {
            get => ctrl.UseSystemPasswordChar;
            set => ctrl.UseSystemPasswordChar = value;
        }

        [Category("Zer0ne")]
        [DefaultValue(false)]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MultiLine
        {
            get => ctrl.Multiline;
            set
            {
                ctrl.Multiline = value;
                base.MultiLines = ctrl.Multiline;
                base.Reset();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue(true)]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool WordWrap
        {
            get => ctrl.WordWrap;
            set => ctrl.WordWrap = value;
        }

        [Category("Zer0ne")]
        public ScrollBars ScrollBars
        {
            get => ctrl.ScrollBars;
            set
            {
                ctrl.ScrollBars = value;
                this.Invalidate();
            }
        }

        private TxtDataType dType = TxtDataType.Strings;
        [Category("Zer0ne")]
        public TxtDataType ValueType
        {
            get { return dType; }
            set
            {
                dType = value;
                this.Invalidate();
            }
        }

        #endregion

        #region event  override voids

        public new event EventHandler TextChanged;
        public new event KeyPressEventHandler KeyPress;
        public new event KeyEventHandler KeyDown;
        public new event EventHandler GotFocus;
        public new event EventHandler LostFocus;

        private void Ctrl_LostFocus(object sender, EventArgs e)
        {
            LostFocus?.Invoke(this, new EventArgs());
        }
        private void Ctrl_GotFocus(object sender, EventArgs e)
        {
            GotFocus?.Invoke(this, new EventArgs());
        }
        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(this, new KeyEventArgs(e.KeyData));
        }
        private void Ctrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (ValueType)
            {
                case TxtDataType.Phone:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                //case TxtDataType.Double:
                //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                //    {
                //        e.Handled = true;
                //    }
                //    if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
                //    {
                //        e.Handled = true;
                //    }
                //    break;
                default:
                    break;
            }
            
            KeyPress?.Invoke(this, new KeyPressEventArgs(e.KeyChar));
        }

        private void Ctrl_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, new EventArgs());
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            SelectAll();
        }

        public void Cut()
        {
            this.ctrl.Cut();
        }

        public void Copy()
        {
            this.ctrl.Copy();
        }

        public void Paste()
        {
            this.ctrl.Paste();
        }

        public void Clear()
        {
            this.ctrl.Clear();
        }

        public void ClearUndo()
        {
            this.ctrl.ClearUndo();
        }

        public void SelectAll()
        {
            this.ctrl.SelectAll();
        }

        public void Select(int start, int length)
        {
            this.ctrl.Select(start, length);
        }
        #endregion

    }
}
