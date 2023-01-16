using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Zer0ne.WinUI;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    [DefaultEvent("ValueChanged")]
    public class ZNumeric : ZControl, IControlZ
    {
        
        private BaseNumeric ctrl;
        public ZNumeric() : base(new BaseNumeric())
        {
            ctrl = (BaseNumeric)base.ChildControl;
            ctrl.Size = new Size(100, 50);
            ctrl.Value = this.Value;
            ctrl.Maximum = this.Maximum;
            ctrl.Minimum = this.Minimum;
            ctrl.TextAlign = this.TextAlignment;
            ctrl.ShowUnit = this.ShowUnit;
            ctrl.Unit = this.Unit;
            ctrl.DecimalPlaces = this.DecimalPlaces;
            ctrl.Increment = this.Increment;
            ctrl.ArrowFocus = this.ArrowFocus;
            ctrl.ArrowColor = this.ArrowColor;
            ctrl.BorderColor = base.BackColor;
            ctrl.BackColor = base.BackColor;
            ctrl.Enabled = base.Enabled;
            ctrl.ValueChanged += ctrl_ValueChanged;
            ctrl.KeyDown += Ctrl_KeyDown;
            ctrl.KeyPress += Ctrl_KeyPress;
        }


        #region Properties

        //[Category("Zer0ne")]
        //public new bool Enabled
        //{
        //    get { return ctrl.Enabled; }
        //    set { ctrl.Enabled = value; }
        //}

        [Category("Zer0ne")]
        public string ErrorText
        {
            get
            {
                return ctrl.ErrorText;
            }
            set
            {
                ctrl.ErrorText = value;
            }
        }

        [Category("Zer0ne")]
        [Bindable(true)]
        public decimal Value
        {
            get { return ctrl.Value; }
            set { ctrl.Value = value; }
        }

        [Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.All)]
        public decimal Maximum
        {
            get { return ctrl.Maximum; }
            set { ctrl.Maximum = value; }

        }

        [Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.All)]
        public decimal Minimum
        {
            get { return ctrl.Minimum; }
            set { ctrl.Minimum = value; }

        }

        [Category("Zer0ne")]
        public int DecimalPlaces
        {
            get { return ctrl.DecimalPlaces; }
            set { ctrl.DecimalPlaces = value; }

        }

        [Category("Zer0ne")]
        public decimal Increment
        {
            get { return ctrl.Increment; }
            set { ctrl.Increment = value; }

        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                ctrl.BackColor = base.BackColor;
                ctrl.BorderColor = base.BackColor;
                ctrl.Invalidate();
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ArrowColor
        {
            get { return base.ZStyle.ActiveColor; }
            set
            {
                base.ZStyle.ActiveColor = value;
                ctrl.ArrowColor = base.ZStyle.ActiveColor;
                ctrl.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ArrowFocus
        {
            get
            {
                return base.ZStyle.InactiveColor;
            }
            set
            {
                base.ZStyle.InactiveColor = value;
                ctrl.ArrowFocus = base.ZStyle.InactiveColor;
                ctrl.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get => ctrl.Text;
            set
            {
                ctrl.Text = value;
                Invalidate();
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
        public bool ReadOnly
        {
            get
            {
                return this.ctrl.ReadOnly;
            }
            set
            {
                this.ctrl.ReadOnly = value;
                this.Invalidate();
            }

        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
        public bool ShowUnit
        {
            get => ctrl.ShowUnit;
            set
            {
                ctrl.ShowUnit = value;
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Unit
        {
            get => ctrl.Unit;
            set
            {
                ctrl.Unit = value;
            }
        }

        #endregion

        #region Events Methods

        public event EventHandler ValueChanged;
        public new event KeyPressEventHandler KeyPress;
        public new event KeyEventHandler KeyDown;
        private void Ctrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPress?.Invoke(this, new KeyPressEventArgs(e.KeyChar ));
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(this, new KeyEventArgs(e.KeyData));
        }

        
        private void ctrl_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, new EventArgs());
        }
        #endregion

    }
}