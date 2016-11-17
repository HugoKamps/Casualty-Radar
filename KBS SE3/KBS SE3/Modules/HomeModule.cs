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
    partial class HomeModule : UserControl, IModule {
        public HomeModule() {
            InitializeComponent();
            var locationManager = new LocationManager(mapBox);
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", new NavigationModule());
        }

    }
}
