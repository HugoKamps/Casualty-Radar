using GMap.NET;

namespace KBS_SE3.Models.Graph {
    public class Node {
        public long ID { get; set; }
        public PointLatLng LatLng { get; set; }

        public Node(long id, PointLatLng latLng) {
            ID = id;
            LatLng = latLng;
        }
    }
}
