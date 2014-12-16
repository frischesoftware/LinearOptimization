using LinearOptimizationGame.Classes.BasicClasses;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Scenarios
{
    public class Elements_easy
    {
        public List<Element> listOfElements= new List<Element>();
        public void Initialize()
        {            
            //Top Level
            Element C = new Element { name = "Product", domain = Domain.IntegerRange(0, 32000), inventory = 0, isAnswer = true, isDecision = true, 
                svg_color = "yellow", 
                svg_shape = "rect"
            };

            // 2nd Level / Primitves
            Element a = new Element { 
                name = "Part_A", domain = Domain.IntegerRange(0, 32000), inventory = 100, isAnswer = false, isDecision = false, 
                usedIn = new Dictionary<Element,int>() { { C, 6 }},
                svg_color = "green", 
                svg_shape = "ellipse"
            };
            Element b = new Element { 
                name = "Part_B", domain = Domain.IntegerRange(0, 32000), inventory = 200, isAnswer = false, isDecision = false, 
                usedIn = new Dictionary<Element, int>() { { C, 1 }},
                svg_color = "blue",
                svg_shape = "rect"
            };

            listOfElements.Add(a);
            listOfElements.Add(b);
            listOfElements.Add(C);
            ElementCreationHelpers.determine_requires(listOfElements);
        }
       
    }
}








//    // models
//    Element a = new Element { name = "a", domain = Domain.IntegerNonnegative, inventory = 100, isAnswer = false, isDecision = false };
//    Element b = new Element { name = "b", domain = Domain.IntegerNonnegative, inventory = 200, isAnswer = false, isDecision = false };
//    Element C = new Element { name = "C", domain = Domain.IntegerNonnegative, inventory = 0, isAnswer = true, isDecision = true };
//    Element D = new Element { name = "D", domain = Domain.IntegerNonnegative, inventory = 0, isAnswer = true, isDecision = true };
