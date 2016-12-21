using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Casualty_Radar.Core.Dialog {
    class DialogOverlay : IDisposable {

        private List<Form> _forms;

        /// <summary>
        /// Creates a form with a black background above all forms except the 
        /// form called after the overlay.
        /// </summary>
        public DialogOverlay() {
            _forms = new List<Form>();
            int cnt = Application.OpenForms.Count;
            for (int ix = 0; ix < cnt; ++ix) {
                Form form = Application.OpenForms[ix];
                Form overlay = new Form {
                    Location = form.Location,
                    Size = form.Size,
                    FormBorderStyle = FormBorderStyle.None,
                    ShowInTaskbar = false,
                    StartPosition = FormStartPosition.Manual,
                    AutoScaleMode = AutoScaleMode.None
                };
                overlay.Opacity = 0.4;
                overlay.BackColor = Color.Black;
                overlay.Show(form);
                _forms.Add(overlay);
            }
        }

        /// <summary>
        /// Disposes all of the dialog overlays
        /// </summary>
        public void Dispose() {
            foreach (Form form in _forms) form.Close();
        }
    }
}
