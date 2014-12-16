using LinearOptimizationGame.Classes.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Scenarios
{
    public static class ElementCreationHelpers
    {
        public static void determine_requires(List<Element> e)
        {
            foreach (var eachElement in e)  // für jedes Element
            {
                Dictionary<Element, int> req = new Dictionary<Element, int>();
                foreach (var i in e)
                {
                    if (i.usedIn != null)  // wenn das element kein usedIn hat, wirds auch von nichts required
                    {
                        foreach (var u in i.usedIn)  // alle usedIns prüfen...
                        {
                            if (u.Key.name == eachElement.name) // ob diese
                            {
                                req.Add(i, u.Value);
                            }
                        }
                    }
                }
                eachElement.requires = req;
            }
        }
    }
}