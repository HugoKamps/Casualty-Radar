using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Core.Dialog;
using Casualty_Radar.Models;
using Casualty_Radar.Models.Navigation;
using Casualty_Radar.Utils;
using GMap.NET;
using GMap.NET.MapProviders;

namespace Casualty_Radar.Modules {
    /// <summary>
    /// Module to create random routes and compare that same route with our algoritm and googles algoritm
    /// </summary>
    partial class TestModule : UserControl, IModule {
        private Random _random;
        private List<long> _cRadarTimes;
        private List<long> _gMapsTimes;
        private Thread _testingThread;
        private NavigationModule _nM;

        public TestModule() {
            InitializeComponent();
            _random = new Random();
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Testomgeving", null,
                ModuleManager.GetInstance().ParseInstance(typeof(SettingsModule)));
        }

        private void startTestButton_Click(object sender, EventArgs e) {
            if (_nM == null)
                _nM = (NavigationModule)ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule));
            ClearTests();
            _testingThread = new Thread(StartNewTest);
            _testingThread.Start();
        }

        /// <summary>
        /// This method starts a new test
        /// Various functions will be called which will generate random routes and run algorithms
        /// </summary>
        private void StartNewTest() {
            _cRadarTimes = new List<long>();
            _gMapsTimes = new List<long>();
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
            Invoke((MethodInvoker)delegate {
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

                PointLatLng startPoint = GetRandomPoint();
                PointLatLng endPoint = GetRandomPoint();

                locations.Add(startPoint);
                locations.Add(endPoint);

                routeLocations.Add(locations);
                Log("Route point " + (i + 1) + " added");

                Invoke((MethodInvoker)delegate {
                    testStatusBar.Value += addToStatusBar;
                });
            }

            Log(amountOfRoutes + " random route points generated");
            Invoke((MethodInvoker)delegate {
                testStatusBar.Value = 20;
            });
            return routeLocations;
        }

        /// <summary>
        /// Retrieves a random point with lat & lng variables from the parsed XML file
        /// </summary>
        /// <returns>A random point</returns>
        private PointLatLng GetRandomPoint() {
            PointLatLng randomPoint = new PointLatLng();
            GeoMapSection section = GetRandomSection();

            randomPoint.Lat = _random.NextDouble() * (section.UpperBound.Lat - section.LowerBound.Lat) + section.LowerBound.Lat;
            randomPoint.Lng = _random.NextDouble() * (section.UpperBound.Lng - section.LowerBound.Lng) + section.LowerBound.Lng;

            return randomPoint;
        }

        /// <summary>
        /// Retrieves sections from the GeoMapLoader class and selects a random section
        /// </summary>
        /// <returns>Returns a random section</returns>
        private GeoMapSection GetRandomSection() {
            List<GeoMapSection> sections = _nM.GetGeoMapLoader().GetGeoMapSections();
            int randomInt = _random.Next(0, sections.Count - 1);
            return sections[randomInt];
        }

        /// <summary>
        /// This method calculates various amounts of routes based on the Casualty Radar algorithm
        /// A stopwatch captures the time which is used to calculate these routes
        /// </summary>
        /// <param name="locations">A list with lists which include two Node objects, the start and end points.</param>
        private long RunCasualtyRadarAlgorithm(List<List<PointLatLng>> locations) {
            Log("Running Casualty Radar Algorithm...");
            var watch = Stopwatch.StartNew();
            int addToStatusBar = 40 / locations.Count;
            long previousWatchTime = 0;

            List<PointLatLng> points = new List<PointLatLng>();
            // Loop through the list of nodes and run the algorithm for each route
            foreach (List<PointLatLng> routePoints in locations) {
                Log("Calculating route " + (locations.IndexOf(routePoints) + 1) + "...");
                points.AddRange(_nM.ParseRoutes(routePoints.First(), routePoints.Last(), new Route()));

                // Add elapsed time of algorithm to list
                _cRadarTimes.Add(watch.ElapsedMilliseconds - previousWatchTime);
                Invoke(new Action(() => testStatusBar.Value += addToStatusBar));
            }
            watch.Stop();
            Log("Finished running Casualty Radar Algorithm");
            Invoke((MethodInvoker)delegate {
                testStatusBar.Value = 60;
                aOneTotalDurationLabel.Text = watch.ElapsedMilliseconds + " ms";
                aOneTotalDistanceLabel.Text = Math.Round(MapUtil.GetTotalDistance(points), 2) + "km";
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
            var watch = Stopwatch.StartNew();
            uint totalDistance = 0;

            int addToStatusBar = 40 / locations.Count;
            long previousWatchTime = watch.ElapsedMilliseconds;
            // Loop through the list of points and run the algorithm for each route
            foreach (List<PointLatLng> routePoints in locations) {
                Log("Calculating route " + (locations.IndexOf(routePoints) + 1) + "...");
                try {
                    GDirections directions;
                    GMapProviders.GoogleMap.GetDirections(out directions, routePoints.First(), routePoints.Last(), false,
                        false, false, false, false);
                    totalDistance += directions.DistanceValue;
                }
                catch (NullReferenceException) {
                    Invoke((MethodInvoker)delegate {
                        Casualty_Radar.Container.GetInstance().DisplayDialog(DialogType.DialogMessageType.ERROR, "GMaps Query Limit", "Het aantal op te vragen routes bij Google Maps is overschreden.");
                    });
                }

                // Add elapsed time of algorithm to list
                _gMapsTimes.Add(watch.ElapsedMilliseconds - previousWatchTime);

                Invoke(new Action(() => testStatusBar.Value += addToStatusBar));
            }

            watch.Stop();
            Log("Finished running Google Maps Algorithm");
            Invoke((MethodInvoker)delegate {
                testStatusBar.Value = 100;
                aTwoTotalDurationLabel.Text = watch.ElapsedMilliseconds + " ms";
                aTwoTotalDistanceLabel.Text = (totalDistance / 1000) + "km";
            });
            return watch.ElapsedMilliseconds;
        }

        private void AppendAverageRouteTime(int amountOfRoutes, long cRadarDuration, long gMapDuration) {
            Invoke((MethodInvoker)delegate {
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

            foreach (long time in _cRadarTimes) {
                int index = _cRadarTimes.IndexOf(time);
                if (time < _gMapsTimes[index]) cRadarCount++;
                else if (_gMapsTimes[index] < time) gMapsCount++;
            }

            Invoke((MethodInvoker)delegate {
                aOneBestRoutesLabel.Text = cRadarCount.ToString();
                aTwoBestRoutesLabel.Text = gMapsCount.ToString();
            });
        }

        /// <summary>
        /// Clears the controls which are used for displaying the test status and results
        /// </summary>
        private void ClearTests() {
            // Stop the current test if one is running
            if (_testingThread != null)
                _testingThread.Abort();

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