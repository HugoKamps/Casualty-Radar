using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;

namespace KBS_SE3.Modules {
     partial class GetStartedModule : UserControl, IModule {
        public GetStartedModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Get started");   
        }

        //This function checks if the user filled in a location. If so, the user is redirected to the HomeModule, if not, a warning is displayed.
        private void continueBtn_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(locationTextBox.Text)) {
                var c = KBS_SE3.Container.GetInstance();
                Properties.Settings.Default.userLocation = locationTextBox.Text;
                Properties.Settings.Default.Save();
                var s = (SettingsModule) ModuleManager.GetInstance().ParseInstance(typeof (SettingsModule));
                s.locationTextBox.Text = locationTextBox.Text;
                ModuleManager.GetInstance().UpdateModule(c.breadCrumbStart, c.contentPanel, ModuleManager.GetInstance().ParseInstance(typeof (HomeModule)));
            } else {
                warningLabel.Show();
            }
        }
     }
}
