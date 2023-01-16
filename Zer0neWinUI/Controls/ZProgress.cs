using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    [DefaultProperty("Value")]
    public class ZProgress : Control
    {
        #region Private Variables

        private long _Value;
        private long _Maximum = 100;
        private int _LineWitdh = 1;
        private float _BarWidth = 14f;

        private LinearGradientMode _GradientMode = LinearGradientMode.ForwardDiagonal;
        private BorderMode ProgressShapeVal;
        private TextMode ProgressTextMode;

        #endregion

        #region Public Properties
        [Category("Zer0ne")]
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BarColor1
        {
            get { return zStyle.GradientColor1; }
            set
            {
                zStyle.GradientColor1 = value;
                Invalidate();
            }
        }
       

        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BarColor2
        {
            get { return zStyle.GradientColor2; }
            set
            {
                zStyle.GradientColor2 = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public float BarWidth
        {
            get { return _BarWidth; }
            set
            {
                _BarWidth = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public LinearGradientMode GradientMode
        {
            get { return _GradientMode; }
            set
            {
                _GradientMode = value;
                Invalidate();
            }
        }
        
        [Browsable(true), Category("Zer0ne"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LineColor
        {
            get { return zStyle.ActiveColor; }
            set
            {
                zStyle.ActiveColor = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public int LineWidth
        {
            get { return _LineWitdh; }
            set
            {
                _LineWitdh = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public BorderMode ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public TextMode TextMode
        {
            get { return ProgressTextMode; }
            set
            {
                ProgressTextMode = value;
                Invalidate();
            }
        }

        [Category("Zer0ne")]
        public override string Text { get; set; }

        #endregion

        #region Contructor
        public ZProgress()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);

            this.Size = new Size(130, 130);           
            this.MinimumSize = new Size(100, 100);
            this.DoubleBuffered = true;
            this.LineWidth = 1;

            //Value = 57;
            ProgressShape = BorderMode.Flat;
            TextMode = TextMode.Percentage;

            base.Font = ZTheme.Fontz;
            TabStop = true;

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

            //------------------
        }


        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

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
            }
        }
        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            /*
        LineColor = zStyle.ActiveColor;
       BarColor1
       BarColor2
        */
            //LineColor = zStyle.ActiveColor;
            //BarColor1 = zStyle.GradientColor1;
            //BarColor2 = zStyle.GradientColor2;
        }

        #endregion

        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        #region Methods

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            this._Value += Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }
        #endregion

        #region Events

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {

                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    //graphics.Clear(Color.Transparent); //<-- this.BackColor, SystemColors.Control, Color.Transparent

                    PaintTransparentBackground(this, e);

                    //Dibuja el circulo blanco interior:
                    using (Brush mBackColor = new SolidBrush(this.BackColor))
                    {

                        graphics.FillEllipse(mBackColor, 18, 18,
                                (this.Width - 0x30) + 12,
                                (this.Height - 0x30) + 12);
                    }
                    // Dibuja la delgada Linea gris del medio:
                    using (Pen pen2 = new Pen(LineColor, this.LineWidth))
                    {
                        graphics.DrawEllipse(pen2,
                            18, 18,
                          (this.Width - 0x30) + 12,
                          (this.Height - 0x30) + 12);
                    }

                    //Dibuja la Barra de Progreso
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                        this.BarColor1, this.BarColor2, this.GradientMode))
                    {
                        using (Pen pen = new Pen(brush, this.BarWidth))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case BorderMode.Circle:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case BorderMode.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }

                            //Aqui se dibuja realmente la Barra de Progreso
                            graphics.DrawArc(pen,
                                0x12, 0x12,
                                (this.Width - 0x23) - 2,
                                (this.Height - 0x23) - 2,
                                -90,
                                (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                        }
                    }

                    #region Dibuja el Texto de Progreso

                    switch (this.TextMode)
                    {
                        case TextMode.None:
                            this.Text = string.Empty;
                            break;

                        case TextMode.Value:
                            this.Text = _Value.ToString();
                            break;

                        case TextMode.Percentage:
                            this.Text = Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)) + " %";
                            break;

                        default:
                            break;
                    }

                    if (this.Text != string.Empty)
                    {
                        using (Brush FontColor = new SolidBrush(this.ForeColor))
                        {
                            //int ShadowOffset = 2;
                            SizeF MS = graphics.MeasureString(this.Text, this.Font);
                            //SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, this.ForeColor));
                            SolidBrush shadowBrush = new SolidBrush(this.ForeColor);

                            //Sombra del Texto:
                            //graphics.DrawString(this.Text, this.Font, shadowBrush,
                            //    Convert.ToInt32(Width / 2 - MS.Width / 2) + ShadowOffset,
                            //    Convert.ToInt32(Height / 2 - MS.Height / 2) + ShadowOffset
                            //);

                            //Texto del Control:
                            graphics.DrawString(this.Text, this.Font, FontColor,
                                Convert.ToInt32(Width / 2 - MS.Width / 2),
                                Convert.ToInt32(Height / 2 - MS.Height / 2));
                        }
                    }

                    #endregion

                    //Aqui se Dibuja todo el Control:
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }

        private static void PaintTransparentBackground(Control c, PaintEventArgs e)
        {
            if (c.Parent == null || !Application.RenderWithVisualStyles)
                return;

            ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        }

        /// <summary>Dibuja un Circulo Relleno de Color con los Bordes perfectos.</summary>
        /// <param name="g">'Canvas' del Objeto donde se va a dibujar</param>
        /// <param name="brush">Color y estilo del relleno</param>
        /// <param name="centerX">Centro del Circulo, en el eje X</param>
        /// <param name="centerY">Centro del Circulo, en el eje Y</param>
        /// <param name="radius">Radio del Circulo</param>
        private void FillCircle(Graphics g, Brush brush, float centerX, float centerY, float radius)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
            }
        }

        #endregion
    }
}

