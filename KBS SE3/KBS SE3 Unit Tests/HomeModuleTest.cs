using System;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBS_SE3_Unit_Tests {
    [TestClass]
    public class HomeModuleTest {
        [TestMethod]
        public void HomeModule_InstanceTest() {
            IModule mod = ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if hm is an instance of HomeModule
            Assert.IsInstanceOfType(mod, typeof(HomeModule));
        }

        [TestMethod]
        public void HomeModule_IsRefreshing() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            bool expected = false;

            // Test if IsRefreshing is equal to expected (true)
            Assert.AreEqual(hm.IsRefreshing, expected);

            // Set IsRefreshing
            hm.IsRefreshing = true;

            // Test if IsRefreshing is no longer equal to expected
            Assert.AreNotEqual(hm.IsRefreshing, expected);
        }

        [TestMethod]
        public void HomeModule_GetLocationManager() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if GetLocationManager() returns an instance of LocationManager
            Assert.IsInstanceOfType(hm.GetLocationManager(), typeof(LocationManager));
        }

        [TestMethod]
        public void HomeModule_SetLocationManager() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            var newLm = new LocationManager();

            hm.LocationManager = newLm;

            //Test if SetLocationManager() sets the locationmanager
            Assert.AreEqual(hm.GetLocationManager(), newLm);
        }

        [TestMethod]
        public void HomeModule_GetAlertType() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if GetAlertType() returns an integer
            Assert.IsInstanceOfType(hm.GetAlertType, typeof(int));
        }

        [TestMethod]
        public void HomeModule_CreateAlert() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            var panel = hm.CreateAlertPanel(0, "", "", "", 0);

            // Test if CreateAlertPanel() returns a Panel
            Assert.IsInstanceOfType(panel, typeof(Panel));
        }
    }
}
