using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.Data;
using DevComponents.DotNetBar.Keyboard;
using System.Diagnostics;
using System.Data;
using Zer0ne.WinUI.Controls;

namespace Zer0ne.WinUI
{
    public static class ZWinHelper
    {
        public static int ConvertTwipsToXPixels(Graphics source, int twips)
        {
            return (int)(((double)twips) * (1.0 / 1440.0) * source.DpiX);
        }

        public static Font GtFontFromFile(string path)
        {
            var pfc = new System.Drawing.Text.PrivateFontCollection();
            pfc.AddFontFile(path);
            return new Font(pfc.Families[0], 16, FontStyle.Regular);

            //Process.Start(Application.StartupPath + "\\Fonts\\Almarai-Bold.ttf");
            
            // Try install the font.
            //result = AddFontResource(@"C:\MY_FONT_LOCATION\MY_NEW_FONT.TTF");
            //error = Marshal.GetLastWin32Error();
            //if (error != 0)
            //{
            //    Console.WriteLine(new Win32Exception(error).Message);
            //}
            //else
            //{
            //    Console.WriteLine((result == 0) ? "Font is already installed." :
            //                                      "Font installed successfully.");
            //}

            //var info = new ProcessStartInfo()
            //{
            //    FileName = path,
            //    Arguments = "/copy",
            //    UseShellExecute = false,
            //    WindowStyle = ProcessWindowStyle.Normal
            //};

            //Process.Start(info);
        }

        public static void SetInputLanguage(string culName)
        {
            if (culName == null)
            {
                culName = "ar-eg";
            }
            var MyLng = new System.Globalization.CultureInfo(culName);
            var InLang = InputLanguage.FromCulture(MyLng);
            InputLanguage.CurrentInputLanguage = InLang;
        }

        private static void BindControls(object controlToFill, DataTable lstData, string value, string display)
        {

            if (controlToFill is ComboBox)
            {
                ComboBox cmb = (ComboBox)controlToFill;
                cmb.DataSource = lstData;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
                cmb.SelectedIndex = -1;
                cmb.SelectedIndexChanged += (s, e) =>
                {
                    if (cmb.SelectedIndex < 0 || cmb.SelectedIndex >= lstData.Rows.Count)
                    {
                        return;
                    }
                };
            }
            else if (controlToFill is ZComboBox)
            {
                ZComboBox cmb = (ZComboBox)controlToFill;
                cmb.DataSource = lstData;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
                cmb.SelectedIndex = -1;
                cmb.SelectedIndexChanged += (s, e) =>
                {
                    if (cmb.SelectedIndex < 0 || cmb.SelectedIndex >= lstData.Rows.Count)
                    {
                        return;
                    }
                };
            }
            else if (controlToFill is BaseComboBox)
            {
                BaseComboBox cmb = (BaseComboBox)controlToFill;
                cmb.DataSource = lstData;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
                cmb.SelectedIndex = -1;
                cmb.SelectedIndexChanged += (s, e) =>
                {
                    if (cmb.SelectedIndex < 0 || cmb.SelectedIndex >= lstData.Rows.Count)
                    {
                        return;
                    }
                };
            }
            else if (controlToFill is ListBox)
            {
                ListBox lst = (ListBox)controlToFill;
                lst.DataSource = lstData;
                lst.DisplayMember = display;
                lst.ValueMember = value;
            }
            else if (controlToFill is ZListBox)
            {
                ZListBox lst = (ZListBox)controlToFill;
                lst.DataSource = lstData;
                lst.DisplayMember = display;
                lst.ValueMember = value;
            }
            else if (controlToFill is DataGridViewComboBoxColumn)
            {
                DataGridViewComboBoxColumn grdCol = (DataGridViewComboBoxColumn)controlToFill;
                grdCol.DataSource = lstData;
                grdCol.DisplayMember = display;
                grdCol.ValueMember = value;
            }
            else if (controlToFill is ZGridComboBoxColumn)
            {
                ZGridComboBoxColumn grdCol = (ZGridComboBoxColumn)controlToFill;
                grdCol.DataSource = lstData;
                grdCol.DisplayMember = display;
                grdCol.ValueMember = value;
            }
            else if (controlToFill is DataGridViewComboBoxCell)
            {
                DataGridViewComboBoxCell grdCel = (DataGridViewComboBoxCell)controlToFill;
                grdCel.DataSource = lstData;
                grdCel.DisplayMember = display;
                grdCel.ValueMember = value;
            }
            else if (controlToFill is DevComponents.DotNetBar.ListBoxAdv)
            {
                DevComponents.DotNetBar.ListBoxAdv lstAdv = (DevComponents.DotNetBar.ListBoxAdv)controlToFill;
                lstAdv.DataSource = lstData;
                lstAdv.DisplayMember = display;
                lstAdv.ValueMember = value;
            }

        }

