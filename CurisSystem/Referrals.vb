Imports System.Data.OleDb

Public Class Referrals

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap

    Private Sub viewer()
        datagridviewReferral.DataSource = Nothing
        datagridviewReferral.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from Referrals ", conn)
        da.Fill(dt)
        datagridviewReferral.DataSource = dt
        conn.Close()

    End Sub

    Private Sub Referrals_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Application.StartupPath & "\CurisDatabase.accdb"
        txtSearch.Text = "Search"

        viewer()


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into Referrals(ReferralID,FullName,Age,Address,ContactNumber) values('" + txtReferralID.Text +
                "','" + txtFullName.Text + "' , '" + txtAge.Text + "' , '" + txtAddress.Text + "', '" + txtContactNumber.Text + "')"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Saved!")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        viewer()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Referrals set FullName = '" + txtFullName.Text + "' , Age = '" + txtAge.Text + "', Address = '" + txtAddress.Text + "' , ContactNumber = '" + txtContactNumber.Text + "'  where ReferralID = '" + txtReferralID.Text + "'"
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

    Private Sub datagridviewReferral_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridviewReferral.CellClick
        Try
            txtReferralID.Text = datagridviewReferral.SelectedRows(0).Cells(0).Value.ToString()
            txtFullName.Text = datagridviewReferral.SelectedRows(0).Cells(1).Value.ToString()
            txtAge.Text = datagridviewReferral.SelectedRows(0).Cells(2).Value.ToString()
            txtAddress.Text = datagridviewReferral.SelectedRows(0).Cells(3).Value.ToString()
            txtContactNumber.Text = datagridviewReferral.SelectedRows(0).Cells(4).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Data Updated!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim checker As Integer

        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from Referrals where ReferralID = '" + txtSearch.Text + "' or FullName = '" + txtSearch.Text + "' or ContactNumber = '" + txtContactNumber.Text + "' "
            cmd.ExecuteNonQuery()
            dt = New DataTable()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            checker = Convert.ToInt32(dt.Rows.Count.ToString)
            datagridviewReferral.DataSource = dt
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
            cmd.CommandText = "delete * from Referrals where ReferralID = '" + txtReferralID.Text + "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Sucessfully Deleted!")
            btnSearch_Click(New Object, New EventArgs())
            viewer()

            txtReferralID.Text = ""
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

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Home As New HomePage
        Me.Hide()
        Home.Show()
    End Sub
End Class