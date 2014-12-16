<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="LinearOptimizationGame.home" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Linear-Optimization.com</title>
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
                    <p>
                        If you want to learn learn about Linear Optimization, you've come to the right place.
                    </p>

                    <p>
                        The <a href="../Pages/tutorial.aspx">Tutorial</a> offers various interactive text problems. Solve the problem, submit your
                         solution and get immediate results. You will be able to progress through different of problem types
                         and increasing complexity.
                    </p>
                    <p>
                        You can <a href="../Pages/Learn.aspx">learn</a> about the various ways to solve a Linear Optimization problem:
                        The <a href="../Pages/graphical.aspx">Graphical Solution</a>, the <a href="../Pages/simplex.aspx">Simplex Algorithm</a> or,
                        recommended for solving real-world problems, the <a href="../Pages/solver.aspx">Solver</a>, a plugin for Microsoft
                        Excel / Libreoffice Calc.                        
                    </p>
                    <p>
                        No idea what this is about? Check out this intuitive <a href="../Pages/Introduction.aspx">Introduction</a> to
                        Linear Optimization.
                    </p>

                </div>
            </div>

        </div>

    </form>
</body>
</html>
