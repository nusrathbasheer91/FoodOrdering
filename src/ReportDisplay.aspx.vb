Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class ReportDisplay
    Inherits System.Web.UI.Page
    Dim rptDoc As New ReportDocument()

    Private Sub ReportDisplay_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        Else
            GetDBData()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub GetDBData()
        Dim ds As New Summary()
        ' .xsd file name
        'Dim ds2 As New DataSet()
        Dim itemsAdapter As New SummaryTableAdapters.ItemsTableAdapter()
        Dim ordersAdapter As New SummaryTableAdapters.OrdersTableAdapter()
        Dim RestAdapter As New SummaryTableAdapters.RestTableAdapter()

        itemsAdapter.Fill(ds.Tables("Items"))
        ordersAdapter.Fill(ds.Tables("Orders"), Format(Today, "yyyy-MM-dd"), Format(Today, "yyyy-MM-dd"), "%", "%")
        RestAdapter.Fill(ds.Tables("Rest"))
        'Dim ds As New Orders()
        '' .xsd file name
        ''Dim ds2 As New DataSet()
        'Dim itemsAdapter As New OrdersTableAdapters.ItemsTableAdapter()
        'Dim ordersAdapter As New OrdersTableAdapters.OrdersTableAdapter()
        'Dim RestAdapter As New OrdersTableAdapters.RestTableAdapter()

        'DropDownList1.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        'DropDownList1.DataBind()

        '' Just set the name of data table
        ''ds2.Tables(0)
        ''ds2 = getData()
        ''This function is located below this function
        ''ds.Tables(0).Merge(dt)
        'itemsAdapter.Fill(ds.Tables("Items"))
        'ordersAdapter.Fill(ds.Tables("Orders"))
        'RestAdapter.Fill(ds.Tables("Rest"))

        ' Your .rpt file path will be below
        rptDoc.Load(Server.MapPath("~/Reports/OrdersRPT.rpt"))

        'set dataset to the report viewer.
        rptDoc.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rptDoc
        CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.Pdf
        'rptDoc.PrintToPrinter(1, True, 0, 0)   'remove comment later


    End Sub

End Class