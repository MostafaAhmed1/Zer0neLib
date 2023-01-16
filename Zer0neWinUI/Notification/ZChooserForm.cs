using System;
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Windows.Forms;
using Zer0ne.Data;
using Zer0ne.WinUI.Forms;

namespace Zer0ne.WinUI.Notifications
{
    public partial class frmChooser<T> : ZDataForm where T : class
    {
        public T Result { get; set; }
        public string StringResult { get; set; }

        List<T> lstData;
        string[] arrData;
        string displayProperty;

        public frmChooser(string displayPropertyName)
        {
            InitializeComponent();

            displayProperty = displayPropertyName;
        }

        public frmChooser(string[] values)
        {
            InitializeComponent();

            arrData = values;
        }
         
        private async void frmChooser_Load(object sender, EventArgs e)
        {
            keyBoard1.Keyboard = ZTheme.DevFullKeyboard();

            if (arrData != null && arrData.Length >= 0)
            {
                listBox1.Items.AddRange(arrData);
            }
            else
            {
                var tbl = new Table<T>();
                lstData = await tbl.GtAllAsync();
                var lst = (from a in lstData select a.GetType().GetProperty(displayProperty).GetValue(a)).ToArray();
                listBox1.Items.AddRange(lst);
            }
            txtSearch.Select();
            txtSearch.Focus();
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (arrData != null && arrData.Length > 0)
            { 
                if (txtSearch.Text.Length > 0)
                {
                    var lst = (from d in arrData where d.Contains(txtSearch.Text) select d).ToArray();
                    listBox1.Items.AddRange(lst);
                }
                else
                {
                    listBox1.Items.AddRange(arrData);
                }
                return;
            }

            if (txtSearch.Text.Length > 0)
            {
                var lst = (from a in lstData
                           where a.GetType().GetProperty(displayProperty).GetValue(a).ToString().Contains(txtSearch.Text)
                           select a.GetType().GetProperty(displayProperty).GetValue(a)).ToArray();
                listBox1.Items.AddRange(lst);
            }
            else
            {
                var lst = (from a in lstData select a.GetType().GetProperty(displayProperty).GetValue(a)).ToArray();
                listBox1.Items.AddRange(lst);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (arrData != null && arrData.Length > 0)
                {
                    StringResult = arrData[listBox1.SelectedIndex];
                }
                else
                {
                    Result = lstData[listBox1.SelectedIndex];
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBox.Msg("يرجى اختيار بيان من القائمة");
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
