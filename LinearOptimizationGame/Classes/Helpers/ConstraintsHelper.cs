using LinearOptimizationGame.Classes.BasicClasses;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Scenarios
{
    public static class ConstraintsHelper
    {
        public static void buildConstraints(Problem p, Model model)
        {
            foreach (var item in p.elements)
            {
                if (item.isAnswer == false)
                {
                    if (item.isDecision == false)
                    {
                        model.AddConstraint(getConstraintName(item.name), CreateConstraint(item.usedIn, "<=", item.inventory));
                    }
                    else
                    {
                        String _constraintname = "constraint" + item.name;
                        _constraintname.Replace(" ", "_");
                        model.AddConstraint(getConstraintName(item.name), CreateConstraint(item.usedIn, "<=", item.decision));
                    }
                }
            }
        }


        internal static void buildKnapsackConstraints(Problem _problem, Model model)
        {
            foreach (var item in _problem.knapsackElements)
            {
                _problem.model.AddConstraint(getConstraintName(item.name), item.decision <= item.inventory);
            }
            _problem.model.AddConstraint("constr", _problem.knapsackElements[0].decision * _problem.knapsackElements[0].weight + _problem.knapsackElements[1].decision * _problem.knapsackElements[1].weight <= _problem.capacity);

        }

        public static void buildTSPContstraints(Problem _problem, Model model)
        {
            foreach (var item in _problem.connections)
            {
                _problem.model.AddConstraint(getConstraintName(item.name), item.decision >= 1);
            }
           
                var result = _problem.connections.GroupBy(a => a.group);
                
                foreach (var group in result) // A ... E
                {
                    Term t = 0;
                    String _tempName = "";
                    foreach (var g in group)  // A_B, A_C, ...
                    {
                        t = t + g.decision;
                        _tempName = g.group;
                    }
                    t = t == 1;
                    _problem.model.AddConstraint(getConstraintName(_tempName), t);
                }                
             
        }

        private static string getConstraintName(string _itemname)
        {
            String _constraintname = "constraint" + _itemname;
            _constraintname = _constraintname.Replace(" ", "_");
            return _constraintname;
        }

        public static Term CreateConstraint(Dictionary<Element, int> _ingredients, String _operator, object rightside)
        {
            Term _constraint = 0;
            Term[] terms = new Term[_ingredients.Count];
            int i = 0;
            foreach (var item in _ingredients)
            {
                Term _factor = item.Key.decision;
                Term _variable = item.Value;
                Term t = _factor * _variable;
                terms[i] = t;
                i = i + 1;
            }
            for (int j = 0; j < terms.Count(); j++)
            {
                _constraint = _constraint + terms[j];
            }
            if (rightside is int)
            {
                _constraint = _constraint <= (int)rightside;
            }
            else if (rightside is Decision)
            {
                _constraint = _constraint <= (Decision)rightside;
            }

            return _constraint;
        }


      
    }
}