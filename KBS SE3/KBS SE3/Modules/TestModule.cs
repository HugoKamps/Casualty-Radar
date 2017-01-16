using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Core.Algorithms;
using Casualty_Radar.Models;
using Casualty_Radar.Models.DataControl;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Models.Navigation;
using Casualty_Radar.Utils;
using GMap.NET;
using GMap.NET.MapProviders;

namespace Casualty_Radar.Modules {
    partial class TestModule : UserControl, IModule {
        private Random random;
        private DataParser parser;
        private DataCollection collection;
        private List<Node> targetCollection;

        public TestModule() {
            InitializeComponent();
            random = new Random();
            parser = new DataParser(@"../../Resources/XML/nederland_snelwegen.xml");
            parser.Deserialize();
            collection = parser.GetCollection();
            targetCollection = collection.Intersections;
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Testomgeving", null,
                ModuleManager.GetInstance().ParseInstance(typeof(SettingsModule)));
        }

        private void startTestButton_Click(object sender, EventArgs e) {
            ClearTests();
            StartNewTest();
        }

        private void StartNewTest() {
            List<List<Node>> casualtyRadarLocations = CreateRandomRouteLocations(Convert.ToInt32(amountOfRoutesNumeric.Value));
            RunCasualtyRadarAlgorithm(casualtyRadarLocations);

            List<List<PointLatLng>> gMapsLocations = GeneratePointLatLngList(casualtyRadarLocations);
            RunGoogleMapsAlgorithm(gMapsLocations);
        }

        private void Log(string text) => testStatusBox.AppendText(text + Environment.NewLine);
        private void LogResult(string text) => testResultsBox.AppendText(text + Environment.NewLine);

        private List<List<Node>> CreateRandomRouteLocations(int amountOfRoutes)
        {
            Log("Start generating " + amountOfRoutes + " random route points");
            List<List<Node>> routeLocations = new List<List<Node>>();

            int addToStatusBar = 20 / amountOfRoutes;

            for (int i = 0; i < amountOfRoutes; i++)
            {
                List<Node> locations = new List<Node>();

                locations.Add(GetRandomNode());
                locations.Add(GetRandomNode());

                routeLocations.Add(locations);
                Log("Route point " + i + " added");
                testStatusBar.Value += addToStatusBar;
            }

            Log(amountOfRoutes + " random route points generated");
            testStatusBar.Value = 20;
            return routeLocations;
        }

        private Node GetRandomNode() {
            int randomInt = random.Next(0, collection.Nodes.Count);
            return collection.Nodes[randomInt];
        }

        private List<List<PointLatLng>> GeneratePointLatLngList(List<List<Node>> locations) {
            List<List<PointLatLng>> routeLocations = new List<List<PointLatLng>>();

            foreach (List<Node> nodes in locations) {
                List<PointLatLng> route = new List<PointLatLng>();

                PointLatLng start = new PointLatLng();
                start.Lat = nodes.First().Lat;
                start.Lng = nodes.First().Lon;

                PointLatLng end = new PointLatLng();
                end.Lat = nodes.Last().Lat;
                end.Lng = nodes.Last().Lon;

                route.Add(start);
                route.Add(end);
                routeLocations.Add(route);
            }
            
           return routeLocations;
        }

        private void RunCasualtyRadarAlgorithm(List<List<Node>> locations) {
            Log("Running Casualty Radar Algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Pathfinder pathfinder;
            Route route = new Route();

            int addToStatusBar = 40 / locations.Count;

            foreach (List<Node> routePoints  in locations)
            {
                Node startNode = routePoints.First();
                Node endNode = routePoints.Last();

                pathfinder = new Pathfinder(startNode, endNode);
                route.RouteNodes = pathfinder.FindPath();
                Log("Calculated route " + (locations.IndexOf(routePoints) + 1));
                testStatusBar.Value += addToStatusBar;
            }

            
            watch.Stop();
            Log("Finished running Casualty Radar Algorithm");
            testStatusBar.Value = 60;
            LogResult("Casualty Radar: " + watch.ElapsedMilliseconds + "ms");
        }

        private void RunGoogleMapsAlgorithm(List<List<PointLatLng>> locations) {
            Log("Running Google Maps Algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int addToStatusBar = 40 / locations.Count;

            foreach (List<PointLatLng> routePoints in locations)
            {
                GDirections directions;
                var route = GMapProviders.GoogleMap.GetDirections(out directions, routePoints.First(), routePoints.Last(), false, false, false, false, false);

                Log("Calculated route " + (locations.IndexOf(routePoints) + 1));
                testStatusBar.Value += addToStatusBar;
            }

            watch.Stop();
            Log("Finished running Google Maps Algorithm");
            testStatusBar.Value = 100;
            LogResult("Google Maps: " + watch.ElapsedMilliseconds + "ms");
        }

        private void ClearTests() {
            testStatusBox.Clear();
            testStatusBar.Value = 0;
            testResultsBox.Clear();
        }

        private void clearPreviousTest_Click(object sender, EventArgs e) {
            ClearTests();
        }
    }
}