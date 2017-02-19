Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Public Class PlaceOrder
    Inherits System.Web.UI.Page
    Dim pageRestname As String
    Dim dbcon As New SqlConnection
    Dim OrderRestArray As New List(Of String)
    Dim RestIDArray As New List(Of String)

    Protected Sub NextButton_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles NextButton.Click
        If DropDownList1.SelectedValue = "" Then
            'Response.Write("<script>alert('Select Rest');</script>")
            'alert("Select Rest")
            ClientScript.RegisterStartupScript(Me.GetType(), "selectRest", "alert('Please Select Restaurant');", True)

        Else

            'If (Me.ViewState("restNameinViewState") IsNot Nothing) Then
            'pageRestname = CType(Me.ViewState("restNameinViewState"), String)
            'Else

            'End If

            'Session.Add("RestId", DropDownList1.SelectedValue)
            Response.Redirect("SelectItems.aspx", False)


        End If
    End Sub

    Private Sub PlaceOrder_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "selectRest", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        End If
    End Sub
    'Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Save PageArrayList before the page is rendered.
    '    Me.ViewState.Add("arrayListInViewState", PageArrayList)
    'End Sub
    Private Sub PlaceOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim orderstart As String = System.Configuration.ConfigurationManager.AppSettings("orderstart")
        Dim orderend As String = System.Configuration.ConfigurationManager.AppSettings("orderend")
        Dim adminmsg As String = System.Configuration.ConfigurationManager.AppSettings("adminmsg")
        Dim disable As String = System.Configuration.ConfigurationManager.AppSettings("disable")
        If disable = "" And adminmsg <> "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AdminMsg1", "alert('" & adminmsg & "');", True)
        ElseIf IsDate(disable) AndAlso CDate(disable) >= DateTime.Today.Date AndAlso adminmsg <> "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AdminMsg2", "alert('" & adminmsg & ", Ordering is DISABLED TODAY');window.location = ""Home.aspx""", True)
        ElseIf IsDate(disable) AndAlso CDate(disable) >= DateTime.Today.Date AndAlso adminmsg = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AdminMsg3", "alert('Ordering is DISABLED TODAY');window.location = ""Home.aspx""", True)
        Else
            If CType(orderstart, Date).TimeOfDay >= DateTime.Now.TimeOfDay Or CType(orderend, Date).TimeOfDay <= DateTime.Now.TimeOfDay Then
                ClientScript.RegisterStartupScript(Me.GetType(), "Printed", "alert('Time to Place Orders has Lapsed, Contact admin to place Order');window.location = ""Home.aspx""", True)
            Else
                Session("button2clicked") = False
                GetDBData()
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1))
                Response.Cache.SetNoStore()
                'Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                'Session.Abandon()
                'FormsAuthentication.SignOut()
                'DropDownList1.Items.Add(New ListItem("Text1", "Value1"))
            End If
        End If
    End Sub
    Public Sub GetDBData()
        Dim strQuery As String = "SELECT * from rest where active=1;"
        Dim sqlAdapter As New SqlDataAdapter
        Dim SQLCmd As New SqlCommand
        Dim dataS As New DataTable
        Dim i As Integer

        If dbcon.State = ConnectionState.Closed Then
            dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
            dbcon.Open()
        End If
        'Prepare connection and query
        With SQLCmd
            .CommandText = strQuery
            .Connection = dbcon
        End With
        With sqlAdapter
            .SelectCommand = SQLCmd
            .Fill(dataS)

        End With
        'CLears the table before loading

        DropDownList1.DataSource = dataS
        DropDownList1.DataTextField = "RestName"
        DropDownList1.DataValueField = "RestID"

        If (Not IsPostBack) Then
            DropDownList1.DataBind()
        End If


        For i = 0 To dataS.Rows.Count - 1
            OrderRestArray.Add(dataS.Rows(i)("OrderString"))
            RestIDArray.Add(dataS.Rows(i)("RestID"))
        Next
        ChangeSelectIndex()
        dbcon.Close()

    End Sub

    Sub ChangeSelectIndex()
        Session("RestName") = DropDownList1.SelectedItem.ToString
        Session("RestId") = DropDownList1.SelectedValue
        Session("OrderString") = OrderRestArray.Item(RestIDArray.IndexOf(DropDownList1.SelectedValue))
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session("RestName") = DropDownList1.SelectedItem.ToString
        Session("RestId") = DropDownList1.SelectedValue
        Session("OrderString") = OrderRestArray.Item(RestIDArray.IndexOf(DropDownList1.SelectedValue))
    End Sub
End Class