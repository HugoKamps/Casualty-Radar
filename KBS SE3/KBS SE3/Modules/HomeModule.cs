using System;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule {
        public HomeModule() {
            InitializeComponent();
            var locationManager = new LocationManager(mapBox);            
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));
        }

        private void refreshFeedButton_Click(object sender, EventArgs e){
            Feed.GetInstance().UpdateAlerts();
        }
    }
}

