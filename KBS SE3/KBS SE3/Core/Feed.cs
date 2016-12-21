using Casualty_Radar.Modules;
using Casualty_Radar.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Casualty_Radar.Core.Dialog;
using Casualty_Radar.Models;

namespace Casualty_Radar.Core {
    public class Feed {
        private static Feed _instance;
        private SyndicationFeed _p2000;
        private readonly string FEED_URL = "http://feeds.livep2000.nl/";
        private readonly string CACHED_FEED_URL = "http://web.archive.org/web/http://feeds.livep2000.nl/";
        private string USE_FEED_URL;
        private List<Alert> _alerts;
        private List<Alert> _filteredAlerts;
        private List<Alert> _newAlerts;

        public static Feed GetInstance() {
            if (_instance == null) _instance = new Feed();
            return _instance;
        }

        private Feed() {
            try {
                _p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                USE_FEED_URL = FEED_URL;
            } catch (WebException) {
                Container.GetInstance().DisplayDialog(DialogType.DialogMessageType.WARNING, "Website is niet bereikbaar", "Een gecachede versie van deze website wordt ingeladen");
                _p2000 = SyndicationFeed.Load(XmlReader.Create(CACHED_FEED_URL));
                USE_FEED_URL = CACHED_FEED_URL;
            }
            _alerts = CreateAlertList(_p2000);
            /* Initial update - Only updates after the P2000 is read.*/
            UpdateFeed();
        }


        public List<Alert> GetAlerts() => _alerts;
        public List<Alert> GetFilteredAlerts => _filteredAlerts;
        public List<Alert> GetNewAlerts => _newAlerts;

        public List<Alert> CreateAlertList(SyndicationFeed items) {
            List<Alert> tempAlerts = new List<Alert>();
            foreach (SyndicationItem item in items.Items.OrderBy(x => x.PublishDate)) {
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
                Alert newAlert = new Alert(item.Title.Text.Replace("~", " "), item.Summary.Text, item.PublishDate, parsedLat, parsedLng);

                return AlertUtil.SetAlertAttributes(newAlert, alertItemString);
            }
            return null;
        }

        public void UpdateFeed() {
            List<Alert> oldAlerts = _alerts;
            _newAlerts = new List<Alert>();
            // Load the feed

            try {
                _p2000 = SyndicationFeed.Load(XmlReader.Create(USE_FEED_URL));
                _alerts = CreateAlertList(_p2000);

                /* 
                Loop through the new feed
                If the first item from the old feed is not identical to the first item of the new feed,
                add it to the list of new items.
                Else, end the loop. 
                */
                foreach (Alert item in _alerts)
                    if (item.Title != oldAlerts[0].Title) {
                        _newAlerts.Add(item);
                    } else break;

                if (_newAlerts.Count > 0 && Container.GetInstance().WindowState == FormWindowState.Minimized)
                    new PushMessage(_newAlerts);
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
                foreach (Alert a in _alerts)
                    if (a.Type == selectedFilter) _filteredAlerts.Add(a);
            } else _filteredAlerts = _alerts;
            hM.DisplayLoadIcon();
            hM.LoadComponents();
        }

    }
}