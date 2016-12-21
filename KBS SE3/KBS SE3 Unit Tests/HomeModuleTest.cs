using System;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBS_SE3_Unit_Tests {
    [TestClass]
    public class HomeModuleTest {
        [TestMethod]
        public void InstanceTest() {
            IModule mod = ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if hm is an instance of HomeModule
            Assert.IsInstanceOfType(mod, typeof(HomeModule));
        }

        [TestMethod]
        public void IsRefreshing() {
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
        public void GetLocationManager() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if GetLocationManager() returns an instance of LocationManager
            Assert.IsInstanceOfType(hm.GetLocationManager(), typeof(LocationManager));
        }

        [TestMethod]
        public void SetLocationManager() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            var newLM = new LocationManager();

            hm.LocationManager = newLM;

            //Test if SetLocationManager() sets the locationmanager
            Assert.AreEqual(hm.GetLocationManager(), newLM);
        }

        [TestMethod]
        public void GetSelectedPanel() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if GetSelectedPanel() returns null as none is selected
            Assert.AreEqual(hm.GetSelectedPanel, null);
        }

        [TestMethod]
        public void GetAlertType() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            // Test if GetAlertType() returns an integer
            Assert.IsInstanceOfType(hm.GetAlertType, typeof(int));
        }

        [TestMethod]
        public void CreateAlert() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            var panel = hm.CreateAlertPanel(0, "", "", "", 0);

            // Test if CreateAlertPanel() returns a Panel
            Assert.IsInstanceOfType(panel, typeof(Panel));
        }
    }
}
