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
    partial class SettingsModule : UserControl, IModule {
        public SettingsModule() {
            InitializeComponent();
            locationTextBox.Text = Properties.Settings.Default.userLocation;
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Settings");
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            Properties.Settings.Default.userLocation = locationTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
