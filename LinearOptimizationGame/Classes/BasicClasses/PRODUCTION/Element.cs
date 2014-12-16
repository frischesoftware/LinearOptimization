using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LinearOptimizationGame.Classes.BasicClasses
{
    public class Element
    {
        public String name { get; set; }
        public Domain domain { get; set; }

        // input for the user?
        public bool isAnswer { get; set; }
        // a decision variable?
        public bool isDecision { get; set; }
        public Decision decision { get; set; }
        public int inventory { get; set; } // an integer on the right side as limiting factor
        //public Decision rightside { get; set; } // a Decision on the right side (5a + 5b <= 3C)

        //public Dictionary<Element, Decision> ingredients { get; set; } // welches Element, welche Menge?
        public Dictionary<Element, int> usedIn { get; set; }
        public Dictionary<Element, int> requires { get; set; }

       // public TextBox textBox { get; set; } // ersetzt durch userAnswer

        public int userAnswer { get; set; }

        public string svg_color { get; set; }
        public string svg_shape { get; set; }

    }
}