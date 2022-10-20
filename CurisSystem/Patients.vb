Imports System.Data.OleDb


Public Class Patients

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap

    Private Sub viewer()
        datagridviewPatients.DataSource = Nothing
        datagridviewPatients.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from Patients ", conn)
        da.Fill(dt)
        datagridviewPatients.DataSource = dt
        conn.Close()

    End Sub

    Private Sub Patients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\CurisDatabase.accdb"
        txtSearch.Text = "Search"

        viewer()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete * from Patients where ID = '" + txtPatientID.Text + "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Sucessfully Deleted!")
            btnSearch_Click(New Object, New EventArgs())
            viewer()

            txtPatientID.Text = ""
            txtFullName.Text = ""
            txtAge.Text = ""
            txtAddress.Text = ""
            txtContactNumber.Text = ""
            txtSearch.Text = "Search"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim checker As Integer

        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from Patients where ID = '" + txtSearch.Text + "' or FullName = '" + txtSearch.Text + "' or ContactNo = '" + txtContactNumber.Text + "' "
            cmd.ExecuteNonQuery()
            dt = New DataTable()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            checker = Convert.ToInt32(dt.Rows.Count.ToString)
            datagridviewPatients.DataSource = dt
            conn.Close()

            If (checker = 0) Then
                txtSearch.Text = "Search"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        viewer()
    End Sub

    Private Sub datagridviewPatients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridviewPatients.CellClick
        Try
            txtPatientID.Text = datagridviewPatients.SelectedRows(0).Cells(0).Value.ToString()
            txtFullName.Text = datagridviewPatients.SelectedRows(0).Cells(1).Value.ToString()
            txtAge.Text = datagridviewPatients.SelectedRows(0).Cells(2).Value.ToString()
            txtAddress.Text = datagridviewPatients.SelectedRows(0).Cells(3).Value.ToString()
            txtEmail.Text = datagridviewPatients.SelectedRows(0).Cells(4).Value.ToString()
            txtContactNumber.Text = datagridviewPatients.SelectedRows(0).Cells(5).Value.ToString()
            txtHemoglobin.Text = datagridviewPatients.SelectedRows(0).Cells(6).Value.ToString()
            txtWBC.Text = datagridviewPatients.SelectedRows(0).Cells(7).Value.ToString()
            txtPlatelet.Text = datagridviewPatients.SelectedRows(0).Cells(8).Value.ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Data Updated!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        txtSearch.Text = " "
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Home As New HomePage
        Me.Hide()
        Home.Show()
    End Sub
End Class