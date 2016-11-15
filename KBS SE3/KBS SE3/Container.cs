using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KBS_SE3 {
    public partial class Container : Form {

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x20000;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public Container() {
            InitializeComponent();
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void minimizeBtn_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void topBarButtons_MouseEnter(object sender, EventArgs e) {
            Label selected = (Label) sender;
            selected.BackColor = Color.FromArgb(220, 82, 66);
        }

        private void topBarButtons_MouseLeave(object sender, EventArgs e) {
            Label selected = (Label)sender;
            selected.BackColor = Color.FromArgb(210, 73, 57);
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
