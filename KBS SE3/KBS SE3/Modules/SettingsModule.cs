using System;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Models;
using Casualty_Radar.Properties;

namespace Casualty_Radar.Modules {
    /// <summary>
    ///  Module that contains the settings, such as options for the ticker and location
    /// </summary>
    partial class SettingsModule : UserControl, IModule {
        public SettingsModule() {
            InitializeComponent();
            locationTextBox.Text = Settings.Default.userLocation;
            feedTickerCheckBox.Checked = Settings.Default.feedTickerEnabled;
            feedTickerNumeric.Enabled = feedTickerCheckBox.Checked;
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Settings", ModuleManager.GetInstance().ParseInstance(typeof(TestModule)), null);
        }

        //If the user changed the value of the textbox the setting is changed
        private void saveBtn_Click(object sender, EventArgs e) {
            HomeModule hm = (HomeModule) ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            if (locationTextBox.Text != "") {
                Settings.Default.userLocation = locationTextBox.Text;
                int feedTickerNumericValue = Convert.ToInt32(feedTickerNumeric.Value);
                bool feedTickerEnabled = feedTickerCheckBox.Checked;
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
                saveBtn.Enabled = false;
                Settings.Default.Save();
            }
            else {
                warningLabel.Show();
            }
        }

        private void feedTickerCheckBox_CheckedChanged(object sender, EventArgs e) {
            feedTickerNumeric.Enabled = feedTickerCheckBox.Checked;
            saveBtn.Enabled = true;
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e) {
            if (locationTextBox.Text != Settings.Default.userLocation) saveBtn.Enabled = true;
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
                }
                else {
                    feedNumericErrorLabel.Visible = false;
                    saveBtn.Enabled = true;
                    feedTickerNumeric.Value = value;
                }
            }
            else feedNumericErrorLabel.Visible = true;
        }

        private void testModuleButton_Click(object sender, EventArgs e) {
            ModuleManager mM = ModuleManager.GetInstance();
            mM.UpdateModule(mM.ParseInstance(typeof(TestModule)));
        }
    }
}