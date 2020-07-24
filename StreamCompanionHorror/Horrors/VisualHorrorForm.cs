using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace StreamCompanionHorror.Horrors
{
    public partial class VisualHorrorForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        public VisualHorrorForm(Image image)
        {
            InitializeComponent();
            horrorPicture.Image = image;
            horrorPicture.BackColor = Color.Transparent;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            var rect = Screen.PrimaryScreen.WorkingArea;
            Location = new Point(rect.X, rect.Y);

            TopMost = true;
            TopLevel = true;

            BackColor = Color.DeepPink;
            TransparencyKey = Color.DeepPink;
            WindowState = FormWindowState.Maximized;
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var style = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, style | 0x80000 | 0x20);
            SetWindowPos(Handle, new IntPtr(-1), 0, 0, 0, 0, 0x1 | 0x2);
            Focus();
            Invalidate();
            Update();
            Thread.Sleep(1000);
            Close();
        }
    }
}
