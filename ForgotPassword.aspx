<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

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
    <div>
        <asp:Label ID="lblUserDetails" runat="server" Text="Label"></asp:Label> <br />
        <table style="margin:auto;border:5px solid white; vertical-align:central">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="UserName: "></asp:Label></td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUserName" runat="server" Width="228px"></asp:TextBox></td>
            </tr>
         
             <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style1">
                 <asp:Button ID="btnReset" runat="server" Text="Reset Password" Width="113px" OnClick="btnReset_Click" />
                 <asp:Button ID="btnLogin" runat="server" Text="Login" Width="113px" OnClick="btnLogin_Click"/></td>
            </tr>
                 
        </table> 
               <asp:Label ID="lblMsg" runat="server"></asp:Label>   
    </div>
    </form>
</body>
</html>
