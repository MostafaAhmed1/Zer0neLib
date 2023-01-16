using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zer0ne.WinUI.Controls
{
     class DropDownMonthCalendar : ToolStripDropDown
    {

        public DropDownMonthCalendar()
        {
            components = new System.ComponentModel.Container();
            
            Ctrl = new MonthCalendar();
            Ctrl.MaxSelectionCount = 1;
            Ctrl.ShowWeekNumbers = true;
            Ctrl.MaxDate = MaxDate;
            Ctrl.MinDate = MinDate;
            //Ctrl.MaxDate = new DateTime(3000, 12, 31);
            //Ctrl.MinDate = new DateTime(1900, 1, 1);
            Ctrl.DateChanged += (w, r) =>
            {
                this.Value = new DateTime(Ctrl.SelectionStart.Year, Ctrl.SelectionStart.Month, Ctrl.SelectionStart.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, DateTime.Now.Kind);
            };
            
            this.m_host = new ToolStripControlHost(Ctrl);
            m_host.AutoSize = false;//make it take the same room as the poped control
            Padding = Margin = m_host.Padding = m_host.Margin = Padding.Empty;
            Ctrl.Location = Point.Empty;
            this.Items.Add(m_host);

            
            Ctrl.Disposed += delegate (object sender, EventArgs e)
            {
                Ctrl = null;
                Dispose(true);// this popup container will be disposed immediately after disposion of the contained control
            };
        }

        #region Properties
        private System.ComponentModel.IContainer components = null;
        private MonthCalendar Ctrl;
        private ToolStripControlHost m_host;

        private DateTime dtMax = DateTime.Now.AddYears(1000);
        public DateTime MaxDate
        {
            get { return dtMax; }
            set
            {
                dtMax = value;
                //if (Ctrl.MaxDate != value)
                //{
                //    Ctrl.MaxDate = value;
                //}
                Ctrl.MaxDate = value;
            }
        }

        private DateTime dtMin = new DateTime(1900, 1, 1);
        public DateTime MinDate
        {
            get { return dtMin; }
            set
            {
                dtMin = value;
                //if (Ctrl.MinDate != value)
                //{
                //    Ctrl.MinDate = value;
                //}
                Ctrl.MinDate = value;
            }
        }


        private DateTime dt =  DateTime.Now;
        public DateTime Value
        {
            get { return dt;  }
            set 
            {
                dt = value;
                GetDate?.Invoke(this, value);
            }
        }
        #endregion

        #region -> Event - override - methods

        public event EventHandler<DateTime> GetDate;

        public void Show(Control control)
        {
            
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            Show(control, control.ClientRectangle);
        }
        private void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;

            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                location.Y -= Size.Height + area.Height;
            }

            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.Right);
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if (Ctrl.IsDisposed || Ctrl.Disposing)
            {
                e.Cancel = true;
                return;
            }
            base.OnOpening(e);
        }
        protected override void OnOpened(EventArgs e)
        {
            Ctrl.Focus();
            base.OnOpened(e);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (Ctrl != null)
                {
                    System.Windows.Forms.Control _content = Ctrl;
                    Ctrl = null;
                    _content.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{//prevent alt from closing it and allow alt+menumonic to work
        //    if ((keyData & Keys.Alt) == Keys.Alt)
        //    {
        //        return false;
        //    }

        //    return base.ProcessDialogKey(keyData);
        //}
        #endregion
    }
}
/*
 old 

  public class DropDownContainer : ToolStripDropDown
    {
        private System.ComponentModel.IContainer components = null;
        private MonthCalendar Ctrl;
        private ToolStripControlHost m_host;
        //private bool m_fade = true;
        public bool IsClosed = false;


        private DateTime dt =  DateTime.Now;

        public DateTime Value
        {
            get { return dt;  }
            set { dt = value; }
        }

        public DropDownContainer(MonthCalendar control)
        {
            components = new System.ComponentModel.Container();
            if (control == null) { throw new ArgumentNullException("content"); }
            this.Ctrl = new MonthCalendar();
            //this.m_fade = SystemInformation.IsMenuAnimationEnabled && SystemInformation.IsMenuFadeEnabled;
            this.m_host = new ToolStripControlHost(control);
            m_host.AutoSize = false;//make it take the same room as the poped control
            Padding = Margin = m_host.Padding = m_host.Margin = Padding.Empty;
            control.Location = Point.Empty;
            this.Items.Add(m_host);

            this.Closing += DropDownContainer_Closing;
            control.Disposed += delegate (object sender, EventArgs e)
            {
                control = null;
                Dispose(true);// this popup container will be disposed immediately after disposion of the contained control
            };
        }

        private void DropDownContainer_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            op.x = true;
        }





        //public new void Close()
        //{
        //    base.Close(ToolStripDropDownCloseReason.CloseCalled);
        //    IsClosed = true;
        //    Dispose(true);
        //}
        public void Show(Control control)
        {
            
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            Show(control, control.ClientRectangle);
        }

        private void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;

            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                location.Y -= Size.Height + area.Height;
            }

            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.Right);
        }

        //private const int frames = 5;
        //private const int totalduration = 100;
        //private const int frameduration = totalduration / frames;

        //protected override void SetVisibleCore(bool visible)
        //{
        //    double opacity = Opacity;
        //    if (visible && m_fade)
        //    {
        //        Opacity = 0;
        //    }
        //    base.SetVisibleCore(visible);

        //    if (!visible || !m_fade) return;

        //    for (int i = 1; i <= frames; i++)
        //    {
        //        if (i > 1)
        //        {
        //            System.Threading.Thread.Sleep(frameduration);
        //        }
        //        Opacity = opacity * (double)i / (double)frames;
        //    }
        //    Opacity = opacity;
        //}
        protected override void OnOpening(CancelEventArgs e)
        {
            if (Ctrl.IsDisposed || Ctrl.Disposing)
            {
                e.Cancel = true;
                return;
            }
            base.OnOpening(e);
        }
        protected override void OnOpened(EventArgs e)
        {
            Ctrl.Focus();
            base.OnOpened(e);
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{//prevent alt from closing it and allow alt+menumonic to work
        //    if ((keyData & Keys.Alt) == Keys.Alt)
        //    {
        //        return false;
        //    }

        //    return base.ProcessDialogKey(keyData);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (Ctrl != null)
                {
                    System.Windows.Forms.Control _content = Ctrl;
                    Ctrl = null;
                    _content.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }

//partial class DropDownContainer
    //{
    //    //private System.ComponentModel.IContainer components = null;

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            if (components != null)
    //            {
    //                components.Dispose();
    //            }
    //            if (Ctrl != null)
    //            {
    //                System.Windows.Forms.Control _content = Ctrl;
    //                Ctrl = null;
    //                _content.Dispose();
    //            }
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        components = new System.ComponentModel.Container();
    //    }
    //}


 */