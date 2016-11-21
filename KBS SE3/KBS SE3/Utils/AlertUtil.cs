using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Utils
{
    static class AlertUtil
    {
        public static string[,] P2000 = new string[,] { 
            { "A1", "Ambulance", "Hoogste Prioriteit" },
            { "A2", "Ambulance", "Normale Prioriteit" },
            { "B", "Ambulance", "Besteld vervoer" },
            { "P 1", "Brandweer", "Spoed rit" },
            { "P 2", "Brandweer", "Gepaste spoed rit" },
            { "P 3", "Brandweer", "Geen spoed" },
            { "P 4", "Brandweer", "Testmelding" },
            { "P 5", "Brandweer", "Testmelding" },
            { "PRIO 1", "Brandweer", "Spoed rit" },
            { "PRIO 2", "Brandweer", "Gepaste spoed rit" },
            { "PRIO 3", "Brandweer", "Geen spoed" },
            { "PRIO 4", "Brandweer", "Testmelding" },
            { "PRIO 5", "Brandweer", "Testmelding" },
            { "PR 1", "Brandweer", "Spoed rit" },
            { "PR 2", "Brandweer", "Gepaste spoed rit" },
            { "PR 3", "Brandweer", "Geen spoed" },
            { "PR 4", "Brandweer", "Testmelding" },
            { "PR 5", "Brandweer", "Testmelding" },
            { "BR", "Brandweer", "Brand" },
            { "HV", "Brandweer", "Hulpverlening" },
            { "VKO", "Brandweer", "Verkeersongeval" },
            { "WO", "Brandweer", "Waterongeval" },
            { "DV", "Brandweer", "Dienstverlening" }
        };
    }
}
