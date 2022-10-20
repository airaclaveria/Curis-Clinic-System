Imports System.Data.OleDb



Public Class Laboratory


    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap

    Private Sub viewer()
        datagridviewLab.DataSource = Nothing
        datagridviewLab.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from Patients ", conn)
        da.Fill(dt)
        datagridviewLab.DataSource = dt
        conn.Close()
    End Sub

    Private Sub Laboratory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\CurisDatabase.accdb"
        txtSearch.Text = "Search"

        viewer()
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Patients set Hemoglobin = '" + txtHemoglobin.Text + "' , WBC = '" + txtWhiteBloodCellsCount.Text + "' , Platelet = '" + txtPlatelets.Text + "' where ID = '" + txtPatientID.Text + "'"
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim checker As Integer

        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from Patients where ID = '" + txtSearch.Text + "' or FullName = '" + txtSearch.Text + "' or Age = '" + txtAge.Text + "' "
            cmd.ExecuteNonQuery()
            dt = New DataTable()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            checker = Convert.ToInt32(dt.Rows.Count.ToString)
            datagridviewLab.DataSource = dt
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

    Private Sub datagridviewLab_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridviewLab.CellClick
        Try
            txtPatientID.Text = datagridviewLab.SelectedRows(0).Cells(0).Value.ToString()
            txtFullName.Text = datagridviewLab.SelectedRows(0).Cells(1).Value.ToString()
            txtAge.Text = datagridviewLab.SelectedRows(0).Cells(2).Value.ToString()
            txtAddress.Text = datagridviewLab.SelectedRows(0).Cells(3).Value.ToString()
            txtEmail.Text = datagridviewLab.SelectedRows(0).Cells(4).Value.ToString()
            txtContactNumber.Text = datagridviewLab.SelectedRows(0).Cells(5).Value.ToString()
            txtHemoglobin.Text = datagridviewLab.SelectedRows(0).Cells(6).Value.ToString()
            txtWhiteBloodCellsCount.Text = datagridviewLab.SelectedRows(0).Cells(7).Value.ToString()
            txtPlatelets.Text = datagridviewLab.SelectedRows(0).Cells(8).Value.ToString()
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
End Class