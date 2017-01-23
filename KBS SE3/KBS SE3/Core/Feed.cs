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
using Casualty_Radar.Modules;
using Casualty_Radar.Utils;

namespace Casualty_Radar.Core {
    /// <summary>
    /// The feed class arranges all the functionalities for the alerts
    /// In this class we create,update and filter the alert and refresh the feed
    /// </summary>
    public class Feed {
        private static Feed _instance;
        private SyndicationFeed _p2000;
        private readonly string FEED_URL = "http://feeds.livep2000.nl/";
        private readonly string CACHED_FEED_URL = "http://web.archive.org/web/http://feeds.livep2000.nl/";
        private readonly string USE_FEED_URL;
        private List<Alert> _alerts;
        private List<Alert> _filteredAlerts;
        private List<Alert> _newAlerts;

        /// <summary>
        /// Returns a single-ton instance from the Feed class
        /// </summary>
        /// <returns>Feed instance</returns>
        public static Feed GetInstance() => _instance ?? (_instance = new Feed());

        public List<Alert> GetAlerts => _alerts;
        public List<Alert> GetFilteredAlerts => _filteredAlerts;
        public List<Alert> GetNewAlerts => _newAlerts;

        /// <summary>
        /// Loads the feed by using SyndicationFeed and converts it into xml
        /// If the website is down we catch it with a WebException
        /// After we caught it with a WebException: display a dialog box with a warning and load in the cached version of the website
        /// If the website does work but there is no data in the xml file we also catch it with an exception
        /// Initial update - Only updates after the P2000 is read
        /// </summary>
        private Feed() {
            try {
                _p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                USE_FEED_URL = FEED_URL;
            }
            catch (WebException) {
                Container.GetInstance()
                    .DisplayDialog(DialogType.DialogMessageType.WARNING, "Website is niet bereikbaar",
                        "Een gecachede versie van deze website wordt ingeladen");
                _p2000 = SyndicationFeed.Load(XmlReader.Create(CACHED_FEED_URL));
                USE_FEED_URL = CACHED_FEED_URL;
            }
            catch (XmlException) {
                Container.GetInstance()
                    .DisplayDialog(DialogType.DialogMessageType.WARNING, "Website bevat geen xml data",
                        "Een gecachede versie van deze website wordt ingeladen");
                _p2000 = SyndicationFeed.Load(XmlReader.Create(CACHED_FEED_URL));
                USE_FEED_URL = CACHED_FEED_URL;
            }
            _alerts = CreateAlertList(_p2000);
            UpdateFeed();
        }

        /// <summary>
        /// Method that creates an alert out of the RSS feed
        /// First we check if there are 2 attributes in the item, the lat and the long, we need those to accurately mark the location
        /// We assign local variables to the items out of the RSS feed
        /// Return filtered alert attributes
        /// If there is no lat and long in the item we return null
        /// </summary>
        /// <param name="item">Item in syndicationfeed</param>
        /// <returns>Filtered alert attributes</returns>
        private Alert CreateAlert(SyndicationItem item) {
            if (item.ElementExtensions.Count == 2) {
                string alertItemString = item.Title.Text.Replace("(Directe Inzet: ", "").ToUpper();
                string lat = item.ElementExtensions.Reverse().Skip(1).Take(1).First().GetObject<XElement>().Value;
                string lng = item.ElementExtensions.Last().GetObject<XElement>().Value;
                double parsedLat = double.Parse(lat, CultureInfo.InvariantCulture);
                double parsedLng = double.Parse(lng, CultureInfo.InvariantCulture);
                Alert newAlert = new Alert(item.Title.Text.Replace("~", " "), item.Summary.Text, item.PublishDate,
                    parsedLat, parsedLng);

                return AlertUtil.SetAlertAttributes(newAlert, alertItemString);
            }
            return null;
        }

        /// <summary>
        /// Creates an alertlist we put all created alerts into one list
        /// In the foreach we sort the items by date, then if the alert is not empty we add it to the list
        /// We reverse the list so we see the newest items on top
        /// </summary>
        /// <param name="items">Item in syndicationfeed</param>
        /// <returns>The ordered by date alert list</returns>
        public List<Alert> CreateAlertList(SyndicationFeed items) {
            List<Alert> tempAlerts = new List<Alert>();
            foreach (SyndicationItem item in items.Items.OrderBy(x => x.PublishDate)) {
                Alert newAlert = CreateAlert(item);
                if (newAlert != null) tempAlerts.Add(newAlert);
            }
            tempAlerts.Reverse();
            return tempAlerts;
        }

        /// <summary>
        /// Method to update and refresh the alerts
        /// We call the HomeModule to access some of it's functions 
        /// Check which filter is selected, 1 is for ambulance 2 is for firefighter and adds the selected filter
        /// </summary>
        public void UpdateAlerts() {
            HomeModule hM = (HomeModule) ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            int selectedFilter = hM.GetAlertType;
            if (selectedFilter == 1 || selectedFilter == 2) {
                _filteredAlerts = new List<Alert>();
                foreach (Alert a in _alerts)
                    if (a.Type == selectedFilter) _filteredAlerts.Add(a);
            }
            else _filteredAlerts = _alerts;
            hM.DisplayLoadIcon();
            hM.LoadComponents();
        }

        /// <summary>
        /// Function to refresh the feed if there are new items
        /// Loop through the new feed
        /// If the first item from the old feed is not identical to the first item of the new feed, add it to the list of new items
        /// Else, end the loop. 
        /// </summary>
        public void UpdateFeed() {
            List<Alert> oldAlerts = _alerts;
            _newAlerts = new List<Alert>();
            try {
                _p2000 = SyndicationFeed.Load(XmlReader.Create(USE_FEED_URL));
                _alerts = CreateAlertList(_p2000);

                foreach (Alert item in _alerts)
                    if (item.Title != oldAlerts[0].Title) _newAlerts.Add(item);
                    else break;

                if (_newAlerts.Count > 0 && Container.GetInstance().WindowState == FormWindowState.Minimized)
                    new PushMessage(_newAlerts);
                UpdateAlerts();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
    }
}