using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    public abstract class ZControl : Control
    {
        List<AdditionalItems> Items;

       internal bool MultiLines = false;

        Control ctrl;
        [Category("Zer0ne")]
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Control ChildControl
        {
            get
            {
                return ctrl;
            }
        }

        private Label plc;
        public ZControl(Control control)
        {            
            ctrl = control;
            ctrl.Size = new Size(100, 50);
            this.Controls.Add(ctrl);

            plc = new Label();
            plc.Text = this.Name + " Titel";
            plc.Font = new Font("Tahoma", 12);
            plc.BorderStyle = BorderStyle.None;
            plc.Size = new Size(100, plc.Font.Height);
            this.Controls.Add(plc);

            base.Font = ZTheme.Fontz;
            Size = new Size(200, 75);
            TabStop = true;
            Reset();

            ZStyle = new ZControlStyle()
            {
                Radius = 8,
                BorderSize = 2,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.ControlStyle.InactiveColor,
                GradientColor2 = ZTheme.ControlStyle.InactiveColor,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.BacgroundColor
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();

            plc.Click += Plc_MouseEnter;
            plc.GotFocus += Plc_MouseEnter;
            plc.DoubleClick += Plc_DoubleClick;
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;

            ctrl.BackColor = ZStyle.BackColor;
            ctrl.ForeColor = ZStyle.TextColor;
            plc.BackColor = ZStyle.BackColor;
            plc.ForeColor = ZStyle.TextColor;
        }

        public void AddItem(ItemPositionZ position, Image image, EventHandler action , bool showBorder = true)
        {
            Items.Add(new AdditionalItems { Position = position, Icon = image, Actionz = action , ShowBorder = showBorder });
            Reset();
        }

        public void ClearItems()
        {
            Items.Clear();
        }

        #region Properties

        //Properties
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
                Reset();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                ctrl.BackColor = ZStyle.BackColor;
                plc.BackColor = ZStyle.BackColor;
                return ZStyle.BackColor;
            }
            set
            {
                ZStyle.BackColor = value;
                ctrl.BackColor = ZStyle.BackColor;
                plc.BackColor = ZStyle.BackColor;
                base.BackColor = ZStyle.BackColor;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
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
                ctrl.ForeColor = ZStyle.TextColor;
                base.ForeColor = ZStyle.TextColor;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TitleForeColor
        {
            get
            {
                return ZStyle.TextColor;
            }
            set
            {
                ZStyle.TextColor = value;
                plc.ForeColor = ZStyle.TextColor;
                this.Invalidate();
            }
        }

        private CornerZ _roundedRectangleEdges = CornerZ.All;
        [Category("Zer0ne")]
        [Editor(typeof(FlagEnumUIEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public CornerZ RoundedCorners
        {
            get { return _roundedRectangleEdges; }
            set
            {
                this._roundedRectangleEdges = value;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get
            {
                return ZStyle.BorderSize;
            }
            set
            {
                if (value > 1)
                {
                    ZStyle.BorderSize = value;
                }
                else
                {
                    ZStyle.BorderSize = 1;
                }
                Reset();
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue(typeof(Color), "Gray")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor1
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

        [Category("Zer0ne")]
        [DefaultValue(typeof(Color), "Gray")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor2
        {
            get
            {
                return ZStyle.GradientColor2;
            }
            set
            {
                ZStyle.GradientColor2 = value;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue(typeof(Color), "Highlight")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectedBorderColor
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

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Radius
        {
            get
            {
                return ZStyle.Radius;
            }
            set
            {
                ZStyle.Radius = value;
                Reset();
                Invalidate();
            }
        }

        Font fnt = ZTheme.Fontz;
        [Category("Zer0ne")]
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
                ctrl.Font = fnt;
                Reset();
                Invalidate();
            }
        }

        Font plfnt = new Font(ZTheme.Fontz.FontFamily, ZTheme.Fontz.Size / 2);
        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font TitleFont
        {
            get
            {
                return plfnt;
            }
            set
            {
                plfnt = value;
                plc.Font = plfnt;
                plc.Height = int.Parse(plfnt.GetHeight().ToString("#"));
                Reset();
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue("")]
        public new string Text
        {
            get => ctrl.Text;
            set
            {
                ctrl.Text = value;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue("Titel")]
        public string TitleText
        {
            get
            {
                return plc.Text;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    plc.Text = ZTheme.Language.DicLang[value];
                }
                else
                {
                    plc.Text = value;
                }
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        public ContentAlignment TitleAlignment
        {
            get
            {
                return plc.TextAlign;
            }
            set
            {
                plc.TextAlign = value;
                Invalidate();
            }
        }

        //private SideZ _borderSides = SideZ.All;
        //[Category("Zer0ne")]
        //[Editor(typeof(FlagEnumUIEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //public SideZ BorderSides
        //{
        //    get
        //    {
        //        return _borderSides;
        //    }
        //    set
        //    {
        //        this._borderSides = value;
        //        this.Invalidate();
        //    }
        //}

        bool titleVisible = true;
        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool TitleVisible 
        {
            get
            {
                return titleVisible;
            }
            set
            {
                titleVisible = value;
                Reset();
            }
        }

        #endregion
         
        #region Setup Methods

        public void Reset()
        {
            #region remove the additional items to add them again
            if (Items == null)
            {
                Items = new List<AdditionalItems>();
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Controls.ContainsKey(i.ToString()))
                    {
                        Controls.RemoveByKey(i.ToString());
                    }
                }
            }
            #endregion 

            int wdz = this.Width - (zStyle.BorderSize * 4) - (zStyle.Radius * 3 / 2);
            Size iSz = new Size(0, 0);
            if (Items.Count > 0)
            {
                iSz = new Size(this.Size.Height - (zStyle.BorderSize * 4), this.Size.Height - (zStyle.BorderSize * 4));
            }
            Point loc = new Point((this.Width - wdz) / 2, (zStyle.BorderSize * 2) + 2);

            int plcHght = plc.Font.Height;
            if (!titleVisible)
            {
                plcHght = 0;
            }

            if (MultiLines)
            {
                if (Items.Count > 0)
                {
                    iSz.Height = ctrl.Font.Height + plcHght;
                    iSz.Width = iSz.Height;
                    loc.X += iSz.Width;
                }

                bool rX = false, lX = false;
                for (int x = 0; x < Items.Count; x++)
                {
                    if (Items[x].Position == ItemPositionZ.Right && rX == false)
                    {
                        rX = true;
                        wdz -= (iSz.Width + 1);
                    }
                    else if (Items[x].Position == ItemPositionZ.Right && lX == false)
                    {
                        lX = true;
                        wdz -= (iSz.Width + 1);
                    }
                }
            }
            //Point lft = new Point(zStyle.Radius + zStyle.BorderSize, zStyle.BorderSize * 2);
            Point lft = new Point(zStyle.BorderSize * 3, zStyle.BorderSize * 2);
            Point rit = new Point(this.Width - iSz.Width - (zStyle.BorderSize * 3), zStyle.BorderSize * 2);
            for (int i = 0; i < Items.Count; i++)
            {
                var itm = new ZButton();
                itm.Size = iSz;
                itm.Name = (Items.Count - 1).ToString();
                itm.Image = Items[i].Icon;
                itm.TabStop = false;
                itm.Click += Items[i].Actionz;
                itm.Cursor = Cursors.Default;
                itm.ZStyle = new ZControlStyle()
                {
                    BorderCapStyle = this.ZStyle.BorderCapStyle,
                    BorderCornersStyle = this.ZStyle.BorderCornersStyle,
                    BorderLineStyle = this.ZStyle.BorderLineStyle,
                    BorderSize = Items[i].ShowBorder  ? 2 : 0,
                    GradientAngle = this.ZStyle.GradientAngle,
                    Radius = ZStyle.Radius > 15 ? 15 : ZStyle.Radius,
                    GradientColor1 = this.ZStyle.GradientColor1,
                    GradientColor2 = this.ZStyle.GradientColor2,
                    TextColor = this.ZStyle.TextColor,
                    BackColor = this.ZStyle.BackColor,
                    ActiveColor = this.ZStyle.ActiveColor,
                    HintColor = this.ZStyle.HintColor,
                    InactiveColor = this.ZStyle.InactiveColor
                };

                if (Items[i].Position == ItemPositionZ.Right)
                {
                    itm.Location = rit;
                    if (MultiLines)
                    {
                        rit.Y += iSz.Height + 1;
                    }
                    else
                    {
                        rit.X -= iSz.Width + 1;
                        wdz -= (iSz.Width + 1);
                    }
                }
                else
                {
                    itm.Location = lft;
                    if (MultiLines)
                    {
                        lft.Y += iSz.Width + 1;
                    }
                    else
                    {
                        lft.X += iSz.Width + 1;
                        loc.X += iSz.Width + 1;
                        wdz -= (iSz.Width + 1);
                    }
                }

                this.Controls.Add(itm);
            }

            plc.Size = new Size(wdz, plc.Height);
            plc.Location = loc;

            if (MultiLines)
            {
                ctrl.Size = new Size(wdz, this.Height - plcHght - (zStyle.BorderSize * 6) - 5);
                ctrl.Location = new Point(loc.X, loc.Y + plcHght);

                if (this.Height < plcHght * 2)
                {
                    this.Height = plcHght * 2;
                }
            }
            else
            {
                ctrl.Size = new Size(wdz, this.Height);
                ctrl.Location = new Point(loc.X, this.Height - ctrl.Height - (zStyle.BorderSize * 2) - 2);

                this.Height = 5 + ctrl.Height + plcHght + (zStyle.BorderSize * 4);
            }
            if (this.Width < 31)
            {
                this.Width = 30;
            }

            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Reset();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Fields
            var rectMain = this.ClientRectangle;
            if (rectMain.Width <= 0)
            {
                rectMain.Width = 1;
            }
            if (rectMain.Height <= 0)
            {
                rectMain.Height = 1;
            }

            LinearGradientBrush borderGColor;
            var smthClr = this.Parent.BackColor;
            var graph = e.Graphics;
            var rectContourSmooth = Rectangle.Inflate(rectMain, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var rectSmooth = Rectangle.Inflate(rectBorder, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var smoothSize = ZStyle.BorderSize > 0 ? ZStyle.BorderSize * 3 : 1;
            if (ctrl.Focused)
            {
                borderGColor = new LinearGradientBrush(rectSmooth, SelectedBorderColor, SelectedBorderColor, 1);
            }
            else
            {
                borderGColor = new LinearGradientBrush(rectSmooth, ZStyle.GradientColor1, ZStyle.GradientColor2, ZStyle.GradientAngle);
            }
            using (borderGColor)
            using (var pathRegion = ZTheme.RoundedRect(rectContourSmooth, ZStyle.Radius, RoundedCorners))
            using (var penSmooth = new Pen(smthClr, smoothSize))
            using (var penBorder = new Pen(borderGColor, ZStyle.BorderSize))
            {
                graph.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.DashStyle = ZStyle.BorderLineStyle;
                penBorder.DashCap = ZStyle.BorderCapStyle;

                //Set rounded region 
                this.Region = new Region(pathRegion);

                //Drawing 
                graph.DrawPath(penSmooth, pathRegion);//Draw contour smoothing

                if (ZStyle.BorderSize > 0) //Draw border
                {
                    graph.DrawPath(penBorder, ZTheme.RoundedRect(rectBorder, ZStyle.Radius, RoundedCorners));
                }
            }

        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.ctrl.Focus();
            if (ChildControl is TextBox)
            {
                var v = ChildControl as TextBox;
                v.SelectAll();
            }
            this.Invalidate();
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);
            OnEnter(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            OnEnter(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            OnEnter(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            OnEnter(e);
        }

        private void Plc_DoubleClick(object sender, EventArgs e)
        {
            OnEnter(e);
        }

        private void Plc_MouseEnter(object sender, EventArgs e)
        {
            OnEnter(e);
        }

        #endregion
    }
}

    /*
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ControlBaseDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu. 
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ControlBaseActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    public class ControlBaseActionList : DesignerActionList
    {
        private ControlBase cntrl;

        private DesignerActionUIService designerActionUISvc = null;

        //The constructor associates the control  
        //with the smart tag list. 
        public ControlBaseActionList(IComponent component) : base(component)
        {
            this.cntrl = component as ControlBase;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of  
        // GetProperties enables undo and menu updates to work properly. 
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(cntrl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ControlBase property not found!", propName);
            else
                return prop;
        }

        PositionZ position = PositionZ.Right;
        public PositionZ ItemPosition
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        private List<AdditionalItems> items = new List<AdditionalItems>();

        // Method that is target of a DesignerActionMethodItem 
        public void InvertColors()
        {
            //Color currentBackColor = cntrl.BackColor;
            //BackColor = Color.FromArgb(255 - currentBackColor.R, 255 - currentBackColor.G, 255 - currentBackColor.B);

            //Color currentForeColor = cntrl.ForeColor;
            //ForeColor = Color.FromArgb(255 - currentForeColor.R, 255 - currentForeColor.G, 255 - currentForeColor.B);
            if (cntrl.Items == null)
            {
                cntrl.Items = new List<AdditionalItems>();
            }
            cntrl.Items.Add(new AdditionalItems() { position = position, Icon = null });

            //GetPropertyByName("Items").SetValue(cntrl, items);
        }

        // Implementation of this abstract method creates smart tag   
        // items, associates their targets, and collects into list. 
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Add Item To The Control"));
            items.Add(new DesignerActionPropertyItem("ItemPosition", "Item Position"));
            items.Add(new DesignerActionMethodItem(this,
                             "InvertColors", "Add Now",
                             "Appearance",
                             "Inverts the fore and background colors.",
                              true));

            return items;
        }
    }

    //[Designer(typeof(ControlBaseDesigner))]
    [DefaultEvent("TextChanged")]
    public class EditorsBase<TControl> : Control where TControl : IControlZ
    {
        public new event EventHandler TextChanged;
        List<AdditionalItems> Items;

        private TControl ctrl;
        private Label plc;
        public EditorsBase()
        {
            ctrl = TControl;
            txbx.Text = Name;
            txbx.BorderStyle = BorderStyle.None;
            txbx.Size = new Size(100, 50);
            txbx.TextChanged += Txbx_TextChanged;
            this.Controls.Add(txbx);

            plc = new Label();
            plc.Text = Name + " Titel";
            plc.Font = new Font("Tahoma", 12);
            plc.BorderStyle = BorderStyle.None;
            plc.Size = new Size(100, int.Parse(plc.Font.GetHeight().ToString("#")));
            this.Controls.Add(plc);

            Cursor = Cursors.IBeam;
            base.Font = ZTheme.Fontz;
            Size = new Size(200, 75);
            TabStop = true;
            Reset();

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

            plc.Click += Plc_MouseEnter;
            plc.GotFocus += Plc_MouseEnter;
            plc.DoubleClick += Plc_DoubleClick;
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;

            txbx.BackColor = ZStyle.BackColor;
            txbx.ForeColor = ZStyle.TextColor;
            plc.BackColor = ZStyle.BackColor;
            plc.ForeColor = ZStyle.TextColor;
        }

        public void AddItem(PositionZ position, Image image, EventHandler action)
        {
            Items.Add(new AdditionalItems { Position = position, Icon = image, Actionz = action });

            Reset();
        }

        public void ClearItems()
        {
            Items.Clear();
        }

        #region Properties

        //Properties
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
                Reset();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                txbx.BackColor = ZStyle.BackColor;
                plc.BackColor = ZStyle.BackColor;
                return ZStyle.BackColor;
            }
            set
            {
                ZStyle.BackColor = value;
                txbx.BackColor = ZStyle.BackColor;
                plc.BackColor = ZStyle.BackColor;
                base.BackColor = ZStyle.BackColor;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
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
                txbx.ForeColor = ZStyle.TextColor;
                base.ForeColor = ZStyle.TextColor;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PlaceHolderColor
        {
            get
            {
                return ZStyle.HintColor;
            }
            set
            {
                ZStyle.TextColor = value;
                plc.ForeColor = ZStyle.TextColor;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get
            {
                return ZStyle.BorderSize;
            }
            set
            {
                if (value > 1)
                {
                    ZStyle.BorderSize = value;
                }
                else
                {
                    ZStyle.BorderSize = 1;
                }
                Reset();
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue(typeof(Color), "Gray")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor1
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

        [Category("Zer0ne")]
        [DefaultValue(typeof(Color), "Gray")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor2
        {
            get
            {
                return ZStyle.GradientColor2;
            }
            set
            {
                ZStyle.GradientColor2 = value;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue(typeof(Color), "Highlight")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SelectedBorderColor
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

        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Radius
        {
            get
            {
                return ZStyle.Radius;
            }
            set
            {
                ZStyle.Radius = value;
                Reset();
                Invalidate();
            }
        }

        Font fnt = ZTheme.Fontz;
        [Category("Zer0ne")]
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
                txbx.Font = fnt;
                Reset();
                Invalidate();
            }
        }

        Font plfnt = new Font(ZTheme.Fontz.FontFamily, ZTheme.Fontz.Size / 2);
        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font PlaceHolderFont
        {
            get
            {
                return plfnt;
            }
            set
            {
                plfnt = value;
                plc.Font = plfnt;
                plc.Height = int.Parse(plfnt.GetHeight().ToString("#"));
                Reset();
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue("")]
        public new string Text
        {
            get => txbx.Text;
            set
            {
                txbx.Text = value;
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return txbx.TextAlign;
            }
            set
            {
                txbx.TextAlign = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue("Titel")]
        public string PlaceHolderText
        {
            get
            {
                return plc.Text;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    plc.Text = ZTheme.Language.DicLang[value];
                }
                else
                {
                    plc.Text = value;
                }
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        public ContentAlignment PlaceHolderAlignment
        {
            get
            {
                return plc.TextAlign;
            }
            set
            {
                plc.TextAlign = value;
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        private bool _readOnly = false;
        [Category("Zer0ne")]
        public bool ReadOnly
        {
            get
            {
                return this._readOnly;
            }
            set
            {
                this._readOnly = value;
                txbx.ReadOnly = _readOnly;
                this.Invalidate();
            }

        }

        [Category("Zer0ne")]
        [DefaultValue(char.MaxValue)]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public char PasswordChar
        {
            get => txbx.PasswordChar;
            set => txbx.PasswordChar = value;
        }

        [Category("Zer0ne")]
        [DefaultValue(false)]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MultiLine
        {
            get => txbx.Multiline;
            set
            {
                txbx.Multiline = value;
                Reset();
                this.Invalidate();
            }
        }

        [Category("Zer0ne")]
        [DefaultValue(true)]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool WordWrap
        {
            get => txbx.WordWrap;
            set => txbx.WordWrap = value;
        }

        [Category("Zer0ne")]
        public ScrollBars ScrollBars
        {
            get => txbx.ScrollBars;
            set
            {
                txbx.ScrollBars = value;
                this.Invalidate();
            }
        }

        #endregion

        //private SideZ _borderSides = SideZ.All;
        //[Category("Zer0ne")]
        //[Editor(typeof(FlagEnumUIEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //public SideZ BorderSides
        //{
        //    get
        //    {
        //        return _borderSides;
        //    }
        //    set
        //    {
        //        this._borderSides = value;
        //        this.Invalidate();
        //    }
        //}

        private CornerZ _roundedRectangleEdges = CornerZ.All;
        [Category("Zer0ne")]
        [Editor(typeof(FlagEnumUIEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public CornerZ RoundedCorners
        {
            get { return _roundedRectangleEdges; }
            set
            {
                this._roundedRectangleEdges = value;
                this.Invalidate();
            }
        }

        #region Setup Methods

        public void Cut()
        {
            this.txbx.Cut();
        }

        public void Copy()
        {
            this.txbx.Copy();
        }

        public void Paste()
        {
            this.txbx.Paste();
        }

        public void Clear()
        {
            this.txbx.Clear();
        }

        public void ClearUndo()
        {
            this.txbx.ClearUndo();
        }

        public void SelectAll()
        {
            this.txbx.SelectAll();
        }

        public void Select(int start, int length)
        {
            this.txbx.Select(start, length);
        }

        private void Reset()
        {
            #region remove the additional items to add them again
            if (Items == null)
            {
                Items = new List<AdditionalItems>();
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Controls.ContainsKey(i.ToString()))
                    {
                        Controls.RemoveByKey(i.ToString());
                    }
                }
            }
            #endregion

            int wdz = this.Width - (zStyle.BorderSize * 4) - (zStyle.Radius * 3 / 2);
            Size iSz = new Size(0, 0);
            if (Items.Count > 0)
            {
                iSz = new Size(this.Size.Height - (zStyle.BorderSize * 4), this.Size.Height - (zStyle.BorderSize * 4));
            }
            Point loc = new Point((this.Width - wdz) / 2, (zStyle.BorderSize * 2) + 2);

            if (MultiLine)
            {
                if (Items.Count > 0)
                {
                    iSz.Height = txbx.Font.Height + plc.Font.Height;
                    iSz.Width = iSz.Height;
                    loc.X += iSz.Width;
                }

                bool rX = false, lX = false;
                for (int x = 0; x < Items.Count; x++)
                {
                    if (Items[x].Position == PositionZ.Right && rX == false)
                    {
                        rX = true;
                        wdz -= (iSz.Width + 1);
                    }
                    else if (Items[x].Position == PositionZ.Right && lX == false)
                    {
                        lX = true;
                        wdz -= (iSz.Width + 1);
                    }
                }
            }
            //Point lft = new Point(zStyle.Radius + zStyle.BorderSize, zStyle.BorderSize * 2);
            Point lft = new Point(zStyle.BorderSize * 3, zStyle.BorderSize * 2);
            Point rit = new Point(this.Width - iSz.Width - (zStyle.BorderSize * 3), zStyle.BorderSize * 2);
            for (int i = 0; i < Items.Count; i++)
            {
                var itm = new ZButton();
                itm.Size = iSz;
                itm.Name = (Items.Count - 1).ToString();
                itm.Image = Items[i].Icon;
                itm.Click += Items[i].Actionz;
                itm.Cursor = Cursors.Default;
                itm.ZStyle = new ZControlStyle()
                {
                    BorderCapStyle = this.ZStyle.BorderCapStyle,
                    BorderCornersStyle = this.ZStyle.BorderCornersStyle,
                    BorderLineStyle = this.ZStyle.BorderLineStyle,
                    BorderSize = 2,
                    GradientAngle = this.ZStyle.GradientAngle,
                    Radius = this.ZStyle.Radius,
                    GradientColor1 = this.ZStyle.GradientColor1,
                    GradientColor2 = this.ZStyle.GradientColor2,
                    TextColor = this.ZStyle.TextColor,
                    BackColor = this.ZStyle.BackColor,
                    ActiveColor = this.ZStyle.ActiveColor,
                    HintColor = this.ZStyle.HintColor,
                    InactiveColor = this.ZStyle.InactiveColor
                };

                if (Items[i].Position == PositionZ.Right)
                {
                    itm.Location = rit;
                    if (MultiLine)
                    {
                        rit.Y += iSz.Height + 1;
                    }
                    else
                    {
                        rit.X -= iSz.Width + 1;
                        wdz -= (iSz.Width + 1);
                    }
                }
                else
                {
                    itm.Location = lft;
                    if (MultiLine)
                    {
                        lft.Y += iSz.Width + 1;
                    }
                    else
                    {
                        lft.X += iSz.Width + 1;
                        loc.X += iSz.Width + 1;
                        wdz -= (iSz.Width + 1);
                    }
                }

                this.Controls.Add(itm);
            }

            plc.Size = new Size(wdz, plc.Height);
            plc.Location = loc;

            if (MultiLine)
            {
                txbx.Size = new Size(wdz, this.Height - plc.Height - (zStyle.BorderSize * 6) - 5);
                txbx.Location = new Point(loc.X, loc.Y + plc.Height);

                if (this.Height < plc.Height * 2)
                {
                    this.Height = plc.Height * 2;
                }
            }
            else
            {
                txbx.Size = new Size(wdz, this.Height);
                txbx.Location = new Point(loc.X, this.Height - txbx.Height - (zStyle.BorderSize * 2) - 2);

                this.Height = 5 + txbx.Height + plc.Height + (zStyle.BorderSize * 4);
            }
            if (this.Width < 31)
            {
                this.Width = 30;
            }

            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Reset();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Fields
            var rectMain = this.ClientRectangle;
            if (rectMain.Width <= 0)
            {
                rectMain.Width = 1;
            }
            if (rectMain.Height <= 0)
            {
                rectMain.Height = 1;
            }

            LinearGradientBrush borderGColor;
            var smthClr = this.Parent.BackColor;
            var graph = e.Graphics;
            var rectContourSmooth = Rectangle.Inflate(rectMain, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var rectSmooth = Rectangle.Inflate(rectBorder, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var smoothSize = ZStyle.BorderSize > 0 ? ZStyle.BorderSize * 3 : 1;
            if (txbx.Focused)
            {
                borderGColor = new LinearGradientBrush(rectSmooth, SelectedBorderColor, SelectedBorderColor, 1);
            }
            else
            {
                borderGColor = new LinearGradientBrush(rectSmooth, ZStyle.GradientColor1, ZStyle.GradientColor2, ZStyle.GradientAngle);
            }
            using (borderGColor)
            using (var pathRegion = ZTheme.RoundedRect(rectContourSmooth, ZStyle.Radius, Edges)) // new GraphicsPath()) 
            using (var penSmooth = new Pen(smthClr, smoothSize))
            using (var penBorder = new Pen(borderGColor, ZStyle.BorderSize))
            {
                graph.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.DashStyle = ZStyle.BorderLineStyle;
                penBorder.DashCap = ZStyle.BorderCapStyle;

                //Set rounded region 
                this.Region = new Region(pathRegion);

                //Drawing 
                graph.DrawPath(penSmooth, pathRegion);//Draw contour smoothing

                if (ZStyle.BorderSize > 0) //Draw border
                {
                    graph.DrawPath(penBorder, ZTheme.RoundedRect(rectBorder, ZStyle.Radius, Edges));
                }
            }

        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.txbx.Focus();
            this.Invalidate();
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            OnEnter(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            SelectAll();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            OnDoubleClick(e);
        }

        private void Plc_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void Plc_MouseEnter(object sender, EventArgs e)
        {
            OnEnter(e);
        }

        private void Txbx_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged.Invoke(this, new EventArgs());
            }
        }

        #endregion
    }
*/

