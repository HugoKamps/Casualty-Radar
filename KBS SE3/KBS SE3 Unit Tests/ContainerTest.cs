using Casualty_Radar;
using Casualty_Radar.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBS_SE3_Unit_Tests {
    [TestClass]
    public class ContainerTest {
        [TestMethod]
        public void Container_InstanceTest() {
            Container ct = Container.GetInstance();

            Assert.IsInstanceOfType(ct, typeof(Container));
        }

        [TestMethod]
        public void Container_SplashScreenTest() {
            Container ct = Container.GetInstance();
            SplashScreenModule sC = ct.SplashScreen;

            // Test if Splashscreen is not null
            Assert.AreNotEqual(null, sC);
        }
    }
}
