Public Class RunReports
    Inherits System.Web.UI.Page

    Private Sub RunReports_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        
        If Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "admino", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        Else
            DropDownListRest.Items.Insert(0, New ListItem("All", "000"))
            DropDownListUsers.Items.Insert(0, New ListItem("All", "000"))
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

 
    Protected Sub ViewButton_Click(sender As Object, e As ImageClickEventArgs) Handles ViewButton.Click
        If TxtStartDate.Text = "" Or TxtEndDate.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "er1", "alert('Empty Date Entries');", True)
        ElseIf Not (IsDate(TxtStartDate.Text) And IsDate(TxtEndDate.Text)) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "er2", "alert('Invalid Date Entered');", True)
        ElseIf CDate(TxtStartDate.Text) > CDate(TxtEndDate.Text) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "er3", "alert('Start Date is Later than End Date');", True)
        ElseIf DateDiff(DateInterval.Day, CDate(TxtStartDate.Text), CDate(TxtEndDate.Text)) > 40 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "er4", "alert('Maximum Date Period Length = 40');", True)
        Else
            Session("startDate") = Format(CDate(TxtStartDate.Text), "yyyy-MM-dd")
            Session("endDate") = Format(CDate(TxtEndDate.Text), "yyyy-MM-dd")
            Session("RestR") = DropDownListRest.SelectedValue
            Session("UserR") = DropDownListUsers.SelectedValue
            Session("RName") = DropDownListReport.SelectedValue
            ClientScript.RegisterStartupScript(Me.GetType(), "info1", "alert('Parameters you selected are StartDate=" & TxtStartDate.Text & ", EndDate=" & TxtEndDate.Text & ",Rest=" & DropDownListRest.SelectedItem.Text.Replace("'", "") & ", User=" & DropDownListUsers.SelectedItem.Text & "');window.location = ""ReportDisplay2.aspx""", True)
        End If
    End Sub
End Class