Imports MySql.Data.MySqlClient

Public Class ABMClientes

    Public PaisElegido As String
    Public ProvinciaElegida As String
    Public CiudadElegida As String
    Public id_ciudad As Integer
    Public id_provincia As Integer
    Public id_pais As Integer
    Public estado As Integer
    Public bandera As Boolean = False

    Public id_cliente As Integer

    Sub LimpiarForms()
        txtIdCliente.Text = ""
        txtNombreCliente.Text = ""
        txtApellidoCliente.Text = ""
        txtDniCliente.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtBusqueda.Text = ""
        cmbGenero.SelectedIndex = -1
        cmbCiudad.SelectedIndex = -1
        cmbProvincia.SelectedIndex = -1
        cmbPais.SelectedIndex = -1
        cmbCiudad.Items.Clear()
        cmbProvincia.Items.Clear()
        Call DeshabilitarCampos()
    End Sub

    Sub HabilitarCampos()
        txtIdCliente.ReadOnly = True
        txtDniCliente.ReadOnly = False
        txtNombreCliente.ReadOnly = False
        txtApellidoCliente.ReadOnly = False
        txtDireccion.ReadOnly = False
        txtTelefono.ReadOnly = False
        txtCorreo.ReadOnly = False
        cmbGenero.Enabled = True
        cmbCiudad.Enabled = True
        cmbProvincia.Enabled = True
        cmbPais.Enabled = True
    End Sub


    Sub DeshabilitarCampos()
        txtIdCliente.ReadOnly = True
        txtDniCliente.ReadOnly = True
        txtNombreCliente.ReadOnly = True
        txtApellidoCliente.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtCorreo.ReadOnly = True
        cmbGenero.Enabled = False
        cmbCiudad.Enabled = False
        cmbProvincia.Enabled = False
        cmbPais.Enabled = False
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

            If dato = "" Then
                'Sql muestro nombre de cliente filtro por estado activo y los ordeno.
                comando.CommandText = "select nombre,apellido from cliente where estado = '" & 1 & "' order by CONCAT(nombre, ' ', apellido);"

            ElseIf dato <> "" And chkDni.Checked Then
                comando.CommandText = "select nombre,apellido from cliente where estado = '" & 1 & "' and dni like '" & dato & "%' order by CONCAT(nombre, ' ', apellido);"

            ElseIf dato <> "" And chkNombre.Checked Then
                comando.CommandText = "select nombre,apellido from cliente where estado = '" & 1 & "' and nombre like '" & dato & "%' order by CONCAT(nombre, ' ', apellido);"

            Else
                Conexion.Close()
                Exit Sub
            End If

            'Declaro Objeto DataReader
            Dim drCliente As MySqlDataReader

            'Traigo datos desde BD
            drCliente = comando.ExecuteReader

            'Verifico que haya registros
            If drCliente.HasRows Then
                'si encuentra registros limpio el list.
                lstClientes.Items.Clear()

                'Recorro el data reader
                Do While drCliente.Read
                    'Agrego los nombres de clientes a los item del list
                    lstClientes.Items.Add(drCliente("nombre") + " " + drCliente("apellido"))
                Loop
            End If
            'Cierro Data reader
            drCliente.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub


    Sub CargarPaises()
        Try
            cmbPais.Items.Clear()
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de categoria y los ordeno.
            comando.CommandText = "select nombre_pais from pais order by nombre_pais "

            'Declaro Objeto DataReader
            Dim drPais As MySqlDataReader

            'Traigo datos desde BD
            drPais = comando.ExecuteReader

            'Verifico que haya registros
            If drPais.HasRows Then


                'Recorro el data reader
                Do While drPais.Read
                    'Agrego los nombres de categoria a los item del list
                    cmbPais.Items.Add(drPais("nombre_pais"))
                Loop
            End If
            'Cierro Data reader
            drPais.Close()

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

            cmbProvincia.Items.Clear()
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de categoria y los ordeno.
            comando.CommandText = "select nombre_provincia from provincia join pais on provincia.id_pais = pais.id_pais where nombre_pais = '" & PaisElegido & "';"




            'Declaro Objeto DataReader
            Dim drProvincia As MySqlDataReader

            'Traigo datos desde BD
            drProvincia = comando.ExecuteReader


            'Verifico que haya registros
            If drProvincia.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drProvincia.Read
                    'Agrego los nombres de categoria a los item del list
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


    Sub CargarCiudad()
        Try

            cmbCiudad.Items.Clear()
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de categoria y los ordeno.
            comando.CommandText = "select nombre_ciudad from ciudad join provincia on ciudad.id_provincia = provincia.id_provincia where nombre_provincia = '" & ProvinciaElegida & "';"




            'Declaro Objeto DataReader
            Dim drCiudad As MySqlDataReader

            'Traigo datos desde BD
            drCiudad = comando.ExecuteReader


            'Verifico que haya registros
            If drCiudad.HasRows Then
                'si encuentra registros limpio el list.

                'Recorro el data reader
                Do While drCiudad.Read
                    'Agrego los nombres de categoria a los item del list
                    cmbCiudad.Items.Add(drCiudad("nombre_ciudad"))
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


    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        Call CargarList(txtBusqueda.Text.ToString)
        Call DeshabilitarCampos()
        cmbGenero.SelectedIndex = -1
        cmbGenero.Items.Add("Masculino")
        cmbGenero.Items.Add("Femenino")

        If Login.rol = "administrador" Then
            btnInactivo.Visible = False
        End If

   
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedIndexChanged

        cmbProvincia.SelectedIndex = -1

        If cmbPais.SelectedIndex < 0 Then
            Exit Sub
        End If
        PaisElegido = cmbPais.SelectedItem.ToString()
        Call CargarProvincias()
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        cmbCiudad.SelectedIndex = -1
        If cmbProvincia.SelectedIndex < 0 Then
            Exit Sub
        End If
        ProvinciaElegida = cmbProvincia.SelectedItem.ToString()
        Call CargarCiudad()
    End Sub
    Private Sub cmbCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCiudad.SelectedIndexChanged
        If cmbCiudad.SelectedIndex < 0 Then
            Exit Sub
        End If
        CiudadElegida = cmbCiudad.SelectedItem.ToString()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Call LimpiarForms()
        Call HabilitarCampos()
        Call CargarPaises()
        txtNombreCliente.Focus()
    End Sub

    Private Sub lstClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstClientes.SelectedIndexChanged
        chkDni.Checked = False
        chkNombre.Checked = False

        Call DeshabilitarCampos()
        'Evito un error al hacer click donde no tenga items el list.
        If lstClientes.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from cliente WHERE CONCAT(nombre, ' ', apellido) = @NombreYApellido ;"
            comando.Parameters.AddWithValue("@NombreYApellido", lstClientes.SelectedItem.ToString)

            'Declaro obejto data reade
            Dim drCliente As MySqlDataReader

            'Traigo datos desde BD
            drCliente = comando.ExecuteReader

            'Si encontre coincidencias
            If drCliente.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las categorias encontradas
                drCliente.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdCliente.Text = drCliente("id_cliente")
                txtDniCliente.Text = drCliente("dni")
                txtNombreCliente.Text = drCliente("nombre")
                txtApellidoCliente.Text = drCliente("apellido")
                txtDireccion.Text = drCliente("direccion")
                txtTelefono.Text = drCliente("telefono")
                txtCorreo.Text = drCliente("email")
                cmbGenero.SelectedItem = drCliente("genero")

                id_ciudad = drCliente("id_ciudad")

                If Not (IsDBNull(drCliente("fecha_nacimiento"))) Then
                    dtpFechaNac.Value = drCliente("fecha_nacimiento")
                Else
                    MsgBox("No tiene fecha nacimiento, se actualiza a la de hoy")
                    dtpFechaNac.Value = Now
                End If

                drCliente.Close()

                comando.Parameters.Clear()

                comando.CommandText = "select * from ciudad where id_ciudad = @id_ciudad;"
                comando.Parameters.AddWithValue("@id_ciudad", id_ciudad)

                'Declaro obejto data reade
                Dim drCiudad As MySqlDataReader

                'Traigo datos desde BD
                drCiudad = comando.ExecuteReader()


                'Si encontre coincidencias
                If drCiudad.HasRows Then
                    drCiudad.Read()
                    id_provincia = drCiudad("id_provincia")
                    CiudadElegida = drCiudad("nombre_ciudad")
                End If
                drCiudad.Close()


                comando.Parameters.Clear()

                comando.CommandText = "select * from provincia where id_provincia = @id_provincia;"
                comando.Parameters.AddWithValue("@id_provincia", id_provincia)

                'Declaro obejto data reade
                Dim drProvincia As MySqlDataReader

                'Traigo datos desde BD
                drProvincia = comando.ExecuteReader()


                'Si encontre coincidencias
                If drProvincia.HasRows Then
                    drProvincia.Read()
                    id_pais = drProvincia("id_pais")
                    ProvinciaElegida = drProvincia("nombre_provincia")
                End If
                drProvincia.Close()


                comando.Parameters.Clear()

                comando.CommandText = "select nombre_pais from pais where id_pais = @id_pais;"
                comando.Parameters.AddWithValue("@id_pais", id_pais)

                'Declaro obejto data reade
                Dim drPais As MySqlDataReader

                'Traigo datos desde BD
                drPais = comando.ExecuteReader()


                'Si encontre coincidencias
                If drPais.HasRows Then
                    drPais.Read()
                    PaisElegido = drPais("nombre_pais")
                End If
                drPais.Close()


            Else
                Call LimpiarForms()
                drCliente.Close()
            End If
            'Cierro conexion
            Conexion.Close()


            cmbPais.Items.Clear()

            cmbPais.Items.Add(PaisElegido)
            cmbPais.SelectedItem = (PaisElegido)
            cmbProvincia.SelectedItem = (ProvinciaElegida).ToString
            cmbCiudad.SelectedItem = (CiudadElegida).ToString
            Call CargarList(txtBusqueda.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click, btnImprimir.Click
        Me.Close()
        PantallaPrincipal.Show()
    End Sub

    Private Sub btnInactivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivo.Click
        'Verifico que haya algo seleccionado para dejar inactivo
        If txtIdCliente.Text = "" Then
            MsgBox("Debe seleccionar un cliente para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_cliente from cliente where id_cliente = @id_cliente;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text)

            'declaro dreader
            Dim drCliente As MySqlDataReader

            'Traigo datos de la BD
            drCliente = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drCliente.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drCliente.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "update cliente set estado = @estado where id_cliente = @id_cliente;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text)
                comando.Parameters.AddWithValue("@estado", 0)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar a este cliente?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "¿Seguro de  eliminar?") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El cliente ha sido eliminado exitosamente", MsgBoxStyle.Information, "Inactivar")
                    Call LimpiarForms()
                End If

            End If

            'Cierro conexion
            Conexion.Close()

            lstClientes.Items.Clear()

            'Actualizo listbox
            Call CargarList(txtBusqueda.Text.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtDniCliente.Text = "" Then
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
            Comando.CommandText = "select id_cliente from cliente where id_cliente = @id_cliente;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text)

            'declaro dreader
            Dim drCliente As MySqlDataReader

            'Traigo los datos de la BD
            drCliente = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drCliente.HasRows) Then
                MsgBox("No se encontraron clientes para editar", MsgBoxStyle.Exclamation, "Editar")
                drCliente.Close()
                Conexion.Close()
                Exit Sub
            Else
                'Cierro Data Reader
                drCliente.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update cliente set dni=@dni,nombre=@nombre,apellido=@apellido,direccion=@direccion,fecha_nacimiento=@fecha_nacimiento,telefono=@telefono,email=@email,genero=@genero,id_ciudad=(select id_ciudad from ciudad where nombre_ciudad = '" & CiudadElegida & "') where id_cliente=@id_cliente;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text)
                Comando.Parameters.AddWithValue("@dni", txtDniCliente.Text)
                Comando.Parameters.AddWithValue("@nombre", txtNombreCliente.Text)
                Comando.Parameters.AddWithValue("@apellido", txtApellidoCliente.Text)
                Comando.Parameters.AddWithValue("@direccion", txtDireccion.Text)
                Comando.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.ToString("yyyy-MM-dd"))
                Comando.Parameters.AddWithValue("@telefono", txtTelefono.Text)
                Comando.Parameters.AddWithValue("@email", txtCorreo.Text)
                Comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString)


                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las categorias modificadas.
                    MsgBox("Se guardaron los cambios  del cliente exitosamente", MsgBoxStyle.Information, "Guardar")
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
        If txtNombreCliente.Text = "" Or txtApellidoCliente.Text = "" Or txtDniCliente.Text = "" Or cmbCiudad.SelectedIndex = -1 Then
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
            comando.CommandText = "select dni,estado from cliente where dni = @dni;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@dni", txtDniCliente.Text)


            'declaro dreader
            Dim drCliente As MySqlDataReader

            'Traigo datos de la BD
            drCliente = comando.ExecuteReader

            'Si hay registros es porque la categoria ya existe.
            If drCliente.HasRows Then

                drCliente.Read()

                estado = drCliente("estado")

                If estado Then
                    MsgBox("El cliente ya existe, no se puede volver a agregar", MsgBoxStyle.Information, "Agregar")

                ElseIf Not estado Then
                    If MsgBox("El cliente ya fue cargado antes, ¿desea activarlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Agregar") = MsgBoxResult.Yes Then
                        ' Acción simple si responde Sí
                        drCliente.Close()
                        comando.Parameters.Clear()

                        comando.CommandText = "update cliente  set estado = @estado where dni = @dni;"
                        comando.Parameters.AddWithValue("@dni", txtDniCliente.Text)
                        comando.Parameters.AddWithValue("@estado", 1)
                        MsgBox("Cliente Activado con éxito", MsgBoxStyle.Information, "Agregar")
                        Call LimpiarForms()
                    End If

                    comando.ExecuteNonQuery()
                End If
                drCliente.Close()
            Else
                'cierro el data reader
                drCliente.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into cliente (dni,nombre,apellido,direccion,fecha_nacimiento,telefono,email,genero,estado,id_ciudad) values (@dni,@nombre,@apellido,@direccion,@fecha_nacimiento,@telefono,@email,@genero,@estado,(select id_ciudad from ciudad where nombre_ciudad = '" & CiudadElegida & "'));"


                comando.Parameters.AddWithValue("@dni", txtDniCliente.Text)
                comando.Parameters.AddWithValue("@nombre", txtNombreCliente.Text)
                comando.Parameters.AddWithValue("@apellido", txtApellidoCliente.Text)
                comando.Parameters.AddWithValue("@direccion", txtDireccion.Text)
                comando.Parameters.AddWithValue("@telefono", txtTelefono.Text)
                comando.Parameters.AddWithValue("@email", txtCorreo.Text)
                comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString)
                comando.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.ToString("yyyy-MM-dd"))
                comando.Parameters.AddWithValue("@estado", 1)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el cliente exitosamente", MsgBoxStyle.Information, "Agregar")

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
        If txtIdCliente.Text = "" Then
            MsgBox("Seleccinar un cliente para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If

        Call HabilitarCampos()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub



    Private Sub chkDni_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDni.CheckedChanged
        Call LimpiarForms()
        If chkDni.Checked Then
            chkNombre.Checked = False
        Else
            chkDni.Checked = False
        End If

    End Sub

    Private Sub chkNombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNombre.CheckedChanged
        Call LimpiarForms()
        If chkNombre.Checked Then
            chkDni.Checked = False
        Else
            chkNombre.Checked = False
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
            If chkDni.Checked = False And chkNombre.Checked = False Then
                Exit Sub
            End If
            Call CargarList(txtBusqueda.Text.ToString)
    End Sub
End Class