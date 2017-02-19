<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ScannedMenus.aspx.vb" Inherits="FoodOrdering.ScannedMenus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Scanned Menus
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <a href="Home.aspx" style="position: relative; top: 5px; font-size: large; margin-left: 30px; color: #17B595;">Select to go to Home</a>
        <p style="font-family: 'Footlight MT Light'; font-size: xx-large; font-weight: 400; color: #2A295C">Please select restaurant :</p>
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Large" 
            Height="58px" Width="315px" BackColor="#FFFFCC" ForeColor="#2A295C" DataSourceID="SqlDataSource1" DataTextField="RestName" DataValueField="RestID">
        </asp:DropDownList>           
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" SelectCommand="SELECT [RestID], [RestName] FROM [Rest] where [Active]=1"></asp:SqlDataSource>
        <p>
           
            <asp:ImageButton ID="ImageButton1" 
                 runat="server"
                 AlternateText="ImageButton1"
                 ImageUrl="~/Resources/view2.png"/>
           
            </p>
    </div>
        <asp:Panel ID="Panel1" runat="server">

        </asp:Panel>
    </form>
</asp:Content>
