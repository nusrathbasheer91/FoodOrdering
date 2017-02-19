Public Class AdminSettings
    Inherits System.Web.UI.Page

    Private Sub AdminSettings_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
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
        TxtorderendRO.Text = System.Configuration.ConfigurationManager.AppSettings("orderend")
        TxtorderstartRO.Text = System.Configuration.ConfigurationManager.AppSettings("orderstart")
    End Sub
    Private Sub ButtonClientNameUpdate_Click(sender As Object, e As EventArgs) Handles ButtonClientNameUpdate.Click
        If Not (Regex.IsMatch(TxtClient.Text, "^[a-zA-Z1-9]")) Or TxtClient.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr2", "alert('Invalid Entry for ClientName, can only contain Letters and Numbers');", True)
        Else
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("clientname").Value = TxtClient.Text
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
            'System.Configuration.ConfigurationManager.AppSettings("amount") = TxtAmount.Text
        End If
    End Sub

    Protected Sub ButtonMsgUpdate_Click(sender As Object, e As EventArgs) Handles ButtonMsgUpdate.Click
        If Not (Regex.IsMatch(TxtMsg.Text, "^[a-zA-Z1-9]")) Or TxtMsg.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr3", "alert('Admin message can only contain Letters and Numbers');", True)
        Else
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("adminmsg").Value = TxtMsg.Text
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
            'System.Configuration.ConfigurationManager.AppSettings("amount") = TxtAmount.Text
        End If
    End Sub

    Protected Sub ButtonCostUpdate_Click(sender As Object, e As EventArgs) Handles ButtonCostUpdate.Click
        If Not (IsNumeric(TxtAmount.Text)) Or TxtAmount.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr4", "alert('Invalid Entry for Cost');", True)
        Else
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("amount").Value = TxtAmount.Text
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
            'System.Configuration.ConfigurationManager.AppSettings("amount") = TxtAmount.Text
        End If
    End Sub

    Protected Sub ButtonDisableUpdate_Click(sender As Object, e As EventArgs) Handles ButtonDisableUpdate.Click
        If Not (IsDate(TxtDisable.Text)) Or TxtDisable.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr5", "alert('Invalid Entry for Disable till. Date Format : dd-mm-yyyy');", True)
        Else
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("disable").Value = Format(CDate(TxtDisable.Text), "dd-MM-yyyy")
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
            'System.Configuration.ConfigurationManager.AppSettings("amount") = TxtAmount.Text
        End If
    End Sub

    Protected Sub ButtonMsgClear_Click(sender As Object, e As EventArgs) Handles ButtonMsgClear.Click
        If TxtMsgRO.Text <> "" Then
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("adminmsg").Value = ""
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
        End If
    End Sub

    Protected Sub ButtonDisableClear_Click(sender As Object, e As EventArgs) Handles ButtonDisableClear.Click
        If TxtDisableRO.Text <> "" Then
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("disable").Value = ""
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
        End If
    End Sub

    Private Sub ButtonOrderStartUpdate_Click(sender As Object, e As EventArgs) Handles ButtonOrderStartUpdate.Click
        If Not (Regex.IsMatch(Txtorderstart.Text, "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$")) Or Txtorderstart.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr6", "alert('Invalid Entry for OrderStart. Time Format hh:mm');", True)
        Else
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("orderstart").Value = Txtorderstart.Text
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
        End If
    End Sub

    Private Sub ButtonOrderEndUpdate_Click(sender As Object, e As EventArgs) Handles ButtonOrderEndUpdate.Click
        If Not (Regex.IsMatch(Txtorderend.Text, "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$")) Or Txtorderend.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "adminerr7", "alert('Invalid Entry for OrderEnd. Time Format hh:mm');", True)
        Else
            Dim objConfig As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            Dim objAppsettings As AppSettingsSection = DirectCast(objConfig.GetSection("appSettings"), AppSettingsSection)
            'Edit
            If objAppsettings IsNot Nothing Then
                objAppsettings.Settings("orderend").Value = Txtorderend.Text
                objConfig.Save()
            End If
            Response.Redirect(Request.RawUrl, False)
        End If
    End Sub
End Class