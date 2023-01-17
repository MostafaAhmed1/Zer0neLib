
namespace Zer0ne.WinUI.Notifications
{
    partial class ZAlert
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
            this.picType = new Zer0ne.WinUI.Controls.ZPictureBox();
            this.lblMsg = new Zer0ne.WinUI.Controls.ZLabel();
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Size = new System.Drawing.Size(399, 28);
            this.pnlTitel.Text = "Alert";
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
            // picType
            // 
            this.picType.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.picType.BorderCornerStyle = Zer0ne.WinUI.Utilities.BorderMode.RoundedCorners;
            this.picType.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picType.BorderSize = 0;
            this.picType.GradientAngle = 30F;
            this.picType.Location = new System.Drawing.Point(3, 53);
            this.picType.Name = "picType";
            this.picType.Radius = 0;
            this.picType.Size = new System.Drawing.Size(47, 47);
            this.picType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picType.TabIndex = 0;
            this.picType.TabStop = false;
            this.picType.Click += new System.EventHandler(this.picType_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(56, 29);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(342, 107);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "label1";
            // 
            // ZAlert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(399, 138);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.picType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ZAlert";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowCloseButton = false;
            this.ShowIcon = false;
            this.ShowMaxmizeButton = false;
            this.ShowMinimizeButton = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Alert";
            this.Load += new System.EventHandler(this.ZAlert_Load);
            this.Controls.SetChildIndex(this.picType, 0);
            this.Controls.SetChildIndex(this.lblMsg, 0);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zer0ne.WinUI.Controls.ZPictureBox picType;
        private Zer0ne.WinUI.Controls.ZLabel lblMsg;
    }
}