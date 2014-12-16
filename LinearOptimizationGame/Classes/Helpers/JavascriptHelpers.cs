using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinearOptimizationGame.Helpers
{
    public class JavascriptHelpers
    {
        public string KnapsackJavascript(Problem p)
        {
            // variable "usedWeight": summiere alle "textbox"-Eingaben *"weights" auf und schreibe in Zelle
            string transferString = " var App = angular.module('myApp', []); " +
              "App.controller('MainCtrl', function ($scope) { ";


         //   transferString += " $scope.elements = new Array(); "; // Elements clientside

            transferString += "$scope.qty = { ";
            foreach (var item in p.knapsackElements)                             
            {
                transferString += "'" + item.name + "':'0', ";
            }
            transferString += " };";

            transferString += "$scope.weight = { ";
            foreach (var item in p.knapsackElements)                            
            {
                transferString += "'" + item.name + "':'" + item.weight + "', ";
            }
            transferString += " };";

            transferString += "$scope.value = { ";
            foreach (var item in p.knapsackElements)                            
            {
                transferString += "'" + item.name + "':'" + item.value + "', ";
            }
            transferString += " };";




            foreach (var item in p.knapsackElements)  // alle Watcher                               
            {
                transferString += " $scope." + item.name + " = 0; ";  // initialisiern
                transferString += "   $scope.$watch('" + item.name + "', function (newValue, oldValue) { ";
                   transferString += " updateQty();";
                   transferString += " getUsedCap();";
                   transferString += " getTotalValue();";                
                transferString += " }); ";
            }

            transferString += " function updateQty() { ";
                foreach (var item in p.knapsackElements)
                {
                    transferString += "$scope.qty['" + item.name + "'] =  $scope." + item.name + ";";
                }
            transferString += " };";

            transferString += " function getUsedCap() { ";
                transferString += " $scope.usedCap = 0;";
                foreach (var item in p.knapsackElements)
                {
                    transferString += "$scope.usedCap = parseInt($scope.usedCap) + (parseInt($scope.qty['" + item.name + "']) * parseInt($scope.weight['" + item.name + "']));";
                }
            transferString += " };";

            transferString += " function getTotalValue() {";
            transferString += " $scope.totalValue = 0;";
                foreach (var item in p.knapsackElements)
                {
                    transferString += "$scope.totalValue = parseInt($scope.totalValue) + (parseInt($scope.qty['" + item.name + "']) * parseInt($scope.value['" + item.name + "']));";                    
                }
            transferString += " };";



            transferString += " });";
            return transferString;

        }

        public string ProductionJavascript(Problem p)
        {
            string transferString = " var App = angular.module('myApp', []); " +
              "App.controller('MainCtrl', function ($scope) {";            
            foreach (var item in p.elements)
            {
                if (item.requires != null)
                {
                    transferString += " $scope." + item.name + " = '" + item.userAnswer + "';";  // initialisiern, war "0";
                    transferString += "    $scope.$watch('" + item.name + "', function (newValue, oldValue) { ";
                    String _tempstr = "";
                    foreach (var req in item.requires)  // C: requires a und b, also jeweils für a und b:
                    {
                        _tempstr += "$scope." + req.Key.name + " = ";
                        foreach (var u in req.Key.usedIn)  // a used in C und D. b used in C und D.
                        {
                            _tempstr += u.Value + " * parseInt($scope." + u.Key.name + ") ";
                            _tempstr += "+";
                        }
                        _tempstr += "parseInt(0); ";
                    }
                    transferString += _tempstr;
                    transferString += "    }); ";
                }
            }
          //  transferString += "var draw = SVG('Product').size(9, 9); var rect = draw.rect(9, 9).attr({ fill: '#a06' });var draw = SVG('Product').size(9, 9);var rect = draw.rect(9, 9).attr({ fill: '#a06' });var draw = SVG('Product').size(9, 9);var rect = draw.rect(9, 9).attr({ fill: '#a06' });";
            // Grafiken
            
            foreach (var item in p.elements)
            {
                if (item.requires.Count > 0)
                {
                    transferString += "var draw = SVG('" + item.name.ToString() + "').size(9, 9);";
                    transferString += "var rect = draw." + item.svg_shape + "(9, 9).attr({ fill: '" + item.svg_color + "' }); ";

                    foreach (var r in item.requires)
                    {
                        transferString += "var draw = SVG('bom_" + item.name + "_" + r.Key.name.ToString() + "').size(9, 9);";
                        transferString += "var rect = draw." + r.Key.svg_shape + "(9, 9).attr({ fill: '" + r.Key.svg_color + "' }); ";    
                    }                    
                    }

                transferString += "var draw = SVG('inv_" + item.name.ToString() + "').size(9, 9);";
                transferString += "var rect = draw." + item.svg_shape + "(9, 9).attr({ fill: '" + item.svg_color + "' }); ";
            }
            



            transferString += "}); ";
            return transferString;
        }
    }
}

//"$scope.$watch('C', function (newValue, oldValue) { " +
//    "$scope.a = 6 * parseInt($scope.C) + 4 * parseInt($scope.D); " +
//    "$scope.b = 1 * parseInt($scope.C) + 2 * parseInt($scope.D); " +
//"}); " +
