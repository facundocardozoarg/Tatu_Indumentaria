Public Class MenuEnvios

    
    Private Sub btnEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpresa.Click
        ABMEmpresaEnvios.Show()
        Me.Close()
    End Sub

    Private Sub btnGestionEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGestionEnvio.Click
        ABMGestionEnvio.Show()
        Me.Close()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        PantallaPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub MenuEnvios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
    End Sub
End Class