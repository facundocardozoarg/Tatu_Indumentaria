Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Stock

    Public id_producto As Integer
    Public id_categoria As Integer
    Public id_marca As Integer
    Public id_modelo As Integer
    Public nombre_talle As String
    Public nombre_color As String
    Private bmp As Bitmap

    Sub LimpiarForms()
        lstProductos.SelectedIndex = -1
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtGenero.Text = ""
        txtTemporada.Text = ""
        txtCategoria.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtPrecioUnitario.Text = ""
        txtCantidad.Text = ""
        cmbColor.SelectedIndex = -1
        cmbTalle.SelectedIndex = -1

    End Sub

    Sub BuscarImagenBD(ByVal id_color As Integer, ByVal idProd As Integer)

        If txtCodigo.Text = "" Or cmbColor.SelectedIndex < 0 Then
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
            ptbImagen.Image = Nothing

            'consulto si trajo registros
            If DReader.HasRows Then
                DReader.Read()
                'traigo la imagen binaria y la convierto
                '*************************************
                Dim lb() As Byte = DReader("imagen_url")
                Dim lstr As New System.IO.MemoryStream(lb)
                'cargo la imagen en el picture
                ptbImagen.Image = Image.FromStream(lstr)
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage
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


    Sub CargarTalle()
        Try
            'Abro conexion
            Conexion.Open()

            'Declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'indico el tipo de intruccion
            comando.CommandType = CommandType.Text

            'Cargo instruccion sql para traer talles
            comando.CommandText = "select * from talle order by nombre_talle"

            'Declaramos datareader
            Dim drTalle As MySqlDataReader

            'traemos los datos de la tabla talles
            drTalle = comando.ExecuteReader

            If drTalle.HasRows Then
                Do While drTalle.Read
                    cmbTalle.Items.Add(drTalle("nombre_talle"))
                Loop
            End If
            'Cierro Data Reader
            drTalle.Close()
            'Cierro la conexion.
            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub




    Sub CargarList(ByVal dato As String)
        'si el parametro esta vacio no hago nada
        If dato = "" Then
            'si no trae limpio el list
            lstProductos.Items.Clear()
            Exit Sub
        End If

        'cargo el list con los nombres de socios
        Try
            'conecto a la BD
            Conexion.Open()

            'declaro objeto comand
            Dim Comando As New MySqlCommand

            'indico cual es la conexion activa
            Comando.Connection = Conexion

            'indico el tipo instruccion
            Comando.CommandType = CommandType.Text

            'cargo la instruccion SQL
            Comando.CommandText = "select descripcion from producto where descripcion like'" & dato.ToString & "%' order by descripcion;"

            'declaro objeto DataReader
            Dim drProducto As MySqlDataReader

            'traido los datos desde la BD
            drProducto = Comando.ExecuteReader

            'vacio el lis
            lstProductos.Items.Clear()

            'verifico que trajo datos
            If drProducto.HasRows Then
                'recorro el Dreader
                Do While drProducto.Read
                    lstProductos.Items.Add(drProducto("descripcion"))
                Loop
            End If

            'cierro el Dreader
            drProducto.Close()

            'cierro la conexion a la BD
            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()

        Call CargarColor()
        Call CargarTalle()
    End Sub

    Private Sub txtBuscador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscador.TextChanged
        Call CargarList(txtBuscador.Text.ToString)
    End Sub

    Private Sub lstProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProductos.SelectedIndexChanged
        'Evito un error al hacer click donde no tenga items el list.
        If lstProductos.SelectedItem Is Nothing Then
            Exit Sub
        End If

        ptbImagen.Image = Nothing
        Try

            'Si no tengo errores...
            'Abro la conexion
            Conexion.Open()

            'Declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo el sql buscando igualdades con items del list
            comando.CommandText = "select * from producto where descripcion = '" & lstProductos.SelectedItem.ToString & "';"

            'Declaro obejto data reade
            Dim drProductos As MySqlDataReader

            'Traigo datos desde BD
            drProductos = comando.ExecuteReader

            'Si encontre coincidencias
            If drProductos.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las categorias encontradas
                drProductos.Read()

                'Cargamos txt con los campos del registro seleccionado.
                id_producto = drProductos("id_producto")
                txtCodigo.Text = drProductos("codigo_producto")
                txtDescripcion.Text = drProductos("descripcion")
                txtGenero.Text = drProductos("genero")
                txtTemporada.Text = drProductos("temporada")
                id_categoria = drProductos("id_categoria")
                id_marca = drProductos("id_marca")
                id_modelo = drProductos("id_modelo")

                drProductos.Close()

                ' Nueva consulta para obtener la categoría
                comando.CommandText = "select nombre_categoria from categoria where id_categoria = @id_categoria;"

                comando.Parameters.AddWithValue("@id_categoria", id_categoria)

                Dim drCategoria As MySqlDataReader

                drCategoria = comando.ExecuteReader

                If drCategoria.HasRows Then
                    drCategoria.Read()
                    txtCategoria.Text = drCategoria("nombre_categoria").ToString
                End If

                drCategoria.Close()

                'consulta para obtener marca
                comando.CommandText = "select nombre_marca from marca where id_marca = '" & id_marca & "';"

                'Hacemos lo mismo para marca
                Dim drMarca As MySqlDataReader
                drMarca = comando.ExecuteReader

                If drMarca.HasRows Then
                    drMarca.Read()
                    txtMarca.Text = drMarca("nombre_marca").ToString
                End If

                drMarca.Close()


                'Repetimos para obtener modelo

                comando.CommandText = "select nombre_modelo from modelo where id_modelo= '" & id_modelo & "';"

                'Hacemos lo mismo para marca
                Dim drModelo As MySqlDataReader
                drModelo = comando.ExecuteReader

                If drModelo.HasRows Then
                    drModelo.Read()
                    txtModelo.Text = drModelo("nombre_modelo").ToString
                End If

                drModelo.Close()

            Else
                Call LimpiarForms()
            End If
            'Cierro conexion
            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()
    End Sub

   

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtCodigo.Text = "" Then
            MsgBox("Debe seleccionar un producto para agregar su stock")
            Exit Sub
        End If
        If cmbColor.SelectedIndex = -1 Or cmbTalle.SelectedIndex = -1 Or txtPrecioUnitario.Text = "" Or txtCantidad.Text = "" Then
            MsgBox("No se pueden agregar datos vacio, rellene todos los campos", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            'Abrimos la conexion
            Conexion.Open()

            'Declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo el sql buscando igualdades con items del list
            comando.CommandText = "select id_variante_producto from variante_producto where id_producto = '" & id_producto & "' and id_talle = (select id_talle from talle where nombre_talle = '" & nombre_talle & "') and id_color = (select id_color from color where nombre_color ='" & nombre_color & "' )  ;"

            Dim drVarianteProducto As MySqlDataReader
            drVarianteProducto = comando.ExecuteReader

            If drVarianteProducto.HasRows Then
                drVarianteProducto.Close()
                MsgBox("Esta variante ya fue creada")
                Call LimpiarForms()
                Conexion.Close()
                Exit Sub
            End If
            drVarianteProducto.Close()

            'Limpiamos parametros
            comando.Parameters.Clear()

            comando.CommandText = "insert into variante_producto (id_producto,id_talle,id_color,stock_unitario,precio_unitario) values (@id_producto,(select id_talle from talle where nombre_talle = @nombre_talle ),(select id_color from color where nombre_color = @nombre_color ),@stock_unitario,@precio_unitario);"

            comando.Parameters.AddWithValue("@id_producto", id_producto)
            comando.Parameters.AddWithValue("@nombre_talle", nombre_talle)
            comando.Parameters.AddWithValue("@nombre_color", nombre_color)
            comando.Parameters.AddWithValue("@stock_unitario", Convert.ToInt16(txtCantidad.Text))
            comando.Parameters.AddWithValue("@precio_unitario", Convert.ToDecimal(txtPrecioUnitario.Text))

            Dim respuesta As Integer

            respuesta = comando.ExecuteNonQuery

            MsgBox("Variante agregada!: " + respuesta.ToString)

            Call LimpiarForms()

            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub cmbColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColor.SelectedIndexChanged
        If cmbColor.SelectedItem Is Nothing Then
            Exit Sub
        End If

        nombre_color = cmbColor.SelectedItem.ToString

        Dim id_color As Integer

        Try
            Conexion.Open()

            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo el sql buscando igualdades con items del list
            comando.CommandText = "select id_color from color where nombre_color = '" & cmbColor.SelectedItem.ToString & "';"


            Dim drColor As MySqlDataReader

            drColor = comando.ExecuteReader()

            If drColor.HasRows() Then
                drColor.Read()
              
                id_color = drColor("id_color")
                drColor.Close()
            End If

            drColor.Close()
            Conexion.Close()
            Call BuscarImagenBD(id_color, id_producto)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try





    End Sub

    Private Sub cmbTalle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTalle.SelectedIndexChanged
        If cmbTalle.SelectedItem Is Nothing Then
            Exit Sub
        End If

        nombre_talle = cmbTalle.SelectedItem.ToString
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ' Capturar la imagen del GroupBox (lo que se ve en pantalla)
        bmp = New Bitmap(gpbFicha.Width, gpbFicha.Height)
        gpbFicha.DrawToBitmap(bmp, New Rectangle(0, 0, gpbFicha.Width, gpbFicha.Height))

        ' Mostrar cuadro de diálogo de impresora
        If SelectImpre.ShowDialog() = DialogResult.OK Then
            PrintDoc.PrinterSettings = SelectImpre.PrinterSettings

            ' Configurar vista previa
            VistaPrevia.Document = PrintDoc
            VistaPrevia.WindowState = FormWindowState.Maximized

            ' Mostrar vista previa
            VistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        e.Graphics.DrawImage(bmp, 0, 0)

    End Sub
End Class