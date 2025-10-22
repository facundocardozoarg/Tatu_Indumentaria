Imports MySql.Data.MySqlClient

Public Class ABMTalle

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdTalle.Text = ""
        txtNombreTalle.Text = ""
        txtNombreTalle.ReadOnly = True
    End Sub


    Sub CargarList()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre del talle y los ordeno.
            comando.CommandText = "select nombre_talle from talle order by nombre_talle;"

            lstTalles.Items.Clear()

            'Declaro Objeto DataReader
            Dim drTalle As MySqlDataReader

            'Traigo datos desde BD
            drTalle = comando.ExecuteReader

            'Verifico que haya registros
            If drTalle.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drTalle.Read
                    'Agrego los nombres del talle a los item del list
                    lstTalles.Items.Add(drTalle("nombre_talle"))
                Loop
            End If
            'Cierro Data reader
            drTalle.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub lstTalle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTalles.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstTalles.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from talle where nombre_talle = '" & lstTalles.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drTalle As MySqlDataReader

            'Traigo datos desde BD
            drTalle = comando.ExecuteReader

            'Si encontre coincidencias
            If drTalle.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos los talles encontradas
                drTalle.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdTalle.Text = drTalle("id_talle")
                txtNombreTalle.Text = drTalle("nombre_talle")
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

    Private Sub ABMTalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        Call Conectar()
        Call CargarList()
        txtNombreTalle.ReadOnly = True
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreTalle.Focus()
        txtNombreTalle.ReadOnly = False
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtNombreTalle.Text = "" Then
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
            comando.CommandText = "select id_talle from talle where nombre_talle = @nombre_talle;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_talle", txtNombreTalle.Text)

            'declaro dreader
            Dim drTalle As MySqlDataReader

            'Traigo datos de la BD
            drTalle = comando.ExecuteReader

            'Si hay registros es porque el talle ya existe.
            If drTalle.HasRows Then
                MsgBox("No se puede agregar, el talle ya existe", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drTalle.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into talle (nombre_talle) values (@nombre_talle);"
                comando.Parameters.AddWithValue("@nombre_talle", txtNombreTalle.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el talle exitosamente", MsgBoxStyle.Information, "Agregar")

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
        If txtIdTalle.Text = "" Then
            MsgBox("Seleccionar un talle para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        txtNombreTalle.ReadOnly = False
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdTalle.Text = "" Or txtNombreTalle.Text = "" Then
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
            Comando.CommandText = "select id_talle from talle where id_talle = @id_talle;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_talle", txtIdTalle.Text)

            'declaro dreader
            Dim drTalle As MySqlDataReader

            'Traigo los datos de la BD
            drTalle = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drTalle.HasRows) Then
                MsgBox("No se encontraron talles para editar", MsgBoxStyle.Exclamation, "Editar")
            Else
                'Cierro Data Reader
                drTalle.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update talle set nombre_talle=@nombre_talle where id_talle = @id_talle;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_talle", txtIdTalle.Text)
                Comando.Parameters.AddWithValue("@nombre_talle", txtNombreTalle.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Modificar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las talles modificados.
                    MsgBox("Se guardaron los cambios del talle exitosamente", MsgBoxStyle.Information, "Guardar")

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

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdTalle.Text = "" Then
            MsgBox("Debe seleccionar un talle para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_talle from talle where id_talle = @id_talle;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_talle", txtIdTalle.Text)

            'declaro dreader
            Dim drTalle As MySqlDataReader

            'Traigo datos de la BD
            drTalle = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drTalle.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drTalle.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan productos con este marca

                comando.CommandText = "select id_variante_producto from variante_producto where id_talle = @id_talle;"

                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_talle", txtIdTalle.Text)

                Dim drProductoTalle As MySqlDataReader

                drProductoTalle = comando.ExecuteReader

                If drProductoTalle.HasRows Then

                    MsgBox("Este talle tiene productos asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drProductoTalle.Close()
                    Conexion.Close()
                    Call LimpiarForms()

                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drProductoTalle.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from talle where id_talle = @id_talle;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_talle", txtIdTalle.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El talle ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
                    Call LimpiarForms()
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

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()
    End Sub
End Class