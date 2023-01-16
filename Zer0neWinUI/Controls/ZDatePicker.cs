using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DateTimePicker))]
    [DefaultEvent("ValueChanged"), DefaultProperty("Value")]
    public class ZDatePicker : ZControl, IControlZ
    {
        public ZDatePicker() : base(new DatePickerEx())
        {
            ctrl = (DatePickerEx)base.ChildControl;
            ctrl.Font = base.Font;
            ctrl.BackColor = base.BackColor;
            ctrl.ForeColor = this.ForeColor;
            ctrl.ValueChanged += Ctrl_ValueChanged;
        }

        #region Data Properties

        [RefreshProperties(RefreshProperties.Repaint), Category("Zer0ne")]
        public DateTimePickerFormat Format
        {
            get { return ctrl.Format; }
            set { ctrl.Format = value; }
        }

        [DefaultValue(null), Category("Zer0ne")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string CustomFormat
        {
            get { return ctrl.CustomFormat; }
            set { ctrl.CustomFormat = value; }
        }

        [Bindable(true), Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.All)]
        public DateTime Value
        {
            get { return ctrl.Value; }
            set
            {
                ctrl.Value = value;
                this.ValueChanged?.Invoke(this, new EventArgs());
            }

        }

        [Category("Zer0ne")]
        public DateTime MaxDate
        {
            get { return ctrl.MaxDate; }
            set { ctrl.MaxDate = value; }
        }

        [Category("Zer0ne")]
        public DateTime MinDate
        {
            get { return ctrl.MinDate; }
            set { ctrl.MinDate = value; }
        }

        #endregion

        public event EventHandler ValueChanged;
       
        private void Ctrl_ValueChanged(object sender, EventArgs e)
        {
            this.ValueChanged?.Invoke(this, new EventArgs());
        }

        #region Propreties

        DatePickerEx ctrl;

        private string eText = string.Empty;
        [Browsable(true), Category("Zer0ne")]
        public string ErrorText
        {
            get
            {
                return eText;
            }

            set
            {
                eText = value;
            }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public bool ReadOnly
        {
            get
            {
                return false;
            }

            set
            {
                value = false;
            }
        }

      
        #endregion
    }
}
