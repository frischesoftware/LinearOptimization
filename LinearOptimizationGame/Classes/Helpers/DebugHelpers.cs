using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Helpers
{
    public class DebugHelpers
    {
        public void DisplaySolution(Solution s, String comment)
        {

            System.Diagnostics.Debug.WriteLine(":::::::::::::: solution ::::::::::::::::::::");
            System.Diagnostics.Debug.WriteLine("::: " + comment + " :::");
            foreach (var item in s.Decisions)
            {
                System.Diagnostics.Debug.WriteLine(item.Name + ": " + item.GetDouble().ToString());
            }
            System.Diagnostics.Debug.Write(s.Quality.ToString());
            System.Diagnostics.Debug.Write(s.Goals.First().ToDouble());
            System.Diagnostics.Debug.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::");
        }
    }
}