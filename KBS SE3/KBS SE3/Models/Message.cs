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

    public class Message {
        NotifyIcon i;
        private string _title;
        private string _type;
        private string _message;
        private string _address;

        // Constructor for making a message + push message
        public Message(string title, string type, string message, string address) {
            this._title = title;
            this._type = type;
            this._message = message;
            this._address = address;
            this.i = new NotifyIcon();
            setPushMessage();

        }

        // Function for pushing message to user
        public void setPushMessage() {
            i.Icon = SystemIcons.Exclamation;
            i.Visible = true;
            i.Icon = new Icon("C:\\Users\\maarten\\Documents\\Visual Studio 2015\\Projects\\KBS-SE3\\KBS SE3\\KBS SE3\\Models\\app_icon.ico");
            //i.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);

            i.ShowBalloonTip(5000,
                _title,
                 _type + " " + _message + " op " + _address,
                ToolTipIcon.None);
        }

        // Function for opening form after double clicking pushMessage
        //private void notifyIcon1_DoubleClick(object Sender, EventArgs e) {
        //    // Show the form when the user double clicks on the notify icon.

        //    // Set the WindowState to normal if the form is minimized.
        //    if (this.WindowState == FormWindowState.Minimized)
        //        this.WindowState = FormWindowState.Normal;

        //    // Activate the form.
        //    this.Activate();
        //}





    }
}
