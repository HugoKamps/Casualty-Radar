namespace Casualty_Radar.Models.Navigation {

    /// <summary>
    /// Indicates what the user needs to do for the current step
    /// </summary>
    public enum RouteStepType {
        Left,
        Right,
        Straight
    }

    /// <summary>
    /// Model class for a navigation step in a route
    /// </summary>
    class NavigationStep {
        /// <summary>
        /// The instruction for the current step in the route
        /// </summary>
        public string Instruction { get; set; }
        /// <summary>
        /// Indicates how long it takes until the next step
        /// </summary>
        public string Distance { get; set; }
        public RouteStepType Type { get; set; }

        public NavigationStep(string instruction, string distance, RouteStepType type) {
            Instruction = instruction;
            Distance = distance;
            Type = type;
        }
    }
}
