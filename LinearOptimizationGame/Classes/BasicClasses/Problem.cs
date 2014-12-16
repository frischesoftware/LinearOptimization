using LinearOptimizationGame.Classes.BasicClasses;
using LinearOptimizationGame.Classes.BasicClasses.KNAPSACK;
using LinearOptimizationGame.Classes.BasicClasses.TSP;
using LinearOptimizationGame.Classes.Scenarios;
using LinearOptimizationGame.Classes.Scenarios.KNAPSACK;
using LinearOptimizationGame.Classes.Scenarios.TSP;
using LinearOptimizationGame.Helpers;
using LinearOptimizationGame.Scenarios;
using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;

namespace LinearOptimizationGame
{
    public class Problem
    {
        public String problemType { get; set; }
        
        public String aufgabenstellung { get; set; }
        public String story { get; set; }
        public String ending_optimal { get; set; }
        public String ending_infeasible { get; set; }
        public String ending_suboptimal { get; set; }

        public bool proceedToNextGame { get; set; }

        public String result { get; set; } // Optimal, Infeasible, Suboptimal

        public String goal { get; set; }
        public List<Element> elements { get; set; }

        public Model model { get; set; }
        public Solution solution { get; set; }

        // Knapsack
        public List<KnapsackElement> knapsackElements { get; set; }
        public int capacity { get; set; }
        public List<int> completedGames { get; set; }

        // TSP
        public List<TSPElement> connections { get; set; }


        public static Problem Initialize(int currentProblem)
        {
            Problem _problem = new Problem(); ;
            _problem.completedGames = new List<int>();

            SolverContext context = new SolverContext(); //.GetContext()
            _problem.model = context.CreateModel();

            if (currentProblem == 999)  // last game; 
            {
                _problem.story = "Coming soon: different problem types, complex scenarios and nice visualizations";
            }

            if (currentProblem == 111)  //TSP
            {
                TSP_easy E = new TSP_easy();
                E.Initialize();

                _problem.connections = E.listOfElements;
                _problem.problemType = "TSP";
                _problem.aufgabenstellung = "Solve this Travelling Salesman Problem. Find the shortest route.";

                finishTSPProblem(_problem, context);
            }
            if (currentProblem == 1)
            {
                //Elements_easy E = new Elements_easy();
                //Elements_easy_Random E = new Elements_easy_Random();
                Elements_easy E = new Elements_easy();
                E.Initialize();
                _problem.elements = E.listOfElements;
                _problem.problemType = "PRODUCTION";
                _problem.aufgabenstellung = "Solve this randomly generated mulit-stage Production planning problem";
                _problem.story = buildProductionStory(E.listOfElements);

                _problem.ending_optimal = "Your production plan was perfect.";
                _problem.ending_suboptimal = "Your production plan was not optimal. A better plan can produce more products.";
                _problem.ending_infeasible = "Your production plan is impossible. Given our constraints we can not produce so many products.";


                finishProductionProblem(_problem, context);

            }
            if (currentProblem == 2)
            {
                //   _problem = new Problem();
                Knapsack_easy E = new Knapsack_easy();
                E.Initialize();
                _problem.knapsackElements = E.listOfElements;
                _problem.problemType = "KNAPSACK";
                _problem.aufgabenstellung = "Solve this Knapsack problem. Fit best combination into the backpack";
                _problem.story = buildKnapsackStory(E.listOfElements);

                _problem.ending_optimal = "Perfect: You have found the best combination of items to fit into the Backpack";
                _problem.ending_suboptimal = "Suboptimal: A better combination of items in the Backpack leads to a higher total value!";
                _problem.ending_infeasible = "Infeasible: This combination of items exceeds the capacity of the Backpack!";

                _problem.capacity = 11;

                finishKnapsackProblem(_problem, context);
            }

            if (currentProblem == 3)
            {
                // p.elements = elements_easy();
                Elements_medium E = new Elements_medium();
                E.Initialize();
                _problem.elements = E.listOfElements;
                _problem.problemType = "PRODUCTION";
                _problem.aufgabenstellung = "Solve this basic Production planning problem";
                _problem.story = buildProductionStory(E.listOfElements);

                _problem.ending_optimal = "Your production plan was perfect.";
                _problem.ending_suboptimal = "Your production plan was not optimal. A better plan can produce more products.";
                _problem.ending_infeasible = "Your production plan is impossible. Given our constraints we can not produce so many products.";

                finishProductionProblem(_problem, context);
            }
            if (currentProblem == 4)
            {
                Knapsack_medium E = new Knapsack_medium();
                E.Initialize();
                _problem.knapsackElements = E.listOfElements;
                _problem.capacity = 20;
                _problem.story = buildKnapsackStory(E.listOfElements);

                _problem.ending_optimal = "Perfect: You have found the best combination of items to fit into the Backpack";
                _problem.ending_suboptimal = "Suboptimal: A better combination of items in the Backpack leads to a higher total value!";
                _problem.ending_infeasible = "Infeasible: This combination of items exceeds the capacity of the Backpack!";

                finishKnapsackProblem(_problem, context);
            }

       
            if (currentProblem == 5)
            {
                Elements_multilevel_productmix E = new Elements_multilevel_productmix();
                E.Initialize();
                _problem.elements = E.listOfElements;
                _problem.problemType = "PRODUCTION";
                _problem.aufgabenstellung = "Solve this multi-stage Production planning problem";
                _problem.story = buildProductionStory(E.listOfElements);

                _problem.ending_optimal = "Your production plan was perfect.";
                _problem.ending_suboptimal = "Your production plan was not optimal. A better plan can produce more products.";
                _problem.ending_infeasible = "Your production plan is impossible. Given our constraints we can not produce so many products.";


                finishProductionProblem(_problem, context);
            }
            if (currentProblem == 6)
            {
                Elements_variable_levels E = new Elements_variable_levels();
                E.Initialize();
                _problem.elements = E.listOfElements;
                _problem.problemType = "PRODUCTION";
                _problem.aufgabenstellung = "Solve this multi-stage Production planning problem";
                _problem.story = buildProductionStory(E.listOfElements);

                _problem.ending_optimal = "Your production plan was perfect.";
                _problem.ending_suboptimal = "Your production plan was not optimal. A better plan can produce more products.";
                _problem.ending_infeasible = "Your production plan is impossible. Given our constraints we can not produce so many products.";


                finishProductionProblem(_problem, context);
            }


            return _problem;

        }
        private static string buildKnapsackStory(List<KnapsackElement> _E)
        {
            String s = "We have a Backpack and must fill it with items in our inventory." +
                "The Backpack has a limited capacity and each item in our Inventory has a specific weight." +
                    "The total weight of all items in the backpack can not exceed the capacity of the backpack. " +
                        " We want to optimize the total value of the items in the backpack. " +
                        " Note that there is also a limited supply for each item in our inventory.";            
            return s;
        }
        private static string buildProductionStory(List<Element> _E)
        {
            String s = "We need to produce as many ";
            foreach (var item in _E)
            {
                if (item.isAnswer == true)
                {
                    s += item.name + " and ";
                }
            }
            s = s.Substring(0, s.Length - 5);
            s += " as possible! ";

            s += "To achieve this goal we have ";
            foreach (var item in _E)
            {
                if (item.isAnswer == false && item.isDecision == false)
                {
                    s += item.inventory + " " + item.name + ", ";
                }
            }
            s = s.Substring(0, s.Length - 2);
            s += " in our inventory. ";
            s += "Refer to the individual product tables to see how much of each is required. ";


            s += "For example, to produce one ";
            foreach (var item in _E)
            {
                if (item.isAnswer == true)
                {
                    s += item.name + "; we need ";
                    foreach (var r in item.requires)
                    {
                        s += r.Value + " " + r.Key.name + " and ";
                    }
                    
                    break;
                }
            }
            s = s.Substring(0, s.Length - 5);
            s += ". ";
            


            s += "Find the optimal production plan! Enter your answer in the 'Enter Decision' textbox on the left side.";
            
            return s;
        }

