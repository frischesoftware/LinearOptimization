using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SolverFoundation.Services;
using Microsoft.SolverFoundation.Solvers;
using System.Web.UI.HtmlControls;
using LinearOptimizationGame.Helpers;
using LinearOptimizationGame.Classes.BasicClasses;
using LinearOptimizationGame.Classes.Helpers;


using LinearOptimizationGame.Classes.Scenarios;
using LinearOptimizationGame.Scenarios;
using LinearOptimizationGame.Classes.BasicClasses.KNAPSACK;
using LinearOptimizationGame.Classes.Scenarios.KNAPSACK;
using LinearOptimizationGame.Classes.Helpers.CONTROLLS;

namespace LinearOptimizationGame
{
    public partial class start2 : Page
    {
        public static Random r = new Random();
        public static Problem p_static;
        //static Solution s;
        JavascriptHelpers javascriptHelp = new JavascriptHelpers();
        
        // build Controls
        ProductionControllGenerationHelpers contHelp = new ProductionControllGenerationHelpers();
        KnapsackControlGenerationHelper knapContHelp = new KnapsackControlGenerationHelper();

        GameControlHelpers gameHelp = new GameControlHelpers();
        ResultControllHelper resHelp = new ResultControllHelper();
       
        GoalHelpers goalHelp = new GoalHelpers();
        DebugHelpers debugHelp = new DebugHelpers();
        SolverHelper solvHelper = new SolverHelper();

        const int howManyGamesAreActive = 6;

