Imports MySql.Data.MySqlClient

Public Class ABMProveedores

    Public PaisElegido As String
    Public ProvinciaElegida As String
    Public CiudadElegida As String
    Public id_ciudad As Integer
    Public id_provincia As Integer
    Public id_pais As Integer
    Public estado As Integer

    Public id_proveedor As Integer

    Sub LimpiarForms()
        txtIdProveedor.Text = ""
        txtNombreProveedor.Text = ""
        txtDescripcionProveedor.Text = ""
        txtDireccionProveedor.Text = ""
        txtTelefonoProveedor.Text = ""
        txtCorreoProveedor.Text = ""
        cmbCiudad.SelectedIndex = -1
        cmbProvincia.SelectedIndex = -1
        cmbPais.SelectedIndex = -1
        cmbCiudad.Items.Clear()
        cmbProvincia.Items.Clear()
        Call DeshabilitarCampos()
    End Sub

    Sub HabilitarCampos()
        txtIdProveedor.ReadOnly = True
        txtNombreProveedor.ReadOnly = False
        txtDescripcionProveedor.ReadOnly = False
        txtDireccionProveedor.ReadOnly = False
        txtTelefonoProveedor.ReadOnly = False
        txtCorreoProveedor.ReadOnly = False
        cmbCiudad.Enabled = True
        cmbProvincia.Enabled = True
        cmbPais.Enabled = True
    End Sub


    Sub DeshabilitarCampos()
        txtIdProveedor.ReadOnly = True
        txtNombreProveedor.ReadOnly = True
        txtDescripcionProveedor.ReadOnly = True
        txtDireccionProveedor.ReadOnly = True
        txtTelefonoProveedor.ReadOnly = True
        txtCorreoProveedor.ReadOnly = True
        cmbCiudad.Enabled = False
        cmbProvincia.Enabled = False
        cmbPais.Enabled = False
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

            'Sql muestro nombre del proveedor filtro por estado activo y los ordeno.
            comando.CommandText = "select nombre_proveedor from proveedor where estado = '" & 1 & "' order by nombre_proveedor"

            'Declaro Objeto DataReader
            Dim drProveedor As MySqlDataReader

            'Traigo datos desde BD
            drProveedor = comando.ExecuteReader

            'Verifico que haya registros
            If drProveedor.HasRows Then
                'si encuentra registros limpio el list.
                lstProveedores.Items.Clear()

                'Recorro el data reader
                Do While drProveedor.Read
                    'Agrego los nombres de proveedores a los item del list
                    lstProveedores.Items.Add(drProveedor("nombre_proveedor"))
                Loop
            End If
            'Cierro Data reader
            drProveedor.Close()

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

            'Declaro objeto comand
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


    Private Sub ABMProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        Call CargarList()
        Call DeshabilitarCampos()
        
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
        txtNombreProveedor.Focus()
    End Sub

    Private Sub lstProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProveedores.SelectedIndexChanged
        Call DeshabilitarCampos()
        'Evito un error al hacer click donde no tenga items el list.
        If lstProveedores.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from proveedor where nombre_proveedor = '" & lstProveedores.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drProveedor As MySqlDataReader

            'Traigo datos desde BD
            drProveedor = comando.ExecuteReader

            'Si encontre coincidencias
            If drProveedor.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos los proveedores encontrados
                drProveedor.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdProveedor.Text = drProveedor("id_proveedor")
                txtNombreProveedor.Text = drProveedor("nombre_proveedor")
                txtDescripcionProveedor.Text = drProveedor("descripcion_proveedor")
                txtDireccionProveedor.Text = drProveedor("direccion_proveedor")
                txtTelefonoProveedor.Text = drProveedor("telefono")
                txtCorreoProveedor.Text = drProveedor("email")


                id_ciudad = drProveedor("id_ciudad")


                drProveedor.Close()

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

                'Declaro obejto data reader
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

    Private Sub btnInactivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivo.Click
        'Verifico que haya algo seleccionado para dejar inactivo
        If txtIdProveedor.Text = "" Then
            MsgBox("Debe seleccionar un proveedor para dejar inactivo", MsgBoxStyle.Exclamation, "Inactivar")
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
            comando.CommandText = "select id_proveedor from proveedor where id_proveedor = @id_proveedor;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_proveedor", txtIdProveedor.Text)

            'declaro dreader
            Dim drProveedor As MySqlDataReader

            'Traigo datos de la BD
            drProveedor = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drProveedor.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drProveedor.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "update proveedor set estado = @estado where id_proveedor = @id_proveedor;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_proveedor", txtIdProveedor.Text)
                comando.Parameters.AddWithValue("@estado", 0)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea dejar inactivo a este proveedor?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "¿Seguro de dejar inactivo?") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El Proveedor ha sido dejado inactivo exitosamente", MsgBoxStyle.Information, "Inactivar")
                    Call LimpiarForms()
                End If

            End If

            'Cierro conexion
            Conexion.Close()

            lstProveedores.Items.Clear()

            'Actualizo listbox
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtNombreProveedor.Text = "" Then
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
            Comando.CommandText = "select id_proveedor from proveedor where id_proveedor = @id_proveedor;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_proveedor", txtIdProveedor.Text)

            'declaro dreader
            Dim drProveedor As MySqlDataReader

            'Traigo los datos de la BD
            drProveedor = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drProveedor.HasRows) Then
                MsgBox("No se encontraron proveedores para editar", MsgBoxStyle.Exclamation, "Editar")
                drProveedor.Close()
                Conexion.Close()
                Exit Sub
            Else
                'Cierro Data Reader
                drProveedor.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update proveedor set nombre_proveedor=@nombre_proveedor,descripcion_proveedor=@descripcion_proveedor,direccion_proveedor=@direccion_proveedor,telefono=@telefono,email=@email,id_ciudad=(select id_ciudad from ciudad where nombre_ciudad = '" & CiudadElegida & "') where id_proveedor=@id_proveedor;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_proveedor", txtIdProveedor.Text)
                Comando.Parameters.AddWithValue("@nombre_proveedor", txtNombreProveedor.Text)
                Comando.Parameters.AddWithValue("@descripcion_proveedor", txtDescripcionProveedor.Text)
                Comando.Parameters.AddWithValue("@direccion_proveedor", txtDireccionProveedor.Text)
                Comando.Parameters.AddWithValue("@telefono", txtTelefonoProveedor.Text)
                Comando.Parameters.AddWithValue("@email", txtCorreoProveedor.Text)


                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las categorias modificadas.
                    MsgBox("Se guardaron los cambios  del proveedor exitosamente", MsgBoxStyle.Information, "Guardar")
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
        If txtNombreProveedor.Text = "" Or txtDireccionProveedor.Text = "" Or txtTelefonoProveedor.Text = "" Or cmbCiudad.SelectedIndex = -1 Then
            MsgBox("Rellenar campos Obligatorios")
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
            comando.CommandText = "select nombre_proveedor,estado from proveedor where nombre_proveedor = @nombre_proveedor;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_proveedor", txtNombreProveedor.Text)


            'declaro dreader
            Dim drProveedor As MySqlDataReader

            'Traigo datos de la BD
            drProveedor = comando.ExecuteReader

            'Si hay registros es porque el proveedor ya existe.
            If drProveedor.HasRows Then

                drProveedor.Read()

                estado = drProveedor("estado")

                If estado Then
                    MsgBox("El proveedor ya existe, no se puede volver a agregar", MsgBoxStyle.Information, "Agregar")
                ElseIf Not estado Then
                    If MsgBox("El proveedor ya fue cargado antes, ¿desea activarlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Agregar") = MsgBoxResult.Yes Then
                        ' Acción simple si responde Sí
                        drProveedor.Close()
                        comando.Parameters.Clear()

                        comando.CommandText = "update proveedor  set estado = @estado where nombre_proveedor = @nombre_proveedor;"
                        comando.Parameters.AddWithValue("@nombre_proveedor", txtNombreProveedor.Text)
                        comando.Parameters.AddWithValue("@estado", 1)
                        MsgBox("Proveedor Activado con éxito", MsgBoxStyle.Information, "Agregar")
                        Call LimpiarForms()
                    End If

                    comando.ExecuteNonQuery()
                End If
            Else
                'cierro el data reader
                drProveedor.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into proveedor (nombre_proveedor,descripcion_proveedor,direccion_proveedor,telefono,email,estado,id_ciudad) values (@nombre_proveedor,@descripcion_proveedor,@direccion_proveedor,@telefono,@email,@estado,(select id_ciudad from ciudad where nombre_ciudad = '" & CiudadElegida & "'));"



                comando.Parameters.AddWithValue("@nombre_proveedor", txtNombreProveedor.Text)
                comando.Parameters.AddWithValue("@descripcion_proveedor", txtDescripcionProveedor.Text)
                comando.Parameters.AddWithValue("@direccion_proveedor", txtDireccionProveedor.Text)
                comando.Parameters.AddWithValue("@telefono", txtTelefonoProveedor.Text)
                comando.Parameters.AddWithValue("@email", txtCorreoProveedor.Text)
                comando.Parameters.AddWithValue("@estado", 1)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("Se agrego el proveedor exitosamente", MsgBoxStyle.Information, "Agregar")

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
        If txtIdProveedor.Text = "" Then
            MsgBox("Seleccinar un proveedor para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If

        Call HabilitarCampos()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        PantallaPrincipal.Show()
    End Sub

    Private Sub btnGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrilla.Click
        Me.Close()
        frmGrillaProveedores.Show()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Call LimpiarForms()
    End Sub
End Class