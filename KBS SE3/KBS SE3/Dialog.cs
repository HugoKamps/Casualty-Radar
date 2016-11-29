using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KBS_SE3.Core.Dialog.DialogType;
using KBS_SE3.Core.Dialog;
using System.Runtime.InteropServices;

namespace KBS_SE3 {
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

        public void Display(DialogMessageType type, String title, String content) {
            dialogHeaderTitle.Text = DialogType.ParseHeaderMessage(type)+": ";
            dialogHeaderText.Text = title;
        }

        private void dialogCloseBtn_Click(object sender, EventArgs e) {
            this.Close();
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
