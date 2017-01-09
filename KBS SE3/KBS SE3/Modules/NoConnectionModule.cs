using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Models;

namespace Casualty_Radar.Modules {
    partial class NoConnectionModule : UserControl, IModule {

        public NoConnectionModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Geen verbinding!");
        }
    }
}
