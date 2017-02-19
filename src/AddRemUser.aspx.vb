Public Class AddRemUser
    Inherits System.Web.UI.Page
    Dim dbcon As New SqlConnection

    Private Sub AddRemUser_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dbcon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringMDF").ConnectionString
    End Sub

    Protected Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        clearBoxes()
    End Sub

    Sub clearBoxes()
        TxtBoxName.Text = ""
        TxtBoxUserID.Text = ""
        ActiveCheckBox.Checked = True
    End Sub

    Protected Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        If TxtBoxUserID.Text = "" Or TxtBoxName.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err1", "alert('Empty Entries');", True)
        ElseIf TxtBoxUserID.Text.Length > 55 Or Not (Regex.IsMatch(TxtBoxName.Text, "^[a-zA-Z\s]*$")) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err2", "alert('Name Only Alphabet Characters allowed, Max Length 55');", True)
        ElseIf TxtBoxUserID.Text.Length > 6 Or Not (Regex.IsMatch(TxtBoxUserID.Text, "^[a-zA-Z0-9]*$")) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "err2", "alert('UserID Only AlphaNumeric Characters allowed, Max Length 6');", True)
        
        Else
            ''''add item
            ' Dim Restid As String = DropDownList1.SelectedValue

            'If DropDownList1.SelectedValue <> -1 Then Restid = DropDownList1.SelectedValue Else Restid = "001"
            Dim sqlQ As String
            Dim sqlCmd As New SqlCommand
            sqlQ = " INSERT INTO Users(UserID,Name,Active,pwd) values ('" & TxtBoxUserID.Text & "','" & TxtBoxName.Text & "','" & ActiveCheckBox.Checked & "','12345');"

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
                ClientScript.RegisterStartupScript(Me.GetType(), "error4", "alert('User Not Added');", True)

            End Try


        End If

    End Sub

    Private Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs) Handles GridView1.PageIndexChanged
        GridView1.SelectedIndex = -1
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim sqlQ As String
        Dim sqlCmd As New SqlCommand
        sqlQ = "UPDATE Users SET Pwd='12345' WHERE (userid = '" & GridView1.SelectedRow.Cells(1).Text & "');"

        If dbcon.State = ConnectionState.Closed Then
            dbcon.Open()
        End If
        Try

            With sqlCmd
                .CommandText = sqlQ
                .Connection = dbcon
                .ExecuteNonQuery()
            End With
            ClientScript.RegisterStartupScript(Me.GetType(), "msg5", "alert('Password successfully Reset to 12345');", True)
        Catch
            ClientScript.RegisterStartupScript(Me.GetType(), "error4", "alert('Password not Reset');", True)

        End Try
        GridView1.SelectedIndex = -1
    End Sub
End Class