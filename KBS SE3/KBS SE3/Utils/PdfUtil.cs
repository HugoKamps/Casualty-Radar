using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Casualty_Radar.Models.Navigation;
using Casualty_Radar.Properties;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Casualty_Radar.Utils {
    class PdfUtil {
        public void CreatePdf(List<NavigationStep> steps, string start, string dest) {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Microsoft Sans Serif", 12);

            gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(236, 89, 71)),  0, 0, page.Width, 40);
            gfx.DrawImage(Resources.logo_final, new XPoint(10, 5));
            gfx.DrawString("Van " + start + " naar " + dest, font, XBrushes.White, new XPoint(0.6 * page.Width, 20), XStringFormats.Center);

            double x = 0.025 * page.Width;
            int y = 50;
            int id = 1;
            XBrush color = XBrushes.Gainsboro;
            font = new XFont("Microsoft Sans Serif", 8);

            foreach (NavigationStep step in steps) {
                if (y + 25 > page.Height) {
                    y = 50;
                    if (x >= 0.525 * page.Width) x = 0.525 * page.Width;
                    else {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        x = 0.025 * page.Width;
                    }
                }
                gfx.DrawRectangle(color, x, y, 0.45 * page.Width, 25);
                gfx.DrawString(id + " - " + step.Instruction, font, XBrushes.DarkSlateGray, new XPoint(x + 10, y + 15));
                //gfx.DrawImage(GetImageWithType(step.Type), new XPoint(0.8 * page.Width, y + 5));

                color = color == XBrushes.Gainsboro ? XBrushes.Silver : XBrushes.Gainsboro;
                y += 25;
                id++;
            }

            const string filename = "Route.pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        public XImage GetImageWithType(RouteStepType type) {
            XImage icon;
            switch (type)
            {
                case RouteStepType.Straight:
                    icon = Resources.straight_icon;
                    break;
                case RouteStepType.CurveLeft:
                    icon = Resources.turn_curve_left_icon;
                    break;
                case RouteStepType.Left:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.SharpLeft:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.CurveRight:
                    icon = Resources.turn_curve_right_icon;
                    break;
                case RouteStepType.Right:
                    icon = Resources.turn_right_icon;
                    break;
                case RouteStepType.SharpRight:
                    icon = Resources.turn_right_icon;
                    break;
                case RouteStepType.DestinationReached:
                    icon = Resources.destination_icon;
                    break;
                default:
                    icon = Resources.straight_icon;
                    break;
            }
            return icon;
        }
    }
}