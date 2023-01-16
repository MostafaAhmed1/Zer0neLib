using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zer0ne.WinUI.Controls
{
    public class ZContextMenu : ContextMenuStrip
    {

        public ZContextMenu(IContainer container) : base(container)
        {
            base.Font = ZTheme.Fontz;
            ZStyle = new ZControlStyle()
            {
                Radius = ZTheme.ControlStyle.Radius,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.AccentColor,                            //MenuBorder => BorderColor;-
                GradientColor2 = ZTheme.AccentColor,
                BackColor = ZTheme.AccentColor,                                 //ToolStripDropDownBackground => BackColor;
                TextColor = ZTheme.ControlStyle.TextColor,                      // TextColor
                ActiveColor = ZTheme.ControlStyle.ActiveColor,                  //MenuItemSelected => MenuItemSelectionColor;
                InactiveColor = ZTheme.ControlStyle.InactiveColor,              //MenuItemBorder => MenuItemBorderColor;
                HintColor = ZTheme.ControlStyle.HintColor                       //ImageMarginGradient Begin Middle End => ColumnColor;
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
        }

        #region  Properties
        bool RTL = false;
        Dictionary<string, Color> DicColor;
        private Bitmap menuItemHeaderSize;

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(typeof(Color), "Gray"), Category("Zer0ne")]
        public Color MenuBorder
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(typeof(Color), "Gray"), Category("Zer0ne")]
        public Color MenuItemBorder
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(typeof(Color), "Gray"), Category("Zer0ne")]
        public Color SelectionColor
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(typeof(Color), "Gray"), Category("Zer0ne")]
        public Color ColumnColor
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


        private int menuItemHeight = 25;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public int MenuItemHeight
        {
            get { return menuItemHeight; }
            set { menuItemHeight = value; }
        }

        #endregion

        #region Overrides methods

        private void LoadItems()
        {

            menuItemHeaderSize = new Bitmap(20, MenuItemHeight);

            foreach (ToolStripMenuItem menuItemL1 in this.Items)
            {
                //    menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                //    if (menuItemL1.Image == null) menuItemL1.Image = menuItemHeaderSize;

                //    //foreach (ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems)
                //    //{
                //    //    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                //    //    if (menuItemL2.Image == null) menuItemL2.Image = menuItemHeaderSize;

                //    //    foreach (ToolStripMenuItem menuItemL3 in menuItemL2.DropDownItems)
                //    //    {
                //    //        menuItemL3.ImageScaling = ToolStripItemImageScaling.None;
                //    //        if (menuItemL3.Image == null) menuItemL3.Image = menuItemHeaderSize;

                //    //        foreach (ToolStripMenuItem menuItemL4 in menuItemL3.DropDownItems)
                //    //        {
                //    //            menuItemL4.ImageScaling = ToolStripItemImageScaling.None;
                //    //            if (menuItemL4.Image == null) menuItemL4.Image = menuItemHeaderSize;
                //    //            ///Level 5++
                //    //        }
                //    //    }
                //    //}
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (this.DesignMode == false)
            {
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    RTL = true;
                }
                else
                {
                    RTL = false;
                }
                this.Renderer = new MenuRenderer(DicColor, RTL);
                LoadItems();
                Invalidate();
            }
        }
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            OnHandleCreated(e);
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }
        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            base.Font = this.Font;

            DicColor = new Dictionary<string, Color>();

            DicColor.Add("BackColor", ZStyle.BackColor);
            DicColor.Add("BorderColor", ZStyle.GradientColor1);
            DicColor.Add("SelectionColor", ZStyle.ActiveColor);
            DicColor.Add("MenuItemBorder", ZStyle.InactiveColor);
            DicColor.Add("ColumnColor", ZStyle.HintColor);
            DicColor.Add("TextColor", ZStyle.TextColor);
        }
        #endregion
    }

    #region class MenuRenderer
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        public MenuRenderer(Dictionary<string, Color> DicColor,bool rtl) : base(new TableColor(DicColor))
        {
            RTL = rtl;
            SelectTextColor = DicColor["TextColor"];
            //UnSelectTextColor =DicColor["ColumnColor"];
            UnSelectTextColor =DicColor["MenuItemBorder"];
        }

        bool RTL;
        private Color UnSelectTextColor;
        private Color SelectTextColor;
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? SelectTextColor : UnSelectTextColor;
        }
       
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Size arrowSize = new Size(5, 12);
            Color arrowColor = e.Item.Selected ? SelectTextColor : UnSelectTextColor;
            Rectangle rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2, arrowSize.Width, arrowSize.Height);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(arrowColor, 3))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                if (RTL)
                {
                    path.AddLine(rect.Left , rect.Top + rect.Height / 2 , rect.Right , rect.Top);
                    path.AddLine(rect.Left, rect.Top + rect.Height / 2, rect.Right, rect.Top + rect.Height );
                }
                else
                {
                    path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
                    path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
                }
                g.DrawPath(pen, path);
            }
        }
    }
    #endregion

    #region class TableColor
    public class TableColor : ProfessionalColorTable
    {
        public TableColor(Dictionary<string, Color> DicColor)
        {
            this.BackColor = DicColor["BackColor"];
            this.BorderColor = DicColor["BorderColor"];
            this.ColumnColor = DicColor["ColumnColor"];
            this.ItemBorderColor = DicColor["MenuItemBorder"];
            this.SelectionColor = DicColor["SelectionColor"];
        }
        Color BackColor;
        Color BorderColor;
        Color ItemBorderColor;
        Color SelectionColor;
        Color ColumnColor;
        public override Color ToolStripDropDownBackground => BackColor;
        public override Color MenuBorder => BorderColor;
        public override Color MenuItemBorder => ItemBorderColor;
        public override Color MenuItemSelected => SelectionColor;
        public override Color ImageMarginGradientBegin => ColumnColor;
        public override Color ImageMarginGradientMiddle => ColumnColor;
        public override Color ImageMarginGradientEnd => ColumnColor;
    }
    #endregion
}
