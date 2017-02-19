Imports System.Data
Imports System.Data.SqlClient

Public Class ChangePwd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub LoginButton_Click(sender As Object, e As ImageClickEventArgs) Handles LoginButton.Click
        If TxtUserID.Text = "" Or TxtPwd.Text = "" Or TxtNPwd1.Text = "" Or TxtNPwd2.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "InPwd", "alert('Invalid Login : Check UserId and Password');", True)
        ElseIf TxtNPwd1.Text <> TxtNPwd2.Text Then
            ClientScript.RegisterStartupScript(Me.GetType(), "InPwd1", "alert('Passwords do not Match');", True)
        ElseIf TxtNPwd1.Text.Length < 5 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "InPwd3", "alert('MINIMUM Password Length is 5');", True)
        ElseIf isNotAlphaNumeric(TxtNPwd1.Text) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "InPwd2", "alert('Password CANNOT contain special characters');", True)

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
                ClientScript.RegisterStartupScript(Me.GetType(), "InPwd", "alert('Invalid Login : Check UserId and Password and check if Active');", True)
                mydata.Close()
            Else
                'Update PWD
                mydata.Close()

                If dbcon.State = ConnectionState.Closed Then
                    dbcon.Open()
                End If
                sqlQ = "Update users set pwd='" & TxtNPwd1.Text & "' where userid='" & TxtUserID.Text & "' ;"
                Try

                    With SQLCmd
                        .CommandText = sqlQ
                        .Connection = dbcon
                        .ExecuteNonQuery()
                    End With
                    ClientScript.RegisterStartupScript(Me.GetType(), "PwdSuccess", "alert('Password Successfully Changed');window.location = ""Login.aspx""", True)

                Catch 'Ex As SqlException
                    ClientScript.RegisterStartupScript(Me.GetType(), "InPwd2", "alert('Error connecting to Database');", True)
                End Try

                ''''''
            End If

        End If
    End Sub
    Function isNotAlphaNumeric(strToCheck As String) As Boolean
        Dim rg As New Regex("^[a-zA-Z0-9]*$")
        Return (Not rg.IsMatch(strToCheck))
    End Function
End Class