Imports MySql.Data.MySqlClient

Public Class ABMProvincias


    Public id_pais As Double


    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdProvincia.Text = ""
        txtNombreProvincia.Text = ""
        cmbPais.SelectedIndex = -1
        btnNuevo.Focus()
    End Sub

    Sub HabilitarCampos()
        txtIdProvincia.ReadOnly = True
        txtNombreProvincia.ReadOnly = False
        cmbPais.Enabled = True
    End Sub


    Sub DeshabilitarCampos()
        txtIdProvincia.ReadOnly = True
        txtNombreProvincia.ReadOnly = True
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

            'Indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de provincia y los ordeno.
            comando.CommandText = "select nombre_provincia from provincia order by nombre_provincia"

            lstProvincias.Items.Clear()

            'Declaro Objeto DataReader
            Dim drProvincia As MySqlDataReader

            'Traigo datos desde BD
            drProvincia = comando.ExecuteReader

            'Verifico que haya registros
            If drProvincia.HasRows Then

                'Recorro el data reader
                Do While drProvincia.Read
                    'Agrego los nombres de provincias a los item del list
                    lstProvincias.Items.Add(drProvincia("nombre_provincia"))
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

    Sub CargarPaises()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'indico el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de pais y los ordeno.
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

    Private Sub lstProvincias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProvincias.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstProvincias.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from provincia where nombre_provincia = '" & lstProvincias.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drProvincia As MySqlDataReader

            'Traigo datos desde BD
            drProvincia = comando.ExecuteReader

            'Si encontre coincidencias
            If drProvincia.HasRows Then

                'Primero limpio forms
                Call LimpiarForms()

                'Leemos las provincias encontradas
                drProvincia.Read()

                'Cargamos txt con los campos del registro seleccionado.
                txtIdProvincia.Text = drProvincia("id_provincia")
                txtNombreProvincia.Text = drProvincia("nombre_provincia")

                'guardo el id 
                id_pais = drProvincia("id_pais")

                'cierro el data reader
                drProvincia.Close()

                'cargo instruccion sql
                comando.CommandText = "select nombre_pais from pais where id_pais = @id_pais"

                'cargo parametros
                comando.Parameters.AddWithValue("@id_pais", id_pais)

                'declaro data reader
                Dim drPais As MySqlDataReader

                'Traigo datos desde BD
                drPais = comando.ExecuteReader()

                'verifico si existen registros
                If drPais.Read() Then
                    cmbPais.SelectedItem = drPais("nombre_pais").ToString() 'obetenemos el valor del item
                End If
                'cierro datareader
                drPais.Close()
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
        If txtNombreProvincia.Text = "" Then
            MsgBox("No se pueden agregar datos vacíos", MsgBoxStyle.Exclamation, "Agregar")
            Exit Sub
        ElseIf cmbPais.Items.Count = 0 Then
            MsgBox("No se puede agregar, debe cargar un país previamente", MsgBoxStyle.Exclamation, "Agregar")
            Exit Sub
        End If
        If cmbPais.SelectedIndex = -1 Then
            MsgBox("No se pueden agregar, elegir un país previamente", MsgBoxStyle.Exclamation, "Agregar")
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
            comando.CommandText = "select id_provincia from provincia where nombre_provincia = @nombre_provincia"
            comando.Parameters.AddWithValue("@nombre_provincia", txtNombreProvincia.Text)


            'declaro dreader
            Dim drProvincia As MySqlDataReader

            'Traigo datos de la BD
            drProvincia = comando.ExecuteReader()

            'Si hay registros es porque la provincia ya existe.
            If drProvincia.HasRows Then
                MsgBox("No se puede agregar, la provincia ya existe", MsgBoxStyle.Exclamation, "Agregar")

                'cierro el data reader
                drProvincia.Close()

                'cierro la conexion
                Conexion.Close()
                Exit Sub
            End If

            'cierro el datareader
            drProvincia.Close()

            'Limpiamos los parametros del comand
            comando.Parameters.Clear()

            ' Obtengo el id del combo box
            comando.CommandText = "select id_pais from pais where nombre_pais = @nombre_pais"
            comando.Parameters.AddWithValue("@nombre_pais", cmbPais.Text)

            'declaro dreader
            Dim drPais As MySqlDataReader

            'Traigo datos de la BD
            drPais = comando.ExecuteReader()

            'Si no se encuentran registros imprimo mensaje.
            If drPais.Read() Then
                id_pais = drPais("id_pais") 'guardo el id 
            Else

                'cierro la conexion
                Conexion.Close()
                Exit Sub
            End If
            'cierro el data reader
            drPais.Close()
            'limpio parametros
            comando.Parameters.Clear()

            ' Insertar la nueva provincia
            comando.CommandText = "insert into provincia (nombre_provincia, id_pais) values (@nombre_provincia, @id_pais)"
            comando.Parameters.AddWithValue("@nombre_provincia", txtNombreProvincia.Text)
            comando.Parameters.AddWithValue("@id_pais", id_pais)

            'Variable para obtener respuesta del servidor al ejecutar.
            Dim respuesta As Integer

            'Ejecuto el insert
            respuesta = comando.ExecuteNonQuery()

            MsgBox("La provincia agregada con exito! ", MsgBoxStyle.Information, "Agregar")

            'cierro conexion
            Conexion.Close()

            'limpio 
            Call LimpiarForms()

            'Actualizo list
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        'Limpio Forms
        Call LimpiarForms()
        Call DeshabilitarCampos()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreProvincia.Focus()
        Call HabilitarCampos()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdProvincia.Text = "" Or txtNombreProvincia.Text = "" Then
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
            comando.CommandText = "select id_provincia from provincia where id_provincia = @id_provincia;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_provincia", txtIdProvincia.Text)

            'Declaro DataReader
            Dim drProvincia As MySqlDataReader

            'Traigo datos de la BD
            drProvincia = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drProvincia.HasRows) Then
                MsgBox("No existe")
            Else

                'Cierro DR
                drProvincia.Close()

                'cargo sql
                comando.CommandText = "select id_pais from pais where nombre_pais = @nombre_pais"

                'cargo parametros
                comando.Parameters.AddWithValue("@nombre_pais", cmbPais.Text)

                'declaro data reader
                Dim drPais As MySqlDataReader

                'Traigo datos de la BD
                drPais = comando.ExecuteReader()

                'Si no se encuentran registros imprimo mensaje.
                If drPais.Read() Then
                    id_pais = drPais("id_pais") 'guardo el id
                Else
                    MsgBox("No se encontró el país seleccionado.")

                    'cierro el data reader
                    drPais.Close()

                    'cierro la conexion
                    Conexion.Close()
                    Exit Sub
                End If

                'cierro datareader
                drPais.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "update provincia set nombre_provincia = @nombre_provincia, id_pais = @id_pais where id_provincia = @id_provincia"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_provincia", txtIdProvincia.Text)
                comando.Parameters.AddWithValue("@nombre_provincia", txtNombreProvincia.Text)
                comando.Parameters.AddWithValue("@id_pais", id_pais)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea guardar la modificacion?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
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
            Call CargarList()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Private Sub ABMProvincias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        Call Conectar()
        Call CargarList()
        Call CargarPaises()
        Call DeshabilitarCampos()
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdProvincia.Text = "" Then
            MsgBox("Debe seleccionar una provincia para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_provincia from provincia where id_provincia = @id_provincia;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_provincia", txtIdProvincia.Text)

            'Declaro DataReader
            Dim drProvincia As MySqlDataReader

            'Traigo datos de la BD
            drProvincia = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drProvincia.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drProvincia.Close()

                comando.Parameters.Clear()
                'verifiquemos que existan provincias con este pais

                comando.CommandText = "select id_provincia from ciudad where id_provincia = @id_provincia;"


                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_provincia", txtIdProvincia.Text)

                Dim drPaisProvincia As MySqlDataReader

                drPaisProvincia = comando.ExecuteReader

                If drPaisProvincia.HasRows Then

                    MsgBox("Esta provincia tiene ciudades asociadas, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drPaisProvincia.Close()

                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drPaisProvincia.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from provincia where id_provincia = @id_provincia;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_provincia", txtIdProvincia.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea eliminar esta provincia?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmar eliminación") = MsgBoxResult.Yes Then
                    'Declaro variable para guardar la respuesta del servidor
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("La provincia ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
                    Call LimpiarForms()
                End If
            End If

            'Cierro conexión
            Conexion.Close()

            'Actualizo el listbox
            Call CargarList()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Localidades.Show()
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdProvincia.Text = "" Then
            MsgBox("Debe seleccionar una provincia para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        Call HabilitarCampos()
    End Sub
End Class