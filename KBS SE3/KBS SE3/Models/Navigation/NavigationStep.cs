using System.Drawing;
using System.Windows.Forms;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Properties;

namespace Casualty_Radar.Models.Navigation {
    /// <summary>
    /// Indicates what the user needs to do for the current step
    /// </summary>
    public enum RouteStepType {
        CurveLeft,
        CurveRight,
        Left,
        Right,
        SharpLeft,
        SharpRight,
        Straight,
        DestinationReached
    }

    /// <summary>
    /// Model class for a navigation step in a route
    /// </summary>
    class NavigationStep {
        /// <summary>
        /// Indicates how long it takes until the next step
        /// </summary>
        public double Distance { get; set; }

        public string FormattedDistance { get; set; }
        public RouteStepType Type { get; set; }

        /// <summary>
        /// The instruction for the current step in the route
        /// </summary>
        public string Instruction { get; set; }


        public Way Way { get; set; }

        public NavigationStep(double distance, RouteStepType type, Way way) {
            Distance = distance;
            Type = type;
            Way = way;
        }
        
        /// <summary>
        /// Set the instruction string based on the current RouteStepType, the distance and the way
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dist"></param>
        /// <param name="way"></param>
        public void SetInstruction() {
            string instruction;
            FormattedDistance = GetFormattedDistance(Distance);
            string way = Way.Name;
            var type = Type;
            switch (type) {
                case RouteStepType.Straight:
                    instruction = "Ga over " + FormattedDistance + " rechtdoor op de " + way;
                    break;
                case RouteStepType.CurveRight:
                    instruction = "Flauwe bocht naar rechts de " + way + " op over " + FormattedDistance;
                    break;
                case RouteStepType.Right:
                    instruction = "Sla over " + FormattedDistance + " rechtsaf de " + way + " op";
                    break;
                case RouteStepType.SharpRight:
                    instruction = "Scherpe bocht naar rechts de " + way + " op over " + FormattedDistance;
                    break;
                case RouteStepType.CurveLeft:
                    instruction = "Flauwe bocht naar links de " + way + " op over " + FormattedDistance;
                    break;
                case RouteStepType.Left:
                    instruction = "Sla over " + FormattedDistance + " linksaf de " + way + " op";
                    break;
                case RouteStepType.SharpLeft:
                    instruction = "Scherpe bocht naar links de " + way + " op over " + FormattedDistance;
                    break;
                case RouteStepType.DestinationReached:
                    instruction = "Bestemming bereikt!";
                    break;
                default:
                    instruction = "";
                    break;
            }
            Instruction = instruction;
        }

        public static string GetFormattedDistance(double tempDistance) => tempDistance < 1 ? tempDistance * 1000 + "m" : tempDistance + "km";


        public static RouteStepType CalcRouteStepType(double bearing) {
            RouteStepType type;

            if (bearing == 0 || bearing == 360 || bearing > 0 && bearing < 25 || bearing < 360 && bearing > 335)
                type = RouteStepType.Straight;
            else if (bearing >= 25 && bearing < 45)
                type = RouteStepType.CurveRight;
            else if (bearing > 45 && bearing <= 90)
                type = RouteStepType.Right;
            else if (bearing > 90 && bearing <= 180)
                type = RouteStepType.SharpRight;
            else if (bearing <= 335 && bearing > 315)
                type = RouteStepType.CurveLeft;
            else if (bearing < 315 && bearing >= 270)
                type = RouteStepType.Left;
            else if (bearing < 270 && bearing >= 180)
                type = RouteStepType.SharpLeft;
            else type = RouteStepType.Straight;

            return type;
        }

        /// <summary>
        /// Creates a routestep based on a given NavigationStep
        /// </summary>
        /// <param name="step">The NavigationStep with all the information</param>
        /// <param name="color">Background color for the panel</param>
        /// <param name="height">Height of the panel</param>
        public static Panel CreateRouteStepPanel(NavigationStep step, Color color, int height) {
            Image icon;

            switch (step.Type) {
                case RouteStepType.Straight:
                    icon = Resources.straight_icon;
                    break;
                case RouteStepType.CurveLeft:
                    icon = Resources.turn_curve_left_icon;
                    break;
                case RouteStepType.Left:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.SharpLeft:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.CurveRight:
                    icon = Resources.turn_curve_right_icon;
                    break;
                case RouteStepType.Right:
                    icon = Resources.turn_right_icon;
                    break;
                case RouteStepType.SharpRight:
                    icon = Resources.turn_right_icon;
                    break;
                case RouteStepType.DestinationReached:
                    icon = Resources.destination_icon;
                    break;
                default:
                    icon = Resources.straight_icon;
                    break;
            }

            //The panel which will be filled with all of the controls below
            Panel newPanel = new Panel {
                Location = new Point(0, height),
                Size = new Size(338, 50),
                BackColor = color
            };

            if (step.Distance != null) {
                Label distanceLabel = new Label {
                    Location = new Point(10, 0),
                    Size = new Size(50, 50),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DarkSlateGray,
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                    Text = step.FormattedDistance
                };
                newPanel.Controls.Add(distanceLabel);
            }

            Label instructionLabel = new Label {
                Location = new Point(60, 0),
                Size = new Size(210, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9),
                Text = step.Instruction
            };

            PictureBox instructionIcon = new PictureBox {
                Location = new Point(280, 10),
                Size = new Size(30, 30),
                Image = icon,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            newPanel.Controls.Add(instructionIcon);
            newPanel.Controls.Add(instructionLabel);
            return newPanel;
         }
    }
}