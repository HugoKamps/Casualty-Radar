using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace KBS_SE3 {
    public partial class SplashScreen : Form {

        //Delegate for cross thread call to close
        private delegate void CloseDelegate();
        private static SplashScreen _splashScreen;

        public SplashScreen() {
            InitializeComponent();
        }

        static public void ShowSplashScreen() {
            // Make sure the splashscreen is only launched once
            if (_splashScreen != null)
                return;
            Thread thread = new Thread(ShowForm) { IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm() {
            _splashScreen = new SplashScreen();
            Application.Run(_splashScreen);
        }

        public static void CloseForm() => _splashScreen.Invoke(new CloseDelegate(CloseFormInternal));

        static private void CloseFormInternal() => _splashScreen.Close();

        private void SplashScreen_Shown(object sender, System.EventArgs e) {
            Container c = null;
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += delegate {
                c = KBS_SE3.Container.GetInstance();
            };

            bw.RunWorkerCompleted += delegate {
                c.Show();
                this.Hide();
            };
        }
    }
}
