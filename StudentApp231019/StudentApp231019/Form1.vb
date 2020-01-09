Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SearchData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        InsertData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UpdateData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DeleteData()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        GetHistory()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        getPrevious()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        getFollowing()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If (Me.TextBox5.Text <> "" And IsNumeric(Me.TextBox5.Text) And Not Me.TextBox5.Text.Contains(".")) Then
            Me.Button1.Enabled = True
            Me.Button5.Enabled = True
            Me.Button6.Enabled = True
        Else
            Me.Button1.Enabled = False
            Me.Button5.Enabled = False
            Me.Button6.Enabled = False
        End If
    End Sub
End Class
