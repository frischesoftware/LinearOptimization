using LinearOptimizationGame.Classes.BasicClasses.KNAPSACK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LinearOptimizationGame.Helpers;

namespace LinearOptimizationGame.Classes.Helpers.CONTROLLS
{
    public class KnapsackControlGenerationHelper
    {     
        public void CreateControlForKnapsack_Backpack(String _headline, String _capacity, Control _dynamicElements)
        {
            HtmlGenericControl div_knapsackBackpack = CommonControlHelpers.makeCtrl("card", 165, "");

            HtmlGenericControl DivHeadline = CommonControlHelpers.makeCtrl("cell-top", 165, "");         
            DivHeadline.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-left", 135, "The Backpack"));
            DivHeadline.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-right", 30, ""));




            HtmlGenericControl DivBody = CommonControlHelpers.makeCtrl("cellbottom", 165, "");

                DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 100, "Capacity"));
                DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 65, _capacity));

                DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left-orange", 100, "used Cap."));
                DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left-orange", 65, "{{usedCap}}"));

                DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 100, "total value"));
                DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 65, "{{totalValue}}"));



            div_knapsackBackpack.Controls.Add(DivHeadline);
            div_knapsackBackpack.Controls.Add(DivBody);

            _dynamicElements.Controls.Add(div_knapsackBackpack);
        }

        internal void CreateControlForKnapsack_BigTable(String _headline, Problem p_static, HtmlGenericControl _dynamicElements)
        {
            HtmlGenericControl div_inventory = CommonControlHelpers.makeCtrl("card", 265, "");  // Breite festlegen

                HtmlGenericControl DivControl = CommonControlHelpers.makeCtrl("cell", 265, ""); // das komplette Control

                    HtmlGenericControl DivHeadline = CommonControlHelpers.makeCtrl("_cell-top", 265, "");  // dunkelblaue Überschriftszeile
                        DivHeadline.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-left", 235, "Inventory"));
                        DivHeadline.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-right", 30, ""));

                    HtmlGenericControl DivBody = CommonControlHelpers.makeCtrl("cellbottom", 265, "");

                        DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 75, "Name"));
                        DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, "weight"));
                        DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, "value"));
                        DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, "Inv."));
                        DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left-orange", 55, "select"));
            
                        foreach (var item in p_static.knapsackElements)
                        {
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 75, item.name));
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, item.weight.ToString()));
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, item.value.ToString()));
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, item.inventory.ToString()));
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left-orange", 55, "{{" + item.name + "}}"));
                        }

            DivControl.Controls.Add(DivHeadline);
            DivControl.Controls.Add(DivBody);

            div_inventory.Controls.Add(DivControl);
            _dynamicElements.Controls.Add(div_inventory);                        
        }    
    }
}