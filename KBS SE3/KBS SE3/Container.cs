﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Core.Dialog;
using Casualty_Radar.Models.DataControl;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Modules;
using static Casualty_Radar.Core.Dialog.DialogType;
using System.Threading;
using System.ComponentModel;

namespace Casualty_Radar {
    public partial class Container : Form {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x20000;

        private Dialog _dialog;
        private static Container _instance;
        private ModuleManager _modManager;

        public SplashScreenModule SplashScreen { get; private set; }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private Container() {
            InitializeComponent();

            Thread t = new Thread(new ThreadStart(SplashThread));
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            _modManager = ModuleManager.GetInstance();
            _dialog = new Dialog();
            RegisterButtons();
            homeBtn.BackColor = Color.FromArgb(236, 89, 71);
        }

        private void SplashThread() {
            SplashScreen = new SplashScreenModule();
            DisplaySplashScreen();
        }

        /// <summary>
        /// Returns a single-ton instance from the Container class
        /// </summary>
        /// <returns>Container instance</returns>
        public static Container GetInstance() => _instance ?? (_instance = new Container());

        public void DisplaySplashScreen() {
            Controls.Add(SplashScreen);
            SplashScreen.Show();
            SplashScreen.BringToFront();
        }

        /// <summary>
        /// Shows a dialog with the given properties
        /// </summary>
        /// <param name="type">The type of the dialog</param>
        /// <param name="title">The string title of the dialog</param>
        /// <param name="msg">The message content of the dialog</param>
        public void DisplayDialog(DialogMessageType type, string title, string msg) {
            using (new DialogOverlay()) {
                _dialog.StartPosition = FormStartPosition.CenterParent;
                _dialog.Display(type, title, msg);
                _dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Method that registers all buttons in the application menu
        /// Each button is bound to a Module; which is an instance of IModule
        /// </summary>
        private void RegisterButtons() {
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
            Label selected = (Label)sender;
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

        private void menuBtn_Click(object sender, EventArgs e) {
            IModule module = ModuleManager.GetInstance().GetCurrentModule();

            homeBtn.BackColor = Color.FromArgb(52, 57, 61);
            settingsBtn.BackColor = Color.FromArgb(52, 57, 61);
            if(module.GetType() != typeof(GetStartedModule)) {
                Button selectedButton = (Button)sender;
                selectedButton.BackColor = Color.FromArgb(236, 89, 71);
                ModuleManager.GetInstance().UpdateModule(selectedButton.Tag);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e) => Application.Exit();

        private void Container_Load(object sender, EventArgs e) {
            BackgroundWorker bW = new BackgroundWorker();
            HomeModule hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
            Shown += hm.HomeModule_Load;
            _modManager.UpdateModule(hm);

        }

        private void prevBtn_Click(object sender, EventArgs e) {
            ModuleManager.GetInstance().UpdateModule(ModuleManager.GetInstance().GetCurrentModule().GetBreadcrumb().Parent);
        }

        private void testBtn_Click(object sender, EventArgs e) {
            DataParser parser = new DataParser(@"C:\Users\richa_000\Desktop\hattem.xml");
            parser.Deserialize();
            DataCollection col = parser.GetCollection();
            //DisplayDialog(DialogMessageType.ERROR, "XML Error", "Je moet eem een nieuwe XML Parsen.");
        }

        /*
        * TEST METHOD 
        */
        private void TestDraw(HomeModule hm, Node n) {
            //hm.RouteOverlay.Markers.Add(new GMarkerGoogle(n.GetPoint(), GMarkerGoogleType.red_big_stop));
            //foreach (Node adjacent in MapUtil.GetAdjacentNodes(n)) {
            //    GMapMarker m = new GMarkerGoogle(adjacent.GetPoint(), GMarkerGoogleType.blue_dot);
            //    hm.RouteOverlay.Markers.Add(m);
            //}
            ModuleManager.GetInstance().UpdateModule(ModuleManager.GetInstance().ParseInstance(typeof(GetStartedModule)));

        }
    }
}
