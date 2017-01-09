using System;
using System.Drawing;

namespace Casualty_Radar.Core.Dialog {
    public static class DialogType {

        /// <summary>
        /// A DialogMessageType is a simple key that is used to define each dialog.
        /// This can differ in positive keys, like success, and negative keys like an error or a warning.
        /// </summary>
        public enum DialogMessageType { WARNING, ERROR, SUCCESS };

        /// <summary>
        /// Returns an icon based on the given message type
        /// Each image extension is png and each image name starts with 'dialog_icon_' + the name of the enum value.
        /// For example: 'dialog_icon_warning.png' represents the warning icon.
        /// </summary>
        /// <param name="type">The type of the dialog</param>
        /// <returns>A bitmap representing the icon from the dialog</returns>
        public static Bitmap GetDialogIcon(DialogMessageType type) {
            string fileName = Enum.GetName(typeof(DialogMessageType), type);
            string path = @"../../Resources/dialog_icon_" + fileName.ToLower() + ".png";
            return new Bitmap(path);
        }


        /// <summary>
        /// Returns a proper display message based on the given message type.
        /// </summary>
        /// <param name="type">The type of the dialog</param>
        /// <returns>The header message of the dialog</returns>
        public static string ParseHeaderMessage(DialogMessageType type) {
            switch (type) {
                case DialogMessageType.WARNING: return "Waarschuwing";
                case DialogMessageType.ERROR:   return "Foutmelding";
                case DialogMessageType.SUCCESS: return "Melding";
                default: return null;     
            }
        }
    }
}
