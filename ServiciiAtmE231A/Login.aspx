<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ServiciiAtmE231A.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-center" style="font-size: x-large">
    <strong>Please Log in</strong></p>
<table class="nav-justified">
    <tr>
        <td class="text-right" style="width: 148px">UserName</td>
        <td style="width: 303px">
            <asp:TextBox ID="TextBoxUserName" runat="server" Width="299px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Please enter UserName" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="text-right" style="width: 148px">Password</td>
        <td style="width: 303px">
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="298px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="text-right" style="width: 148px; height: 22px"></td>
        <td style="width: 303px; height: 22px">
            <asp:Button ID="Button_Login" runat="server" OnClick="Button_Login_Click" Text="Login" Width="88px" />
        </td>
        <td style="height: 22px"></td>
    </tr>
    <tr>
        <td class="text-right" style="width: 148px">&nbsp;</td>
        <td style="width: 303px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
