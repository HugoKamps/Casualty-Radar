﻿using KBS_SE3.Utils;
using System;
using System.Windows.Forms;

namespace KBS_SE3 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.GetInstance());
            DatabaseUtil.getDbInstance().SetDBConnection();
        }
    }
}
