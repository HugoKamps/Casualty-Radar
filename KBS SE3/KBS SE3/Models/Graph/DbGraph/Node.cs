namespace KBS_SE3.Models.Graph {
    public class Node {
        private int _id;
        private double _lat;
        private double _lon;

        public Node(int id, double lat, double lon) {
            _id = id;
            _lat = lat;
            _lon = lon;
        }
    }
}
