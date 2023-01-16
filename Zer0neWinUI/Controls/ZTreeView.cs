using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
   public class ZTreeView : TreeView
    {

        public ZTreeView()
        {
            
            AutoSize = false;
            TabStop = true;

            ZStyle = new ZControlStyle()
            {
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                GradientColor1 = ZTheme.ControlStyle.GradientColor1,
                GradientColor2 = ZTheme.ControlStyle.GradientColor2,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                Radius = ZTheme.ControlStyle.Radius,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        void Recolor()
        {
            base.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            base.Font = ZTheme.Fontz;
        }

        ZControlStyle zStyle = new ZControlStyle();
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZControlStyle ZStyle
        {
            get
            {
                return zStyle;
            }
            set
            {
                zStyle = value;
            }

        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get
            {
                return ZStyle.TextColor;
            }
            set
            {
                ZStyle.TextColor = value;
                base.ForeColor = ZStyle.TextColor;
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                return ZStyle.BackColor;
            }
            set
            {
                ZStyle.BackColor = value;
                base.BackColor = ZStyle.BackColor;
                Invalidate();
            }
        }


        Font fnt = ZTheme.Fontz;
        [Category("Zer0ne")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
                return fnt;
            }
            set
            {
                fnt = value;
                base.Font = fnt;
                Invalidate();
            }
        }





    }
}
