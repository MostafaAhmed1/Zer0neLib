using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zer0ne.WinUI;
using Zer0ne.WinUI.Utilities;

namespace Zer0Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ZTheme.BacgroundColor = Color.FromArgb(29, 34, 54); //(170, 172, 182);  
            //ZTheme.SecondaryColor = Color.FromArgb(46, 51, 71);
            //ZTheme.ThirdColor = Color.FromArgb(65, 70, 92);
            //ZTheme.AccentColor = Color.FromArgb(252, 131, 96);
            //ZTheme.TextColor = Color.White;
            //ZTheme.SelectColor = Color.FromArgb(249, 225, 93);
            //ZTheme.HintColor = Color.FromArgb(170, 172, 182);

            ZTheme.BacgroundColor = Color.FromArgb(235, 233, 234);
            ZTheme.SecondaryColor = Color.FromArgb(170, 172, 182);
            ZTheme.ThirdColor = Color.FromArgb(198, 199, 206);
            ZTheme.AccentColor = Color.FromArgb(252, 131, 96);
            ZTheme.TextColor = Color.White;
            ZTheme.SelectColor = Color.FromArgb(249, 225, 93);
            ZTheme.HintColor = Color.FromArgb(29, 34, 54);
            //ZTheme.Fontz = ZWinHelper.GtFontFromFile(Application.StartupPath + "\\Fonts\\Almarai-Regular.ttf");
            ZControlStyle styl = new ZControlStyle()
            {
                BorderCapStyle = System.Drawing.Drawing2D.DashCap.Round,
                BorderCornersStyle = BorderMode.RoundedCorners,
                BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid,
                BorderSize = 0,
                GradientAngle = 60,
                Radius = 0,
                GradientColor1 = ZTheme.AccentColor,
                GradientColor2 = ZTheme.SelectColor,
                TextColor = ZTheme.TextColor,
                BackColor = ZTheme.SecondaryColor,
                ActiveColor = ZTheme.SelectColor,
                HintColor = ZTheme.HintColor,
                InactiveColor = ZTheme.ThirdColor
            };
            ZTheme.ControlStyle = styl;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