        public static void FillObject(object controlToFill, string fields, string displayField, string valueField, string tableName)
        {
            var lstData = ZDataHelper.DbController.Read("select " + fields + " from " + tableName);

            BindControls(controlToFill, lstData, valueField, displayField);
        }

        public static void FillObject(object controlToFill, string displayField, string valueField, string tableName)
        { 
            var lstData = ZDataHelper.DbController.Read("select " + valueField + " id, " + displayField + " bian from " + tableName);

            BindControls(controlToFill, lstData, "id", "bian");
        }

        public static void FillObject<T>(object controlToFill, IEnumerable<T> listOfData, string displayField, string valueField) where T : class
        {
            if (listOfData?.Count()<= 0)
            {
                BindControls(controlToFill, null, "", "");
                return;
            }

            var lstData = ZDataHelper.ListToTable<T>(listOfData.ToList());

            BindControls(controlToFill, lstData, valueField, displayField);
        }

        public static List<T> FillObject<T>(object controlToFill, string displayField, string valueField, EventHandler<T> valueSelectEvent = null) where T : class
        {
            var tbl = new Table<T>();
            var lstData = tbl.GtAll();

            string value, display;
            value = valueField;
            display = displayField;

            if (controlToFill is ComboBox)
            {
                ComboBox cmb = (ComboBox)controlToFill;
                cmb.DataSource = lstData;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
                cmb.SelectedIndex = -1;
                cmb.SelectedIndexChanged += (s, e) =>
                {
                    if (cmb.SelectedIndex < 0 || cmb.SelectedIndex >= lstData.Count)
                    {
                        return;
                    }
                    valueSelectEvent?.Invoke(cmb, lstData[cmb.SelectedIndex]);
                };
            }
            else if (controlToFill is ZComboBox)
            {
                var lst = (ZComboBox)controlToFill;
                lst.DataSource = lstData;
                lst.DisplayMember = display;
                lst.ValueMember = value;
                lst.SelectedIndexChanged += (s, e) =>
                {
                    if (lst.SelectedIndex < 0 || lst.SelectedIndex >= lstData.Count)
                    {
                        return;
                    }
                    valueSelectEvent?.Invoke(lst, lstData[lst.SelectedIndex]);
                };
            }
            else if (controlToFill is ListBox)
            {
                ListBox lst = (ListBox)controlToFill;
                lst.DataSource = lstData;
                lst.DisplayMember = display;
                lst.ValueMember = value;
                lst.SelectedIndexChanged += (s, e) =>
                {
                    if (lst.SelectedIndex < 0 || lst.SelectedIndex >= lstData.Count)
                    {
                        return;
                    }
                    valueSelectEvent?.Invoke(lst, lstData[lst.SelectedIndex]);
                };
            }
            else if (controlToFill is DataGridViewComboBoxColumn)
            {
                DataGridViewComboBoxColumn grdCol = (DataGridViewComboBoxColumn)controlToFill;
                grdCol.DataSource = lstData;
                grdCol.DisplayMember = display;
                grdCol.ValueMember = value;
            }
            else if (controlToFill is DataGridViewComboBoxCell)
            {
                DataGridViewComboBoxCell grdCel = (DataGridViewComboBoxCell)controlToFill;
                grdCel.DataSource = lstData;
                grdCel.DisplayMember = display;
                grdCel.ValueMember = value;
            }
            else if (controlToFill is DevComponents.DotNetBar.ListBoxAdv)
            {
                DevComponents.DotNetBar.ListBoxAdv lstAdv = (DevComponents.DotNetBar.ListBoxAdv)controlToFill;
                lstAdv.DataSource = lstData;
                lstAdv.DisplayMember = display;
                lstAdv.ValueMember = value;
            }

            return lstData;
        }

