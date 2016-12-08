using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KBS_SE3.Models {

     class PushMessage {
        private NotifyIcon _icon;
        private List<Alert> _alert;

        // Constructor for making a message + push message
        public PushMessage(List<Alert> alert) {
            _icon = new NotifyIcon();
            _alert = alert;
           setPushMessage(_alert);
        }

        // Function for pushing message to user
        private void setPushMessage(List<Alert> alert) {
            string message = "";
            if(alert.Count == 1) {
                message = alert[0].ToString();
            }else {
                message = "Er zijn " + alert.Count + " nieuwe meldingen";
            }
            if (_alert.Count != 0 && Container.GetInstance().WindowState == FormWindowState.Minimized) {
                _icon.Icon = SystemIcons.Exclamation;
                _icon.Visible = true;
                _icon.Icon = new Icon(@"..\..\Resources\app_icon.ico");
                _icon.BalloonTipClosed += new EventHandler(BalloonTipClosed);
                _icon.BalloonTipClicked += new EventHandler(notifyIcon_BalloonTipClicked);
                _icon.ShowBalloonTip(5000,
                    message,
                     "Klik hier om de meldingen te bekijken",
                    ToolTipIcon.None);
            }
        }

        private void BalloonTipClosed(object Sender, EventArgs e) {
            _icon.Dispose();
        }

        // Function for opening form after double clicking pushMessage
        private void notifyIcon_BalloonTipClicked(object Sender, EventArgs e) {
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
