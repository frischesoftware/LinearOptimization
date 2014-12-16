<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="LinearOptimizationGame.Pages.consulting" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Linear Optimization - About</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/site.css" rel="stylesheet" />
    <link href="../Content/1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off" >
        <div class="container container_additions">
            <uc1:Header runat="server" ID="Header" />
            <div class="row"></div>
            <div class="row marketing">
                <div class="col-lg-5" style="margin: 25px">
                    <h4>About this website</h4>
                    <p>
                        This website intends to close the gap between basic textbook samples that are used in
                            class, and real world applications. On the job, a linear optimization problem
                            might not be recognized, or a solution not attempted as the user's skill is often rusty.
                            Large scale problems might seem too intimidating and are left to consultants.
                    </p>
                    <p>
                        
                    </p>
                    <h4>About the Tutorial</h4>
                    <p>
                        This Tutorial generates random Linear Optimization problems (the easier problems have
                            hardcoded); currently Knapsack problems or production planning problems are supported.
                            Later many other problem types and combinations will be added.
                    </p>

                    <p>.</p>


                </div>

                <div class="col-lg-5" style="margin: 25px">
                    <h4>Contact</h4>
                    <p>
                       I hope you found this website useful. If have any questions, suggestions
                        or if you just want to get in contact, drop me a line and I will get back to you.   
                        <br />
                        <img src="../Images/intro/email.png"  width="200" />
                    </p>
                                    
                    <span class="visible-xs">SIZE XS</span>
                    <span class="visible-sm">SIZE SM</span>
                    <span class="visible-md">SIZE MD</span>
                    <span class="visible-lg">SIZE LG</span>
                  <%--  <div class="form-group">
                        <textarea id="ta1" runat="server" spellcheck="false" rows="3"></textarea>
                        <div class="col-md-8" style="padding-left: 0px; padding-right: 0px">
                            <input runat="server" spellcheck="false" type="email" class="form-control" id="inputEmail" placeholder="Email" />
                        </div>
                        <div class="col-md-4" >                                                         
                            <asp:Button ID="btnSendEmail" runat="server" style="float:right" Text="Send" OnClick="btnSendEmail_Click1" />
                        </div>
                    </div>--%>
                   
                   
                </div>
                <style>
                    @media(max-width:767px) {
                    }

                    @media(min-width:768px) {
                    }

                    @media(min-width:992px) {
                    }

                    @media(min-width:1200px) {
                    }
                </style>










            </div>


            <div class="footer" style="margin: 25px; color: #7a7a7a;">
                <p>&copy; Linear-Optimization.com 2014</p>
            </div>

        </div>
    </form>
</body>
</html>
