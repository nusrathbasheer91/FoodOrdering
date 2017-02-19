<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="PlaceOrder.aspx.vb" Inherits="FoodOrdering.PlaceOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Place Order
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <p style="position: relative; top: 15px; font-size: large;"><a href="Login.aspx" style="color: #17B595;">Select to LogOut</a></p>
        <div class="verticalcentre">
        <p style="font-family: 'Footlight MT Light'; font-size: xx-large; font-weight: 400; color: #2A295C">Please select restaurant :</p>
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Large" 
            Height="58px" Width="315px" BackColor="#FFFFCC" ForeColor="#2A295C">
        </asp:DropDownList>
            <p>
            <asp:ImageButton style=" padding-top:10px;" ID="NextButton" runat="server"
                AlternateText="NextButton"
                ImageUrl="~/Resources/nextbutton.png"
                OnClick="NextButton_Click" />
            </p>
       </div>
    </div>
    </form>
</asp:Content>