        //ازالة البيانات من الحقول فى الفورم
        public static void Remove_Data(Control Container)
        {
            foreach (Control item in Container.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                else if (item is ZTextBox)
                {
                    ZTextBox txt = (ZTextBox)item;
                    txt.Clear();
                }
                else if (item is RichTextBox)
                {
                    RichTextBox txt = (RichTextBox)item;
                    txt.Clear();
                }
                else if (item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.SelectedIndex = -1;
                }
                else if (item is BaseComboBox)
                {
                    BaseComboBox cmb = (BaseComboBox)item;
                    cmb.SelectedIndex = -1;
                }
                else if (item is ZComboBox)
                {
                    ZComboBox cmb = (ZComboBox)item;
                    cmb.SelectedIndex = -1;
                    cmb.SelectedIndex = -1;
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown num = (NumericUpDown)item;
                    num.Value = num.Minimum;
                }
                else if (item is BaseNumeric)
                {
                    BaseNumeric num = (BaseNumeric)item;
                    num.Value = num.Minimum;
                }
                else if (item is ZNumeric)
                {
                    ZNumeric num = (ZNumeric)item;
                    num.Value = num.Minimum;
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)item;
                    dtp.Value = DateTime.Now;
                }
                else if (item is ZDatePicker)
                {
                    ZDatePicker dtp = (ZDatePicker)item;
                    dtp.Value = DateTime.Now;
                }
                else if (item is DatePickerEx)
                {
                    DatePickerEx dtp = (DatePickerEx)item;
                    dtp.Value = DateTime.Now;
                }
                else if (item is ZDatePicker)
                {
                    ZDatePicker dtp = (ZDatePicker)item;
                    dtp.Value = DateTime.Now;
                }
                else if (item is ListBox)
                {
                    ListBox lsb = (ListBox)item;
                    lsb.SelectedIndex = -1;
                }
                else if (item is ZSplitContainer)
                {
                    ZSplitContainer s = (ZSplitContainer)item;
                    Remove_Data(s.Panel1);
                    Remove_Data(s.Panel2);
                }
                else if (item is Panel)
                {
                    Panel pnl = (Panel)item;
                    if (pnl.Name == "pnlTitel" || pnl.Name == "pnlBtns")
                    {
                        continue;
                    }
                    Remove_Data(pnl);
                }
                else if (item is GroupBox || item is GroupPanel)
                {
                    GroupBox grb = (GroupBox)item;
                    Remove_Data(grb);
                }
                else if (item is TabControl)
                {
                    TabControl tabCtrl = (TabControl)item;

                    foreach (TabPage pg in tabCtrl.TabPages)
                    {
                        Remove_Data(pg);
                    }
                }
                else if (item is DevComponents.DotNetBar.SuperTabControl)
                {
                    DevComponents.DotNetBar.SuperTabControl tab = (DevComponents.DotNetBar.SuperTabControl)item;

                    foreach (DevComponents.DotNetBar.SuperTabItem pg in tab.Tabs)
                    {
                        Remove_Data(pg.AttachedControl);
                    }
                }

            }
        }

