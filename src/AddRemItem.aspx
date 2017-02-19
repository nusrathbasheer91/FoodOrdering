<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddRemItem.aspx.vb" Inherits="FoodOrdering.AddRemItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Add/Deactivate Items
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <p style="position: relative; top: 15px; font-size: large;"><a href="AdminHome.aspx" style="color: #17B595;">Select to go to Admin Home</a></p>
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
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ItemId,RestId" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" CssClass="gridview">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ButtonType="Button" >
            <HeaderStyle Width="70px" />
            </asp:CommandField>
            <asp:BoundField DataField="ItemId" HeaderText="ItemId" ReadOnly="True" SortExpression="ItemId" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="RestId" HeaderText="RestId" ReadOnly="True" SortExpression="RestId" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
            <ControlStyle Width="240px" />
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" >
            <ControlStyle Width="60px" />
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="OrderType" HeaderText="OrderType" SortExpression="OrderType" >
            <ControlStyle Width="60px" />
            <HeaderStyle Width="100px" />
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" >
            <HeaderStyle Width="50px" />
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
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" InsertCommand="INSERT INTO Items(ItemId, RestId, Name, Price, OrderType, Active) VALUES (@ItemId, @RestId, @Name, @Price, @OrderType, @Active)" SelectCommand="SELECT ItemId, RestId, Name, Price, OrderType, Active FROM Items WHERE (RestId = @RestId)" UpdateCommand="UPDATE Items SET Active = @Active, OrderType = @OrderType, Price = @Price, Name = @Name WHERE (ItemId = @ItemId) AND (RestId = @RestId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="RestId" PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Active" />
                <asp:Parameter Name="OrderType" />
                <asp:Parameter Name="Price" />
                <asp:Parameter Name="Name" />
                <asp:Parameter Name="ItemId" />
                <asp:Parameter Name="RestId" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Panel ID="Panel1" runat="server" BackColor="#0060BF" ForeColor="White" Height="120px">
         <br />
                            <p style="margin: 10px auto auto auto; vertical-align: 40%">Name:&nbsp;&nbsp;<asp:TextBox ID="NameTextBox" runat="server"  Width="177px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;Price:&nbsp;&nbsp;<asp:TextBox ID="PriceTextBox" runat="server" />
                            &nbsp;&nbsp;&nbsp;OrderType:&nbsp;&nbsp;<asp:TextBox ID="OrderTypeTextBox" runat="server" />
                            &nbsp;&nbsp;Active:<asp:CheckBox ID="ActiveCheckBox" runat="server" Checked="True" />
                            <br /><br />
                            <asp:Button ID="InsertButton" runat="server" BackColor="#66FFFF" CommandName="Insert" Font-Bold="True" Text="Insert" Width="106px" />
                                &nbsp;&nbsp;
                            <asp:Button ID="CancelButton" runat="server" BackColor="#66CCFF" CommandName="Cancel" Font-Bold="True" Text="Clear" Width="106px" />&nbsp;
                            </p>
        </asp:Panel>
        <br />
        <br />
        <br />
        </div>
    </form>
</asp:Content>
