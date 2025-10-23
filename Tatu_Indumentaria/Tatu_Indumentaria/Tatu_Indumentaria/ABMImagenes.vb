Option Strict Off

Imports MySql.Data.MySqlClient
Imports System.IO


Public Class ABMImagenes

    Public id_producto As Integer
    Public id_color As Integer

    Public IdImgSelec As Integer  'para el lujo

    '*******************************************
    Public Function ConvertImageFiletoBytes(ByVal ImageFilePath As String) As Byte()
        'funcion convierte la imagen a binario para guardar en la BD
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("La imagen no puede estar vacia", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '*************************************
    Public Function ConvertBytesToMemoryStream(ByVal ImageData As Byte()) As IO.MemoryStream
        Try
            If IsNothing(ImageData) = True Then
                Return Nothing
                'Throw New ArgumentNullException("La imagen no puede estar vacia", "ImageData")
            End If
            Return New System.IO.MemoryStream(ImageData)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '***********************************
    Public Function ConvertImageFiletoMemoryStream(ByVal ImageFilePath As String) As IO.MemoryStream
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Return Nothing
            ' Throw New ArgumentNullException("ILa imagen no puede estar vacia", "ImageFilePath")
        End If
        Return ConvertBytesToMemoryStream(ConvertImageFiletoBytes(ImageFilePath))
    End Function

    Sub BuscarImagenBD(ByVal id_color As Integer, ByVal idProd As Integer)

        If lstCodigos.SelectedIndex < 0 Or cmbColor.SelectedIndex < 0 Then
            Exit Sub
        End If


        Try
            'conecto a BD
            Conexion.Open()

            'declaro el objeto command para enviar sentencias a la BD
            Dim Comando As New MySqlCommand

            'indico objeto de conexion
            Comando.Connection = Conexion

            'indico tipos de instruccion de la BD
            Comando.CommandType = CommandType.Text

            'cargo instrucccion para la BD
            Comando.CommandText = "select * from imagen where id_color = " & id_color & " and id_producto = " & idProd & ";"

            'obtengo los datos y los devuelvo a un objeto DataReader
            Dim DReader As MySqlDataReader

            'el mÃ©todo ExecuteReader trae los datos de la BD
            DReader = Comando.ExecuteReader
            pbxImagen.Image = Nothing

            'consulto si trajo registros
            If DReader.HasRows Then
                DReader.Read()
                'traigo la imagen binaria y la convierto
                '*************************************
                Dim lb() As Byte = DReader("imagen_url")
                Dim lstr As New System.IO.MemoryStream(lb)
                'cargo la imagen en el picture
                pbxImagen.Image = Image.FromStream(lstr)
                pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage
                lstr.Close()
            End If

            DReader.Close()
            Conexion.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Conexion.Close()
        End Try
    End Sub

    Sub CargarColor()
        Try
            'Limpiamos el combo
            cmbColor.Items.Clear()

            'Abro conexion
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo instruccion sql
            comando.CommandText = "select nombre_color from color order by nombre_color"

            'Declaro datareader
            Dim drColor As MySqlDataReader

            'traemos los datos de la tabla color
            drColor = comando.ExecuteReader

            'Si existen filas en la tabla de color
            If drColor.HasRows Then

                'Recorro el datareader y voy cargando los items del combo con el campo nombre color
                Do While drColor.Read
                    cmbColor.Items.Add(drColor("nombre_color"))
                Loop

            End If
            'Cierro Data Reader
            drColor.Close()
            'Cierro la conexion.
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Sub CargarList(ByVal dato As String)

        Try
            Conexion.Open()
            'Declaramos comando
            Dim Comando As New MySqlCommand

            'indico cual es la conexion activa
            Comando.Connection = Conexion

            'indico el tipo instruccion
            Comando.CommandType = CommandType.Text


            If dato = "" Then
                'Sql muestro nombre de categoria y los ordeno.
                Comando.CommandText = "select codigo_producto from producto order by codigo_producto"

                lstCodigos.Items.Clear()

                'Declaro Objeto DataReader
                Dim drCodigos As MySqlDataReader

                'Traigo datos desde BD
                drCodigos = Comando.ExecuteReader

                'Verifico que haya registros
                If drCodigos.HasRows Then
                    'si encuentra registros limpio el list.


                    'Recorro el data reader
                    Do While drCodigos.Read
                        'Agrego los nombres de categoria a los item del list
                        lstCodigos.Items.Add(drCodigos("codigo_producto"))
                    Loop

                    drCodigos.Close()
                End If
            ElseIf (dato <> "") Then
                'cargo la instruccion SQL

                Comando.CommandText = "select codigo_producto from producto where codigo_producto like'" & dato.ToString & "%' order by codigo_producto;"

                lstCodigos.Items.Clear()

                'declaro objeto DataReader
                Dim drCodigos As MySqlDataReader

                'traido los datos desde la BD
                drCodigos = Comando.ExecuteReader

                'vacio el lis
                lstCodigos.Items.Clear()

                'verifico que trajo datos
                If drCodigos.HasRows Then
                    'recorro el Dreader
                    Do While drCodigos.Read
                        lstCodigos.Items.Add(drCodigos("codigo_producto"))
                    Loop
                End If
                drCodigos.Close()
            End If

            'cierro la conexion a la BD
            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub ABMImagenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        Call CargarList("")
        Call CargarColor()
    End Sub

    Private Sub txtCodigos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigos.TextChanged
        Call CargarList(txtCodigos.Text.ToString)
    End Sub


    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        'abro la ventana de busqueda 
        If OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            'cargo en el text el Path de la Imagen
            txtUrl.Text = OpenFileDialog1.FileName
            'cargo la imagen en el picturebox 
            pbxImagen.ImageLocation = txtUrl.Text
            pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If id_color < 1 Or id_producto < 1 Then
            MsgBox("Debe seleccionar codigo de producto y color antes de cargar la imagen", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'guarda la imagen seleccionada en la BD
        If (lstCodigos.SelectedIndex <> -1) And (txtUrl.Text <> "") Then

            'informo el path del archivo de imagen a la funcion
            '***********
            Dim filename As String = txtUrl.Text
            Dim FileSize As UInt32

            Try

                'conecto a BD
                Conexion.Open()

                'declaro el objeto command para enviar sentencias a la BD
                Dim Comando As New MySqlCommand

                'indico objeto de conexion
                Comando.Connection = Conexion

                'indico tipos de instruccion de la BD
                Comando.CommandType = CommandType.Text


                Comando.CommandText = "select * from imagen where id_color = " & id_color & " and id_producto = " & id_producto & ";"


                Dim drImagen As MySqlDataReader

                drImagen = Comando.ExecuteReader

                If drImagen.HasRows Then
                    MsgBox("El producto ya tiene una imagen cargada", MsgBoxStyle.Exclamation)
                    drImagen.Close()
                    Comando.Parameters.Clear()
                    Conexion.Close()
                    Exit Sub
                End If
                drImagen.Close()
                Comando.Parameters.Clear()

                'convierto imagen a binario
                '**************************
                Dim mstream As System.IO.MemoryStream = ConvertImageFiletoMemoryStream(filename)
                Dim arrImage() As Byte = ConvertImageFiletoBytes(filename)
                FileSize = mstream.Length
                mstream.Close()

                'cargo instrucccion para la BD
                '*****************************
                Comando.CommandText = "insert into imagen (imagen_url,id_producto,id_color) VALUES(@BFoto,@id_producto,@id_color);"

                Comando.Parameters.AddWithValue("@id_producto", id_producto)
                Comando.Parameters.AddWithValue("@id_color", id_color)
                Comando.Parameters.AddWithValue("@BFoto", arrImage)
                Comando.ExecuteNonQuery()

                'limpio imagen
                txtUrl.Text = ""
                pbxImagen.Image = Nothing

                'pbPicture.
                MsgBox("IMAGEN GUARDADA EN BD")
                lstCodigos.SelectedIndex = -1
                cmbColor.SelectedIndex = -1

                Conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                Conexion.Close()
            End Try

        Else
            MsgBox("DEBE BUSCAR LA IMAGEN", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub lstCodigos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCodigos.SelectedIndexChanged
        'Evito un error al hacer click donde no tenga items el list.
        If lstCodigos.SelectedItem Is Nothing Then
            id_producto = -1
            Exit Sub
        End If

        Try

            Conexion.Open()

            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo el sql buscando igualdades con items del list
            comando.CommandText = "select id_producto from producto where codigo_producto = '" & lstCodigos.SelectedItem.ToString & "';"

            'Declaro obejto data reade
            Dim drProductos As MySqlDataReader

            'Traigo datos desde BD
            drProductos = comando.ExecuteReader

            If drProductos.HasRows Then

                drProductos.Read()


                id_producto = drProductos("id_producto")
                drProductos.Close()
            End If
            Conexion.Close()

            Call BuscarImagenBD(id_color, id_producto)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub cmbColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColor.SelectedIndexChanged
        If cmbColor.SelectedItem Is Nothing Then
            id_color = -1
            Exit Sub
        End If
        Try
            Conexion.Open()

            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo el sql buscando igualdades con items del list
            comando.CommandText = "select id_color from color where nombre_color = '" & cmbColor.SelectedItem.ToString & "' ;"

            'Declaro obejto data reade
            Dim drColor As MySqlDataReader

            'Traigo datos desde BD
            drColor = comando.ExecuteReader

            If drColor.HasRows Then

                drColor.Read()

                id_color = drColor("id_color")
                drColor.Close()
            End If
            Conexion.Close()
            Call BuscarImagenBD(id_color, id_producto)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()
    End Sub
End Class