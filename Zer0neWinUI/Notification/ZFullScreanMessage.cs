using System; 
using System.Windows.Forms;
using Zer0ne.WinUI.Notifications;

namespace Zer0ne.WinUI.Notifications
{
    public partial class ZFullScreanMessage : Form
    {
        public string TextZ { get; set; }
        public MessageBoxButtons ButtonZ { get; set; }
        public MessageBoxIcon IconZ { get; set; }
        public DialogResult Result { get; private set; }

        public ZFullScreanMessage()
        {
            InitializeComponent();
        }

        private void frmBack_Load(object sender, EventArgs e)
        {
            var frm = new ZMessageBox(TextZ, ButtonZ, IconZ);
            frm.TopLevel = true;
            frm.Text = "Zer0ne";
            Result = frm.ShowDialog();
            this.Close();
        }
    }
}
