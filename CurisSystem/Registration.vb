Imports System.Data.OleDb

Public Class Registration

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap

    Private Sub viewer()
        datagridviewRegForm.DataSource = Nothing
        datagridviewRegForm.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from Patients ", conn)
        da.Fill(dt)
        datagridviewRegForm.DataSource = dt
        conn.Close()

    End Sub


    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try

            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into Patients(ID,FullName,Age,Address,Email,ContactNo) values('" + txtPatientID.Text +
                "','" + txtFullName.Text + "' , '" + txtAge.Text + "' , '" + txtAddress.Text + "', '" + txtEmail.Text + "' , '" + txtContactNumber.Text + "')"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Record Saved!")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VB Save Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\CurisDatabase.accdb"

        viewer()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        viewer()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Home As New HomePage
        Me.Hide()
        Home.Show()

    End Sub
End Class