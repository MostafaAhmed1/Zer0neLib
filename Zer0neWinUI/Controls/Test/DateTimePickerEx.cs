using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Zer0ne.WinUI.Controls
{
     class DateTimePickerEx : DateTimePicker
    {

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
        //        return parms;
        //    }
        //}
        //protected override void OnHandleCreated(EventArgs e)
        //{
        //    base.OnHandleCreated(e);
        //    this.Invalidate();
        //}
        public DateTimePickerEx()
        {
            //this.Format = DateTimePickerFormat.Long;
            //this.SuspendLayout();
            this.RightToLeftLayout = true;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        private const int WM_PAINT = 0x000F;

        private const int SRCPAINT = 0x00EE0086;
        private const int SRCAND = 0x8800C6;
        private const int NOTSRCCOPY = 0x330008;
        private const int SRCCOPY = 0xCC0020;

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hdc,
                                  int nXDest, int nYDest,
                                  int nWidth, int nHeight,
                                  IntPtr hdcSrc,
                                  int nXSrc, int nYSrc,
                                  int dwRop);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            public int reserved1;
            public int reserved2;
            public int reserved3;
            public int reserved4;
            public int reserved5;
            public int reserved6;
            public int reserved7;
            public int reserved8;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject([In] IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        private class DATETIMEPICKERINFO
        {
            public int cbSize;
            public RECT rcCheck;
            public int stateCheck;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndEdit;
            public IntPtr hwndUD;
            public IntPtr hwndDropDown;

            public DATETIMEPICKERINFO()
            {
                cbSize = Marshal.SizeOf(this);
            }
        }

        private const int DTM_FIRST = 0x1000;
        private const int DTM_GETDATETIMEPICKERINFO = DTM_FIRST + 14;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd,
                                                int Msg,
                                                IntPtr wParam,
                                                DATETIMEPICKERINFO lParam);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    WmPaint(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private static Bitmap CreateColorBitmap(Color color, Size size)
        {
            if (size.Width < 1)
            {
                size.Width = 1;
            }
            var bmp = new Bitmap(size.Width, size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(color);
            }
            return bmp;
        }

        private static void BitBlt(IntPtr hdc, Color color, Rectangle rectangle, int dwRop)
        {
            using (Bitmap bmp = CreateColorBitmap(color, rectangle.Size))
            {
                BitBlt(hdc, bmp, rectangle, dwRop);
            }
        }

        private static void BitBlt(Bitmap bmp, Color color, Rectangle rectangle, int dwRop)
        {
            using (var g = Graphics.FromImage(bmp))
            {
                IntPtr hdc = g.GetHdc();
                BitBlt(hdc, bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), SRCCOPY);
                BitBlt(hdc, color, rectangle, dwRop);
                g.ReleaseHdc();
            }
        }

        private static void BitBlt(IntPtr hdc, Bitmap bmp)
        {
            BitBlt(hdc, bmp, SRCCOPY);
        }

        private static void BitBlt(IntPtr hdc, Bitmap bmp, int dwRop)
        {
            BitBlt(hdc, bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), dwRop);
        }

        private static void BitBlt(IntPtr hdc, Bitmap bmp, Rectangle rectangle, int dwRop)
        {
            BitBlt(hdc, bmp, rectangle, new Point(0, 0), dwRop);
        }

        private static void BitBlt(IntPtr hdc, Bitmap bmp, Rectangle rectangle, Point point, int dwRop)
        {
            IntPtr hdcSrc = CreateCompatibleDC(hdc);
            IntPtr hBitmap = bmp.GetHbitmap();
            IntPtr hbmpOld = SelectObject(hdcSrc, hBitmap);

            BitBlt(hdc,
                rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height,
                hdcSrc, point.X, point.Y, dwRop);

            SelectObject(hdcSrc, hbmpOld);
            DeleteObject(hBitmap);
            DeleteDC(hdcSrc);
        }

        private static void BitBlt(Bitmap bmpDst, Bitmap bmpSrc, int dwRop)
        {
            using (var g = Graphics.FromImage(bmpDst))
            {
                IntPtr hdc = g.GetHdc();
                BitBlt(hdc, bmpDst);
                BitBlt(hdc, bmpSrc, dwRop);
                g.ReleaseHdc();
            }
        }

        private Bitmap CreateNativeBitmap()
        {
            var cs = this.ClientSize;
            var bmp = new Bitmap(cs.Width, cs.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                var hdc = g.GetHdc();
                var pm = Message.Create(this.Handle, WM_PAINT, hdc, IntPtr.Zero);
                base.DefWndProc(ref pm);
                g.ReleaseHdc();
            }
            return bmp;
        }

        private static Bitmap CreateNagetiveBitmap(Bitmap bmp)
        {
            var bmpDest = new Bitmap(bmp.Width, bmp.Height);
            using (var g = Graphics.FromImage(bmpDest))
            {
                var hdc = g.GetHdc();
                BitBlt(hdc, bmp, NOTSRCCOPY);
                g.ReleaseHdc();
            }
            return bmpDest;
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            base.OnRightToLeftLayoutChanged(e);
            this.ResumeLayout();
            this.Invalidate();
        }

        private void WmPaint(ref Message m)
        {
            var cs = this.ClientSize;
            var dti = new DATETIMEPICKERINFO();
            var ret = SendMessage(this.Handle, DTM_GETDATETIMEPICKERINFO, IntPtr.Zero, dti);
            var bsz = SystemInformation.Border3DSize;
            var canvas = new Rectangle(bsz.Width, bsz.Height, dti.rcButton.Left - bsz.Width, cs.Height - bsz.Height * 2);

            using (var bmpBack = CreateNativeBitmap())
            using (var bmpFore = CreateNagetiveBitmap(bmpBack))
            {
                BitBlt(bmpBack, BackColor, canvas, SRCAND);
                BitBlt(bmpFore, ForeColor, canvas, SRCAND);

                using (var bmp = new Bitmap(cs.Width, cs.Height))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        IntPtr hdc = g.GetHdc();
                        BitBlt(hdc, bmpBack, SRCCOPY);
                        BitBlt(hdc, bmpFore, canvas, canvas.Location, SRCPAINT);
                        g.ReleaseHdc();
                    }

                    if (m.WParam == IntPtr.Zero)
                    {
                        // コントロールに描画
                        var ps = new PAINTSTRUCT();
                        var controlHdc = BeginPaint(m.HWnd, ref ps);
                        using (var controlGraphics = Graphics.FromHdc(controlHdc))
                        {
                            controlGraphics.DrawImage(bmp, 0, 0);
                        }
                        EndPaint(m.HWnd, ref ps);
                    }
                    else
                    {
                        // hdc に描画
                        using (var controlGraphics = Graphics.FromHdc(m.WParam))
                        {
                            controlGraphics.DrawImage(bmp, 0, 0);
                        }
                    }
                }
            }
        }
    }
}