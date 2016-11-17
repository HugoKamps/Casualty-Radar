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
    partial class HomeModule : UserControl, IModule {
        public HomeModule() {
            InitializeComponent();

            var points = new List<string>()
            {
                "52.501356,6.083451",
                "52.501988,6.082142"
            };
            GetMap(LocationManager.GetLocationProperty(), points);
        }

        public void GetMap(string currentLocation, List<string> locations) {
            var url = "https://maps.googleapis.com/maps/api/staticmap?center=" + currentLocation + "&zoom=15&size=700x480&maptype=terrain&";
            url += "markers=color:blue%7Clabel:L%7C" + currentLocation + "&";

            foreach (var location in locations) {
                url += "markers=color:red%7Clabel:O%7C" + location + "&";
            }
            
            url += "&key=AIzaSyDoRzUMAF3osX972CDWR2rDoWc9nKafV5A";
                mapTest.Load(url);
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", new NavigationModule());
        }

    }
}
