<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:wheat;
        }
       
        .auto-style1 {
            width: 186px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    <table style="margin:auto;border:5px solid white; vertical-align:central">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="UserName: "></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="txtUserName" runat="server" Width="178px"></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label></td>
            <td class="auto-style1"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="177px"></asp:TextBox></td>
        </tr>
         <tr>
            <td></td>
            <td class="auto-style1">
             <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="64px" /></td>
        </tr>
        <tr>
            <td><asp:linkbutton runat="server" ID="btnForgotPassword" OnClick="btnForgotPassword_Click">Forgot Password?</asp:linkbutton>
            </td>
            <td class="auto-style1">
             <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></td>
        </tr>
    </table>    
    </div>
    </form>
</body>
</html>
