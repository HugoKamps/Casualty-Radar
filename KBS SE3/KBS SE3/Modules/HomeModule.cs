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
    public partial class HomeModule : UserControl, IModule {
        private BindingList<Alert> alerts;
        private static HomeModule instance;

        public HomeModule() {
            InitializeComponent();
            instance = this;
            alerts = new BindingList<Alert>(Feed.Instance.Alerts);
            listBox1.DataSource = alerts;
        }

        public void UpdateAlerts()
        {
            listBox1.DataSource = null;
            alerts = new BindingList<Alert>(Feed.Instance.Alerts);
            listBox1.DataSource = alerts;
        }


        public string GetModuleName() {
            return "Home";
        }

        public static HomeModule Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomeModule();
                }
                return instance;
            }
        }

    }
}

