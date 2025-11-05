Imports MySql.Data.MySqlClient
Public Class Productos

    Public categoriaElegida As String
    Public marcaElegida As String
    Public modeloElegido As String

    Public id_Categoria As Integer
    Public id_marca As Integer
    Public id_modelo As Integer
    Public id_producto As Integer



    Sub LimpiarForms()
        txtCodigo.Text = ""
        txtDescipcion.Text = ""
        cmbGenero.SelectedIndex = -1
        cmbTemporada.SelectedIndex = -1
        cmbCategoria.SelectedIndex = -1
        cmbMarca.SelectedIndex = -1
        cmbModelo.SelectedIndex = -1
    End Sub



    Sub HabilitarCampos()
        txtCodigo.ReadOnly = False
        txtDescipcion.ReadOnly = False
        cmbGenero.Enabled = True
        cmbTemporada.Enabled = True
        cmbCategoria.Enabled = True
        cmbMarca.Enabled = True
        cmbModelo.Enabled = True

    End Sub


    Sub CargarList(ByVal dato As String)
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de categoria y los ordeno.
            comando.CommandText = "select codigo_producto from producto order by codigo_producto"

            lstProductos.Items.Clear()

            'Declaro Objeto DataReader
            Dim drCodigos As MySqlDataReader

            'Traigo datos desde BD
            drCodigos = comando.ExecuteReader

            'Verifico que haya registros
            If drCodigos.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drCodigos.Read
                    'Agrego los nombres de categoria a los item del list
                    lstProductos.Items.Add(drCodigos("codigo_producto"))
                Loop
            End If
            'Cierro Data reader
            drCodigos.Close()

            'Cierro Conexion
            Conexion.Close()

        Catch ex As Exception

        End Try

    End Sub



    Sub CargarCategorias()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de modelo y los ordeno.
            comando.CommandText = "select * from categoria order by nombre_categoria "

            'Declaro Objeto DataReader
            Dim drCategoria As MySqlDataReader

            'Traigo datos desde BD
            drCategoria = comando.ExecuteReader

            'Verifico que haya registros
            If drCategoria.HasRows Then


                'Recorro el data reader
                Do While drCategoria.Read
                    'Agrego los nombres de categoria a los item del list
                    cmbCategoria.Items.Add(drCategoria("nombre_categoria"))
                Loop
            End If
            'Cierro Data reader
            drCategoria.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Sub CargarMarcas()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de modelo y los ordeno.
            comando.CommandText = "select * from marca order by nombre_marca "

            'Declaro Objeto DataReader
            Dim drMarca As MySqlDataReader

            'Traigo datos desde BD
            drMarca = comando.ExecuteReader

            'Verifico que haya registros
            If drMarca.HasRows Then


                'Recorro el data reader
                Do While drMarca.Read
                    'Agrego los nombres de categoria a los item del list
                    cmbMarca.Items.Add(drMarca("nombre_marca"))
                Loop
            End If
            'Cierro Data reader
            drMarca.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Sub CargarModelos()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de modelo y los ordeno.
            comando.CommandText = "select * from modelo order by nombre_modelo "

            'Declaro Objeto DataReader
            Dim drModelo As MySqlDataReader

            'Traigo datos desde BD
            drModelo = comando.ExecuteReader

            'Verifico que haya registros
            If drModelo.HasRows Then


                'Recorro el data reader
                Do While drModelo.Read
                    'Agrego los nombres de categoria a los item del list
                    cmbModelo.Items.Add(drModelo("nombre_modelo"))
                Loop
            End If
            'Cierro Data reader
            drModelo.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Private Sub btnCategorias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCategorias.Click
        Me.Close()
        'Dim formCategorias As New ABMCategorias()
        ' formCategorias.ShowDialog()
        ABMCategorias.Show()
    End Sub


    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click
        Me.Close()
        ABMColor.Show()
    End Sub


    Private Sub btnModelos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModelos.Click
        Me.Close()
        ABMModelo.Show()
    End Sub

  

    Private Sub btnMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarca.Click
        Me.Close()
        ABMMarcas.Show()
    End Sub

    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarModelos()
        Call CargarCategorias()
        Call CargarMarcas()
        Call CargarList(txtBusqueda.Text.ToString)
        Call LimpiarForms()
        cmbGenero.Items.Add("Hombre")
        cmbGenero.Items.Add("Mujer")
        cmbTemporada.Items.Add("Primavera - Verano")
        cmbTemporada.Items.Add("Otoño - Invierno")
        Call Conectar()
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria.SelectedIndexChanged

        If lstProductos.SelectedIndex > -1 Then
            Exit Sub
        End If


        If cmbCategoria.SelectedIndex >= 0 Then


            categoriaElegida = cmbCategoria.SelectedItem.ToString

            Try
                'Abro conexion
                Conexion.Open()

                'declaro objeto comando
                Dim comando As New MySqlCommand

                'Indico conexion activa.
                comando.Connection = Conexion

                'Indico tipo de instruccion
                comando.CommandType = CommandType.Text

                'Cargo instruccion sql
                comando.CommandText = "select id_categoria from categoria where nombre_categoria = @nombre_categoria;"

                comando.Parameters.AddWithValue("@nombre_categoria", categoriaElegida)

                Dim drCategoria As MySqlDataReader

                'Traigo datos de la BD
                drCategoria = comando.ExecuteReader

                If drCategoria.Read() Then
                    id_Categoria = drCategoria("id_categoria")
                End If


                drCategoria.Close()
                Conexion.Close()


            Catch ex As Exception
                'Imprimo mensaje en caso de error
                MsgBox(ex.Message)
                Conexion.Close()
            End Try
        End If
    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMarca.SelectedIndexChanged
        If lstProductos.SelectedIndex > -1 Then
            Exit Sub
        End If



        If cmbMarca.SelectedIndex >= 0 Then


            marcaElegida = cmbMarca.SelectedItem.ToString

            Try
                'Abro conexion
                Conexion.Open()

                'declaro objeto comando
                Dim comando As New MySqlCommand

                'Indico conexion activa.
                comando.Connection = Conexion

                'Indico tipo de instruccion
                comando.CommandType = CommandType.Text

                'Cargo instruccion sql
                comando.CommandText = "select id_marca from marca where nombre_marca = @nombre_marca;"

                comando.Parameters.AddWithValue("@nombre_marca", marcaElegida)

                Dim drMarca As MySqlDataReader

                'Traigo datos de la BD
                drMarca = comando.ExecuteReader

                If drMarca.Read() Then
                    id_marca = drMarca("id_marca")
                End If


                drMarca.Close()
                Conexion.Close()


            Catch ex As Exception
                'Imprimo mensaje en caso de error
                MsgBox(ex.Message)
                Conexion.Close()
            End Try
        End If

    End Sub

    Private Sub cmbModelo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModelo.SelectedIndexChanged
        If lstProductos.SelectedIndex > -1 Then
            Exit Sub
        End If



        If cmbMarca.SelectedIndex >= 0 Then


            modeloElegido = cmbModelo.SelectedItem.ToString

            Try
                'Abro conexion
                Conexion.Open()

                'declaro objeto comando
                Dim comando As New MySqlCommand

                'Indico conexion activa.
                comando.Connection = Conexion

                'Indico tipo de instruccion
                comando.CommandType = CommandType.Text

                'Cargo instruccion sql
                comando.CommandText = "select id_modelo from modelo where nombre_modelo = @nombre_modelo;"

                comando.Parameters.AddWithValue("@nombre_modelo", modeloElegido)

                Dim drModelo As MySqlDataReader

                'Traigo datos de la BD
                drModelo = comando.ExecuteReader

                If drModelo.Read() Then
                    id_modelo = drModelo("id_modelo")
                End If


                drModelo.Close()
                Conexion.Close()


            Catch ex As Exception
                'Imprimo mensaje en caso de error
                MsgBox(ex.Message)
                Conexion.Close()
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Call LimpiarForms()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        PantallaPrincipal.Show()
    End Sub

    Private Sub btnActulizarStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActulizarStock.Click
        Me.Close()
        Stock.Show()
    End Sub

    Private Sub btnTalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTalle.Click
        Me.Close()
        ABMTalle.Show()
    End Sub

    Private Sub btnImagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagenes.Click
        Me.Close()
        ABMImagenes.Show()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtCodigo.Text = "" Or txtDescipcion.Text = "" Then
            MsgBox("Faltan completar campos")
            Exit Sub
        End If

        Try
            'Abro conexion
            Conexion.Open()

            'declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa.
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo instruccion sql
            comando.CommandText = "select id_producto from producto where codigo_producto = @codigo_producto;"

            comando.Parameters.AddWithValue("@codigo_producto", txtCodigo.Text)

            Dim drProducto As MySqlDataReader

            'Traigo datos de la BD
            drProducto = comando.ExecuteReader

            If drProducto.HasRows Then
                MsgBox("El producto ya existe!")
            Else
                drProducto.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into producto (codigo_producto,descripcion,genero,temporada,id_categoria,id_marca,id_modelo) values (@codigo_producto,@descripcion,@genero,@temporada,@id_categoria,@id_marca,@id_modelo);"

                ' FALTA TERMINAR  INSTRUCCION SQL Y PARAMETROS
                comando.Parameters.AddWithValue("@codigo_producto", txtCodigo.Text)
                comando.Parameters.AddWithValue("@descripcion", txtDescipcion.Text)
                comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString)
                comando.Parameters.AddWithValue("@temporada", cmbTemporada.SelectedItem.ToString)
                comando.Parameters.AddWithValue("@id_categoria", id_Categoria)
                comando.Parameters.AddWithValue("@id_marca", id_marca)
                comando.Parameters.AddWithValue("@id_modelo", id_modelo)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el producto exitosamente", MsgBoxStyle.Information, "Guardar")

                Call LimpiarForms()

            End If

            Conexion.Close()

            Call CargarList(txtBusqueda.Text.ToString)

            'Cierro conexion.
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Call LimpiarForms()
        Call HabilitarCampos()
        txtCodigo.Focus()
    End Sub

    Private Sub lstProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProductos.SelectedIndexChanged
        If lstProductos.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Try
            Conexion.Open()

            'Declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo el sql buscando igualdades con items del list
            comando.CommandText = "select * from producto where codigo_producto = @codigos ;"
            comando.Parameters.AddWithValue("@codigos", lstProductos.SelectedItem.ToString)

            'Declaro obejto data reade
            Dim drProducto As MySqlDataReader

            'Traigo datos desde BD
            drProducto = comando.ExecuteReader

            'Si encontre coincidencias
            If drProducto.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las categorias encontradas
                drProducto.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtCodigo.Text = drProducto("codigo_producto")
                txtDescipcion.Text = drProducto("descripcion")
                cmbGenero.SelectedItem = drProducto("genero")
                cmbTemporada.SelectedItem = drProducto("temporada")


                id_categoria = drProducto("id_categoria")
                id_marca = drProducto("id_marca")
                id_modelo = drProducto("id_modelo")

                drProducto.Close()

                comando.Parameters.Clear()

                comando.CommandText = "select nombre_categoria from categoria where id_categoria = @id_categoria;"
                comando.Parameters.AddWithValue("@id_categoria", id_categoria)

                'Declaro obejto data reade
                Dim drCategoria As MySqlDataReader

                'Traigo datos desde BD
                drCategoria = comando.ExecuteReader()


                If drCategoria.Read() Then
                    cmbCategoria.SelectedItem = drCategoria("nombre_categoria").ToString()
                End If

                drCategoria.Close()


                comando.Parameters.Clear()

                comando.CommandText = "select nombre_marca from marca where id_marca = @id_marca;"
                comando.Parameters.AddWithValue("@id_marca", id_marca)

                'Declaro obejto data reade
                Dim drMarca As MySqlDataReader

                'Traigo datos desde BD
                drMarca = comando.ExecuteReader()


                'Si encontre coincidencias
                If drMarca.Read() Then
                    cmbMarca.SelectedItem = drMarca("nombre_marca").ToString
                End If
                drMarca.Close()


                comando.Parameters.Clear()

                comando.CommandText = "select * from modelo where id_modelo = @id_modelo;"
                comando.Parameters.AddWithValue("@id_modelo", id_modelo)

                'Declaro obejto data reade
                Dim drModelo As MySqlDataReader

                'Traigo datos desde BD
                drModelo = comando.ExecuteReader()


                'Si encontre coincidencias
                If drModelo.Read() Then
                    cmbModelo.SelectedItem = drModelo("nombre_modelo").ToString
                End If
                drModelo.Close()
            Else
                Call LimpiarForms()
                drProducto.Close()
            End If
            'Cierro conexion
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Call HabilitarCampos()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If txtCodigo.Text = "" Then
            MsgBox("No hay cambios efectuados para modificar", MsgBoxStyle.Exclamation, "Modificar")
            Exit Sub
        End If

        Try
            'conecto
            Conexion.Open()

            'declaro objeto comand
            Dim Comando As New MySqlCommand

            'configuro el command

            'Indico conexion activa
            Comando.Connection = Conexion

            'Indico el tipo de instruccion
            Comando.CommandType = CommandType.Text

            'cargo instruccion sql
            Comando.CommandText = "select id_producto from producto where codigo_producto = @codigo_producto;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@codigo_producto", txtCodigo.Text)

            'declaro dreader
            Dim drProducto As MySqlDataReader

            'Traigo los datos de la BD
            drProducto = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not drProducto.HasRows Then
                MsgBox("No se encontró el producto para modificar", MsgBoxStyle.Exclamation, "Modificar")
                drProducto.Close()
                Conexion.Close()
                Exit Sub
            End If

            drProducto.Read()
            id_producto = drProducto("id_producto")
            'Cierro Data Reader 
            drProducto.Close()

            'Limpio los parametros para que no esten sobrecargados.
            Comando.Parameters.Clear()

            'Cargo la instruccion sql
            Comando.CommandText = "update producto set codigo_producto=@codigo_producto, descripcion=@descripcion,genero=@genero,temporada=@temporada,id_categoria=(select id_categoria from categoria where nombre_categoria = '" & cmbCategoria.SelectedItem.ToString() & "')," & "id_marca=(select id_marca from marca where nombre_marca = '" & cmbMarca.SelectedItem.ToString() & "')," & "id_modelo=(select id_modelo from modelo where nombre_modelo = '" & cmbModelo.SelectedItem.ToString() & "') where id_producto=@id_producto;"


            'Cargo los parametros
            Comando.Parameters.AddWithValue("@id_producto", id_producto)
            Comando.Parameters.AddWithValue("@codigo_producto", txtCodigo.Text)
            Comando.Parameters.AddWithValue("@descripcion", txtDescipcion.Text)
            Comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString)
            Comando.Parameters.AddWithValue("@temporada", cmbTemporada.SelectedItem.ToString)
            Comando.Parameters.AddWithValue("@categoria", cmbCategoria.SelectedItem.ToString)
            Comando.Parameters.AddWithValue("@marca", cmbMarca.SelectedItem.ToString)
            Comando.Parameters.AddWithValue("@modelo", cmbModelo.SelectedItem.ToString)


            'Imprimo mensaje para confirmar modificacion
            If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Modificar") = MsgBoxResult.Yes Then

                'Variable para obtener respuesta del servidor al ejecutar.
                Dim respuesta As Integer

                'Ejecuto el update
                respuesta = Comando.ExecuteNonQuery

                'Informo las categorias modificadas.
                MsgBox("Se guardaron los cambios  del producto exitosamente", MsgBoxStyle.Information, "Modificar")
                Call LimpiarForms()

            End If
            Conexion.Close()



            Call LimpiarForms()

            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtCodigo.Text = "" Then
            MsgBox("Debe seleccionar un producto para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
            Exit Sub
        End If

        Try
            'Abro conexion
            Conexion.Open()

            'Declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo sql
            comando.CommandText = "select codigo_producto from producto where codigo_producto = @codigo_producto;"

            'cargo parametros
            comando.Parameters.AddWithValue("@codigo_producto", txtCodigo.Text)

            'declaro dreader
            Dim drProducto As MySqlDataReader

            'Traigo datos de la BD
            drProducto = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drProducto.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drProducto.Close()

                comando.Parameters.Clear()

                'verifiquemos que existan productos con este color

                comando.CommandText = "select id_variante_producto from variante_producto where id_producto = @id_producto;"

                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_producto", id_producto)

                Dim drProductoVariante As MySqlDataReader

                drProductoVariante = comando.ExecuteReader

                If drProductoVariante.HasRows Then

                    MsgBox("Este producto tiene variantes asociadas, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drProductoVariante.Close()
                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drProductoVariante.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from producto where codigo_producto = @codigo_producto;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@codigo_producto", txtCodigo.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El producto ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
                    Call LimpiarForms()
                End If

            End If

            'Cierro conexion
            Conexion.Close()

            'Actualizo listbox
            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Call CargarList(txtBusqueda.Text.ToString)
    End Sub
End Class