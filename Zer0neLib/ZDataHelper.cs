using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks; 
using Zer0ne.Processes;
using System.Data.Entity;
using System.Threading;

namespace Zer0ne.Data
{
    public static class ZDataHelper
    {
        public static DbContext DbContext { get; set; }
        public static DatabaseController DbController { get; set; }
        //------------------------>>>

        public static async Task<int> WaitMethod(int miliSec)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(miliSec);
                return 0;
            });
        }

        public static List<T> TableToList<T>(DataTable tbl) where T : class
        {
            var lstResult = new List<T>();

            // نلف علي كل الصفوف 
            for (int row = 0; row < tbl.Rows.Count; row++)
            {
                // نعرف متغير المتغير بياخد القيم اللي في الصف الواحد و في نهاية الفور نضيف المتغير للستة اللي هترجع
                //var ins = (T)Activator.CreateInstance(Type.GetType(typeof(T).FullName, true, true));
                T ins = (T)Activator.CreateInstance(typeof(T));

                // نلف علي كل الاعمدة عشان نعرف اسمائهم و نقارنهم بالبروبرتي اللي في المتغير
                for (int col = 0; col < tbl.Columns.Count; col++)
                {
                    // نجيب البروبرتي اللي في المتغير و نحطهم في اراي  
                    var lsPropIns = ins.GetType().GetProperties();

                    // نجيب طول او عدد الايتم اللي في الاراي بتاعت البروبرتي عشان محتاج الاندكسس لكل بروبرتي
                    for (int propIns = 0; propIns < lsPropIns.Length; propIns++)
                    {
                        // لو اسم البروبرتي اللي في الاراي = نفس اسم العمود  
                        if (lsPropIns[propIns].Name.ToUpper() == tbl.Columns[col].ColumnName.ToUpper())
                        {
                            /*
                             لو الشرط اتحقق 
                             بنحط قيمة البروبرتي من الجدول بالاندكسس بتاع العمود و الصف 
                             و مننساش ان البروبرتي دي داخل اوبجكت عرفني اية هو الاوبجكت اللي يحتوي علي البروبرتي دي عشان احطلك فية القيمة 
                             */
                            if (tbl.Rows[row][col] == DBNull.Value)
                            {
                                lsPropIns[propIns].SetValue(ins, Convert.ChangeType(null, lsPropIns[propIns].PropertyType));
                            }
                            else
                            {
                            lsPropIns[propIns].SetValue(ins, Convert.ChangeType(tbl.Rows[row][col] , lsPropIns[propIns].PropertyType));
                            }

                           break;
                        }
                    }
                }
                // و بكدة في نهاية كل لفة معايا صف بيانات ادية للستة اللي هترجع عشان بعد ما يخلص الفور 
                lstResult.Add(ins);
            }

            //يرجعلي اللست
            return lstResult;
        }

        public static DataTable ListToTable<T>(List<T> list) where T : class
        {
            if (list.Count == 0)
            {
                return null;
            }

            DataTable tbl = new DataTable(typeof(T).Name);
            var pList = list[0].GetType().GetProperties();

            foreach (PropertyInfo info in pList)
            {
                tbl.Columns.Add(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType);
            }

            foreach (var item in list)
            {
                var rw = tbl.NewRow();

                for (int p = 0; p < pList.Length; p++)
                {
                    rw[pList[p].Name] = pList[p].GetValue(item);
                }

                tbl.Rows.Add(rw);
            }

            return tbl;
        }

        public static object GtPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static List<PropertyInfo> GtClassProperties(Type clsObject)
        {
            return clsObject.GetType().GetProperties().ToList();
        }

        public static void JsonSave(object data, string filePath)
        {
            DataSerializer ds = new DataSerializer();
            ds.JsonSerializer(data, filePath);
        }

        public static T JsonLoad<T>(string filePath) where T : class
        {
            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }
            DataSerializer ds = new DataSerializer();
            return ds.JsonDeserializer(typeof(T), filePath) as T;
        }

        public static string Tafket(string moneyValue, string bigCurrency = "", string smallCurrency = "")
        {
            Tafket tafkeet = new Tafket();
            string NumArWord = "";
            string NumPoint = "";

            if (moneyValue.Contains("."))
            {
                NumPoint = moneyValue.Substring(moneyValue.IndexOf(".") + 1);
            }
            else
            {
                NumPoint = "";
            }

            NumArWord = tafkeet.taff(moneyValue);

            if (bigCurrency != "")
            {
                NumArWord += " " + bigCurrency;
            }

            if (int.TryParse(NumPoint, out int i) && Convert.ToInt16(NumPoint) > 0)
            {
                if (NumPoint.Length == 1)
                {
                    NumPoint = Convert.ToString(Convert.ToInt16(NumPoint) * 10);
                }

                NumPoint = " و " + tafkeet.taff(NumPoint) + " " + smallCurrency;
            }
            else
            {
                NumPoint = "";
            }

            return NumArWord + NumPoint;
        }

        //--------------------------------

        public static List<T> TableToList2<T>(this DataTable tbl) where T : class 
        {
            var lstResult = new List<T>();

            foreach (var rw in tbl.AsEnumerable())
            {

                T obj = (T)Activator.CreateInstance(typeof(T));

                foreach (var prop in obj.GetType().GetProperties())
                {
                   
                    PropertyInfo propInfo = obj.GetType().GetProperty(prop.Name);
                    if (tbl.Columns.Contains(prop.Name))
                    {
                        if (rw[prop.Name] != DBNull.Value)
                        {
                            propInfo.SetValue(obj, Convert.ChangeType(rw[prop.Name], propInfo.PropertyType));
                        }
                        else if (rw[prop.Name] == DBNull.Value)
                        {
                            propInfo.SetValue(obj, Convert.ChangeType(null, propInfo.PropertyType));
                        }
                    }                    
                }
                lstResult.Add(obj);
            }
            return lstResult;
        }

        //--------------------------------




    }
}
