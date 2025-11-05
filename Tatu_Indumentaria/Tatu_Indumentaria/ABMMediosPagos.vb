Imports MySql.Data.MySqlClient

Public Class ABMMediosPagos

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdMedioPago.Text = ""
        txtNombreMedioP.Text = ""
    End Sub

    Sub HabilitarCampos()
        txtIdMedioPago.ReadOnly = True
        txtNombreMedioP.ReadOnly = False

    End Sub


    Sub DeshabilitarCampos()
        txtIdMedioPago.ReadOnly = True
        txtNombreMedioP.ReadOnly = True
    End Sub

    Sub CargarList(ByVal dato As String)
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro objeto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de empresa y los ordeno.
            comando.CommandText = "select nombre_medio_pago from medio_pago where nombre_medio_pago like'" & dato.ToString & "%' order by nombre_medio_pago;"

            lstMedioPago.Items.Clear()

            'Declaro Objeto DataReader
            Dim drMedioPago As MySqlDataReader

            'Traigo datos desde BD
            drMedioPago = comando.ExecuteReader

            'Verifico que haya registros
            If drMedioPago.HasRows Then

                'Recorro el data reader
                Do While drMedioPago.Read
                    'Agrego los nombres de medios de pago a los item del list
                    lstMedioPago.Items.Add(drMedioPago("nombre_medio_pago"))
                Loop
            End If
            'Cierro Data reader
            drMedioPago.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub lstMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMedioPago.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstMedioPago.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from medio_pago where nombre_medio_pago = '" & lstMedioPago.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drMedioPago As MySqlDataReader

            'Traigo datos desde BD
            drMedioPago = comando.ExecuteReader

            'Si encontre coincidencias
            If drMedioPago.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos los medios de pagos encontrados
                drMedioPago.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdMedioPago.Text = drMedioPago("id_medio_pago")
                txtNombreMedioP.Text = drMedioPago("nombre_medio_pago")
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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtNombreMedioP.Text = "" Then
            MsgBox("No se pueden agregar datos vacíos", MsgBoxStyle.Exclamation, "Agregar")
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
            comando.CommandText = "select id_medio_pago from medio_pago where nombre_medio_pago = @nombre_medio_pago;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_medio_pago", txtNombreMedioP.Text)

            'declaro dreader
            Dim drMedioPago As MySqlDataReader

            'Traigo datos de la BD
            drMedioPago = comando.ExecuteReader

            'Si hay registros es porque el medio de pago ya existe.
            If drMedioPago.HasRows Then
                MsgBox("No se puede agregar, el medio de pago ya existe!", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drMedioPago.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into medio_pago (nombre_medio_pago) values (@nombre_medio_pago);"
                comando.Parameters.AddWithValue("@nombre_medio_pago", txtNombreMedioP.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("El medio de pago ha sido agregado con exito!", MsgBoxStyle.Information, "Agregar")

                Call DeshabilitarCampos()

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

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        'Limpio Forms
        Call LimpiarForms()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreMedioP.Focus()
        Call HabilitarCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'valido que no intenten guardar con campos vacios
        If txtIdMedioPago.Text = "" Or txtNombreMedioP.Text = "" Then
            MsgBox("No se han efectuados cambios para guardar", MsgBoxStyle.Exclamation, "Guardar")
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
            Comando.CommandText = "select id_medio_pago from medio_pago where id_medio_pago = @id_medio_pago;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_medio_pago", txtIdMedioPago.Text)

            'declaro dreader
            Dim drMedioPago As MySqlDataReader

            'Traigo los datos de la BD
            drMedioPago = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drMedioPago.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro Data Reader
                drMedioPago.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update medio_pago set nombre_medio_pago=@nombre_medio_pago where id_medio_pago = @id_medio_pago;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_medio_pago", txtIdMedioPago.Text)
                Comando.Parameters.AddWithValue("@nombre_medio_pago", txtNombreMedioP.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Está seguro que desea guardar la modificacion?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo los cambios modificados.
                    MsgBox("Los cambios se han guardado exitosamente!", MsgBoxStyle.Information, "Guardar")
                    Call LimpiarForms()
                    Call DeshabilitarCampos()
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

    Private Sub ABMMediosPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        Call Conectar()
        Call CargarList(txtBusqueda.Text.ToString)
        Call DeshabilitarCampos()
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdMedioPago.Text = "" Then
            MsgBox("Debe seleccionar un medio de pago para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_medio_pago from medio_pago where id_medio_pago = @id_medio_pago;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_medio_pago", txtIdMedioPago.Text)

            'declaro dreader
            Dim drMedioPago As MySqlDataReader

            'Traigo datos de la BD
            drMedioPago = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drMedioPago.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drMedioPago.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan ventas con este medio de pago

                comando.CommandText = "select id_venta from venta where id_medio_pago = @id_medio_pago;"


                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_medio_pago", txtIdMedioPago.Text)

                Dim drMedioPago_Venta As MySqlDataReader

                drMedioPago_Venta = comando.ExecuteReader

                If drMedioPago_Venta.HasRows Then

                    MsgBox("Este medio de pago tiene ventas asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drMedioPago_Venta.Close()

                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drMedioPago_Venta.Close()

                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from medio_pago where id_medio_pago = @id_medio_pago;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_medio_pago", txtIdMedioPago.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea eliminar este medio de pago?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El medio de pago ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
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

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        MenuVenta.Show()
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdMedioPago.Text = "" Then
            MsgBox("Debe seleccionar un medio de pago para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        Call HabilitarCampos()
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Call CargarList(txtBusqueda.Text.ToString)
    End Sub
End Class