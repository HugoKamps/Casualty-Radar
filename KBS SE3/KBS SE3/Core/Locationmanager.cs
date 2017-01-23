using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Casualty_Radar.Models.DataControl.Graph.Ways;
using Casualty_Radar.Properties;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Casualty_Radar.Core {
    /// <summary>
    /// Class that contains functionality which can be used on a GMAP.net control
    /// </summary>
    public class LocationManager {
        public double CurrentLatitude { get; set; } //The user's current latitude
        public double CurrentLongitude { get; set; } //The user's current longitude
        public List<Way> Ways = new List<Way>();

        /// <summary>
        /// Function that gets the coordinates of the user's default location (in settings) and changes the local lat and lng variables
        /// </summary>
        public void SetCoordinatesByLocationSetting() {
            string location = Settings.Default.userLocation + ", The Netherlands";
            string requestUri =
                $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(location)}&sensor=false";

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            if (result != null) {
                XElement locationElement = result.Element("geometry").Element("location");
                string lat = Regex.Replace(locationElement.Element("lat").ToString(), "<.*?>", string.Empty);
                string lng = Regex.Replace(locationElement.Element("lng").ToString(), "<.*?>", string.Empty);
                CurrentLatitude = double.Parse(lat.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                CurrentLongitude = double.Parse(lng.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Instantiates a marker that will be placed on a given location. The color can vary based on the type.
        /// Every marker gets a tooltip which contains the distance from the user's current location to the marker's location
        /// </summary>
        /// <param name="lat">The latitude of the marker's location</param>
        /// <param name="lng">The longitude of the marker's location</param>
        /// <param name="type">The type which indicates what kind of marker it is. 
        /// <para>0 = Current location</para> 
        /// <para>1 = Ambulance</para>
        /// <para>2 = Firefighter</para>
        /// <para>3 = Selected marker</para>
        /// <para>4 = Destination marker</para>
        /// </param>
        /// <returns>The created marker</returns>
        public GMarkerGoogle CreateMarker(double lat, double lng, int type) {
            string imgLocation = "../../Resources../Icons/Markers/marker_icon_";
            if (type == 0) imgLocation += "blue.png";
            if (type == 1) imgLocation += "yellow.png";
            if (type == 2) imgLocation += "red.png";
            if (type == 3) imgLocation += "selected.png";
            if (type == 4) imgLocation += "destination.png";

            Image image = new Bitmap(imgLocation);
            return new GMarkerGoogle(new PointLatLng(lat, lng), new Bitmap(image, 30, 30));
        }

        /// <summary>
        /// Creates a PointLatLng variable based on the user's current latitude and longitude
        /// </summary>
        /// <returns>The created PointLatLng variable</returns>
        public PointLatLng GetLocationPoint() => new PointLatLng(CurrentLatitude, CurrentLongitude);

        /// <summary>
        /// Function which draws a path on a GMap overlay based on a given list of PointLatLng variables
        /// </summary>
        /// <param name="points">The list with points for the path</param>
        /// <param name="routeOverlay">The overlay which must be drawn on</param>
        /// <param name="color">The color of the route</param>
        public void DrawRoute(List<PointLatLng> points, GMapOverlay routeOverlay, Color color) {
            routeOverlay.Routes.Add(new GMapRoute(points, "MyRoute") {
                Stroke = {
                    DashStyle = DashStyle.Solid,
                    Color = color
                }
            });
        }
    }
}