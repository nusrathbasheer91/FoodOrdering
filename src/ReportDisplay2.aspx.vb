Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportDisplay2
    Inherits System.Web.UI.Page
    Dim rptDoc As New ReportDocument()
    Dim RName As String
    Dim startDate As String
    Dim endDate As String
    Dim RestR As String
    Dim UserR As String

    Private Sub ReportDisplay2_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        Else
            initParams()
            GetDBData()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub initParams()
        startDate = Session("startDate")
        endDate = Session("endDate")
        UserR = Session("UserR")
        RestR = Session("RestR")
        RName = Session("RName")
        If UserR = "000" Then
            UserR = "%"
        End If
        If RestR = "000" Then
            RestR = "%"
        End If
    End Sub

    Sub GetDBData()


        Dim ds As New Summary()
        ' .xsd file name
        'Dim ds2 As New DataSet()
        Dim itemsAdapter As New SummaryTableAdapters.ItemsTableAdapter()
        Dim ordersAdapter As New SummaryTableAdapters.OrdersTableAdapter()
        Dim RestAdapter As New SummaryTableAdapters.RestTableAdapter()


        ' Just set the name of data table
        'ds2.Tables(0)
        'ds2 = getData()
        'This function is located below this function
        'ds.Tables(0).Merge(dt)
        itemsAdapter.Fill(ds.Tables("Items"))
        ordersAdapter.Fill(ds.Tables("Orders"), startDate, endDate, UserR, RestR)
        RestAdapter.Fill(ds.Tables("Rest"))

        ' Your .rpt file path will be below
        rptDoc.Load(Server.MapPath("~/Reports/" & RName & ".rpt"))

        'set dataset to the report viewer.
        rptDoc.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rptDoc
        CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.Pdf
        'rptDoc.PrintToPrinter(1, True, 0, 0)   'remove comment later

    End Sub

End Class