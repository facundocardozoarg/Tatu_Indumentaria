Imports MySql.Data.MySqlClient

Public Class ABMCiudades


    Public id_provincia As Double

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdCiudad.Text = ""
        txtNombreCiudad.Text = ""
        txtCodigoPostal.Text = ""
        cmbProvincia.SelectedIndex = -1
        Call DeshabilitarCampos()
    End Sub

    Sub HabilitarCampos()
        txtIdCiudad.ReadOnly = True
        txtNombreCiudad.ReadOnly = False
        txtCodigoPostal.ReadOnly = False
        cmbProvincia.Enabled = True
    End Sub


    Sub DeshabilitarCampos()
        txtIdCiudad.ReadOnly = True
        txtNombreCiudad.ReadOnly = True
        txtCodigoPostal.ReadOnly = True
        cmbProvincia.Enabled = False
    End Sub

    Sub CargarList(ByVal dato As String)
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            comando.CommandText = "select nombre_ciudad from ciudad where nombre_ciudad like'" & dato.ToString & "%' order by nombre_ciudad;"


            lstCiudades.Items.Clear()

            'Declaro Objeto DataReader
            Dim drCiudad As MySqlDataReader

            'Traigo datos desde BD
            drCiudad = comando.ExecuteReader

            'Verifico que haya registros
            If drCiudad.HasRows Then

                'Recorro el data reader
                Do While drCiudad.Read
                    'Agrego los nombres de ciudades a los item del list
                    lstCiudades.Items.Add(drCiudad("nombre_ciudad"))
                Loop
            End If
            'Cierro Data reader
            drCiudad.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    Sub CargarProvincias()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro objeto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de provincia y los ordeno.
            comando.CommandText = "select nombre_provincia from provincia order by nombre_provincia "

            'Declaro Objeto DataReader
            Dim drProvincia As MySqlDataReader

            'Traigo datos desde BD
            drProvincia = comando.ExecuteReader

            'Verifico que haya registros
            If drProvincia.HasRows Then

                'Recorro el data reader
                Do While drProvincia.Read
                    'Agrego los nombres de provincias a los item del list
                    cmbProvincia.Items.Add(drProvincia("nombre_provincia"))
                Loop
            End If
            'Cierro Data reader
            drProvincia.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub lstCiudades_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCiudades.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstCiudades.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from ciudad where nombre_ciudad = '" & lstCiudades.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drCiudad As MySqlDataReader

            'Traigo datos desde BD
            drCiudad = comando.ExecuteReader

            'Si encontre coincidencias
            If drCiudad.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las ciudades encontradas
                drCiudad.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdCiudad.Text = drCiudad("id_ciudad")
                txtNombreCiudad.Text = drCiudad("nombre_ciudad")
                txtCodigoPostal.Text = drCiudad("codigo_postal")



                id_provincia = drCiudad("id_provincia") 'guardo el id 

                'cierro el data reader
                drCiudad.Close()

                'cargo instruccion sql
                comando.CommandText = "select nombre_provincia from provincia where id_provincia = @id_provincia"

                'cargo parametros
                comando.Parameters.AddWithValue("@id_provincia", id_provincia)

                'declaro data reader
                Dim drProvincia As MySqlDataReader

                'Traigo datos desde BD
                drProvincia = comando.ExecuteReader()

                'verifico si existen registros
                If drProvincia.Read() Then
                    cmbProvincia.SelectedItem = drProvincia("nombre_provincia").ToString() 'obetenemos el valor del item
                End If

                'cierro datareader
                drProvincia.Close()
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
        If txtNombreCiudad.Text = "" Or txtCodigoPostal.Text = "" Then
            MsgBox("No se pueden agregar datos vacíos", MsgBoxStyle.Exclamation, "Agregar")
            Exit Sub
        ElseIf cmbProvincia.Items.Count = 0 Then
            MsgBox("No se puede agregar, debe cargar una provincia previamente", MsgBoxStyle.Exclamation, "Agregar")
            Exit Sub
        End If

        If cmbProvincia.SelectedIndex = -1 Then
            MsgBox("No se pueden agregar, elegir una provincia previamente", MsgBoxStyle.Exclamation, "Agregar")
            Exit Sub
        End If

        Try
            'abro conexcion
            Conexion.Open()

            'declaro objeto comand
            Dim comando As New MySqlCommand

            'Indico conexion activa.
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            ' Verifico si ya existe la provincia (para evitar duplicados)
            comando.CommandText = "select id_ciudad from ciudad where nombre_ciudad = @nombre_ciudad"
            comando.Parameters.AddWithValue("@nombre_ciudad", txtNombreCiudad.Text)


            'declaro dreader
            Dim drCiudad As MySqlDataReader

            'Traigo datos de la BD
            drCiudad = comando.ExecuteReader()

            'Si hay registros es porque la ciudad ya existe.
            If drCiudad.HasRows Then
                MsgBox("No se puede agregar, la ciudad ya existe!", MsgBoxStyle.Exclamation, "Agregar")

                'cierro el data reader
                drCiudad.Close()

                'Cierro conexion.
                Conexion.Close()
                Exit Sub
            End If

            'cierro el data reader
            drCiudad.Close()

            'Limpiamos los parametros del comand
            comando.Parameters.Clear()

            'Obtengo el id del combo box
            comando.CommandText = "select id_provincia from provincia where nombre_provincia = @nombre_provincia"
            comando.Parameters.AddWithValue("@nombre_provincia", cmbProvincia.Text)

            'declaro data reader
            Dim drProvincia As MySqlDataReader

            'Traigo datos de la BD
            drProvincia = comando.ExecuteReader()


            If drProvincia.Read() Then
                id_provincia = drProvincia("id_provincia") 'guardo el id 
            Else

                'cierro la conexion
                Conexion.Close()
                Exit Sub
            End If

            'cierro el data reader
            drProvincia.Close()

            'limpio parametros
            comando.Parameters.Clear()

            ' Insertar la nueva ciudad
            comando.CommandText = "insert into ciudad (nombre_ciudad, codigo_postal ,id_provincia) values (@nombre_ciudad, @codigo_postal ,@id_provincia)"
            comando.Parameters.AddWithValue("@nombre_ciudad", txtNombreCiudad.Text)
            comando.Parameters.AddWithValue("@codigo_postal", txtCodigoPostal.Text)
            comando.Parameters.AddWithValue("@id_provincia", id_provincia)

            'Variable para obtener respuesta del servidor al ejecutar.
            Dim respuesta As Integer

            'Ejecuto el insert
            respuesta = comando.ExecuteNonQuery()

            MsgBox("La ciudad ha sido agregado con exito!", MsgBoxStyle.Information, "Agregar")

            'cierro conexion
            Conexion.Close()

            'limpio 
            Call LimpiarForms()

            'Actualizo list
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
        txtNombreCiudad.Focus()
        Call HabilitarCampos()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdCiudad.Text = "" Or txtNombreCiudad.Text = "" Or txtCodigoPostal.Text = "" Then
            MsgBox("No se han efectuados cambios para guardar", MsgBoxStyle.Exclamation, "Guardar")
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
            comando.CommandText = "select id_ciudad from ciudad where id_ciudad = @id_ciudad;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_ciudad", txtIdCiudad.Text)

            'Declaro DataReader
            Dim drCiudad As MySqlDataReader

            'Traigo datos de la BD
            drCiudad = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drCiudad.HasRows) Then
                MsgBox("No existe")
            Else

                'Cierro DR
                drCiudad.Close()

                'cargo sql
                comando.CommandText = "select id_provincia from provincia where nombre_provincia = @nombre_provincia"

                'cargo parametros
                comando.Parameters.AddWithValue("@nombre_provincia", cmbProvincia.Text)

                'declaro data reader
                Dim drProvincia As MySqlDataReader

                'Traigo datos de la BD
                drProvincia = comando.ExecuteReader()

                'Si no se encuentran registros imprimo mensaje.
                If drProvincia.Read() Then
                    id_provincia = drProvincia("id_provincia") 'guardo el id
                Else
                    MsgBox("No se encontró la provincia seleccionado.")

                    'cierro el data reader
                    drProvincia.Close()

                    'cierro la conexion
                    Conexion.Close()
                    Exit Sub
                End If

                'cierro datareader
                drProvincia.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "update ciudad set nombre_ciudad=@nombre_ciudad, codigo_postal=@codigo_postal, id_provincia = @id_provincia where id_ciudad = @id_ciudad;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_ciudad", txtIdCiudad.Text)
                comando.Parameters.AddWithValue("@nombre_ciudad", txtNombreCiudad.Text)
                comando.Parameters.AddWithValue("@codigo_postal", txtCodigoPostal.Text)
                comando.Parameters.AddWithValue("@id_provincia", id_provincia)


                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea modificar esta ciudad?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
                    'Declaro variable para guardar la respuesta del servidor
                    Dim respuesta As Integer

                    'Ejecuto la modificacion
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("Los cambios se han guardado exitosamente!", MsgBoxStyle.Information, "Guardar")
                    Call LimpiarForms()
                End If
            End If

            'Cierro conexión
            Conexion.Close()

            'Actualizo el listbox
            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Private Sub ABMCiudades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        Call Conectar()
        Call CargarList(txtBusqueda.Text.ToString)
        Call CargarProvincias()
        Call DeshabilitarCampos()
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdCiudad.Text = "" Then
            MsgBox("Debe seleccionar un pais para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_ciudad from ciudad where id_ciudad = @id_ciudad;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_ciudad", txtIdCiudad.Text)

            'Declaro DataReader
            Dim drCiudad As MySqlDataReader

            'Traigo datos de la BD
            drCiudad = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drCiudad.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drCiudad.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan provincias con este pais

                comando.CommandText = "select id_ciudad from cliente where id_ciudad = @id_ciudad;"


                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_ciudad", txtIdCiudad.Text)

                Dim drPaisProvincia As MySqlDataReader

                drPaisProvincia = comando.ExecuteReader

                If drPaisProvincia.HasRows Then

                    MsgBox("Esta ciudad tiene clientes asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drPaisProvincia.Close()

                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drPaisProvincia.Close()

                comando.Parameters.Clear()


                'Cargo sql
                comando.CommandText = "delete from ciudad where id_ciudad = @id_ciudad;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_ciudad", txtIdCiudad.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea eliminar esta ciudad?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    'Declaro variable para guardar la respuesta del servidor
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("La ciudad ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
                    Call LimpiarForms()
                End If
            End If

            'Cierro conexión
            Conexion.Close()

            'Actualizo el listbox
            Call CargarList(txtBusqueda.Text.ToString)

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Localidades.Show()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdCiudad.Text = "" Then
            MsgBox("Debe seleccionar una ciudad para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        Call HabilitarCampos()
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Call CargarList(txtBusqueda.Text.ToString)
    End Sub
End Class
