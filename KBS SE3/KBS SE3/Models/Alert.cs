using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models
{
    class Alert {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PubDate { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public Alert(string title, string description, DateTimeOffset pubDate, double lat, double lng){
            Title = title;
            Description = description;
            PubDate = pubDate;
            Lat = lat;
            Lng = lng;
        }

        public override string ToString(){
            string returnString = "Alert: \n" + Title + "\n" + Description + "\n" + PubDate + "\n" + Lat + "\n" + Lng + "\n";
            return returnString;
        }
    }
}
