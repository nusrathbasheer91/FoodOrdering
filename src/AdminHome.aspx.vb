Imports System.Globalization
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class AdminHome
    Inherits System.Web.UI.Page
    Dim dbcon As New SqlConnection


    Private Sub AdminHome_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtDate.Text = Format(DateTime.Today, "dd-MM-yyyy")
    End Sub

    'Protected Sub ButtonGenerateReport_Click(sender As Object, e As ImageClickEventArgs) Handles ButtonGenerateReport.Click
    '    'Dim sqlCmd As New SqlCommand
    '    'Dim sqlAdapter As New SqlDataAdapter
    '    'Dim dataS As New DataSet

    '    'Dim sqlQ As String = "select * from orders where dateO=cast(GETDATE() as date)"
    '    'If dbcon.State = ConnectionState.Closed Then
    '    '    dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
    '    '    dbcon.Open()
    '    'End If
    '    'Try

    '    '    With sqlCmd
    '    '        .CommandText = sqlQ
    '    '        .Connection = dbcon
    '    '    End With
    '    '    With sqlAdapter
    '    '        .SelectCommand = sqlCmd
    '    '        .Fill(dataS)
    '    '    End With
    '    '    Dim myReportDocument As ReportDocument
    '    '    myReportDocument = New ReportDocument()
    '    '    myReportDocument.Load("~/Reports/Orders.rpt")
    '    '    myReportDocument.SetDataSource(dataS)
    '    '    myReportDocument.SetDatabaseLogon("username", "pwd")
    '    '    crystalReportViewer1.ReportSource = myReportDocument
    '    '    crystalReportViewer1.DisplayToolbar = True
    '    'Catch

    '    'End Try
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    '        Public Class ReportsController

    '    '        Private ReadOnly _db As New ReportSampleDataContext()

    '    '    Public Function SalesYtd() As ActionResult
    '    '        Dim reportPath = Server.MapPath("~/ReportTemplates/SalesYTD.rpt")
    '    '        Dim customers = _db.Customers
    '    '        Using reportDocument = New ReportDocument()
    '    '            reportDocument.Load(reportPath)
    '    '            reportDocument.SetDataSource(customers)

    '    '            Dim response = System.Web.HttpContext.Current.Response
    '    '            reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, response, True, "SalesYTD")
    '    '        End Using

    '    '        Return New EmptyResult()
    '    '    End Function
    '    'End Class
    '    '      ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '       private readonly ReportSampleDataContext _db = new ReportSampleDataContext();

    '    'public ActionResult SalesYtd()
    '    '{
    '    '  var reportPath = Server.MapPath("~/ReportTemplates/SalesYTD.rpt");
    '    '  var customers = _db.Customers;
    '    '  using (var reportDocument = new ReportDocument())
    '    '  {
    '    '    reportDocument.Load(reportPath);
    '    '    reportDocument.SetDataSource(customers);

    '    '    var response = System.Web.HttpContext.Current.Response;
    '    '    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, response, true, "SalesYTD");
    '    '  }

    '    '  return new EmptyResult();
    '    '}
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim reportPath As Object = Server.MapPath("~/Reports/OrdersReport.rpt")
    '    Using reportDoc As New ReportDocument

    '        reportDoc.Load(reportPath)

    '        Dim response As Object = System.Web.HttpContext.Current.Response
    '        reportDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, response, True, "OrdersReport")
    '    End Using


    'End Sub
End Class