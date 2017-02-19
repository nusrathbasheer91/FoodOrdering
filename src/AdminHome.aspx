<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AdminHome.aspx.vb" Inherits="FoodOrdering.AdminHome" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Administrator Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <p style="position: relative; top: 15px; font-size: large;"><a href="Login.aspx" style="color: #17B595;">Select to LogOut</a></p>
    <p style="font-family: 'Footlight MT Light'; font-size: xx-large; font-weight: 400; color: #2A295C">Administrator Home Page</p>
    <asp:TextBox ID="TxtDate" runat="server" BackColor="Silver" ReadOnly="True" Height="25px" Width="138px"/>
        &nbsp;<br />
        &nbsp;&nbsp;
        <asp:Hyperlink ID="ImageButton1" runat="server" ImageUrl="~/Resources/print1.png" NavigateUrl="~/ReportDisplay.aspx" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br /><br />
        &nbsp;
        <asp:Hyperlink ID="Hyperlink5" runat="server" ImageUrl="~/Resources/reports.png" NavigateUrl="~/RunReports.aspx" />
        &nbsp;
        <br /><br />
        <asp:Hyperlink ID="Hyperlink2" runat="server" ImageUrl="~/Resources/restbutton1.png" NavigateUrl="~/AddRemRest.aspx" />
        <br /><br />
        <asp:Hyperlink ID="Hyperlink3" runat="server" ImageUrl="~/Resources/itemsbutton1.png" NavigateUrl="~/AddRemItem.aspx" />
        <br /><br />
        <asp:Hyperlink ID="Hyperlink4" runat="server" ImageUrl="~/Resources/usersbutton1.png" NavigateUrl="~/AddRemUser.aspx" />
        <br /><br />
        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Resources/settings2.png" NavigateUrl="~/AdminSettings.aspx"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        </div>
    </form>
</asp:Content>
