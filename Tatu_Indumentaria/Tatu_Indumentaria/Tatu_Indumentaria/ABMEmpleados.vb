Imports MySql.Data.MySqlClient

Public Class ABMEmpleados


    Public PaisElegido As String
    Public ProvinciaElegida As String
    Public CiudadElegida As String
    Public id_ciudad As Integer
    Public id_provincia As Integer
    Public id_pais As Integer
    Public estado As Integer

    Public id_empleado As Integer

    Sub LimpiarForms()
        txtIdEmpleado.Text = ""
        txtNombreEmpleado.Text = ""
        txtApellidoEmpleado.Text = ""
        txtDniEmpleado.Text = ""
        txtDireccionEmpleado.Text = ""
        txtTelefonoEmpleado.Text = ""
        txtCorreoEmpleado.Text = ""
        cmbGenero.SelectedIndex = -1
        cmbCiudad.SelectedIndex = -1
        cmbProvincia.SelectedIndex = -1
        cmbPais.SelectedIndex = -1
        cmbCiudad.Items.Clear()
        cmbProvincia.Items.Clear()
        Call DeshabilitarCampos()
    End Sub

    Sub HabilitarCampos()
        txtIdEmpleado.ReadOnly = True
        txtDniEmpleado.ReadOnly = False
        txtNombreEmpleado.ReadOnly = False
        txtApellidoEmpleado.ReadOnly = False
        txtDireccionEmpleado.ReadOnly = False
        txtTelefonoEmpleado.ReadOnly = False
        txtCorreoEmpleado.ReadOnly = False
        cmbGenero.Enabled = True
        cmbCiudad.Enabled = True
        cmbProvincia.Enabled = True
        cmbPais.Enabled = True
    End Sub


    Sub DeshabilitarCampos()
        txtIdEmpleado.ReadOnly = True
        txtDniEmpleado.ReadOnly = True
        txtNombreEmpleado.ReadOnly = True
        txtApellidoEmpleado.ReadOnly = True
        txtDireccionEmpleado.ReadOnly = True
        txtTelefonoEmpleado.ReadOnly = True
        txtCorreoEmpleado.ReadOnly = True
        cmbGenero.Enabled = False
        cmbCiudad.Enabled = False
        cmbProvincia.Enabled = False
        cmbPais.Enabled = False
    End Sub



    Sub CargarList()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de empleado filtro por estado activo y los ordeno.
            comando.CommandText = "select nombre,apellido from empleado where estado = '" & 1 & "' order by CONCAT(nombre, ' ', apellido)"

            'Declaro Objeto DataReader
            Dim drEmpleado As MySqlDataReader

            'Traigo datos desde BD
            drEmpleado = comando.ExecuteReader

            'Verifico que haya registros
            If drEmpleado.HasRows Then
                'si encuentra registros limpio el list.
                lstEmpleados.Items.Clear()

                'Recorro el data reader
                Do While drEmpleado.Read
                    'Agrego los nombres de empleados a los item del list
                    lstEmpleados.Items.Add(drEmpleado("nombre") + " " + drEmpleado("apellido"))
                Loop
            End If
            'Cierro Data reader
            drEmpleado.Close()

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

    Private Sub ABMEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        Call CargarList()
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
        txtNombreEmpleado.Focus()
    End Sub

    Private Sub lstEmpleados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEmpleados.SelectedIndexChanged
        Call DeshabilitarCampos()
        'Evito un error al hacer click donde no tenga items el list.
        If lstEmpleados.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from empleado where CONCAT(nombre, ' ', apellido) = @NombreYApellido ;"
            comando.Parameters.AddWithValue("@NombreYApellido", lstEmpleados.SelectedItem.ToString)

            'Declaro objeto data reader
            Dim drEmpleado As MySqlDataReader

            'Traigo datos desde BD
            drEmpleado = comando.ExecuteReader

            'Si encontre coincidencias
            If drEmpleado.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos los empleados encontrados
                drEmpleado.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdEmpleado.Text = drEmpleado("id_empleado")
                txtDniEmpleado.Text = drEmpleado("dni")
                txtNombreEmpleado.Text = drEmpleado("nombre")
                txtApellidoEmpleado.Text = drEmpleado("apellido")
                txtDireccionEmpleado.Text = drEmpleado("direccion")
                txtTelefonoEmpleado.Text = drEmpleado("telefono")
                txtCorreoEmpleado.Text = drEmpleado("email")
                cmbGenero.SelectedItem = drEmpleado("genero")

                id_ciudad = drEmpleado("id_ciudad")

                If Not (IsDBNull(drEmpleado("fecha_nacimiento"))) Then
                    dtpFechaNac.Value = drEmpleado("fecha_nacimiento")
                Else
                    MsgBox("No tiene fecha nacimiento, se actualiza a la de hoy")
                    dtpFechaNac.Value = Now
                End If

                drEmpleado.Close()

                comando.Parameters.Clear()

                comando.CommandText = "select * from ciudad where id_ciudad = @id_ciudad;"
                comando.Parameters.AddWithValue("@id_ciudad", id_ciudad)

                'Declaro objeto data reader
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
                drProvincia.Close()


            Else
                Call LimpiarForms()
            End If
            'Cierro conexion
            Conexion.Close()


            cmbPais.Items.Clear()

            cmbPais.Items.Add(PaisElegido)
            cmbPais.SelectedItem = (PaisElegido)
            cmbProvincia.SelectedItem = (ProvinciaElegida).ToString
            cmbCiudad.SelectedItem = (CiudadElegida).ToString

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        PantallaPrincipal.Show()
    End Sub

    Private Sub btnGrillaEmpleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrillaEmpleados.Click
        Me.Close()
        frmGrillaEmpleados.Show()
    End Sub

    Private Sub btnInactivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivo.Click
        'Verifico que haya algo seleccionado para dejar inactivo
        If txtIdEmpleado.Text = "" Then
            MsgBox("Debe seleccionar un empleado para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_empleado from empleado where id_empleado = @id_empleado;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_empleado", txtIdEmpleado.Text)

            'declaro dreader
            Dim drEmpleado As MySqlDataReader

            'Traigo datos de la BD
            drEmpleado = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drEmpleado.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drEmpleado.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "update empleado set estado = @estado where id_empleado = @id_empleado;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_empleado", txtIdEmpleado.Text)
                comando.Parameters.AddWithValue("@estado", 0)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar a este empleado?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "¿Seguro de eliminar?") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El empleado ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
                    Call LimpiarForms()
                End If

            End If

            'Cierro conexion
            Conexion.Close()

            lstEmpleados.Items.Clear()

            'Actualizo listbox
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtDniEmpleado.Text = "" Then
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
            Comando.CommandText = "select id_empleado from empleado where id_empleado = @id_empleado;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_empleado", txtIdEmpleado.Text)

            'declaro dreader
            Dim drEmpleado As MySqlDataReader

            'Traigo los datos de la BD
            drEmpleado = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drEmpleado.HasRows) Then
                MsgBox("No se encontraron empleados para editar", MsgBoxStyle.Exclamation, "Editar")
                drEmpleado.Close()
                Conexion.Close()
                Exit Sub
            Else
                'Cierro Data Reader
                drEmpleado.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update empleado set dni=@dni,nombre=@nombre,apellido=@apellido,direccion=@direccion,fecha_nacimiento=@fecha_nacimiento,telefono=@telefono,email=@email,genero=@genero,id_ciudad=(select id_ciudad from ciudad where nombre_ciudad = '" & CiudadElegida & "') where id_empleado=@id_empleado;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_empleado", txtIdEmpleado.Text)
                Comando.Parameters.AddWithValue("@dni", txtDniEmpleado.Text)
                Comando.Parameters.AddWithValue("@nombre", txtNombreEmpleado.Text)
                Comando.Parameters.AddWithValue("@apellido", txtApellidoEmpleado.Text)
                Comando.Parameters.AddWithValue("@direccion", txtDireccionEmpleado.Text)
                Comando.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.ToString("yyyy-MM-dd"))
                Comando.Parameters.AddWithValue("@telefono", txtTelefonoEmpleado.Text)
                Comando.Parameters.AddWithValue("@email", txtCorreoEmpleado.Text)
                Comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString)


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


            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtNombreEmpleado.Text = "" Or txtApellidoEmpleado.Text = "" Or txtDniEmpleado.Text = "" Or cmbCiudad.SelectedIndex = -1 Then
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
            comando.CommandText = "select dni,estado from empleado where dni = @dni;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@dni", txtDniEmpleado.Text)


            'declaro dreader
            Dim drEmpleado As MySqlDataReader

            'Traigo datos de la BD
            drEmpleado = comando.ExecuteReader

            'Si hay registros es porque el empleado ya existe.
            If drEmpleado.HasRows Then

                drEmpleado.Read()

                estado = drEmpleado("estado")

                If estado Then
                    MsgBox("El empleado ya existe, no se puede volver a agregar", MsgBoxStyle.Information, "Agregar")
                ElseIf Not estado Then
                    If MsgBox("El empleado ya fue cargado antes, ¿desea activarlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Agregar") = MsgBoxResult.Yes Then
                        ' Acción simple si responde Sí
                        drEmpleado.Close()
                        comando.Parameters.Clear()

                        comando.CommandText = "update empleado  set estado = @estado where dni = @dni;"
                        comando.Parameters.AddWithValue("@dni", txtDniEmpleado.Text)
                        comando.Parameters.AddWithValue("@estado", 1)
                        MsgBox("Empleado Activado con éxito", MsgBoxStyle.Information, "Agregar")
                        Call LimpiarForms()
                    End If

                    comando.ExecuteNonQuery()
                End If
            Else
                'cierro el data reader
                drEmpleado.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into empleado (dni,nombre,apellido,direccion,fecha_nacimiento,telefono,email,genero,estado,id_ciudad) values (@dni,@nombre,@apellido,@direccion,@fecha_nacimiento,@telefono,@email,@genero,@estado,(select id_ciudad from ciudad where nombre_ciudad = '" & CiudadElegida & "'));"


                comando.Parameters.AddWithValue("@dni", txtDniEmpleado.Text)
                comando.Parameters.AddWithValue("@nombre", txtNombreEmpleado.Text)
                comando.Parameters.AddWithValue("@apellido", txtApellidoEmpleado.Text)
                comando.Parameters.AddWithValue("@direccion", txtDireccionEmpleado.Text)
                comando.Parameters.AddWithValue("@telefono", txtTelefonoEmpleado.Text)
                comando.Parameters.AddWithValue("@email", txtCorreoEmpleado.Text)
                comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString)
                comando.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.ToString("yyyy-MM-dd"))
                comando.Parameters.AddWithValue("@estado", 1)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego al empleado exitosamente", MsgBoxStyle.Information, "Agregar")

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
        If txtIdEmpleado.Text = "" Then
            MsgBox("Seleccinar un empleado para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If

        Call HabilitarCampos()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub

    Private Sub chkDni_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDni.CheckedChanged
        If chkDni.Checked Then
            chkNombre.Checked = False
        Else
            chkDni.Checked = False
        End If
    End Sub

    Private Sub chkNombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNombre.CheckedChanged
        If chkNombre.Checked Then
            chkDni.Checked = False
        Else
            chkNombre.Checked = False
        End If
    End Sub
End Class