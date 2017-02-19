Public Class AddRemRest
    Inherits System.Web.UI.Page
    Dim dbcon As New SqlConnection

    Private Sub AddRemRest_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        End If
    End Sub

    'Private Sub AddRemRest_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
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
        If NameTextBox.Text = "" Or OrderStringTextBox.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err1", "alert('Empty Entries');", True)
        ElseIf OrderStringTextBox.Text.Length < 1 Or Not (Regex.IsMatch(OrderStringTextBox.Text, "^((([A-Y](\+[A-Y])*)(,([A-Y](\+[A-Y])*))*)*(.Z)?)$")) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err2", "alert('Invalid OrderString, Refer to help Manual');", True)
        Else
            ''''add item
            ' Dim Restid As String = DropDownList1.SelectedValue

            'If DropDownList1.SelectedValue <> -1 Then Restid = DropDownList1.SelectedValue Else Restid = "001"
            Dim sqlQ As String
            Dim sqlCmd As New SqlCommand
            sqlQ = " INSERT INTO Rest(RestID, RestName, OrderString, Active) select RIGHT('000'+CONVERT(varchar(3),max(RestID)+1),3)as RestID,'" & NameTextBox.Text & "','" & OrderStringTextBox.Text & "','" & ActiveCheckBox.Checked & "' from Rest ;"
                  
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
                ClientScript.RegisterStartupScript(Me.GetType(), "error4", "alert('Rest Not Added');", True)

            End Try


        End If
    End Sub

    Protected Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        clearBoxes()
    End Sub

    Sub clearBoxes()
        NameTextBox.Text = ""
        OrderStringTextBox.Text = ""
        ActiveCheckBox.Checked = True
    End Sub
End Class