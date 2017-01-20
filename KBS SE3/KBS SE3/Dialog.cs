using System;
using System.Drawing;
using System.Windows.Forms;
using static Casualty_Radar.Core.Dialog.DialogType;
using System.Runtime.InteropServices;

namespace Casualty_Radar {
     public partial class Dialog : Form {

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public Dialog() {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the dialog interface with the given properties.
        /// This method is purely for initialization purposes and shouldn't be called randomly.
        /// </summary>
        /// <param name="type">The type of the dialog</param>
        /// <param name="title">The title of the dialog</param>
        /// <param name="content">The message content of the dialog</param>
        public void Display(DialogMessageType type, string title, string content) {
            dialogHeaderTitle.Text = ParseHeaderMessage(type)+": ";
            dialogHeaderText.Text = title;
            dialogContentLabel.Text = content;
            Bitmap img = GetDialogIcon(type);
            img.MakeTransparent(Color.White);
            dialogIconPicturebox.Image = img;
        }

        private void dialogCloseBtn_Click(object sender, EventArgs e) {
            Close();
        }

        private void dialogCloseBtn_MouseEnter(object sender, EventArgs e) {
            Control selected = (Control)sender;
            selected.BackColor = Color.FromArgb(220, 82, 66);
        }

        private void dialogCloseBtn_MouseLeave(object sender, EventArgs e) {
            Control selected = (Control)sender;
            selected.BackColor = Color.FromArgb(210, 73, 57);
        }

        private void dialogHeader_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
