using System.Windows.Forms;

namespace KBS_SE3 {
    partial class Dialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dialogHeader = new System.Windows.Forms.Panel();
            this.dialogHeaderText = new System.Windows.Forms.Label();
            this.dialogHeaderTitle = new System.Windows.Forms.Label();
            this.dialogCloseBtn = new System.Windows.Forms.Label();
            this.dialogHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogHeader
            // 
            this.dialogHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.dialogHeader.Controls.Add(this.dialogHeaderText);
            this.dialogHeader.Controls.Add(this.dialogHeaderTitle);
            this.dialogHeader.Controls.Add(this.dialogCloseBtn);
            this.dialogHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.dialogHeader.Location = new System.Drawing.Point(0, 0);
            this.dialogHeader.Name = "dialogHeader";
            this.dialogHeader.Size = new System.Drawing.Size(448, 32);
            this.dialogHeader.TabIndex = 0;
            this.dialogHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dialogHeader_MouseDown);
            // 
            // dialogHeaderText
            // 
            this.dialogHeaderText.AutoSize = true;
            this.dialogHeaderText.Dock = System.Windows.Forms.DockStyle.Left;
            this.dialogHeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogHeaderText.ForeColor = System.Drawing.Color.White;
            this.dialogHeaderText.Location = new System.Drawing.Point(5, 0);
            this.dialogHeaderText.Margin = new System.Windows.Forms.Padding(0);
            this.dialogHeaderText.Name = "dialogHeaderText";
            this.dialogHeaderText.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.dialogHeaderText.Size = new System.Drawing.Size(0, 24);
            this.dialogHeaderText.TabIndex = 1;
            this.dialogHeaderText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dialogHeader_MouseDown);
            // 
            // dialogHeaderTitle
            // 
            this.dialogHeaderTitle.AutoSize = true;
            this.dialogHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.dialogHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.dialogHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.dialogHeaderTitle.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dialogHeaderTitle.Name = "dialogHeaderTitle";
            this.dialogHeaderTitle.Padding = new System.Windows.Forms.Padding(5, 8, 0, 0);
            this.dialogHeaderTitle.Size = new System.Drawing.Size(5, 24);
            this.dialogHeaderTitle.TabIndex = 3;
            this.dialogHeaderTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dialogHeader_MouseDown);
            // 
            // dialogCloseBtn
            // 
            this.dialogCloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dialogCloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogCloseBtn.ForeColor = System.Drawing.Color.White;
            this.dialogCloseBtn.Location = new System.Drawing.Point(417, -3);
            this.dialogCloseBtn.Name = "dialogCloseBtn";
            this.dialogCloseBtn.Size = new System.Drawing.Size(31, 35);
            this.dialogCloseBtn.TabIndex = 0;
            this.dialogCloseBtn.Text = "x";
            this.dialogCloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dialogCloseBtn.Click += new System.EventHandler(this.dialogCloseBtn_Click);
            this.dialogCloseBtn.MouseEnter += new System.EventHandler(this.dialogCloseBtn_MouseEnter);
            this.dialogCloseBtn.MouseLeave += new System.EventHandler(this.dialogCloseBtn_MouseLeave);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 172);
            this.Controls.Add(this.dialogHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.dialogHeader.ResumeLayout(false);
            this.dialogHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dialogHeader;
        private System.Windows.Forms.Label dialogCloseBtn;
        private System.Windows.Forms.Label dialogHeaderText;
        private Label dialogHeaderTitle;
    }
}