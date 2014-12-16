<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientclicks.aspx.cs" Inherits="LinearOptimizationGame.clientclicks" %>
<html>
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
        function confirmthis() {
            if (Page_ClientValidate()) {
                //  alert("Page_ClientValidate TRUE");
                return true
            }
            else {
                //alert("Page_ClientValidate FALSE");
                return false
            }
            /*
            if (Page_IsValid) {
                alert("is valid");
            }
            else {
                alert("is invalid");
            }
            if (confirm("Do you want to do a server trip?")) {
                return true;
            }
            else {
                return false;
            }
            */
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="return confirmthis();" Text="Click Me…" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="TextBox1"
                ErrorMessage="Last name is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </form>
</body>
</html>
