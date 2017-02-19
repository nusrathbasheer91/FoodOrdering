Public Class AddRemItem
    Inherits System.Web.UI.Page
    Dim dbcon As New SqlConnection

    Private Sub AddRemItem_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        End If
    End Sub

    'Private Sub AddRemItem_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
    '    If Session("LoginID") = "" Or Session("LoginID") <> "admin" Then
    '        ClientScript.RegisterStartupScript(Me.GetType(), "adminerr1", "alert('Please Login First');", True)
    '        'Response.Write("<script>alert('Please Login First');</script>")
    '        Response.Redirect("Login.aspx", False)
    '    End If
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
    End Sub

    Protected Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        If NameTextBox.Text = "" Or PriceTextBox.Text = "" Or OrderTypeTextBox.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err1", "alert('Empty Entries');", True)
        ElseIf OrderTypeTextBox.Text.Length > 1 Or Not (Regex.IsMatch(OrderTypeTextBox.Text, "^[A-Z]")) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err2", "alert('Order Type can only be a Capital Letter of Length = 1');", True)
        ElseIf Not (IsNumeric(PriceTextBox.Text) AndAlso (CDec(PriceTextBox.Text) < 100.0 Or CDec(PriceTextBox.Text) <= 0)) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err2", "alert('Price should be a Number and Cannot be more than 100');", True)
        Else
            ''''add item
            Dim Restid As String = DropDownList1.SelectedValue

            'If DropDownList1.SelectedValue <> -1 Then Restid = DropDownList1.SelectedValue Else Restid = "001"
            Dim sqlQ As String
            Dim sqlCmd As New SqlCommand
            sqlQ = "if exists (select itemid from items where restid='" & Restid & "')" & _
                    " INSERT INTO Items(ItemId, RestId, Name, Price, OrderType, Active) select RIGHT('000'+CONVERT(varchar(3),max(itemid)+1),3)as itemid,'" & Restid & "','" & NameTextBox.Text & "','" & CDec(PriceTextBox.Text) & "','" & OrderTypeTextBox.Text & "','" & ActiveCheckBox.Checked & "' from items ;" & _
                    " else if not exists (select itemid from items where restid='" & Restid & "')" & _
                    " INSERT INTO Items(ItemId, RestId, Name, Price, OrderType, Active)  values('001','" & Restid & "','" & NameTextBox.Text & "','" & CDec(PriceTextBox.Text) & "','" & OrderTypeTextBox.Text & "','" & ActiveCheckBox.Checked & "');"

            If dbcon.State = ConnectionState.Closed Then
                dbcon.Open()
            End If
            Try

                With sqlCmd
                    .CommandText = sqlQ
                    .Connection = dbcon
                    .ExecuteNonQuery()
                End With
                clearBoxes()
                GridView1.DataBind()
            Catch
                ClientScript.RegisterStartupScript(Me.GetType(), "error4", "alert('Item Not Added');", True)

            End Try


        End If
    End Sub

    Protected Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        clearBoxes()
    End Sub

    Sub clearBoxes()
        NameTextBox.Text = ""
        PriceTextBox.Text = ""
        OrderTypeTextBox.Text = ""
        ActiveCheckBox.Checked = True
    End Sub
End Class