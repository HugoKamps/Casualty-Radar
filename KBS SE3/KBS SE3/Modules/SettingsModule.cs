﻿using System;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Properties;

namespace KBS_SE3.Modules {
    partial class SettingsModule : UserControl, IModule {
        public SettingsModule() {
            InitializeComponent();
            locationTextBox.Text = Settings.Default.userLocation;
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Settings");
        }

        //If the user changed the value of the textbox the Setting is changed
        private void saveBtn_Click(object sender, EventArgs e) {
            if (locationTextBox.Text != "") {
                Settings.Default.userLocation = locationTextBox.Text;
                Settings.Default.Save();
            } else {
                warningLabel.Show();
            }
        }
    }
}
