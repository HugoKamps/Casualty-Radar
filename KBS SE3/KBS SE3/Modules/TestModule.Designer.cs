namespace Casualty_Radar.Modules
{
    partial class TestModule
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.testStatusBox = new System.Windows.Forms.TextBox();
            this.testResultsBox = new System.Windows.Forms.TextBox();
            this.testStatusLabel = new System.Windows.Forms.Label();
            this.testStatusBar = new System.Windows.Forms.ProgressBar();
            this.firstAlgorithmLabel = new System.Windows.Forms.Label();
            this.secondAlgorithmLabel = new System.Windows.Forms.Label();
            this.totalRoutesLabel = new System.Windows.Forms.Label();
            this.firstAlgorithmTypeLabel = new System.Windows.Forms.Label();
            this.secondAlgorithmTypeLabel = new System.Windows.Forms.Label();
            this.moduleTitleLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.startTestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // testStatusBox
            // 
            this.testStatusBox.BackColor = System.Drawing.SystemColors.Control;
            this.testStatusBox.Location = new System.Drawing.Point(464, 38);
            this.testStatusBox.Multiline = true;
            this.testStatusBox.Name = "testStatusBox";
            this.testStatusBox.Size = new System.Drawing.Size(466, 263);
            this.testStatusBox.TabIndex = 0;
            // 
            // testResultsBox
            // 
            this.testResultsBox.BackColor = System.Drawing.SystemColors.Control;
            this.testResultsBox.Location = new System.Drawing.Point(464, 385);
            this.testResultsBox.Multiline = true;
            this.testResultsBox.Name = "testResultsBox";
            this.testResultsBox.Size = new System.Drawing.Size(466, 63);
            this.testResultsBox.TabIndex = 1;
            // 
            // testStatusLabel
            // 
            this.testStatusLabel.AutoSize = true;
            this.testStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testStatusLabel.Location = new System.Drawing.Point(462, 20);
            this.testStatusLabel.Name = "testStatusLabel";
            this.testStatusLabel.Size = new System.Drawing.Size(47, 15);
            this.testStatusLabel.TabIndex = 2;
            this.testStatusLabel.Text = "Status";
            // 
            // testStatusBar
            // 
            this.testStatusBar.Location = new System.Drawing.Point(465, 316);
            this.testStatusBar.Name = "testStatusBar";
            this.testStatusBar.Size = new System.Drawing.Size(465, 23);
            this.testStatusBar.TabIndex = 3;
            // 
            // firstAlgorithmLabel
            // 
            this.firstAlgorithmLabel.AutoSize = true;
            this.firstAlgorithmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstAlgorithmLabel.Location = new System.Drawing.Point(29, 76);
            this.firstAlgorithmLabel.Name = "firstAlgorithmLabel";
            this.firstAlgorithmLabel.Size = new System.Drawing.Size(95, 17);
            this.firstAlgorithmLabel.TabIndex = 4;
            this.firstAlgorithmLabel.Text = "1e Algoritme: ";
            // 
            // secondAlgorithmLabel
            // 
            this.secondAlgorithmLabel.AutoSize = true;
            this.secondAlgorithmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondAlgorithmLabel.Location = new System.Drawing.Point(29, 110);
            this.secondAlgorithmLabel.Name = "secondAlgorithmLabel";
            this.secondAlgorithmLabel.Size = new System.Drawing.Size(95, 17);
            this.secondAlgorithmLabel.TabIndex = 5;
            this.secondAlgorithmLabel.Text = "2e Algoritme: ";
            // 
            // totalRoutesLabel
            // 
            this.totalRoutesLabel.AutoSize = true;
            this.totalRoutesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRoutesLabel.Location = new System.Drawing.Point(29, 172);
            this.totalRoutesLabel.Name = "totalRoutesLabel";
            this.totalRoutesLabel.Size = new System.Drawing.Size(100, 17);
            this.totalRoutesLabel.TabIndex = 6;
            this.totalRoutesLabel.Text = "Aantal routes: ";
            // 
            // firstAlgorithmTypeLabel
            // 
            this.firstAlgorithmTypeLabel.AutoSize = true;
            this.firstAlgorithmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstAlgorithmTypeLabel.Location = new System.Drawing.Point(195, 77);
            this.firstAlgorithmTypeLabel.Name = "firstAlgorithmTypeLabel";
            this.firstAlgorithmTypeLabel.Size = new System.Drawing.Size(133, 17);
            this.firstAlgorithmTypeLabel.TabIndex = 7;
            this.firstAlgorithmTypeLabel.Text = "Casualty Radar (A*)";
            // 
            // secondAlgorithmTypeLabel
            // 
            this.secondAlgorithmTypeLabel.AutoSize = true;
            this.secondAlgorithmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondAlgorithmTypeLabel.Location = new System.Drawing.Point(195, 110);
            this.secondAlgorithmTypeLabel.Name = "secondAlgorithmTypeLabel";
            this.secondAlgorithmTypeLabel.Size = new System.Drawing.Size(92, 17);
            this.secondAlgorithmTypeLabel.TabIndex = 8;
            this.secondAlgorithmTypeLabel.Text = "Google Maps";
            // 
            // moduleTitleLabel
            // 
            this.moduleTitleLabel.AutoSize = true;
            this.moduleTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleTitleLabel.Location = new System.Drawing.Point(27, 20);
            this.moduleTitleLabel.Name = "moduleTitleLabel";
            this.moduleTitleLabel.Size = new System.Drawing.Size(148, 26);
            this.moduleTitleLabel.TabIndex = 9;
            this.moduleTitleLabel.Text = "Testomgeving";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(198, 172);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Resultaten";
            // 
            // startTestButton
            // 
            this.startTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startTestButton.Location = new System.Drawing.Point(32, 228);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(107, 41);
            this.startTestButton.TabIndex = 12;
            this.startTestButton.Text = "Test Algoritmes";
            this.startTestButton.UseVisualStyleBackColor = true;
            // 
            // TestModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.moduleTitleLabel);
            this.Controls.Add(this.secondAlgorithmTypeLabel);
            this.Controls.Add(this.firstAlgorithmTypeLabel);
            this.Controls.Add(this.totalRoutesLabel);
            this.Controls.Add(this.secondAlgorithmLabel);
            this.Controls.Add(this.firstAlgorithmLabel);
            this.Controls.Add(this.testStatusBar);
            this.Controls.Add(this.testStatusLabel);
            this.Controls.Add(this.testResultsBox);
            this.Controls.Add(this.testStatusBox);
            this.Name = "TestModule";
            this.Size = new System.Drawing.Size(953, 480);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox testStatusBox;
        private System.Windows.Forms.TextBox testResultsBox;
        private System.Windows.Forms.Label testStatusLabel;
        private System.Windows.Forms.ProgressBar testStatusBar;
        private System.Windows.Forms.Label firstAlgorithmLabel;
        private System.Windows.Forms.Label secondAlgorithmLabel;
        private System.Windows.Forms.Label totalRoutesLabel;
        private System.Windows.Forms.Label firstAlgorithmTypeLabel;
        private System.Windows.Forms.Label secondAlgorithmTypeLabel;
        private System.Windows.Forms.Label moduleTitleLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startTestButton;
    }
}
