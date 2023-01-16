using System.Drawing;
using System.Windows.Forms;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI.Controls
{
    public interface IControlZ
    {
        ZControlStyle ZStyle { get; set; }
        Font Font { get; set; }
        Color BackColor { get; set; }
        Color ForeColor { get; set; }
        int Radius { get; set; }
        int BorderSize { get; set; }
        string Text { get; set; }
        string ErrorText { get; set; } 
        bool ReadOnly { get; set; }
        CornerZ RoundedCorners { get; set; }
    }
}
