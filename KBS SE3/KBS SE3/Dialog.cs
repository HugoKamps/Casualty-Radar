using System;
using System.Drawing;
using System.Windows.Forms;
using static KBS_SE3.Core.Dialog.DialogType;
using System.Runtime.InteropServices;

namespace KBS_SE3 {
     public partial class Dialog : Form {

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int DIALOG_ICON_SIZE = 25;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public Dialog() {
            InitializeComponent();
        }

        /*
        * Initializes the dialog interface with the given properties.
        * This method is purely for initialization purposes and shouldn't be called randomly.
        */
        public void Display(DialogMessageType type, string title, string content) {
            dialogHeaderTitle.Text = ParseHeaderMessage(type)+": ";
            dialogHeaderText.Text = title;
            dialogContentLabel.Text = content;
            dialogIconPicturebox.Image = (Image)GetDialogIcon(type);
        }

        private void dialogCloseBtn_Click(object sender, EventArgs e) {
            Close();
        }

        private void dialogCloseBtn_MouseEnter(object sender, EventArgs e) {
            Label selected = (Label)sender;
            selected.BackColor = Color.FromArgb(220, 82, 66);
        }

        private void dialogCloseBtn_MouseLeave(object sender, EventArgs e) {
            Label selected = (Label)sender;
            selected.BackColor = Color.FromArgb(210, 73, 57);
        }

        private void dialogHeader_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
