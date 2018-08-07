<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

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
       
        .auto-style2 {
            width: 82px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblUserDetails" runat="server" Text="Label"></asp:Label> 
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click1"/>
        <br />
        <table style="margin:auto;border:5px solid white; vertical-align:central; width: 573px;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Select Department: "></asp:Label></td>
            <td class="auto-style1">
                <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
         <tr>
            <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Select an Employee: "></asp:Label></td>
            <td class="auto-style1"><asp:DropDownList ID="drpEmployee" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
         <tr>
            <td class="auto-style2"></td>
            <td class="auto-style1">
             <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="64px" OnClick="btnSubmit_Click" /></td>
        </tr>
        <tr>            
            <td class="auto-style1">
             <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>    
    </div>
    </form>
    <form id="form2" runat="server">
        <div>
            <table style="margin:auto;border:5px solid white; vertical-align:central; width: 573px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Reward Type: "></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="drpRewardType" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label4" runat="server" Text="Reward: "></asp:Label></td>
                    <td class="auto-style1"><asp:DropDownList ID="drpReward" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                    <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style1">
                        <asp:Button ID="Button1" runat="server" Text="Submit" Width="64px" /></td>
                </tr>
                <tr>            
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
