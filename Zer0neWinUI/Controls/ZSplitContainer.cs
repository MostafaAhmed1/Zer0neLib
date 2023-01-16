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
    public class ZSplitContainer : SplitContainer
    {
        public ZSplitContainer()
        {
            ZStyle = new ZControlStyle()
            {
                Radius = ZTheme.ControlStyle.Radius,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.HintColor,
                GradientColor2 = ZTheme.HintColor,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
            };

            zStyle.OnValueChanged += ZStyle_OnValueChanged;
            Recolor();
        }
        
        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        //Properties
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
                Recolor();
            }
        }

        void Recolor()
        {
            base.BackColor = ZStyle.GradientColor1;
            Panel2.BackColor = ZStyle.BackColor;
            Panel1.BackColor = ZStyle.BackColor;
            base.ForeColor = ZStyle.TextColor;
            //base.Font = ZTheme.Fontz;
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                Panel2.BackColor = ZStyle.BackColor;
                Panel1.BackColor = ZStyle.BackColor;
                return ZStyle.GradientColor1;
            }
            set
            {
                ZStyle.GradientColor1 = value;
                Panel2.BackColor = ZStyle.BackColor;
                Panel1.BackColor = ZStyle.BackColor;
                base.BackColor = ZStyle.GradientColor1;
                Invalidate();
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

        Font fnt = ZTheme.Fontz;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
                fnt = base.Font;
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
