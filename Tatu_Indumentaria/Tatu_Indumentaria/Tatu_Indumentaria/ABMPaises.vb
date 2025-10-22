Imports MySql.Data.MySqlClient
Public Class ABMPaises

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdPais.Text = ""
        txtNombrePais.Text = ""
    End Sub

    Sub HabilitarCampos()
        txtIdPais.ReadOnly = True
        txtNombrePais.ReadOnly = False

    End Sub


    Sub DeshabilitarCampos()
        txtIdPais.ReadOnly = True
        txtNombrePais.ReadOnly = True
    End Sub


    Sub CargarList()
        Try
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de pais y los ordeno.
            comando.CommandText = "select nombre_pais from pais order by nombre_pais"

            lstPaises.Items.Clear()

            'Declaro Objeto DataReader
            Dim drPais As MySqlDataReader

            'Traigo datos desde BD
            drPais = comando.ExecuteReader

            'Verifico que haya registros
            If drPais.HasRows Then

                'Recorro el data reader
                Do While drPais.Read
                    'Agrego los nombres de paises a los item del list
                    lstPaises.Items.Add(drPais("nombre_pais"))
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

    Private Sub lstPaises_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPaises.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstPaises.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from pais where nombre_pais = '" & lstPaises.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drPais As MySqlDataReader

            'Traigo datos desde BD
            drPais = comando.ExecuteReader

            'Si encontre coincidencias
            If drPais.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos los paises encontradas
                drPais.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdPais.Text = drPais("id_pais")
                txtNombrePais.Text = drPais("nombre_pais")
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
        If txtNombrePais.Text = "" Then
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
            comando.CommandText = "select id_pais from pais where nombre_pais = @nombre_pais;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_pais", txtNombrePais.Text)

            'declaro dreader
            Dim drPais As MySqlDataReader

            'Traigo datos de la BD
            drPais = comando.ExecuteReader

            'Si hay registros es porque el pais ya existe.
            If drPais.HasRows Then
                MsgBox("No se puede agregar, el pais ya existe!", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drPais.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into pais (nombre_pais) values (@nombre_pais);"
                comando.Parameters.AddWithValue("@nombre_pais", txtNombrePais.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery

                MsgBox("El país ha sido agregado con exito!", MsgBoxStyle.Information, "Agregar")

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
        txtNombrePais.Focus()
        Call HabilitarCampos()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten guardar con campos vacios
        If txtIdPais.Text = "" Or txtNombrePais.Text = "" Then
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
            Comando.CommandText = "select id_pais from pais where id_pais = @id_pais;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_pais", txtIdPais.Text)

            'declaro dreader
            Dim drPais As MySqlDataReader

            'Traigo los datos de la BD
            drPais = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drPais.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro Data Reader
                drPais.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update pais set nombre_pais=@nombre_pais where id_pais = @id_pais;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_pais", txtIdPais.Text)
                Comando.Parameters.AddWithValue("@nombre_pais", txtNombrePais.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Está seguro que desea guardar la modificacion?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo los paises modificados.
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


    Private Sub ABMPaises_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        If txtIdPais.Text = "" Then
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
            comando.CommandText = "select id_pais from pais where id_pais = @id_pais;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_pais", txtIdPais.Text)

            'declaro dreader
            Dim drPais As MySqlDataReader

            'Traigo datos de la BD
            drPais = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drPais.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drPais.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan provincias con este pais

                comando.CommandText = "select id_pais from provincia where id_pais = @id_pais;"


                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_pais", txtIdPais.Text)

                Dim drPaisProvincia As MySqlDataReader

                drPaisProvincia = comando.ExecuteReader

                If drPaisProvincia.HasRows Then

                    MsgBox("Este país tiene provincias asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
                    drPaisProvincia.Close()

                    Conexion.Close()
                    Call LimpiarForms()
                    Exit Sub
                End If

                'Cerramos el DataReader en caso de que no encuentre filas
                drPaisProvincia.Close()

                comando.Parameters.Clear()

                'Cargo sql
                comando.CommandText = "delete from pais where id_pais = @id_pais;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_pais", txtIdPais.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Está seguro que desea eliminar este país?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("El país ha sido eliminado exitosamente", MsgBoxStyle.Information, "Eliminar")
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
        Localidades.Show()
        Me.Close()

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If txtIdPais.Text = "" Then
            MsgBox("Debe seleccionar un pais para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If
        Call HabilitarCampos()
    End Sub
End Class

