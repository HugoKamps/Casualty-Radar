using KBS_SE3.Core;
using KBS_SE3.Modules;
using System;
using System.Collections.Generic;
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
    class Feed
    {
        private SyndicationFeed p2000;
        private string feedUrl = "http://feeds.livep2000.nl/";
        public List<Alert> Alerts = new List<Alert>();

        public Feed()
        {
            CreateFirstFeed();
            Alerts = CreateAlertList(p2000);
            DisplayItems(Alerts);
            UpdateFeed();
        }

        public SyndicationFeed P2000
        {
            get { return p2000; }
        }

        public List<Alert> CreateAlertList(SyndicationFeed items)
        {
            List<Alert> tempAlerts = new List<Alert>();
            string lat;
            string lng;

            foreach (SyndicationItem item in items.Items.OrderBy(x => x.PublishDate))
            {
                if (item.ElementExtensions.Count == 2)
                {
                    lat = item.ElementExtensions.Reverse().Skip(1).Take(1).First().GetObject<XElement>().Value;
                    lng = item.ElementExtensions.Last().GetObject<XElement>().Value;
                    tempAlerts.Add(new Alert(item.Title.Text, item.Summary.Text, item.PublishDate, double.Parse(lat, CultureInfo.InvariantCulture), double.Parse(lng, CultureInfo.InvariantCulture)));
                }
            }

            return tempAlerts;
        }

        public void DisplayItems(List<Alert> alerts)
        {
            HomeModule module = (HomeModule)ModuleManager.GetInstance().GetCurrentModule();
            foreach (Alert alert in alerts)
            {
                // Display item
                module.listBox1.Items.Add(alert.Title);
            }
        }

        public void CreateFirstFeed()
        {
            p2000 = SyndicationFeed.Load(XmlReader.Create(feedUrl));
        }

        public void UpdateFeed()
        {
            SyndicationFeed oldP2000 = p2000;
            List<SyndicationItem> newItems = new List<SyndicationItem>();
            SyndicationFeed newFeed = new SyndicationFeed();

            // Load the feed
            p2000 = SyndicationFeed.Load(XmlReader.Create(feedUrl));
            Alerts = CreateAlertList(p2000);

            // Get the first item from the previous feed
            SyndicationItem first = oldP2000.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault(); ;

            // Loop through the new feed
            foreach (SyndicationItem item in p2000.Items)
            {
                // If the first item from the old feed is identical to the first item of the new feed
                if (item.Title.Text != first.Title.Text)
                {
                    // The item is a new item
                    newItems.Add(item);
                }
                else
                {
                    // The item is not a new item, end of loop
                    break;
                }
            }

            newFeed.Items = newItems;
            List<Alert> newAlerts = CreateAlertList(newFeed);
            DisplayItems(newAlerts);
        }
    }
}
