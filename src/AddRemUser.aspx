<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddRemUser.aspx.vb" Inherits="FoodOrdering.AddRemUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Add/Deactivate Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="horizontalcentre">
            <p style="position: relative; top: 15px; font-size: large;"><a href="AdminHome.aspx" style="color: #17B595;">Select to go to Admin Home</a></p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="gridview" DataKeyNames="userid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="440px"  PageSize="20">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Reset Password" ShowEditButton="True" ShowSelectButton="True">
            <ControlStyle BackColor="#CCFF99" />
            <HeaderStyle Width="200px" />
            </asp:CommandField>
            <asp:BoundField DataField="userid" HeaderText="userid" ReadOnly="True" SortExpression="userid">
            <HeaderStyle Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
            <ControlStyle Width="350px" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active">
            <HeaderStyle Width="70px" />
            </asp:CheckBoxField>
        </Columns>
        <EditRowStyle BackColor="#89EBF5" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" SelectCommand="SELECT userid, Name, Active FROM Users WHERE (userid &lt;&gt; 'admin') ORDER BY userid" UpdateCommand="UPDATE Users SET Name = @Name, Active = @Active WHERE (userid = @UserID)">
            <UpdateParameters>
                <asp:Parameter Name="Name" />
                <asp:Parameter Name="Active" />
                <asp:Parameter Name="UserID" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <br />
            <br />
    <asp:Panel ID="Panel1" runat="server" BackColor="#0060BF" ForeColor="White" Height="120px">
         <br />
               <p style="margin: 10px auto auto auto; vertical-align: 40%">UserID:&nbsp;&nbsp;<asp:TextBox ID="TxtBoxUserID" runat="server"  Width="177px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:&nbsp;&nbsp;<asp:TextBox ID="TxtBoxName" runat="server" />
                            &nbsp;&nbsp;Active:<asp:CheckBox ID="ActiveCheckBox" runat="server" Checked="True" />
                            <br /><br />
                            <asp:Button ID="InsertButton" runat="server" BackColor="#66FFFF" CommandName="Insert" Font-Bold="True" Text="Insert" Width="106px" />
                                &nbsp;&nbsp;
                            <asp:Button ID="CancelButton" runat="server" BackColor="#66CCFF" CommandName="Cancel" Font-Bold="True" Text="Clear" Width="106px" />&nbsp;
                            </p>             
        </asp:Panel>
            <br /><br /><br />
</div>    </form>
</asp:Content>
