<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddRemRest.aspx.vb" Inherits="FoodOrdering.AddRemRest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Add/Deactivate Restaurants
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="horizontalcentre">
            <p style="position: relative; top: 15px; font-size: large;"><a href="AdminHome.aspx" style="color: #17B595;">Select to go to Admin Home</a></p>
        <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" SelectCommand="SELECT * FROM [Rest]" UpdateCommand="UPDATE Rest SET Active = @Active, OrderString = @OrderString WHERE (RestID = @RestID)" InsertCommand="INSERT INTO Rest(RestID, RestName, OrderString, Active) VALUES (@RestID, @RestName, @OrderString, @Active)">
            <InsertParameters>
                <asp:Parameter Name="RestID" />
                <asp:Parameter Name="RestName" />
                <asp:Parameter Name="OrderString" />
                <asp:Parameter Name="Active" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Active" />
                <asp:Parameter Name="OrderString" />
                <asp:Parameter Name="RestID" />
            </UpdateParameters>
            </asp:SqlDataSource>
        <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RestID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" CssClass="gridview">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True">
                    <HeaderStyle Width="100px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="RestID" HeaderText="RestID" ReadOnly="True" SortExpression="RestID" >
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RestName" HeaderText="RestName" SortExpression="RestName" />
                    <asp:BoundField DataField="OrderString" HeaderText="OrderString" SortExpression="OrderString" />
                    <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" >
                    <HeaderStyle Width="70px" />
                    </asp:CheckBoxField>
                </Columns>
                <EditRowStyle BackColor="#89EBF5" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
            <br />
            
        <asp:Panel ID="Panel1" runat="server" BackColor="#0060BF" ForeColor="White" Height="120px">
         <br />
               <p style="margin: 10px auto auto auto; vertical-align: 40%">Name:&nbsp;&nbsp;<asp:TextBox ID="NameTextBox" runat="server"  Width="177px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrderString:&nbsp;&nbsp;<asp:TextBox ID="OrderStringTextBox" runat="server" />
                            &nbsp;&nbsp;Active:<asp:CheckBox ID="ActiveCheckBox" runat="server" Checked="True" />
                            <br /><br />
                            <asp:Button ID="InsertButton" runat="server" BackColor="#66FFFF" CommandName="Insert" Font-Bold="True" Text="Insert" Width="106px" />
                                &nbsp;&nbsp;
                            <asp:Button ID="CancelButton" runat="server" BackColor="#66CCFF" CommandName="Cancel" Font-Bold="True" Text="Clear" Width="106px" />&nbsp;
                            </p>             
        </asp:Panel>
            <br /><br /><br />
 
   </form></div>
</asp:Content>
