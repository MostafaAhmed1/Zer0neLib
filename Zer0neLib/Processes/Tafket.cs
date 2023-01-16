using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zer0ne.Processes
{
    public class Tafket
    {
        string[] words1_9 = new string[] { "", "واحد", "إثنان", "ثلاثة", "اربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" }; //, "عشرة"}
        string[] words10_19 = new string[] { "عشرة", "إحدى عشر", "إثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
        string[] words20_90 = new string[] { "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
        string[] words100_900 = new string[] { "", "مائة", "مائتان", "ثلاث مائة", "اربع مائة", "خمس مائة", "ست مائة", "سبع مائة", "ثمان مائة", "تسع مائة" };
        string[] words1000_9000 = new string[] { "", "ألف", "الفان", "ثلاثة الاف", "اربعة الاف", "خمسة الاف", "ستة الاف", "سبعة الاف", "ثمانية الاف", "تسعة الاف" };

        public string taff(string num)
        {
            string NumInArWord = "";
            if (num.Contains("."))
            {
                num = num.Remove(num.IndexOf("."), num.Length - num.IndexOf("."));
            }
            long num2 = Convert.ToInt64(num);

            if (num2 < 0)
            {
                num2 = 0 - num2;
            }

            num = num2.ToString();

            if (Convert.ToDouble(num) == 0)
            {
                NumInArWord += "";
            }
            else if (Convert.ToInt64(num) < 10)
            {
                NumInArWord += words1_9[Convert.ToInt64(num)];
            }
            else if (Convert.ToInt64(num) < 20)
            {
                NumInArWord += words10_19[Convert.ToInt64(num) - 10];
            }
            else if (Convert.ToInt64(num) < 100)
            {
                if (num.Substring(1) != "0") //20 30 40 50 60 and so on
                {
                    NumInArWord += words1_9[Convert.ToInt64(num.Substring(1))] + " و ";
                }
                NumInArWord += words20_90[Convert.ToInt64(num.Substring(0, 1))];
            }
            else if (Convert.ToInt64(num) < 1000)
            {
                NumInArWord += words100_900[Convert.ToInt64(num.Substring(0, 1))];
                if (num.Substring(1) != "00")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(1));
                }
            }
            else if (Convert.ToInt64(num) < 10000)
            {
                NumInArWord += words1000_9000[Convert.ToInt64(num.Substring(0, 1))];
                if (num.Substring(1) != "000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(1));
                }
            }
            else if (Convert.ToInt64(num) < 100000)
            {
                NumInArWord += taff(num.Substring(0, 2)) + " ألف ";
                if (num.Substring(2) != "000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(2));
                }
            }
            else if (Convert.ToInt64(num) < 1000000)
            {
                NumInArWord += taff(num.Substring(0, 3)) + " ألف ";
                if (num.Substring(3) != "000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(3));
                }
            }
            else if (Convert.ToInt64(num) < 10000000)
            {
                NumInArWord += taff(num.Substring(0, 1)) + " مليون ";
                if (num.Substring(1) != "000000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(1));
                }
            }
            else if (Convert.ToInt64(num) < 100000000)
            {
                NumInArWord += taff(num.Substring(0, 2)) + " مليون ";
                if (num.Substring(2) != "000000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(2));
                }
            }
            else if (Convert.ToInt64(num) < 1000000000)
            {
                NumInArWord += taff(num.Substring(0, 3)) + " مليون ";
                if (num.Substring(3) != "0000000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(3));
                }
            }
            else if (Convert.ToInt64(num) < 10000000000)
            {
                NumInArWord += taff(num.Substring(0, 1)) + " مليار ";
                if (num.Substring(1) != "00000000")
                {
                    NumInArWord += " و ";
                    NumInArWord += taff(num.Substring(1));
                }
            }

            return NumInArWord;
        }
    }
}
