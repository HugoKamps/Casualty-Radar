﻿using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Modules;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KBS_SE3 {
    public partial class Container : Form {

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x20000;
        private static Container _instance;
        private ModuleManager _modManager;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private Container() {
            InitializeComponent();
            this._modManager = ModuleManager.GetInstance();
            registerButtons();
            homeBtn.BackColor = Color.FromArgb(236, 89, 71);
            _modManager.UpdateModule(breadCrumbStart, contentPanel, _modManager.GetDefaultModule());
        }

        public static Container GetInstance() {
            if (_instance == null) _instance = new Container();
            return _instance;
        }

        public Label GetBreadcrumbStart()
        {
            return breadCrumbStart;
        }
        
        /*
        * Method that registers all buttons in the application menu
        * Each button is bound to a Module; which is an instance of IModule
        */
        private void registerButtons() {
            homeBtn.Tag = _modManager.ParseInstance(typeof(HomeModule));
            settingsBtn.Tag = _modManager.ParseInstance(typeof(SettingsModule));
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        
        //This event is triggered when the minimize button is clicked. It minimizes the window
        private void minimizeBtn_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        /* This event is triggered when the user's mouse hovers over the minimize or exit button. 
        It changes the color to show which button is being hovered over. */
        private void topBarButtons_MouseEnter(object sender, EventArgs e) {
            Label selected = (Label) sender;
            selected.BackColor = Color.FromArgb(220, 82, 66);
        }

        private void prevBtn_MouseEnter(object sender, EventArgs e) {
            Label selected = (Label)sender;
            selected.ForeColor = Color.White;
        }

        private void prevBtn_MouseLeave(object sender, EventArgs e) {
            Label selected = (Label)sender;
            selected.ForeColor = Color.Gainsboro;
        }

        private void topBarButtons_MouseLeave(object sender, EventArgs e) {
            Label selected = (Label)sender;
            selected.BackColor = Color.FromArgb(210, 73, 57);
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void menuBtn_Click(object sender, EventArgs e){
            homeBtn.BackColor = Color.FromArgb(52, 57, 61);
            settingsBtn.BackColor = Color.FromArgb(52, 57, 61);
            Button selectedButton = (Button) sender;
            selectedButton.BackColor = Color.FromArgb(236, 89, 71);
            ModuleManager.GetInstance().UpdateModule(breadCrumbStart, contentPanel, selectedButton.Tag);
        }

        private void exitBtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Container_Load(object sender, EventArgs e){
            // Load the feed
            FeedTicker feedTicker = new FeedTicker(30000, Feed.GetInstance());
        }

        private void prevBtn_Click(object sender, EventArgs e) {

        }
    }
}
