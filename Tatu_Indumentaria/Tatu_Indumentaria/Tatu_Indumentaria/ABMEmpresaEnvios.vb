Imports MySql.Data.MySqlClient
Public Class ABMEmpresaEnvios

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdEmpresa.Text = ""
        txtNombreEmpresa.Text = ""
    End Sub

    Sub HabilitarCampos()
        txtIdEmpresa.ReadOnly = True
        txtNombreEmpresa.ReadOnly = False

    End Sub


    Sub DeshabilitarCampos()
        txtIdEmpresa.ReadOnly = True
        txtNombreEmpresa.ReadOnly = True
    End Sub

    Sub CargarList()
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
            comando.CommandText = "select nombre_empresa from empresa_envio order by nombre_empresa"

            lstEmpresas.Items.Clear()

            'Declaro Objeto DataReader
            Dim drEmpresa As MySqlDataReader

            'Traigo datos desde BD
            drEmpresa = comando.ExecuteReader

            'Verifico que haya registros
            If drEmpresa.HasRows Then

                'Recorro el data reader
                Do While drEmpresa.Read
                    'Agrego los nombres de empresas a los item del list
                    lstEmpresas.Items.Add(drEmpresa("nombre_empresa"))
                Loop
            End If
            'Cierro Data reader
            drEmpresa.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    Private Sub lstEmpresas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEmpresas.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstEmpresas.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from empresa_envio where nombre_empresa = '" & lstEmpresas.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drEmpresa As MySqlDataReader

            'Traigo datos desde BD
            drEmpresa = comando.ExecuteReader

            'Si encontre coincidencias
            If drEmpresa.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las empresas encontradas
                drEmpresa.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdEmpresa.Text = drEmpresa("id_empresa_envio")
                txtNombreEmpresa.Text = drEmpresa("nombre_empresa")
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
        If txtNombreEmpresa.Text = "" Then
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
            comando.CommandText = "select id_empresa_envio from empresa_envio where nombre_empresa = @nombre_empresa;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text)

            'declaro dreader
            Dim drEmpresa As MySqlDataReader

            'Traigo datos de la BD
            drEmpresa = comando.ExecuteReader

            'Si hay registros es porque la empresa ya existe.
            If drEmpresa.HasRows Then
                MsgBox("No se puede agregar, la empresa ya existe!", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drEmpresa.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into empresa_envio (nombre_empresa) values (@nombre_empresa);"
                comando.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("La empresa ha sido agregado con exito!", MsgBoxStyle.Information, "Agregar")

                Call DeshabilitarCampos()

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

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        'Limpio Forms
        Call LimpiarForms()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreEmpresa.Focus()
        Call HabilitarCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'valido que no intenten guardar con campos vacios
        If txtIdEmpresa.Text = "" Or txtNombreEmpresa.Text = "" Then
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
            Comando.CommandText = "select id_empresa_envio from empresa_envio where id_empresa_envio = @id_empresa_envio;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_empresa_envio", txtIdEmpresa.Text)

            'declaro dreader
            Dim drEmpresa As MySqlDataReader

            'Traigo los datos de la BD
            drEmpresa = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drEmpresa.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro Data Reader
                drEmpresa.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update empresa_envio set nombre_empresa=@nombre_empresa where id_empresa_envio = @id_empresa_envio;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_empresa_envio", txtIdEmpresa.Text)
                Comando.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text)

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
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub ABMEmpresaEnvios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        Call Conectar()
        Call CargarList()
        Call DeshabilitarCampos()
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdEmpresa.Text = "" Then
            MsgBox("Debe seleccionar una empresa para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_empresa_envio from empresa_envio where id_empresa_envio = @id_empresa_envio;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_empresa_envio", txtIdEmpresa.Text)

            'declaro dreader
            Dim drEmpresa As MySqlDataReader

            'Traigo datos de la BD
            drEmpresa = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drEmpresa.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drEmpresa.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan envios con esta empresa

                comando.CommandText = "select id_envio from envio where id_empresa_envio = @id_empresa_envio;"


                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_empresa_envio", txtIdEmpresa.Text)

                Dim drEmpresaEnvio_Envio As MySqlDataReader

                drEmpresaEnvio_Envio = comando.ExecuteReader

                If drEmpresaEnvio_Envio.HasRows Then

                    MsgBox("Esta empresa tiene envios asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drEmpresaEnvio_Envio.Close()

                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drEmpresaEnvio_Envio.Close()

                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from empresa_envio where id_empresa_envio = @id_empresa_envio;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_empresa_envio", txtIdEmpresa.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea eliminar esta empresa?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("La empresa ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
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

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        MenuEnvios.Show()
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdEmpresa.Text = "" Then
            MsgBox("Debe seleccionar una empresa para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        Call HabilitarCampos()
    End Sub
End Class