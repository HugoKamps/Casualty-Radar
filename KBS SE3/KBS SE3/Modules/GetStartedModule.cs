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
     partial class GetStartedModule : UserControl, IModule {
        public GetStartedModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb()
        {
            return new Breadcrumb(this, "Get started", null, ModuleManager.GetInstance().ParseInstance(typeof(HomeModule)));   
        }
    }
}
