using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    //[Designer(typeof(System.Windows.Forms.ComboBox))]
    [ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    [DefaultEvent("SelectedIndexChanged"), DefaultProperty("Items")]
    public class BaseComboBox : Control
    {
        public BaseComboBox()
        {
            cbx = new ComboBox();
            btnIcon = new Button();
            lbl = new Label();
            this.SuspendLayout();

            cbx.BackColor = BackColor;
            cbx.Font = this.Font;
            cbx.ForeColor = this.ForeColor;

            lbl.BackColor = BackColor;
            lbl.Font = this.Font;
            lbl.ForeColor = this.ForeColor;
            lbl.Size = new Size(0, 0);

            //cbx.DrawMode = DrawMode.OwnerDrawFixed;
            //cbx.DrawItem += Cbx_DrawItem;

            cbx.SelectedIndexChanged += Cbx_SelectedIndexChanged;
            cbx.SelectedValueChanged += Cbx_SelectedValueChanged;
            cbx.DataSourceChanged += Cbx_DataSourceChanged;
            cbx.DisplayMemberChanged += Cbx_DisplayMemberChanged;
            cbx.ValueMemberChanged += Cbx_ValueMemberChanged;
            cbx.DropDown += Cbx_DropDown;
            cbx.DropDownClosed += Cbx_DropDownClosed;
            cbx.SelectionChangeCommitted += Cbx_SelectionChangeCommitted;


            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = BackColor;
            btnIcon.Size = new Size(21, 17);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);//Open dropdown list
            btnIcon.LostFocus += BtnIcon_LostFocus;
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);//Draw icon
            this.Controls.Add(btnIcon);
            this.Controls.Add(cbx);
            this.Controls.Add(lbl);
            //this.Size = new Size(200, cbx.Font.Height);
            Reset();
            this.ResumeLayout();
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

        private Color selectColor = Color.Green;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectionColor
        {
            get { return selectColor; }
            set
            {
                selectColor = value;
                cbx.Invalidate();
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
                lbl.BackColor = value;
                btnIcon.BackColor = value;
                cbx.BackColor = value;
                cbx.Invalidate();
                this.Invalidate();
            }
        }

        private Color iconColor = Color.MediumSlateBlue;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();//Redraw icon
            }
        }

        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor
        {
            get { return cbx.ForeColor; }
            set
            {
                base.ForeColor = value;
                cbx.ForeColor = value;
                lbl.ForeColor = value;
                cbx.Invalidate();
            }
        }

        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                cbx.Font = value;
                lbl.Font = value;
                Reset();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Image BackgroundImage { get => cbx.BackgroundImage; set => cbx.BackgroundImage = value; }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override ImageLayout BackgroundImageLayout { get => cbx.BackgroundImageLayout; set => cbx.BackgroundImageLayout = value; }

        #endregion

        #region -> ComboBox Data Properties

        private ComboBox cbx;
        private Button btnIcon;
        private Label lbl;



        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart { get { return cbx.SelectionStart; } set { cbx.SelectionStart = value; } }

        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength { get { return cbx.SelectionLength; } set { cbx.SelectionLength = value; } }

        [DefaultValue(false), Category("Zer0ne")]
        public bool Sorted { get { return cbx.Sorted; } set { cbx.Sorted = value; } }

        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText { get { return cbx.SelectedText; } set { cbx.SelectedText = value; } }

        [DefaultValue(""), Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        public string FormatString { get { return cbx.FormatString; } set { cbx.FormatString = value; } }

        [DefaultValue(false)]
        public bool FormattingEnabled { get { return cbx.FormattingEnabled; } set { cbx.FormattingEnabled = value; } }

        //--


        [Category("Zer0ne")]
        public new string Text
        {
            get { return cbx.Text; }
            set { cbx.Text = value; }
        }


        [DefaultValue(8)]
        [Localizable(true), Category("Zer0ne")]
        public int MaxDropDownItems
        {
            get { return cbx.MaxDropDownItems; }
            set { cbx.MaxDropDownItems = value; }
        }

        [Category("Zer0ne"), Browsable(false)]
        public bool DroppedDown
        {
            get { return cbx.DroppedDown; }
            set
            {
                cbx.DroppedDown = value;
                if (cbx.DroppedDown == true)
                {
                    DropDown?.Invoke(this, new EventArgs());
                }
                else
                {
                    DropDownClosed?.Invoke(this, new EventArgs());
                }
            }
        }


        [DefaultValue(106), Category("Zer0ne"), Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int DropDownHeight
        {
            get { return cbx.DropDownHeight; }//erorr
            set { cbx.DropDownHeight = value; }
        }

        [Category("Zer0ne")]
        public int DropDownWidth
        {
            get { return cbx.DropDownWidth; }
            set { cbx.DropDownWidth = value; }
        }

        [DefaultValue(DrawMode.OwnerDrawFixed), Category("Zer0ne")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public DrawMode DrawMode
        {
            get { return cbx.DrawMode; }
            set
            {
                cbx.DrawMode = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public ComboBoxStyle DropDownStyle
        {
            get { return cbx.DropDownStyle; }
            set
            {
                if (cbx.DropDownStyle != ComboBoxStyle.Simple)
                {
                    cbx.DropDownStyle = value;
                }
            }
        }

        [Localizable(true), Category("Zer0ne")]
        public int ItemHeight
        {
            get { return cbx.ItemHeight; }
            set
            {
                cbx.ItemHeight = value;
                cbx.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false), Localizable(true)]
        public ComboBox.ObjectCollection Items
        {
            get { return cbx.Items; }
        }

        [Browsable(false), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(null), Category("Zer0ne")]
        public object SelectedValue
        {
            get => cbx.SelectedValue;
            set
            {
                cbx.SelectedValue = value;
                SelectedValueChanged?.Invoke(this, new EventArgs());
            }
        }

        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null), Category("Zer0ne")]
        public object DataSource
        {
            get { return cbx.DataSource; }
            set
            {
                cbx.DataSource = value;
                DataSourceChanged?.Invoke(this, new EventArgs());
            }
        }

        [Category("Zer0ne"), Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always), Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return cbx.AutoCompleteCustomSource; }
            set { cbx.AutoCompleteCustomSource = value; }
        }

        [Category("Zer0ne"), Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always), DefaultValue(AutoCompleteSource.None)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return cbx.AutoCompleteSource; }
            set { cbx.AutoCompleteSource = value; }
        }

        [Category("Zer0ne"), Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always), DefaultValue(AutoCompleteMode.None)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return cbx.AutoCompleteMode; }
            set { cbx.AutoCompleteMode = value; }
        }

        [Bindable(true), Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return cbx.SelectedItem; }
            set { cbx.SelectedItem = value; }
        }

        [Browsable(false), Category("Zer0ne")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return cbx.SelectedIndex; }
            set
            {
                if (cbx.Items.Count > 0)
                {
                    cbx.SelectedIndex = value;
                    SelectedIndexChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        [Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return cbx.DisplayMember; }
            set
            {
                cbx.DisplayMember = value;
                DisplayMemberChanged?.Invoke(this, new EventArgs());
            }
        }

        [Category("Zer0ne")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return cbx.ValueMember; }
            set
            {
                cbx.ValueMember = value;
                ValueMemberChanged?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region -> Event - override - methods

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectedValueChanged;
        public event EventHandler DataSourceChanged;
        public event EventHandler DisplayMemberChanged;
        public event EventHandler ValueMemberChanged;
        public event EventHandler DropDown;
        public event EventHandler DropDownClosed;
        public event EventHandler SelectionChangeCommitted;

        private void Cbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectionChangeCommitted?.Invoke(sender, e);
        }

        private void Cbx_DropDownClosed(object sender, EventArgs e)
        {
            DropDownClosed?.Invoke(sender, e);
        }
        private void Cbx_DropDown(object sender, EventArgs e)
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
        private void Cbx_DrawItem(object sender, DrawItemEventArgs e)
        {

            //ComboBox itm = sender as ComboBox;
            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            //{
            //    e.Graphics.FillRectangle(new SolidBrush(SelectionColor), e.Bounds);
            //}
            //else
            //{
            //    e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            //}

            //DataTable tbl;
            //DataView dv;
            //string val = "";
            //SizeF txSize;
            //if (itm.DataSource != null)
            //{

            //    //var ss = itm.DataSource.GetType();

            //    if (itm.DataSource is System.Collections.Generic.IList<Utilities.tsss.ValueAndID>)
            //    {

            //        List<Utilities.tsss.ValueAndID> l = new List<Utilities.tsss.ValueAndID>();
            //        l =  (List<Utilities.tsss.ValueAndID>)itm.DataSource;

            //        val = l[e.Index].Name;
            //    }
            //    else
            //    {
            //        tbl = (DataTable)itm.DataSource;
            //        dv = new DataView(tbl);

            //        if (tbl.Columns.Contains(this.DisplayMember))
            //        {
            //            val = dv[e.Index].Row.ItemArray[tbl.Columns[this.DisplayMember].Ordinal].ToString();
            //        }
            //    }


            //    txSize = e.Graphics.MeasureString(val, e.Font);
            //}
            //else
            //{
            //    txSize = e.Graphics.MeasureString(itm.Items[e.Index].ToString(), e.Font);
            //    val = itm.Items[e.Index].ToString();
            //}


            //PointF locTxt;
            //if (RightToLeft == RightToLeft.No)
            //{
            //    locTxt = new PointF(e.Bounds.X, e.Bounds.Y + ((e.Bounds.Height / 2) - txSize.Height / 2));
            //}
            //else
            //{
            //    locTxt = new PointF(e.Bounds.Width - txSize.Width, e.Bounds.Y);
            //}
            //e.Graphics.DrawString(val, this.Font, new SolidBrush(this.ForeColor), locTxt);
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectIcon = new Rectangle((btnIcon.Width - 14) / 2, (btnIcon.Height - 6) / 2, 14, 6);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(IconColor, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (14 / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (14 / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                e.Graphics.DrawPath(pen, path);
            }
        }
        private void Icon_Click(object sender, EventArgs e)
        {
            //Open dropdown list
            cbx.Select();
            cbx.DroppedDown = true;
        }
        private void BtnIcon_LostFocus(object sender, EventArgs e)
        {
            btnIcon.Cursor = Cursors.Default;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Reset();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Reset();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            cbx.Font = this.Font;
            Reset();
        }
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            if (this.RightToLeft == RightToLeft.Yes)
            {
                cbx.RightToLeft = RightToLeft.Yes;
                lbl.RightToLeft = RightToLeft.Yes;
                btnIcon.Dock = DockStyle.Left;
            }
            else
            {
                cbx.RightToLeft = RightToLeft.No;
                lbl.RightToLeft = RightToLeft.No;
                btnIcon.Dock = DockStyle.Right;
            }
            btnIcon.Invalidate();
            Reset();
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Reset();
        }

        private void Reset()
        {
            //bool r = false;
            //if (this.RightToLeft == RightToLeft.Yes) { r = true; }

            cbx.Width = this.Enabled ? this.Width + 3 : 0;
            cbx.Location = new Point((this.RightToLeft == RightToLeft.Yes) ? -1 : -3, -3);
            switch (this.DrawMode)
            {
                case DrawMode.Normal:
                    this.Height = cbx.Font.Height;
                    break;
                default:
                    this.Height = cbx.Font.Height - 1;
                    break;
            }
            btnIcon.Size = new Size(21, 17);

            if (this.Enabled == false)
            {
                lbl.BackColor = BackColor;
                lbl.Font = this.Font;
                lbl.ForeColor = this.ForeColor;
                lbl.Size = new Size(this.Width, this.Height);
                lbl.Location = new Point(0, 0);
                lbl.Text = (cbx.SelectedIndex <= -1) ? "" : cbx.Text;
            }
        }
        #endregion

    }
}


