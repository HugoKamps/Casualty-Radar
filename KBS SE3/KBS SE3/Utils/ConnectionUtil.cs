using System.IO;
using System.Net;

namespace Casualty_Radar {
    static class ConnectionUtil {

        /// <summary>
        /// Function that returns true if the user has a working internet connection
        /// </summary>
        /// <returns>True if there's an internet connection, false if there isn't one</returns>
        public static bool HasInternetConnection() {
            try {
                using (WebClient client = new WebClient()) {
                    using (Stream stream = client.OpenRead("http://www.google.com")) {
                        return true;
                    }
                }
            } catch {
                return false;
            }
        }
    }
}
