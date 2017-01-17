using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Utils;
using GMap.NET;

namespace Casualty_Radar.Models.Navigation {
    class Route {
        public List<Node> RouteNodes { get; set; } // All the nodes in the calculated route
        public List<NavigationStep> RouteSteps { get; set; } // All the calculated steps of the route
        public List<Panel> RouteStepPanels { get; set; } // All the generated panels for the route steps
        public string StartingRoad { get; set; } // The starting road for the route
        public string DestinationRoad { get; set; } // The destination road for the route
        public double TotalDistance { get; set; } // The total distance of the route
        public NavigationStep LastStep { get; set; }

        public Route() {
            RouteSteps = new List<NavigationStep>();
            RouteStepPanels = new List<Panel>();
        }


        /// <summary>
        /// Gets all latitude and longitude points of each node in the route
        /// </summary>
        /// <returns>A list with all the retrieved points</returns>
        public List<PointLatLng> GetRoutePoints() => RouteNodes.Select(node => node.GetPoint()).ToList();

        /// <summary>
        /// Calculates all the route steps and sets information about the route
        /// </summary>
        public void CalculateRouteSteps() {
            double prevAngle = -1;
            int height = 0;
            Color color = Color.Gainsboro;
            for (int index = 0; index < RouteNodes.Count; index++) {
                Node node = RouteNodes[index];
                if (index + 1 != RouteNodes.Count && index + 2 != RouteNodes.Count) {
                    Node nextNode = RouteNodes[index + 1];
                    Node nextNextNode = RouteNodes[index + 2];

                    if (index == 0)
                        StartingRoad = MapUtil.GetWay(RouteNodes[0], nextNode).Name;
                    // Set the starting road for the route

                    TotalDistance += MapUtil.GetDistance(node, nextNode);
                    // Add this step's distance to the total distance

                    // Check in which direction the step should point
                    double angle = RouteUtil.AngleFromCoordinate(nextNode, nextNextNode);
                    var type = prevAngle >= 0
                        ? NavigationStep.CalcRouteStepType(RouteUtil.CalcBearing(prevAngle, angle))
                        : RouteStepType.Straight;

                    // Get the distance for the step
                    double distance = Math.Round(MapUtil.GetDistance(node, nextNode), 2);
                    string distanceString =
                        NavigationStep.GetFormattedDistance(distance);

                    if (distance != 0) {

                        NavigationStep step = new NavigationStep(distance, type, MapUtil.GetWay(nextNode, nextNextNode));

                        if (LastStep != null) {
                            if (LastStep.Way.Name == step.Way.Name && step.Type == LastStep.Type) {
                                LastStep.Distance += step.Distance;
                            }
                            else {
                                RouteSteps.Add(step);
                                LastStep = step;
                            }

                            // Check if the route is finished
                            if (index + 3 == RouteNodes.Count) {
                                step = new NavigationStep(distance, RouteStepType.DestinationReached,
                                    MapUtil.GetWay(nextNode, nextNextNode));
                                DestinationRoad = MapUtil.GetWay(nextNode, nextNextNode).Name;
                                RouteSteps.Add(step);
                                LastStep = step;
                            }
                            prevAngle = angle;
                            RouteSteps[RouteSteps.Count - 1] = LastStep;
                        }
                        else {
                            RouteSteps.Add(step);
                            LastStep = step;
                            RouteSteps[RouteSteps.Count - 1] = LastStep;
                        }
                        LastStep.SetInstruction();
                    }
                }
                TotalDistance = Math.Round(TotalDistance, 2);
            }
            PrintPanels();
        }

        public void PrintPanels() {
            var route = RouteSteps;
            int height = 0;
            for(int i = 0; i < RouteSteps.Count; i++) {
                if(i != RouteSteps.Count - 2) {
                    RouteStepPanels.Add(NavigationStep.CreateRouteStepPanel(RouteSteps[i], Color.Gainsboro, height));
                    height += 51;

                }
            }
        }
    }
}