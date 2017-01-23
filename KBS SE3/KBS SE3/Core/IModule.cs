using Casualty_Radar.Models;

namespace Casualty_Radar.Core {
    public interface IModule {
        /// <summary>
        /// Returns the breadcrumb from the module, this is used for our navigation within the application
        /// </summary>
        /// <returns>An instance of the breadcrumb class</returns>
        Breadcrumb GetBreadcrumb();
    }
}