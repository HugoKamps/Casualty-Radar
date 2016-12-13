using System.Threading;
using System.Windows.Forms;

namespace KBS_SE3 {
    public partial class SplashScreen : Form {

        //Delegate for cross thread call to close
        private delegate void CloseDelegate();
        private static SplashScreen _splashScreen;

        private SplashScreen() {
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
    }
}
