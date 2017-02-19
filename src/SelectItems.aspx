<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="SelectItems.aspx.vb" Inherits="FoodOrdering.SelectItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Select Items
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
       
       <div class="restName">
        <div class="horizontalcentre">
            <p style="position: relative; top: 15px; font-size: large;"><a href="Login.aspx" style="color: #17B595;">Select to LogOut</a></p>
            <p style="position: relative; top: 15px; font-size: large;"><a href="PlaceOrder.aspx" style="color: #17B595;">Select to Change Restaurant</a></p>
            <p style="border: thin solid #000000; font-family: 'Footlight MT Light'; font-size: xx-large; font-weight: 400; color: #2A295C; margin-bottom: 0px;"><%= Session("RestID").ToString%>: <%= RestName%></p>
            <p style="font-family: 'Footlight MT Light'; font-size: medium; color: #2A295C; position: relative; top: -10px"><br /><%= StrO%>
                </p>
            <p>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" 
                    SelectCommand="SELECT [ItemId], [Name], [Price], [OrderType] FROM [Items] WHERE ([RestId] = @RestId) and [Active]=1">
                    <SelectParameters>
                        <asp:SessionParameter Name="RestId" SessionField="RestID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" CellPadding="8" ForeColor="#333333" GridLines="None" Height="114px" HorizontalAlign="Center" CssClass="gridview">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" CausesValidation="False" InsertVisible="False" SelectText="Add to Order" ShowCancelButton="False" ShowSelectButton="True" >
                        <HeaderStyle Width="120px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="ItemId" HeaderText="ItemId" 
                            SortExpression="ItemId" ReadOnly="True" >
                        <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name" 
                            SortExpression="Name" ReadOnly="True" >
                        </asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="Price" 
                            SortExpression="Price" ReadOnly="True" >
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OrderType" HeaderText="OrderType" SortExpression="OrderType" ReadOnly="True" >
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
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
                </p>
            <p>
                        RestID .: <asp:TextBox ID="txtRestID" runat="server" BackColor="#CCCCCC" ReadOnly="True" style="margin-top: 7px"></asp:TextBox>&nbsp;&nbsp;&nbsp;Name of Orderee .: <asp:TextBox ID="txtUserName" runat="server" BackColor="#FFFF99" Width="372px" ReadOnly="True"></asp:TextBox>
                        <br /><br />
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderNo,ItemId"
                    DataSourceID="SqlDataSource2" CellPadding="8" ForeColor="#333333" GridLines="None"  HorizontalAlign="Center" CssClass="gridview">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" DeleteText="Remove" ShowDeleteButton="True">
                                <HeaderStyle Width="90px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="Orderno" HeaderText="Orderno" ReadOnly="True" SortExpression="Orderno" Visible="False" />
                                <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" ReadOnly="True" >
                                <HeaderStyle Width="55px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ReadOnly="True" />
                                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ReadOnly="True">
                                <HeaderStyle Width="55px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrderType" HeaderText="OrderType" SortExpression="OrderType" ReadOnly="True" >
                                <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" DataFormatString="{0:dd-MMM-yy}" HeaderText="Date" SortExpression="Date" ReadOnly="True">
                                <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name of Orderee" HeaderText="Name of Orderee" SortExpression="Name of Orderee" ReadOnly="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
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
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringMDF %>" SelectCommand="SELECT  [OrdersTemp].[Orderno], [OrdersTemp].[ItemId], [Name],[OrdersTemp].[Price], [OrdersTemp].[OrderType], [NameofO] as 'Name of Orderee', [DateO] as Date FROM [OrdersTemp],[Items]  WHERE (([OrdersTemp].[ItemId]=[Items].[ItemId]) AND ([OrdersTemp].[RestID]=[Items].[RestID]) AND ([UserId] = @UserId) AND ([DateO] = cast(GETDATE() as date) ))" DeleteCommand="DELETE FROM [OrdersTemp] where [Orderno]=@Orderno and [ItemId]=@ItemId" >
                            <DeleteParameters>
                                <asp:Parameter Name="Orderno" />
                                <asp:Parameter Name="ItemId" />
                            </DeleteParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="UserId" SessionField="LoginID" Type="String" />
                            </SelectParameters>
                           
                        </asp:SqlDataSource>
                 </p>
      </div>
    </div>
                                   
                                   
        <div style="position: relative; text-align: right; right: 10px; margin-top: -7px">
                                               Total Price.: 
                        <asp:TextBox ID="txtTotal" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        <asp:Button ID="ButtonConfirm" runat="server" BackColor="#99FF66" Font-Bold="True" Height="21px" Text="Confirm Order" Style="position: relative; top: 0px; left: -6px;" />
         &nbsp;&nbsp; 
         <asp:Button ID="ButtonClear" runat="server" BackColor="Red" Font-Bold="True" ForeColor="White" Height="21px" Text="Clear Order" Style="position: relative; top: 0px; left: 0px; width: 136px;"/>
           <br /><br /><div style="color: #FF0000; font-weight: bolder; font-size: large"><%=confString%> </div>
        </div>
                                   <br />
                                  <br />
                                   <br />
                                   <br />
                                   <br />
                                   <br />
                        <br /><br />
                                   <br /><br /><br />
                <br />
                <br />
              
        <asp:Button ID="Button2" runat="server" Text="Button2" CausesValidation="False" OnClick="Button2_click" Style="display: none;" />
      
    <script type="text/javascript">
        function confirmProcess() {
            if (confirm('Order placed to another Restaurant will be CLEARED. Confirm to clear Order?')) {
                document.getElementById('<%=Button2.ClientID%>').click();
             }
             else {
                 window.location = "PlaceOrder.aspx";
             }
         }
    </script>
           </form>
    
    </asp:Content>
