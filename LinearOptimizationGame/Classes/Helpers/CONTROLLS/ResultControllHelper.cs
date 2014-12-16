using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace LinearOptimizationGame.Classes.Helpers.CONTROLLS
{
    public class ResultControllHelper
    {
        public void CreateControlForResult(Problem _p, Control AddToControl)
        {
            
                HtmlGenericControl div_result = CommonControlHelpers.makeCtrl("card", 360, "");

                    HtmlGenericControl DivControl = CommonControlHelpers.makeCtrl("cell", 360, "");

                    HtmlGenericControl DivHeadline = CommonControlHelpers.makeCtrl("cell-top", 360, "Result");
                    HtmlGenericControl DivBody = CommonControlHelpers.makeCtrl("cellbottom", 360, "");
                        
                        if (_p.result == "Optimal")
                        {
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 360, _p.ending_optimal));
                        }
                        else if (_p.result == "Suboptimal")
                        {
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 360, _p.ending_suboptimal));
                        }
                        else if (_p.result == "Infeasible")
                        {
                            DivBody.Controls.Add(CommonControlHelpers.makeCtrl("cell-left", 360, _p.ending_infeasible));   
                        }

                    DivControl.Controls.Add(DivHeadline);
                    DivControl.Controls.Add(DivBody);
                div_result.Controls.Add(DivControl);
                AddToControl.Controls.Add(div_result);

        }
        
    }
}