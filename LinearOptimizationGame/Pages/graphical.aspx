<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graphical.aspx.cs" Inherits="LinearOptimizationGame.graphical" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
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
               <%-- <div class="page-header" style="background-color: #eee; padding: 10px">--%>
                    <h2>The Graphical Solution</h2>
                    <p>
                        Our company produces 2 products. 3 machines (A, B, C) are available. A can run for 170 hours per
                        months, B 150 hours and C 180 hours.
                        <br />
                        Product 1 has a profit of 300, Product 2 500 per unit. Goal is to maximize profit by producing these two
                        products. Which product mix is the most profitable combination?
                        <div style="width: 165px" class="card">
                            <div class="cell-top" style="width: 165px">
                                <div class="cell-top-left" style="width: 165px">
                                    Profit per Unit     
                                </div>
                            </div>
                            <div class="cellbottom">
                                <div style="width: 120px" class="cell-left">Product A</div>
                                <div class="cell-right" style="width: 45px">300</div>
                                <div style="width: 120px" class="cell-left">Product B</div>
                                <div class="cell-right" style="width: 45px">500</div>
                            </div>
                        </div>
                        <div class="row">
                        </div>
                        <br />
                        <div>
                            This can be formulated as an equation: max z = 300*x1 + 500*x2
                            <br />
                            z is the goal...

                        </div>

                        Each product needs some time on each machine to be produced.
                        <div class="row"></div>
                        <div style="width: 165px" class="card">
                            <div class="cell-top" style="width: 165px" >
                                <div class="cell-top-left" style="width: 165px" >
                                    Product 1 
                                </div>
                            </div>
                            <div class="cellbottom">
                                <div style="width: 120px" class="cell-left">Machine A</div>
                                <div class="cell-right" style="width: 45px">1</div>
                                <div style="width: 120px" class="cell-left">Machine B</div>
                                <div class="cell-right" style="width: 45px">1</div>
                                <div style="width: 120px" class="cell-left">Machine C</div>
                                <div class="cell-right" style="width: 45px">0</div>
                            </div>
                        </div>
                        <div style="width: 165px" class="card">
                            <div class="cell-top" style="width: 165px" >
                                <div class="cell-top-left" style="width: 165px" >
                                    Product 2 
                                </div>
                            </div>
                            <div class="cellbottom">
                                <div style="width: 120px" class="cell-left">Machine A</div>
                                <div class="cell-right" style="width: 45px">2</div>
                                <div style="width: 120px" class="cell-left">Machine B</div>
                                <div class="cell-right" style="width: 45px">1</div>
                                <div style="width: 120px" class="cell-left">Machine C</div>
                                <div class="cell-right" style="width: 45px">3</div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                        </div>
                        <div>
                            The available time on each machine is limited, therefore the maximum amount of products
                            is also limited. These are "constraints", and can be formulated like this:<br />
                            I)   1*x1 + 2*x2 <= 170 (Machine A)<br />
                            II)  1*x1 + 1*x2 <= 150 (Machine B)<br />
                            III) 0*x1 + 2*x2 <= 180 (Machine C)<br />

                            How to find all constraints?<br />
                            To find these constraints, look at all information given in a text problem: How does this
                            information limit the decision variables (in this case "Product 1" and "Product 2")?
                            There could be other constraints as well: maybe we can only produce / sell a certain number of
                            each product? Maybe the total numbers of products are limited (e.g. due to a constraints on available
                            workers). Each of these is turned into a constraint.
                        </div>
                        <br />
                        <div class="row">
                        </div>
                        <div>
                            To draw the graphical solution, first change the "<=" to "=", as we are interested in the
                            maximum possible values. Then find the intersections with the x1 resp. x2 axis by setting x2 resp. x1
                            to 0.<br />
                            1*x1 + 2*x2 = 170<br />
                            1*x1 + 0 = 170<br />
                            x1 = 170 when x2 is 0<br />
                            and
                            0 + 2*x2 = 170<br />
                            x2 = 85 when x1 is 0<br />
                            Connect the 2 dots to get the black line as shown in the image below. Do the same with all other
                            constraints.
                        </div>
                    </p>
                    <p>
                        <img src="../Images/525px-Linear_programming_polytope.png" />
                    </p>
                    <div class="row">
                    </div>
                    <br />
                    <p>
                        Do the same for the goal function and set it to an arbitrary initial value, e.g. 300 * x1 + 500 * x2 = 10000.
                        This should give you something like the red dotted line in the graphics.
                    </p>
                    <div>
                        The optimal solution must be on a corner, so the solution can be found by checking all the 
                        intersections of two (or more) constraints.
                    </div>
                    <br />
                    <div>
                        Let's check the numbers and convince ourselves that we have a correct answer: 130*x1 and 20*x2 exactly
                        fulfills the constraints  II)  1*x1 + 1*x2 <= 150: 1*130 + 1*20 = 150 and
                        I) 130*x1 + 2*x2 <= 170: 130 + 2*20 = 170.
                        <br />
                        Constraint III is not violated: 3*20 <=180
                        <br />


                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
