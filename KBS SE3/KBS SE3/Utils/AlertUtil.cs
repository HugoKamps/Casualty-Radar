using KBS_SE3.Models;

namespace KBS_SE3.Utils
{
    static class AlertUtil
    {
        public static string[,] P2000 = new string[,] { 
            { "A1", "1", "Ambulance", "Hoogste Prioriteit" },
            { "A2", "1", "Ambulance", "Normale Prioriteit" },
            { "B", "1", "Ambulance", "Besteld vervoer" },
            { "P 1", "2", "Brandweer", "Spoed rit" },
            { "P 2", "2", "Brandweer", "Gepaste spoed rit" },
            { "P 3", "2", "Brandweer", "Geen spoed" },
            { "P 4", "2", "Brandweer", "Testmelding" },
            { "P 5", "2", "Brandweer", "Testmelding" },
            { "PRIO 1", "2", "Brandweer", "Spoed rit" },
            { "PRIO 2", "2", "Brandweer", "Gepaste spoed rit" },
            { "PRIO 3", "2", "Brandweer", "Geen spoed" },
            { "PRIO 4", "2", "Brandweer", "Testmelding" },
            { "PRIO 5", "2", "Brandweer", "Testmelding" },
            { "PR 1", "2", "Brandweer", "Spoed rit" },
            { "PR 2", "2", "Brandweer", "Gepaste spoed rit" },
            { "PR 3", "2", "Brandweer", "Geen spoed" },
            { "PR 4", "2", "Brandweer", "Testmelding" },
            { "PR 5", "2", "Brandweer", "Testmelding" },
            { "BR", "2", "Brandweer", "Brand" },
            { "HV", "2", "Brandweer", "Hulpverlening" },
            { "VKO", "2", "Brandweer", "Verkeersongeval" },
            { "WO", "2", "Brandweer", "Waterongeval" },
            { "DV", "2", "Brandweer", "Dienstverlening" }
        };

        public static Alert SetAlertAttributes(Alert alert, string alertItemString)
        {
            for (int i = 0; i < P2000.GetLength(0); i++) {
                if (alertItemString.StartsWith(P2000[i, 0])) {
                    alert.Code = P2000[i, 0];
                    alert.Type = int.Parse(P2000[i, 1]);
                    alert.TypeString = P2000[i, 2];
                    alert.Info = P2000[i, 3];
                    return alert;
                }
            }
            return null;
        }
    }
}
