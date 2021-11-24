Imports System.Data.SqlClient
Public Class Employee
    Dim Con As New SqlConnection("Data Source=SANZEEV\SQLEXPRESS;Initial Catalog=vbnet;Integrated Security=True")
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Panel1.AutoSizeChanged
        Populate()
    End Sub
    Private Sub Populate()
        Con.Open()
        Dim sql = "select * from EmployeeTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, Con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        EmployeeDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Con.Open()
            Dim Query As String
            Query = "insert into EmployeeTbl values('" & EmpID.Text & "','" & EmpName.Text & "','" & EmpAdd.Text & "','" & PosCb.Text & "','" & EmpDOB.Value & "','" & EmpPhoneTb.Text & "','" & EmpEdTb.Text & "','" & GendCb.SelectedItem.ToString() & "','" & MarryCb.SelectedItem.ToString() & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Employee Data Added")
            Con.Close()
            Populate()
        Catch ex As Exception
            MsgBox("Employee ID is repeated!!!")
            Con.Close()
        End Try

    End Sub
    Dim key = 0
    Private Sub Clear()
        EmpID.Clear()
        EmpName.Clear()
        EmpAdd.Clear()
        EmpPhoneTb.Clear()
        PosCb.Clear()
        EmpEdTb.Clear()
        GendCb.Text = ""
        MarryCb.Text = ""
        key = 0
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Please Enter A Valid Detail")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "delete from EmployeeTbl where EmpId = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Employee Detail Deleted Succesfully")
                Con.Close()
                Populate()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub EmployeeDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles EmployeeDGV.CellMouseClick
        Dim row As DataGridViewRow = EmployeeDGV.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        EmpID.Text = row.Cells(0).Value.ToString()
        EmpName.Text = row.Cells(1).Value.ToString()
        EmpAdd.Text = row.Cells(2).Value.ToString()
        PosCb.Text = row.Cells(3).Value.ToString()
        EmpDOB.Value = row.Cells(4).Value.ToString()
        EmpPhoneTb.Text = row.Cells(5).Value.ToString()
        EmpEdTb.Text = row.Cells(6).Value.ToString()
        GendCb.Text = row.Cells(7).Value.ToString()
        MarryCb.Text = row.Cells(8).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If EmpID.Text = "" Or EmpName.Text = "" Or EmpAdd.Text = "" Or EmpPhoneTb.Text = "" Or PosCb.Text = "" Or EmpEdTb.Text = "" Then
            MsgBox("Some Details Are Missing!!!")
        Else
            Con.Open()
            Dim Query As String
            Query = "update EmployeeTbl set EmpName = '" & EmpName.Text & "', EmpAdd = '" & EmpAdd.Text & "', EmpPos = '" & PosCb.Text & "', EmpDob = '" & EmpDOB.Value & "', EmpPhone = '" & EmpPhoneTb.Text & "', EmpEdu = '" & EmpEdTb.Text & "', EmpGend = '" & GendCb.SelectedItem.ToString() & "', EmpMarriage = '" & MarryCb.SelectedItem.ToString() & "' where EmpId = " & key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Employee Detail Edited")
            Con.Close()
            Populate()
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Clear()
    End Sub
End Class