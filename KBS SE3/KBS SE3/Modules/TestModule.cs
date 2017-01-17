using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Core.Algorithms;
using Casualty_Radar.Models;
using Casualty_Radar.Models.DataControl;
using Casualty_Radar.Models.DataControl.Graph;
using GMap.NET;
using GMap.NET.MapProviders;

namespace Casualty_Radar.Modules {
    partial class TestModule : UserControl, IModule {
        private Random random;
        private DataParser parser;
        private DataCollection collection;
        private List<Node> targetCollection;
        private List<long> cRadarTimes;
        private List<long> gMapsTimes;

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

        /// <summary>
        /// This method starts a new test
        /// Various functions will be called which will generate random routes and run algorithms
        /// </summary>
        private void StartNewTest() {
            cRadarTimes = new List<long>();

            List<List<Node>> casualtyRadarLocations =
                CreateRandomRouteLocations(Convert.ToInt32(amountOfRoutesNumeric.Value));
            RunCasualtyRadarAlgorithm(casualtyRadarLocations);

            gMapsTimes = new List<long>();

            List<List<PointLatLng>> gMapsLocations = GeneratePointLatLngList(casualtyRadarLocations);
            RunGoogleMapsAlgorithm(gMapsLocations);

            CompareSingleRouteTimes();
            AppendAverageRouteTime();
        }

        /// <summary>
        /// Append text to the status textbox of the test
        /// </summary>
        /// <param name="text">The text that has to be appended</param>
        private void Log(string text) => testStatusBox.AppendText(text + Environment.NewLine);

        /// <summary>
        /// Creates a list with multiple lists which include two random nodes
        /// These two nodes will be the start and end nodes of a route
        /// </summary>
        /// <param name="amountOfRoutes">The amount of routes that has to be generated</param>
        /// <returns>A list with multiple lists which include two random nodes</returns>
        private List<List<Node>> CreateRandomRouteLocations(int amountOfRoutes) {
            Log("Start generating " + amountOfRoutes + " random route points");
            List<List<Node>> routeLocations = new List<List<Node>>();

            int addToStatusBar = 20 / amountOfRoutes;

            for (int i = 0; i < amountOfRoutes; i++) {
                List<Node> locations = new List<Node>();

                locations.Add(GetRandomNode());
                locations.Add(GetRandomNode());

                routeLocations.Add(locations);
                Log("Route point " + (i + 1) + " added");
                testStatusBar.Value += addToStatusBar;
            }

            Log(amountOfRoutes + " random route points generated");
            testStatusBar.Value = 20;
            return routeLocations;
        }

        /// <summary>
        /// Retrieves a random node with lat & lng variables from the parsed XML file
        /// </summary>
        /// <returns>A random node</returns>
        private Node GetRandomNode() {
            int randomInt = random.Next(0, collection.Intersections.Count);
            return collection.Nodes[randomInt];
        }

        /// <summary>
        /// This method converts the list which is created with CreateRandomRouteLocations
        /// All Node objects will become PointLatLng objects
        /// </summary>
        /// <param name="locations">This is the list which is created with CreateRandomRouteLocations</param>
        /// <returns></returns>
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

        /// <summary>
        /// This method calculates various amounts of routes based on the Casualty Radar algorithm
        /// A stopwatch captures the time which is used to calculate these routes
        /// </summary>
        /// <param name="locations">A list with lists which include two Node objects, the start and end points.</param>
        private void RunCasualtyRadarAlgorithm(List<List<Node>> locations) {
            Log("Running Casualty Radar Algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Pathfinder pf;

            int addToStatusBar = 40 / locations.Count;
            long previousWatchTime = watch.ElapsedMilliseconds;
            // Loop through the list of nodes and run the algorithm for each route
            foreach (List<Node> routePoints in locations) {
                pf = new Pathfinder(routePoints.First(), routePoints.Last());

                List<Node> path = pf.FindPath();

                // Add elapsed time of algorithm to list
                cRadarTimes.Add(watch.ElapsedMilliseconds - previousWatchTime);

                Log("Calculated route " + (locations.IndexOf(routePoints) + 1));
                testStatusBar.Value += addToStatusBar;
            }

            watch.Stop();
            Log("Finished running Casualty Radar Algorithm");
            testStatusBar.Value = 60;
            aOneTotalDurationLabel.Text = watch.ElapsedMilliseconds + " ms";
        }

        /// <summary>
        /// This method calculates various amounts of routes based on the Google Maps algorithm
        /// A stopwatch captures the time which is used to calculate these routes
        /// </summary>
        /// <param name="locations">A list with lists which include two PointLatLng variables, the start and end points.</param>
        private void RunGoogleMapsAlgorithm(List<List<PointLatLng>> locations) {
            Log("Running Google Maps Algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            uint totalDistance = 0;

            int addToStatusBar = 40 / locations.Count;
            long previousWatchTime = watch.ElapsedMilliseconds;
            // Loop through the list of points and run the algorithm for each route
            foreach (List<PointLatLng> routePoints in locations) {
                GDirections directions;
                var route = GMapProviders.GoogleMap.GetDirections(out directions, routePoints.First(),
                    routePoints.Last(), false, false, false, false, false);
                totalDistance += directions.DistanceValue;

                // Add elapsed time of algorithm to list
                gMapsTimes.Add(watch.ElapsedMilliseconds - previousWatchTime);

                Log("Calculated route " + (locations.IndexOf(routePoints) + 1));
                testStatusBar.Value += addToStatusBar;
            }

            watch.Stop();
            Log("Finished running Google Maps Algorithm");
            testStatusBar.Value = 100;
            aTwoTotalDurationLabel.Text = watch.ElapsedMilliseconds + " ms";
            aTwoTotalDistanceLabel.Text = (totalDistance / 1000) + "km";
        }

        private void AppendAverageRouteTime() {
            aOneAverageDurationLabel.Text = cRadarTimes.Average(item => item) + " ms";
            aTwoAverageDurationLabel.Text = gMapsTimes.Average(item => item) + " ms";
        }

        /// <summary>
        /// Compare the times for each route of both algorithms and determine which one is faster
        /// Add the amount of routes where the algorithm was faster than the other one to the label
        /// </summary>
        private void CompareSingleRouteTimes() {
            int cRadarCount = 0;
            int gMapsCount = 0;

            foreach (long time in cRadarTimes) {
                int index = cRadarTimes.IndexOf(time);
                if (time < gMapsTimes[index]) cRadarCount++;
                else if (gMapsTimes[index] < time) gMapsCount++;
            }

            aOneBestRoutesLabel.Text = cRadarCount.ToString();
            aTwoBestRoutesLabel.Text = gMapsCount.ToString();
        }

        /// <summary>
        /// Clears the controls which are used for displaying the test status and results
        /// </summary>
        private void ClearTests() {
            testStatusBox.Clear();
            testStatusBar.Value = 0;

            aOneAverageDurationLabel.Text = "-";
            aOneBestRoutesLabel.Text = "-";
            aOneTotalDistanceLabel.Text = "-";
            aOneTotalDurationLabel.Text = "-";

            aTwoAverageDurationLabel.Text = "-";
            aTwoBestRoutesLabel.Text = "-";
            aTwoTotalDistanceLabel.Text = "-";
            aTwoTotalDurationLabel.Text = "-";
        }

        private void clearPreviousTest_Click(object sender, EventArgs e) {
            ClearTests();
        }
    }
}