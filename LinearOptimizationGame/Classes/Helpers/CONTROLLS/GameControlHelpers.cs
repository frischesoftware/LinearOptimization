using LinearOptimizationGame.Classes.BasicClasses;
using LinearOptimizationGame.Classes.BasicClasses.KNAPSACK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LinearOptimizationGame.Classes.Helpers.CONTROLLS
{
    public class GameControlHelpers
    {

        internal void CreateAnswerTextboxes(Problem _p, Control addToControl)
        {
            HtmlGenericControl DivUserInput = CommonControlHelpers.makeCtrl("card", 160, "");

            HtmlGenericControl DivHeadline = CommonControlHelpers.makeCtrl("cell-top", 160, "");
                DivHeadline.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-left", 160, "Enter Decision"));

            HtmlGenericControl DivBody = CommonControlHelpers.makeCtrl("cellbottom", 160, "");

            if (_p.problemType == "KNAPSACK")
            {
                foreach (var item in _p.knapsackElements)
                {
                    if (item.isAnswer == true)
                    {
                        DivBody.Controls.Add(KnapsackCreateAnswerTextbox(item, DivBody));
                    }
                }
            }
            else if (_p.problemType == "PRODUCTION")
            {
                foreach (var item in _p.elements)
                {                   
                    if (item.isAnswer == true)
                    {                        
                        DivBody.Controls.Add(CreateProductionAnswerTextbox(item, DivBody));                     
                    }                    
                }
            }

            DivUserInput.Controls.Add(DivHeadline);
            DivUserInput.Controls.Add(DivBody);
            addToControl.Controls.Add(DivUserInput);
        }
        private HtmlGenericControl CreateProductionAnswerTextbox(Element _answerTo, Control addToControl)
        {

            HtmlGenericControl DivBodyLine = CommonControlHelpers.makeCtrl("cell-left", 160, "");

                Label l = new Label()
                {
                    Text = _answerTo.name,
                    CssClass = "form-control"
                };

                TextBox t = new TextBox();
                t.Attributes.Add("Style", "color : #FF6A00; padding-left: 12px");
                t.Attributes.Add("class", "form-control");
                t.Attributes.Add("ng-model", _answerTo.name);
                t.ID = "Textbox_" + _answerTo.name;

                RegularExpressionValidator regVali = new RegularExpressionValidator();
                regVali.ValidationExpression = "^([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|[1-3][0-9][0-9][0-9][0-9])$";
                regVali.ErrorMessage = "doesn't match";
                regVali.ControlToValidate = t.ID;

          
            DivBodyLine.Controls.Add(l);
            DivBodyLine.Controls.Add(t);
            DivBodyLine.Controls.Add(regVali);
           // DivBodyLine.Controls.Add(rangeVali);
            return DivBodyLine;
        }
        private HtmlGenericControl KnapsackCreateAnswerTextbox(KnapsackElement _answerTo, Control addToControl)
        {
            HtmlGenericControl DivBodyLine = CommonControlHelpers.makeCtrl("cell-left", 160, "");
            Label l = new Label()
          {
              Text = _answerTo.name,
              CssClass = "form-control"
          };
            TextBox t = new TextBox();


            t.Attributes.Add("Style", "color : #FF6A00; padding-left: 12px");
            t.Attributes.Add("class", "form-control");
            t.Attributes.Add("ng-model", _answerTo.name);
            t.ID = "Textbox_" + _answerTo.name;

            RegularExpressionValidator regVali = new RegularExpressionValidator();
            regVali.ValidationExpression = "^([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|[1-3][0-9][0-9][0-9][0-9])$";
            regVali.ErrorMessage = "doesn't match";
            regVali.ControlToValidate = t.ID;

            DivBodyLine.Controls.Add(l);
            DivBodyLine.Controls.Add(t);
            DivBodyLine.Controls.Add(regVali);

            return DivBodyLine;
        }

        //public void CreateListOfChallenges(Control _control, Problem _p)
        //{
        //    int totalWidth = 160;
        //    // ************ List Of Challenges **************
        //    HtmlGenericControl divChallenges = CommonControlHelpers.makeCtrl("card", totalWidth, "");

        //        HtmlGenericControl divChallengesHeadline = CommonControlHelpers.makeCtrl("cell-top", totalWidth, "CHALLENGES");
        //        HtmlGenericControl divChallengesBody = CommonControlHelpers.makeCtrl("cellbottom", totalWidth, "");

        //            HtmlGenericControl div1 = CommonControlHelpers.makeChallenge("cell-left", totalWidth, "Production 1", 1);
        //            HtmlGenericControl div2 = CommonControlHelpers.makeChallenge("cell-left", totalWidth, "Knapsack 1", 2);
        //            HtmlGenericControl div3 = CommonControlHelpers.makeChallenge("cell-left", totalWidth, "Production 2", 3);

        //            divChallengesBody.Controls.Add(div1);
        //            divChallengesBody.Controls.Add(div2);
        //            divChallengesBody.Controls.Add(div3);

        //        divChallenges.Controls.Add(divChallengesHeadline);
        //        divChallenges.Controls.Add(divChallengesBody);
        //    _control.Controls.Add(divChallenges);
        //}

        public void CreateControlForUSERINFOandMISSION(Control _mission, Problem _p)
        {
            int totalWidth = 160;

            // ************ User **************
            HtmlGenericControl divUserInfo = CommonControlHelpers.makeCtrl("card", totalWidth, "");

            HtmlGenericControl divUserInfoHeadline = CommonControlHelpers.makeCtrl("cell-top", totalWidth, "USER INFO");
            HtmlGenericControl divUserInfoBody = CommonControlHelpers.makeCtrl("cellbottom", totalWidth, "");

            HtmlGenericControl rank = CommonControlHelpers.makeCtrl("cell-left", totalWidth, "Rank: Assistant");
            HtmlGenericControl solved = CommonControlHelpers.makeCtrl("cell-left", totalWidth, "Solved: 0");
            divUserInfoBody.Controls.Add(rank);
            divUserInfoBody.Controls.Add(solved);

            divUserInfo.Controls.Add(divUserInfoHeadline);
            divUserInfo.Controls.Add(divUserInfoBody);


            // Auskommentiert, da es aktuell keine Statistik/Punkte etc. gibt
           // _mission.Controls.Add(divUserInfo);


            // ************ Mission **************
            HtmlGenericControl divMission = CommonControlHelpers.makeCtrl("card", totalWidth, "");

            HtmlGenericControl DivHeadline = CommonControlHelpers.makeCtrl("cell-top", totalWidth, "");
            DivHeadline.Controls.Add(CommonControlHelpers.makeCtrl("cell-top-left", totalWidth, "MISSION"));

            HtmlGenericControl DivBody = CommonControlHelpers.makeCtrl("cellbottom", totalWidth, "");

            HtmlGenericControl pp = CommonControlHelpers.makeCtrl("cell-left", totalWidth, _p.problemType);
            HtmlGenericControl txt = CommonControlHelpers.makeCtrl("cell-left", totalWidth, _p.aufgabenstellung);

            DivBody.Controls.Add(pp);
            DivBody.Controls.Add(txt);

            divMission.Controls.Add(DivHeadline);
            divMission.Controls.Add(DivBody);

            _mission.Controls.Add(divMission);

            // ************** User Data Entry **************
            HtmlGenericControl divUserEntry = CommonControlHelpers.makeCtrl("card", totalWidth, "");

        }

        internal void CreateStory(HtmlGenericControl dynamicElements, Problem _p)
        {
            int totalWidth = 520;
            HtmlGenericControl divMission = CommonControlHelpers.makeCtrl("card", totalWidth, "");

                HtmlGenericControl DivHeadline = CommonControlHelpers.makeCtrl("cell-top", totalWidth, "STORY");
                HtmlGenericControl DivBody = CommonControlHelpers.makeCtrl("cellbottom", totalWidth, "");

                    HtmlGenericControl pp = CommonControlHelpers.makeCtrl("cell-left", totalWidth, _p.story);
                    DivBody.Controls.Add(pp);

                divMission.Controls.Add(DivHeadline);
                divMission.Controls.Add(DivBody);
            dynamicElements.Controls.Add(divMission);
        }
    }
}