
namespace Zer0ne.WinUI.Notifications
{
    partial class ZMessageBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlBtns.SuspendLayout();
            this.pnlTitel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new System.Drawing.Point(416, 1);
            this.btnSave.Size = new System.Drawing.Size(128, 55);
            this.btnSave.Text = "نعم";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExit.Size = new System.Drawing.Size(138, 55);
            this.btnExit.Text = "لا      ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Image = global::Zer0ne.WinUI.Properties.Resources.checkmark_32px;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(139, 1);
            this.btnDelete.Size = new System.Drawing.Size(277, 55);
            this.btnDelete.Text = "                      موافق";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlBtns
            // 
            this.pnlBtns.Location = new System.Drawing.Point(0, 192);
            this.pnlBtns.Size = new System.Drawing.Size(545, 57);
            // 
            // pnlTitel
            // 
            this.pnlTitel.Size = new System.Drawing.Size(545, 44);
            this.pnlTitel.Text = "Zer0ne";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Size = new System.Drawing.Size(29, 44);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Size = new System.Drawing.Size(29, 44);
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Size = new System.Drawing.Size(30, 44);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textBox1.Location = new System.Drawing.Point(5, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(528, 138);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ZMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(545, 249);
            this.Controls.Add(this.textBox1);
            this.Name = "ZMessageBox";
            this.RoundCorners = true;
            this.ShowCloseButton = false;
            this.ShowMaxmizeButton = false;
            this.ShowMinimizeButton = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zer0ne";
            this.Load += new System.EventHandler(this.frmMessageBox_Load);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.Controls.SetChildIndex(this.pnlBtns, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.pnlBtns.ResumeLayout(false);
            this.pnlTitel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}