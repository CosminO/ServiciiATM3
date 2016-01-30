<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="ServiciiAtmE231A.Student.StudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            text-align: center;
            font-size: large;
            color: #FFFFFF;
            height: 69px;
            background-color: #00CC00;
        }
        .auto-style4 {
            height: 116px;
            background-color: #0000FF;
        }
        .auto-style5 {
            height: 149px;
            background-color: #0000FF;
        }
        .auto-style6 {
            height: 116px;
            width: 369px;
            background-color: #0000FF;
            color: #0000CC;
        }
        .auto-style7 {
            height: 149px;
            width: 369px;
            background-color: #0000FF;
        }
        .auto-style8 {
            color: #0000CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3" colspan="2">Student Page</td>
            </tr>
            <tr> 
                <td class="auto-style6">
                    &nbsp;<asp:Label ID="Label2" runat="server" Text="Afisarea Serviciilor in Functie de Companie" ForeColor="White"></asp:Label>
                     <asp:Button ID="Btn_Incarca" runat="server" Text="Incarca" OnClick="Btn_Incarca_Click" />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-left: 48px">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server" Text="Compania:" ForeColor="White"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                   
                    <asp:Button ID="Button_Afisare" runat="server" OnClick="Button_Afisare_Click" Text="Afiseaza" />
                   
                </td>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Afisarea Serviciilor in Functie de Data" CssClass="auto-style8"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Afisarea Serviciilor in Functie de An de Studii:" CssClass="auto-style8"></asp:Label>
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    :<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="auto-style8">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="Afiseaza" CssClass="auto-style8" OnClick="Button1_Click" />
                </td>
                <td class="auto-style5"></td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
