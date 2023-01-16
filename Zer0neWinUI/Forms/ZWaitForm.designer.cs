
namespace Zer0ne.WinUI.Forms
{
    partial class ZWaitForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Margin = new System.Windows.Forms.Padding(3);
            this.pnlTitel.Size = new System.Drawing.Size(500, 37);
            this.pnlTitel.Text = "Zer0ne";
            this.pnlTitel.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(459, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3);
            this.btnClose.Size = new System.Drawing.Size(41, 37);
            this.btnClose.Visible = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Location = new System.Drawing.Point(377, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3);
            this.btnMinimize.Size = new System.Drawing.Size(41, 37);
            this.btnMinimize.Visible = false;
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Location = new System.Drawing.Point(418, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(3);
            this.btnMaximize.Size = new System.Drawing.Size(41, 37);
            this.btnMaximize.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-12, -14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ZWaitForm
            // 
            this.ClientSize = new System.Drawing.Size(301, 296);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ZWaitForm";
            this.RoundCorners = true;
            this.ShowTitelPanel = false;
            this.Text = "Zer0ne";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}