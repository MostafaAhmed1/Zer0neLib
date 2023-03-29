using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI.Controls;

namespace Zer0ne.WinUI.Forms
{
    public partial class ZForm : Form
    {
        #region drop shadow

        private bool Drag;
        private int MouseX;
        private int MouseY;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        private int mrgnWdz = 1;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = mrgnWdz,
                            leftWidth = mrgnWdz,
                            rightWidth = mrgnWdz,
                            topHeight = mrgnWdz
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                case WM_NCHITTEST:
                    Point pos = new Point(m.LParam.ToInt32());
                    pos = this.PointToClient(pos);
                    if (pos.Y < cCaption)
                    {
                        m.Result = (IntPtr)2;
                        return;
                    }
                    if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
                    {
                        m.Result = (IntPtr)17;
                        return;
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION;
            }
        }

        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }

        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; }

        #endregion

        public ZPanel pnlTitel;
        public ZButton btnClose;
        public ZButton btnMinimize;
        public ZButton btnMaximize;

        [Category("Zer0ne")]
        public override string Text
        {
            get
            {
                if (pnlTitel != null)
                {
                    pnlTitel.Text = base.Text;
                }
                return base.Text;
            }
            set
            {
                base.Text = value;
                pnlTitel.Text = value;
                Invalidate();
            }
        }

        bool cl = true;
        [Category("Zer0ne")]
        public bool ShowCloseButton
        {
            get
            {
                btnClose.Visible = cl;
                return cl;
            }
            set
            {
                cl = value;
                btnClose.Visible = cl;
            }
        }

        bool mx = true;
        [Category("Zer0ne")]
        public bool ShowMaxmizeButton
        {
            get
            {
                btnMaximize.Visible = mx;
                return mx;
            }
            set
            {
                mx = value;
                btnMaximize.Visible = mx;
            }
        }

        bool mn = true;
        [Category("Zer0ne")]
        public bool ShowMinimizeButton
        {
            get
            {
                btnMinimize.Visible = mn;
                return mn;
            }
            set
            {
                mn = value;
                btnMinimize.Visible = mn;
            }
        }

        bool tp = true;
        [Category("Zer0ne")]
        public bool ShowTitelPanel
        {
            get
            {
                pnlTitel.Visible = tp;
                return tp;
            }
            set
            {
                tp = value;
                pnlTitel.Visible = tp;
            }
        }

        bool roundCorners = false;
        public ErrorProvider ep;
        private IContainer components;

        [Category("Zer0ne")]
        public bool RoundCorners
        {
            get
            {
                return roundCorners;
            }
            set
            {
                if (value)
                {
                    mrgnWdz = 0;
                }
                else
                {
                    mrgnWdz = 1;
                }
                roundCorners = value;
                ZBaseForm_Resize(this, new EventArgs());
            }
        }

        bool movable;
        [Category("Zer0ne")]
        public bool Movable
        {
            get
            {
                return movable;
            }
            set
            {
                movable = value;
            }
        }

        #region Form Title Methods

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        const int cGrip = 16;
        const int cCaption = 32;

        private void PnlTitel_DoubleClick(object sender, EventArgs e)
        {
            if (ShowMaxmizeButton)
            {
                btnMaximize_Click(sender, e);
            }
        }

        private void pnlTitel_MouseDown(object sender, MouseEventArgs e)
        {
            if (movable)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Image = ZTheme.ReplaceColor(Properties.Resources.maximize_24px, Color.FromArgb(0, 0, 0), ZTheme.BacgroundColor);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Image = ZTheme.ReplaceColor(Properties.Resources.normal_24px, Color.FromArgb(0, 0, 0), ZTheme.BacgroundColor);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        public ZForm()
        {
            InitializeComponent();
            
            StartPosition = FormStartPosition.CenterParent;

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            if (roundCorners)
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            }

            m_aeroEnabled = false ;
            movable = true;

            this.BackColor = ZTheme.SecondaryColor;
            this.ForeColor = ZTheme.TextColor;

            pnlTitel.ZStyle = btnClose.ZStyle;

            btnClose.Image = ZTheme.ReplaceColor(Properties.Resources.Close_24px, Color.FromArgb(255, 0, 0, 0), ZTheme.BacgroundColor);
            btnMaximize.Image = ZTheme.ReplaceColor(Properties.Resources.maximize_24px, Color.FromArgb(255, 0, 0, 0), ZTheme.BacgroundColor);
            btnMinimize.Image = ZTheme.ReplaceColor(Properties.Resources.minimize_24, Color.FromArgb(255, 0, 0, 0), ZTheme.BacgroundColor);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTitel = new Zer0ne.WinUI.Controls.ZPanel();
            this.btnMinimize = new Zer0ne.WinUI.Controls.ZButton();
            this.btnMaximize = new Zer0ne.WinUI.Controls.ZButton();
            this.btnClose = new Zer0ne.WinUI.Controls.ZButton();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Controls.Add(this.btnMinimize);
            this.pnlTitel.Controls.Add(this.btnMaximize);
            this.pnlTitel.Controls.Add(this.btnClose);
            this.pnlTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitel.Location = new System.Drawing.Point(0, 0);
            this.pnlTitel.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitel.Name = "pnlTitel";
            this.pnlTitel.Text  = "Hat";
            this.pnlTitel.ShowTitle = true;
            this.pnlTitel.Size = new System.Drawing.Size(502, 29);
            this.pnlTitel.TabIndex = 9;
            this.pnlTitel.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitel.DoubleClick += new System.EventHandler(this.PnlTitel_DoubleClick);
            this.pnlTitel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitel_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BorderSize = 1;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Zer0ne.WinUI.Properties.Resources.minimize_24;
            this.btnMinimize.Location = new System.Drawing.Point(409, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Radius = 0;
            this.btnMinimize.Size = new System.Drawing.Size(31, 29);
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = global::Zer0ne.WinUI.Properties.Resources.maximize_24px;
            this.btnMaximize.Location = new System.Drawing.Point(440, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Radius = 0;
            this.btnMaximize.Size = new System.Drawing.Size(31, 29);
            this.btnMaximize.TabIndex = 9;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Zer0ne.WinUI.Properties.Resources.Close_24px;
            this.btnClose.Location = new System.Drawing.Point(471, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 0;
            this.btnClose.Size = new System.Drawing.Size(31, 29);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            this.ep.Icon = global::Zer0ne.WinUI.Properties.Resources.epIcon;
            // 
            // ZForm
            // 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.pnlTitel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 16F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ZForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ZForm_Load);
            this.Resize += new System.EventHandler(this.ZBaseForm_Resize);
            this.HandleCreated += ZForm_HandleCreated;
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
        }

        private void ZForm_HandleCreated(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void ZBaseForm_Resize(object sender, EventArgs e)
        {
            if (roundCorners)
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            }
        }

        private void ZForm_Load(object sender, EventArgs e)
        {

        }

        public Bitmap ReplaceColor(Bitmap bmp, Color oldColor, Color newColor)
        {
            return ZTheme.ReplaceColor(bmp, oldColor, newColor);
        }

    }
}
