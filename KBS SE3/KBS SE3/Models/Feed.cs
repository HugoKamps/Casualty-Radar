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
        private Panel _selectedPanel;
        public bool TriggerEvent { get; set; }

        public static Feed GetInstance() {
            if (_instance == null) _instance = new Feed();
            return _instance;
        }

        private Feed() {
            TriggerEvent = true;
            if (ConnectionUtil.HasInternetConnection()) {
                _p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
                _alerts = CreateAlertList(_p2000);
                /* Initial update - Only updates after the P2000 is read.*/
                UpdateFeed();
            }
        }

        public List<Alert> GetAlerts() {
            return _filteredAlerts;
        }

        public List<Alert> CreateAlertList(SyndicationFeed items) {
            var tempAlerts = new List<Alert>();
            string lat, lng;

            foreach (var item in items.Items.OrderBy(x => x.PublishDate)) {
                if (item.ElementExtensions.Count == 2) {
                    lat = item.ElementExtensions.Reverse().Skip(1).Take(1).First().GetObject<XElement>().Value;
                    lng = item.ElementExtensions.Last().GetObject<XElement>().Value;
                    var newAlert = new Alert(item.Title.Text, item.Summary.Text, item.PublishDate, double.Parse(lat, CultureInfo.InvariantCulture), double.Parse(lng, CultureInfo.InvariantCulture));
                    for (var i = 0; i < AlertUtil.P2000.GetLength(0); i++) {
                        if ((((item.Title.Text).Replace("(Directe Inzet: ", "")).ToUpper()).StartsWith(AlertUtil.P2000[i, 0])) {
                            newAlert.Code = AlertUtil.P2000[i, 0];
                            newAlert.Type = Int32.Parse(AlertUtil.P2000[i, 1]);
                            newAlert.TypeString = AlertUtil.P2000[i, 2];
                            newAlert.Info = AlertUtil.P2000[i, 3];
                            tempAlerts.Add(newAlert);
                            break;
                        }
                    }
                }
            }
            return tempAlerts;
        }

        public void UpdateFeed() {
            var oldP2000 = _p2000;
            var newItems = new List<SyndicationItem>();
            var newFeed = new SyndicationFeed();

            // Load the feed
            _p2000 = SyndicationFeed.Load(XmlReader.Create(FEED_URL));
            _alerts = CreateAlertList(_p2000);

            // Get the first item from the previous feed
            var first = oldP2000.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault(); ;

            // Loop through the new feed
            foreach (var item in _p2000.Items) {
                // If the first item from the old feed is identical to the first item of the new feed
                if (item.Title.Text != first.Title.Text) {
                    // The item is a new item
                    newItems.Add(item);
                }
                else {
                    // The item is not a new item, end of loop
                    break;
                }
            }

            newFeed.Items = newItems;
            var newAlerts = CreateAlertList(newFeed);

            // Send list with new alerts to PushMessage
            new PushMessage(newAlerts);
            UpdateAlerts();
        }

        /*
        * Update the displayed alerts with the new feed
        */
        public void UpdateAlerts() {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            var selectedFilter = hm.alertTypeComboBox.SelectedIndex;
            var y = 0;
            // Check which filter is selected and apply the filter
            if (selectedFilter == 1 || selectedFilter == 2) {
                _filteredAlerts = new List<Alert>();
                foreach (var a in _alerts) {
                    if (a.Type == selectedFilter) {
                        _filteredAlerts.Add(a);
                    }
                }
            }
            else {
                _filteredAlerts = _alerts;
            }

            hm.feedPanel.Controls.Clear();
            foreach (var a in _filteredAlerts) {
                CreateAlertPanel(a.Type, a.Title, a.Info, a.PubDate.TimeOfDay.ToString(), y, hm);
                y += 105;
            }

        }

        public Panel GetSelectedPanel => _selectedPanel;

        public void CreateAlertPanel(int type, string title, string info, string time, int y, HomeModule hm) {
            //The panel which will be filled with all of the controls below
            var newPanel = new Panel {
                Location = new Point(8, y),
                Size = new Size(305, 100),
                BackColor = Color.FromArgb(236, 89, 71)
            };

            //The picture which indicates the type of alert (Firefighter or ambulance)
            var newPictureBox = new PictureBox {
                Location = new Point(220, 10),
                Size = new Size(60, 60),
                Image = type == 1 ? Properties.Resources.Medic : Properties.Resources.Firefighter,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            //The label which will be filled with the information about the alert
            var label = new Label {
                ForeColor = Color.White,
                Location = new Point(10, 5),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 90),
                BackColor = Color.Transparent,
                Text = title + "\n" + info
            };

            if (_selectedPanel != null)
            {
                foreach (var control in _selectedPanel.Controls)
                {
                    if (control is Label)
                    {
                        var selectedLabel = (Label) control;
                        if (selectedLabel.Text == label.Text)
                        {
                            newPanel.BackColor = Color.FromArgb(210,93,0);
                            _selectedPanel = newPanel;
                        }
                    }
                }
            }

            //The label which will be filled with the time of the alert
            var timeLabel = new Label
            {
                ForeColor = Color.White,
                Location = new Point(150, 65),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 30),
                BackColor = Color.Transparent,
                Text = time
            };

            //Events for each control in the panel;
            newPictureBox.MouseEnter += feedPanelItem_MouseEnter;
            newPictureBox.MouseLeave += feedPanelItem_MouseLeave;
            newPictureBox.Click += feedPanelItem_Click;

            label.MouseEnter += feedPanelItem_MouseEnter;
            label.MouseLeave += feedPanelItem_MouseLeave;
            label.Click += feedPanelItem_Click;
            label.TextAlign = ContentAlignment.MiddleCenter;

            timeLabel.MouseEnter += feedPanelItem_MouseEnter;
            timeLabel.MouseLeave += feedPanelItem_MouseLeave;
            timeLabel.Click += feedPanelItem_Click;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;

            newPanel.MouseEnter += feedPanelItem_MouseEnter;
            newPanel.MouseLeave += feedPanelItem_MouseLeave;
            newPanel.Click += feedPanelItem_Click;
            newPanel.Cursor = Cursors.Hand;

            //The panel is filled with all the controls initialized above
            hm.feedPanel.AutoScroll = true;
            newPanel.Controls.Add(newPictureBox);
            newPanel.Controls.Add(label);
            newPanel.Controls.Add(timeLabel);
            hm.feedPanel.Controls.Add(newPanel);
        }

        private void feedPanelItem_Click(object sender, EventArgs e) {
            if (!TriggerEvent) return;
            var homeModule = (HomeModule) ModuleManager.GetInstance().ParseInstance(typeof (HomeModule));

            if (sender.GetType() == typeof (Panel)) {
                var panel = (Panel) sender;
                if (_selectedPanel != null) _selectedPanel.BackColor = Color.FromArgb(236, 86, 71);
                if (_selectedPanel == panel) {
                    _selectedPanel = null;
                    homeModule.navigationBtn.Enabled = false;
                    homeModule.navigationBtn.BackColor = Color.Gray;
                }
                else {
                    _selectedPanel = panel;
                    _selectedPanel.BackColor = Color.FromArgb(210, 93, 0);
                    homeModule.navigationBtn.Enabled = true;
                }
            }
            else {
                var control = (Control) sender;
                if (_selectedPanel != null) _selectedPanel.BackColor = Color.FromArgb(236, 86, 71);
                if (_selectedPanel == control.Parent) {
                    _selectedPanel = null;
                    homeModule.navigationBtn.Enabled = false;
                }
                else {
                    _selectedPanel = (Panel) control.Parent;
                    _selectedPanel.BackColor = Color.FromArgb(210, 93, 0);
                    homeModule.navigationBtn.Enabled = true;
                }
            }
        }

        private void feedPanelItem_MouseEnter(object sender, EventArgs e) {
            if (!TriggerEvent) return;
            if (sender.GetType() == typeof(Panel)) {
                var panel = (Panel)sender;
                if(panel != _selectedPanel) panel.BackColor = Color.FromArgb(210, 73, 57);
            }
            else {
                var control = (Control)sender;
                if (control.Parent != _selectedPanel) control.Parent.BackColor = Color.FromArgb(210, 73, 57);
            }
        }

        private void feedPanelItem_MouseLeave(object sender, EventArgs e) {
            if (!TriggerEvent) return;
            if (sender.GetType() == typeof(Panel)) {
                var panel = (Panel)sender;
                if (panel != _selectedPanel) panel.BackColor = Color.FromArgb(236, 86, 71);
            }
            else {
                var control = (Control)sender;
                if (control.Parent != _selectedPanel) control.Parent.BackColor = Color.FromArgb(236, 86, 71);
            }
        }
    }
}
