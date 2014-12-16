using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Classes.BasicClasses.KNAPSACK
{
    public class KnapsackElement
    {
        public string name { get; set; }
        
        public Domain domain { get; set; }
        public Decision decision { get; set; }

        // input for the user?
        public bool isAnswer { get; set; }
        // a decision variable?
        public bool isDecision { get; set; }

        public int weight { get; set; }
        public int value { get; set; }
        public int inventory { get; set; }  // soviele haben wir auf Lager

        public int userAnswer { get; set; }

    }
}