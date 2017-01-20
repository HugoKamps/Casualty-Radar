using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace XMLRewriter.Core {

    [DesignerCategory("Code")]
    class SectionPanel : Panel {

        public Label HeaderLabel { get; private set; }
        public SectionPanel() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            HeaderLabel = new Label();
            HeaderLabel.AutoSize = true;
            HeaderLabel.ForeColor = Color.Blue;
            HeaderLabel.Location = new Point(Location.X+30, Location.Y);
            Controls.Add(HeaderLabel);
        }

        protected override void OnPaint(PaintEventArgs e) {
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(194, 194, 194)), 7, 7, ClientSize.Width - 8, ClientSize.Height - 8);
        }

        /// <summary>
        /// Sets the header text from the panel
        /// </summary>
        /// <param name="text">The text that is displayed</param>
        public void SetHeaderText(String text) {
            HeaderLabel.Text = text;
        }
    
    }
}