        /// <summary>
        /// دالة تتفقد ماإذا كان هناك حقل لم يتم إدخال البيان المناسب له.
        /// </summary>
        /// <param name="Container">إسم الحاوية المطلوب فحصها.</param>
        /// <param name="Except">مصفوفة العناصر المطلوب إستبعادها.</param>
        /// <returns>bool</returns>
        public static bool chkErrors(Control Container, params Control[] Except)
        {
            // تحديد جميع الكائنات فى الحاوية المحددة
            foreach (Control objCtl in Container.Controls)
            {
                if (objCtl is TextBox)
                {
                    TextBox txt = (TextBox)objCtl;
                    if (txt.Visible == true && txt.Enabled == true && txt.ReadOnly == false)
                    {
                        txt.Focus();
                    }
                }
                if (objCtl is ZTextBox)
                {
                    ZTextBox txt = (ZTextBox)objCtl;
                    if (txt.Visible == true && txt.Enabled == true && txt.ReadOnly == false)
                    {
                        txt.Focus();
                    }
                }
                else if (objCtl is ComboBox)
                {
                    ComboBox cmb = (ComboBox)objCtl;
                    if (cmb.Items.Count == 1 && cmb.SelectedIndex == -1 && cmb.Enabled == true)
                    {
                        cmb.SelectedIndex = 0;
                    }
                }
                else if (objCtl is Label)
                {
                    objCtl.Focus();
                }
            }
            // فحص الأخطاء للكائنات داخل الحاوية
            foreach (Control objCtl in Container.Controls)
            {
                if (objCtl.Enabled == false || objCtl.Visible == false)
                {
                    goto stepOver;
                }
                for (int i = 0; i < Except.Length; i++)
                {
                    if (objCtl.Name == Except[i].Name)
                        goto stepOver;
                }

                if (objCtl is ComboBox)  // إذا ما كان الكائن كمبوبوكس
                {
                    ComboBox cmb = (ComboBox)objCtl;
                    if (cmb.SelectedItem == null)
                    {
                        MessageBox.Show("يرجى التأكد من إدخال البيانات بشكل صحيح", "Zer0ne");
                        cmb.Text = "Select -- إختر";
                        cmb.Focus();
                        return true;
                    }
                }
                else if (objCtl is ZComboBox)  // إذا ما كان الكائن كمبوبوكس
                {
                    ZComboBox cmb = (ZComboBox)objCtl;
                    if (cmb.SelectedItem == null)
                    {
                        MessageBox.Show("يرجى التأكد من إدخال البيانات بشكل صحيح", "Zer0ne");
                        cmb.Text = "Select -- إختر";
                        cmb.Focus();
                        return true;
                    }
                }
                else if (objCtl is TextBox) // إذا كان تكست بوكس
                {
                    TextBox txt = (TextBox)objCtl;
                    if (txt.ReadOnly == true)
                        {
                        goto stepOver;
                        }

                    if (txt.Text == "" || txt.Text == "الرجاء كتابة البيان" || txt.Text == "الرجاء كتابة تاريخ صحيح"
                            || txt.Text == "الرجاء كتابة قيمة رقمية" || txt.Text == "الرجاء كتابة التاريخ" ||
                            txt.Text == "الرجاء كتابة رقم موجب" || txt.Text == "الرجاء كتابة بريد صحيح")
                    {
                        MessageBox.Show("يرجى التأكد من إدخال البيانات بشكل صحيح", "Zer0ne");
                        txt.Focus();
                        return true;
                    }
                }
                else if (objCtl is ZTextBox) // إذا كان تكست بوكس
                {
                    ZTextBox txt = (ZTextBox)objCtl;
                    
                    if (txt.ReadOnly == true)
                        goto stepOver;
                    if (txt.Text == "" || txt.Text == "الرجاء كتابة البيان" || txt.Text == "الرجاء كتابة تاريخ صحيح"
                            || txt.Text == "الرجاء كتابة قيمة رقمية" || txt.Text == "الرجاء كتابة التاريخ" ||
                            txt.Text == "الرجاء كتابة رقم موجب" || txt.Text == "الرجاء كتابة بريد صحيح")
                    {
                        MessageBox.Show("يرجى التأكد من إدخال البيانات بشكل صحيح", "Zer0ne");
                        txt.Focus();
                        return true;
                    }
                }
            stepOver:;
            }

            return false;
        }

