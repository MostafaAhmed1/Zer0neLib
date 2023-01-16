using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Forms
{
    public partial class ZWaitForm : ZForm
    {
        public event EventHandler OnFormShowed;

        public ZWaitForm()
        {
            InitializeComponent();

            //Create a Bitmpap Object.
            Bitmap animatedImage = new Bitmap(500, 500);
            if (System.IO.File.Exists(Application.StartupPath + @"\Logos\circular.gif"))
            {
                animatedImage = new Bitmap(Application.StartupPath + @"\Logos\circular.gif");
            }
            pictureBox1.Image = animatedImage;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        { 
            OnFormShowed.Invoke(sender, e); 
        }
    }
}
