using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Scenarios
{
    public static class DecisionsHelpers
    {
        public static void addDecisionsToModel(Problem p, Model model)
        {            
                foreach (var e in p.elements)
                {
                    Decision d = new Decision(e.domain, e.name);
                    e.decision = d;

                    if (e.isDecision == true)
                    {
                        p.model.AddDecision(d); // Achtung - auch "a" und "b" - decisions zum Model hinzufügen? ggf. isDecision checken                 
                    }             
            }
        }    

        internal static void addKnapsackDecisionsToModel(Problem _problem, Model model)
        {
            foreach (var item in _problem.knapsackElements)
            {
                item.decision = new Decision(item.domain, item.name);
                if (item.isDecision == true)
                {
                    _problem.model.AddDecision(item.decision);
                }                
            }
        }
    }
}