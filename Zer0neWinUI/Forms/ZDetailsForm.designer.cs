
using Zer0ne.WinUI.Controls;

namespace Zer0ne.WinUI.Forms
{
    partial class ZDetailsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new ZPanel();
            this.txtSearchAll = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAddNew = new Zer0ne.WinUI.Controls.ZButton();
            this.pnlUnder = new ZPanel();
            this.grd = new ZGridView();
            this.pnlTitel.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Location = new System.Drawing.Point(3, 3);
            this.pnlTitel.Margin = new System.Windows.Forms.Padding(3);
            this.pnlTitel.Size = new System.Drawing.Size(931, 43);
            this.pnlTitel.Text = "DevDetailsForm";
            //
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(903, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3);
            this.btnClose.Size = new System.Drawing.Size(28, 43);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Location = new System.Drawing.Point(428, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3);
            this.btnMinimize.Size = new System.Drawing.Size(28, 43);
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Location = new System.Drawing.Point(456, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(3);
            this.btnMaximize.Size = new System.Drawing.Size(28, 43);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.pnlTop.Controls.Add(this.txtSearchAll);
            this.pnlTop.Controls.Add(this.btnAddNew);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 46);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(931, 79);
            this.pnlTop.TabIndex = 11;
            // 
            // txtSearchAll
            // 
            this.txtSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchAll.AutoSelectAll = true;
            this.txtSearchAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            // 
            // 
            // 
            this.txtSearchAll.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSearchAll.Border.BorderColor = System.Drawing.Color.Azure;
            this.txtSearchAll.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSearchAll.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSearchAll.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSearchAll.Border.Class = "TextBoxBorder";
            this.txtSearchAll.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.txtSearchAll.Border.TextColor = System.Drawing.Color.Coral;
            this.txtSearchAll.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearchAll.ForeColor = System.Drawing.Color.Black;
            this.txtSearchAll.Location = new System.Drawing.Point(16, 28);
            this.txtSearchAll.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchAll.MinimumSize = new System.Drawing.Size(400, 0);
            this.txtSearchAll.Name = "txtSearchAll";
            this.txtSearchAll.PreventEnterBeep = true;
            this.txtSearchAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearchAll.Size = new System.Drawing.Size(400, 41);
            this.txtSearchAll.TabIndex = 1;
            this.txtSearchAll.WatermarkColor = System.Drawing.Color.Silver;
            this.txtSearchAll.WatermarkText = "ما الذى تبحث عنه ...";
            this.txtSearchAll.TextChanged += new System.EventHandler(this.txtSearchAll_TextChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat; 
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.Location = new System.Drawing.Point(760, 16);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(155, 54);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "إضــافة";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // pnlUnder
            // 
            this.pnlUnder.AutoScroll = true;
            this.pnlUnder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUnder.Location = new System.Drawing.Point(3, 389);
            this.pnlUnder.Margin = new System.Windows.Forms.Padding(4);
            this.pnlUnder.Name = "pnlUnder";
            this.pnlUnder.Size = new System.Drawing.Size(931, 114);
            this.pnlUnder.TabIndex = 12;
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(3, 125);
            this.grd.Margin = new System.Windows.Forms.Padding(4);
            this.grd.Name = "grd";
            this.grd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grd.RowHeadersVisible = false;
            this.grd.RowTemplate.Height = 40;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd.Size = new System.Drawing.Size(931, 264);
            this.grd.TabIndex = 13;
            this.grd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CellContentClick);
            this.grd.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grd_DataError);
            // 
            // ZDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.ClientSize = new System.Drawing.Size(937, 506);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.pnlUnder);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.MinimumSize = new System.Drawing.Size(635, 39);
            this.Name = "ZDetailsForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowMaxmizeButton = false;
            this.ShowMinimizeButton = false;
            this.Text = "Zer0ne"; 
            this.Load += new System.EventHandler(this.FrmUsersGrd_Load);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlUnder, 0);
            this.Controls.SetChildIndex(this.grd, 0);
            this.pnlTitel.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZPanel pnlTop;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtSearchAll;
        private ZButton btnAddNew;
        private ZPanel pnlUnder;
        internal ZGridView grd;
    }
}