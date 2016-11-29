namespace KBS_SE3.Models.Navigation {
    public enum RouteStepType {
        Left,
        Right,
        Straight
    }

    class NavigationStep {
        public string Instruction { get; set; }
        public string Distance { get; set; }
        public RouteStepType Type { get; set; }

        public NavigationStep(string instruction, string distance, RouteStepType type) {
            Instruction = instruction;
            Distance = distance;
            Type = type;
        }
    }
}
