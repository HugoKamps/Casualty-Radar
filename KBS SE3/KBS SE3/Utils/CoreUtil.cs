using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Utils {
    static class CoreUtil {

        /*
        * Returns true if the application can connect to the internet
        * Returns false if there is no internet connection (therefore the app doesn't work)
        */
        public static bool CheckForInternetConnection() {
            try {
                using (var client = new WebClient()) {
                    using (var stream = client.OpenRead("http://www.google.com")) {
                        return true;
                    }
                }
            } catch {
                return false;
            }
        }
    }
}
