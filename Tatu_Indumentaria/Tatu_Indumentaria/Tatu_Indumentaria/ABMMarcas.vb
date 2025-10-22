Imports MySql.Data.MySqlClient

Public Class ABMMarcas

    'Subrutina para limpiar los formularios
    Sub LimpiarForms()
        txtIdMarca.Text = ""
        txtNombreMarca.Text = ""
        txtNombreMarca.ReadOnly = True
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

            'Sql muestro nombre de marca y los ordeno.
            comando.CommandText = "select nombre_marca from marca order by nombre_marca;"

            'Declaro Objeto DataReader
            Dim drMarca As MySqlDataReader

            'Traigo datos desde BD
            drMarca = comando.ExecuteReader


            lstMarcas.Items.Clear()

            'Verifico que haya registros
            If drMarca.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drMarca.Read
                    'Agrego los nombres de marca a los item del list
                    lstMarcas.Items.Add(drMarca("nombre_marca"))
                Loop
            End If
            'Cierro Data reader
            drMarca.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try

    End Sub

    Private Sub lstMarcas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMarcas.SelectedIndexChanged
        Try
            'Evito un error al hacer click donde no tenga items el list.
            If lstMarcas.SelectedItem Is Nothing Then
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
            comando.CommandText = "select * from marca where nombre_marca = '" & lstMarcas.SelectedItem.ToString & "';"

            'Declaro objeto data reader
            Dim drMarca As MySqlDataReader

            'Traigo datos desde BD
            drMarca = comando.ExecuteReader

            'Si encontre coincidencias
            If drMarca.HasRows Then
                'Primero limpio forms
                Call LimpiarForms()
                'Leemos las marcas encontradas
                drMarca.Read()
                'Cargamos txt con los campos del registro seleccionado.
                txtIdMarca.Text = drMarca("id_marca")
                txtNombreMarca.Text = drMarca("nombre_marca")
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

    Private Sub ABMMarcas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hago foco en nuevo.
        btnNuevo.Focus()
        txtNombreMarca.ReadOnly = True
        Call Conectar()
        Call CargarList()
        If Login.rol = "administrador" Then
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'Limpio forms y hago foco en el txt
        Call LimpiarForms()
        txtNombreMarca.Focus()
        txtNombreMarca.ReadOnly = False
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Valido que no se intenten cargar campos vacios.
        If txtNombreMarca.Text = "" Then
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
            comando.CommandText = "select id_marca from marca where nombre_marca = @nombre_marca;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@nombre_marca", txtNombreMarca.Text)

            'declaro dreader
            Dim drMarca As MySqlDataReader

            'Traigo datos de la BD
            drMarca = comando.ExecuteReader

            'Si hay registros es porque la marca ya existe.
            If drMarca.HasRows Then
                MsgBox("No se puede agregar, la marca ya existe", MsgBoxStyle.Exclamation, "Agregar")
            Else
                'cierro el data reader
                drMarca.Close()

                'Limpiamos los parametros del comand
                comando.Parameters.Clear()

                'Cargo instruccion sql para agregar los valores.
                comando.CommandText = "insert into marca (nombre_marca) values (@nombre_marca);"
                comando.Parameters.AddWithValue("@nombre_marca", txtNombreMarca.Text)


                'declaro variable para respuesta del server
                Dim Respuesta As Integer

                'ejecuto el insert
                Respuesta = comando.ExecuteNonQuery


                MsgBox("Se agrego la marca exitosamente", MsgBoxStyle.Information, "Agregar")

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
        If txtIdMarca.Text = "" Then
            MsgBox("Seleccionar una marca para editar", MsgBoxStyle.Exclamation, "Editar")
            Exit Sub
        End If

        txtNombreMarca.ReadOnly = False
    End Sub


    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        'valido que no intenten modificar con campos vacios
        If txtIdMarca.Text = "" Or txtNombreMarca.Text = "" Then
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
            Comando.CommandText = "select id_marca from marca where id_marca = @id_marca;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_marca", txtIdMarca.Text)

            'declaro dreader
            Dim drMarca As MySqlDataReader

            'Traigo los datos de la BD
            drMarca = Comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje
            If Not (drMarca.HasRows) Then
                MsgBox("No se encontraron marcas para editar", MsgBoxStyle.Exclamation, "Editar")
            Else
                'Cierro Data Reader
                drMarca.Close()

                'Limpio los parametros para que no esten sobrecargados.
                Comando.Parameters.Clear()

                'Cargo la instruccion sql
                Comando.CommandText = "update marca set nombre_marca=@nombre_marca where id_marca = @id_marca;"

                'Cargo los parametros
                Comando.Parameters.AddWithValue("@id_marca", txtIdMarca.Text)
                Comando.Parameters.AddWithValue("@nombre_marca", txtNombreMarca.Text)

                'Imprimo mensaje para confirmar modificacion
                If MsgBox("¿Esta seguro que desea modificar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Modificar") = MsgBoxResult.Yes Then

                    'Variable para obtener respuesta del servidor al ejecutar.
                    Dim respuesta As Integer

                    'Ejecuto el update
                    respuesta = Comando.ExecuteNonQuery

                    'Informo las marcas modificadas.
                    MsgBox("Se guardaron los cambios de la marca exitosamente", MsgBoxStyle.Information, "Guardar")
                    Call LimpiarForms()
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

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'Verifico que haya algo seleccionado para eliminar
        If txtIdMarca.Text = "" Then
            MsgBox("Debe seleccionar una marca para eliminar", MsgBoxStyle.Exclamation, "Eliminar")
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
            comando.CommandText = "select id_marca from marca where id_marca = @id_marca;"

            'cargo parametros
            comando.Parameters.AddWithValue("@id_marca", txtIdMarca.Text)

            'declaro dreader
            Dim drMarca As MySqlDataReader

            'Traigo datos de la BD
            drMarca = comando.ExecuteReader

            'Si no se encuentran registros imprimo mensaje.
            If Not (drMarca.HasRows) Then
                MsgBox("No existe")
            Else
                'Cierro DR
                drMarca.Close()

                'Limpio los parametros.
                comando.Parameters.Clear()

                'verifiquemos que existan productos con este marca

                comando.CommandText = "select id_producto from producto where id_marca = @id_marca;"

                'Indicamos los parametros
                comando.Parameters.AddWithValue("@id_marca", txtIdMarca.Text)

                Dim drProductoColor As MySqlDataReader

                drProductoColor = comando.ExecuteReader

                If drProductoColor.HasRows Then

                    MsgBox("Esta marca tiene productos asociados, no se puede eliminar", MsgBoxStyle.Critical, "Eliminar")
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
                comando.CommandText = "delete from marca where id_marca = @id_marca;"

                'Cargo parametros
                comando.Parameters.AddWithValue("@id_marca", txtIdMarca.Text)

                'Imprimo mensaje con accion segun respuesta.
                If MsgBox("¿Esta seguro que desea eliminar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim respuesta As Integer

                    'Ejecuto el delete
                    respuesta = comando.ExecuteNonQuery

                    'Imprimo mensaje.
                    MsgBox("La marca ha sido eliminada exitosamente", MsgBoxStyle.Information, "Eliminar")
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


    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        'Limpio Forms
        Call LimpiarForms()
    End Sub

  
    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        Productos.Show()

    End Sub
End Class