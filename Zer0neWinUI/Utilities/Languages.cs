using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zer0ne.WinUI.Utilities
{
    public class Languages
    {
        #region ==========================================  Properties

        public bool IsRightToLift { get; set; }
        public Dictionary<string, string> DicLang { get; set; }       
        public string FilePath { get; set; }

        #endregion


        #region ==========================================  Voids

        public void Save()
        {
            if (DicLang == null)
            {
                DicLang = new Dictionary<string, string>();
            }
            Zer0ne.Data.ZDataHelper.JsonSave(this, FilePath);
        }

        public void Load()
        {
            if (DicLang == null)
            {
                DicLang = new Dictionary<string, string>();
            }
            else
            {
                DicLang.Clear();
            }

            Languages lng = new Languages();
            lng = Zer0ne.Data.ZDataHelper.JsonLoad<Languages>(FilePath);
            this.IsRightToLift = lng.IsRightToLift;
            this.DicLang = lng.DicLang;
        }

        #endregion
    }
}
