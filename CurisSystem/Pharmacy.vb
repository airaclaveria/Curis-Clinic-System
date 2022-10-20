Imports System.Data.OleDb

Public Class Pharmacy

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap

    Private Sub viewer()
        datagridviewPharmacy.DataSource = Nothing
        datagridviewPharmacy.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from Pharmacy ", conn)
        da.Fill(dt)
        datagridviewPharmacy.DataSource = dt
        conn.Close()

    End Sub

    Private Sub Pharmacy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\CurisDatabase.accdb"
        txtSearch.Text = "Search"

        viewer()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into Pharmacy(MedicineID, MedicineName, Price,Stock) values('" + txtMedicineID.Text +
                "', '" + txtMedicineName.Text+ "' , '" + txtPrice.Text + "' , '" + txtStock.Text + "')"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Saved!")

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
            cmd.CommandText = "delete * from Pharmacy where MedicineID = '" + txtMedicineID.Text + "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Sucessfully Deleted!")
            btnSearch_Click(New Object, New EventArgs())
            viewer()

            txtMedicineID.Text = ""
            txtPrice.Text = ""
            txtStock.Text = ""
     
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
            cmd.CommandText = "select * from Pharmacy where MedicineID = '" + txtSearch.Text + "' or MedicineName = '" + txtMedicineName.Text + "' or Price = '" + txtSearch.Text + "' or Stock = '" + txtStock.Text + "' "
            cmd.ExecuteNonQuery()
            dt = New DataTable()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            checker = Convert.ToInt32(dt.Rows.Count.ToString)
            datagridviewPharmacy.DataSource = dt
            conn.Close()

            If (checker = 0) Then
                txtSearch.Text = "Search"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update Pharmacy set MedicineName = '" + txtMedicineName.Text + "' , Price = '" + txtPrice.Text + "' , Stock = '" + txtStock.Text + "' where MedicineID = '" + txtMedicineID.Text + "'"
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

    Private Sub datagridviewPharmacy_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridviewPharmacy.CellClick
        Try
            txtMedicineID.Text = datagridviewPharmacy.SelectedRows(0).Cells(0).Value.ToString()
            txtMedicineName.Text = datagridviewPharmacy.SelectedRows(0).Cells(1).Value.ToString()
            txtPrice.Text = datagridviewPharmacy.SelectedRows(0).Cells(2).Value.ToString()
            txtStock.Text = datagridviewPharmacy.SelectedRows(0).Cells(3).Value.ToString()
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