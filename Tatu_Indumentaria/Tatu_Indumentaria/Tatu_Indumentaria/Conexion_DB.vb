Imports MySql.Data.MySqlClient

Module Conexion_DB
    'Variable de alcance global, obejto de conexion
    Friend Conexion As MySqlConnection


    Sub Conectar()
        'Usar try para manejo de errores y excepciones.
        Try
            'Intancia de objeto conexion.
            Conexion = New MySqlConnection

            Dim Cadena As String

            'Genero string de conexion en TXT
            Cadena = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\conexion.txt")

            'Genero string de conexion
            'Cadena = "server=localhost; user id=root; password=1234;database=tatu_indumentaria_PRUEBA;port=3306;"

            'configuro propiedad de conexion
            Conexion.ConnectionString = Cadena

            'Probar conexion
            ' Conexion.Open()

            'MsgBox("Conexion Exitosa")

            'cierro conexion
            ' Conexion.Close()

        Catch ex As Exception

            MsgBox(ex.Message)
            MsgBox("Error en la conexion con la Base de datos")

        End Try

    End Sub


End Module
