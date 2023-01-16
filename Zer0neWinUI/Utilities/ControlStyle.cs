using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zer0ne.WinUI
{
    public enum BorderMode
    {
        Circle,
        RoundedCorners,
        Flat
    }

    public class ZControlStyle
    {
        public event EventHandler OnValueChanged;

        Color bk;
        public Color BackColor
        {
            get
            {
                return bk;
            }
            set
            {
                bk = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        Color txcr;
        public Color TextColor
        {
            get
            {
                return txcr;
            }
            set
            {
                txcr = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        Color hnt;
        public Color HintColor
        {
            get
            {
                return hnt;
            }
            set
            {
                hnt = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        Color actv;
        public Color ActiveColor
        {
            get
            {
                return actv;
            }
            set
            {
                actv = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        Color iactv;
        public Color InactiveColor
        {
            get
            {
                return iactv;
            }
            set
            {
                iactv = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        Color c1;
        public Color GradientColor1
        {
            get
            {
                return c1;
            }
            set
            {
                c1 = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        Color c2;
        public Color GradientColor2
        {
            get
            {
                return c2;
            }
            set
            {
                c2 = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }
        
        int brdrsz;
        public int BorderSize
        {
            get
            {
                return brdrsz;
            }
            set
            {
                brdrsz = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        int rds;
        public int Radius
        {
            get
            {
                return rds;
            }
            set
            {
                rds = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        float ga;
        public float GradientAngle
        {
            get
            {
                return ga;
            }
            set
            {
                ga = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        DashStyle bls;
        public DashStyle BorderLineStyle
        {
            get
            {
                return bls;
            }
            set
            {
                bls = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        DashCap bc;
        public DashCap BorderCapStyle
        {
            get
            {
                return bc;
            }
            set
            {
                bc = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }

        BorderMode bcs;
        public BorderMode BorderCornersStyle
        {
            get
            {
                return bcs;
            }
            set
            {
                bcs = value;
                OnValueChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
