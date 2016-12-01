using KBS_SE3.Models;

namespace KBS_SE3.Core {
     interface IModule {

        /*
        * Returns the name of the Module
        */
        Breadcrumb GetBreadcrumb();
    }
}
