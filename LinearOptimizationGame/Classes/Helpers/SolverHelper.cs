using LinearOptimizationGame.Classes.BasicClasses;
using LinearOptimizationGame.Helpers;
using LinearOptimizationGame.Scenarios;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LinearOptimizationGame.Classes.Helpers
{
    public class SolverHelper
    {
        // nicht mehr "with user input"?  -> der wurde schon früher getätigt mit der Range (25,25)
        public Problem SolveWithUserInput(Problem originalProblem) // //int currentProblem,
        {
            GoalHelpers _goalHelp = new GoalHelpers();
            DebugHelpers _debugHelp = new DebugHelpers();

            Problem _problem = new Problem();
            SolverContext context = new SolverContext(); //.GetContext()
            _problem.problemType = originalProblem.problemType;
            _problem.model = context.CreateModel();
            
            
            if (_problem.problemType == "KNAPSACK")
            {
                
                _problem.capacity = originalProblem.capacity;
                _problem.knapsackElements = originalProblem.knapsackElements;
                //DecisionsHelpers.addDecisionsToModel(_problem, _problem.model);
                DecisionsHelpers.addKnapsackDecisionsToModel(_problem, _problem.model);
                ConstraintsHelper.buildKnapsackConstraints(_problem, _problem.model);
                _problem.model.AddGoal("max_EE_FF", GoalKind.Maximize, _goalHelp.buildKnapsackGoal(_problem)); // EE.decision + FF.decision
    
            }
            if (_problem.problemType == "PRODUCTION")
            {
                _problem.elements = originalProblem.elements;
                DecisionsHelpers.addDecisionsToModel(_problem, _problem.model);
                ConstraintsHelper.buildConstraints(_problem, _problem.model);
                _problem.model.AddGoal("max_EE_FF", GoalKind.Maximize, _goalHelp.buildGoal(_problem)); // EE.decision + FF.decision
            }
            
            
            _problem.solution = context.Solve(new SimplexDirective());

            _debugHelp.DisplaySolution(_problem.solution, "mit user constraints");

            return _problem;

        }
        /*
        public SolverContext solve(Problem _p)
        {
            GoalHelpers goalHelp = new GoalHelpers();
            DebugHelpers debugHelp = new DebugHelpers();

            SolverContext c2 = new SolverContext();
            _p.model = c2.CreateModel();

            foreach (var item in _p.elements)
            {
                if (item.isAnswer)
                {
                    Term _t = item.decision;
                    _p.model.AddConstraint(item.name.ToString() + "_extra", item.userAnswer);
                }
            }             
            return c2;
         
        }*  */
    }
}



// Decisions nicht nochmal, da diese schon dranhängen an _p
//DecisionsHelpers.addDecisionsToModel(_p, _p.model);

/*
Decision C_quantity = new Decision(Domain.IntegerNonnegative, "C_quantity"); // Domain.IntegerNonnegative, "C_quantity");
Decision D_quantity = new Decision(Domain.IntegerNonnegative, "D_quantity");
Decision EE_quantity = new Decision(Domain.IntegerNonnegative, "EE_quantity");
Decision FF_quantity = new Decision(Domain.IntegerNonnegative, "FF_quantity");
m2.AddDecisions(C_quantity, D_quantity, EE_quantity, FF_quantity);
*/


//   ConstraintsHelper.buildConstraints(_p, _p.model);

/*
            _p.answers = new List<Element>();
            Element ee = (Element)(from _e in _p.elements where _e.name == "EE" select _e).Single();
            Element ff = (Element)(from _e in _p.elements where _e.name == "FF" select _e).Single();
            _p.answers.Add(ee);
            _p.answers.Add(ff);
*/

/*
       * Term term_ee = ee.userAnswer;// Convert.ToInt32(ee.textBox.Text);
      Term term_ff = ff.userAnswer; // Convert.ToInt32(ff.textBox.Text);
      m2.AddConstraints("production",
          6 * C_quantity + 4 * D_quantity <= 100,
          1 * C_quantity + 2 * D_quantity <= 200,
          2 * EE_quantity + 1 * FF_quantity <= C_quantity,
          1 * EE_quantity + 2 * FF_quantity <= D_quantity,
          EE_quantity == term_ee,
          FF_quantity == term_ff
          );
      */



// GOAL
//goal ist auch schon dabei
//_p.model.AddGoal("max_EE_FF", GoalKind.Maximize, goalHelp.buildGoal(_p)); // EE.decision + FF.decision


//m2.AddGoal("fixed_EE_FF", GoalKind.Maximize, "EE + FF");
//m2.AddGoal("fixed_EE_FF", GoalKind.Maximize, "EE_quantity + FF_quantity");