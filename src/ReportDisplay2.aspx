<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportDisplay2.aspx.vb" Inherits="FoodOrdering.ReportDisplay2" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Report Display</title>
        <style>
html
{
    background-image: url('../Resources/body.jpg');
    background-attachment: fixed;
    background-position: top center; 
    background-repeat: repeat-y;
}
body 
{
    max-width: 800px;
    margin: 20px auto;
    padding: 50px;
    background-color: #FFFFFF; 
    border: thick solid #9999FF;
    margin-top: 100px;
    margin-bottom:100px;
}

.mainbody
{
    position : relative;
    min-height: 550px;
    max-width: 1100px;
}
.horizontalcentre
{
    text-align: center;
}
        </style>
    </head>
    <body class="mainbody">
        <form id="form2" runat="server" class="horizontalcentre">
            <p style="position: relative; top: 15px; font-size: medium;"><a href="AdminHome.aspx" style="color: #17B595;">Select to go to Admin Home</a></p>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
   
        </form>
        </body>
    </html>
