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
            this.testStatusLabel = new System.Windows.Forms.Label();
            this.testStatusBar = new System.Windows.Forms.ProgressBar();
            this.firstAlgorithmLabel = new System.Windows.Forms.Label();
            this.secondAlgorithmLabel = new System.Windows.Forms.Label();
            this.totalRoutesLabel = new System.Windows.Forms.Label();
            this.firstAlgorithmTypeLabel = new System.Windows.Forms.Label();
            this.secondAlgorithmTypeLabel = new System.Windows.Forms.Label();
            this.moduleTitleLabel = new System.Windows.Forms.Label();
            this.amountOfRoutesNumeric = new System.Windows.Forms.NumericUpDown();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.startTestButton = new System.Windows.Forms.Button();
            this.clearPreviousTest = new System.Windows.Forms.Button();
            this.algorithmOneResultsLabel = new System.Windows.Forms.Label();
            this.algorithmTwoResultsLabel = new System.Windows.Forms.Label();
            this.totalDurationTextLabel = new System.Windows.Forms.Label();
            this.averageDurationTextLabel = new System.Windows.Forms.Label();
            this.totalDistanceTextLabel = new System.Windows.Forms.Label();
            this.bestRoutesTextLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aTwoBestRoutesLabel = new System.Windows.Forms.Label();
            this.aOneBestRoutesLabel = new System.Windows.Forms.Label();
            this.aTwoTotalDistanceLabel = new System.Windows.Forms.Label();
            this.aOneTotalDistanceLabel = new System.Windows.Forms.Label();
            this.aTwoAverageDurationLabel = new System.Windows.Forms.Label();
            this.aOneAverageDurationLabel = new System.Windows.Forms.Label();
            this.aTwoTotalDurationLabel = new System.Windows.Forms.Label();
            this.aOneTotalDurationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfRoutesNumeric)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testStatusBox
            // 
            this.testStatusBox.BackColor = System.Drawing.SystemColors.Control;
            this.testStatusBox.Location = new System.Drawing.Point(464, 38);
            this.testStatusBox.Multiline = true;
            this.testStatusBox.Name = "testStatusBox";
            this.testStatusBox.Size = new System.Drawing.Size(466, 202);
            this.testStatusBox.TabIndex = 0;
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
            this.testStatusBar.Location = new System.Drawing.Point(465, 246);
            this.testStatusBar.Name = "testStatusBar";
            this.testStatusBar.Size = new System.Drawing.Size(465, 23);
            this.testStatusBar.Step = 100;
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
            // amountOfRoutesNumeric
            // 
            this.amountOfRoutesNumeric.Location = new System.Drawing.Point(198, 172);
            this.amountOfRoutesNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.amountOfRoutesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountOfRoutesNumeric.Name = "amountOfRoutesNumeric";
            this.amountOfRoutesNumeric.Size = new System.Drawing.Size(89, 20);
            this.amountOfRoutesNumeric.TabIndex = 10;
            this.amountOfRoutesNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.resultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsLabel.Location = new System.Drawing.Point(10, 9);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(88, 18);
            this.resultsLabel.TabIndex = 11;
            this.resultsLabel.Text = "Resultaten";
            // 
            // startTestButton
            // 
            this.startTestButton.BackColor = System.Drawing.SystemColors.Control;
            this.startTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startTestButton.Location = new System.Drawing.Point(32, 228);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(107, 41);
            this.startTestButton.TabIndex = 12;
            this.startTestButton.Text = "Test Algoritmes";
            this.startTestButton.UseVisualStyleBackColor = false;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // clearPreviousTest
            // 
            this.clearPreviousTest.BackColor = System.Drawing.SystemColors.Control;
            this.clearPreviousTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearPreviousTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearPreviousTest.Location = new System.Drawing.Point(253, 246);
            this.clearPreviousTest.Name = "clearPreviousTest";
            this.clearPreviousTest.Size = new System.Drawing.Size(75, 23);
            this.clearPreviousTest.TabIndex = 13;
            this.clearPreviousTest.Text = "Clear";
            this.clearPreviousTest.UseVisualStyleBackColor = false;
            this.clearPreviousTest.Click += new System.EventHandler(this.clearPreviousTest_Click);
            // 
            // algorithmOneResultsLabel
            // 
            this.algorithmOneResultsLabel.AutoSize = true;
            this.algorithmOneResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmOneResultsLabel.Location = new System.Drawing.Point(10, 60);
            this.algorithmOneResultsLabel.Name = "algorithmOneResultsLabel";
            this.algorithmOneResultsLabel.Size = new System.Drawing.Size(133, 17);
            this.algorithmOneResultsLabel.TabIndex = 14;
            this.algorithmOneResultsLabel.Text = "Casualty Radar (A*)";
            // 
            // algorithmTwoResultsLabel
            // 
            this.algorithmTwoResultsLabel.AutoSize = true;
            this.algorithmTwoResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmTwoResultsLabel.Location = new System.Drawing.Point(10, 119);
            this.algorithmTwoResultsLabel.Name = "algorithmTwoResultsLabel";
            this.algorithmTwoResultsLabel.Size = new System.Drawing.Size(92, 17);
            this.algorithmTwoResultsLabel.TabIndex = 15;
            this.algorithmTwoResultsLabel.Text = "Google Maps";
            // 
            // totalDurationTextLabel
            // 
            this.totalDurationTextLabel.AutoSize = true;
            this.totalDurationTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDurationTextLabel.Location = new System.Drawing.Point(231, 11);
            this.totalDurationTextLabel.Name = "totalDurationTextLabel";
            this.totalDurationTextLabel.Size = new System.Drawing.Size(81, 17);
            this.totalDurationTextLabel.TabIndex = 16;
            this.totalDurationTextLabel.Text = "Totale duur";
            // 
            // averageDurationTextLabel
            // 
            this.averageDurationTextLabel.AutoSize = true;
            this.averageDurationTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageDurationTextLabel.Location = new System.Drawing.Point(400, 11);
            this.averageDurationTextLabel.Name = "averageDurationTextLabel";
            this.averageDurationTextLabel.Size = new System.Drawing.Size(117, 17);
            this.averageDurationTextLabel.TabIndex = 17;
            this.averageDurationTextLabel.Text = "Gemiddelde duur";
            // 
            // totalDistanceTextLabel
            // 
            this.totalDistanceTextLabel.AutoSize = true;
            this.totalDistanceTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDistanceTextLabel.Location = new System.Drawing.Point(577, 11);
            this.totalDistanceTextLabel.Name = "totalDistanceTextLabel";
            this.totalDistanceTextLabel.Size = new System.Drawing.Size(99, 17);
            this.totalDistanceTextLabel.TabIndex = 18;
            this.totalDistanceTextLabel.Text = "Totale afstand";
            // 
            // bestRoutesTextLabel
            // 
            this.bestRoutesTextLabel.AutoSize = true;
            this.bestRoutesTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestRoutesTextLabel.Location = new System.Drawing.Point(748, 11);
            this.bestRoutesTextLabel.Name = "bestRoutesTextLabel";
            this.bestRoutesTextLabel.Size = new System.Drawing.Size(111, 17);
            this.bestRoutesTextLabel.TabIndex = 19;
            this.bestRoutesTextLabel.Text = "Snelst berekend";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.aTwoBestRoutesLabel);
            this.panel1.Controls.Add(this.aOneBestRoutesLabel);
            this.panel1.Controls.Add(this.aTwoTotalDistanceLabel);
            this.panel1.Controls.Add(this.aOneTotalDistanceLabel);
            this.panel1.Controls.Add(this.aTwoAverageDurationLabel);
            this.panel1.Controls.Add(this.aOneAverageDurationLabel);
            this.panel1.Controls.Add(this.aTwoTotalDurationLabel);
            this.panel1.Controls.Add(this.aOneTotalDurationLabel);
            this.panel1.Controls.Add(this.algorithmTwoResultsLabel);
            this.panel1.Controls.Add(this.totalDurationTextLabel);
            this.panel1.Controls.Add(this.algorithmOneResultsLabel);
            this.panel1.Controls.Add(this.bestRoutesTextLabel);
            this.panel1.Controls.Add(this.resultsLabel);
            this.panel1.Controls.Add(this.totalDistanceTextLabel);
            this.panel1.Controls.Add(this.averageDurationTextLabel);
            this.panel1.Location = new System.Drawing.Point(32, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 172);
            this.panel1.TabIndex = 20;
            // 
            // aTwoBestRoutesLabel
            // 
            this.aTwoBestRoutesLabel.AutoSize = true;
            this.aTwoBestRoutesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aTwoBestRoutesLabel.Location = new System.Drawing.Point(748, 119);
            this.aTwoBestRoutesLabel.Name = "aTwoBestRoutesLabel";
            this.aTwoBestRoutesLabel.Size = new System.Drawing.Size(13, 17);
            this.aTwoBestRoutesLabel.TabIndex = 27;
            this.aTwoBestRoutesLabel.Text = "-";
            // 
            // aOneBestRoutesLabel
            // 
            this.aOneBestRoutesLabel.AutoSize = true;
            this.aOneBestRoutesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aOneBestRoutesLabel.Location = new System.Drawing.Point(748, 60);
            this.aOneBestRoutesLabel.Name = "aOneBestRoutesLabel";
            this.aOneBestRoutesLabel.Size = new System.Drawing.Size(13, 17);
            this.aOneBestRoutesLabel.TabIndex = 26;
            this.aOneBestRoutesLabel.Text = "-";
            // 
            // aTwoTotalDistanceLabel
            // 
            this.aTwoTotalDistanceLabel.AutoSize = true;
            this.aTwoTotalDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aTwoTotalDistanceLabel.Location = new System.Drawing.Point(577, 119);
            this.aTwoTotalDistanceLabel.Name = "aTwoTotalDistanceLabel";
            this.aTwoTotalDistanceLabel.Size = new System.Drawing.Size(13, 17);
            this.aTwoTotalDistanceLabel.TabIndex = 25;
            this.aTwoTotalDistanceLabel.Text = "-";
            // 
            // aOneTotalDistanceLabel
            // 
            this.aOneTotalDistanceLabel.AutoSize = true;
            this.aOneTotalDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aOneTotalDistanceLabel.Location = new System.Drawing.Point(577, 60);
            this.aOneTotalDistanceLabel.Name = "aOneTotalDistanceLabel";
            this.aOneTotalDistanceLabel.Size = new System.Drawing.Size(13, 17);
            this.aOneTotalDistanceLabel.TabIndex = 24;
            this.aOneTotalDistanceLabel.Text = "-";
            // 
            // aTwoAverageDurationLabel
            // 
            this.aTwoAverageDurationLabel.AutoSize = true;
            this.aTwoAverageDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aTwoAverageDurationLabel.Location = new System.Drawing.Point(400, 119);
            this.aTwoAverageDurationLabel.Name = "aTwoAverageDurationLabel";
            this.aTwoAverageDurationLabel.Size = new System.Drawing.Size(13, 17);
            this.aTwoAverageDurationLabel.TabIndex = 23;
            this.aTwoAverageDurationLabel.Text = "-";
            // 
            // aOneAverageDurationLabel
            // 
            this.aOneAverageDurationLabel.AutoSize = true;
            this.aOneAverageDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aOneAverageDurationLabel.Location = new System.Drawing.Point(400, 60);
            this.aOneAverageDurationLabel.Name = "aOneAverageDurationLabel";
            this.aOneAverageDurationLabel.Size = new System.Drawing.Size(13, 17);
            this.aOneAverageDurationLabel.TabIndex = 22;
            this.aOneAverageDurationLabel.Text = "-";
            // 
            // aTwoTotalDurationLabel
            // 
            this.aTwoTotalDurationLabel.AutoSize = true;
            this.aTwoTotalDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aTwoTotalDurationLabel.Location = new System.Drawing.Point(231, 119);
            this.aTwoTotalDurationLabel.Name = "aTwoTotalDurationLabel";
            this.aTwoTotalDurationLabel.Size = new System.Drawing.Size(13, 17);
            this.aTwoTotalDurationLabel.TabIndex = 21;
            this.aTwoTotalDurationLabel.Text = "-";
            // 
            // aOneTotalDurationLabel
            // 
            this.aOneTotalDurationLabel.AutoSize = true;
            this.aOneTotalDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aOneTotalDurationLabel.Location = new System.Drawing.Point(231, 60);
            this.aOneTotalDurationLabel.Name = "aOneTotalDurationLabel";
            this.aOneTotalDurationLabel.Size = new System.Drawing.Size(13, 17);
            this.aOneTotalDurationLabel.TabIndex = 20;
            this.aOneTotalDurationLabel.Text = "-";
            // 
            // TestModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.clearPreviousTest);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.amountOfRoutesNumeric);
            this.Controls.Add(this.moduleTitleLabel);
            this.Controls.Add(this.secondAlgorithmTypeLabel);
            this.Controls.Add(this.firstAlgorithmTypeLabel);
            this.Controls.Add(this.totalRoutesLabel);
            this.Controls.Add(this.secondAlgorithmLabel);
            this.Controls.Add(this.firstAlgorithmLabel);
            this.Controls.Add(this.testStatusBar);
            this.Controls.Add(this.testStatusLabel);
            this.Controls.Add(this.testStatusBox);
            this.Controls.Add(this.panel1);
            this.Name = "TestModule";
            this.Size = new System.Drawing.Size(953, 480);
            ((System.ComponentModel.ISupportInitialize)(this.amountOfRoutesNumeric)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox testStatusBox;
        private System.Windows.Forms.Label testStatusLabel;
        private System.Windows.Forms.ProgressBar testStatusBar;
        private System.Windows.Forms.Label firstAlgorithmLabel;
        private System.Windows.Forms.Label secondAlgorithmLabel;
        private System.Windows.Forms.Label totalRoutesLabel;
        private System.Windows.Forms.Label firstAlgorithmTypeLabel;
        private System.Windows.Forms.Label secondAlgorithmTypeLabel;
        private System.Windows.Forms.Label moduleTitleLabel;
        private System.Windows.Forms.NumericUpDown amountOfRoutesNumeric;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Button clearPreviousTest;
        private System.Windows.Forms.Label algorithmOneResultsLabel;
        private System.Windows.Forms.Label algorithmTwoResultsLabel;
        private System.Windows.Forms.Label totalDurationTextLabel;
        private System.Windows.Forms.Label averageDurationTextLabel;
        private System.Windows.Forms.Label totalDistanceTextLabel;
        private System.Windows.Forms.Label bestRoutesTextLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label aTwoBestRoutesLabel;
        private System.Windows.Forms.Label aOneBestRoutesLabel;
        private System.Windows.Forms.Label aTwoTotalDistanceLabel;
        private System.Windows.Forms.Label aOneTotalDistanceLabel;
        private System.Windows.Forms.Label aTwoAverageDurationLabel;
        private System.Windows.Forms.Label aOneAverageDurationLabel;
        private System.Windows.Forms.Label aTwoTotalDurationLabel;
        private System.Windows.Forms.Label aOneTotalDurationLabel;
    }
}
