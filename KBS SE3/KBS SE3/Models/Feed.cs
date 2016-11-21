﻿using KBS_SE3.Core;
using KBS_SE3.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace KBS_SE3.Models
{
    class Feed {

        private static Feed _instance;
        private SyndicationFeed _p2000;
        private readonly string FEED_URL = "http://feeds.livep2000.nl/";
        private List<Alert> _alerts;

        public static Feed GetInstance() {
            if (_instance == null)  _instance = new Feed();
            return _instance;
        }

        private Feed() {
            if (MainMethods.CheckForInternetConnection()) {
                this._p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                this._alerts = CreateAlertList(_p2000);
                /* Initial update - Only updates after the P2000 is read.*/
                UpdateFeed();
            }
        }

        //Returns the list with alerts
        public List<Alert> GetAlerts() {
            return _alerts;
        }

        public List<Alert> CreateAlertList(SyndicationFeed items) {
            List<Alert> tempAlerts = new List<Alert>();
            string lat, lng;

            foreach (SyndicationItem item in items.Items.OrderBy(x => x.PublishDate)) {
                if (item.ElementExtensions.Count == 2) {
                    lat = item.ElementExtensions.Reverse().Skip(1).Take(1).First().GetObject<XElement>().Value;
                    lng = item.ElementExtensions.Last().GetObject<XElement>().Value;
                    tempAlerts.Add(new Alert(item.Title.Text, item.Summary.Text, item.PublishDate, double.Parse(lat, CultureInfo.InvariantCulture), double.Parse(lng, CultureInfo.InvariantCulture)));
                }
            }
            return tempAlerts;
        }

        public void UpdateFeed() {
            SyndicationFeed oldP2000 = _p2000;
            List<SyndicationItem> newItems = new List<SyndicationItem>();
            SyndicationFeed newFeed = new SyndicationFeed();

            // Load the feed
            this._p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
            this._alerts = CreateAlertList(_p2000);
            
            // Get the first item from the previous feed
            SyndicationItem first = oldP2000.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault(); ;
            
            // Loop through the new feed
            foreach (SyndicationItem item in _p2000.Items) {
                // If the first item from the old feed is identical to the first item of the new feed
                if (item.Title.Text != first.Title.Text) {
                    // The item is a new item
                    newItems.Add(item);
                } else {
                    // The item is not a new item, end of loop
                    break;
                }
            }
            
            newFeed.Items = newItems;
            List<Alert> newAlerts = CreateAlertList(newFeed);
            
            // Send list with new alerts to PushMessage
            new PushMessage(newAlerts);
            UpdateAlerts();
        }

        /*
        * Update the displayed alerts with the new feed
        */
        public void UpdateAlerts() {
            HomeModule hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            ListBox box = hm.feedListBox;
            box.DataSource = null;
            box.DataSource = new BindingList<Alert>(_alerts);
            box.DisplayMember = "Title"; 
        }
    }
}
