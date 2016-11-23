using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;

namespace KBS_SE3.Modules {
    partial class NoConnectionModule : UserControl, IModule {
        public NoConnectionModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb()
        {
            return new Breadcrumb(this, "Geen verbinding!");
        }
    }
}
