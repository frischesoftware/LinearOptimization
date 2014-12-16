using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Helpers
{
    public class GoalHelpers
    {

        public Term buildGoal(Problem p)
        {
            Term g1 = 0;
            foreach (var item in p.elements)
            {
                if (item.isDecision == true && item.isAnswer == true)
                {
                    g1 += item.decision;
                }
            }
            return g1;
        }

        internal Term buildKnapsackGoal(Problem _problem)
        {
            return _problem.knapsackElements[0].decision * _problem.knapsackElements[0].value + _problem.knapsackElements[1].decision * _problem.knapsackElements[1].value;
        }

        internal Term buildTSPGoal(Problem _problem)
        {
            Term g1 = 0;
            foreach (var item in _problem.connections)
            {
                g1 += item.cost * item.decision;
            }
            return g1;
        }
    }
}