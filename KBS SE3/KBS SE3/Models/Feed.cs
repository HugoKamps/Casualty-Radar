using KBS_SE3.Core;
using KBS_SE3.Modules;
using KBS_SE3.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        private List<Alert> _filteredAlerts;

        public static Feed GetInstance() {
            if (_instance == null) _instance = new Feed();
            return _instance;
        }

        private Feed() {
            try
            {
                this._p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                this._alerts = CreateAlertList(_p2000);
                /* Initial update - Only updates after the P2000 is read.*/
                UpdateFeed();
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public List<Alert> GetAlerts() {
            return _filteredAlerts;
        }

        public List<Alert> CreateAlertList(SyndicationFeed items)
        {
            List<Alert> tempAlerts = new List<Alert>();
            foreach (SyndicationItem item in items.Items.OrderBy(x => x.PublishDate))
            {
                Alert newAlert = _createAlert(item);

                if (newAlert != null)
                    tempAlerts.Add(newAlert);
            }
            tempAlerts.Reverse();
            return tempAlerts;
        }

        private Alert _createAlert(SyndicationItem item)
        {
            // Check if the item has 2 attributes which are Lat & Long
            if (item.ElementExtensions.Count == 2)
            {
                string lat = item.ElementExtensions.Reverse().Skip(1).Take(1).First().GetObject<XElement>().Value;
                string lng = item.ElementExtensions.Last().GetObject<XElement>().Value;
                Alert newAlert = new Alert(item.Title.Text, item.Summary.Text, item.PublishDate, double.Parse(lat, CultureInfo.InvariantCulture), double.Parse(lng, CultureInfo.InvariantCulture));
                // Use the AlertUtil for setting attributes
                for (int i = 0; i < AlertUtil.P2000.GetLength(0); i++)
                {
                    if ((((item.Title.Text).Replace("(Directe Inzet: ", "")).ToUpper()).StartsWith(AlertUtil.P2000[i, 0]))
                    {
                        newAlert.Code = AlertUtil.P2000[i, 0];
                        newAlert.Type = Int32.Parse(AlertUtil.P2000[i, 1]);
                        newAlert.TypeString = AlertUtil.P2000[i, 2];
                        newAlert.Info = AlertUtil.P2000[i, 3];
                        return newAlert;
                    }
                }
            }
            return null;
        } 

        public void UpdateFeed() {
            SyndicationFeed oldP2000 = _p2000;
            List<SyndicationItem> newItems = new List<SyndicationItem>();
            SyndicationFeed newFeed = new SyndicationFeed();

            // Load the feed
            try
            {
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
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /*
        * Update the displayed alerts with the new feed
        */
        public void UpdateAlerts() {
            HomeModule hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            int selectedFilter = hm.alertTypeComboBox.SelectedIndex;
            int y = 0;
            // Check which filter is selected and apply the filter
            if (selectedFilter == 1 || selectedFilter == 2) {
                _filteredAlerts = new List<Alert>();
                foreach (Alert a in _alerts) {
                    if (a.Type == selectedFilter) {
                        _filteredAlerts.Add(a);
                    }
                }
            }
            else {
                _filteredAlerts = _alerts;
            }

            hm.feedPanel.Controls.Clear();
            foreach (Alert a in _filteredAlerts) {
                createAlertPanel(a.Type, a.Title, a.Info, a.PubDate.TimeOfDay.ToString(), y, hm);
                y += 105;
            }

            hm.alertsCountLabel.Text = "(" + _filteredAlerts.Count.ToString() + ")";
        }

        public void createAlertPanel(int type, string title, string info, string time, int y, HomeModule hm) {
            Panel newPanel = new Panel();
            newPanel.Location = new System.Drawing.Point(8, y);
            newPanel.Size = new System.Drawing.Size(305, 100);
            newPanel.BackColor = Color.FromArgb(236, 89, 71);

            PictureBox newPictureBox = new PictureBox();
            newPictureBox.Location = new System.Drawing.Point(220, 10);
            newPictureBox.Size = new System.Drawing.Size(60, 60);
            newPictureBox.Image = type == 1 ? Properties.Resources.Medic : Properties.Resources.Firefighter;
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.MouseEnter += feedPanelItem_MouseEnter;
            newPictureBox.MouseLeave += feedPanelItem_MouseLeave;

            Label label = new Label();
            label.ForeColor = Color.White;
            label.Location = new System.Drawing.Point(10, 5);
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label.Size = new System.Drawing.Size(200, 90);
            label.BackColor = Color.Transparent;
            label.Text = title + "\n" + info;
            label.MouseEnter += feedPanelItem_MouseEnter;
            label.MouseLeave += feedPanelItem_MouseLeave;
            label.TextAlign = ContentAlignment.MiddleCenter;

            Label timeLabel = new Label();
            timeLabel.ForeColor = Color.White;
            timeLabel.Location = new System.Drawing.Point(150, 65);
            timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            timeLabel.Size = new System.Drawing.Size(200, 30);
            timeLabel.BackColor = Color.Transparent;
            timeLabel.Text = time;
            timeLabel.MouseEnter += feedPanelItem_MouseEnter;
            timeLabel.MouseLeave += feedPanelItem_MouseLeave;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;

            newPanel.MouseEnter += feedPanelItem_MouseEnter;
            newPanel.MouseLeave += feedPanelItem_MouseLeave;

            hm.feedPanel.AutoScroll = true;
            newPanel.Controls.Add(newPictureBox);
            newPanel.Controls.Add(label);
            newPanel.Controls.Add(timeLabel);
            hm.feedPanel.Controls.Add(newPanel);
        }

        void feedPanelItem_MouseEnter(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                Panel panel = (Panel)sender;
                panel.BackColor = Color.FromArgb(210, 73, 57);
            }
            else {
                Control control = (Control)sender;
                control.Parent.BackColor = Color.FromArgb(210, 73, 57);
            }
        }

        void feedPanelItem_MouseLeave(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                Panel panel = (Panel)sender;
                panel.BackColor = Color.FromArgb(236, 86, 71);
            }
            else {
                Control control = (Control)sender;
                control.Parent.BackColor = Color.FromArgb(236, 86, 71);
            }
        }
    }
}
