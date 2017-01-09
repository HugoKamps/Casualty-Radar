using System.Windows.Forms;

namespace Casualty_Radar.Modules {
    public partial class SplashScreenModule : UserControl {

        public SplashScreenModule() {
            InitializeComponent();
        }

        /// <summary>
        /// Getter and setter for the label which indicates what the application is currently loading
        /// </summary>
        public Label CurrentlyLoadingLabel { get; set; }

    }
}
