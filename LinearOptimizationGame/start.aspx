<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="LinearOptimizationGame.start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="myApp">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Linear Optimization Game</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    
    <style type="text/css">        
        .card {
            margin: 5px;
            width: 165px;  /*165 für zweispaltig*/
            float: left;
            /*background-color: #ccc;*/
            margin-bottom: 0px;
            margin-right: 0px;
            position: relative;
        }

        .cell-top {
            height: 30px;
            border-bottom: 1px solid;
            padding: 0px;
            background-color: #B9C9FE;
            border-color: #AABCFE;
            color: #003399;
        }
     
        .cell-left {
            width: 120px;
            padding: 5px;
            float: left;
            background-color: #E8EDFF;
            border-left: 1px solid #AABCFE;
            border-bottom: 1px solid #AABCFE;
            border-right: 1px solid #AABCFE;
            color: #666699;
        }
        .cell-center {
            width: 45px; 
            padding: 5px;
            float: left;
            background-color: #E8EDFF;
            border-bottom: 1px solid #AABCFE;
            color: #ff6a00;
        }

        .cell-right {
            width: 45px;
            padding: 5px;
            float: right;
            background-color: #E8EDFF;
            border-right: 1px solid #AABCFE;
            border-left: 1px solid #AABCFE;
            border-bottom: 1px solid #AABCFE;
            color: #666699;
        }
        cell-withdrawal {
            width: 45px;
            padding: 5px;

            
            border-right: 1px solid #AABCFE;
            border-bottom: 1px solid #AABCFE;
           
            color:palegreen;
        }

        .tg {
            border-collapse: collapse;
            border-spacing: 0;
            border-color: #aabcfe;
        }

            .tg td {
                font-family: Arial, sans-serif;
                font-size: 14px;
                padding: 10px 5px;
                border-style: solid;
                border-width: 0px;
                overflow: hidden;
                word-break: normal;
                border-color: #aabcfe;
                color: #669;
                background-color: #e8edff;
            }

            .tg th {
                font-family: Arial, sans-serif;
                font-size: 14px;
                font-weight: normal;
                padding: 10px 5px;
                border-style: solid;
                border-width: 0px;
                overflow: hidden;
                word-break: normal;
                border-color: #aabcfe;
                color: #039;
                background-color: #b9c9fe;
            }
    </style>
    
</head>
<body ng-controller="MainCtrl">
    <form id="form1" runat="server" autocomplete="off">
        <div class="container">
            {{uwe}}
            <div class="jumbotron">
                <h2>Linear Optimization Game</h2>
                <p>
                    Your mission is to manage human exploration of the universe. Build spaceships, and plan routes and cargo.
                Unfortunately there are rumors or the Crazy Space Monster that likes to eat civilizations. Therefore you will have
                to use Linear Optimization to calculate the optimal solution in each situation.
                </p>
                <p id="goal" runat="server">
                </p>
            </div>

            <div class="row">          
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div id="a5" class="card" runat="server" style="width: 165px">
                       
                    </div>

                    <div id="a1" class="card" runat="server"></div>
                    <div id="a2" class="card" runat="server"></div>
                    <div id="a3" class="card" runat="server"></div>
                    <div id="a4" class="card" runat="server"></div>
                </div>
            </div>



            <div id="mainDIV" runat="server">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <div id="section0" runat="server">
                    </div>
                    <div id="section1" runat="server">
                    </div>
                    <div id="section2" runat="server">
                    </div>
                    <div id="section3" runat="server">
                    </div>
                </div>
                 <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="width:200px" runat="server">
                     <div id="a6" runat="server"></div>
                 </div>
                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                    <div id="section4" runat="server">
                        <h4>Confirm and submit your choice</h4>
                        <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Order Production" OnClick="Button2_Click" />
                        <label class="form-control">Your plan was: </label>
                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/angular.min.js"></script>

    <script type="text/javascript">
      

        var App = angular.module('myApp', []);

        App.controller('MainCtrl', function ($scope) {
            $scope.uwe = "uuuuuuuuu"
        
        })
    </script>


</body>
</html>
