Public Class LoginForm
    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        UidTb.Clear()
        PassTb.Clear()
        PictureBox3.Visible = False
        PictureBox4.Visible = True
        PassTb.UseSystemPasswordChar = False
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Application.Exit()
    End Sub

    Private Sub Log_Click(sender As Object, e As EventArgs) Handles Log.Click
        If UidTb.Text = "" Or PassTb.Text = "" Then
            MsgBox("Please Enter Your Username Or Password!!")
        ElseIf UidTb.Text = "admin" And PassTb.Text = "admin" Then
            MainForm.Show()
            Me.Close()
        Else
            MsgBox("Invalid Username Or Password")
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PictureBox4.Visible = True
        PictureBox3.Visible = False
        PassTb.UseSystemPasswordChar = False
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        PassTb.UseSystemPasswordChar = True
        PictureBox3.Visible = True
        PictureBox4.Visible = False
    End Sub
End Class