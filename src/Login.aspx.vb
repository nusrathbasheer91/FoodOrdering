Imports System.Data
Imports System.Data.SqlClient
'Imports System.Configuration

Public Class Login
    Inherits System.Web.UI.Page
    'Dim alert As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim adminmsg As String = System.Configuration.ConfigurationManager.AppSettings("adminmsg")
        Dim disable As String = System.Configuration.ConfigurationManager.AppSettings("disable")
        If disable = "" And adminmsg <> "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AdminMsg1", "alert('" & adminmsg & "');", True)
        ElseIf IsDate(disable) AndAlso CDate(disable) >= Today AndAlso adminmsg <> "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AdminMsg2", "alert('" & adminmsg & ", Ordering is DISABLED TODAY');", True)
        ElseIf IsDate(disable) AndAlso CDate(disable) >= Today AndAlso adminmsg = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "AdminMsg3", "alert('Ordering is DISABLED TODAY');", True)
        Else
            'ClientScript.RegisterStartupScript(Me.GetType(), "Login", "", True)
            'If alert = True Then
            '    ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", "alert('Invalid Login : Check UserId and Password');", True)
            '    alert = False
            'Else
            '    ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", "", True)
            'End If
            Session("LoginID") = ""
            'Response.ExpiresAbsolute = DateTime.Now.AddDays(-1D)
            'Response.Expires = -1500
            'Response.CacheControl = "no-cache"
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1))
            Response.Cache.SetNoStore()

            HttpResponse.RemoveOutputCacheItem("/caching/PlaceOrder.aspx")
            'Dim strI As String = Page.IsPostBack.ToString
            'Dim script As String
            'If (IsPostBack) Then
            '    script = "var isPostBack = true;"
            'Else
            '    script = "var isPostBack = false;"
            'End If
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "IsPostBack", script, True)

        End If


    End Sub

    Protected Sub LoginButton_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles LoginButton.Click
        If TxtUserID.Text = "" Or TxtPwd.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", "alert('Invalid Login : Check UserId and Password');", True)
            ' alert = True
            'ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", script, False)
            'Response.Write("<script>alert('Please Enter Valid UserID');</script>")
            'ClientScript.RegisterStartupScript(Me.GetType(), "UserID", "alert('Please Enter Valid UserID');__doPostBack('__Page', 'EmptyPostback');", True)
            'ElseIf  Then
            '    ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", "alert('Invalid Login : Check UserId and Password');", True)
            ' alert = True
            'ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", script, False)
            'Response.Write("<script>alert('Please Enter Valid Password');</script>")
            'ClientScript.RegisterStartupScript(Me.GetType(), "Pwd", "alert('Please Enter Valid Password');__doPostBack('__Page', 'EmptyPostback');", True)
      Else
            Dim dbcon As New SqlConnection
            Dim sqlQ As String = "Select * from users where userid= '" & TxtUserID.Text & "' and pwd='" & TxtPwd.Text & "' and active=1;"
            Dim sqlAdapter As New SqlDataAdapter
            Dim SQLCmd As New SqlCommand
            Dim Table1 As New DataTable
            If dbcon.State = ConnectionState.Closed Then
                dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
                Try
                    dbcon.Open()
                    ' MsgBox("dbcon Open")
                Catch ex As Exception
                    ClientScript.RegisterStartupScript(Me.GetType(), "InPwd2", "alert('Error connecting to Database');", True)
                End Try
            End If

            With SQLCmd
                .CommandText = sqlQ
                .Connection = dbcon
            End With
            With sqlAdapter
                .SelectCommand = SQLCmd
                .Fill(Table1)
            End With
            Dim mydata As SqlDataReader
            mydata = SQLCmd.ExecuteReader
            If mydata.HasRows = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", "alert('Invalid Login : Check UserId and Password');", True)
                ' alert = True
                'Response.Write("<script>alert('Invalid Login : Check UserId and Password');</script>")
                'ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", script, False)
                ' ClientScript.RegisterStartupScript(Me.GetType(), "InLogin", "alert('Invalid Login : Check UserId and Password');__doPostBack('__Page', 'EmptyPostback');", True)
                mydata.Close()
                ' Me.Close()
            Else
                'alert = False
                'Response.Write("<script>alert('Login Accepted');</script>")
                'Cache.Remove("InLogin")
                'Cache.Remove("UserId")
                'Cache.Remove("Pwd")
                If TxtPwd.Text = "12345" Then ''''''''''''''''''''''''''''''''''CHANGE
                    ClientScript.RegisterStartupScript(Me.GetType(), "LoginMsg2", "alert('Please Change Password before Placing Order');window.location = ""ChangePwd.aspx""", True)
                Else
                    Session("UserName") = Table1.Rows(0)("Name").ToString
                    Session("LoginID") = Table1.Rows(0)("UserID").ToString
                    If Table1.Rows(0)("UserID").ToString = "admin" Then
                        Response.Redirect("AdminHome.aspx", False)
                    Else
                        Response.Redirect("PlaceOrder.aspx", False)
                    End If
                End If
                
                mydata.Close()
                'ClientScript.RegisterStartupScript(Me.GetType(), "Login", "alert('Login Accepted');window.location = ""PlaceOrder.aspx""", True)

            End If


        End If

    End Sub
    'Sub ShowMessage()
    '    If Not IsPostBack Then
    '        Label1.Text = "Invalid Login"
    '    End If
    'End Sub ''HTML CODE TO SHOW MESSAGE NEXT LINE


End Class