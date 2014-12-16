<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start2.aspx.cs" Inherits="LinearOptimizationGame.start2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="myApp">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Linear Optimization Game</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/angular.js"></script>
    <link href="Content/site.css" rel="stylesheet" />
    <link href="Content/1.css" rel="stylesheet" />

    <script>
        $('#sites input:radio').addClass('input_hidden');
        $(document).on('click', '#sites label', function () {
            $(this).addClass('selected').siblings().removeClass('selected');
        });
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
</head>
<body ng-controller="MainCtrl">
    <form id="form1" runat="server" autocomplete="off">
        <div class="container">
            <div id="page">
                <%--weisser rahmen--%>
                <header id="branding" role="banner">
                    <hgroup>
                        <div id="site-title">
                            <a rel="home" title="SQL" href="http://sql.sh/">
                                <img width="245" height="63" alt="SQL" src="http://sql.sh/wp-content/themes/sql_sh/img/sql-sh-logo-245.png">
                            </a>
                        </div>
                        <div id="site-description">The ultimative Linear Optimization Course</div>
                    </hgroup>


                    <nav role="navigation" id="access">
                        <h3 class="assistive-text">Menu principal</h3>
                        <div class="skip-link"><a title="Aller au contenu" href="#content" class="assistive-text">Aller au contenu</a></div>
                        <div class="menu-menu_header-container">
                            <ul class="menu" id="menu-menu_header">
                                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="home.aspx">Home</a></li>
                                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="intro1.aspx">Introduction</a>
                                </li>
                                <li class="menu-item menu-item-type-post_type menu-item-object-page"><a href="techniques.aspx">Techniques</a></li>
                                <li class="menu-item menu-item-type-custom menu-item-object-custom current-menu-item"><a href="start2.aspx">The Challenge</a></li>
                            </ul>
                        </div>
                    </nav>
                    <p>
                        Use your knowledge and your own tools to solve a series of linear optimization problems with increasing difficulty.
                    </p>
                </header>


                <div class="row">
                    <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="min-width: 160px">
                        <div id="div_mission" runat="server">
                        </div>
                        <div id="div_userDataEntry" runat="server">
                        </div>
                        <div id="a6" runat="server">
                            <asp:Button ID="OrderProduction" runat="server" class="btn btn-primary" Text="Order Production" OnClick="OrderProduction_Click"
                                OnClientClick="collectValues" />
                            <asp:Button ID="btnStartNewGame" runat="server" class="btn btn-primary" Text="Next >>>" OnClick="btnStartNewGame_Click1" />
                            <asp:Button ID="btnTryAgain" runat="server" class="btn btn-primary" Text="Try Again" OnClick="btnStartNewGame_Click1" />
                            <input id="lblWhichGameToStart" style="margin-left: -99999px; position: absolute;" type="text" value="-" runat="server" />
                        </div>
                    </div>
                    <div id="dynamicElements" runat="server" class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                        <%--col-xs-10 col-sm-10 col-md-10 col-lg-10 --%>
                    </div>
                    <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                        <div id="div_challenges" runat="server">
                            <div class="card" style="width: 140px">
                                <div class="cell-top" style="width: 140px">CHALLENGES</div>
                                <div class="cellbottom" style="width: 140px">
                                    <div id="sites" style="height: 30px">
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r1" onclick="lblWhichGameToStart.value = '1'" class="investfield">Production 1</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r2" onclick="lblWhichGameToStart.value = '4'" class="investfield">Knapsack 1</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r3" onclick="lblWhichGameToStart.value = '7'" class="investfield">Production 2</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r4" onclick="lblWhichGameToStart.value = '2'" class="investfield">Knapsack 2</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r5" onclick="lblWhichGameToStart.value = '5'" class="investfield">Production 3</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r6" onclick="lblWhichGameToStart.value = '8'" class="investfield">Knapsack 3</label>
                                        </div>

                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r7" onclick="lblWhichGameToStart.value = '3'" class="investfield">Production 4</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r8" onclick="lblWhichGameToStart.value = '6'" class="investfield">Knapsack 4</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <input class="input_hidden" type="radio" /><label runat="server" id="r9" onclick="lblWhichGameToStart.value = '9'" class="investfield">Production 5</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">

                                            <input class="input_hidden" type="radio" /><label runat="server" id="r10" onclick="lblWhichGameToStart.value = '10'" class="investfield">Knapsack 5</label>
                                        </div>
                                        <div class="cell-left" style="width: 140px">
                                            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Next >>>" OnClick="btnStartNewGame_Click1" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <div id="mainDIV" runat="server">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                    <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    </div>
                    <%--          {{elements}}
                {{qty}}--%>
                    <div id="Div1" class="col-xs-4 col-sm-4 col-md-4 col-lg-4" runat="server">
                        <%--style="width: 200px" --%>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <div id="section4" runat="server">

                        <%--<label class="form-control">Your plan was: </label>
                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>--%>
                    </div>


                </div>
            </div>
        </div>

    </form>

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
