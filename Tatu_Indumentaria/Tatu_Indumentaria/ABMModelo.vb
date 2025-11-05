Imports MySql.Data.MySqlClient

Public Class ABMModelo

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdModelo.Text = ""
        txtNombreModelo.Text = ""
        txtNombreModelo.ReadOnly = True
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
            comando.CommandText = "select nombre_modelo from modelo where nombre_modelo like'" & dato.ToString & "%' order by nombre_modelo;"

            lstModelos.Items.Clear()

            'Declaro Objeto DataReader
            Dim drModelo As MySqlDataReader

            'Traigo datos desde BD
            drModelo = comando.ExecuteReader

            'Verifico que haya registros
            If drModelo.HasRows Then



                'Recorro el data reader
                Do While drModelo.Read
                    'Agrego los nombres de categoria a los item del list
                    lstModelos.Items.Add(drModelo("nombre_modelo"))
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

    Private Sub lstColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstModelos.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstModelos.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from modelo where nombre_modelo = '" & lstModelos.SelectedItem.ToString & "';"

            'Declaro obejto data reade
            Dim drModelo As MySqlDataReader

            'Traigo datos desde BD
            drModelo = comando.ExecuteReader

            'Si encontre coincidencias
            If drModelo.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las categorias encontradas
                drModelo.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdModelo.Text = drModelo("id_modelo")
                txtNombreModelo.Text = drModelo("nombre_modelo")
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

    Private Sub ABMModelo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        Call Conectar()
        Call CargarList(txtBusqueda.Text.ToString)
        txtNombreModelo.ReadOnly = True
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreModelo.Focus()
        txtNombreModelo.ReadOnly = False
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtNombreModelo.Text = "" Then
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
            comando.CommandText = "select id_modelo from modelo where nombre_modelo = @nombre_modelo;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_modelo", txtNombreModelo.Text)

            'declaro dreader
            Dim drModelo As MySqlDataReader

            'Traigo datos de la BD
            drModelo = comando.ExecuteReader

            'Si hay registros es porque la categoria ya existe.
            If drModelo.HasRows Then
                MsgBox("No se puede agregar, el modelo ya existe", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drModelo.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into modelo (nombre_modelo) values (@nombre_modelo);"
                comando.Parameters.AddWithValue("@nombre_modelo", txtNombreModelo.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el modelo exitosamente", MsgBoxStyle.Information, "Agregar")

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

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdModelo.Text = "" Then
            MsgBox("Seleccionar un modelo para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        txtNombreModelo.Focus()
        txtNombreModelo.ReadOnly = False
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdModelo.Text = "" Or txtNombreModelo.Text = "" Then
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
            Comando.CommandText = "select id_modelo from modelo where id_modelo = @id_modelo;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_modelo", txtIdModelo.Text)

            'declaro dreader
            Dim drModelo As MySqlDataReader

            'Traigo los datos de la BD
            drModelo = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drModelo.HasRows) Then
                MsgBox("No se encontraron modelos para editar", MsgBoxStyle.Exclamation, "Editar")
            Else
                'Cierro Data Reader
                drModelo.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update modelo set nombre_modelo=@nombre_modelo where id_modelo = @id_modelo;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_modelo", txtIdModelo.Text)
                Comando.Parameters.AddWithValue("@nombre_modelo", txtNombreModelo.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Modificar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las categorias modificadas.
                    MsgBox("Se guardaron los cambios del modelo exitosamente", MsgBoxStyle.Information, "Guardar")
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

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdModelo.Text = "" Then
            MsgBox("Debe seleccionar un modelo para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_modelo from modelo where id_modelo = @id_modelo;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_modelo", txtIdModelo.Text)

            'declaro dreader
            Dim drModelo As MySqlDataReader

            'Traigo datos de la BD
            drModelo = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drModelo.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drModelo.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan productos con este marca

                comando.CommandText = "select id_producto from producto where id_modelo = @id_modelo;"

                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_modelo", txtIdModelo.Text)

                Dim drProductoColor As MySqlDataReader

                drProductoColor = comando.ExecuteReader

                If drProductoColor.HasRows Then

                    MsgBox("Este modelo tiene productos asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
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
                comando.CommandText = "delete from modelo where id_modelo = @id_modelo;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_modelo", txtIdModelo.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El modelo ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
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

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Call CargarList(txtBusqueda.Text.ToString)
    End Sub
End Class