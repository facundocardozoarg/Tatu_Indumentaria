Public Class frmGrillaEmpleados

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Hide()
        ABMEmpleados.Show()
    End Sub

    Private Sub frmGrillaEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
    End Sub
End Class