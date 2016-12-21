using System;
using System.Threading;
using System.Windows.Forms;

namespace Casualty_Radar.Modules {
    public partial class SplashScreenModule : UserControl {
        public long StartTime { get; private set; }
        public long EndTime { get; private set; }

        public SplashScreenModule() {
            InitializeComponent();
        }

        //Getter and setter for the label which indicates what the application is currently loading
        public Label CurrentlyLoadingLabel { get; set; }

        //Override for the Show method which sets a timestamp when the splashscreen is being displayed
        public new void Show() {
            base.Show();
        }

        //Override for the Hide method which sets a timestamp when the splashscreen is being hidden
        public new void Hide() {
            EndTime = DateTime.Now.Ticks;
            long difference = (EndTime - StartTime) / 10000;
            if (difference < 1000) Thread.Sleep(1000 - int.Parse(difference.ToString()));
            base.Hide();
        }
    }
}
