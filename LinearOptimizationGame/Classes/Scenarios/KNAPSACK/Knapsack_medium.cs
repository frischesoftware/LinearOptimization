using LinearOptimizationGame.Classes.BasicClasses.KNAPSACK;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Classes.Scenarios.KNAPSACK
{
    public class Knapsack_medium
    {
        public List<KnapsackElement> listOfElements = new List<KnapsackElement>();
        static Random r = new Random();
        public List<String> spaceShipCargo = new List<String> 
                                    { 
                                        "Energypack", 
                                        "Energy_Amplifyer",
                                        "Radiation_Protection",
                                        "Food_Module",
                                        "Oxygen_Generator",
                                        "Terraforming_Toolbag",
                                        "Robot_Bay",
                                        "Space_Medicine",
                                        "Asteroid_Laser",
                                        "Wormhole_Radio",
                                        "Black_Hole_Detector"
                                    };

        public void Initialize()
        {
            int countElements = 3;
            for (int i = 0; i < countElements; i++)
            {
                int z = r.Next(spaceShipCargo.Count());
                string _randomname = spaceShipCargo[z];
                spaceShipCargo.RemoveAt(z);
                KnapsackElement _e = new KnapsackElement
                {                    
                    name =  _randomname,
                    domain = Domain.IntegerRange(0,32000),
                    weight = r.Next(1,6),
                    value = r.Next(2,8),
                    inventory = r.Next(3,9),
                    isAnswer = true,
                    isDecision = true
                };
                listOfElements.Add(_e);
            }
        }
    }
}