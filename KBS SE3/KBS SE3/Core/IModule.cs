using Casualty_Radar.Models;

namespace Casualty_Radar.Core {
     public interface IModule {

        /*
        * Returns the name of the Module
        */
        Breadcrumb GetBreadcrumb();
    }
}
