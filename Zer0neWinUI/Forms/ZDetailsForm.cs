using System;
using System.Collections.Generic; 
using System.Drawing; 
using System.Windows.Forms;
using Zer0ne.WinUI.Controls;

namespace Zer0ne.WinUI.Forms
{
    public partial class ZDetailsForm : ZForm
    {
        public event EventHandler<DevFormDetailsEvent> OnFormLoad;
        public event EventHandler<DevFormDetailsEvent> OnAddNewClicked;
        public event EventHandler<DevFormDetailsEvent> OnSearch;
        public event EventHandler<DevFormDetailsEvent> OnGridCellCliced;

        List<ZButton> lstOptions;
        List<Label> lstAnalytics;

        System.Timers.Timer tmr;
        byte tmrFlg;

        public bool ShowAddButton
        {
            get
            {
                return btnAddNew.Visible;
            }
            set
            {
                btnAddNew.Visible = value;
            }
        }

        public bool ShowBottomPanel
        {
            get
            {
                return pnlUnder.Visible;
            }
            set
            {
                pnlUnder.Visible = value;
            }
        }

        public ZDetailsForm(Dictionary<string, DataGridViewColumn> columnsTextType)
        {
            InitializeComponent();

            tmr = new System.Timers.Timer();
            tmr.Interval = 500;
            tmr.Elapsed += Tmr_Elapsed;
            tmr.Enabled = false;
            tmrFlg = 0;

            lstOptions = new List<ZButton>();
            lstAnalytics = new List<Label>();
            
            pnlTop.BackColor = ZTheme.SecondaryColor;
            txtSearchAll.BackColor = ZTheme.SecondaryColor;
            txtSearchAll.WatermarkColor = ZTheme.AccentColor;
            txtSearchAll.Border.BorderColor = ZTheme.AccentColor;


            AddGridColumns(columnsTextType);
        }

        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tmrFlg >= 3)
            {
                tmr.Enabled = false;
                OnSearch?.Invoke(this, new DevFormDetailsEvent() { GridView = grd, TextSearch = txtSearchAll });
            }
            tmrFlg += 1;
        }

        public Action<object> FillGridAction;

        public void FillGrid<T>(List<T> data)
        {
            grd.Rows.Clear();
            FillGridAction.Invoke(data);
        }

        void AddGridColumns(Dictionary<string, DataGridViewColumn> columns)
        {
            foreach (var c in columns)
            {
                c.Value.HeaderText = c.Key;
                c.Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                grd.Columns.Add(c.Value);
            }
        }

        private void FrmUsersGrd_Load(object sender, EventArgs e)
        {
            OnFormLoad?.Invoke(this, new DevFormDetailsEvent() { GridView = grd, TextSearch = txtSearchAll });
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            OnAddNewClicked?.Invoke(this, new DevFormDetailsEvent() { GridView = grd, TextSearch = txtSearchAll });
        }
         
        private void txtSearchAll_TextChanged(object sender, EventArgs e)
        {
            if (tmr.Enabled == false)
            {
                tmr.Enabled = true;
            }
            tmrFlg = 0;
        }

        public void AddAnalytic(string text)
        {
            var lbl = new Label();
            lbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl.Location = new Point(740 - (155 * lstAnalytics.Count), 12);
            lbl.Name = "lbl" + lstAnalytics.Count.ToString();
            lbl.Size = new Size(150, 49);
            lbl.TabIndex = 0;
            lbl.Text = text;
            lbl.RightToLeft = RightToLeft.Yes;
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            pnlUnder.Controls.Add(lbl);
            lstAnalytics.Add(lbl);
            pnlUnder.Visible = true;
        }

        public void AddOption(string text, EventHandler action)
        {  
            var btn = new ZButton();
            btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //btn.BackColor = ZTheme.AccentColor;
            //btn.ForeColor = ZTheme.BacgroundColor;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat; 
            btn.ImageAlign = ContentAlignment.MiddleRight;
            btn.Name = "btn" + lstOptions.Count.ToString();
            btn.Size = new Size(136, 48);
            btn.TabIndex = 0;
            btn.Text = text;
            btn.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn.UseVisualStyleBackColor = false;
            btn.Location = new Point(750 - (141 * lstOptions.Count), 68);
            btn.Click += action;
            pnlUnder.Controls.Add(btn);

            lstOptions.Add(btn);
        }

        private void grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OnGridCellCliced?.Invoke(this, new DevFormDetailsEvent() { GridView = grd, gridViewCellEventArgs = e, TextSearch = txtSearchAll });
        }
    }

    public class DevFormDetailsEvent : EventArgs
    {
        public DataGridView GridView { get; set; }
        public TextBox TextSearch { get; set; }
        public DataGridViewCellEventArgs gridViewCellEventArgs { get; set; }

    }
}
