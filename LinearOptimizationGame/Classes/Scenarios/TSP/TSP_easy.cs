using LinearOptimizationGame.Classes.BasicClasses.TSP;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Classes.Scenarios.TSP
{
    public class TSP_easy
    {
        public List<TSPElement> listOfElements = new List<TSPElement>();
        public void Initialize()
        {

            listOfElements.Add(new TSPElement() { name = "A_B", domain = Domain.IntegerRange(0, 1), from = "A", to = "B", cost = 3, group = "A" });
            listOfElements.Add(new TSPElement() { name = "A_C", domain = Domain.IntegerRange(0, 1), from = "A", to = "C", cost = 7, group = "A" });
            listOfElements.Add(new TSPElement() { name = "A_D", domain = Domain.IntegerRange(0, 1), from = "A", to = "D", cost = 11, group = "A" });
            listOfElements.Add(new TSPElement() { name = "A_E", domain = Domain.IntegerRange(0, 1), from = "A", to = "E", cost = 9, group = "A" });

            listOfElements.Add(new TSPElement() { name = "B_C", domain = Domain.IntegerRange(0, 1), from = "B", to = "C", cost = 5, group = "B" });
            listOfElements.Add(new TSPElement() { name = "B_D", domain = Domain.IntegerRange(0, 1), from = "B", to = "D", cost = 10, group = "B" });
            listOfElements.Add(new TSPElement() { name = "B_E", domain = Domain.IntegerRange(0, 1), from = "B", to = "E", cost = 9, group = "B" });

            listOfElements.Add(new TSPElement() { name = "C_D", domain = Domain.IntegerRange(0, 1), from = "C", to = "D", cost = 7, group = "C" });
            listOfElements.Add(new TSPElement() { name = "C_E", domain = Domain.IntegerRange(0, 1), from = "C", to = "E", cost = 8, group = "C" });

            listOfElements.Add(new TSPElement() { name = "D_E", domain = Domain.IntegerRange(0, 1), from = "D", to = "E", cost = 2, group = "D" });

        }
    }
}