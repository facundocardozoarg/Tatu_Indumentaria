Public Class MenuVenta

   
    Private Sub btnMedioPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedioPago.Click
        Me.Close()
        ABMMediosPagos.Show()
    End Sub

    Private Sub btnGestionEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGestionEnvio.Click
        Me.Close()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        PantallaPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub MenuVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
    End Sub
End Class