using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Casualty_Radar.Models {
    /// <summary>
    /// Class which instantiates a PushMessage for when the user has the application in the background and new alerts come in.
    /// </summary>
    class PushMessage {
        private NotifyIcon _icon;

        public PushMessage(List<Alert> alerts) {
            _icon = new NotifyIcon();
            SetPushMessage(alerts);
        }

        /// <summary>
        /// Function that creates a balloontip notification containing the amount of new alerts
        /// </summary>
        /// <param name="alerts"></param>
        private void SetPushMessage(List<Alert> alerts) {
            string message;
            if (alerts.Count == 1) message = alerts[0].ToString();
            else message = "Er zijn " + alerts.Count + " nieuwe meldingen";
            _icon.Icon = SystemIcons.Exclamation;
            _icon.Visible = true;
            _icon.Icon = new Icon(@"..\..\Resources\app_icon.ico");
            _icon.BalloonTipClosed += BalloonTipClosed;
            _icon.BalloonTipClicked += notifyIcon_BalloonTipClicked;
            _icon.ShowBalloonTip(5000,
                message,
                "Klik hier om de meldingen te bekijken",
                ToolTipIcon.None);
        }

        private void BalloonTipClosed(object sender, EventArgs e) {
            _icon.Dispose();
        }

        /// <summary>
        /// Event which brings the application to the front when the user clicks the balloontip
        /// </summary>
        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e) {
            // Show the form when the user double clicks on the notify icon.
            // Set the WindowState to normal if the form is minimized.
            if (Container.GetInstance().WindowState == FormWindowState.Minimized)
                Container.GetInstance().WindowState = FormWindowState.Normal;

            // Activate the form.
            Container.GetInstance().Activate();
            _icon.Dispose();
        }
    }
}