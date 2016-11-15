using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS_SE3.Core {
    class ModuleManager {

        private static ModuleManager _instance;

        private ModuleManager() { }

        public static ModuleManager GetInstance() {
            if (_instance == null) _instance = new ModuleManager();
            return _instance;
        }

        public void UpdateModule(Label headerLabel, Panel contentPanel, Object module) {
            if(module != null) {
                IModule reInitialized = (IModule)Activator.CreateInstance(module.GetType());
                if(headerLabel != null) headerLabel.Text = reInitialized.GetModuleName();
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add((UserControl) module);
            }
        }
    }
}
