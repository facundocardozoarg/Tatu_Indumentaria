Imports MySql.Data.MySqlClient

Public Class ABMGestionEnvio

    Public EmpresaElegida As String
    Public id_empresa_envio As Integer


    Sub LimpiarForms()
        txtIdEnvio.Text = ""
        txtSeguimiento.Text = ""
        txtDescripcion.Text = ""
        txtDireccion.Text = ""
        txtMonto.Text = ""
        cmbEstado.SelectedIndex = -1
        cmbEmpresa.SelectedIndex = -1
        cmbEmpresa.Items.Clear()
        Call DeshabilitarCampos()
    End Sub

    Sub HabilitarCampos()
        txtIdEnvio.ReadOnly = True
        txtSeguimiento.ReadOnly = False
        txtDescripcion.ReadOnly = False
        txtDireccion.ReadOnly = False
        txtMonto.ReadOnly = False
        cmbEstado.Enabled = True
        cmbEmpresa.Enabled = True
    End Sub


    Sub DeshabilitarCampos()
        txtIdEnvio.ReadOnly = True
        txtSeguimiento.ReadOnly = True
        txtDescripcion.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtMonto.ReadOnly = True
        cmbEstado.Enabled = False
        cmbEmpresa.Enabled = False
    End Sub


    Sub CargarList(ByVal dato As String)
        Try
            'Ejecuto la conexion a la BD
            Conexion.Open()

            'Declaro objeto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro los seguimientos y los ordeno.
            comando.CommandText = "select codigo_envio, descripcion_envio from envio where codigo_envio like'" & dato.ToString & "%' OR descripcion_envio like'" & dato.ToString & "%' order by codigo_envio;"

            lstEnvios.Items.Clear()

            'Declaro Objeto DataReader
            Dim drEnvio As MySqlDataReader

            'Traigo datos desde BD
            drEnvio = comando.ExecuteReader

            'Verifico que haya registros
            If drEnvio.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drEnvio.Read
                    'Agrego los codigos de envio a los item del list
                    lstEnvios.Items.Add(drEnvio("codigo_envio"))
                Loop
            End If
            'Cierro Data reader
            drEnvio.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    Sub CargarEmpresas()
        Try
            cmbEmpresa.Items.Clear()
            'Ejecuto la conexion a la BD
            Conexion.Open()

            'Declaro objeto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de empresa.
            comando.CommandText = "select nombre_empresa from empresa_envio order by nombre_empresa "

            'Declaro Objeto DataReader
            Dim drEmpresa As MySqlDataReader

            'Traigo datos desde BD
            drEmpresa = comando.ExecuteReader

            'Verifico que haya registros
            If drEmpresa.HasRows Then


                'Recorro el data reader
                Do While drEmpresa.Read
                    'Agrego los nombres de empresas a los item del cmb
                    cmbEmpresa.Items.Add(drEmpresa("nombre_empresa"))
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

    Private Sub ABMGestionEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        Call CargarList(txtBusqueda.Text.ToString)
        Call DeshabilitarCampos()
        cmbEstado.SelectedIndex = -1
        cmbEstado.Items.Add("En preparacion")
        cmbEstado.Items.Add("En camino")
        cmbEstado.Items.Add("Entregado")

        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If cmbEmpresa.SelectedIndex < 0 Then
            Exit Sub
        End If
        EmpresaElegida = cmbEmpresa.SelectedItem.ToString()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Call LimpiarForms()
        Call HabilitarCampos()
        Call CargarEmpresas()
        txtSeguimiento.Focus()
    End Sub

    Private Sub lstEnvios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEnvios.SelectedIndexChanged
        Call DeshabilitarCampos()
        'Evito un error al hacer click donde no tenga items el list.

        If lstEnvios.SelectedItem Is Nothing Then
            Exit Sub
        End If

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
            comando.CommandText = "select * from envio where codigo_envio = '" & lstEnvios.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drEnvio As MySqlDataReader

            'Traigo datos desde BD
            drEnvio = comando.ExecuteReader

            'Si encontre coincidencias
            If drEnvio.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos los envios encontrados
                drEnvio.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdEnvio.Text = drEnvio("id_envio")
                txtSeguimiento.Text = drEnvio("codigo_envio")
                txtDescripcion.Text = drEnvio("descripcion_envio")
                txtDireccion.Text = drEnvio("direccion_envio")
                txtMonto.Text = drEnvio("monto_envio")
                cmbEstado.SelectedItem = drEnvio("estado_envio")

                id_empresa_envio = drEnvio("id_empresa_envio")

                If Not (IsDBNull(drEnvio("fecha_envio"))) Then
                    dtpFechaEnv.Value = drEnvio("fecha_envio")
                Else
                    MsgBox("No tiene fecha envio, se actualiza a la de hoy")
                    dtpFechaEnv.Value = Now
                End If

                drEnvio.Close()

                comando.Parameters.Clear()

                comando.CommandText = "select * from empresa_envio where id_empresa_envio = @id_empresa_envio;"
                comando.Parameters.AddWithValue("@id_empresa_envio", id_empresa_envio)

                'Declaro objeto data reader
                Dim drEmpresaEnvio As MySqlDataReader

                'Traigo datos desde BD
                drEmpresaEnvio = comando.ExecuteReader()


                'Si encontre coincidencias
                If drEmpresaEnvio.HasRows Then
                    drEmpresaEnvio.Read()
                    id_empresa_envio = drEmpresaEnvio("id_empresa_envio")
                    EmpresaElegida = drEmpresaEnvio("nombre_empresa")
                End If
                drEmpresaEnvio.Close()

            Else
                Call LimpiarForms()
            End If
            'Cierro conexion
            Conexion.Close()


            cmbEmpresa.Items.Clear()

            cmbEmpresa.Items.Add(EmpresaElegida)
            cmbEmpresa.SelectedItem = (EmpresaElegida)
            
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        MenuEnvios.Show()
    End Sub

    
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdEnvio.Text = "" Then
            MsgBox("Debe seleccionar un envio para eliminar", MsgBoxStyle.Exclamation, "Error al eliminar")
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
            comando.CommandText = "select id_envio from envio where id_envio = @id_envio;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_envio", txtIdEnvio.Text)

            'declaro dreader
            Dim drEnvio As MySqlDataReader

            'Traigo datos de la BD
            drEnvio = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drEnvio.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drEnvio.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from envio where id_envio = @id_envio;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_envio", txtIdEnvio.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Seguro de eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El envio ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtSeguimiento.Text = "" Then
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
            Comando.CommandText = "select id_envio from envio where id_envio = @id_envio;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_envio", txtIdEnvio.Text)

            'declaro dreader
            Dim drEnvio As MySqlDataReader

            'Traigo los datos de la BD
            drEnvio = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drEnvio.HasRows) Then
                MsgBox("No se encontraron envios para editar", MsgBoxStyle.Exclamation, "Editar")
                drEnvio.Close()
                Conexion.Close()
                Exit Sub
            Else
                'Cierro Data Reader
                drEnvio.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update envio set codigo_envio=@codigo_envio,descripcion_envio=@descripcion_envio,fecha_envio=@fecha_envio,direccion_envio=@direccion_envio,monto_envio=@monto_envio,estado_envio=@estado_envio,id_empresa_envio=(select id_empresa_envio from empresa_envio where nombre_empresa = '" & EmpresaElegida & "') where id_envio=@id_envio;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_envio", txtIdEnvio.Text)
                Comando.Parameters.AddWithValue("@codigo_envio", txtSeguimiento.Text)
                Comando.Parameters.AddWithValue("@descripcion_envio", txtDescripcion.Text)
                Comando.Parameters.AddWithValue("@fecha_envio", dtpFechaEnv.Value.ToString("yyyy-MM-dd"))
                Comando.Parameters.AddWithValue("@direccion_envio", txtDireccion.Text)
                Comando.Parameters.AddWithValue("@monto_envio", Convert.ToDecimal(txtMonto.Text))
                Comando.Parameters.AddWithValue("@estado_envio", cmbEstado.SelectedItem.ToString)


                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las categorias modificadas.
                    MsgBox("Se guardaron los cambios  del empleado exitosamente", MsgBoxStyle.Information, "Guardar")
                    Call LimpiarForms()

                End If
                Conexion.Close()
            End If


            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtSeguimiento.Text = "" Then
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
            comando.CommandText = "select id_envio from envio where codigo_envio = @codigo_envio;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@codigo_envio", txtSeguimiento.Text)

            'declaro dreader
            Dim drEnvio As MySqlDataReader

            'Traigo datos de la BD
            drEnvio = comando.ExecuteReader

            'Si hay registros es porque el envio ya existe.
            If drEnvio.HasRows Then
                MsgBox("No se puede agregar el envio, ya existe", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drEnvio.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into envio (codigo_envio,descripcion_envio,fecha_envio,direccion_envio,monto_envio,estado_envio,id_empresa_envio) values (@codigo_envio,@descripcion_envio,@fecha_envio,@direccion_envio,@monto_envio,@estado_envio,(select id_empresa_envio from empresa_envio where nombre_empresa = '" & EmpresaElegida & "'));"


                comando.Parameters.AddWithValue("@codigo_envio", txtSeguimiento.Text)
                comando.Parameters.AddWithValue("@descripcion_envio", txtDescripcion.Text)
                comando.Parameters.AddWithValue("@fecha_envio", dtpFechaEnv.Value.ToString("yyyy-MM-dd"))
                comando.Parameters.AddWithValue("@direccion_envio", txtDireccion.Text)
                comando.Parameters.AddWithValue("@monto_envio", Convert.ToDecimal(txtMonto.Text))
                comando.Parameters.AddWithValue("@estado_envio", cmbEstado.SelectedItem.ToString)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el envio exitosamente", MsgBoxStyle.Information, "Agregar")

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
        If txtIdEnvio.Text = "" Then
            MsgBox("Seleccinar un envio para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If

        Call HabilitarCampos()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Call CargarList(txtBusqueda.Text.ToString())
    End Sub
End Class