using System;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Properties;

namespace KBS_SE3.Modules {
    partial class SettingsModule : UserControl, IModule {
        public SettingsModule() {
            InitializeComponent();
            locationTextBox.Text = Settings.Default.userLocation;
            feedTickerCheckBox.Checked = Settings.Default.feedTickerEnabled;
            feedTickerNumeric.Enabled = feedTickerCheckBox.Checked;
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Settings");
        }

        //If the user changed the value of the textbox the Setting is changed
        private void saveBtn_Click(object sender, EventArgs e) {
            var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            if (locationTextBox.Text != "") {
                Settings.Default.userLocation = locationTextBox.Text;
                var feedTickerNumericValue = Convert.ToInt32(feedTickerNumeric.Value);
                var feedTickerEnabled = feedTickerCheckBox.Checked;
                // Check if the timer tick value is changed and update to settings
                if (feedTickerNumericValue != Settings.Default.feedTickerTime) {
                    Settings.Default.feedTickerTime = feedTickerNumericValue;
                    // Apply changes
                    hm.FeedTicker.ChangeTickTime(feedTickerNumericValue);
                }
                // Check if the checkbox value is changed and update to settings
                if (feedTickerEnabled != Settings.Default.feedTickerEnabled) {
                    Settings.Default.feedTickerEnabled = feedTickerEnabled;
                    // Apply changes
                    hm.FeedTicker.TimerStateChanged(feedTickerEnabled);
                }
                this.saveBtn.Enabled = false;
                Settings.Default.Save();
            } else {
                warningLabel.Show();
            }
        }

        private void feedTickerCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.feedTickerNumeric.Enabled = this.feedTickerCheckBox.Checked;
            this.saveBtn.Enabled = true;
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e) {
            if (locationTextBox.Text != Settings.Default.userLocation) this.saveBtn.Enabled = true;
        }

        private void feedTickerNumeric_ValueChanged(object sender, EventArgs e) {
            saveBtn.Enabled = true;
        }

        private void feedTickerNumeric_TextChanged(object sender, EventArgs e) {
            // Try to parse the text from feedTickerNumeric and check if the value is in range, enable the save button if true
            int n;
            if (Int32.TryParse(feedTickerNumeric.Text, out n)) {
                int value = Int32.Parse(feedTickerNumeric.Text);
                if (value < 30 || value > 300) {
                    feedNumericErrorLabel.Visible = true;
                    saveBtn.Enabled = false;
                } else {
                    feedNumericErrorLabel.Visible = false;
                    saveBtn.Enabled = true;
                    feedTickerNumeric.Value = value;
                }
            } else feedNumericErrorLabel.Visible = true;
        }
    }
}
