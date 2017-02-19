Imports System.Data
Imports System.Data.SqlClient
'Imports System.Configuration

Public Class SelectItems
    Inherits System.Web.UI.Page
    Dim button2clicked As Boolean
    Public RestId As String '= CStr(Session("RestID")) '= CType(Me.ViewState("restNameinViewState"), String)
    Public OrderStringRest As String
    ' Public OrderStringGrid2 As String
    Dim OrderArray As New List(Of Char)
    'Dim LastItem As GridViewRow
    Public RestName As String
    Public StrO As String
    Public UserID As String
    Public UserName As String
    Dim dbcon As New SqlConnection
    Dim amount As New Decimal
    Public confString As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Session.Abandon()
        'FormsAuthentication.SignOut()
      
        If Session.Item("LoginID") = "" Or Session.Item("RestID") = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "error1", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)

        Else
            button2clicked = CType(Session("button2clicked"), Boolean)
            UserID = CStr(Session.Item("LoginID"))
            UserName = Session("UserName")

            amount = System.Configuration.ConfigurationManager.AppSettings("amount")
            GetRestDetails()
            txtRestID.Text = RestId
            'If txtUserName.Text = "" Then
            '    txtUserName.Text = UserName
            'Else
            '    UserName = txtUserName.Text
            'End If
            'If GridView2.Rows.Count > 0 Then
            '    UserName = GridView2.Rows(0).Cells(7).Text
            '    txtUserName.Text = UserName
            'End If
            txtUserName.Text = UserName

            For i = 0 To GridView2.Rows.Count - 1
                If GridView2.Rows(i).Cells(5).Text <> "Z" Then
                    OrderArray.Add(GridView2.Rows(i).Cells(5).Text)
                End If
            Next
            OrderArray.Sort()
            'HideNShow()
            'CheckOrderRest()
            If dbcon.State = ConnectionState.Closed Then
                dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
                dbcon.Open()
            End If
            '''''Asks if you want to delete order for another restaurant
            CheckConfirmed()
        End If
    End Sub

    Sub CheckConfirmed()

        Dim sqlQ As String = "Select * from orders where userid= '" & UserID & "' and dateO=cast(GETDATE() as date) ;"
        Dim sqlAdapter As New SqlDataAdapter
        Dim SQLCmd As New SqlCommand
        Dim Table1 As New DataTable
        If dbcon.State = ConnectionState.Closed Then
            dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
            dbcon.Open()
        End If
        ' MsgBox("dbcon Open")


        With SQLCmd
            .CommandText = sqlQ
            .Connection = dbcon
        End With
        With sqlAdapter
            .SelectCommand = SQLCmd
            .Fill(Table1)
        End With
        'Dim mydata As SqlDataReader
        'mydata = SQLCmd.ExecuteReader
        If Table1.Rows.Count > 0 Then
            GridView1.Columns(0).Visible = False
            ButtonConfirm.Enabled = False
            ButtonClear.Enabled = False
            txtTotal.Text = ""
            GridView2.Columns(0).Visible = False
            confString = "Your Order has been CONFIRMED. To make any changes, please contact admin"
        Else
            confString = ""
            'Page.Response.Output.WriteLine("<p style=""text-align:centre; "">I am a test</p>");
        End If
        'mydata.Close()
    End Sub

    Sub CheckOrderRest()
        Dim sqlq As String = "select * from ordersTemp where userid='" & UserID & "' and dateO=cast(GETDATE() as date) and restid!='" & RestId & "';"
        Dim sqlCmd As New SqlCommand
        Dim sqlAdapter As New SqlDataAdapter
        Dim table As New DataTable

        If dbcon.State = ConnectionState.Closed Then
            dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
            dbcon.Open()
        End If
        Try

            With sqlCmd
                .CommandText = sqlq
                .Connection = dbcon
            End With
            With sqlAdapter
                .SelectCommand = sqlCmd
                .Fill(Table)
            End With
            Dim mydata As SqlDataReader
            mydata = sqlCmd.ExecuteReader
            If mydata.HasRows = True Then
                ClientScript.RegisterStartupScript(Me.GetType(), "popup1", "confirmProcess();", True)
                mydata.Close()
                'sqlq = "delete from orders where userid='" & UserID & "' and restid!='" & RestId & "';"
                'With sqlCmd
                '    .CommandText = sqlq
                '    .Connection = dbcon
                '    .ExecuteNonQuery()
                'End With
            Else
                Session("button2clicked") = True
                button2clicked = True

            End If
            mydata.Close()
        Catch
            ClientScript.RegisterStartupScript(Me.GetType(), "InSelect", "alert('Error connecting to Database');", True)
        End Try

    End Sub

    Sub HideNShow()

        'For i2 = 0 To GridView2.Rows.Count - 1
        '    For i1 = 0 To GridView1.Rows.Count - 1
        '        If GridView2.Rows(i2).Cells(2).Text = GridView1.Rows(i1).Cells(1).Text Then
        '            GridView1.Rows(i1).Visible = False
        '            Exit For
        '        End If
        '    Next
        'Next
        For Each row2 In GridView2.Rows
            For Each row1 In GridView1.Rows
                If row2.Cells(2).Text = row1.Cells(1).Text Then
                    row1.Visible = False
                    Exit For
                End If
            Next
        Next
    End Sub

    Sub GetRestDetails()
        RestId = Session("RestID")
        RestName = Session("RestName")
        OrderStringRest = Session("OrderString")

        StrO = "Select one Item each in " & Replace(OrderStringRest, ",", "<br />OR Select one Item each in ")
        StrO = Replace(StrO, "+", ",")
        StrO = Replace(StrO, ".Z", "<br />Select 0 or more items in Z")
        StrO = StrO & "<br />Maximum Order Price = " & amount & ""

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sqlq As String
        Dim sqlCmd As New SqlCommand
        Session("button2clicked") = True
        button2clicked = True
        If dbcon.State = ConnectionState.Closed Then
            dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
            dbcon.Open()
        End If
        sqlq = "delete from ordersTemp where userid='" & UserID & "' and restid!='" & RestId & "';"
        With sqlCmd
            .CommandText = sqlq
            .Connection = dbcon
            .ExecuteNonQuery()
        End With
        GridView2.DataBind()
        txtTotal.Text = ""
    End Sub


    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim sqlQ As String
        Dim sqlCmd As New SqlCommand
        Dim OrderStringGrid2 As String = ""
        CheckOrderRest()


        sqlQ = "if exists (select orderno from ordersTemp where userid='" & UserID & "' and dateO=cast(GETDATE() as date))" & _
                " insert into ordersTemp (orderno,restid,itemid,ordertype,NameofO,UserID,Price) select distinct orderno,'" & RestId & "','" & GridView1.SelectedRow.Cells(1).Text & "','" & GridView1.SelectedRow.Cells(4).Text & "','" & UserName & "','" & UserID & "','" & GridView1.SelectedRow.Cells(3).Text & "' from ordersTemp where userid='" & UserID & "' and dateO=cast(GETDATE() as date);" & _
                " else if not exists (select * from ordersTemp where dateO=cast(GETDATE() as date))" & _
                " insert into ordersTemp (orderno,restid,itemid,ordertype,NameofO,UserID,Price) values(1,'" & RestId & "','" & GridView1.SelectedRow.Cells(1).Text & "','" & GridView1.SelectedRow.Cells(4).Text & "','" & UserName & "','" & UserID & "','" & GridView1.SelectedRow.Cells(3).Text & "') ;" & _
                " else" & _
                " insert into ordersTemp (orderno,restid,itemid,ordertype,NameofO,UserID,Price) select max(Orderno)+1 as orderno,'" & RestId & "','" & GridView1.SelectedRow.Cells(1).Text & "','" & GridView1.SelectedRow.Cells(4).Text & "','" & UserName & "','" & UserID & "','" & GridView1.SelectedRow.Cells(3).Text & "' from ordersTemp where dateO=cast(GETDATE() as date);"

        'sqlQ = "insert into orders (orderno,restid,itemid,ordertype,NameofO,UserID) values ((if exists (select orderno from orders where userid='" & UserID & "') select orderno from orders where userid='" & UserID & "' else select max(Orderno)+1 as orderno from orders),'" & RestId & "','" & GridView1.SelectedRow.Cells(1).Text & "','" & GridView1.SelectedRow.Cells(4).Text & "','" & txtUserName.Text & "','" & UserID & "'); "
        If button2clicked = True Then
            If txtTotal.Text <> "" AndAlso CDec(txtTotal.Text) + CDec(GridView1.SelectedRow.Cells(3).Text) > amount Then

                ClientScript.RegisterStartupScript(Me.GetType(), "error2", "alert('Total Order Amount exceeds Predefined Amount. Please remove items from Order and Try again.');", True)
                'Response.Write("<script>alert('Total Order Amount exceeds Predefined Amount. Please remove items from Order and Try again.');</script>")
            Else
                If GridView1.SelectedRow.Cells(4).Text <> "Z" Then
                    OrderArray.Add(GridView1.SelectedRow.Cells(4).Text)
                    OrderArray.Sort()
                    OrderStringGrid2 = String.Join("+", OrderArray)
                End If
                'If OrderStringGrid2.Contains("Z") Then OrderStringGrid2 = OrderStringGrid2.Remove(OrderStringGrid2.IndexOf("+Z"))
                If OrderStringGrid2 <> "" AndAlso Not OrderStringRest.Contains(OrderStringGrid2) Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "error3", "alert('Cannot add this Item to current Order Items. Please remove items from Order and Try again.');", True)
                    'Response.Write("<script>alert('Can't add this Item to current Order Items. Please remove items from Order and Try again.');</script>")

                Else
                    ' txtOrderString.Text = String.Join("", OrderArray.ToString)

                    If dbcon.State = ConnectionState.Closed Then
                        dbcon.Open()
                    End If
                    Try

                        With sqlCmd
                            .CommandText = sqlQ
                            .Connection = dbcon
                            .ExecuteNonQuery()
                        End With
                        txtTotal.Text = ""
                        GridView2.DataBind()
                        GridView1.SelectedRow.Visible = False
                        ' LastItem = GridView1.SelectedRow
                    Catch
                        ClientScript.RegisterStartupScript(Me.GetType(), "error4", "alert('Duplicate Item ID');", True)
                        'Response.Write("<script>alert('Duplicate Item ID');</script>")
                        'MsgBox("ERROR ADDING RECORD" & System.Environment.NewLine & ex.Message)
                        Response.Redirect("SelectItems.aspx", False)
                    End Try
                End If
                End If
        End If
    End Sub


    Private Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        dbcon.Close()

    End Sub

    'Private Sub GridView2_Load(sender As Object, e As EventArgs) Handles GridView2.Load
    '    HideNShow()

    'End Sub

    Private Sub GridView2_PreRender(sender As Object, e As EventArgs) Handles GridView2.PreRender
        HideNShow()

    End Sub

    Private Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim tot As Decimal = 0
        If txtTotal.Text <> "" Then tot += CDec(txtTotal.Text)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            tot += CDec(e.Row.Cells(4).Text)
            txtTotal.Text = tot.ToString()
        End If

    End Sub

    Private Sub GridView2_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView2.RowDeleting

        txtTotal.Text = ""
        'OrderArray.Remove(GridView2.Rows(e.RowIndex).Cells(5).Text)
        'OrderArray.Sort()
        'OrderStringGrid2 = String.Join("+", OrderArray)
        For Each row In GridView1.Rows
            If row.cells(1).text = GridView2.Rows(e.RowIndex).Cells(2).Text Then
                row.visible = True
                Return
            End If
        Next

    End Sub


    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        Dim sqlq As String
        Dim sqlCmd As New SqlCommand
        If dbcon.State = ConnectionState.Closed Then
            dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
            dbcon.Open()
        End If
        sqlq = "delete from ordersTemp where userid='" & UserID & "';"
        With sqlCmd
            .CommandText = sqlq
            .Connection = dbcon
            .ExecuteNonQuery()
        End With
        GridView2.DataBind()
        For i = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Visible = True
        Next
        txtTotal.Text = ""
    End Sub

    Private Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click
        Dim orderstart As String = System.Configuration.ConfigurationManager.AppSettings("orderstart")
        Dim orderend As String = System.Configuration.ConfigurationManager.AppSettings("orderend")

        If CType(orderstart, Date).TimeOfDay >= DateTime.Now.TimeOfDay Or CType(orderend, Date).TimeOfDay <= DateTime.Now.TimeOfDay Then
            ClientScript.RegisterStartupScript(Me.GetType(), "Printed1", "alert('Your Order has not been CONFIRMED. Time to Place Orders has Lapsed, Contact admin to place Order');window.location = ""Home.aspx""", True)
        ElseIf txtTotal.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "Amount", "alert('You have not ordered Items yet');", True)
        ElseIf CInt(txtTotal.Text) < amount And RestName <> "McDonald's" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "Amount", "alert('You have ordered Items for less than prescribed Amount SAR " & amount & "');", True)
        ElseIf CheckWrongOrderString() Then
            ClientScript.RegisterStartupScript(Me.GetType(), "Amount", "alert('Your order is incomplete, " & StrO.Replace("<br />", " ") & "');", True) ''''
        Else
            Dim sqlq As String = "insert into orders (orderno,restid,itemid,ordertype,NameofO,UserID,Price) select orderno,restid,itemid,ordertype,NameofO,UserID,Price from OrdersTemp where userid='" & UserID & "' and dateO=cast(GETDATE() as date) "
            Dim sqlCmd As New SqlCommand
            If dbcon.State = ConnectionState.Closed Then
                dbcon.Open()
            End If
            Try

                With sqlCmd
                    .CommandText = sqlq
                    .Connection = dbcon
                    .ExecuteNonQuery()
                End With

                GridView1.Columns(0).Visible = False
                ButtonConfirm.Enabled = False
                ButtonClear.Enabled = False
                txtTotal.Text = ""
                GridView2.Columns(0).Visible = False
                confString = "Your Order has been CONFIRMED. To make any changes, please contact admin"
                ClientScript.RegisterStartupScript(Me.GetType(), "Amount", "alert('Your Order has been Successfully Placed');", True)
            Catch
                ClientScript.RegisterStartupScript(Me.GetType(), "error5", "alert('Could not Confirm Order.Please Try Again');", True)
            End Try
        End If
    End Sub
    Function CheckWrongOrderString()
        Dim RestOrderArray As List(Of String) = OrderStringRest.Split(".")(0).Split(",").ToList()
        Dim OrderStringGRID As String = String.Join("+", OrderArray)
        'If OrderStringGRID.Contains("Z") Then OrderStringGRID = OrderStringGRID.Remove(OrderStringGRID.IndexOf("+Z"))
        'StrO = StrO.Remove(StrO.IndexOf(","))
        If RestOrderArray.IndexOf(OrderStringGRID) >= 0 Or OrderStringGRID = "" Then
            Return False
        Else
            Return True
        End If
    End Function

End Class