//-------------------------------------
//cbx.DataSource = this.DataSource;
//cbx.ValueMember = this.ValueMember;
//cbx.DisplayMember = this.DisplayMember;
//cbx.SelectedIndex = this.SelectedIndex;
//cbx.SelectedItem = this.SelectedItem;
//cbx.SelectedValue = this.SelectedValue;

//cbx.SelectedIndexChanged += ComboBox_SelectedIndexChanged;//Default event
//cbx.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
//cbx.SelectedValueChanged += Cbx_SelectedValueChanged;
//cbx.DropDownStyleChanged += ComboBox_DropDownStyleChanged;
//cbx.DataSourceChanged += Cbx_DataSourceChanged;
//cbx.ValueMemberChanged += Cbx_ValueMemberChanged;
//cbx.DisplayMemberChanged += Cbx_DisplayMemberChanged;
//cbx.DrawItem += Cbx_DrawItem;

//private void Cbx_DisplayMemberChanged(object sender, EventArgs e)
//{
//    DisplayMemberChanged?.Invoke(this, new EventArgs());
//}

//private void Cbx_ValueMemberChanged(object sender, EventArgs e)
//{
//    ValueMemberChanged?.Invoke(this, new EventArgs());
//}

//private void Cbx_DataSourceChanged(object sender, EventArgs e)
//{
//    DataSourceChanged?.Invoke(this, new EventArgs());
//}

//private void Cbx_SelectedValueChanged(object sender, EventArgs e)
//{
//    SelectedValueChanged?.Invoke(this, new EventArgs());
//}
//private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
//{
//    SelectedIndexChanged?.Invoke(this, new EventArgs());
//}
//private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
//{
//    SelectionChangeCommitted?.Invoke(this, new EventArgs());
//}
//private void ComboBox_DropDownStyleChanged(object sender, EventArgs e)
//{
//    DropDownStyleChanged?.Invoke(this, new EventArgs());
//}