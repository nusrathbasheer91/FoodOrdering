<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.vb" Inherits="FoodOrdering.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Login
 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2" runat="server">
    <meta http-equiv="Expires" content="0"/>
  <meta http-equiv="Cache-Control" content="no-cache"/>
  <meta http-equiv="Pragma" content="no-cache"/>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="horizontalcentre">
        <p style="position: relative; top: 15px; font-size: large;"><a href="Home.aspx" style="color: #17B595;">Select to go to Home</a></p>
        <div class="verticalcentre">
            <br />
            <div style="font-size: large; color: #2A295C; position: relative; bottom:-10px;">UserID .:</div><br /><asp:TextBox ID="TxtUserID" runat="server" Height="29px" Width="249px" BackColor="#FFFF99" MaxLength="6"></asp:TextBox>
            <br />
            <div style="font-size: large; color: #2A295C; position: relative; bottom:-10px;">Password .:</div><br /><asp:TextBox ID="TxtPwd" runat="server" Height="29px" Width="249px" BackColor="#FFFF99" MaxLength="10" TextMode="Password"></asp:TextBox>
            <p>
                <asp:ImageButton style=" padding-top:0px;" ID="LoginButton" runat="server"
                AlternateText="LoginButton"
                ImageUrl="~/Resources/loginbutton.png" />
                </p>
       </div>
    </div>
        <p style="font-family: 'Footlight MT Light'; font-size: xx-large; font-weight: 400; color: #2A295C; text-align: center; ">Enter Login Details :</p>

   </form>
    </asp:Content>
