using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KBS_SE3.Models
{
    class Feed
    {
        private SyndicationFeed p2000;
        private string feedUrl = "http://feeds.livep2000.nl/";

        public Feed()
        {
            CreateFirstFeed();
            DisplayItems(p2000);
            UpdateFeed();
        }

        public SyndicationFeed P2000
        {
            get { return p2000; }
        }

        public void DisplayItems(SyndicationFeed items)
        {
            foreach (SyndicationItem item in items.Items.OrderBy(x => x.PublishDate))
            {
                // Print item
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
            DisplayItems(newFeed);
        }
    }
}
