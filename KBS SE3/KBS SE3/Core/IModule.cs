using Casualty_Radar.Models;

namespace Casualty_Radar.Core {
     public interface IModule {

        /// <summary>
        /// Returns the breadcrumb from the module
        /// </summary>
        /// <returns>An instance of the breadcrumb class</returns>
        Breadcrumb GetBreadcrumb();
    }
}