        /// <summary>
        ///     دالة تتفقد ماإذا كان هناك حقل لم يتم إدخال البيان المناسب له.
        /// </summary>
        /// <param name="Container">إسم الحاوية المطلوب فحصها.</param>
        /// <param name="Except">مصفوفة العناصر المطلوب إستبعادها.</param>
        /// <returns>bool</returns>
        public static bool chkErrors( ErrorProvider ep, params Control[] ctrl)
        {
            int numberOfErrors = 0;

            for (int i = 0; i < ctrl.Length; i++)
            {
                foreach (Control objCtl in ctrl[i].Controls)
                {
                    if (objCtl.Enabled == false || objCtl.Visible == false)
                    {
                        continue; //goto stepOver;
                    }

                    if (objCtl is ZComboBox)
                    {
                        ZComboBox cmb = (ZComboBox)objCtl;
                        if (cmb.SelectedItem == null && cmb.ErrorText != string.Empty)
                        {
                            ep.SetError(cmb, cmb.ErrorText);
                            numberOfErrors += 1;
                        }
                    }
                    else if (objCtl is ZTextBox)
                    {
                        ZTextBox txt = (ZTextBox)objCtl;
                        //if (txt.ReadOnly == true) { goto stepOver; }
                        if (string.IsNullOrEmpty(txt.Text.Trim()) && txt.ErrorText != string.Empty)
                        {
                            ep.SetError(txt, txt.ErrorText);
                            Debug.Print(txt.Name);
                            numberOfErrors += 1;
                        }
                    }
                    else if (objCtl is ZNumeric)
                    {
                        ZNumeric nmrc = (ZNumeric)objCtl;
                        if (nmrc.ErrorText != string.Empty)
                        {
                            ep.SetError(nmrc, nmrc.ErrorText);
                            numberOfErrors += 1;
                        }
                    }
                    else if (objCtl is ZDatePicker)
                    {
                        ZDatePicker dt = (ZDatePicker)objCtl;
                        if (dt.ErrorText != string.Empty)
                        {
                            ep.SetError(dt, dt.ErrorText);
                            numberOfErrors += 1;
                        }
                    }
                    else if (objCtl is ZDatePicker)
                    {
                        ZDatePicker dt = (ZDatePicker)objCtl;
                        if (dt.ErrorText != string.Empty)
                        {
                            ep.SetError(dt, dt.ErrorText);
                            numberOfErrors += 1;
                        }
                    }
                    else if (objCtl is ZListBox)
                    {
                        ZListBox lst = (ZListBox)objCtl;
                        if (lst.ErrorText != string.Empty)
                        {
                            ep.SetError(lst, lst.ErrorText);
                            numberOfErrors += 1;
                        }
                    }
                    else if (objCtl is ZGroup)
                    {
                        ZGroup g = (ZGroup)objCtl;
                        if (g.ErrorText != string.Empty)
                        {
                            ep.SetError(g, g.ErrorText);
                            numberOfErrors += 1;
                        }
                    }
                }
            }
            

            if (numberOfErrors == 0)
            {
                ep.Clear();
            }
            return (numberOfErrors > 0) ? false : true;
        }

        public static byte[] imgToBytes(Image img)
        {
            using (System.IO.MemoryStream strm = new System.IO.MemoryStream())
            {
                try
                {
                    if (img == null)
                    {
                        return strm.ToArray();
                    }
                    else
                    {
                        img.Save(strm, img.RawFormat);
                        return strm.ToArray();
                    }
                }
                catch (Exception) { return strm.ToArray();}
            }

        }

        public static Image imgFromBytes(byte[] bytArr)
        {
            Image img;
            try
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(bytArr, false))
                {
                    img = Image.FromStream(stream);
                }
            }
            catch { img = null; }
            return img;

        }

    }
}
