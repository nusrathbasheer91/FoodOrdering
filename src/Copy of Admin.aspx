<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Admin.aspx.vb" Inherits="FoodOrdering.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Administrator
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
  <p style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: #2A295C"> Change Maximum Cost :<br />
      <asp:TextBox ID="TxtAmountRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtAmount" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonCostUpdate" runat="server" Text="Update" BackColor="#CCFFCC" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtAmount" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
      <br /><br />Change Client Name : <br />
      <asp:TextBox ID="TxtClientRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtClient" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonClientNameUpdate" runat="server" Text="Update" BackColor="#CCFFCC" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="client" ControlToValidate="TxtClient" runat="server" ErrorMessage="Only Letters allowed" ValidationExpression="[A-Za-z]*"></asp:RegularExpressionValidator>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="client" ControlToValidate="ButtonClientNameUpdate" runat="server"></asp:RegularExpressionValidator>
      <br /><br />Message from Admin : <br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtMsgRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtMsg" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonMsgUpdate" runat="server" Text="Update" BackColor="#CCFFCC" />
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonMsgClear" runat="server" Text="Clear" Width="54px" BackColor="#FFCC99" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtClient" runat="server" ErrorMessage="Only Letters allowed" ValidationExpression="[A-Za-z]*"></asp:RegularExpressionValidator>
      <br /><br />Disable Ordering Till :<br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtDisableRO" runat="server" BackColor="Silver" ReadOnly="True"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="TxtDisable" runat="server" BackColor="#FFFFCC"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonDisableUpdate" runat="server" Text="Update" BackColor="#CCFFCC" />
      &nbsp;&nbsp;&nbsp;
      <asp:Button ID="ButtonDisableClear" runat="server" Text="Clear" Width="54px" BackColor="#FFCC99" style="height: 26px" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TxtDisable" runat="server" ErrorMessage="Only Date Allowed allowed" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator>
      <br />Enter Date till when Ordering is to be disabled (Format: dd-mm-yyyy ex: 22-05-2014) </p>
        </div>
    </form>
</asp:Content>
