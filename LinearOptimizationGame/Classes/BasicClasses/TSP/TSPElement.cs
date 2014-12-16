using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Classes.BasicClasses.TSP
{

    public class TSPElement
    {
        public Domain domain { get; set; }
        public Decision decision { get; set; }

        public string name { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int cost { get; set; }

        public string group { get; set; } // group: A_B, A_C, A_D ... für constraint, damit man sagen kann A_* = 1 (genau einmal A anfahren)
    }
}