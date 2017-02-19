<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="RunReports.aspx.vb" Inherits="FoodOrdering.RunReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Run Reports
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <a href="AdminHome.aspx" style="position: relative; top: 5px; font-size: large; margin-left: 30px; color: #17B595;">Select to go to Admin Home</a>
            <div style="margin-left: 30px">
            <p style="vertical-align: super">Select Report : <asp:DropDownList ID="DropDownListReport" runat="server" Font-Size="Medium" 
            Height="39px" Width="269px" BackColor="#FFFFCC" ForeColor="#2A295C" AppendDataBoundItems="True">
                <asp:ListItem>SummaryRPT</asp:ListItem>
                <asp:ListItem>SummaryDetailsRPT</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                <asp:ImageButton ID="ViewButton" runat="server" ImageUrl="~/Resources/view2.png" />
                <p style="vertical-align: super; height: 28px; margin-top: 20px; margin-bottom: 20px;">
            Enter Start Date :
            <asp:TextBox ID="TxtStartDate" runat="server" BackColor="#FFFFCC" Height="28px"></asp:TextBox>
&nbsp;Enter End Date :
            <asp:TextBox ID="TxtEndDate" runat="server" BackColor="#FFFFCC" Height="28px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
                <p style="vertical-align: super; height: 28px; margin-top: 20px; margin-bottom: 20px;">
            &nbsp;(Date Format : YYYY-MM-DD Ex: 2014-02-27)</p>
            <p style="vertical-align: super">
                Select Restaurant : <asp:DropDownList ID="DropDownListRest" runat="server" Font-Size="Medium" 
            Height="39px" Width="269px" BackColor="#FFFFCC" ForeColor="#2A295C" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="RestName" DataValueField="RestID">
                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" SelectCommand="SELECT [RestID], [RestName] FROM [Rest]"></asp:SqlDataSource>
            </p>
            <p style="vertical-align: super">
                 Select Users : <asp:DropDownList ID="DropDownListUsers" runat="server" Font-Size="Medium" 
            Height="39px" Width="269px" BackColor="#FFFFCC" ForeColor="#2A295C" AppendDataBoundItems="true" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="userid">
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br /><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" SelectCommand="SELECT userid, Name FROM Users WHERE (userid &lt;&gt; 'admin') ORDER BY Name"></asp:SqlDataSource>
               <br /><br /><br /> </p>
        </div>
        </div>
    </form>
</asp:Content>
