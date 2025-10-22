Imports MySql.Data.MySqlClient

Public Class Login

    Friend usuario As String
    Friend rol As String

    Private Sub btnIniciarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciarSesion.Click
        Call Conectar()

        If txtUsuario.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Debe ingresar usuario y contraseña", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If


        'Hacemos usuario root
        If txtUsuario.Text = "root" And txtPassword.Text = "1234" Then

            MsgBox("Sesion iniciada correctamente", MsgBoxStyle.Information, "Inicio de sesion")

            usuario = txtUsuario.Text

            'Doy acceso al formulario principal
            Me.DialogResult = Windows.Forms.DialogResult.OK

        Else
            Try
                'abro la conexion
                Conexion.Open()

                'declaro objeto comando
                Dim comando As New MySqlCommand

                'Indico conexion activa.
                comando.Connection = Conexion

                'Indico tipo de instruccion
                comando.CommandType = CommandType.Text

                'Cargo instruccion sql
                comando.CommandText = "select * from usuario where nombre_usuario = @nombre_usuario and clave=@clave ;"

                'Asigno valores a los parametros
                comando.Parameters.AddWithValue("@nombre_usuario", txtUsuario.Text)
                comando.Parameters.AddWithValue("@clave", txtPassword.Text)

                'declaro dreader
                Dim drUsuario As MySqlDataReader

                'Traigo datos de la BD
                drUsuario = comando.ExecuteReader

                'Si hay registros es porque la marca ya existe.
                If drUsuario.HasRows Then

                    drUsuario.Read()

                    usuario = drUsuario("nombre_usuario").ToString
                    rol = drUsuario("rol").ToString

                    MsgBox("Sesion iniciada correctamente", MsgBoxStyle.Information, "Inicio de sesion")

                    'Doy acceso al formulario principal
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox("El usuario o la contraseña es inconrrecto", MsgBoxStyle.Exclamation, "Error de ingreso")


                End If
                drUsuario.Close()
                Conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conexion.Close()
            End Try

        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
    End Sub
End Class