        private static void finishTSPProblem(Problem _problem, SolverContext context)
        {
            GoalHelpers _goalHelp = new GoalHelpers();
            DebugHelpers _debugHelp = new DebugHelpers();

            foreach (var item in _problem.connections)
            {
                Decision d = new Decision(Domain.Boolean, item.name);
                item.decision = d;
                _problem.model.AddDecision(d);
            }
            ConstraintsHelper.buildTSPContstraints(_problem, _problem.model);

            _problem.model.AddGoal("Min_distance", GoalKind.Maximize, _goalHelp.buildTSPGoal(_problem));

            _problem.solution = context.Solve(new SimplexDirective());

            _debugHelp.DisplaySolution(_problem.solution, "optimal solution");


        }
        private static void finishProductionProblem(Problem _problem, SolverContext context)
        {
            GoalHelpers _goalHelp = new GoalHelpers();
            DebugHelpers _debugHelp = new DebugHelpers();
            DecisionsHelpers.addDecisionsToModel(_problem, _problem.model);
            ConstraintsHelper.buildConstraints(_problem, _problem.model);

            _problem.model.AddGoal("max_EE_FF", GoalKind.Maximize, _goalHelp.buildGoal(_problem)); // EE.decision + FF.decision

            //Solution solution
            _problem.solution = context.Solve(new SimplexDirective());

            _debugHelp.DisplaySolution(_problem.solution, "optimal solution");
        }

        private static void finishKnapsackProblem(Problem _problem, SolverContext context)
        {
            GoalHelpers _goalHelp = new GoalHelpers();
            DebugHelpers _debugHelp = new DebugHelpers();
            DecisionsHelpers.addKnapsackDecisionsToModel(_problem, _problem.model);
            ConstraintsHelper.buildKnapsackConstraints(_problem, _problem.model);
            _problem.problemType = "KNAPSACK";
            _problem.aufgabenstellung = "Solve this Knapsack problem. Fit best combination into the backpack";
          //  _problem.capacity = 11;


            _problem.model.AddGoal("knap", GoalKind.Maximize, _goalHelp.buildKnapsackGoal(_problem)); // EE.decision + FF.decision
            // solve!!
            _problem.solution = context.Solve(new SimplexDirective());
            _debugHelp.DisplaySolution(_problem.solution, "knapsack solution");
        }
    }

}

