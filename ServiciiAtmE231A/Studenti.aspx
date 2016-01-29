<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Studenti.aspx.cs" Inherits="ServiciiAtmE231A.Studenti" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/About">About</a></li>
                       
                    </ul>
          <p>
        Pagina Studenti.</p>
</div>
<asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        You are not logged in.
    </AnonymousTemplate>
    <LoggedInTemplate>
        You are Logged in. Welcome<asp:LoginName ID="LoginName1" runat="server" />
    </LoggedInTemplate>
</asp:LoginView>
</asp:Content>

   
