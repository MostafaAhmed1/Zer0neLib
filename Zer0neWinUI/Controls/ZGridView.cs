using DevComponents.DotNetBar.Controls;
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
    public class ZGridView : DataGridView
    {
        public ZGridView()
        {
            MultiSelect = false;
            RowTemplate.Height = 35;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //BorderStyle = BorderStyle.None;
            EnableHeadersVisualStyles = false;
            Font = ZTheme.Fontz;

            //AllowUserToAddRows = false;
            //AllowUserToDeleteRows = false;
           // columnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //base.ColumnHeadersHeight = 45;
            //this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            zStyle = new ZControlStyle()
            {
                Radius = ZTheme.ControlStyle.Radius,
                BorderSize = ZTheme.ControlStyle.BorderSize,
                GradientAngle = ZTheme.ControlStyle.GradientAngle,
                BorderCapStyle = ZTheme.ControlStyle.BorderCapStyle,
                BorderLineStyle = ZTheme.ControlStyle.BorderLineStyle,
                BorderCornersStyle = ZTheme.ControlStyle.BorderCornersStyle,
                GradientColor1 = ZTheme.ControlStyle.GradientColor1,
                GradientColor2 = ZTheme.ControlStyle.GradientColor2,
                BackColor = ZTheme.ControlStyle.BackColor,
                TextColor = ZTheme.ControlStyle.TextColor,
                ActiveColor = ZTheme.ControlStyle.ActiveColor,
                InactiveColor = ZTheme.ControlStyle.InactiveColor,
                HintColor = ZTheme.ControlStyle.HintColor
            };
            zStyle.OnValueChanged += ZStyle_OnValueChanged;

            _defaultCellStyle = new DataGridViewCellStyle();
            _defaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _defaultCellStyle.BackColor = ZStyle.InactiveColor;
            _defaultCellStyle.ForeColor = ZStyle.TextColor;
            _defaultCellStyle.SelectionBackColor = ZStyle.ActiveColor;
            _defaultCellStyle.SelectionForeColor = ZStyle.GradientColor1;

            _colCellStyle= new DataGridViewCellStyle();
            _colCellStyle.Font = ZTheme.Fontz;
            _colCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _colCellStyle.BackColor = ZStyle.GradientColor1;
            _colCellStyle.ForeColor = ZStyle.TextColor;
            _colCellStyle.SelectionBackColor = ZStyle.ActiveColor;
            _colCellStyle.SelectionForeColor = ZStyle.GradientColor1;

            _alternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
            _alternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _alternatingRowsDefaultCellStyle.BackColor = ZStyle.BackColor;
            _alternatingRowsDefaultCellStyle.ForeColor = ZStyle.TextColor;
            _alternatingRowsDefaultCellStyle.SelectionBackColor = ZStyle.ActiveColor;
            _alternatingRowsDefaultCellStyle.SelectionForeColor = ZStyle.GradientColor1;

            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Recolor();
        }

        private void ZStyle_OnValueChanged(object sender, EventArgs e)
        {
            Recolor();
        }

        void Recolor()
        {
            DefaultCellStyle = _defaultCellStyle;
            RowsDefaultCellStyle = _defaultCellStyle;
            AlternatingRowsDefaultCellStyle = _alternatingRowsDefaultCellStyle;
            base.ColumnHeadersDefaultCellStyle.ApplyStyle(_colCellStyle);
            base.RowHeadersDefaultCellStyle.ApplyStyle(_colCellStyle);

            ForeColor = ZTheme.TextColor;
            BackColor = ZStyle.BackColor;
            base.BackgroundColor = BackColor;
            //base.Font = ZTheme.Fontz;
        }

        //Properties
        ZControlStyle zStyle = new ZControlStyle();
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Category("Zer0ne"),Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool AllowUserToAddRows
        {
            get
            {
                return base.AllowUserToAddRows;
            }
            set
            {
                base.AllowUserToAddRows = value;
                Invalidate();
            }
        }

        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool AllowUserToDeleteRows
        {
            get
            {
                return base.AllowUserToDeleteRows;
            }
            set
            {
                base.AllowUserToDeleteRows = value;
                Invalidate();
            }
        }

        DataGridViewCellStyle _alternatingRowsDefaultCellStyle;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle AlternatingRowsDefaultCellStyle
        {
            get
            {
                return _alternatingRowsDefaultCellStyle;
            }
            set
            {
                _alternatingRowsDefaultCellStyle = value;
                base.AlternatingRowsDefaultCellStyle = value;
            }
        }

        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle RowsDefaultCellStyle
        {
            get
            {
                return _defaultCellStyle;
            }
            set
            {
                _defaultCellStyle = value;
                base.RowsDefaultCellStyle = value;
            }
        }

        DataGridViewCellStyle _defaultCellStyle;
        [Category("Zer0ne"),Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return _defaultCellStyle;
            }
            set
            {
                _defaultCellStyle = value;
                base.DefaultCellStyle = value;
            }
        }

        DataGridViewCellStyle _colCellStyle;
        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get
            {
                return _colCellStyle;
            }
            set
            {
                _colCellStyle = value;
                //base.ColumnHeadersDefaultCellStyle.ApplyStyle(_colCellStyle);
            }
        }

        [Category("Zer0ne"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackgroundColor
        {
            get
            {
                return ZStyle.BackColor;
            }
            set
            {
                ZStyle.BackColor = value;
                Invalidate();
            }
        }

        //[EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Zer0ne"), Browsable(true),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color GridColor
        {
            get
            {
                return ZStyle.BackColor;
            }
            set
            {
                ZStyle.BackColor = value;
                Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            get
            {
                return _colCellStyle;
            }
            set
            {
                _colCellStyle = value;
                //base.RowHeadersDefaultCellStyle.ApplyStyle(_colCellStyle);
            }
        }
    }

    #region Grid Columns
    //Button
    public class ZGridButtonColumn : DataGridViewButtonColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }
    public class ZGridButtonXColumn : DataGridViewButtonXColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    // TextBox
    public class ZGridTextBoxColumn : DataGridViewTextBoxColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    public class ZGridTextBoxDropDownColumn : DataGridViewTextBoxDropDownColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    // CheckBox
    public class ZGridCheckBoxXColumn : DataGridViewCheckBoxXColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }
    public class ZGridCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    //  ComboBox
    public class ZGridComboBoxColumn : DataGridViewComboBoxColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    public class ZGridComboBoxExColumn : DataGridViewComboBoxExColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    //  DateTime
    public class ZGridDateTimeInputColumn : DataGridViewDateTimeInputColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    //  DoubleInput
    public class ZGridDoubleInputColumn : DataGridViewDoubleInputColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    // IntegerInput
    public class ZGridIntegerInputColumn : DataGridViewIntegerInputColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    }

    // Image
    public class ZGridImageColumn : DataGridViewImageColumn
    {
        [Category("Zer0ne")]
        public new string HeaderText
        {
            get
            {
                return base.HeaderText;
            }
            set
            {
                if (ZTheme.Language != null && ZTheme.Language.DicLang != null
                    && ZTheme.Language.DicLang.ContainsKey(value))
                {
                    base.HeaderText = ZTheme.Language.DicLang[value];
                }
                else
                {
                    ZTheme.Language.DicLang.Add(value, value);
                    ZTheme.Language.Save();
                    base.HeaderText = value;
                }
            }
        }
    } 
    #endregion
}
