﻿using System.Net;

namespace KBS_SE3 {
    static class ConnectionUtil {

        //Function that returns true if the user has a working internet connection
        public static bool HasInternetConnection() {
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
