Imports MySql.Data.MySqlClient

Public Class ABMCategorias

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdCat.Text = ""
        txtNombreCategoria.Text = ""
        txtNombreCategoria.ReadOnly = True
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
            comando.CommandText = "select nombre_categoria from categoria order by nombre_categoria"

            lstCategorias.Items.Clear()

            'Declaro Objeto DataReader
            Dim drCategoria As MySqlDataReader

            'Traigo datos desde BD
            drCategoria = comando.ExecuteReader

            'Verifico que haya registros
            If drCategoria.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drCategoria.Read
                    'Agrego los nombres de categoria a los item del list
                    lstCategorias.Items.Add(drCategoria("nombre_categoria"))
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

    Private Sub lstCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCategorias.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstCategorias.SelectedItem Is Nothing Then
                Exit Sub
            End If

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
            comando.CommandText = "select * from categoria where nombre_categoria = '" & lstCategorias.SelectedItem.ToString & "';"

            'Declaro obejto data reade
            Dim drCategoria As MySqlDataReader

            'Traigo datos desde BD
            drCategoria = comando.ExecuteReader

            'Si encontre coincidencias
            If drCategoria.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las categorias encontradas
                drCategoria.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdCat.Text = drCategoria("id_categoria")
                txtNombreCategoria.Text = drCategoria("nombre_categoria")
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




    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        'Limpio Forms
        Call LimpiarForms()
        txtNombreCategoria.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreCategoria.Focus()
        txtNombreCategoria.ReadOnly = False
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdCat.Text = "" Or txtNombreCategoria.Text = "" Then
            MsgBox("No hay cambios efectuados para guardar", MsgBoxStyle.Exclamation, "Guardar")
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
            Comando.CommandText = "select id_categoria from categoria where id_categoria = @id_categoria;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_categoria", txtIdCat.Text)

            'declaro dreader
            Dim drCategoria As MySqlDataReader

            'Traigo los datos de la BD
            drCategoria = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drCategoria.HasRows) Then
                MsgBox("No se encontraron categorias para editar", MsgBoxStyle.Exclamation, "Editar")
            Else
                'Cierro Data Reader
                drCategoria.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update categoria set nombre_categoria=@nombre_categoria where id_categoria = @id_categoria;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_categoria", txtIdCat.Text)
                Comando.Parameters.AddWithValue("@nombre_categoria", txtNombreCategoria.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea guardar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las categorias modificadas.
                    MsgBox("Se guardaron los cambios de la categoría exitosamente", MsgBoxStyle.Information)
                    Call LimpiarForms()
                End If

            End If
            'Cierro conexion
            Conexion.Close()
            'Actualizo list
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try


    End Sub


    Private Sub ABMCategorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        txtNombreCategoria.ReadOnly = True
        Call Conectar()
        Call CargarList()
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False 
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdCat.Text = "" Then
            MsgBox("Debe seleccionar una categoria para eliminar", MsgBoxStyle.Exclamation, "Error al eliminar")
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
            comando.CommandText = "select id_categoria from categoria where id_categoria = @id_categoria;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_categoria", txtIdCat.Text)

            'declaro dreader
            Dim drCategoria As MySqlDataReader

            'Traigo datos de la BD
            drCategoria = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drCategoria.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drCategoria.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan productos con esta categoria

                comando.CommandText = "select id_producto from producto where id_categoria = @id_categoria;"


                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_categoria", txtIdCat.Text)

                Dim drProductoCategoria As MySqlDataReader

                drProductoCategoria = comando.ExecuteReader

                If drProductoCategoria.HasRows Then

                    MsgBox("Esta categoria tiene productos asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drProductoCategoria.Close()

                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drProductoCategoria.Close()

                'Limpiamos los parametros anteriores
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from categoria where id_categoria = @id_categoria;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_categoria", txtIdCat.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("Esta seguro que desea eliminar", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Seguro de eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("La categoría fue eliminada exitosamente!", MsgBoxStyle.Information, "Eliminar")
                    Call LimpiarForms()
                    txtNombreCategoria.Enabled = False
                End If

            End If

            'Cierro conexion
            Conexion.Close()

            'Actualizo listbox
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtNombreCategoria.Text = "" Then
            MsgBox("No se permiten datos vacíos.", MsgBoxStyle.Exclamation, "Agregar")
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
            comando.CommandText = "select id_categoria from categoria where nombre_categoria = @nombre_categoria;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_categoria", txtNombreCategoria.Text)

            'declaro dreader
            Dim dreCategoria As MySqlDataReader

            'Traigo datos de la BD
            dreCategoria = comando.ExecuteReader

            'Si hay registros es porque la categoria ya existe.
            If dreCategoria.HasRows Then
                MsgBox("No se puede agregar la categoria, ya existe", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                dreCategoria.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into categoria (nombre_categoria) values (@nombre_categoria);"
                comando.Parameters.AddWithValue("@nombre_categoria", txtNombreCategoria.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego la categoria exitosamente", MsgBoxStyle.Information, "Agregar")

                Call LimpiarForms()
            End If
            'Cierro conexion.
            Conexion.Close()

            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdCat.Text = "" Then
            MsgBox("Seleccinar una categoria para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        txtNombreCategoria.ReadOnly = False
    End Sub
End Class