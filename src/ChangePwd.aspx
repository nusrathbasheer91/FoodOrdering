<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ChangePwd.aspx.vb" Inherits="FoodOrdering.ChangePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Change Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
   <p style="font-family: 'Footlight MT Light'; font-size: xx-large; font-weight: 400; color: #2A295C; text-align: center; ">Enter Details :</p>
<p style="font-family: 'Footlight MT Light'; font-size: small; font-weight: 400; color: #2A295C; text-align: center;">Password can contain Alphanumeric Characters ONLY</p>
                <div class="horizontalcentre">
                             <div style="font-size: large; color: #2A295C; position: relative; bottom:-10px;">UserID .:</div><br /><asp:TextBox ID="TxtUserID" runat="server" Height="29px" Width="249px" BackColor="#FFFF99" MaxLength="6"></asp:TextBox>
            <br />
            <div style="font-size: large; color: #2A295C; position: relative; bottom:-10px;">Old Password .:</div><br /><asp:TextBox ID="TxtPwd" runat="server" Height="29px" Width="249px" BackColor="#FFFF99" MaxLength="10" TextMode="Password"></asp:TextBox>
            <div style="font-size: large; color: #2A295C; position: relative; bottom:-10px;">New Password .:</div><br /><asp:TextBox ID="TxtNPwd1" runat="server" Height="29px" Width="249px" BackColor="#FFFF99" MaxLength="10" TextMode="Password"></asp:TextBox>
            <div style="font-size: large; color: #2A295C; position: relative; bottom:-10px;">Retype Password .:</div><br /><asp:TextBox ID="TxtNPwd2" runat="server" Height="29px" Width="249px" BackColor="#FFFF99" MaxLength="10" TextMode="Password"></asp:TextBox>
            <p>
                <asp:ImageButton style=" padding-top:0px; " ID="LoginButton" runat="server"
                AlternateText="LoginButton"
                ImageUrl="~/Resources/loginbutton.png" />
                </p>
            
       <br /><br /><br />
    </div>
        </form>
</asp:Content>
