Imports System.Data.SqlClient
Public Class EmployeeDetails
    Dim Con As New SqlConnection("Data Source=SANZEEV\SQLEXPRESS;Initial Catalog=vbnet;Integrated Security=True")
    Private Sub GetEmployeeData()
        If EmpIdTb.Text = "" Then
            MsgBox("Please Enter Employee ID")
        Else
            Con.Open()
            Dim Query As String
            Query = "select * from EmployeeTbl where EmpId=" & EmpIdTb.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sda As SqlDataAdapter
            sda = New SqlDataAdapter(cmd)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                EmpNamelbl.Text = dr(1).ToString()
                EmpAddlbl.Text = dr(2).ToString()
                EmpPostlbl.Text = dr(3).ToString()
                EmpDoblbl.Text = dr(4)
                EmpPhonelbl.Text = dr(5).ToString()
                EmpEdulbl.Text = dr(6).ToString()
                EmpGenderlbl.Text = dr(7).ToString()
                EmpMarriagelbl.Text = dr(8).ToString()
                EmpNamelbl.Visible = True
                EmpAddlbl.Visible = True
                EmpPostlbl.Visible = True
                EmpDoblbl.Visible = True
                EmpPhonelbl.Visible = True
                EmpEdulbl.Visible = True
                EmpGenderlbl.Visible = True
                EmpMarriagelbl.Visible = True
            Next
            Con.Close()
        End If
    End Sub
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetEmployeeData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EmpNamelbl.Text = ""
        EmpAddlbl.Text = ""
        EmpPostlbl.Text = ""
        EmpDoblbl.Text = ""
        EmpPhonelbl.Text = ""
        EmpEdulbl.Text = ""
        EmpGenderlbl.Text = ""
        EmpMarriagelbl.Text = ""
    End Sub

    Private Sub EmpIdTb_TextChanged(sender As Object, e As EventArgs) Handles EmpIdTb.TextChanged

    End Sub
End Class