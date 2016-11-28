using System;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using KBS_SE3.Core;
using KBS_SE3.Models;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule
    {
        private readonly LocationManager _locationManager;
        public HomeModule() {
            InitializeComponent();
             _locationManager = new LocationManager(map);            
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));
        }

        private void refreshFeedButton_Click(object sender, EventArgs e) {
            Feed.GetInstance().UpdateFeed();
            _locationManager.GetMap(false);
        }

        private void alertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Feed.GetInstance().UpdateAlerts();
            _locationManager.GetMap(false);
        }

        private void navigationBtn_Click(object sender, EventArgs e) {
            Feed.GetInstance().TriggerEvent = false;
            var navigationModule = (NavigationModule)ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule));

            foreach (Control c in Feed.GetInstance().GetSelectedPanel.Controls) {
                navigationModule.alertInfoPanel.Controls.Add(c);
            }

            ModuleManager.GetInstance().UpdateModule(KBS_SE3.Container.GetInstance().breadCrumbStart, KBS_SE3.Container.GetInstance().contentPanel, navigationModule);
        }

        private void navigationBtn_EnabledChanged(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.ForeColor = Color.White;
            button.BackColor = button.Enabled ? Color.FromArgb(210, 73, 57) : Color.Gray;
        }
    }
}

