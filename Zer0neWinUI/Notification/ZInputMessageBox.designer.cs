
namespace Zer0ne.WinUI.Notifications
{
    partial class ZInputMessageBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.keyBoard1 = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.pnlTitel.SuspendLayout();
            this.pnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Size = new System.Drawing.Size(427, 44);
            this.pnlTitel.Text = "frmInputMessageBox";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Size = new System.Drawing.Size(42, 44);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Size = new System.Drawing.Size(42, 44);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0; 
            this.btnSave.Location = new System.Drawing.Point(301, 0);
            this.btnSave.Text = "موافق";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0; 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExit.Text = "إلغــاء   ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlBtns
            // 
            this.pnlBtns.Location = new System.Drawing.Point(0, 388);
            this.pnlBtns.Size = new System.Drawing.Size(427, 55);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 0; 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(126, 0);
            this.btnDelete.Size = new System.Drawing.Size(175, 55);
            this.btnDelete.Text = "-------------";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Size = new System.Drawing.Size(42, 44);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textBox1.Location = new System.Drawing.Point(5, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(413, 53);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 26F);
            this.numericUpDown1.Location = new System.Drawing.Point(12, 109);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(399, 45);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.Enter += new System.EventHandler(this.numericUpDown1_Enter);
            // 
            // keyBoard1
            // 
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
            this.keyBoard1.Location = new System.Drawing.Point(5, 160);
            this.keyBoard1.Name = "keyBoard1";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.keyBoard1.Renderer = flatStyleRenderer1;
            this.keyBoard1.Size = new System.Drawing.Size(413, 222);
            this.keyBoard1.TabIndex = 15;
            this.keyBoard1.TabStop = false;
            this.keyBoard1.Text = "Zer0ne Keyboard";
            // 
            // frmInputMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 443);
            this.Controls.Add(this.keyBoard1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmInputMessageBox";
            this.RoundCorners = true;
            this.ShowCloseButton = false;
            this.ShowMaxmizeButton = false;
            this.ShowMinimizeButton = false;
            this.Text = "Zer0ne"; 
            this.Load += new System.EventHandler(this.frmInputMessageBox_Load);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.Controls.SetChildIndex(this.pnlBtns, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.Controls.SetChildIndex(this.keyBoard1, 0);
            this.pnlTitel.ResumeLayout(false);
            this.pnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        internal DevComponents.DotNetBar.Keyboard.KeyboardControl keyBoard1;
    }
}