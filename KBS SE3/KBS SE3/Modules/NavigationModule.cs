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
     partial class NavigationModule : UserControl, IModule {
        public NavigationModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Navigation", null, ModuleManager.GetInstance().ParseInstance(typeof(HomeModule)));
        }

         public void SetAlertInfo(string title, string info, int type, string time) {
             infoTitleLabel.Text = title + "\n" + info;
             alertTypePicturebox.Image = type == 1 ? Properties.Resources.Medic : Properties.Resources.Firefighter;
             timeLabel.Text = time;
         }
    }
}
