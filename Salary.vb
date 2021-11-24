Imports System.Data.SqlClient
Public Class Salary
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
                EmpPostlbl.Text = dr(3).ToString()
                EmpNamelbl.Visible = True
                EmpPostlbl.Visible = True
            Next
            Con.Close()
        End If
    End Sub
    Private Sub Salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetEmployeeData()
    End Sub
    Dim monthly, sixmonth, yearly

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If EmpPostlbl.Text = "" Or SalarypdTb.Text = "" Then
            MsgBox("Please Enter Valid Details")
        Else
            monthly = SalarypdTb.Text * 30
            sixmonth = monthly * 6
            yearly = monthly * 12
            SalaryTb.Text = "Employee ID:       " + EmpIdTb.Text + vbCrLf + "Employee Name:     " + EmpNamelbl.Text + vbCrLf + "Employee Post:      " + EmpPostlbl.Text + vbCrLf + "Salary for a month:     " + Convert.ToString(monthly) + vbCrLf + "Salary For 6 Months:    " + Convert.ToString(sixmonth) + vbCrLf + "Salary Of A Year:  " + Convert.ToString(yearly)

        End If
    End Sub
End Class