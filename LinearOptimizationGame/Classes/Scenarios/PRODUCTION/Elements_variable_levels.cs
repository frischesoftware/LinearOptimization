using LinearOptimizationGame.Classes.BasicClasses;
using LinearOptimizationGame.Scenarios;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Classes.Scenarios
{
    public class Elements_variable_levels
    {
        Random r = new Random();
        public List<Element> listOfElements = new List<Element>();
        public List<Element> listOfElementsThirdLevel = new List<Element>();
        public List<Element> listOfElementsSecondLevel = new List<Element>();
        string namesOfElements = "abcdefghijklmnopqrstuvwxyz";
        public void Initialize()
        {
            int countElementsOnFirstLevel = 2;
            string namesOfElementsFirstLevel = namesOfElements.Substring(0, countElementsOnFirstLevel);
            int countElementOnSecondLevel = r.Next(4, 11); 
            string namesOfElementsSecondLevel = namesOfElements.Substring(0 + countElementsOnFirstLevel, countElementOnSecondLevel);
            int countElementsOnThirdLevel = 2;
            string namesOfElementsThirdLevel = namesOfElements.Substring(0 + countElementsOnFirstLevel + countElementOnSecondLevel, countElementsOnThirdLevel);
            // 3rd Level
            for (int i = 0; i < countElementsOnThirdLevel; i++)
            {
                Element _e = new Element
                {
                    name = (namesOfElementsThirdLevel.Substring(i, 1) + namesOfElementsThirdLevel.Substring(i, 1)).ToUpper(),   //EE, FF ...
                    domain = Domain.IntegerRange(0, 32000),
                    inventory = 0,
                    isAnswer = true,
                    isDecision = true,
                    usedIn = new Dictionary<Element, int>()
                };
                listOfElements.Add(_e);
                listOfElementsThirdLevel.Add(_e);
            }

            // 2nd Level - dynamisch

            for (int i = 0; i < countElementOnSecondLevel; i++)
            {
                Element _e = new Element()
                {
                    name = namesOfElementsSecondLevel.Substring(i, 1).ToUpper(),
                    domain = Domain.IntegerRange(0, 32000),
                    inventory = 0,
                    isAnswer = false,
                    isDecision = true,
                    usedIn = new Dictionary<Element,int>()
                };
              listOfElements.Add(_e);  // nur anfügen, wenn sie auch "usedins" (3 Zeilen weiter)
              listOfElementsSecondLevel.Add(_e);
            }

            foreach (var elem in listOfElementsSecondLevel)  // alle C,D...
            {
                // 1/3 für EE, 1/3 für FF, rest für beide
                //spreading over how many Thirdlevel Elements EE,FF...?
                int i = r.Next(0, listOfElementsThirdLevel.Count+1); // EE,FF,rest -> r.next(0, 2) => 0,1,3, 3=> alle
                if (i == listOfElementsThirdLevel.Count)
                {
                    foreach (var lvl3item in listOfElementsThirdLevel)
                    {
                        elem.usedIn.Add(lvl3item,5);
                    }
                    
                }
                else
                {
                    elem.usedIn.Add(listOfElementsThirdLevel[i], getRandomNumberHighOrLow()); //getRandomNumberHighOrLow()
                }
            }
            /*
            foreach (var item in listOfElementsThirdLevel)
            {
                int _usings;                
                if (0.3 > r.Next (0,countElementOnSecondLevel))
                {
                    
                }
                
                if (countElementOnSecondLevel <= 2)
                {
                    _usings = countElementOnSecondLevel;
                }
                else
                {
                    _usings = r.Next(2, Convert.ToInt32(Math.Round(countElementOnSecondLevel * 0.5)));
                }
                
                // wähle _using-Stück Elemente aus tier 2 aus  
                int numbers_needed = _usings;
                int numbers_left = listOfElementsSecondLevel.Count();               
                foreach (var ii in listOfElementsSecondLevel)
                {
                    if (r.Next(numbers_left) <= numbers_needed)  //https://stackoverflow.com/questions/48087/select-a-random-n-elements-from-listt-in-c-sharp
                    {
                        ii.usedIn.Add(item, getRandomNumberHighOrLow());
                    }
                }
            }
            */



            // FIRST LEVEL

            for (int i = 0; i < countElementsOnFirstLevel; i++)
            {
                Element _e = new Element()
                {
                    name = namesOfElementsFirstLevel.Substring(i, 1),
                    domain = Domain.IntegerRange(0, 32000),
                    inventory = (r.Next(900, 2000) + 50) / 100 * 100, // auf den Hunderter gerundet
                    isAnswer = false,
                    isDecision = false
                };
                Dictionary<Element, int> _usedIns = new Dictionary<Element, int>();
                foreach (var item in listOfElements)
                {
                    if (item.isAnswer == false && item.isDecision == true) // damit wird Ebene 2 ausgewählt -> besser?
                    {
                        _usedIns.Add(item, getRandomNumberHighOrLow());
                    }
                }
                _e.usedIn = _usedIns;
                listOfElements.Add(_e);
            }


            ElementCreationHelpers.determine_requires(listOfElements);
        }

        private int getRandomNumberHighOrLow()
        {
            bool hilo = r.Next(0, 2) == 0;
            if (hilo == true)
            { return r.Next(8, 11); }
            else
            {
                return r.Next(1, 3);
            }         
        }
    }
}