using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
    class ColoredCombo : ComboBox
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }
    }
}
