using System;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Models;
using Casualty_Radar.Properties;

namespace Casualty_Radar.Modules {
    /// <summary>
    /// Module which is displayed when the user starts the application for the first time. Contains a field where the user needs to fill in his location in case the user's PC doesn't support location services.
    /// </summary>
    partial class GetStartedModule : UserControl, IModule {
        public GetStartedModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Get started");
        }

        /// <summary>
        /// This event checks if the user filled in a location. If so, the user is redirected to the HomeModule, if not, a warning is displayed.
        /// </summary>
        private void continueBtn_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(locationTextBox.Text)) {
                Settings.Default.userLocation = locationTextBox.Text;
                Settings.Default.Save();
                SettingsModule s = (SettingsModule) ModuleManager.GetInstance().ParseInstance(typeof(SettingsModule));
                s.locationTextBox.Text = locationTextBox.Text;
                ModuleManager.GetInstance().UpdateModule(ModuleManager.GetInstance().ParseInstance(typeof(HomeModule)));
            }
            else {
                warningLabel.Show();
            }
        }
    }
}