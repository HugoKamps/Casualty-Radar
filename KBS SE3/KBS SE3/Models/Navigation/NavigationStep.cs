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
        public string Distance { get; set; }

        public RouteStepType Type { get; set; }

        /// <summary>
        /// The instruction for the current step in the route
        /// </summary>
        public string Instruction { get; set; }

        public NavigationStep(string distance, RouteStepType type) {
            Distance = distance;
            Type = type;
            SetInstruction(type, distance);
        }

        private void SetInstruction(RouteStepType type, string dist) {
            string instruction;
            switch (type) {
                case RouteStepType.Straight:
                    instruction = "Ga over " + dist + " rechtdoor";
                    break;
                case RouteStepType.CurveRight:
                    instruction = "Flauwe bocht naar rechts over " + dist;
                    break;
                case RouteStepType.Right:
                    instruction = "Sla over " + dist + " rechtsaf";
                    break;
                case RouteStepType.SharpRight:
                    instruction = "Scherpe bocht naar rechts over " + dist;
                    break;
                case RouteStepType.CurveLeft:
                    instruction = "Flauwe bocht naar links over " + dist;
                    break;
                case RouteStepType.Left:
                    instruction = "Sla over " + dist + " linksaf";
                    break;
                case RouteStepType.SharpLeft:
                    instruction = "Scherpe bocht naar links over " + dist;
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
    }
}