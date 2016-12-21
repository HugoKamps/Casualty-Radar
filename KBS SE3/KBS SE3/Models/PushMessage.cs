using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KBS_SE3.Models {

     class PushMessage {
        private NotifyIcon _icon;

        // Constructor for making a message + push message
        public PushMessage(List<Alert> alerts) {
            _icon = new NotifyIcon();
            SetPushMessage(alerts);
        }

        // Function for pushing message to user
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

        // Function for opening form after double clicking pushMessage
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
