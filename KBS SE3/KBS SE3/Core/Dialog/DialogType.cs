using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Core.Dialog {
    public static class DialogType {
        public enum DialogMessageType { WARNING, ERROR, SUCCESS };

        /*
        * Returns an icon based on the given message type
        * Each image extension is png and each image name starts with 'dialog_icon_' + the name of the enum value.
        * For example: 'dialog_icon_warning.png' represents the warning icon.
        */
        public static Bitmap GetDialogIcon(DialogMessageType type) {
            string fileName = Enum.GetName(typeof(DialogMessageType), type);
            string path = @"../../Resources/dialog_icon_" + fileName.ToLower() + ".png";
            return new Bitmap(path);
        }

        //Returns a proper display message based on the given message type.
        public static String ParseHeaderMessage(DialogMessageType type) {
            switch (type) {
                case DialogMessageType.WARNING: return "Waarschuwing";
                case DialogMessageType.ERROR:   return "Foutmelding";
                case DialogMessageType.SUCCESS: return "Melding";
                default: return null;     
            }
        }
    }
}
