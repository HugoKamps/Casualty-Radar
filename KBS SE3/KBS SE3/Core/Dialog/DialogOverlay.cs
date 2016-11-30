using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KBS_SE3.Core.Dialog {
    class DialogOverlay : IDisposable {

        private List<Form> _forms;

        /*
        * Creates a form with a black background above all forms except the 
        * form called after the overlay.
        */
        public DialogOverlay() {
            _forms = new List<Form>();
            var cnt = Application.OpenForms.Count;
            for (int ix = 0; ix < cnt; ++ix) {
                var form = Application.OpenForms[ix];
                var overlay = new Form {
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

        public void Dispose() {
            foreach (var form in _forms) form.Close();
        }
    }
}
