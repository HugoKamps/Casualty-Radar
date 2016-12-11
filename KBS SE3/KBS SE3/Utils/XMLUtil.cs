using GMap.NET;
using KBS_SE3.Core;
using KBS_SE3.Modules;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace KBS_SE3.Utils {
    class XMLUtil {
        /*
        static List<Way> ways = new List<Way>();

        public static void read()
        {
            string xmlLoc = @"../../Resources/converted.osm";
            XDocument doc = XDocument.Load(xmlLoc);
            IEnumerable<XElement> elements = doc.Descendants("way");
            foreach (XElement element in elements)
            {
                Way way = new Way();
                way.ID = (long)element.FirstAttribute;
                IEnumerable<XElement> children = element.Descendants("nd");
                foreach (XElement child in children)
                {
                    long refId = (long)child.FirstAttribute;
                    XElement selectedElement = doc.Descendants().Where(x => (string)x.Attribute("id") == refId.ToString()).FirstOrDefault();
                    if (selectedElement != null)
                    {
                        double lat = double.Parse((selectedElement.Attribute("lat").Value).Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                        double lng = double.Parse((selectedElement.Attribute("lon").Value).Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);

                        PointLatLng latLng = new PointLatLng(lat, lng);
                        Node node = new Node(refId, latLng);
                        way.Nodes.Add(node);
                    }
                }
                IEnumerable<XElement> tags = element.Descendants("tag");
                foreach (XElement tag in tags)
                {
                    way.Name = tag.Attribute("name") != null ? tag.Attribute("name").Value : null;
                    way.OneWay = tag.Attribute("oneway") != null;
                }
                ways.Add(way);

                // Dummy data for draw route
                IList<PointLatLng> wayPoints = new List<PointLatLng>();
                foreach(Node n in way.Nodes)
                {
                    wayPoints.Add(n.LatLng);
                }
                var hm = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));
                //hm.GetLocationManager().DrawRoute(wayPoints);
            }
            */
    }
}
