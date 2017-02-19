Public Class Admin
    Inherits System.Web.UI.Page

    Private Sub Admin_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        If Session("LoginID") = "" Or Session("LoginID") <> "admin" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr1", "alert('Please Login First');", True)
            'Response.Write("<script>alert('Please Login First');</script>")
            Response.Redirect("Login.aspx", False)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtAmountRO.Text = System.Configuration.ConfigurationManager.AppSettings("amount")
        TxtClientRO.Text = System.Configuration.ConfigurationManager.AppSettings("clientname")
        TxtMsgRO.Text = System.Configuration.ConfigurationManager.AppSettings("adminmsg")
        TxtDisableRO.Text = System.Configuration.ConfigurationManager.AppSettings("disable")
    End Sub

    Private Sub ButtonClientNameUpdate_Click(sender As Object, e As EventArgs) Handles ButtonClientNameUpdate.Click
        If TxtClient.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr2", "alert('Invalid Entry');", True)
        Else
            'System.Configuration.ConfigurationManager.AppSettings("amount") = TxtAmount.Text
        End If
    End Sub

    Protected Sub ButtonMsgUpdate_Click(sender As Object, e As EventArgs) Handles ButtonMsgUpdate.Click

    End Sub

    Protected Sub ButtonCostUpdate_Click(sender As Object, e As EventArgs) Handles ButtonCostUpdate.Click

    End Sub

    Protected Sub ButtonDisableUpdate_Click(sender As Object, e As EventArgs) Handles ButtonDisableUpdate.Click

    End Sub

    Protected Sub ButtonMsgClear_Click(sender As Object, e As EventArgs) Handles ButtonMsgClear.Click

    End Sub

    Protected Sub ButtonDisableClear_Click(sender As Object, e As EventArgs) Handles ButtonDisableClear.Click

    End Sub

    'Protected Sub EditConfigButton(sender As Object, e As EventArgs)
    '    Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
    '    Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
    '    'Edit
    '    If objAppsettings IsNot Nothing Then
    '        objAppsettings.Settings("test").Value = "newvalueFromCode"
    '        objConfig.Save()
    '    End If
    'End Sub
End Class