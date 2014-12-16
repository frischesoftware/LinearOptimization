<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="introduction.aspx.cs" Inherits="LinearOptimizationGame.intro1" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Linear Optimization Game</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/site.css" rel="stylesheet" />
    <link href="../Content/1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="page">
            <uc1:Header runat="server" ID="Header" />
            <div class="container">
                <div class="starter-template">
                    <br />
                    <h3>Manually optimize simple scenarios</h3>
                    This page introduces optimization problems by looking at really simple problems that can be
                    solved without math. Just read through each problem, understand it and figure out the solution.
                    <br />
                    <br />
                    <h4>1. One Decision, no constraint</h4>
                    <p class="_lead">
                        Imagine your company has 1 Machine, producing Widgets with a profit of 5 per Widget. 
                        What is the perfect production plan?
                    </p>
                    <div class="card">
                        <div class="cell-top">Profit</div>
                        <div class="cellbottom">
                            <div class="cell-left">Widget</div>
                            <div class="cell-right">5</div>
                        </div>
                    </div>
                    <div class="row"></div>
                    <p>
                        <strong>Answer:</strong> Optimum solution is of course to make "infinite" widgets!
                        <br />
                        (How can it be infinite? Because there are no restraints in this text problem.)
                    </p>


                    <h4>2. Two Products, no contraints</h4>
                    <p>
                        Let's say we can make 2 products with different profit. 
                    Profit is 5 for Widget A and 7 for Widget B. We can make a maximum of 100 total. 
                    What product combination is the most profitable?
                    </p>
                    <div class="card">
                        <div class="cell-top">Profit</div>
                        <div class="cellbottom">
                            <div class="cell-left">Widget A</div>
                            <div class="cell-right">5</div>
                            <div class="cell-left">Widget B</div>
                            <div class="cell-right">7</div>
                        </div>
                    </div>
                    <div class="row"></div>
                    <p>
                        <strong>Answer:</strong> We should make 100 of Widget B and 0 of Widget A.
                    </p>

                    <h4>3. Build Widgets from limited Components</h4>
                    We want to produce as many Widgets as possible. One Widget requires 1 Component A and 2 Component B.
              We have 40 Component A and 50 Component B in stock. How many Widgets can we make?
            <div class="row"></div>
                    <div class="card">
                        <div class="cell-top">Inventory</div>
                        <div class="cellbottom">
                            <div class="cell-left">Component A</div>
                            <div class="cell-right">40</div>
                            <div class="cell-left">Component B</div>
                            <div class="cell-right">50</div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="cell-top">Bill of Materials: Widget</div>
                        <div class="cellbottom">
                            <div class="cell-left">Component A</div>
                            <div class="cell-right">1</div>
                            <div class="cell-left">Component B</div>
                            <div class="cell-right">2</div>
                        </div>
                    </div>
                    <div class="row"></div>
                    <p>
                        <strong>Answer:</strong> We have enough Component As to make 40 Widgets, but the 50 Component Bs last for only 25.
                         Therefore the maximum quantity is 25.
                    </p>
                    <p>
                        More complicated problems may require using a linear programming algorithm like Simplex. A practical solution
                        would be to use the Solver Plugin provided by MS Excel or Libre Office Calc.
                    </p>
                </div>
            </div>
            <!-- /.container -->
        </div>

    </form>
</body>
</html>
