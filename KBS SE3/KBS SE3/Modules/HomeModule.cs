﻿using System;
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
    }
}

