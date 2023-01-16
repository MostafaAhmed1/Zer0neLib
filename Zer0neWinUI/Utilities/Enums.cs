using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Utilities
{
    public enum PositionZ
    {
        BottomRight = 0,
        TopRight,
        BottomLeft,
        TopLeft,
    }

    public enum ItemPositionZ
    {
        Right,
        Left
    }

    public enum ActionZ
    {
        wait,
        start,
        close
    }
     
    public enum AlertTypeZ
    {
        Success,
        Warning,
        Error,
        Info
    }

    [Flags]
    public enum CornerZ
    {
        None = 0,
        TopLeft = 1,
        BottomRight = 2,
        BottomLeft = 4,
        TopRight = 8,
        All = TopLeft|TopRight|BottomLeft|BottomRight
    }
    
    [Flags]
    public enum SideZ
    {
        None = 0,
        Top = 1,
        Right = 8,
        Left = 4,
        Bottom = 2,
        All = Left | Top | Right | Bottom
    }
    
    public enum TextAlighnZ
    {
        Right = 0,
        Left = 1,
        Center = 3
    }

    public enum TextMode
    {
        None,
        Value,
        Percentage,
    }


    public enum TabStyle
    {
        None = 0,
        Default = 1,
        VisualStudio = 2,
        Rounded = 3,
        Angled = 4,
        Chrome = 5,
        IE8 = 6,
        VS2010 = 7
    }

    public enum TxtDataType
    {
        Strings,
        Phone,
        E_mail,
    }

}
