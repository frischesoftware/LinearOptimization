<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="LinearOptimizationGame.Header" %>

<header role="banner">
        <div role="banner" style="margin: 0 7.6%;">
            <div>
                <div id="site-title">
                    <a href="../pages/home.aspx" title="Linear Optimization Logo" rel="home">
                        <img src="../Images/intro/lo5.png" style="max-width:100%; height:auto" />
                    </a>
                </div>
                <div id="site-description">Interactive Linear Optimization training</div>
            </div>

        </div>
        <nav id="access" role="navigation">

            <div class="menu-menu_header-container">

                <ul class="menu" id="menu-menu_header">
                    <li class=""><a href="../Pages/home.aspx">Home</a></li>
                    <li class=""><a href="../Pages/tutorial.aspx">The Tutorial</a></li>
                    <li class="" id=""><a href="../Pages/learn.aspx">Learn</a> <%--current-menu-item--%>
                        <ul class="sub-menu">
                            <li class="" id="Li1"><a href="../Pages/introduction.aspx">Introduction</a></li>
                            <li class="" id="Li2"><a href="../Pages/graphical.aspx">Graphical Solution</a></li>
                            <%--current-menu-item--%>
                            <li class="" id="Li3"><a href="../Pages/simplex.aspx">Simplex Algorithm</a></li>
                            <li class="" id="Li4"><a href="../Pages/solver.aspx">Solver</a></li>
                        </ul>
                    </li>

                    <li class=""><a href="../Pages/about.aspx">About</a></li>
                </ul>
            </div>
        </nav>
  
</header>
