
﻿using KBS_SE3.Core;
using KBS_SE3.Modules;
using System;
using System.Windows.Forms;
﻿using System.Drawing;

namespace KBS_SE3 {
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
            this.topBar = new System.Windows.Forms.Panel();
            this.logoTopBar = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.subBar = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTopBar)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.topBar.Controls.Add(this.logoTopBar);
            this.topBar.Controls.Add(this.minimizeBtn);
            this.topBar.Controls.Add(this.closeBtn);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1095, 67);
            this.topBar.TabIndex = 0;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            // 
            // logoTopBar
            // 
            this.logoTopBar.Image = global::KBS_SE3.Properties.Resources.logo_final;
            this.logoTopBar.Location = new System.Drawing.Point(10, 11);
            this.logoTopBar.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.logoTopBar.Name = "logoTopBar";
            this.logoTopBar.Size = new System.Drawing.Size(287, 50);
            this.logoTopBar.TabIndex = 2;
            this.logoTopBar.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeBtn.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(913, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(91, 67);
            this.minimizeBtn.TabIndex = 1;
            this.minimizeBtn.Text = "-";
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.topBarButtons_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.topBarButtons_MouseLeave);
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1004, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(91, 67);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.topBarButtons_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.topBarButtons_MouseLeave);
            // 
            // subBar
            // 
            this.subBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(89)))), ((int)(((byte)(71)))));
            this.subBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.subBar.Location = new System.Drawing.Point(0, 67);
            this.subBar.Name = "subBar";
            this.subBar.Size = new System.Drawing.Size(1095, 20);
            this.subBar.TabIndex = 1;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.contentPanel.Location = new System.Drawing.Point(142, 87);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(953, 480);
            this.contentPanel.TabIndex = 2;
            // 
            // menuLabel
            // 
            this.menuLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.menuLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLabel.ForeColor = System.Drawing.Color.White;
            this.menuLabel.Location = new System.Drawing.Point(0, 20);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(142, 34);
            this.menuLabel.TabIndex = 1;
            this.menuLabel.Text = "Menu";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.exitBtn);
            this.menuPanel.Controls.Add(this.settingsBtn);
            this.menuPanel.Controls.Add(this.homeBtn);
            this.menuPanel.Controls.Add(this.menuLabel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 87);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.menuPanel.Size = new System.Drawing.Size(142, 480);
            this.menuPanel.TabIndex = 3;
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(0, 114);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(142, 30);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.ForeColor = System.Drawing.Color.White;
            this.settingsBtn.Location = new System.Drawing.Point(0, 84);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(142, 30);
            this.settingsBtn.TabIndex = 5;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.ForeColor = System.Drawing.Color.White;
            this.homeBtn.Location = new System.Drawing.Point(0, 54);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(142, 30);
            this.homeBtn.TabIndex = 4;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1095, 567);
            this.ControlBox = false;
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.subBar);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Container";
            this.Text = "Casualty Radar";
            this.topBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoTopBar)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Panel subBar;
        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.PictureBox logoTopBar;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button homeBtn;
    }
}

