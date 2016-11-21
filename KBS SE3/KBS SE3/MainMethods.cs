﻿using System.Net;

namespace KBS_SE3 {
    static class MainMethods {
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
