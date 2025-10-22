Public Class Localidades
    Private Sub btnPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPais.Click
        ABMPaises.Show()
        Me.Close()
    End Sub

    Private Sub btnProvincia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProvincia.Click
        ABMProvincias.Show()
        Me.Close()
    End Sub

    Private Sub btnCiudad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiudad.Click
        ABMCiudades.Show()
        Me.Close()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        PantallaPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub Localidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
    End Sub
End Class