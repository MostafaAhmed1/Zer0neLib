
using Zer0ne.WinUI.Utilities;

namespace Zer0Test
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode15});
            this.zButton1 = new Zer0ne.WinUI.Controls.ZButton();
            this.zCheckBox1 = new Zer0ne.WinUI.Controls.ZCheckBox();
            this.zDateTime1 = new Zer0ne.WinUI.Controls.ZDatePicker();
            this.zLabel1 = new Zer0ne.WinUI.Controls.ZLabel();
            this.zListBox1 = new Zer0ne.WinUI.Controls.ZListBox();
            this.zNumeric1 = new Zer0ne.WinUI.Controls.ZNumeric();
            this.zPanel1 = new Zer0ne.WinUI.Controls.ZPanel();
            this.zButton2 = new Zer0ne.WinUI.Controls.ZButton();
            this.zPictureBox1 = new Zer0ne.WinUI.Controls.ZPictureBox();
            this.zSplitContainer1 = new Zer0ne.WinUI.Controls.ZSplitContainer();
            this.zTreeView1 = new Zer0ne.WinUI.Controls.ZTreeView();
            this.txtBx1 = new Zer0ne.WinUI.Controls.ZTextBox();
            this.zRadioButton1 = new Zer0ne.WinUI.Controls.ZRadioButton();
            this.zRadioButton2 = new Zer0ne.WinUI.Controls.ZRadioButton();
            this.zToggle1 = new Zer0ne.WinUI.Controls.ZToggle();
            this.zComboBox1 = new Zer0ne.WinUI.Controls.ZComboBox();
            this.zGridView1 = new Zer0ne.WinUI.Controls.ZGridView();
            this.Column1 = new Zer0ne.WinUI.Controls.ZGridTextBoxColumn();
            this.Column2 = new Zer0ne.WinUI.Controls.ZGridTextBoxColumn();
            this.Column3 = new Zer0ne.WinUI.Controls.ZGridTextBoxColumn();
            this.Column4 = new Zer0ne.WinUI.Controls.ZGridTextBoxColumn();
            this.Column5 = new Zer0ne.WinUI.Controls.ZGridTextBoxColumn();
            this.Column6 = new Zer0ne.WinUI.Controls.ZGridTextBoxColumn();
            this.zToggle2 = new Zer0ne.WinUI.Controls.ZToggle();
            this.zTextBox1 = new Zer0ne.WinUI.Controls.ZTextBox();
            this.zTextBox2 = new Zer0ne.WinUI.Controls.ZTextBox();
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).BeginInit();
            this.zPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSplitContainer1)).BeginInit();
            this.zSplitContainer1.Panel1.SuspendLayout();
            this.zSplitContainer1.Panel2.SuspendLayout();
            this.zSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Size = new System.Drawing.Size(1017, 31);
            this.pnlTitel.Text = "Form1";
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Location = new System.Drawing.Point(915, 0);
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Location = new System.Drawing.Point(949, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(983, 0);
            // 
            // zButton1
            // 
            this.zButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zButton1.BorderSize = 1;
            this.zButton1.FlatAppearance.BorderSize = 0;
            this.zButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zButton1.Location = new System.Drawing.Point(203, 8);
            this.zButton1.Name = "zButton1";
            this.zButton1.Radius = 0;
            this.zButton1.Size = new System.Drawing.Size(146, 40);
            this.zButton1.TabIndex = 12;
            this.zButton1.Text = "zButton1";
            this.zButton1.UseVisualStyleBackColor = false;
            this.zButton1.Click += new System.EventHandler(this.zButton1_Click);
            // 
            // zCheckBox1
            // 
            this.zCheckBox1.CheckAlign = Zer0ne.WinUI.Utilities.ItemPositionZ.Right;
            this.zCheckBox1.Location = new System.Drawing.Point(449, 201);
            this.zCheckBox1.Name = "zCheckBox1";
            this.zCheckBox1.Size = new System.Drawing.Size(150, 33);
            this.zCheckBox1.TabIndex = 14;
            this.zCheckBox1.Text = "zCheckBox1";
            this.zCheckBox1.UseVisualStyleBackColor = false;
            // 
            // zDateTime1
            // 
            this.zDateTime1.BorderSize = 2;
            this.zDateTime1.ErrorText = "";
            this.zDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.zDateTime1.Location = new System.Drawing.Point(605, 37);
            this.zDateTime1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.zDateTime1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.zDateTime1.Name = "zDateTime1";
            this.zDateTime1.Radius = 8;
            this.zDateTime1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.zDateTime1.RoundedCorners = ((Zer0ne.WinUI.Utilities.CornerZ)((((Zer0ne.WinUI.Utilities.CornerZ.TopLeft | Zer0ne.WinUI.Utilities.CornerZ.BottomRight) 
            | Zer0ne.WinUI.Utilities.CornerZ.BottomLeft) 
            | Zer0ne.WinUI.Utilities.CornerZ.TopRight)));
            this.zDateTime1.Size = new System.Drawing.Size(400, 59);
            this.zDateTime1.TabIndex = 15;
            this.zDateTime1.TitleAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.zDateTime1.TitleText = " Titel";
            this.zDateTime1.TitleVisible = true;
            this.zDateTime1.Value = new System.DateTime(2023, 1, 15, 18, 11, 2, 280);
            // 
            // zLabel1
            // 
            this.zLabel1.Location = new System.Drawing.Point(449, 158);
            this.zLabel1.Name = "zLabel1";
            this.zLabel1.Size = new System.Drawing.Size(150, 27);
            this.zLabel1.TabIndex = 17;
            this.zLabel1.Text = "zLabel1";
            // 
            // zListBox1
            // 
            this.zListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.zListBox1.ErrorText = "";
            this.zListBox1.FormattingEnabled = true;
            this.zListBox1.IntegralHeight = false;
            this.zListBox1.ItemHeight = 40;
            this.zListBox1.Items.AddRange(new object[] {
            "item 1",
            "item 2",
            "item 3",
            "item 4"});
            this.zListBox1.Location = new System.Drawing.Point(8, 4);
            this.zListBox1.Name = "zListBox1";
            this.zListBox1.Size = new System.Drawing.Size(205, 268);
            this.zListBox1.TabIndex = 18;
            // 
            // zNumeric1
            // 
            this.zNumeric1.BorderSize = 2;
            this.zNumeric1.DecimalPlaces = 0;
            this.zNumeric1.ErrorText = "";
            this.zNumeric1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zNumeric1.Location = new System.Drawing.Point(605, 120);
            this.zNumeric1.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.zNumeric1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.zNumeric1.Name = "zNumeric1";
            this.zNumeric1.Radius = 8;
            this.zNumeric1.ReadOnly = false;
            this.zNumeric1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.zNumeric1.RoundedCorners = ((Zer0ne.WinUI.Utilities.CornerZ)((((Zer0ne.WinUI.Utilities.CornerZ.TopLeft | Zer0ne.WinUI.Utilities.CornerZ.BottomRight) 
            | Zer0ne.WinUI.Utilities.CornerZ.BottomLeft) 
            | Zer0ne.WinUI.Utilities.CornerZ.TopRight)));
            this.zNumeric1.ShowUnit = true;
            this.zNumeric1.Size = new System.Drawing.Size(400, 59);
            this.zNumeric1.TabIndex = 19;
            this.zNumeric1.Text = "0";
            this.zNumeric1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.zNumeric1.TitleAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.zNumeric1.TitleText = " Titel";
            this.zNumeric1.TitleVisible = true;
            this.zNumeric1.Unit = "";
            this.zNumeric1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // zPanel1
            // 
            this.zPanel1.Controls.Add(this.zButton2);
            this.zPanel1.Controls.Add(this.zButton1);
            this.zPanel1.Location = new System.Drawing.Point(19, 484);
            this.zPanel1.Name = "zPanel1";
            this.zPanel1.ShowTitle = false;
            this.zPanel1.Size = new System.Drawing.Size(366, 56);
            this.zPanel1.TabIndex = 20;
            this.zPanel1.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zButton2
            // 
            this.zButton2.BorderSize = 1;
            this.zButton2.FlatAppearance.BorderSize = 0;
            this.zButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zButton2.Location = new System.Drawing.Point(12, 8);
            this.zButton2.Name = "zButton2";
            this.zButton2.Radius = 0;
            this.zButton2.Size = new System.Drawing.Size(133, 40);
            this.zButton2.TabIndex = 24;
            this.zButton2.Text = "zButton2";
            this.zButton2.UseVisualStyleBackColor = false;
            this.zButton2.Click += new System.EventHandler(this.zButton2_Click);
            // 
            // zPictureBox1
            // 
            this.zPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.zPictureBox1.BorderCornerStyle = Zer0ne.WinUI.Utilities.BorderMode.RoundedCorners;
            this.zPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.zPictureBox1.BorderSize = 2;
            this.zPictureBox1.GradientAngle = 30F;
            this.zPictureBox1.Location = new System.Drawing.Point(449, 48);
            this.zPictureBox1.Name = "zPictureBox1";
            this.zPictureBox1.Radius = 25;
            this.zPictureBox1.Size = new System.Drawing.Size(150, 101);
            this.zPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.zPictureBox1.TabIndex = 21;
            this.zPictureBox1.TabStop = false;
            // 
            // zSplitContainer1
            // 
            this.zSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.zSplitContainer1.Location = new System.Drawing.Point(16, 48);
            this.zSplitContainer1.Name = "zSplitContainer1";
            // 
            // zSplitContainer1.Panel1
            // 
            this.zSplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(205)))), ((int)(((byte)(245)))));
            this.zSplitContainer1.Panel1.Controls.Add(this.zTreeView1);
            // 
            // zSplitContainer1.Panel2
            // 
            this.zSplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(205)))), ((int)(((byte)(245)))));
            this.zSplitContainer1.Panel2.Controls.Add(this.zListBox1);
            this.zSplitContainer1.Size = new System.Drawing.Size(427, 274);
            this.zSplitContainer1.SplitterDistance = 189;
            this.zSplitContainer1.SplitterWidth = 10;
            this.zSplitContainer1.TabIndex = 22;
            // 
            // zTreeView1
            // 
            this.zTreeView1.Location = new System.Drawing.Point(3, 3);
            this.zTreeView1.Name = "zTreeView1";
            treeNode9.Name = "Node2";
            treeNode9.Text = "Node2";
            treeNode10.Name = "Node3";
            treeNode10.Text = "Node3";
            treeNode11.Name = "Node0";
            treeNode11.Text = "Node0";
            treeNode12.Name = "Node4";
            treeNode12.Text = "Node4";
            treeNode13.Name = "Node6";
            treeNode13.Text = "Node6";
            treeNode14.Name = "Node7";
            treeNode14.Text = "Node7";
            treeNode15.Name = "Node5";
            treeNode15.Text = "Node5";
            treeNode16.Name = "Node1";
            treeNode16.Text = "Node1";
            this.zTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode16});
            this.zTreeView1.Size = new System.Drawing.Size(169, 268);
            this.zTreeView1.TabIndex = 13;
            // 
            // txtBx1
            // 
            this.txtBx1.BorderSize = 5;
            this.txtBx1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBx1.ErrorText = "";
            this.txtBx1.Location = new System.Drawing.Point(605, 248);
            this.txtBx1.MultiLine = true;
            this.txtBx1.Name = "txtBx1";
            this.txtBx1.PasswordChar = '\0';
            this.txtBx1.Radius = 30;
            this.txtBx1.ReadOnly = false;
            this.txtBx1.RoundedCorners = ((Zer0ne.WinUI.Utilities.CornerZ)((((Zer0ne.WinUI.Utilities.CornerZ.TopLeft | Zer0ne.WinUI.Utilities.CornerZ.BottomRight) 
            | Zer0ne.WinUI.Utilities.CornerZ.BottomLeft) 
            | Zer0ne.WinUI.Utilities.CornerZ.TopRight)));
            this.txtBx1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBx1.Size = new System.Drawing.Size(400, 225);
            this.txtBx1.TabIndex = 26;
            this.txtBx1.Text = "txtBx1";
            this.txtBx1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBx1.TitleAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBx1.TitleText = " Titel";
            this.txtBx1.TitleVisible = true;
            this.txtBx1.ValueType = Zer0ne.WinUI.Utilities.TxtDataType.Strings;
            // 
            // zRadioButton1
            // 
            this.zRadioButton1.AutoSize = true;
            this.zRadioButton1.CheckAlign = Zer0ne.WinUI.Utilities.ItemPositionZ.Right;
            this.zRadioButton1.ErrorText = "";
            this.zRadioButton1.Location = new System.Drawing.Point(451, 240);
            this.zRadioButton1.Name = "zRadioButton1";
            this.zRadioButton1.Size = new System.Drawing.Size(95, 17);
            this.zRadioButton1.TabIndex = 27;
            this.zRadioButton1.TabStop = true;
            this.zRadioButton1.Text = "zRadioButton1";
            this.zRadioButton1.UseVisualStyleBackColor = false;
            // 
            // zRadioButton2
            // 
            this.zRadioButton2.AutoSize = true;
            this.zRadioButton2.CheckAlign = Zer0ne.WinUI.Utilities.ItemPositionZ.Right;
            this.zRadioButton2.ErrorText = "";
            this.zRadioButton2.Location = new System.Drawing.Point(449, 273);
            this.zRadioButton2.Name = "zRadioButton2";
            this.zRadioButton2.Size = new System.Drawing.Size(95, 17);
            this.zRadioButton2.TabIndex = 27;
            this.zRadioButton2.TabStop = true;
            this.zRadioButton2.Text = "zRadioButton1";
            this.zRadioButton2.UseVisualStyleBackColor = false;
            // 
            // zToggle1
            // 
            this.zToggle1.AutoSize = true;
            this.zToggle1.ForeColor = System.Drawing.Color.White;
            this.zToggle1.Location = new System.Drawing.Point(187, 36);
            this.zToggle1.MinimumSize = new System.Drawing.Size(100, 35);
            this.zToggle1.Name = "zToggle1";
            this.zToggle1.OffText = "لا";
            this.zToggle1.OnText = "نعم";
            this.zToggle1.Size = new System.Drawing.Size(100, 35);
            this.zToggle1.TabIndex = 29;
            this.zToggle1.UseVisualStyleBackColor = true;
            this.zToggle1.Value = false;
            this.zToggle1.ValueChanged += new System.EventHandler<bool>(this.zToggle1_ValueChanged);
            // 
            // zComboBox1
            // 
            this.zComboBox1.BorderSize = 2;
            this.zComboBox1.DisplayMember = "";
            this.zComboBox1.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.zComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.zComboBox1.DropDownWidth = 230;
            this.zComboBox1.DroppedDown = false;
            this.zComboBox1.ErrorText = "";
            this.zComboBox1.ItemHeight = 23;
            this.zComboBox1.Location = new System.Drawing.Point(605, 201);
            this.zComboBox1.Name = "zComboBox1";
            this.zComboBox1.Radius = 8;
            this.zComboBox1.RoundedCorners = ((Zer0ne.WinUI.Utilities.CornerZ)((((Zer0ne.WinUI.Utilities.CornerZ.TopLeft | Zer0ne.WinUI.Utilities.CornerZ.BottomRight) 
            | Zer0ne.WinUI.Utilities.CornerZ.BottomLeft) 
            | Zer0ne.WinUI.Utilities.CornerZ.TopRight)));
            this.zComboBox1.Size = new System.Drawing.Size(400, 36);
            this.zComboBox1.TabIndex = 25;
            this.zComboBox1.Text = "zComboBox1";
            this.zComboBox1.TitleAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.zComboBox1.TitleText = " Titel";
            this.zComboBox1.TitleVisible = false;
            this.zComboBox1.ValueMember = "";
            // 
            // zGridView1
            // 
            this.zGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.zGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.zGridView1.EnableHeadersVisualStyles = false;
            this.zGridView1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.zGridView1.Location = new System.Drawing.Point(16, 328);
            this.zGridView1.MultiSelect = false;
            this.zGridView1.Name = "zGridView1";
            this.zGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.zGridView1.RowTemplate.Height = 40;
            this.zGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.zGridView1.Size = new System.Drawing.Size(583, 150);
            this.zGridView1.TabIndex = 28;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // zToggle2
            // 
            this.zToggle2.ForeColor = System.Drawing.Color.White;
            this.zToggle2.Location = new System.Drawing.Point(461, 493);
            this.zToggle2.MinimumSize = new System.Drawing.Size(100, 20);
            this.zToggle2.Name = "zToggle2";
            this.zToggle2.OffText = "لا";
            this.zToggle2.OnText = "نعم";
            this.zToggle2.Size = new System.Drawing.Size(138, 41);
            this.zToggle2.TabIndex = 29;
            this.zToggle2.UseVisualStyleBackColor = true;
            this.zToggle2.Value = false;
            // 
            // zTextBox1
            // 
            this.zTextBox1.BorderSize = 2;
            this.zTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.zTextBox1.ErrorText = "";
            this.zTextBox1.Location = new System.Drawing.Point(646, 493);
            this.zTextBox1.Name = "zTextBox1";
            this.zTextBox1.PasswordChar = '\0';
            this.zTextBox1.Radius = 8;
            this.zTextBox1.ReadOnly = false;
            this.zTextBox1.RoundedCorners = ((Zer0ne.WinUI.Utilities.CornerZ)((((Zer0ne.WinUI.Utilities.CornerZ.TopLeft | Zer0ne.WinUI.Utilities.CornerZ.BottomRight) 
            | Zer0ne.WinUI.Utilities.CornerZ.BottomLeft) 
            | Zer0ne.WinUI.Utilities.CornerZ.TopRight)));
            this.zTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.zTextBox1.Size = new System.Drawing.Size(262, 56);
            this.zTextBox1.TabIndex = 30;
            this.zTextBox1.Text = "zTextBox1";
            this.zTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.zTextBox1.TitleAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.zTextBox1.TitleText = " Titel";
            this.zTextBox1.TitleVisible = true;
            this.zTextBox1.ValueType = Zer0ne.WinUI.Utilities.TxtDataType.Strings;
            // 
            // zTextBox2
            // 
            this.zTextBox2.BorderSize = 2;
            this.zTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.zTextBox2.ErrorText = "";
            this.zTextBox2.Location = new System.Drawing.Point(605, 555);
            this.zTextBox2.Name = "zTextBox2";
            this.zTextBox2.PasswordChar = '\0';
            this.zTextBox2.Radius = 8;
            this.zTextBox2.ReadOnly = false;
            this.zTextBox2.RoundedCorners = ((Zer0ne.WinUI.Utilities.CornerZ)((((Zer0ne.WinUI.Utilities.CornerZ.TopLeft | Zer0ne.WinUI.Utilities.CornerZ.BottomRight) 
            | Zer0ne.WinUI.Utilities.CornerZ.BottomLeft) 
            | Zer0ne.WinUI.Utilities.CornerZ.TopRight)));
            this.zTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.zTextBox2.Size = new System.Drawing.Size(319, 56);
            this.zTextBox2.TabIndex = 31;
            this.zTextBox2.Text = "zTextBox2";
            this.zTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.zTextBox2.TitleAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.zTextBox2.TitleText = " Titel";
            this.zTextBox2.TitleVisible = true;
            this.zTextBox2.ValueType = Zer0ne.WinUI.Utilities.TxtDataType.Strings;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1021, 632);
            this.Controls.Add(this.zTextBox2);
            this.Controls.Add(this.zTextBox1);
            this.Controls.Add(this.zToggle2);
            this.Controls.Add(this.zGridView1);
            this.Controls.Add(this.zRadioButton2);
            this.Controls.Add(this.zRadioButton1);
            this.Controls.Add(this.txtBx1);
            this.Controls.Add(this.zComboBox1);
            this.Controls.Add(this.zSplitContainer1);
            this.Controls.Add(this.zPictureBox1);
            this.Controls.Add(this.zPanel1);
            this.Controls.Add(this.zNumeric1);
            this.Controls.Add(this.zLabel1);
            this.Controls.Add(this.zDateTime1);
            this.Controls.Add(this.zCheckBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.zCheckBox1, 0);
            this.Controls.SetChildIndex(this.zDateTime1, 0);
            this.Controls.SetChildIndex(this.zLabel1, 0);
            this.Controls.SetChildIndex(this.zNumeric1, 0);
            this.Controls.SetChildIndex(this.zPanel1, 0);
            this.Controls.SetChildIndex(this.zPictureBox1, 0);
            this.Controls.SetChildIndex(this.zSplitContainer1, 0);
            this.Controls.SetChildIndex(this.pnlTitel, 0);
            this.Controls.SetChildIndex(this.zComboBox1, 0);
            this.Controls.SetChildIndex(this.txtBx1, 0);
            this.Controls.SetChildIndex(this.zRadioButton1, 0);
            this.Controls.SetChildIndex(this.zRadioButton2, 0);
            this.Controls.SetChildIndex(this.zGridView1, 0);
            this.Controls.SetChildIndex(this.zToggle2, 0);
            this.Controls.SetChildIndex(this.zTextBox1, 0);
            this.Controls.SetChildIndex(this.zTextBox2, 0);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).EndInit();
            this.zPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zPictureBox1)).EndInit();
            this.zSplitContainer1.Panel1.ResumeLayout(false);
            this.zSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zSplitContainer1)).EndInit();
            this.zSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Zer0ne.WinUI.Controls.ZButton zButton1; 
        private Zer0ne.WinUI.Controls.ZCheckBox zCheckBox1;
        private Zer0ne.WinUI.Controls.ZDatePicker zDateTime1;
        private Zer0ne.WinUI.Controls.ZLabel zLabel1;
        private Zer0ne.WinUI.Controls.ZListBox zListBox1;
        private Zer0ne.WinUI.Controls.ZNumeric zNumeric1;
        private Zer0ne.WinUI.Controls.ZPanel zPanel1;
        private Zer0ne.WinUI.Controls.ZPictureBox zPictureBox1;
        private Zer0ne.WinUI.Controls.ZSplitContainer zSplitContainer1;
        private Zer0ne.WinUI.Controls.ZTreeView zTreeView1;
        private Zer0ne.WinUI.Controls.ZButton zButton2;
        private Zer0ne.WinUI.Controls.ZComboBox zComboBox1;
        private Zer0ne.WinUI.Controls.ZTextBox txtBx1;
        private Zer0ne.WinUI.Controls.ZRadioButton zRadioButton1;
        private Zer0ne.WinUI.Controls.ZRadioButton zRadioButton2;
        private Zer0ne.WinUI.Controls.ZToggle zToggle1;
        private Zer0ne.WinUI.Controls.ZGridView zGridView1;
        private Zer0ne.WinUI.Controls.ZGridTextBoxColumn Column1;
        private Zer0ne.WinUI.Controls.ZGridTextBoxColumn Column2;
        private Zer0ne.WinUI.Controls.ZGridTextBoxColumn Column3;
        private Zer0ne.WinUI.Controls.ZGridTextBoxColumn Column4;
        private Zer0ne.WinUI.Controls.ZGridTextBoxColumn Column5;
        private Zer0ne.WinUI.Controls.ZGridTextBoxColumn Column6;
        private Zer0ne.WinUI.Controls.ZToggle zToggle2;
        private Zer0ne.WinUI.Controls.ZTextBox zTextBox1;
        private Zer0ne.WinUI.Controls.ZTextBox zTextBox2;
    }
}

