<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AdminSettings.aspx.vb" Inherits="FoodOrdering.AdminSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Administrator Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <p style="position: relative; top: 15px; font-size: large;"><a href="AdminHome.aspx" style="color: #17B595;">Select to go to Admin Home</a></p>
  <p style="font-family: 'Footlight MT Light'; font-size: large; font-weight: 400; color: #2A295C; text-align: center; ">Page will be refreshed after Update to reflect changes</p>
        <p style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #2A295C"> Change Maximum Cost :<br />
      <asp:TextBox ID="TxtAmountRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtAmount" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonCostUpdate" runat="server" Text="Update" BackColor="#99FF66" />
      <br /><br />Change Client Name : <br />
      <asp:TextBox ID="TxtClientRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtClient" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonClientNameUpdate" runat="server" Text="Update" BackColor="#99FF66" />
      <br /><br />Change Start Ordering Time : Format(hh:mm)<br />
      <asp:TextBox ID="TxtorderstartRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="Txtorderstart" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonOrderStartUpdate" runat="server" Text="Update" BackColor="#99FF66" />
      <br /><br />Change End Ordering Time : Format(hh:mm)<br />
      <asp:TextBox ID="TxtorderendRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="Txtorderend" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonOrderEndUpdate" runat="server" Text="Update" BackColor="#99FF66" />
      <br /><br />Message from Admin : <br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtMsgRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtMsg" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonMsgUpdate" runat="server" Text="Update" BackColor="#99FF66" />
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonMsgClear" runat="server" Text="Clear" Width="54px" BackColor="#FF6666" />
     <br /><br />Disable Ordering Till :<br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtDisableRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtDisable" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonDisableUpdate" runat="server" Text="Update" BackColor="#99FF66" />
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonDisableClear" runat="server" Text="Clear" Width="54px" BackColor="#FF6666" style="height: 26px" />
      <br />Enter Date till when Ordering is to be disabled (Format: dd-mm-yyyy ex: 22-05-2014) </p><br /><br />
        </div>
    </form>
</asp:Content>
