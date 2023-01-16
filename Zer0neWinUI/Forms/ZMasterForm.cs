using FluentTransitions;
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
    public partial class ZMasterForm : Form
    {
        public ZPanel pnlTitel;
        public ZButton btnMinimize;
        public ZButton btnMaximize;
        public ZButton btnClose;
        public ZPictureBox picAppIcon;

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitel = new Zer0ne.WinUI.Controls.ZPanel();
            this.picAppIcon = new Zer0ne.WinUI.Controls.ZPictureBox();
            this.btnMinimize = new Zer0ne.WinUI.Controls.ZButton();
            this.btnMaximize = new Zer0ne.WinUI.Controls.ZButton();
            this.btnClose = new Zer0ne.WinUI.Controls.ZButton();
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Controls.Add(this.picAppIcon);
            this.pnlTitel.Controls.Add(this.btnMinimize);
            this.pnlTitel.Controls.Add(this.btnMaximize);
            this.pnlTitel.Controls.Add(this.btnClose);
            this.pnlTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitel.Location = new System.Drawing.Point(0, 0);
            this.pnlTitel.Margin = new System.Windows.Forms.Padding(1);
            this.pnlTitel.Name = "pnlTitel";
            this.pnlTitel.Size = new System.Drawing.Size(811, 31);
            this.pnlTitel.TabIndex = 10;
            this.pnlTitel.DoubleClick += new System.EventHandler(this.PnlTitel_DoubleClick);
            this.pnlTitel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitel_MouseDown);
            // 
            // picAppIcon
            // 
            this.picAppIcon.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.picAppIcon.BorderCornerStyle = Zer0ne.WinUI.BorderMode.RoundedCorners;
            this.picAppIcon.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picAppIcon.BorderSize = 0;
            this.picAppIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picAppIcon.GradientAngle = 30F;
            this.picAppIcon.Image = global::Zer0ne.WinUI.Properties.Resources.new_24px;
            this.picAppIcon.Location = new System.Drawing.Point(0, 0);
            this.picAppIcon.Margin = new System.Windows.Forms.Padding(2);
            this.picAppIcon.Name = "picAppIcon";
            this.picAppIcon.Radius = 0;
            this.picAppIcon.Size = new System.Drawing.Size(36, 31);
            this.picAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAppIcon.TabIndex = 12;
            this.picAppIcon.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Zer0ne.WinUI.Properties.Resources.minimize_24;
            this.btnMinimize.Location = new System.Drawing.Point(709, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(34, 31);
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
            this.btnMaximize.Location = new System.Drawing.Point(743, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(1);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(34, 31);
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
            this.btnClose.Location = new System.Drawing.Point(777, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 31);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ZMasterForm
            // 
            this.ClientSize = new System.Drawing.Size(811, 469);
            this.Controls.Add(this.pnlTitel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ZMasterForm";
            this.Text = "ZMasterForm";
            this.Load += new System.EventHandler(this.ZMasterForm_Load);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).EndInit();
            this.ResumeLayout(false);

        }

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
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        bool movable;
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

        private int boarderSize = 2;
        public int BorderSize
        {
            get
            {
                return boarderSize;
            }
            set
            {
                boarderSize = value;
            }
        }

        FormWindowState st;
        public new FormWindowState WindowState
        {
            get
            {
                st = base.WindowState;
                return st;
            }
            set
            {
                base.WindowState = value;
                st = base.WindowState;
            }
        }

        Font fnt = ZTheme.Fontz;
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

        #region Form Title Methods
         
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        const int cGrip = 16;
        const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
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
            }
            else if (m.Msg == 0x0083 && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }

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

        public ZMasterForm()
        {
            InitializeComponent();

            this.Padding = new Padding(boarderSize); //---boarder Size
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            movable = true;

            this.BackColor = ZTheme.BacgroundColor;
            this.ForeColor = ZTheme.AccentColor;

            var zs = new ZControlStyle()
            {
                Radius = 0,
                BorderSize = 0,
                GradientAngle = 10,
                BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat,
                BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid,
                BorderCornersStyle = BorderMode.RoundedCorners,
                GradientColor1 = ZTheme.ThirdColor,
                GradientColor2 = ZTheme.ThirdColor,
                BackColor = ZTheme.SecondaryColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
            };
            btnClose.ZStyle = btnMaximize.ZStyle = btnMinimize.ZStyle = zs;
            pnlTitel.ZStyle = zs;
            picAppIcon.ZStyle = zs;

            btnClose.Image = ZTheme.ReplaceColor(Properties.Resources.Close_24px, Color.FromArgb(255, 0, 0, 0), ZTheme.TextColor);
            btnMaximize.Image = ZTheme.ReplaceColor(Properties.Resources.maximize_24px, Color.FromArgb(255, 0, 0, 0), ZTheme.TextColor);
            btnMinimize.Image = ZTheme.ReplaceColor(Properties.Resources.minimize_24, Color.FromArgb(255, 0, 0, 0), ZTheme.TextColor);
            
        }

        private Panel WorkingAreaPanel;
        public Size WorkingAreaSize { get; set; }
        public Point WorkingAreaStartPoint { get; set; }

        private void ZMasterForm_Load(object sender, EventArgs e)
        {
        }

        public void HideWorkingAreaPanel()
        {
            if (WorkingAreaPanel != null && WorkingAreaPanel.Width > 10)
            {                
                Transition
                    .With(WorkingAreaPanel, nameof(Top), Screen.PrimaryScreen.Bounds.Height + 20)
                    //.With(WorkingAreaPanel, nameof(Width), 5)
                    .Linear(TimeSpan.FromMilliseconds(600));
            }
        }

        public void ShowWorkingAreaPanel(Control content)
        {
            var pnlCont = new Panel();
            pnlCont.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCont.BackColor = ZTheme.BacgroundColor;
            pnlCont.Name = "pnlCont";
            pnlCont.Size = WorkingAreaSize;
            pnlCont.Location = WorkingAreaStartPoint;
            pnlCont.TabStop = false;
            pnlCont.Width = 0;
            pnlCont.BringToFront();
            pnlCont.Visible = true;
            this.Controls.Add(pnlCont);
            pnlCont.Controls.Add(content);
            pnlCont.Tag = content;
            WorkingAreaPanel = pnlCont;
            content.Dock = DockStyle.Fill;
            content.BringToFront();
            content.Visible = true;
            Transition.With(pnlCont, nameof(Width), this.Width - 20)
                .HookOnCompletion(()=> 
                {
                    content.Invoke(new MethodInvoker(() =>
                    {
                        content.Show();
                    }));
                }).Linear(TimeSpan.FromMilliseconds(750));
        }

    }
}
