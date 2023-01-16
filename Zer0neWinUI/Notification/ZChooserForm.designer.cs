
namespace Zer0ne.WinUI.Notifications
{
    partial class frmChooser<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable1 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer1 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.listBox1 = new Zer0ne.WinUI.Controls.ZListBox();
            this.keyBoard1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.pnlBtns.SuspendLayout();
            this.pnlTitel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new System.Drawing.Point(368, 1);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            // 
            // pnlBtns
            // 
            this.pnlBtns.Location = new System.Drawing.Point(0, 525);
            this.pnlBtns.Size = new System.Drawing.Size(497, 59);
            // 
            // pnlTitel
            // 
            this.pnlTitel.Size = new System.Drawing.Size(497, 33);
            this.pnlTitel.Text = "Zer0ne";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSearch.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.txtSearch.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.txtSearch.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.txtSearch.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.txtSearch.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 22F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(12, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(473, 49);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.WatermarkText = "إبحث...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 35;
            this.listBox1.Location = new System.Drawing.Point(12, 105);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(473, 420);
            this.listBox1.TabIndex = 12;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // keyBoard1
            // 
            this.keyBoard1.BackColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable1.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable1.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable1.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable1.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable1.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable1.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable1.TopBarTextColor = System.Drawing.Color.White;
            this.keyBoard1.ColorTable = virtualKeyboardColorTable1;
            this.keyBoard1.ForeColor = System.Drawing.Color.Black;
            this.keyBoard1.Location = new System.Drawing.Point(12, 328);
            this.keyBoard1.Name = "keyBoard1";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyBoard1.Renderer = flatStyleRenderer1;
            this.keyBoard1.Size = new System.Drawing.Size(470, 192);
            this.keyBoard1.TabIndex = 13;
            this.keyBoard1.TabStop = false;
            this.keyBoard1.Text = "Zer0ne Keyboard";
            // 
            // frmChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 584);
            this.Controls.Add(this.keyBoard1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmChooser";
            this.RoundCorners = true;
            this.ShowCloseButton = false;
            this.ShowDeleteButton = false;
            this.ShowMaxmizeButton = false;
            this.ShowMinimizeButton = false;
            this.Text = "Zer0ne";
            this.Load += new System.EventHandler(this.frmChooser_Load);
            this.Controls.SetChildIndex(this.pnlBtns, 0);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.listBox1, 0);
            this.Controls.SetChildIndex(this.keyBoard1, 0);
            this.pnlBtns.ResumeLayout(false);
            this.pnlTitel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private Controls.ZListBox listBox1;
        internal DevComponents.DotNetBar.Keyboard.KeyboardControl keyBoard1;
    }
}