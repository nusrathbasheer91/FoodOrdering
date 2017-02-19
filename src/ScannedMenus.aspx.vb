Public Class ScannedMenus
    Inherits System.Web.UI.Page
    Dim myImg As New Image
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        myImg.ImageUrl = "~/Resources/" & DropDownList1.SelectedValue & ".jpg"
        myImg.Visible = True
        myImg.Width = 800
        Panel1.Controls.Add(myImg)
    End Sub
End Class