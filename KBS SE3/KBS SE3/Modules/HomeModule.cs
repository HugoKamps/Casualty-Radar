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

namespace KBS_SE3.Modules {
    public partial class HomeModule : UserControl, IModule {
        private static HomeModule instance;
        private BindingList<Alert> alerts;

        public HomeModule() {
            InitializeComponent();
            instance = this;
            //listBox1.DataSource = new BindingList<Alert>(Feed.Instance.Alerts);
            foreach(Alert a in Feed.Instance.Alerts)
            {
                listBox1.Items.Add(a.Title);
            }
        }

        public void UpdateAlerts()
        {
            listBox1.Items.Clear();
            foreach (Alert a in Feed.Instance.Alerts)
            {
                listBox1.Items.Add(a.Title);
            }
            //listBox1.DataSource = null;
            //listBox1.Items.Clear();
            //listBox1.DataSource = new BindingList<Alert>(Feed.Instance.Alerts);
            //listBox1.DisplayMember = "Title";
        }


        public string GetModuleName() {
            return "Home";
        }

        public static HomeModule Instance
        {
            get
            {
                return instance;
            }
        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
            UpdateAlerts();   
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateAlerts();
        }
    }
}

