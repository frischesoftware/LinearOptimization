<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solver.aspx.cs" Inherits="LinearOptimizationGame.Pages.solver" %>

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
                    <h3>Using the Solver</h3>
                    The best way to solve




                    <div class="row">
                        In the above example, we can formulate an objective function.
              <br />
                        P = 1a + 2b
              <br />
                        We also have constraints:<br />
                        a <= 40<br />
                        b <= 50<br />
                        a >= 0<br />
                        b >= 0<br />

                    </div>
                    <div class="row">
                        <img src="../Images/intro/solver1.png" />
                    </div>
                    <div class="row">
                        <img src="../Images/intro/solver2.png" />

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
