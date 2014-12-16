using LinearOptimizationGame.Classes.BasicClasses.KNAPSACK;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Classes.Scenarios.KNAPSACK
{
    public class Knapsack_easy
    {
        public List<KnapsackElement> listOfElements = new List<KnapsackElement>();
        public void Initialize()
        {
            KnapsackElement k1 = new KnapsackElement()
            {
                name = "Part_A",
                domain = Domain.IntegerRange(0, 32000),
                weight = 3,
                value = 2,
                inventory = 5,
                isAnswer = true, 
                isDecision = true
            };
            KnapsackElement k2 = new KnapsackElement()
            {
                name = "Part_B",
                domain = Domain.IntegerRange(0, 32000),
                weight = 2,
                value = 3,
                inventory = 2,
                isAnswer = true,
                isDecision = true
            };
            listOfElements.Add(k1);
            listOfElements.Add(k2);
        }
    }
}