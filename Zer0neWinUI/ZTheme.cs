using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar.Keyboard;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI
{
    public static class ZTheme
    {
        public static Font Fontz = new Font("Tahoma", 14F);
        public static Color BacgroundColor = Color.Aqua;
        public static Color SecondaryColor = Color.FromArgb(2, 205, 245);
        public static Color ThirdColor = Color.FromArgb(2, 205, 245);
        public static Color AccentColor = Color.FromArgb(25, 118, 216);
        public static Color TextColor = Color.White;
        public static Color HintColor = Color.Silver;
        public static Color SelectColor = Color.Aquamarine;
        public static ZControlStyle ControlStyle = new ZControlStyle()
        {
            GradientAngle = 30,
            BorderSize = 0,
            BorderCapStyle = DashCap.Flat,
            BorderLineStyle = DashStyle.Solid,
            Radius = 0,
            BorderCornersStyle = BorderMode.RoundedCorners,
            BackColor = SecondaryColor,
            TextColor = TextColor,
            GradientColor1 = AccentColor,
            GradientColor2 = SelectColor,
            ActiveColor = SelectColor,
            InactiveColor = ThirdColor,
            HintColor = HintColor
        };

        private static Languages language;
        public static Languages Language
        {
            get
            {
                if (language == null)
                {
                    language = new Languages();
                    language.DicLang = new Dictionary<string, string>();
                }
                return language;
            }
            set => language = value;
        }

        #region Images
        private static Image saveImage = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.save_48px, Color.Black, Color.Green); //  Properties.Resources.save_48px;
        public static Image SaveImage
        {
            get
            {
                return saveImage;
            }
            set
            {
                saveImage = value;
            }
        }

        private static Image shutDownImage = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.exit_48px, Color.Black, Color.Red ); //Properties.Resources.exit_48px ;
        public static Image ShutDownImage
        {
            get
            {
                return shutDownImage;
            }
            set
            {
                shutDownImage = value;
            }
        }

        private static Image plusImage = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.Plus, Color.Black, Color.SeaGreen ); //Properties.Resources.Plus ;
        public static Image PlusImage
        {
            get
            {
                return plusImage;
            }
            set
            {
                plusImage = value;
            }
        }

        private static Image searchImage = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.Search, Color.Black, Color.SeaGreen); //Properties.Resources.Search ;
        public static Image SearchImage
        {
            get
            {
                return searchImage;
            }
            set
            {
                searchImage = value;
            }
        }

        private static Image deleteImage = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.Delete_48px, Color.Black, Color.Red); //Properties.Resources.Delete_48px ;
        public static Image DeleteImage
        {
            get
            {
                return deleteImage;
            }
            set
            {
                deleteImage = value;
            }
        }

        private static Image editImage = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.pen, Color.Black, Color.DeepSkyBlue); //Properties.Resources.pen;
        public static Image EditImage
        {
            get
            {
                return editImage;
            }
            set
            {
                editImage = value;
            }
        }

        private static Image chkAll = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.chkList, Color.Black, Color.DarkSlateBlue); //Properties.Resources.pen;
        public static Image ChekedAll
        {
            get
            {
                return chkAll;
            }
            set
            {
                chkAll = value;
            }
        }

        private static Image unchkAll = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.unChkList, Color.Black, Color.DarkGray); //Properties.Resources.pen;
        public static Image UnChekedAll
        {
            get
            {
                return unchkAll;
            }
            set
            {
                unchkAll = value;
            }
        }

        private static Image calender = Zer0ne.WinUI.ZTheme.ReplaceColor(Properties.Resources.Calender_32px, Color.Black, Color.SeaGreen); //Properties.Resources.Plus ;
        public static Image CalenderImage
        {
            get
            {
                return calender;
            }
            set
            {
                calender = value;
            }
        }

        #endregion
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius, CornerZ edges)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            if ((CornerZ.TopLeft & edges) == CornerZ.TopLeft)
            {
                path.AddArc(arc, 180, 90);
            }
            else
            {
                path.AddLine(bounds.Left, bounds.Top + radius, bounds.Left, bounds.Top);
                path.AddLine(bounds.Left, bounds.Top, bounds.Left + radius, bounds.Top);
            }

            // top right arc  
            if ((CornerZ.TopRight & edges) == CornerZ.TopRight)
            {
                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90);
            }
            else
            {
                path.AddLine(bounds.Right - radius, bounds.Top, bounds.Right, bounds.Top);
                path.AddLine(bounds.Right, bounds.Top, bounds.Right, bounds.Top + radius);
            }


            // bottom right arc
            if ((CornerZ.BottomRight & edges) == CornerZ.BottomRight)
            {
                arc.X = bounds.Right - diameter;
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);
            }
            else
            {
                path.AddLine(bounds.Right, bounds.Bottom - radius, bounds.Right, bounds.Bottom);
                path.AddLine(bounds.Right, bounds.Bottom, bounds.Right - radius, bounds.Bottom);
            }


            // bottom left arc 

            if ((CornerZ.BottomLeft & edges) == CornerZ.BottomLeft)
            {
                arc.X = bounds.Left;
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 90, 90);
            }
            else
            {
                path.AddLine(bounds.Left + radius, bounds.Bottom, bounds.Left, bounds.Bottom);
                path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Bottom - radius);

            }

            path.CloseFigure();
            return path;
        }

        public static Bitmap ReplaceColor(Bitmap bmp, Color oldColor, Color newColor)
        {
            var lockedBitmap = new LockBitmap(bmp);
            lockedBitmap.LockBits();

            for (int y = 0; y < lockedBitmap.Height; y++)
            {
                for (int x = 0; x < lockedBitmap.Width; x++)
                {
                    Color tkn = lockedBitmap.GetPixel(x, y);
                    if (tkn == oldColor)
                    {
                        lockedBitmap.SetPixel(x, y, newColor);
                    }
                    else if (tkn.R == oldColor.R && tkn.G == oldColor.G && tkn.B == oldColor.B)
                    {
                        Color c = Color.FromArgb(tkn.A, newColor.R, newColor.G, newColor.B);
                        lockedBitmap.SetPixel(x, y, c);
                    }
                }
            }
            lockedBitmap.UnlockBits();

            return bmp;
        }

        public static Keyboard DevFullKeyboard()
        {
            var keyboard = new Keyboard();

            // Actually there are 4 layout objects, 
            // but for code simplicity this variable is reused for creating each of them.
            LinearKeyboardLayout kc;

            #region Normal style configuration (no modifier keys pressed)

            kc = new LinearKeyboardLayout();
            keyboard.Layouts.Add(kc);

            kc.AddKey("ض");
            kc.AddKey("ص");
            kc.AddKey("ث");
            kc.AddKey("ق");
            kc.AddKey("ف");
            kc.AddKey("غ");
            kc.AddKey("ع");
            kc.AddKey("ه");
            kc.AddKey("خ");
            kc.AddKey("ح");
            kc.AddKey("ج");
            kc.AddKey("د");
            kc.AddKey("Backspace", "{BACKSPACE}", "", 21);

            kc.AddLine();
            kc.AddSpace(1);

            kc.AddKey("ش");
            kc.AddKey("س");
            kc.AddKey("ي");
            kc.AddKey("ب");
            kc.AddKey("ل");
            kc.AddKey("ا");
            kc.AddKey("ت");
            kc.AddKey("ن");
            kc.AddKey("م");
            kc.AddKey("ك");
            kc.AddKey("ط");
            kc.AddKey("ذ");
            kc.AddKey("Enter" + Environment.NewLine + "↲", "{ENTER}", "", 19, 22);

            kc.AddLine();

            kc.AddSpace(10);
            kc.AddKey("ئ");
            kc.AddKey("ء");
            kc.AddKey("ؤ");
            kc.AddKey("ر");
            kc.AddKey("لا");
            kc.AddKey("ى");
            kc.AddKey("ة");
            kc.AddKey("و");
            kc.AddKey("ز");
            kc.AddKey("ظ");

            kc.AddLine();

            kc.AddKey("Ctrl", info: "", style: KeyStyle.Dark, layout: 3);
            kc.AddKey("&123", info: "", style: KeyStyle.Dark, layout: 4);
            kc.AddKey(":-)", info: ":-{)}", style: KeyStyle.Dark);
            kc.AddKey(" ", width: 76);
            kc.AddKey("EN", info: "{RIGHT}", style: KeyStyle.Dark, layout: 1);

            #endregion

            #region En Lang Layout

            kc = new LinearKeyboardLayout();
            keyboard.Layouts.Add(kc);

            kc.AddKey("q");
            kc.AddKey("w");
            kc.AddKey("e");
            kc.AddKey("r");
            kc.AddKey("t");
            kc.AddKey("y");
            kc.AddKey("u");
            kc.AddKey("i");
            kc.AddKey("o");
            kc.AddKey("p");
            kc.AddKey("Backspace", info: "{BACKSPACE}", width: 21);

            kc.AddLine();
            kc.AddSpace(4);

            kc.AddKey("a");
            kc.AddKey("s");
            kc.AddKey("d");
            kc.AddKey("f");
            kc.AddKey("g");
            kc.AddKey("h");
            kc.AddKey("j");
            kc.AddKey("k");
            kc.AddKey("l");
            kc.AddKey(@"""");
            kc.AddKey("Enter", info: "{ENTER}", width: 17);

            kc.AddLine();

            kc.AddKey("Shift", info: "", style: KeyStyle.Pressed, layout: 2);
            kc.AddKey("z");
            kc.AddKey("x");
            kc.AddKey("c");
            kc.AddKey("v");
            kc.AddKey("b");
            kc.AddKey("n");
            kc.AddKey("m");
            kc.AddKey(";");
            kc.AddKey(":");
            kc.AddKey("!");
            kc.AddKey("Shift", info: "", style: KeyStyle.Pressed, layout: 2);

            kc.AddLine();

            kc.AddKey("Ctrl", info: "", style: KeyStyle.Dark, layout: 3);
            kc.AddKey("&123", info: "", style: KeyStyle.Dark, layout: 4);
            kc.AddKey(":-)", info: ":-{)}", style: KeyStyle.Dark);
            kc.AddKey(" ", width: 76);
            kc.AddKey("AR", info: "{RIGHT}", style: KeyStyle.Dark, layout: 0);

            #endregion

            #region En Shift pressed

            kc = new LinearKeyboardLayout();
            keyboard.Layouts.Add(kc);

            kc.AddKey("Q");
            kc.AddKey("W");
            kc.AddKey("E");
            kc.AddKey("R");
            kc.AddKey("T");
            kc.AddKey("Y");
            kc.AddKey("U");
            kc.AddKey("I");
            kc.AddKey("O");
            kc.AddKey("P");
            kc.AddKey("Backspace", info: "{BACKSPACE}", width: 21);

            kc.AddLine();
            kc.AddSpace(4);

            kc.AddKey("A");
            kc.AddKey("S");
            kc.AddKey("D");
            kc.AddKey("F");
            kc.AddKey("G");
            kc.AddKey("H");
            kc.AddKey("J");
            kc.AddKey("K");
            kc.AddKey("L");
            kc.AddKey("//");
            kc.AddKey("Enter", info: "{ENTER}", width: 17);

            kc.AddLine();

            kc.AddKey("Shift", info: "", style: KeyStyle.Toggled, layout: 1);
            kc.AddKey("Z");
            kc.AddKey("X");
            kc.AddKey("C");
            kc.AddKey("V");
            kc.AddKey("B");
            kc.AddKey("N");
            kc.AddKey("M");
            kc.AddKey(",");
            kc.AddKey(".");
            kc.AddKey("?");
            kc.AddKey("Shift", info: "", style: KeyStyle.Toggled, layout: 1);

            kc.AddLine();

            kc.AddKey("Ctrl", info: "", style: KeyStyle.Dark, layout: 3);
            kc.AddKey("&123", info: "", style: KeyStyle.Dark, layout: 4);
            kc.AddKey(" ", width: 85);
            kc.AddKey("AR", info: "{RIGHT}", style: KeyStyle.Dark, layout: 0);

            #endregion

            #region Ctrl modifier pressed

            kc = new LinearKeyboardLayout();
            keyboard.Layouts.Add(kc);

            kc.AddKey("q", info: "^q", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("w", info: "^w", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("e", info: "^e", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("r", info: "^r", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("t", info: "^t", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("y", info: "^y", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("u", info: "^u", hint: "Underline", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("i", info: "^i", hint: "Italic", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("o", info: "^o", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("p", info: "^p", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("Backspace", info: "^{BACKSPACE}", width: 21, layout: KeyboardLayout.PreviousLayout);

            kc.AddLine();
            kc.AddSpace(4);

            kc.AddKey("a", info: "^a", hint: "Select all", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("s", info: "^s", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("d", info: "^d", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("f", info: "^f", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("g", info: "^g", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("h", info: "^h", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("j", info: "^j", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("k", info: "^k", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("l", info: "^l", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("'", info: "^'", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("Enter", info: "^{ENTER}", width: 17, layout: KeyboardLayout.PreviousLayout);

            kc.AddLine();

            kc.AddKey("Shift", info: "", layout: 1);
            kc.AddKey("z", info: "^z", hint: "Undo", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("x", info: "^x", hint: "Cut", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("c", info: "^c", hint: "Copy", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("v", info: "^v", hint: "Paste", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("b", info: "^b", hint: "Bold", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("n", info: "^n", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("m", info: "^m", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey(",", info: "^,", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey(".", info: "^.", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("?", info: "^?", layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("Shift", info: "", layout: 1);

            kc.AddLine();

            kc.AddKey("Ctrl", info: "", style: KeyStyle.Pressed, layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("&123", info: "", style: KeyStyle.Dark, layout: 3);
            kc.AddKey(":-)", info: "^:-{)}", style: KeyStyle.Dark, layout: KeyboardLayout.PreviousLayout);
            kc.AddKey(" ", info: "^ ", width: 76, layout: KeyboardLayout.PreviousLayout);
            kc.AddKey("<", info: "^{LEFT}", style: KeyStyle.Dark, layout: KeyboardLayout.PreviousLayout);
            kc.AddKey(">", info: "^{RIGHT}", style: KeyStyle.Dark, layout: KeyboardLayout.PreviousLayout);

            #endregion

            #region Symbols and numbers (&123) modifier pressed

            kc = new LinearKeyboardLayout();
            keyboard.Layouts.Add(kc);

            kc.AddKey("!");
            kc.AddKey("@");
            kc.AddKey("#");
            kc.AddKey("$");
            kc.AddKey("½");
            kc.AddKey("-");
            kc.AddKey("+", info: "{+}");

            kc.AddSpace(5);

            kc.AddKey("1", style: KeyStyle.Light);
            kc.AddKey("2", style: KeyStyle.Light);
            kc.AddKey("3", style: KeyStyle.Light);

            kc.AddSpace(5);

            kc.AddKey("Bcks", info: "{BACKSPACE}", style: KeyStyle.Dark);

            kc.AddLine();

            // second line
            kc.AddKey(";");
            kc.AddKey(":");
            kc.AddKey(@"""");
            kc.AddKey("%", info: "{%}");
            kc.AddKey("&");
            kc.AddKey("/");
            kc.AddKey("*");

            kc.AddSpace(5);

            kc.AddKey("4", style: KeyStyle.Light);
            kc.AddKey("5", style: KeyStyle.Light);
            kc.AddKey("6", style: KeyStyle.Light);

            kc.AddSpace(5);

            kc.AddKey("Enter", info: "{ENTER}", style: KeyStyle.Dark);

            kc.AddLine();

            // third line
            kc.AddKey("(", info: "{(}");
            kc.AddKey(")", info: "{)}");
            kc.AddKey("[", info: "{[}");
            kc.AddKey("]", info: "{]}");
            kc.AddKey("_");
            kc.AddKey("\\");
            kc.AddKey("=");

            kc.AddSpace(5);

            kc.AddKey("7", style: KeyStyle.Light);
            kc.AddKey("8", style: KeyStyle.Light);
            kc.AddKey("9", style: KeyStyle.Light);

            kc.AddSpace(5);

            kc.AddKey("Tab", info: "{TAB}", style: KeyStyle.Dark);

            kc.AddLine();

            // forth line
            kc.AddKey("...", style: KeyStyle.Dark);
            kc.AddKey("&123", info: "", style: KeyStyle.Pressed);
            kc.AddKey(":-)", info: ":-{)}", style: KeyStyle.Dark);
            kc.AddKey("<", info: "{LEFT}", style: KeyStyle.Dark);
            kc.AddKey(">", info: "{RIGHT}", style: KeyStyle.Dark);
            kc.AddKey("Space", info: "^ ", width: 21);

            kc.AddSpace(5);

            kc.AddKey("0", style: KeyStyle.Light, width: 21);
            kc.AddKey(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, style: KeyStyle.Dark);

            kc.AddSpace(5);

            kc.AddKey("AR", layout: 0, style: KeyStyle.Dark);

            kc.AddLine();

            #endregion

            return keyboard;
        }

        public static Keyboard DevNumericKeyboard()
        {
            var keyboard = new Keyboard();

            // Actually there are 4 layout objects, 
            // but for code simplicity this variable is reused for creating each of them.
            LinearKeyboardLayout kc;

            #region Symbols and numbers (&123) modifier pressed

            kc = new LinearKeyboardLayout();
            keyboard.Layouts.Add(kc);

            kc.AddKey("1", style: KeyStyle.Light);
            kc.AddKey("2", style: KeyStyle.Light);
            kc.AddKey("3", style: KeyStyle.Light);

            kc.AddSpace(5);

            kc.AddKey("Bcks", info: "{BACKSPACE}", style: KeyStyle.Dark);

            kc.AddLine();

            // second line 
            kc.AddKey("4", style: KeyStyle.Light);
            kc.AddKey("5", style: KeyStyle.Light);
            kc.AddKey("6", style: KeyStyle.Light);

            kc.AddSpace(5);

            kc.AddKey("Enter", info: "{ENTER}", style: KeyStyle.Dark);

            kc.AddLine();

            // third line 
            kc.AddKey("7", style: KeyStyle.Light);
            kc.AddKey("8", style: KeyStyle.Light);
            kc.AddKey("9", style: KeyStyle.Light);

            kc.AddSpace(5);
            kc.AddKey(">", info: "^{RIGHT}", style: KeyStyle.Dark, layout: KeyboardLayout.PreviousLayout);

            kc.AddLine();

            // forth line 
            kc.AddKey("0", style: KeyStyle.Light, width: 21);
            kc.AddKey(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, style: KeyStyle.Dark);

            kc.AddSpace(5);
            kc.AddKey("<", info: "^{LEFT}", style: KeyStyle.Dark, layout: KeyboardLayout.PreviousLayout);

            kc.AddLine();

            #endregion

            return keyboard;
        }

    }
}
