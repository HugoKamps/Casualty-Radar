using KBS_SE3.Models;

namespace KBS_SE3.Core {
     public interface IModule {

        /// <summary>
        /// Returns the breadcrumb from the module
        /// </summary>
        /// <returns>An instance of the breadcrumb class</returns>
        Breadcrumb GetBreadcrumb();
    }
}
