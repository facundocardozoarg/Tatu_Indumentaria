Imports MySql.Data.MySqlClient

Public Class ABMColor

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdColor.Text = ""
        txtNombreColor.Text = ""
        txtNombreColor.ReadOnly = True
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
            comando.CommandText = "select nombre_color from color where nombre_color like'" & dato.ToString & "%' order by nombre_color;"

            lstColor.Items.Clear()

            'Declaro Objeto DataReader
            Dim drColor As MySqlDataReader

            'Traigo datos desde BD
            drColor = comando.ExecuteReader

            'Verifico que haya registros
            If drColor.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drColor.Read
                    'Agrego los nombres de categoria a los item del list
                    lstColor.Items.Add(drColor("nombre_color"))
                Loop
            End If
            'Cierro Data reader
            drColor.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    Private Sub lstColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstColor.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstColor.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from color where nombre_color = '" & lstColor.SelectedItem.ToString & "';"

            'Declaro obejto data reade
            Dim drColor As MySqlDataReader

            'Traigo datos desde BD
            drColor = comando.ExecuteReader

            'Si encontre coincidencias
            If drColor.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las categorias encontradas
                drColor.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdColor.Text = drColor("id_color")
                txtNombreColor.Text = drColor("nombre_color")
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

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Limpio Forms
        Call LimpiarForms()
        txtNombreColor.ReadOnly = True
    End Sub


    Private Sub ABMcolor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        txtNombreColor.ReadOnly = True
        Call Conectar()
        Call CargarList(txtBusqueda.Text.ToString)
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

   
    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Productos.Show()
    End Sub

    Private Sub btnModificar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdColor.Text = "" Or txtNombreColor.Text = "" Then
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
            Comando.CommandText = "select id_color from color where id_color = @id_color;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_color", txtIdColor.Text)

            'declaro dreader
            Dim drColor As MySqlDataReader

            'Traigo los datos de la BD
            drColor = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drColor.HasRows) Then
                MsgBox("No se encontraron colores para editar", MsgBoxStyle.Exclamation, "Editar")
            Else
                'Cierro Data Reader
                drColor.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update color set nombre_color=@nombre_color where id_color = @id_color;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_color", txtIdColor.Text)
                Comando.Parameters.AddWithValue("@nombre_color", txtNombreColor.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Modificar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las categorias modificadas.
                    MsgBox("Se guardaron los cambios del color exitosamente", MsgBoxStyle.Information, "Guardar")
                    Call LimpiarForms()
                End If

            End If
            'Cierro conexion
            Conexion.Close()
            'Actualizo list
            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try


    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdColor.Text = "" Then
            MsgBox("Seleccionar un color para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        txtNombreColor.ReadOnly = False
    End Sub

    Private Sub btnAgregar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtNombreColor.Text = "" Then
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
            comando.CommandText = "select id_color from color where nombre_color = @nombre_color;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_color", txtNombreColor.Text)

            'declaro dreader
            Dim drColor As MySqlDataReader

            'Traigo datos de la BD
            drColor = comando.ExecuteReader

            'Si hay registros es porque la categoria ya existe.
            If drColor.HasRows Then
                MsgBox("No se puede agregar el color, ya existe", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drColor.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into color (nombre_color) values (@nombre_color);"
                comando.Parameters.AddWithValue("@nombre_color", txtNombreColor.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el color exitosamente", MsgBoxStyle.Information, "Agregar")

                Call LimpiarForms()
            End If
            'Cierro conexion.
            Conexion.Close()

            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreColor.ReadOnly = False
        txtNombreColor.Focus()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdColor.Text = "" Then
            MsgBox("Debe seleccionar un color para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_color from color where id_color = @id_color;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_color", txtIdColor.Text)

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

                comando.Parameters.Clear()

                'verifiquemos que existan productos con este color

                comando.CommandText = "select id_variante_producto from variante_producto where id_color = @id_color;"

                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_color", txtIdColor.Text)

                Dim drProductoColor As MySqlDataReader

                drProductoColor = comando.ExecuteReader

                If drProductoColor.HasRows Then

                    MsgBox("Este color tiene productos asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drProductoColor.Close()
                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drProductoColor.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from color where id_color = @id_color;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_color", txtIdColor.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El color ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
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

    Private Sub btnVolver_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()

    End Sub

    Private Sub btnBorrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Call CargarList(txtBusqueda.Text.ToString)
    End Sub
End Class
