<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="learn.aspx.cs" Inherits="LinearOptimizationGame.Pages.Learn" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Linear-Optimization.com - Learn</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/site.css" rel="stylesheet" />
    <link href="../Content/1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

       <div class="container container_additions">
            <uc1:Header runat="server" ID="Header" />
            <div class="row"></div>
            <div class="row marketing">

                <div class="col-lg-5" style="margin: 25px;">
                    Chose one of the topics
                    <br /><br />
                     <h4><a href="../Pages/introduction.aspx">Introduction</a></h4>
                    <p>
                           No idea what this is about? Take this intuitive introduction
                    </p>

                    <h4><a href="../Pages/graphical.aspx">Graphical Solution</a></h4>
                    <p>
                        A Linear Optimization problem can be shown as a series of graphs in a diagram.
                    </p>
                    
                    <h4><a href="../Pages/simplex.aspx">The Simples Algorithm</a></h4>
                    <p>
                        Coming soon: a tutorial on the Simplex Algorithm.
                    </p>

                    <h4><a href="../Pages/solver.aspx">The Solver</a></h4>
                    <p>
                       The best way to solve Linear Optimization problems is to use the Solver plugin
                        for Microsoft Excel or Libreoffice Calc.
                    </p>
                </div>
            </div>

        </div>

    </form>
</body>
</html>
