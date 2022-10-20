Imports System.Data.OleDb

Public Class Doctors

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap

    Private Sub viewer()
        datagridviewDoctors.DataSource = Nothing
        datagridviewDoctors.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from Doctors ", conn)
        da.Fill(dt)
        datagridviewDoctors.DataSource = dt
        conn.Close()

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into Doctors(ID,DoctorsName,Age,ContactNumber,Email) values('" + txtDoctorID.Text +
                "','" + txtDoctorsName.Text + "' , '" + txtDoctorsAge.Text + "' , '" + txtContactNumber.Text + "', '" + txtEmail.Text + "')"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Saved!")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub Doctors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\CurisDatabase.accdb"
        txtSearch.Text = "Search"

        viewer()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Doctors set DoctorsName = '" + txtDoctorsName.Text + "' , Age = '" + txtDoctorsAge.Text + "', ContactNumber = '" + txtContactNumber.Text + "' , Email = '" + txtEmail.Text + "'  where ID = '" + txtDoctorID.Text + "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Update Successfully!")
            btnSearch_Click(New Object, New EventArgs())
            viewer()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        viewer()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim checker As Integer

        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from Doctors where ID = '" + txtSearch.Text + "' or DoctorsName = '" + txtSearch.Text + "' or ContactNumber = '" + txtContactNumber.Text + "' "
            cmd.ExecuteNonQuery()
            dt = New DataTable()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            checker = Convert.ToInt32(dt.Rows.Count.ToString)
            datagridviewDoctors.DataSource = dt
            conn.Close()

            If (checker = 0) Then
                txtSearch.Text = "Search"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete * from Doctors where ID = '" + txtDoctorID.Text + "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Sucessfully Deleted!")
            btnSearch_Click(New Object, New EventArgs())
            viewer()

            txtDoctorID.Text = ""
            txtDoctorsName.Text = ""
            txtDoctorsAge.Text = ""
            txtContactNumber.Text = ""
            txtEmail.Text = ""
            txtSearch.Text = "Search"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub datagridviewDoctors_Click(sender As Object, e As EventArgs) Handles datagridviewDoctors.Click

    End Sub

    Private Sub datagridviewDoctors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridviewDoctors.CellClick
        Try
            txtDoctorID.Text = datagridviewDoctors.SelectedRows(0).Cells(0).Value.ToString()
            txtDoctorsName.Text = datagridviewDoctors.SelectedRows(0).Cells(1).Value.ToString()
            txtDoctorsAge.Text = datagridviewDoctors.SelectedRows(0).Cells(2).Value.ToString()
            txtContactNumber.Text = datagridviewDoctors.SelectedRows(0).Cells(3).Value.ToString()
            txtEmail.Text = datagridviewDoctors.SelectedRows(0).Cells(4).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Data Updated!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Home As New HomePage
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        txtSearch.Text = ""
    End Sub
End Class