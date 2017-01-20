using System.ComponentModel;
using System.Windows.Forms;

namespace Casualty_Radar {
    partial class Dialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
            this.dialogHeader = new System.Windows.Forms.Panel();
            this.dialogHeaderText = new System.Windows.Forms.Label();
            this.dialogHeaderTitle = new System.Windows.Forms.Label();
            this.dialogCloseBtn = new System.Windows.Forms.Label();
            this.dialogIconPicturebox = new System.Windows.Forms.PictureBox();
            this.dialogContentLabel = new System.Windows.Forms.Label();
            this.dialogContentPanel = new System.Windows.Forms.Panel();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.dialogHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogIconPicturebox)).BeginInit();
            this.dialogContentPanel.SuspendLayout();
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
            this.dialogHeaderText.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
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
            // dialogIconPicturebox
            // 
            this.dialogIconPicturebox.Location = new System.Drawing.Point(8, 72);
            this.dialogIconPicturebox.Name = "dialogIconPicturebox";
            this.dialogIconPicturebox.Size = new System.Drawing.Size(51, 52);
            this.dialogIconPicturebox.TabIndex = 1;
            this.dialogIconPicturebox.TabStop = false;
            // 
            // dialogContentLabel
            // 
            this.dialogContentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogContentLabel.Location = new System.Drawing.Point(0, 0);
            this.dialogContentLabel.Name = "dialogContentLabel";
            this.dialogContentLabel.Padding = new System.Windows.Forms.Padding(5);
            this.dialogContentLabel.Size = new System.Drawing.Size(355, 121);
            this.dialogContentLabel.TabIndex = 2;
            this.dialogContentLabel.Text = "Placeholder";
            this.dialogContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialogContentPanel
            // 
            this.dialogContentPanel.Controls.Add(this.dialogContentLabel);
            this.dialogContentPanel.Location = new System.Drawing.Point(56, 32);
            this.dialogContentPanel.Name = "dialogContentPanel";
            this.dialogContentPanel.Size = new System.Drawing.Size(355, 121);
            this.dialogContentPanel.TabIndex = 3;
            // 
            // confirmBtn
            // 
            this.confirmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.confirmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.ForeColor = System.Drawing.Color.White;
            this.confirmBtn.Location = new System.Drawing.Point(348, 136);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(89, 26);
            this.confirmBtn.TabIndex = 3;
            this.confirmBtn.Text = "Ok";
            this.confirmBtn.UseVisualStyleBackColor = false;
            this.confirmBtn.Click += new System.EventHandler(this.dialogCloseBtn_Click);
            this.confirmBtn.MouseEnter += new System.EventHandler(this.dialogCloseBtn_MouseEnter);
            this.confirmBtn.MouseLeave += new System.EventHandler(this.dialogCloseBtn_MouseLeave);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 172);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.dialogContentPanel);
            this.Controls.Add(this.dialogIconPicturebox);
            this.Controls.Add(this.dialogHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.dialogHeader.ResumeLayout(false);
            this.dialogHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogIconPicturebox)).EndInit();
            this.dialogContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel dialogHeader;
        private Label dialogCloseBtn;
        private Label dialogHeaderText;
        private Label dialogHeaderTitle;
        private PictureBox dialogIconPicturebox;
        private Label dialogContentLabel;
        private Panel dialogContentPanel;
        private Button confirmBtn;
    }
}