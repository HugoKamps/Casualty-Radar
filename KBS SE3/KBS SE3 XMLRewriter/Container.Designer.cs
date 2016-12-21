using XMLRewriter.Core;

namespace XMLRewriter {
    partial class Container {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Container));
            this.convertBtn = new System.Windows.Forms.Button();
            this.convertContainer = new XMLRewriter.Core.SectionPanel();
            this.convertDataLog = new System.Windows.Forms.TextBox();
            this.fileSettingsContainer = new XMLRewriter.Core.SectionPanel();
            this.outputTypeLabel = new System.Windows.Forms.Label();
            this.outputNameBox = new System.Windows.Forms.TextBox();
            this.outputNameLabel = new System.Windows.Forms.Label();
            this.destinationFileSelectBtn = new System.Windows.Forms.Button();
            this.fileDestinationBox = new System.Windows.Forms.TextBox();
            this.fileDestinationLabel = new System.Windows.Forms.Label();
            this.fileLocationBox = new System.Windows.Forms.TextBox();
            this.fileLocationLabel = new System.Windows.Forms.Label();
            this.browseFileBtn = new System.Windows.Forms.Button();
            this.convertStatusBar = new System.Windows.Forms.ProgressBar();
            this.convertContainer.SuspendLayout();
            this.fileSettingsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // convertBtn
            // 
            this.convertBtn.Enabled = false;
            this.convertBtn.Location = new System.Drawing.Point(355, 328);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 5;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // convertContainer
            // 
            this.convertContainer.Controls.Add(this.convertDataLog);
            this.convertContainer.Location = new System.Drawing.Point(3, 168);
            this.convertContainer.Name = "convertContainer";
            this.convertContainer.Size = new System.Drawing.Size(424, 144);
            this.convertContainer.TabIndex = 4;
            // 
            // convertDataLog
            // 
            this.convertDataLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.convertDataLog.Enabled = false;
            this.convertDataLog.Location = new System.Drawing.Point(19, 14);
            this.convertDataLog.Multiline = true;
            this.convertDataLog.Name = "convertDataLog";
            this.convertDataLog.Size = new System.Drawing.Size(394, 124);
            this.convertDataLog.TabIndex = 1;
            // 
            // fileSettingsContainer
            // 
            this.fileSettingsContainer.Controls.Add(this.outputTypeLabel);
            this.fileSettingsContainer.Controls.Add(this.outputNameBox);
            this.fileSettingsContainer.Controls.Add(this.outputNameLabel);
            this.fileSettingsContainer.Controls.Add(this.destinationFileSelectBtn);
            this.fileSettingsContainer.Controls.Add(this.fileDestinationBox);
            this.fileSettingsContainer.Controls.Add(this.fileDestinationLabel);
            this.fileSettingsContainer.Controls.Add(this.fileLocationBox);
            this.fileSettingsContainer.Controls.Add(this.fileLocationLabel);
            this.fileSettingsContainer.Controls.Add(this.browseFileBtn);
            this.fileSettingsContainer.ForeColor = System.Drawing.Color.Black;
            this.fileSettingsContainer.Location = new System.Drawing.Point(3, 25);
            this.fileSettingsContainer.Margin = new System.Windows.Forms.Padding(10);
            this.fileSettingsContainer.Name = "fileSettingsContainer";
            this.fileSettingsContainer.Size = new System.Drawing.Size(424, 130);
            this.fileSettingsContainer.TabIndex = 3;
            // 
            // outputTypeLabel
            // 
            this.outputTypeLabel.AutoSize = true;
            this.outputTypeLabel.ForeColor = System.Drawing.Color.DimGray;
            this.outputTypeLabel.Location = new System.Drawing.Point(221, 85);
            this.outputTypeLabel.Name = "outputTypeLabel";
            this.outputTypeLabel.Size = new System.Drawing.Size(28, 13);
            this.outputTypeLabel.TabIndex = 9;
            this.outputTypeLabel.Text = ". xml";
            // 
            // outputNameBox
            // 
            this.outputNameBox.Location = new System.Drawing.Point(103, 80);
            this.outputNameBox.Name = "outputNameBox";
            this.outputNameBox.Size = new System.Drawing.Size(118, 20);
            this.outputNameBox.TabIndex = 8;
            // 
            // outputNameLabel
            // 
            this.outputNameLabel.AutoSize = true;
            this.outputNameLabel.Location = new System.Drawing.Point(20, 83);
            this.outputNameLabel.Name = "outputNameLabel";
            this.outputNameLabel.Size = new System.Drawing.Size(71, 13);
            this.outputNameLabel.TabIndex = 7;
            this.outputNameLabel.Text = "Output name:";
            // 
            // destinationFileSelectBtn
            // 
            this.destinationFileSelectBtn.Enabled = false;
            this.destinationFileSelectBtn.Location = new System.Drawing.Point(368, 55);
            this.destinationFileSelectBtn.Name = "destinationFileSelectBtn";
            this.destinationFileSelectBtn.Size = new System.Drawing.Size(31, 24);
            this.destinationFileSelectBtn.TabIndex = 5;
            this.destinationFileSelectBtn.Text = "...";
            this.destinationFileSelectBtn.UseVisualStyleBackColor = true;
            this.destinationFileSelectBtn.Click += new System.EventHandler(this.destinationFileSelectBtn_Click);
            // 
            // fileDestinationBox
            // 
            this.fileDestinationBox.Location = new System.Drawing.Point(103, 56);
            this.fileDestinationBox.Name = "fileDestinationBox";
            this.fileDestinationBox.Size = new System.Drawing.Size(251, 20);
            this.fileDestinationBox.TabIndex = 4;
            // 
            // fileDestinationLabel
            // 
            this.fileDestinationLabel.AutoSize = true;
            this.fileDestinationLabel.Location = new System.Drawing.Point(20, 59);
            this.fileDestinationLabel.Name = "fileDestinationLabel";
            this.fileDestinationLabel.Size = new System.Drawing.Size(63, 13);
            this.fileDestinationLabel.TabIndex = 3;
            this.fileDestinationLabel.Text = "Destination:";
            // 
            // fileLocationBox
            // 
            this.fileLocationBox.Location = new System.Drawing.Point(103, 33);
            this.fileLocationBox.Name = "fileLocationBox";
            this.fileLocationBox.Size = new System.Drawing.Size(251, 20);
            this.fileLocationBox.TabIndex = 0;
            // 
            // fileLocationLabel
            // 
            this.fileLocationLabel.AutoSize = true;
            this.fileLocationLabel.Location = new System.Drawing.Point(20, 35);
            this.fileLocationLabel.Name = "fileLocationLabel";
            this.fileLocationLabel.Size = new System.Drawing.Size(41, 13);
            this.fileLocationLabel.TabIndex = 1;
            this.fileLocationLabel.Text = "Target:";
            // 
            // browseFileBtn
            // 
            this.browseFileBtn.Location = new System.Drawing.Point(368, 31);
            this.browseFileBtn.Name = "browseFileBtn";
            this.browseFileBtn.Size = new System.Drawing.Size(31, 24);
            this.browseFileBtn.TabIndex = 2;
            this.browseFileBtn.Text = "...";
            this.browseFileBtn.UseVisualStyleBackColor = true;
            this.browseFileBtn.Click += new System.EventHandler(this.browseFileBtn_Click);
            // 
            // convertStatusBar
            // 
            this.convertStatusBar.Location = new System.Drawing.Point(10, 328);
            this.convertStatusBar.Name = "convertStatusBar";
            this.convertStatusBar.Size = new System.Drawing.Size(339, 23);
            this.convertStatusBar.TabIndex = 6;
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 357);
            this.Controls.Add(this.convertStatusBar);
            this.Controls.Add(this.convertBtn);
            this.Controls.Add(this.convertContainer);
            this.Controls.Add(this.fileSettingsContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Container";
            this.Text = "XML Rewriter";
            this.convertContainer.ResumeLayout(false);
            this.convertContainer.PerformLayout();
            this.fileSettingsContainer.ResumeLayout(false);
            this.fileSettingsContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browseFileBtn;
        private System.Windows.Forms.Label fileLocationLabel;
        private System.Windows.Forms.TextBox fileLocationBox;
        private SectionPanel fileSettingsContainer;
        private System.Windows.Forms.Button destinationFileSelectBtn;
        private System.Windows.Forms.TextBox fileDestinationBox;
        private System.Windows.Forms.Label fileDestinationLabel;
        private SectionPanel convertContainer;
        private System.Windows.Forms.Button convertBtn;
        private System.Windows.Forms.TextBox outputNameBox;
        private System.Windows.Forms.Label outputNameLabel;
        private System.Windows.Forms.Label outputTypeLabel;
        private System.Windows.Forms.TextBox convertDataLog;
        private System.Windows.Forms.ProgressBar convertStatusBar;
    }
}

