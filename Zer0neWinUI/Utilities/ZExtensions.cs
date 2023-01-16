﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Utilities
{
    internal static class ZExtensions
    {
        #region System.Drawing related

        /// <summary>
        ///     Have removed the StringTrimming.EllipsisCharacter here !!
        /// </summary>
        public static StringFormat AsStringFormat(this ContentAlignment textAlign)
        {
            StringFormat stringFormat = new StringFormat();
         
            switch (textAlign)
            {
                case ContentAlignment.TopLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.MiddleLeft:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomLeft:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomCenter:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
            }

            return stringFormat;
        }

        internal static TextFormatFlags AsTextFormatFlags(this HorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case HorizontalAlignment.Left: return TextFormatFlags.Left;
                case HorizontalAlignment.Center: return TextFormatFlags.HorizontalCenter;
                case HorizontalAlignment.Right: return TextFormatFlags.Right;
            }
            throw new InvalidEnumArgumentException();
        }

        internal static TextFormatFlags AsTextFormatFlags(this ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.BottomLeft: return TextFormatFlags.Bottom | TextFormatFlags.Left;
                case ContentAlignment.BottomCenter: return TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.BottomRight: return TextFormatFlags.Bottom | TextFormatFlags.Right;
                case ContentAlignment.MiddleLeft: return TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                case ContentAlignment.MiddleCenter: return TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.MiddleRight: return TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                case ContentAlignment.TopLeft: return TextFormatFlags.Top | TextFormatFlags.Left;
                case ContentAlignment.TopCenter: return TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.TopRight: return TextFormatFlags.Top | TextFormatFlags.Right;
            }
            throw new InvalidEnumArgumentException();
        }

        internal static void DrawImage(this Graphics g, Image image, Rectangle destination, ContentAlignment alignment)
        {
            g.DrawImage(image, AlignContent(destination, alignment, image.Size));
        }

        private static Point AlignContent(Rectangle container, ContentAlignment alignment, Size content)
        {
            switch (alignment)
            {
                case ContentAlignment.BottomLeft: return new Point(container.Left, container.Bottom - content.Height);
                case ContentAlignment.BottomCenter: return new Point(container.HorizontalCenter() - content.Width / 2, container.Bottom - content.Height);
                case ContentAlignment.BottomRight: return new Point(container.Right - content.Width, container.Bottom - content.Height);
                case ContentAlignment.MiddleLeft: return new Point(0, container.VerticalCenter() - content.Height / 2);
                case ContentAlignment.MiddleCenter: return new Point(container.HorizontalCenter() - content.Width / 2, container.VerticalCenter() - content.Height / 2);
                case ContentAlignment.MiddleRight: return new Point(container.Right - content.Width, container.VerticalCenter() - content.Height / 2);
                case ContentAlignment.TopLeft: return container.Location;
                case ContentAlignment.TopCenter: return new Point(container.HorizontalCenter() - content.Width / 2, container.Top);
                case ContentAlignment.TopRight: return new Point(container.Right - content.Width, container.Top);
            }
            throw new InvalidEnumArgumentException();
        }

        internal static Point TopLeft(this Rectangle r) { return r.Location; }
        internal static Point TopRight(this Rectangle r) { return new Point(r.Right, r.Top); }
        internal static Point BottomLeft(this Rectangle r) { return new Point(r.Left, r.Bottom); }
        internal static Point BottomRight(this Rectangle r) { return new Point(r.Right, r.Bottom); }
        internal static Point Center(this Rectangle r) { return new Point(r.Left + r.Width / 2, r.Top + r.Height / 2); }
        internal static int HorizontalCenter(this Rectangle r) { return r.Left + r.Width / 2; }
        internal static int VerticalCenter(this Rectangle r) { return r.Top + r.Height / 2; }

        #endregion

        // for Point, use new Point((int)m.LParam) !!

        //public static ushort LoWord(this uint n) { return (ushort)n; }
        //public static short LoWord(this int n) { return (short)(n & 0xffff); }
        //public static ushort HiWord(this uint n) { return (ushort)(n >> 16); }
        //public static short HiWord(this int n) { return (short)((n >> 16) & 0xffff); }


    }
}
