using KBS_SE3.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS_SE3.Models {

    public enum hulpdiensten {
        Police, Ambulance, FireDepartment
    }

    public class PushMessage {
        NotifyIcon _icon;
        private string _title;
        private string _type;
        private string _message;
        private string _address;

        // Constructor for making a message + push message
        public PushMessage(string title, string type, string message, string address) {
            this._title = title;
            this._type = type;
            this._message = message;
            this._address = address;
            this._icon = new NotifyIcon();
            setPushMessage();

        }

        // Function for pushing message to user
        private void setPushMessage() {
            _icon.Icon = SystemIcons.Exclamation;
            _icon.Visible = true;
            _icon.Icon = new Icon(FileUtil.GetResourcesPath() + "app_icon.ico");
            _icon.DoubleClick += new System.EventHandler(this.icon_DoubleClick);

            _icon.ShowBalloonTip(5000,
                _title,
                 _type + " " + _message + " op " + _address,
                ToolTipIcon.None);
        }

        // Function for opening form after double clicking pushMessage
        private void icon_DoubleClick(object Sender, EventArgs e) {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (Container.GetInstance().WindowState == FormWindowState.Minimized)
                Container.GetInstance().WindowState = FormWindowState.Normal;

            // Activate the form.
            Container.GetInstance().Activate();
        }
    }
}
