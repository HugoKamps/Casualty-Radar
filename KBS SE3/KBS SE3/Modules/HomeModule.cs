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
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule {
        private static HomeModule _instance;

        public HomeModule() {
            InitializeComponent();
            var locationManager = new LocationManager(mapBox);

            // If there is not an instance yet, set it
            if (_instance == null)
            {
                _instance = this;
            }
            
            // Set the datasource for the listbox
            listBox1.DataSource = new BindingList<Alert>(Feed.Instance.Alerts);
        }

        public void UpdateAlerts()
        {
            // Change the datasource so the listbox will update it's items
            listBox1.DataSource = null;
            listBox1.DataSource = new BindingList<Alert>(Feed.Instance.Alerts);
            listBox1.DisplayMember = "Title";
        }

        public static HomeModule Instance
        {
            get
            {
                if (_instance == null)
                {
                   _instance = new HomeModule();
                }
                   
                return _instance;
            }
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));
        }
    }
}

