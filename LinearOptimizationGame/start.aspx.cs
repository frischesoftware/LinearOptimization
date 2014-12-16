using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SolverFoundation.Services;
using Microsoft.SolverFoundation.Solvers;
using System.Web.UI.HtmlControls;

namespace LinearOptimizationGame
{
    public partial class start : Page
    {
        static Random r = new Random();
        static Problem p;
        static Solution s;

        static int currentProblem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                p = new Problem();
                currentProblem = 3;
                makeProblem();
            }
            showTheContent();
        }

        private void makeProblem()
        {
            switch (currentProblem)
            {
                case 1:
                    s = easy_product();
                    break;

                case 2:
                    break;

                case 3:
                    s = multilevel_productmix();
                    break;
            }
        }

        private void showTheContent()
        {
            switch (currentProblem)
            {
                case 1:

                    break;

                case 2:
                    break;

                case 3:

                    // Angaben

                    Dictionary<String, int> BoM_C = new Dictionary<string, int>() { { "a", 6 }, { "b", 1 } };
                    Dictionary<String, int> BoM_D = new Dictionary<string, int>() { { "a", 4 }, { "b", 2 } };
                    Dictionary<String, int> BoM_EE = new Dictionary<string, int>() { { "C", 2 }, { "D", 1 } };
                    Dictionary<String, int> BoM_FF = new Dictionary<string, int>() { { "C", 1 }, { "D", 2 } };
                    Dictionary<String, int> inventory = new Dictionary<string, int>() { { "a", 100 }, { "b", 200 }, { "C", 0 }, { "D", 0 }, { "EE", 0 }, { "FF", 0 } };
                    


                    CreateAControl("C requires:", BoM_C, a1);
                    CreateAControl("D requires:", BoM_D, a2);
                    CreateAControl("EE requires:", BoM_EE, a3);
                    CreateAControl("FF requires:", BoM_FF, a4);

                    CreateInventory("Inventory ", inventory, a5);
                    //CreateAControl("Inventory ", inventory, a5);           
                    CreateAControl_Goal("Goal: Maximize EE + FF", goal);



                    TextBox t = new TextBox();

                    section1.Controls.Add(new Label() { Text = "EE_Quantity", CssClass="form-control"});
                    t.Attributes.Add("Style", "color : #FF6A00");
                    t.Attributes.Add("class", "form-control");
                    t.ID= "TextBox1";
                    section1.Controls.Add(t);

                    t = new TextBox();
                    section1.Controls.Add(new Label() { Text = "FF_Quantity", CssClass="form-control" });
                    t.Attributes.Add("Style", "color : #FF6A00");
                    t.Attributes.Add("class", "form-control");
                    t.ID= "TextBox2";
                    section1.Controls.Add(t);
                    break;
                default:

                    break;
            }
        }
        private void CreateAControl_Goal(string headline, Control addToControl)
        {
            HtmlGenericControl goal = new HtmlGenericControl("div");
            goal.InnerHtml = headline;
            goal.Attributes.Add("class", "cell-top");
            addToControl.Controls.Add(goal);
        }

        private void CreateInventory(string headline, Dictionary<String, int> _dictionary, Control addToControl)
        {
            HtmlGenericControl celltop = new HtmlGenericControl("div");
            celltop.Attributes.Add("class", "cell-top");
            celltop.InnerHtml = headline;

            HtmlGenericControl cellbottom = new HtmlGenericControl("div");
            cellbottom.Attributes.Add("class", "cellbottom");

            foreach (var item in _dictionary)
            {
                HtmlGenericControl cellleft = new HtmlGenericControl("div");
                cellleft.Attributes.Add("class", "cell-left");
                cellleft.Attributes.Add("style", "width: 75px");
                cellleft.InnerHtml = item.Key;

                HtmlContainerControl cellcenter = new HtmlGenericControl("div");
                cellcenter.Attributes.Add("class", "cell-center");
                cellcenter.InnerHtml = "0";

                HtmlGenericControl cellright = new HtmlGenericControl("div");
                cellright.Attributes.Add("class", "cell-right");
                cellright.InnerHtml = item.Value.ToString();




                cellbottom.Controls.Add(cellleft);
                cellbottom.Controls.Add(cellright);
                cellbottom.Controls.Add(cellcenter);
            }


            addToControl.Controls.Add(celltop);
            addToControl.Controls.Add(cellbottom);
        }

        private void CreateAControl(string headline, Dictionary<String, int> _dictionary, Control addToControl)
        {
            HtmlGenericControl celltop = new HtmlGenericControl("div");
            celltop.Attributes.Add("class", "cell-top");
            celltop.InnerHtml = headline;

            HtmlGenericControl cellbottom = new HtmlGenericControl("div");
            cellbottom.Attributes.Add("class", "cellbottom");

            foreach (var item in _dictionary)
            {
                HtmlGenericControl cellleft = new HtmlGenericControl("div");
                cellleft.Attributes.Add("class", "cell-left");
                cellleft.InnerHtml = item.Key;

                HtmlGenericControl cellright = new HtmlGenericControl("div");
                cellright.Attributes.Add("class", "cell-right");
                cellright.InnerHtml = item.Value.ToString();

                cellbottom.Controls.Add(cellleft);
                cellbottom.Controls.Add(cellright);
            }


            addToControl.Controls.Add(celltop);
            addToControl.Controls.Add(cellbottom);

        }

        private static Solution easy_product()
        {
            // 2 Materialien , ein Produkt - wahlweise

            SolverContext context = SolverContext.GetContext();
            Model model = context.CreateModel();

            Element a = new Element { name = "a", domain = Domain.IntegerNonnegative, inventory = 100 };
            Element b = new Element { name = "b", domain = Domain.IntegerNonnegative, inventory = 40 };
            Element C = new Element { name = "C", domain = Domain.IntegerNonnegative };

            Decision a_quantity = new Decision(a.domain, a.name);
            Decision b_quantity = new Decision(a.domain, b.name);

            Decision C_quantity = new Decision(C.domain, C.name);
            model.AddDecisions(C_quantity); // a_quantity,b_quantity, 

            //a.usedIn = new Dictionary<int, Decision>() { { 4, C_quantity } };  // nur 4 a für ein C, und 100 auf Lager
            //b.usedIn = new Dictionary<int, Decision>() { { 7, C_quantity } }; // 7 b für C, und nur 40 auf Lager -> schlechter

            //model.AddConstraint("max_a_in_store", CreateConstraint_FirstLevel(a.usedIn, "<=", a.inventory));
            //model.AddConstraint("max_b_in_store", CreateConstraint_FirstLevel(b.usedIn, "<=", b.inventory));

            model.AddGoal("max_C", GoalKind.Maximize, C_quantity);

            Solution solution = context.Solve(new SimplexDirective());
            return solution;
        }

        private static Solution multilevel_productmix()
        {
            // zweistufige Produktion 
            SolverContext context = SolverContext.GetContext();
            Model model = context.CreateModel();


            Problem p = new Problem();

            p.inventory = new Dictionary<string, int>();
            p.inventory.Add("a", 100);
            p.inventory.Add("b", 200);
            p.inventory.Add("C", 0);
            p.inventory.Add("D", 0);
            p.inventory.Add("EE", 0);
            p.inventory.Add("FF", 0);


            Element a = new Element { name = "a", domain = Domain.IntegerNonnegative };
            a.inventory = p.inventory[a.name];

            Element b = new Element { name = "b", domain = Domain.IntegerNonnegative, inventory = 200 };

            Element C = new Element { name = "C_quantity", domain = Domain.IntegerNonnegative };

            Element D = new Element { name = "D_quantity", domain = Domain.IntegerNonnegative };

            Element EE = new Element { name = "EE", domain = Domain.IntegerNonnegative };
            Element FF = new Element { name = "FF", domain = Domain.IntegerNonnegative };







            Decision C_quantity = new Decision(C.domain, C.name); // Domain.IntegerNonnegative, "C_quantity");
            Decision D_quantity = new Decision(Domain.IntegerNonnegative, "D_quantity");
            Decision EE_quantity = new Decision(Domain.IntegerNonnegative, "EE_quantity");
            Decision FF_quantity = new Decision(Domain.IntegerNonnegative, "FF_quantity");
            model.AddDecisions(C_quantity, D_quantity, EE_quantity, FF_quantity);

            a.usedIn = new Dictionary<int, Decision>() { { 6, C_quantity }, { 4, D_quantity } };
            b.usedIn = new Dictionary<int, Decision>() { { 1, C_quantity }, { 2, D_quantity } };
            C.usedIn = new Dictionary<int, Decision>() { { 2, EE_quantity }, { 1, FF_quantity } };
            D.usedIn = new Dictionary<int, Decision>() { { 1, EE_quantity }, { 2, FF_quantity } };



            model.AddConstraint("one", CreateConstraint_FirstLevel(a.usedIn, "<=", a.inventory));
            model.AddConstraint("two", CreateConstraint_FirstLevel(b.usedIn, "<=", b.inventory));

            model.AddConstraint("three", CreateConstraint_SecondLevel(C.usedIn, "<=", C_quantity));
            model.AddConstraint("four", CreateConstraint_SecondLevel(D.usedIn, "<=", D_quantity));

            model.AddGoal("max_EE_FF", GoalKind.Maximize, EE_quantity + FF_quantity);

            Solution solution = context.Solve(new SimplexDirective());
            return solution;
        }

        private static Term CreateConstraint_FirstLevel(Dictionary<int, Decision> _ingredients, String _operator, int rightside)
        {
            Term t1 = 0;
            Term[] terms = new Term[_ingredients.Count];
            int i = 0;
            foreach (var item in _ingredients)
            {
                Term _factor = item.Value;
                Term _variable = item.Key;
                Term t = _factor * _variable;
                terms[i] = t;
                i = i + 1;
            }

            for (int j = 0; j < terms.Count(); j++)
            {
                t1 = t1 + terms[j];
            }

            t1 = t1 <= rightside;

            return t1;
        }

        private static Term CreateConstraint_SecondLevel(Dictionary<int, Decision> _ingredients, String _operator, Decision rightside)
        {
            Term t1 = 0;
            Term[] terms = new Term[_ingredients.Count];
            int i = 0;
            foreach (var item in _ingredients)
            {
                Term _factor = item.Value;
                Term _variable = item.Key;
                Term t = _factor * _variable;
                terms[i] = t;
                i = i + 1;
            }

            for (int j = 0; j < terms.Count(); j++)
            {
                t1 = t1 + terms[j];
            }

            t1 = t1 <= rightside;

            return t1;
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            TextBox tb1 = (TextBox)mainDIV.FindControl("TextBox1");            
            TextBox tb2 = (TextBox)mainDIV.FindControl("TextBox2");
           


            //  ContentPlaceHolder C =      (ContentPlaceHolder)this.Page.Master.FindControl("MainContent");

            //ContentPlaceHolder mc = FindControl("BodyContent") as ContentPlaceHolder;
            // TextBox tb3 = C.FindControl("TextBox3") as TextBox;


            TextBox tb3 = (TextBox)section4.FindControl("TextBox3");



            Dictionary<string, String> dic = new Dictionary<string, string>();
            foreach (var item in s.Decisions)
            {
                dic.Add(item.Name, item.GetDouble().ToString());
            }
            if (tb1.Text == dic["EE_quantity"] && tb2.Text == dic["FF_quantity"])
            {
                tb3.Text = "correct";
                currentProblem = currentProblem + 1;
            }
            else
            {
                tb3.Text = "incorrect. Space monster will eat your civilization";
            }

        }

    }


}


//private static Term CreateConstraint_FixedConstants_FirstLevel(Decision d1, int c1, Decision d2, int c2, String _operator, int rightside)
//{
//    Term t1;
//    if (_operator == "<=")
//    {
//        t1 = c1 * d1 + c2 * d2 <= rightside;    
//    }
//    else if (_operator == "=>")
//    {
//        t1 = c1 * d1 + c2 * d2 >= rightside;    
//    }
//    else
//    {
//        t1 = c1 * d1 + c2 * d2 == rightside;    
//    }

//    return t1;
//}

//private static Term CreateConstraint_RandomConstants(Decision C_quantity, Decision D_quantity)
//{
//    Term a = 6 * C_quantity; // r.Next(0, 20)
//    Term b = 4 * D_quantity; //r.Next(0, 20)             
//    Term rightside = 100; //r.Next(100, 1000);
//    Term _con = a + b  <= rightside;
//    return _con;
//}





//model.AddConstraints("production",
//               2 * EE_quantity + 1 * FF_quantity <= C_quantity,
//               1 * EE_quantity + 2 * FF_quantity <= D_quantity
//           );