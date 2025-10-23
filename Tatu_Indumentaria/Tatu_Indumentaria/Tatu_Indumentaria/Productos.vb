Imports MySql.Data.MySqlClient
Public Class Productos

    Public categoriaElegida As String
    Public marcaElegida As String
    Public modeloElegido As String

    Public id_Categoria As Integer
    Public id_marca As Integer
    Public id_modelo As Integer



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


    Sub CargarList()
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
        Call CargarList()
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click, Button1.Click
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

                MsgBox("Productos agregados: " + Respuesta.ToString)

            End If
            Call LimpiarForms()
            Call CargarList()
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

<<<<<<< HEAD
    Private Sub btnMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarca.Click
        Me.Close()
        ABMMarcas.Show()
    End Sub
=======
                drProducto.Close()

                comando.Parameters.Clear()
>>>>>>> 373277c250345c321872b4a2381e4718c25375ed

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

<<<<<<< HEAD
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Call LimpiarCampos()

    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        PantallaPrincipal.Show()
    End Sub

    Private Sub btnActulizarStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActulizarStock.Click
        Me.Close()
        Stock.Show()
=======
    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Call HabilitarCampos()
>>>>>>> 373277c250345c321872b4a2381e4718c25375ed
    End Sub

    Private Sub btnTalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTalle.Click
        Me.Close()
        ABMTalle.Show()
    End Sub
End Class