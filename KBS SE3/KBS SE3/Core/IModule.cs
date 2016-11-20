using KBS_SE3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Core {
     interface IModule {

        /*
        * Returns the name of the Module
        */
        Breadcrumb GetBreadcrumb();
    }
}