        public void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                setCurrentProblem(getCurrentProblem());
                p_static = new Problem();
                p_static = Problem.Initialize(getCurrentProblem());
                Session["p"] = p_static;
                showTheContent();
                btnStartNewGame.Visible = false;
                btnTryAgain.Visible = false;
                OrderProduction.Visible = true;
            }                             
        }
        private void setCurrentProblem(int i)
        {
            // 1 2 3 (4) 5 6 7 8 9 10
            lblWhichGameToStart.Value = i.ToString();
            // alle abwählen (normal)
            for (int j = 1; j <= howManyGamesAreActive; j++)
            {
                HtmlGenericControl cc = (HtmlGenericControl)Page.FindControl("r" + j.ToString());
                cc.Attributes.Remove("class");
                cc.Attributes.Add("class", "investfield");        
            }

            for (int j = 1; j <= howManyGamesAreActive; j++)
            {
                HtmlGenericControl cc = (HtmlGenericControl)Page.FindControl("r" + j.ToString());
                //cc.Attributes.Add("class", "investfield disabled");  //dies, wenn nur das Programm enablen und disablen soll
                if (j==i)
                {
                    cc.Attributes.Remove("class");
                    cc.Attributes.Add("class", "investfield selected");        
                }
                if (p_static != null && p_static.completedGames.Count != 0)
                {
                    if (j <= p_static.completedGames.Max())
                    {
                        cc.Attributes.Remove("class");
                        cc.Attributes.Add("class", "investfield");
                    }                                    
                }
                
            }
            // das aktuelle anwählen (rot)
            //HtmlGenericControl c = (HtmlGenericControl)Page.FindControl("r" + i);                                    

        }
        private int getCurrentProblem()
        {
            if (lblWhichGameToStart.Value.Equals("1"))
            {              
                return 1;                
            }
            else if (lblWhichGameToStart.Value.Equals("2"))
            {
                return 2;
            }
            else if (lblWhichGameToStart.Value.Equals("3"))
            {
                return 3;
            }
            else if (lblWhichGameToStart.Value.Equals("4"))
            {
                return 4;
            }
            else if (lblWhichGameToStart.Value.Equals("5"))
            {
                return 5;
            }
            else if (lblWhichGameToStart.Value.Equals("6"))
            {
                return 6;
            }
            else if (lblWhichGameToStart.Value.Equals("7"))
            {
                return 7;
            }
            else if (lblWhichGameToStart.Value.Equals("8"))
            {
                return 8;
            }
            else if (lblWhichGameToStart.Value.Equals("9"))
            {
                return 9;
            }
            else if (lblWhichGameToStart.Value.Equals("10"))
            {
                return 10;
            }
            else
            {             
                return 1;
            }           
        }

        public void showTheContent()
        {
            Dictionary<String, int> inventory;
            String transferString ="";
            if (p_static.problemType == "KNAPSACK")
            {
                gameHelp.CreateControlForUSERINFOandMISSION(div_mission, p_static);
                gameHelp.CreateAnswerTextboxes(p_static, div_userDataEntry);

                knapContHelp.CreateControlForKnapsack_BigTable("---", p_static, dynamicElements);
                knapContHelp.CreateControlForKnapsack_Backpack("---", p_static.capacity.ToString(), dynamicElements);

                //gameHelp.CreateListOfChallenges(div_challenges, p_static);
                div_story.InnerHtml = p_static.story;
                transferString = javascriptHelp.KnapsackJavascript(p_static);
                // Objekt mit dem "Rucksack"
            }
            if (p_static.problemType == "PRODUCTION")
            {
                gameHelp.CreateControlForUSERINFOandMISSION(div_mission, p_static);   //div_mission  dynamicElements
                inventory = new Dictionary<string, int>();
                foreach (var item in p_static.elements)
                {
                    inventory.Add(item.name, item.inventory);
                }
                contHelp.CreateControlForInventory("Inventory ", inventory, dynamicElements);

                foreach (var item in p_static.elements)
                {
                    if (item.isDecision == true)
                    {
                        contHelp.CreateControlForBoM(item.decision.Name + " requires:", item.requires, dynamicElements);
                    }
                }
                //gameHelp.CreateStory(dynamicElements, p_static); //dynamicElements
                div_story.InnerHtml = p_static.story;


                gameHelp.CreateAnswerTextboxes(p_static, div_userDataEntry);

              //  gameHelp.CreateListOfChallenges(div_challenges, p_static);

                transferString = javascriptHelp.ProductionJavascript(p_static);
                
            }


            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", transferString, true);                       
        }



        private bool evaluatePageInput(Double calculatedResult, Problem p2, Double userAnswer) // TextBox3
        {
            bool _gameSolvedCorrectlyMoveToNextGame = false;
            if (p2.solution.Quality.ToString() == "Optimal")  // "optimal" mit den usereingaben, d.h. ggf. suboptimal
            {
                if (userAnswer == calculatedResult)
                {                 
                    _gameSolvedCorrectlyMoveToNextGame = true;
                    p_static.result = "Optimal";
                }
                else
                {             
                    p_static.result = "Suboptimal";
                }
            }
            else
            {
                p_static.result = "Infeasible";
            }
            return _gameSolvedCorrectlyMoveToNextGame;
        }

        private static double getPageInput(Problem p2)
        {
            Double _userAnswer = 0;
            if (p2.problemType == "KNAPSACK")
            {
                foreach (var a in p2.knapsackElements)
                {
                    if (a.isAnswer == true)
                    {
                        _userAnswer += Convert.ToDouble(a.userAnswer * a.value);
                    }
                }
            }

            if (p2.problemType == "PRODUCTION")
            {
                foreach (var a in p2.elements)
                {
                    if (a.isAnswer == true)
                    {
                        _userAnswer += Convert.ToDouble(a.userAnswer);
                    }
                }    
            }
            return _userAnswer;
        }

      

        private void getTheAnswersFrompage()
        {
            if (p_static.problemType == "KNAPSACK")
            {
                foreach (var item in p_static.knapsackElements)
                {
                    TextBox t = (TextBox)mainDIV.FindControl("Textbox_" + item.name);
                    if (item.isAnswer == true)
                    {
                        item.userAnswer = Convert.ToInt32(Request.Form["Textbox_" + item.name]);
                        item.domain = Domain.IntegerRange(item.userAnswer, item.userAnswer);
                    }
                }
            }
            if (p_static.problemType == "PRODUCTION")
            {
                foreach (var item in p_static.elements)
                {
                    TextBox t = (TextBox)mainDIV.FindControl("Textbox_" + item.name);
                    if (item.isAnswer == true)
                    {
                        item.userAnswer = Convert.ToInt32(Request.Form["Textbox_" + item.name]);
                        item.domain = Domain.IntegerRange(item.userAnswer, item.userAnswer);
                        // item.textBox = (TextBox)mainDIV.FindControl("Textbox_" + item.name);   // z.B. EE.textbox = "Textbox_EE"
                        //    item.userAnswer = Convert.ToInt32(((TextBox)mainDIV.FindControl("Textbox_" + item.name)).Text);
                    }
                }
            }

        }

        public void btnOrderProduction_Click(object sender, EventArgs e)
        {
            getTheAnswersFrompage();
            if ((Problem)Session["p"] != null)
            {
                p_static = (Problem)Session["p"];
                
                showTheContent();
            }
            //TextBox tb3 = (TextBox)section4.FindControl("TextBox3");
            Double calculatedResult = Math.Round(p_static.solution.Goals.First().ToDouble());

           

          
                Problem p2 = new Problem();
                p2 = solvHelper.SolveWithUserInput(p_static);
                Double userAnswer = getPageInput(p2);
                if (evaluatePageInput(calculatedResult, p2, userAnswer) == true)
                {
                    p_static.completedGames.Add(getCurrentProblem());  // dieses Problem haben wir gelöst

                    // setCurrentProblem(getCurrentProblem() + 1);
                    p_static.proceedToNextGame = true; // nächste Runde: eins weiter

                    btnStartNewGame.Visible = true;
                    btnTryAgain.Visible = false;
                }
                else
                {
                    p_static.proceedToNextGame = false; // da falsch geantwortet
                    btnStartNewGame.Visible = false;
                    btnTryAgain.Visible = true;
                }
            //}
            OrderProduction.Visible = false; // disable "Order Production" button    
            
            // jetzt hier noch alles unsichtbar machen: Fokus auf Ergebnis; dieses anzeigen
            // bisher: Eingabebereich unsichtbar machen: 
            // div_userDataEntry.Visible = false;

                

            makeAllTextboxesInDivREADONLY_READ(div_userDataEntry, true);

            resHelp.CreateControlForResult(p_static, dynamicElements);
        }


        private void makeAllTextboxesInDivREADONLY_READ(HtmlGenericControl _div_userDataEntry, bool _readOrReadonly)
        {
            var controlList = GetControlHierarchy(_div_userDataEntry).ToList();

            foreach (var control in controlList)
            {
                if (control.ID != null)
                {
                    if (control.ID.Contains("Textbox"))
                    {
                        TextBox c = (TextBox)control;
                        c.ReadOnly = _readOrReadonly;
                        /*
                        c.Attributes.Remove("readOnly");
                        c.Attributes.Add("color", "green");
                        c.Attributes.Add("readOnly", _readOrReadonly);
                      */
                    }
                }
            }
        }
        

        private IEnumerable<Control> GetControlHierarchy(Control root)
        {
            var queue = new Queue<Control>();
            queue.Enqueue(root);
            do
            {
                var control = queue.Dequeue();
                yield return control;
                foreach (var child in control.Controls.OfType<Control>())
                    queue.Enqueue(child);
            } while (queue.Count > 0);
        }






        protected void btnStartNewGame_Click1(object sender, EventArgs e)
        {
            if (p_static.proceedToNextGame == true)
            {
                if (getCurrentProblem() + 1 > howManyGamesAreActive)  // no more games available -> game over
                {
                    p_static = Problem.Initialize(999);
                }
                else
                {
                    setCurrentProblem(getCurrentProblem() + 1);
                    p_static = Problem.Initialize(getCurrentProblem());           
                }                
            }
            else
            {
                setCurrentProblem(getCurrentProblem());  // wenn man direkt auswählt -> dann nicht +1. benötigt, um den richtigen Button rot zu färben
                p_static = Problem.Initialize(getCurrentProblem());                
            }            
            showTheContent();
            Session["p"] = p_static;
            btnStartNewGame.Visible = false;
            btnTryAgain.Visible = false;
            OrderProduction.Visible = true;

           // div_userDataEntry.Visible = true; true ist gut, aber nicht mehr nötig. Jetzt: disablen/enablen
            makeAllTextboxesInDivREADONLY_READ(div_userDataEntry, false);

        }     
     
    }
}










      //private static List<Element> randomize(List<Element> _e) //Problem _p
      //  {
      //      DebugHelpers _debugHelp = new DebugHelpers();
      //      GoalHelpers _goalHelp = new GoalHelpers();
      //      Problem newP = new Problem();
      //      //newP = _p;
      //      List<Element> newElements = new List<Element>();
      //      int numberOfabc = 2;
      //      int numberOfABC = 1;

            
      //     // bool isDifferent = false;
      //      // diese anfügen, so daß jedes die Komplexität erhöht
            
      //      for (int i = 0; i < numberOfABC; i++)
      //      {
      //           Element e = new Element() { 
      //           name = "C" + i.ToString(), 
      //           domain = Domain.IntegerRange(0, 32000), 
      //           inventory = 0, 
      //           isAnswer = true, 
      //           isDecision = true 
      //           };
      //           newElements.Add(e);
      //      }
            
      //      for (int i = 0; i < numberOfabc; i++)
      //      {
      //          Element e = new Element() {
      //              name = "a" + i.ToString(),
      //              domain = Domain.IntegerRange(0, 32000),
      //              inventory = r.Next(70, 130),  // milder Zufall, aber nichts weltbewegendes
      //              isAnswer = false,
      //              isDecision = false
      //          };
      //          // die usedIns. Brauchen wir eins für jedes Element, das isAnswer ist
      //          Dictionary<Element, int> _usedIns = new Dictionary<Element, int>();
      //          foreach (var item in newElements)
      //          {
      //              if (item.isAnswer == true)
      //              {
      //                  _usedIns.Add(item, r.Next(1,9));
      //              }
      //          }
      //          e.usedIn = _usedIns;
      //          newElements.Add(e);
      //          // nachdem abc angefügt wurde inkl. Usedin, "solven" wir das Ganze:
      //          SolverContext context = new SolverContext(); //.GetContext()
      //          newP.elements = newElements;
      //          newP.model = context.CreateModel();

      //          Problem tempP = new Problem();
      //          tempP = newP;

      //          DecisionsHelpers.addDecisionsToModel(tempP, tempP.model);
      //          ConstraintsHelper.buildConstraints(tempP, tempP.model);
      //          tempP.model.AddGoal("max_EE_FF", GoalKind.Maximize, _goalHelp.buildGoal(tempP)); // EE.decision + FF.decision

      //          tempP.solution = context.Solve(new SimplexDirective());
      //          _debugHelp.DisplaySolution(tempP.solution, "optimal solution");
              
      //      }
            
      //     // return newP;
    //return newElements;
    //    }
