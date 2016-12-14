using KBS_SE3.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace KBS_SE3 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //TODO: Bring container to front
            //SplashScreen.ShowSplashScreen();
            //Container.GetInstance();
            //Thread.Sleep(3000);
            //SplashScreen.CloseForm();
            

            Application.Run(Container.GetInstance());
        }
    }
}
