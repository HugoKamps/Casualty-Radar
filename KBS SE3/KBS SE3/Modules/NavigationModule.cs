using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Models.Navigation;
using KBS_SE3.Properties;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace KBS_SE3.Modules {
    partial class NavigationModule : UserControl, IModule {
        public NavigationModule() {
            InitializeComponent();
            var y = 0;
            var color = Color.Gainsboro;

            var navSteps = new List<NavigationStep>
            {
                new NavigationStep("Sla rechtsaf", "100m", RouteStepType.Right),
                new NavigationStep("Sla linksaf", "500m", RouteStepType.Left),
                new NavigationStep("Ga rechtdoor", "1.2km", RouteStepType.Straight),
                new NavigationStep("Sla linksaf", "5km", RouteStepType.Left),
                new NavigationStep("Ga links op de rotonde", "2km", RouteStepType.Left),
                new NavigationStep("Rijd een kind aan", "500m", RouteStepType.Straight)
            };

            foreach (var t in navSteps) {
                CreateRouteStepPanel(t, color, y);
                y += 50;
                color = color == Color.Gainsboro ? Color.White : Color.Gainsboro;
            }

        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Navigation", null, ModuleManager.GetInstance().ParseInstance(typeof(HomeModule)));
        }

        public void SetAlertInfo(string title, string info, int type, string time) {
            infoTitleLabel.Text = title + "\n" + info;
            alertTypePicturebox.Image = type == 1 ? Resources.Medic : Resources.Firefighter;
            timeLabel.Text = time;
        }

        public void CreateRouteStepPanel(NavigationStep step, Color color, int y) {
            Image icon;

            switch (step.Type) {
                case RouteStepType.Straight:
                    icon = Resources.straight_icon;
                    break;
                case RouteStepType.Left:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.Right:
                    icon = Resources.turn_right_icon;
                    break;
                default:
                    icon = Resources.straight_icon;
                    break;
            }

            //The panel which will be filled with all of the controls below
            var newPanel = new Panel {
                Location = new Point(0, y),
                Size = new Size(321, 50),
                BackColor = color
            };

            var distanceLabel = new Label {
                Location = new Point(10, 0),
                Size = new Size(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Text = step.Distance
            };

            var instructionLabel = new Label {
                Location = new Point(60, 0),
                Size = new Size(130, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9),
                Text = step.Instruction
            };

            var instructionIcon = new PictureBox {
                Location = new Point(280, 10),
                Size = new Size(30, 30),
                Image = icon,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            newPanel.Controls.Add(distanceLabel);
            newPanel.Controls.Add(instructionLabel);
            newPanel.Controls.Add(instructionIcon);

            routeInfoPanel.AutoScroll = true;
            routeInfoPanel.HorizontalScroll.Enabled = false;
            routeInfoPanel.Controls.Add(newPanel);
        }
    }
}
