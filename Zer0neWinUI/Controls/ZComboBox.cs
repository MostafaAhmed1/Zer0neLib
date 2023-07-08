using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    [DefaultEvent("SelectedIndexChanged"),DefaultProperty("Items")]
    public class ZComboBox : ZControl, IControlZ
    {
        #region -> Constructor - EventHandler 
        
        public ZComboBox() : base(new BaseComboBox())
        {
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

            ctrl = (BaseComboBox)base.ChildControl;
            ctrl.BackColor = base.BackColor;
            ctrl.SelectionColor =this.SelectionColor;
            ctrl.IconColor = this.ArrowColor;
            ctrl.ForeColor = base.ForeColor;

            ctrl.SelectedIndexChanged += Cbx_SelectedIndexChanged;
            ctrl.SelectedValueChanged += Cbx_SelectedValueChanged;
            ctrl.DataSourceChanged += Cbx_DataSourceChanged;
            ctrl.DisplayMemberChanged += Cbx_DisplayMemberChanged;
            ctrl.ValueMemberChanged += Cbx_ValueMemberChanged;
            ctrl.DropDown += Ctrl_DropDown;
            ctrl.DropDownClosed += Ctrl_DropDownClosed;
            ctrl.SelectionChangeCommitted += Ctrl_SelectionChangeCommitted;  
        }
        #endregion

        #region Properties
        private BaseComboBox ctrl;

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
        public new string Text
        {
            get
            {
                return ctrl.Text;
            }

            set
            {
                ctrl.Text = value;
            }
        }

        [Category("Zer0ne")]
        public new bool Enabled
        {
            get
            {
                //ctrl.IconColor = ctrl.Enabled ? base.z.ActiveColor : base.ZStyle.InactiveColor;
                return ctrl.Enabled;
            }
            set
            {
                ctrl.Enabled = value;
                ctrl.IconColor = value ? base.ZStyle.ActiveColor : base.ZStyle.InactiveColor;
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                ZStyle.BackColor = value;
                base.BackColor = ZStyle.BackColor;
                ctrl.BackColor = ZStyle.BackColor;
                ctrl.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ArrowColor
        {
            get { return ZStyle.GradientColor1; }
            set
            {
                ZStyle.GradientColor1 = value;
                ctrl.IconColor = ZStyle.GradientColor1;
                ctrl.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectionColor
        {
            get { return ZStyle.ActiveColor; }
            set
            {
                ZStyle.ActiveColor = value;
                ctrl.SelectionColor = ZStyle.ActiveColor;
                ctrl.Invalidate();
            }
        }
         
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly{get => false; set => value = false;}

        #endregion

        #region Events Methods

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectedValueChanged;
        public event EventHandler DataSourceChanged;
        public event EventHandler DisplayMemberChanged;
        public event EventHandler ValueMemberChanged;
        public event EventHandler DropDown;
        public event EventHandler DropDownClosed;
        public event EventHandler SelectionChangeCommitted;

        private void Ctrl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectionChangeCommitted?.Invoke(sender, e);
        }
        private void Ctrl_DropDownClosed(object sender, EventArgs e)
        {
            DropDownClosed?.Invoke(sender, e);
        }
        private void Ctrl_DropDown(object sender, EventArgs e)
        {
            DropDown?.Invoke(sender, e);
        }
        private void Cbx_ValueMemberChanged(object sender, EventArgs e)
        {
            ValueMemberChanged?.Invoke(sender, e);
        }

        private void Cbx_DisplayMemberChanged(object sender, EventArgs e)
        {
            DisplayMemberChanged?.Invoke(sender, e);
        }

        private void Cbx_DataSourceChanged(object sender, EventArgs e)
        {
            DataSourceChanged?.Invoke(sender, e);
        }

        private void Cbx_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectedValueChanged?.Invoke(sender, e);
        }

        private void Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(sender, e);
        }

        #endregion

        #region -> Data properties


        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart { get { return ctrl.SelectionStart; } set { ctrl.SelectionStart = value; } }

        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength { get { return ctrl.SelectionLength; } set { ctrl.SelectionLength = value; } }

        [DefaultValue(false), Category("Zer0ne")]
        public bool Sorted { get { return ctrl.Sorted; } set { ctrl.Sorted = value; } }

        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText { get { return ctrl.SelectedText; } set { ctrl.SelectedText = value; } }

        [DefaultValue(""), Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        public string FormatString { get { return ctrl.FormatString; } set { ctrl.FormatString = value; } }

        [DefaultValue(false)]
        public bool FormattingEnabled { get { return ctrl.FormattingEnabled; } set { ctrl.FormattingEnabled = value; } }

        //--



        [Browsable(false), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(null), Category("Zer0ne")]
        public object SelectedValue 
        {
            get => ctrl.SelectedValue;
            set
            {
                ctrl .SelectedValue = value;
                SelectedValueChanged?.Invoke(this, new EventArgs());
            }
        }

        [DefaultValue(8)]
        [Localizable(true), Category("Zer0ne")]
        public int MaxDropDownItems
        {
            get { return ctrl.MaxDropDownItems; }
            set { ctrl.MaxDropDownItems = value; }
        }

        [Category("Zer0ne")]
        public bool DroppedDown
        {
            get { return ctrl.DroppedDown; }
            set
            {
                ctrl.DroppedDown = value;
                if (ctrl.DroppedDown == true)
                {
                    DropDown?.Invoke(this, new EventArgs());
                }
                else
                {
                    DropDownClosed?.Invoke(this, new EventArgs());
                }
            }
        }
        
        [Browsable(true ) , DefaultValue(106), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public int DropDownHeight
        {
            get { return ctrl.DropDownHeight; }
            set
            {
                ctrl.DropDownHeight = value;
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DropDownWidth
        {
            get { return ctrl.DropDownWidth; }
            set
            {
                ctrl.DropDownWidth = value;
            }
        }

        [DefaultValue(DrawMode.OwnerDrawFixed), Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public DrawMode DrawMode
        {
            get { return ctrl.DrawMode; }
            set
            {
                ctrl.DrawMode = value;
            }
        }

        [Category("Zer0ne")]
        public ComboBoxStyle DropDownStyle
        {
            get { return ctrl.DropDownStyle; }
            set
            {
                if (ctrl.DropDownStyle != ComboBoxStyle.Simple)
                {
                    ctrl.DropDownStyle = value;
                }
            }
        }

        [Localizable(true), Category("Zer0ne")]
        public int ItemHeight
        {
            get { return ctrl.ItemHeight; }
            set
            {
                ctrl.ItemHeight = value;
            }
        }

        [Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return ctrl.Items; }
        }

        [Category("Zer0ne")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get { return ctrl.DataSource; }
            set 
            { 
                ctrl.DataSource = value;
                DataSourceChanged?.Invoke(this, new EventArgs());
            }
        }

        [Category("Zer0ne")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return ctrl.AutoCompleteCustomSource; }
            set { ctrl.AutoCompleteCustomSource = value; }
        }

        [Category("Zer0ne")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return ctrl.AutoCompleteSource; }
            set { ctrl.AutoCompleteSource = value; }
        }

        [Category("Zer0ne")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return ctrl.AutoCompleteMode; }
            set { ctrl.AutoCompleteMode = value; }
        }

        [Category("Zer0ne")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return ctrl.SelectedItem; }
            set { ctrl.SelectedItem = value; }
        }

        [Category("Zer0ne")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return ctrl.SelectedIndex; }
            set 
            { 
                ctrl.SelectedIndex = value;
                SelectedIndexChanged?.Invoke(this, new EventArgs());
            }
        }

        [Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return ctrl.DisplayMember; }
            set 
            { 
                ctrl.DisplayMember = value;
                DisplayMemberChanged?.Invoke(this, new EventArgs());
            }
        }

        [Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return ctrl.ValueMember; }
            set 
            { 
                ctrl.ValueMember = value;
                ValueMemberChanged?.Invoke(this, new EventArgs());
            }
        }

        
        #endregion

    }
}