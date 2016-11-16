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

namespace KBS_SE3.Modules {
    public partial class SettingsModule : UserControl, IModule {
        public SettingsModule() {
            InitializeComponent();
        }

        public string GetModuleName() {
            return "Settings";
        }
    }
}
