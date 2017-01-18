using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private Thread testingThread;

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
            testingThread = new Thread(StartNewTest);
            testingThread.Start();
        }

        /// <summary>
        /// This method starts a new test
        /// Various functions will be called which will generate random routes and run algorithms
        /// </summary>
        private void StartNewTest() {
            cRadarTimes = new List<long>();
            gMapsTimes = new List<long>();
            int amountOfRoutes = Convert.ToInt32(amountOfRoutesNumeric.Value);

            List<List<PointLatLng>> locations =
                CreateRandomRouteLocations(amountOfRoutes);

            long cRadarDuration = RunCasualtyRadarAlgorithm(locations);
            long gMapDuration = RunGoogleMapsAlgorithm(locations);

            CompareSingleRouteTimes();
            AppendAverageRouteTime(amountOfRoutes, cRadarDuration, gMapDuration);
        }

        /// <summary>
        /// Append text to the status textbox of the test
        /// </summary>
        /// <param name="text">The text that has to be appended</param>
        private void Log(string text) {
            this.Invoke((MethodInvoker)delegate {
                testStatusBox.AppendText(text + Environment.NewLine);
            });
        }

        /// <summary>
        /// Creates a list with multiple lists which include two random nodes
        /// These two nodes will be the start and end nodes of a route
        /// </summary>
        /// <param name="amountOfRoutes">The amount of routes that has to be generated</param>
        /// <returns>A list with multiple lists which include two random nodes</returns>
        private List<List<PointLatLng>> CreateRandomRouteLocations(int amountOfRoutes) {
            Log("Start generating " + amountOfRoutes + " random route points");
            List<List<PointLatLng>> routeLocations = new List<List<PointLatLng>>();

            int addToStatusBar = 20 / amountOfRoutes;

            for (int i = 0; i < amountOfRoutes; i++) {
                List<PointLatLng> locations = new List<PointLatLng>();

                Node start = GetRandomNode();
                Node end = GetRandomNode();

                PointLatLng startPoint = new PointLatLng();
                PointLatLng endPoint = new PointLatLng();
                startPoint.Lat = start.Lat;
                startPoint.Lng = start.Lon;
                endPoint.Lat = end.Lat;
                endPoint.Lng = end.Lon;

                locations.Add(startPoint);
                locations.Add(endPoint);

                routeLocations.Add(locations);
                Log("Route point " + (i + 1) + " added");

                this.Invoke((MethodInvoker)delegate {
                    testStatusBar.Value += addToStatusBar;
                });
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
        /// This method calculates various amounts of routes based on the Casualty Radar algorithm
        /// A stopwatch captures the time which is used to calculate these routes
        /// </summary>
        /// <param name="locations">A list with lists which include two Node objects, the start and end points.</param>
        private long RunCasualtyRadarAlgorithm(List<List<PointLatLng>> locations) {
            Log("Running Casualty Radar Algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var nM = (NavigationModule)ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule));
            int addToStatusBar = 40 / locations.Count;
            long previousWatchTime = 0;
            // Loop through the list of nodes and run the algorithm for each route
            foreach (List<PointLatLng> routePoints in locations) {
                Log("Calculating route " + (locations.IndexOf(routePoints) + 1));
                nM.ParseRoute(collection, routePoints.First(), routePoints.Last());

                // Add elapsed time of algorithm to list
                cRadarTimes.Add(watch.ElapsedMilliseconds - previousWatchTime);
                Log("Calculated route " + (locations.IndexOf(routePoints) + 1));
                testStatusBar.Value += addToStatusBar;
                this.Invoke((MethodInvoker)delegate {
                    testStatusBar.Value += addToStatusBar;
                });
            }
            watch.Stop();
            Log("Finished running Casualty Radar Algorithm");
            this.Invoke((MethodInvoker)delegate {
                testStatusBar.Value = 60;
                aOneTotalDurationLabel.Text = watch.ElapsedMilliseconds + " ms";
            });

            return watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// This method calculates various amounts of routes based on the Google Maps algorithm
        /// A stopwatch captures the time which is used to calculate these routes
        /// </summary>
        /// <param name="locations">A list with lists which include two PointLatLng variables, the start and end points.</param>
        private long RunGoogleMapsAlgorithm(List<List<PointLatLng>> locations) {
            Log("Running Google Maps Algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            uint totalDistance = 0;

            int addToStatusBar = 40 / locations.Count;
            long previousWatchTime = watch.ElapsedMilliseconds;
            // Loop through the list of points and run the algorithm for each route
            foreach (List<PointLatLng> routePoints in locations) {
                Log("Calculating route " + (locations.IndexOf(routePoints) + 1));
                GDirections directions;
                GMapProviders.GoogleMap.GetDirections(out directions, routePoints.First(), routePoints.Last(), false, false, false, false, false);
                totalDistance += directions.DistanceValue;

                // Add elapsed time of algorithm to list
                gMapsTimes.Add(watch.ElapsedMilliseconds - previousWatchTime);

                this.Invoke((MethodInvoker)delegate {
                    testStatusBar.Value += addToStatusBar;
                });
            }

            watch.Stop();
            Log("Finished running Google Maps Algorithm");
            this.Invoke((MethodInvoker)delegate {
                testStatusBar.Value = 100;
                aTwoTotalDurationLabel.Text = watch.ElapsedMilliseconds + " ms";
                aTwoTotalDistanceLabel.Text = (totalDistance / 1000) + "km";
            });
            return watch.ElapsedMilliseconds;
        }

        private void AppendAverageRouteTime(int amountOfRoutes, long cRadarDuration, long gMapDuration) {
            this.Invoke((MethodInvoker)delegate {
                aOneAverageDurationLabel.Text = cRadarDuration / amountOfRoutes + " ms";
                aTwoAverageDurationLabel.Text = gMapDuration / amountOfRoutes + " ms";
            });
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

            this.Invoke((MethodInvoker)delegate {
                aOneBestRoutesLabel.Text = cRadarCount.ToString();
                aTwoBestRoutesLabel.Text = gMapsCount.ToString();
            });
        }

        /// <summary>
        /// Clears the controls which are used for displaying the test status and results
        /// </summary>
        private void ClearTests() {
            // Stop the current test if one is running
            if (testingThread != null)
                testingThread.Abort();

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