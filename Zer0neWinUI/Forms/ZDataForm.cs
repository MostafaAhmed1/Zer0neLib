using System;
using System.ComponentModel;
using System.Drawing; 
using System.Windows.Forms;
using Zer0ne.WinUI.Controls;

namespace Zer0ne.WinUI.Forms
{
    public class ZDataForm : ZForm
    {
        public ZButton btnSave;
        public ZButton btnExit;
        public ZButton btnDelete;
        public ZPanel pnlBtns;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZDataForm));
            this.pnlBtns = new Zer0ne.WinUI.Controls.ZPanel();
            this.btnDelete = new Zer0ne.WinUI.Controls.ZButton();
            this.btnExit = new Zer0ne.WinUI.Controls.ZButton();
            this.btnSave = new Zer0ne.WinUI.Controls.ZButton();
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.pnlBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Size = new System.Drawing.Size(549, 33);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(520, 0);
            this.btnClose.Size = new System.Drawing.Size(29, 33);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Location = new System.Drawing.Point(461, 0);
            this.btnMinimize.Size = new System.Drawing.Size(29, 33);
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Location = new System.Drawing.Point(490, 0);
            this.btnMaximize.Size = new System.Drawing.Size(30, 33);
            // 
            // pnlBtns
            // 
            this.pnlBtns.Controls.Add(this.btnDelete);
            this.pnlBtns.Controls.Add(this.btnExit);
            this.pnlBtns.Controls.Add(this.btnSave);
            this.pnlBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtns.Location = new System.Drawing.Point(0, 328);
            this.pnlBtns.Margin = new System.Windows.Forms.Padding(1);
            this.pnlBtns.Name = "pnlBtns";
            this.pnlBtns.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBtns.ShowTitle = false;
            this.pnlBtns.Size = new System.Drawing.Size(549, 50);
            this.pnlBtns.TabIndex = 10;
            this.pnlBtns.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.BorderSize = 1;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(344, 1);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Radius = 0;
            this.btnDelete.Size = new System.Drawing.Size(105, 48);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "حــذف";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BorderSize = 1;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(1, 1);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 0;
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(124, 48);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "إغـلاق";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderSize = 1;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(449, 1);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 0;
            this.btnSave.Size = new System.Drawing.Size(99, 48);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ZDataForm
            // 
            this.ClientSize = new System.Drawing.Size(549, 378);
            this.Controls.Add(this.pnlBtns);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Name = "ZDataForm";
            this.Load += new System.EventHandler(this.ZDataForm_Load);
            this.Controls.SetChildIndex(this.pnlBtns, 0);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.pnlBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }
         
        bool eb = true;
        [Category("Zer0ne")]
        public bool ShowExitButton
        {
            get
            {
                btnExit.Visible = eb;
                return eb;
            }
            set
            {
                eb = value;
                btnExit.Visible = eb;
            }
        }
         
        bool sb = true;
        [Category("Zer0ne")]
        public bool ShowSaveButton
        {
            get
            {
                btnSave.Visible = sb;
                return sb;
            }
            set
            {
                sb = value;
                btnSave.Visible = sb;
            }
        }

        bool db = true;
        [Category("Zer0ne")]
        public bool ShowDeleteButton
        {
            get
            {
                btnDelete.Visible = db;
                return db;
            }
            set
            {
                db = value;
                btnDelete.Visible = db;
            }
        }
          
        public ZDataForm()
        {
            InitializeComponent();
            pnlBtns.ZStyle = btnClose.ZStyle; 

            btnExit.Image = ZTheme.ReplaceColor(Properties.Resources.exit_48px, Color.FromArgb(255, 0, 0, 0), ZTheme.BacgroundColor); 
            btnSave.Image = ZTheme.ReplaceColor(Properties.Resources.save_48px, Color.FromArgb(255, 0, 0, 0), ZTheme.BacgroundColor);
            btnDelete.Image = ZTheme.ReplaceColor(Properties.Resources.Delete_48px, Color.FromArgb(255, 0, 0, 0), Color.Red);
        }
           
        private void btnExit_Click(object sender, EventArgs e)
        {
            base.btnClose.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void ZDataForm_Load(object sender, EventArgs e)
        {

        }
    }

}
