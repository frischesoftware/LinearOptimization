<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tutorial.aspx.cs" Inherits="LinearOptimizationGame.start2" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="myApp">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Linear Optimization Game</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/angular.js"></script>
    <link href="../Content/site.css" rel="stylesheet" />
    <link href="../Content/1.css" rel="stylesheet" />
    <script src="../Scripts/svg/svg.min.js"></script>

    <script>
        $('#sites input:radio').addClass('input_hidden');
        $(document).on('click', '#sites label', function () {
            $(this).addClass('selected').siblings().removeClass('selected');
        });
    </script>
    <script>
        function myValidate() {
            if (Page_ClientValidate()) {
                return true
            }
            else {
                return false
            }
        }
    </script>
    <style>
        .hov:hover {
            background: #f9f9f9;
            background: -moz-linear-gradient(#f9f9f9,#e5e5e5);
            background: -o-linear-gradient(#f9f9f9,#e5e5e5);
            background: -webkit-gradient(linear,0% 0,0% 100%,from(#f9f9f9),to(#e5e5e5));
            background: -webkit-linear-gradient(#f9f9f9,#e5e5e5);
            color: #373737;
        }

        .selected {
            background-color: #a01717;
        }
    </style>
    <style>
        .sidebar-nav {
            padding: 9px 0;
        }

        .row-fluid > .sidebar-nav {
            position: relative;
            top: 0;
            left: auto;
            width: 180px;
        }

        .left {
            float: left;
        }

        .right {
            float: right;
        }

        .fixed-fluid {
            margin-left: 180px;
        }

        .fluid-fixed {
            margin-right: 180px;
            /*margin-left: auto !important;*/
            margin-left: 180px;
        }

        .fixed-fixed {
            margin: 0 180px;
        }
    </style>
</head>
<body ng-controller="MainCtrl">
    <form id="form1" runat="server" autocomplete="off">
        <div class="container">
            <div id="page">
                <uc1:Header runat="server" ID="Header" />

                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="_well sidebar-nav left" style="margin-top: -14px">
                            <div id="div_mission" runat="server">
                            </div>
                            <div id="div_userDataEntry" runat="server">
                            </div>
                            <div id="a6" runat="server">
                                <asp:Button ID="OrderProduction" runat="server" class="greyButton" Text="Order Production" OnClick="btnOrderProduction_Click" CausesValidation="true" />
                                <asp:Button ID="btnStartNewGame" runat="server" class="greyButton" Text="Next >>>" OnClick="btnStartNewGame_Click1" Style="width: 120px" /><%-- btn btn-primary--%>
                                <asp:Button ID="btnTryAgain" runat="server" class="greyButton" Text="Try Again" OnClick="btnStartNewGame_Click1" />
                                <input id="lblWhichGameToStart" style="margin-left: -99999px; position: absolute;" type="text" value="-" runat="server" />
                            </div>
                        </div>

                        <div class="_well sidebar-nav right" style="padding-left: 20px; margin-top: -14px">
                            <div id="div_challenges" runat="server" style="margin-left: 0px;">
                                <div class="card" style="width: 160px;">
                                    <div class="cell-top" style="width: 160px;">
                                        <div class="cell-top-left" style="width: 160px;">
                                            CHALLENGES
                                        </div>
                                    </div>
                                    <div class="cellbottom" style="width: 160px">
                                        <div id="sites" style="height: 30px">
                                            <div class="cell-left" style="width: 160px">
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r1" onclick="lblWhichGameToStart.value = '1'" class="investfield">Production 1</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r2" onclick="lblWhichGameToStart.value = '2'" class="investfield">Knapsack 1</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r3" onclick="lblWhichGameToStart.value = '3'" class="investfield">Production 2</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r4" onclick="lblWhichGameToStart.value = '4'" class="investfield">Knapsack 2</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r5" onclick="lblWhichGameToStart.value = '5'" class="investfield">Production 3</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r6" onclick="lblWhichGameToStart.value = '6'" class="investfield">Random Production</label>
                                                <%--                                                <input class="input_hidden" type="radio" /><label runat="server" id="r7" onclick="lblWhichGameToStart.value = '7'" class="investfield">Production 4</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r8" onclick="lblWhichGameToStart.value = '8'" class="investfield">Knapsack 4</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r9" onclick="lblWhichGameToStart.value = '9'" class="investfield">Production 5</label>
                                                <input class="input_hidden" type="radio" /><label runat="server" id="r10" onclick="lblWhichGameToStart.value = '10'" class="investfield">Knapsack 5</label>--%>
                                                <asp:Button ID="Button1" runat="server" Text="Start Scenario" OnClick="btnStartNewGame_Click1" class="greyButton" />
                                                <%--class="btn btn-primary" --%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="story content fluid-fixed" style="margin-left: 180px;">
                            <div style="padding-top: 9px">
                                <div>STORY</div>
                                <div class="_cellbottom">
                                    <div id="div_story" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="dynamicElements" class="content fluid-fixed" runat="server">
                    </div>
                </div>
                <div id="mainDIV" runat="server">
                </div>
            </div>
        </div>
    </form>
    <script>

        //$('.aaa').each(function () {        
        //    var draw = SVG($(this)[0].id).size(9,9);
        //    var rect = draw.rect(10, 10);
        //SVG($(this)).size(size(9, 9)).draw.ellipse(9, 9).attr({ fill: 'black' });
        //  });

        /*
        var draw = SVG('inv_Part_A').size(9, 9);
        var rect = draw.ellipse(9, 9).attr({
            fill: 'green'
        });
        var draw = SVG('inv_Part_B').size(9, 9);
        var rect = draw.rect(9, 9).attr({
            fill: 'blue'
        });
        var draw = SVG('Product').size(9, 9);
        var rect = draw.rect(9, 9).attr({
            fill: 'yellow'
        });
        var draw = SVG('bom_Part_A').size(9, 9);
        var rect = draw.rect(9, 9).attr({
            fill: 'yellow'
        });
        var draw = SVG('inv_Product').size(9, 9);
        var rect = draw.rect(9, 9).attr({
            fill: 'yellow'
        });
        */
    </script>
    <script type="text/javascript">

        //var App = angular.module('myApp', []);
        //App.controller('MainCtrl', function ($scope) {
        //    $scope.$watch('C', function (newValue, oldValue) {
        //        $scope.a = 6 * parseInt($scope.C) + 4 * parseInt($scope.D) + parseInt(0);
        //        $scope.b = 1 * parseInt($scope.C) + 2 * parseInt($scope.D) + parseInt(0);
        //    });
        //    $scope.$watch('D', function (newValue, oldValue) {
        //        $scope.a = 6 * parseInt($scope.C) + 4 * parseInt($scope.D) + parseInt(0);
        //        $scope.b = 1 * parseInt($scope.C) + 2 * parseInt($scope.D) + parseInt(0);
        //    });
        //    $scope.$watch('EE', function (newValue, oldValue) {
        //        $scope.C = 2 * parseInt($scope.EE) + 1 * parseInt($scope.FF) + parseInt(0);
        //        $scope.D = 1 * parseInt($scope.EE) + 2 * parseInt($scope.FF) + parseInt(0);
        //    });
        //    $scope.$watch('FF', function (newValue, oldValue) {
        //        $scope.C = 2 * parseInt($scope.EE) + 1 * parseInt($scope.FF) + parseInt(0);
        //        $scope.D = 1 * parseInt($scope.EE) + 2 * parseInt($scope.FF) + parseInt(0);
        //    });
        //});












        //var App = angular.module('myApp', []);

        //App.controller('MainCtrl', function ($scope) {
        //    $scope.$watch('C', function (newValue, oldValue) {
        //        $scope.a = 6 * parseInt($scope.C)
        //        $scope.b = 1 * parseInt($scope.C)
        //    });
        //});



        //var App = angular.module('myApp', []);

        //  App.controller('MainCtrl', function ($scope) {
        //    $scope.C = function () {
        //        2 * parseInt($scope.EE) + 1 * parseInt($scope.FF)
        //    }
        //    $scope.D = 44
        //    $scope.$watch("EE", function (newValue, oldValue) {                
        //        $scope.C = 2 * parseInt($scope.EE) + 1 * parseInt($scope.FF)
        //        $scope.D = 1 * parseInt($scope.EE) + 2 * parseInt($scope.FF)                                                   
        //    });
        //    $scope.$watch("FF", function (newValue, oldValue) {
        //        $scope.C = 2 * parseInt($scope.EE) + 1 * parseInt($scope.FF)
        //        $scope.D = 1 * parseInt($scope.EE) + 2 * parseInt($scope.FF)
        //    });

        //    $scope.$watch("C", function (newValue, oldValue) {
        //        $scope.a = 6 * parseInt($scope.C) + 4 * parseInt($scope.D)
        //        $scope.b = 1 * parseInt($scope.C) + 2 * parseInt($scope.D)
        //    });
        //    $scope.$watch("D", function (newValue, oldValue) {
        //        $scope.a = 6 * parseInt($scope.C) + 4 * parseInt($scope.D)
        //        $scope.b = 1 * parseInt($scope.C) + 2 * parseInt($scope.D)
        //    });

        //})
    </script>
</body>

</html>
