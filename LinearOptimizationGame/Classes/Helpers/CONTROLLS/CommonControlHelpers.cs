using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace LinearOptimizationGame.Classes.Helpers.CONTROLLS
{
    public static class CommonControlHelpers
    {
        public static HtmlGenericControl makeCtrl(string _class, int _width, string _text)
        {
            HtmlGenericControl _div = new HtmlGenericControl("div");
            _div.Attributes.Add("class", _class);
            _div.Attributes.Add("style", "width: " + _width + "px");
            _div.InnerHtml = _text;
            return _div;
        }

        public static HtmlGenericControl makeCtrlNoWidth(string _class, string _text)
        {
            HtmlGenericControl _div = new HtmlGenericControl("div");
            _div.Attributes.Add("class", _class);        
            _div.InnerHtml = _text;
            return _div;
        }

        public static HtmlGenericControl makeChallenge(string _class, int _width, string _text, int _gameToStart)
        {
            HtmlGenericControl _div = new HtmlGenericControl("div");
            _div.Attributes.Add("onclick", "lblWhichGameToStart.value = '" + _gameToStart + "'");
            _div.Attributes.Add("class", _class);
            _div.Attributes.Add("style", "width: " + _width + "px");
            _div.InnerHtml = _text;
            return _div;
        }
    }
}