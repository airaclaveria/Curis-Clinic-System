Public Class HomePage

    Private Sub btnRegistration_Click(sender As Object, e As EventArgs) Handles btnRegistration.Click
        Dim RegForm As New Registration
        Me.Hide()
        RegForm.Show()
    End Sub

    Private Sub btnReferrals_Click(sender As Object, e As EventArgs) Handles btnReferrals.Click
        Dim Refer As New Referrals
        Me.Hide()
        Referrals.Show()
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        Dim Patient As New Patients
        Me.Hide()
        Patient.Show()
    End Sub

    Private Sub btnDoctors_Click(sender As Object, e As EventArgs) Handles btnDoctors.Click
        Dim Doctor As New Doctors
        Me.Hide()
        Doctor.Show()
    End Sub

    Private Sub btnPharmacy_Click(sender As Object, e As EventArgs) Handles btnPharmacy.Click
        Dim Pharma As New Pharmacy
        Me.Hide()
        Pharma.Show()
    End Sub

    Private Sub btnLaboratory_Click(sender As Object, e As EventArgs) Handles btnLaboratory.Click
        Dim Lab As New Laboratory
        Me.Hide()
        Lab.Show()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Login As New Form1
        Me.Hide()
        Login.Show()
    End Sub
End Class