using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Models;

namespace Casualty_Radar.Modules
{
    partial class TestModule : UserControl, IModule
    {
        public TestModule()
        {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb()
        {
            return new Breadcrumb(this, "Testmodule");
        }
    }
}
