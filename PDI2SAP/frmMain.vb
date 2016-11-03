Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtDate.Text = RefreshDate()
        txtProfitCtr.Text = My.Settings.ProfitCenter
        txtText.Text = My.Settings.Text



    End Sub

    Private Sub btnRDate_Click(sender As Object, e As EventArgs) Handles btnRDate.Click
        txtDate.Text = RefreshDate()
    End Sub

    Private Sub txtDate_TextChanged(sender As Object, e As EventArgs) Handles txtDate.TextChanged, txtProfitCtr.TextChanged, txtText.TextChanged

        Dim obj = CType(sender, TextBox)
        If obj.Text = RefreshDate() Then
            obj.BackColor = Color.LightGreen
        Else
            obj.BackColor = System.Drawing.SystemColors.Window
        End If

    End Sub


    Private Function ClosingYear() As String
        If Today.Month >= 7 Then
            Return Today.Year + 1
        Else
            Return Today.Year
        End If

    End Function


    Private Function RefreshDate() As String
        Return Today.ToString("ddMMyyyy")
    End Function


End Class
