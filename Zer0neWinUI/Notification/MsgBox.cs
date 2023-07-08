using System.IO;
using System.Windows.Forms;
using Zer0ne.WinUI.Notifications;
using Zer0ne.WinUI.Utilities;

namespace Zer0ne.WinUI
{
    public static class MsgBox
    {
        public static DialogResult Msg(string text, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon Icon = MessageBoxIcon.Information)
        {
            //var frm = new ZMessageBox(Text, buttons, Icon);
            //frm.TopLevel = true;
            ////frm.TopMost = true;
            //frm.Text = "Zer0ne";
            //return frm.ShowDialog();

            var frm = new ZFullScreanMessage();
            frm.TextZ = text;
            frm.ButtonZ = buttons;
            frm.IconZ = Icon;
            frm.ShowDialog();
            return frm.Result;
        }

        public static void Alert(string text, string title = "", AlertTypeZ type = AlertTypeZ.Success, PositionZ pos = PositionZ.BottomRight)
        {
            if (File.Exists(Application.StartupPath + @"\catcat.wav"))
            {
                var player = new System.Media.SoundPlayer(Application.StartupPath + @"\catcat.wav");
                player.Play();
            }
            var frm = new ZAlert();
            frm.ShowAlert(text, title, type, pos);
        }

        public static double InputBox(string message)
        {
            var frm = new ZInputMessageBox(message);
            frm.TopLevel = true;
            frm.TopMost = true;
            frm.Text = "Zer0ne";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return double.Parse(frm.ResultNumber.ToString());
            }
            return 0;
        }

        public static T ChoseBox<T>(string displayFieldName) where T : class
        {
            var frm = new frmChooser<T>(displayFieldName);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return frm.Result;
            }
            else
            {
                return null;// default(T);
            }
        }

        public static string ChoseBox<T>(string[] items) where T : class
        {
            var frm = new frmChooser<T>(items);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return frm.StringResult;
            }
            else
            {
                return "";
            }
        }
    }
}
