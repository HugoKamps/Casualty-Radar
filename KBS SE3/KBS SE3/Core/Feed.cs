using KBS_SE3.Modules;
using KBS_SE3.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using GMap.NET.WindowsForms;
using KBS_SE3.Models;

namespace KBS_SE3.Core {
    internal class Feed {
        private static Feed _instance;
        private SyndicationFeed _p2000;
        private readonly string FEED_URL = "http://feeds.livep2000.nl/";
        private readonly string CACHED_FEED_URL = "http://web.archive.org/web/http://feeds.livep2000.nl/";
        private readonly string LOCAL_FEED_URL = @"../../feed.xml";
        private List<Alert> _alerts;
        private List<Alert> _filteredAlerts;

        public static Feed GetInstance() {
            if (_instance == null) _instance = new Feed();
            return _instance;
        }

        private Feed() {
            try {
                _p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                _alerts = CreateAlertList(_p2000);
                /* Initial update - Only updates after the P2000 is read.*/
                UpdateFeed();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }


        public List<Alert> GetAlerts() => _alerts;
        public List<Alert> GetFilteredAlerts => _filteredAlerts;

        public List<Alert> CreateAlertList(SyndicationFeed items) {
            var tempAlerts = new List<Alert>();
            foreach (var item in items.Items.OrderBy(x => x.PublishDate)) {
                Alert newAlert = createAlert(item);

                if (newAlert != null)
                    tempAlerts.Add(newAlert);
            }
            tempAlerts.Reverse();
            return tempAlerts;
        }

        private Alert createAlert(SyndicationItem item) {
            // Check if the item has 2 attributes which are Lat & Long
            if (item.ElementExtensions.Count == 2) {
                string alertItemString = item.Title.Text.Replace("(Directe Inzet: ", "").ToUpper();
                string lat = item.ElementExtensions.Reverse().Skip(1).Take(1).First().GetObject<XElement>().Value;
                string lng = item.ElementExtensions.Last().GetObject<XElement>().Value;
                double parsedLat = double.Parse(lat, CultureInfo.InvariantCulture);
                double parsedLng = double.Parse(lng, CultureInfo.InvariantCulture);
                Alert newAlert = new Alert(item.Title.Text, item.Summary.Text, item.PublishDate, parsedLat, parsedLng);

                return AlertUtil.SetAlertAttributes(newAlert, alertItemString);
            }
            return null;
        }

        public void UpdateFeed() {
            SyndicationFeed oldP2000 = _p2000;
            List<SyndicationItem> newItems = new List<SyndicationItem>();
            SyndicationFeed newFeed = new SyndicationFeed();

            // Load the feed
            try {
                // Get the first item from the old feed
                SyndicationItem first = oldP2000.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault();
                _p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                _alerts = CreateAlertList(_p2000);

                /* 
                Loop through the new feed
                If the first item from the old feed is not identical to the first item of the new feed,
                add it to the list of new items.
                Else, end the loop. 
                */
                foreach (var item in _p2000.Items)
                    if (item.Title.Text != first.Title.Text) newItems.Add(item);
                    else break;

                newFeed.Items = newItems;
                List<Alert> newAlerts = CreateAlertList(newFeed);

                if (newAlerts.Count > 0 && Container.GetInstance().WindowState == FormWindowState.Minimized)
                    new PushMessage(newAlerts);
                UpdateAlerts();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        // Update the displayed alerts with the new feed
        public void UpdateAlerts() {
            HomeModule hM = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            int selectedFilter = hM.GetAlertType;
            // Check which filter is selected and apply the filter
            if (selectedFilter == 1 || selectedFilter == 2) {
                _filteredAlerts = new List<Alert>();
                foreach (var a in _alerts)
                    if (a.Type == selectedFilter) _filteredAlerts.Add(a);
            } else _filteredAlerts = _alerts;
            hM.DisplayLoadIcon();
            hM.LoadComponents();
        }

    }
}