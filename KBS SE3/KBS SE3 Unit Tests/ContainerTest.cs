using KBS_SE3;
using KBS_SE3.Core;
using KBS_SE3.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBS_SE3_Unit_Tests {
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void InstanceTest()
        {
            Container ct = Container.GetInstance();

            Assert.IsInstanceOfType(ct, typeof(Container));
        }

        [TestMethod]
        public void SplashScreenTest()
        {
            Container ct = Container.GetInstance();
            var sC = ct.SplashScreen;

            // Test if Splashscreen is not null
            Assert.AreNotEqual(null, sC);
        }
    }
}
