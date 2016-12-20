using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.DataControl.Graph.Ways {
    public class WayTypeControl {

        public WayTypeControl() {
            Init();
        }

        private void Init() {
            var wayTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => a.IsClass && a.Namespace != null && 
                a.Namespace.Contains(@"KBS_SE3.Models.DataControl.Graph.Ways.WayTypes")).ToList();
            foreach (Type t in wayTypes) {
                Console.WriteLine(t.Name);
            }
        }
    }
}
