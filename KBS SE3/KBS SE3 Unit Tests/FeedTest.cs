using System.Collections.Generic;
using Casualty_Radar.Core;
using Casualty_Radar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBS_SE3_Unit_Tests {
    [TestClass]
    public class FeedTest {
        [TestMethod]
        public void Feed_InstanceTest() {
            Feed feed = Feed.GetInstance();

            // Test if feed is an instance of Feed
            Assert.IsInstanceOfType(feed, typeof(Feed));
        }

        [TestMethod]
        public void Feed_Alerts() {
            Feed feed = Feed.GetInstance();

            // When feed gets initialized, an alerts list should be created with the CreateAlertList() method
            List<Alert> alerts = feed.GetAlerts;

            // Test if alerts is created
            Assert.IsNotNull(alerts);
        }

        [TestMethod]
        public void Feed_UpdateAlerts() {
            Feed feed = Feed.GetInstance();

            // Get alerts after initialization
            List<Alert> oldAlerts = feed.GetAlerts;
            // Update the feed
            feed.UpdateFeed();
            // Get alerts after update
            List<Alert> alerts = feed.GetAlerts;

            // Test if oldAlerts is not equal to the alerts after the update
            Assert.AreNotEqual(oldAlerts, alerts);
            // Test if NewAlerts is set
            Assert.IsNotNull(feed.GetNewAlerts);
            // Test if FilteredAlerts is set
            Assert.IsNotNull(feed.GetFilteredAlerts);
        }
    }
}