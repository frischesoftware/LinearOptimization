using LinearOptimizationGame.Classes.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LinearOptimizationGame.Classes.Helpers.CONTROLLS;

namespace LinearOptimizationGame.Scenarios
{
    public class ProductionControllGenerationHelpers
    {
        public  void CreateControlForBoM(string _headline, Dictionary<Element, int> _dictionary, Control addToControl) //, 
        {
            int _totalwidth = 195;
            HtmlGenericControl cardControl = CommonControlHelpers.makeCtrl("card", _totalwidth, "");

            HtmlGenericControl celltop = CommonControlHelpers.makeCtrl("cell-top", _totalwidth, "");

            celltop.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-left", _totalwidth -30, _headline));

                    HtmlGenericControl celltopright = CommonControlHelpers.makeCtrl("cell-top-right", 30, "");
                    celltopright.Attributes.Add("id", _headline.Split(' ')[0]);
                    celltop.Controls.Add(celltopright);


            HtmlGenericControl cellbottom = CommonControlHelpers.makeCtrl("cellbottom", _totalwidth, "");

            foreach (var item in _dictionary)
            {
                cellbottom.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", _totalwidth -45 -30, item.Key.name)); 
                cellbottom.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 45, item.Value.ToString()));

                HtmlGenericControl c = CommonControlHelpers.makeCtrl("cell-right", 30, "");
                c.Attributes.Add("id", "bom_" + _headline.Split(' ')[0] + "_" + item.Key.name.ToString());
                c.Attributes.Add("class", "cell-right aaa");
                cellbottom.Controls.Add(c);
            }


            cardControl.Controls.Add(celltop);
            cardControl.Controls.Add(cellbottom);

            addToControl.Controls.Add(cardControl);            
        }

        public  void CreateControlForGoal(string headline, Control addToControl)
        {
            HtmlGenericControl goal = new HtmlGenericControl("div");
            goal.InnerHtml = headline;
            goal.Attributes.Add("class", "cell-top");
            addToControl.Controls.Add(goal);
        }

        public  void CreateControlForInventory(string _headline, Dictionary<String, int> _dictionary, Control _dynamicElements)
        {
            int _totalwidth = 195;
            HtmlGenericControl div_productionInventory = CommonControlHelpers.makeCtrl("card", _totalwidth, "");

            HtmlGenericControl celltop = CommonControlHelpers.makeCtrl("cell-top", _totalwidth, "");

            celltop.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-left", _totalwidth - 30, _headline));
            celltop.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-right", 30, ""));


            HtmlGenericControl cellbottom = new HtmlGenericControl("div");
            cellbottom.Attributes.Add("class", "cellbottom");

            foreach (var item in _dictionary)
            {
                cellbottom.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 75, item.Key));
                cellbottom.Controls.Add(CommonControlHelpers.makeCtrl("cell-center", 45, "{{" + item.Key + "}}"));
                cellbottom.Controls.Add(CommonControlHelpers.makeCtrl("cell-center", 45, item.Value.ToString()));


                    HtmlGenericControl svgCell = CommonControlHelpers.makeCtrl("cell-right", 30, "");  // add 2 classes
                    svgCell.Attributes.Add("id", "inv_" + item.Key.ToString());
                cellbottom.Controls.Add(svgCell);



            }
            div_productionInventory.Controls.Add(celltop);
            div_productionInventory.Controls.Add(cellbottom);

            _dynamicElements.Controls.Add(div_productionInventory);
        }

   
    }
}