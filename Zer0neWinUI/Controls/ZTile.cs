using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    public class ZTile : Control //Button
    {
        ContextMenuStrip dropMenu;
        bool EnableDropMenu;
       
        public ZTile()
        {
            //ZWinHelper.SetInputLanguage(null);
            Title = "zTile";
            Size = new Size(150, 150);
            //FlatStyle = FlatStyle.Flat;
            //FlatAppearance.BorderSize = 0;
            //UseVisualStyleBackColor = true;
            TabStop = true;
            EnableDropMenu = false;
            dropMenu = new ContextMenuStrip();
            dropMenu.SuspendLayout();
            dropMenu.Name = "dropMenu";
            dropMenu.Size = new Size(100, 200);
            dropMenu.RightToLeft = RightToLeft.Yes;
            base.Click += DevButton_Click;
            base.Font = new Font("Tahoma", 16F);// ZTheme.Fontz;
            
            dropMenu.ResumeLayout(false);
            ZStyle = new ZControlStyle()
            {
                Radius = ZTheme.ControlStyle.Radius,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.AccentColor,
                GradientColor2 = ZTheme.AccentColor,
                BackColor = ZTheme.AccentColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
      
        }



        #region Tile Properties

        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        //[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
        //public override ContentAlignment TextAlign
        //{
        //    get
        //    {
        //        return base.TextAlign;
        //    }

        //    set
        //    {
        //        base.TextAlign = value;
        //    }
        //}
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx



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

        [ Category("Zer0ne")]
        public string Title
        {
            get
            {
                return Text;
            }

            set
            {
                Text = value;
                Invalidate();
            }
        }

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

        Font fnt = new Font("Tahoma", 12F); //ZTheme.Fontz;
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


        private ContentAlignment titleAlign = ContentAlignment.TopLeft;
        [DefaultValue(ContentAlignment.TopLeft),Category("Zer0ne")]
        public  ContentAlignment TitleAlign
        {
            get { return titleAlign; }
            set { titleAlign = value; Invalidate(); }
        }


        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Zer0ne")]
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
                Invalidate();
            }
        }

    

        
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),Category("Zer0ne")]
        public int Radius
        {
            get
            {
                return ZStyle.Radius;
            }
            set
            {
                ZStyle.Radius = value;
                Invalidate();
            }
        }
        #endregion

        #region Description 

        //private Color descriptionColor =ZTheme.HintColor;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public  Color DescriptionColor
        {
            get
            {
                return ZTheme.ThirdColor;
            }
            set
            {
                ZTheme.ThirdColor = value;
                Invalidate();
            }
        }

        Font fntDesc = new Font("Tahoma", 12F); 
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public Font DescriptionFont
        {
            get
            {
                return fntDesc;
            }
            set
            {
                fntDesc = value;
                Invalidate();
            }
        }

        private string description = string.Empty;
        [Category("Zer0ne")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                //if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                //    && ZTheme.Language.DicLang.ContainsKey(value))
                //{
                //    base.Text = ZTheme.Language.DicLang[value];
                //}
                //else
                //{
                //    ZTheme.Language.DicLang.Add(value, value);
                //    ZTheme.Language.Save();
                //    base.Text = value;
                //}
                description = value;
                Invalidate();
            }
        }

        private ContentAlignment descriptionAlign = ContentAlignment.MiddleCenter;
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Category("Zer0ne")]
        public ContentAlignment DescriptionAlign
        {
            get { return descriptionAlign; }
            set { descriptionAlign = value; Invalidate(); }
        }

        #endregion

        #region Image Properties

        private Image tileImage = null;
        [DefaultValue(null)]
        [Category("Zer0ne")]
        public  Image Image
        {
            get { return tileImage; }
            set { tileImage = value; Invalidate(); }
        }

        private bool useTileImage = false;
        [DefaultValue(false)]
        [Category("Zer0ne")]
        public bool UseImage
        {
            get { return useTileImage; }
            set { useTileImage = value; Invalidate(); }
        }

        private ContentAlignment tileImageAlign = ContentAlignment.TopLeft;
        [DefaultValue(ContentAlignment.TopLeft)]
        [Category("Zer0ne")]
        public  ContentAlignment ImageAlign
        {
            get { return tileImageAlign; }
            set { tileImageAlign = value; Invalidate(); }
        }
        #endregion

        #region Number 
        private ContentAlignment numAlign = ContentAlignment.TopRight;
        [DefaultValue(ContentAlignment.TopRight), Category("Zer0ne")]
        public ContentAlignment NumberAlign
        {
            get { return numAlign; }
            set { numAlign = value; Invalidate(); }
        }

        private bool unum = true;
        [DefaultValue(true), Category("Zer0ne")]
        public bool UseNumber
        {
            get { return unum; }
            set { unum = value; Invalidate(); }
        }

        private string tileCount = "01";
        [DefaultValue(0), Category("Zer0ne")]
        public string Number
        {
            get { return tileCount; }
            set { tileCount = value; Invalidate(); }
        }

        Font fntnum = new Font("Tahoma", 22F,System.Drawing.FontStyle.Bold);
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public Font NumberFont
        {
            get
            {
                return fntnum;
            }
            set
            {
                fntnum = value;
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Zer0ne")]
        public Color NumberColor
        {
            get
            {
                return ZTheme.SelectColor;
            }
            set
            {
                ZTheme.SelectColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Eventes Voids

       
        protected override void OnPaint(PaintEventArgs pe)
        {
          
            base.OnPaint(pe);

            var graph = pe.Graphics;
            graph.Clear(this.BackColor);
            
            var smthClr = this.Parent.BackColor;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var rectSmooth = Rectangle.Inflate(rectBorder, -ZStyle.BorderSize, -ZStyle.BorderSize);
            var smoothSize = ZStyle.BorderSize > 0 ? ZStyle.BorderSize * 3 : 1;
            using (var borderGColor = new LinearGradientBrush(rectSmooth, ZStyle.GradientColor1, ZStyle.GradientColor2, ZStyle.GradientAngle))
            using (var pathRegion = ZTheme.RoundedRect(rectContourSmooth, ZStyle.Radius)) // new GraphicsPath()) 
            using (var penSmooth = new Pen(smthClr, smoothSize))
            using (var penBorder = new Pen(borderGColor, ZStyle.BorderSize))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                penBorder.DashStyle = ZStyle.BorderLineStyle;
                penBorder.DashCap = ZStyle.BorderCapStyle;

                //Set rounded region 
                this.Region = new Region(pathRegion);

                //Drawing 
                graph.DrawPath(penSmooth, pathRegion);//Draw contour smoothing

                if (ZStyle.BorderSize > 0) //Draw border
                {
                    graph.DrawPath(penBorder, ZTheme.RoundedRect(rectBorder, ZStyle.Radius));
                }

                if (UseImage && this.Image != null)
                {

                    graph.DrawImage(Image, rectSmooth , ImageAlign);
                }
                //ConvertToWesternArabicNumerals(Title)
                //ConvertToEasternArabicNumerals

                // Draw TitleText
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    TextRenderer.DrawText(graph, ConvertToEasternArabicNumerals(this.Title), this.Font, rectSmooth, this.ForeColor, Color.Transparent, TitleAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                    TextRenderer.DrawText(graph, ConvertToEasternArabicNumerals(Description), this.DescriptionFont, rectSmooth, this.DescriptionColor, Color.Transparent, DescriptionAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                    if (UseNumber)
                    {
                        TextRenderer.DrawText(graph, ConvertToEasternArabicNumerals(Number.ToString()), this.NumberFont, rectSmooth, this.NumberColor, Color.Transparent, NumberAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                    }
                }
                else
                {
                    TextRenderer.DrawText(graph, this.Title, this.Font, rectSmooth, this.ForeColor, Color.Transparent, TitleAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                    TextRenderer.DrawText(graph, ConvertToEasternArabicNumerals(Description), this.DescriptionFont, rectSmooth, this.DescriptionColor, Color.Transparent, DescriptionAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                    if (UseNumber)
                    {
                        TextRenderer.DrawText(graph, Number.ToString(), this.NumberFont, rectSmooth, this.NumberColor, Color.Transparent, NumberAlign.AsTextFormatFlags() | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
                    }
                }
                //rectContourSmooth
            }


        }
       
        public void PerformClick()
        {
           
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.Size == new Size(-1,-1))
            {
                return;
            }
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }
        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            //base.Font = this.Font;
        }
        public void AddDropListItem(string text, EventHandler action)
        {
            EnableDropMenu = true;

            ZDropDownItem toolStripMenuItem1 = new ZDropDownItem();
            toolStripMenuItem1.Name = text + dropMenu.Items.Count;
            toolStripMenuItem1.Size = new Size(200, 30);
            toolStripMenuItem1.Text = text;
            toolStripMenuItem1.Click += action;

            dropMenu.Items.Add(toolStripMenuItem1);
        }
        private void DevButton_Click(object sender, EventArgs e)
        {
            if (EnableDropMenu)
            {
                var p = this.PointToScreen(Point.Empty);
                p = new Point(p.X + this.Width, p.Y + this.Height);
                dropMenu.Show(p, ToolStripDropDownDirection.BelowLeft);
            }
        }
        public void ClearDropItems()
        {
            dropMenu.Items.Clear();
            EnableDropMenu = false;
        }
        #endregion

        public string ConvertToWesternArabicNumerals(string input)//Converts ٠١٢٣... to 01234... 
        {
            System.Text.UTF8Encoding utf8Encoder = new UTF8Encoding();
            System.Text.Decoder utf8Decoder = utf8Encoder.GetDecoder();
            System.Text.StringBuilder convertedChars = new System.Text.StringBuilder();

            char[] convertedChar = new char[1];
            char[] inputCharArray = input.ToCharArray();

            foreach (char c in inputCharArray)
            {

                if (char.IsDigit(c))
                {
                    convertedChars.Append(char.GetNumericValue(c));
                }
                else
                {
                    convertedChars.Append(c);
                }
            }
            return convertedChars.ToString();
        }

        public string ConvertToEasternArabicNumerals(string input)//Converts 01234... to ٠١٢٣...
        {

            WebUtility.HtmlDecode(input);

            System.Text.UTF8Encoding utf8Encoder = new UTF8Encoding();
            System.Text.Decoder utf8Decoder = utf8Encoder.GetDecoder();

            System.Text.StringBuilder convertedChars = new System.Text.StringBuilder();
            char[] convertedChar = new char[1];
            byte[] bytes = new byte[] { 217, 160 };
            char[] inputCharArray = input.ToCharArray();
            foreach (char c in inputCharArray)
            {

                if (char.IsDigit(c))
                {
                    bytes[1] = Convert.ToByte(160 + char.GetNumericValue(c));
                    utf8Decoder.GetChars(bytes, 0, 2, convertedChar, 0);
                    convertedChars.Append(convertedChar[0]);
                }
                else
                {
                    convertedChars.Append(c);
                }
            }
            return convertedChars.ToString();
        }

    }
}
