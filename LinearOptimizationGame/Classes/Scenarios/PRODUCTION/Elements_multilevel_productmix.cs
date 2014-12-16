using LinearOptimizationGame.Classes.BasicClasses;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Scenarios
{
    public class Elements_multilevel_productmix
    {
         public List<Element> listOfElements= new List<Element>();
         public void Initialize()
         {

             // Top Level
             Element EE = new Element { name = "EE", domain = Domain.IntegerRange(0,32000), inventory = 0, isAnswer = true, isDecision = true,
             svg_color = "red",
             svg_shape = "rect"
             };

             Element FF = new Element { name = "FF", domain = Domain.IntegerRange(0,32000), inventory = 0, isAnswer = true, isDecision = true,
             svg_color = "brown",
             svg_shape = "rect"
             };

             // 2nd Level
             Element C = new Element
             {
                 name = "C",
                 domain = Domain.IntegerRange(0, 32000),
                 inventory = 0,
                 isAnswer = false,
                 isDecision = true,                 
                 usedIn = new Dictionary<Element, int>() { { EE, 2 }, { FF, 1 } },
                 svg_color = "yellow",
                 svg_shape = "rect"
             };
             Element D = new Element
             {
                 name = "D",
                 domain = Domain.IntegerRange(0, 32000),
                 inventory = 0,
                 isAnswer = false,
                 isDecision = true,
                 usedIn = new Dictionary<Element, int>() { { EE, 1 }, { FF, 2 } },
                 svg_color = "pink",
                 svg_shape = "ellipse"
             };

             // 3rd Level
             Element a = new Element
             {
                 name = "a",
                 domain = Domain.IntegerRange(0, 32000),
                 inventory = 100,
                 isAnswer = false,
                 isDecision = false,
                 usedIn = new Dictionary<Element, int>() { { C, 6 }, { D, 4 } },
                 svg_color = "green",
                 svg_shape = "ellipse"
             };
             Element b = new Element
             {
                 name = "b",
                 domain = Domain.IntegerRange(0,32000),
                 inventory = 200,
                 isAnswer = false,
                 isDecision = false,
                 usedIn = new Dictionary<Element, int>() { { C, 1 }, { D, 2 } },
                 svg_color = "blue",
                 svg_shape = "rect"
             };

             listOfElements.Add(a);
             listOfElements.Add(b);
             listOfElements.Add(C);
             listOfElements.Add(D);
             listOfElements.Add(EE);
             listOfElements.Add(FF);
             ElementCreationHelpers.determine_requires(listOfElements);
         }
    }
}