Imports MySql.Data.MySqlClient



Public Class GenerarVenta
    Public idVariante As Integer
    Public cantidad As Integer

    Sub CargarDataGridVenta()

        'conecto a la BD
        Conexion.Open()

        'declaro objeto comand
        Dim Comando As New MySqlCommand

        'indico cual es la conexion activa
        Comando.Connection = Conexion

        'indico el tipo instruccion
        Comando.CommandType = CommandType.Text

        'cargo la instruccion SQL
        Comando.CommandText = "SELECT id_variante_producto, producto.codigo_producto, producto.descripcion, variante_producto.stock_unitario, talle.nombre_talle, color.nombre_color, precio_unitario FROM(variante_producto) JOIN talle on variante_producto.id_talle = talle.id_talle JOIN color on variante_producto.id_color = color.id_color JOIN producto on variante_producto.id_producto = producto.id_producto WHERE variante_producto.id_variante_producto = @id_variante;"

        Comando.Parameters.AddWithValue("@id_variante", idVariante)

        Dim drVariante As MySqlDataReader

        drVariante = Comando.ExecuteReader

        If drVariante.HasRows Then
            MsgBox("entre")
            Do While drVariante.Read

                dgvVenta.Rows.Add(drVariante("id_variante_producto"), drVariante("codigo_producto").ToString, drVariante("descripcion"), drVariante("nombre_talle"), drVariante("nombre_color"), cantidad, drVariante("precio_unitario"))
            Loop

            drVariante.Close()

        End If
        Conexion.Close()

    End Sub


    Sub CargarDataGrid()

        dgvBusqueda.Rows.Clear()
        'conecto a la BD
        Conexion.Open()

        'declaro objeto comand
        Dim Comando As New MySqlCommand

        'indico cual es la conexion activa
        Comando.Connection = Conexion

        'indico el tipo instruccion
        Comando.CommandType = CommandType.Text

        'cargo la instruccion SQL
        Comando.CommandText = "SELECT id_variante_producto, producto.codigo_producto , marca.nombre_marca, modelo.nombre_modelo, categoria.nombre_categoria, variante_producto.stock_unitario, talle.nombre_talle, color.nombre_color , precio_unitario FROM(variante_producto) JOIN talle on variante_producto.id_talle = talle.id_talle JOIN color on variante_producto.id_color = color.id_color JOIN producto on variante_producto.id_producto = producto.id_producto JOIN marca on producto.id_marca = marca.id_marca JOIN modelo ON producto.id_modelo = modelo.id_modelo JOIN categoria ON producto.id_categoria = categoria.id_categoria WHERE variante_producto.id_producto = (select id_producto from producto where codigo_producto =  @codigo);"

        Comando.Parameters.AddWithValue("@codigo", txtBuscarproducto.Text)

        Dim drVariante As MySqlDataReader

        drVariante = Comando.ExecuteReader

        If drVariante.HasRows Then

            Do While drVariante.Read

                dgvBusqueda.Rows.Add(drVariante("id_variante_producto"), drVariante("codigo_producto").ToString, drVariante("nombre_marca"), drVariante("nombre_modelo"), drVariante("nombre_talle"), drVariante("nombre_color"), drVariante("stock_unitario"), drVariante("precio_unitario"))
            Loop

            drVariante.Close()

        End If
        Conexion.Close()
    End Sub



    Private Sub GenerarVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblFecha.Text = Date.Now.ToLongDateString() & " - " & TimeOfDay.ToLongTimeString()
    End Sub


    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        If txtBuscarCliente.Text = "" Then
            MsgBox("Debe ingresar un Dni para buscar al cliente", MsgBoxStyle.Exclamation, "Error de busqueda")
            Exit Sub
        End If

        Try
            Conexion.Open()
            'declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa.
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo instruccion sql
            comando.CommandText = "select dni,nombre,apellido,estado from cliente where dni = @dni;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@dni", txtBuscarCliente.Text)

            'declaro dreader
            Dim drCliente As MySqlDataReader

            'Traigo datos de la BD
            drCliente = comando.ExecuteReader

            If drCliente.HasRows() Then
                drCliente.Read()
                If drCliente("estado") Then
                    lblCliente.Text = drCliente("nombre").ToString + " " + drCliente("apellido").ToString
                    lblDNI.Text = drCliente("dni").ToString
                ElseIf Not drCliente("estado") Then
                    Dim nombre As String = drCliente("nombre").ToString + " " + drCliente("apellido").ToString
                    Dim dni As String = drCliente("dni").ToString.ToString

                    drCliente.Close()

                    If MessageBox.Show("¿El cliente esta inactivo, desea activarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        comando.Parameters.Clear()
                        comando.CommandText = "update cliente set estado=@estado where dni = @dni;"
                        comando.Parameters.AddWithValue("@estado", 1)
                        comando.Parameters.AddWithValue("@dni", txtBuscarCliente.Text)

                        comando.ExecuteNonQuery()

                        lblCliente.Text = nombre
                        lblDNI.Text = dni
                    End If
                End If
            End If

            drCliente.Close()
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        PantallaPrincipal.Show()
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        If txtBuscarproducto.Text = "" Then
            MsgBox("Debe ingresar un codigo para buscar al producto", MsgBoxStyle.Exclamation, "Error de busqueda")
            Exit Sub
        End If

        Try
            Conexion.Open()
            'declaro objeto comando
            Dim comando As New MySqlCommand

            'Indico conexion activa.
            comando.Connection = Conexion

            'Indico tipo de instruccion
            comando.CommandType = CommandType.Text

            'Cargo instruccion sql
            comando.CommandText = "select codigo_producto from producto where codigo_producto = @codigo;"

            'Asigno valores a los parametros
            comando.Parameters.AddWithValue("@codigo", txtBuscarproducto.Text)

            'declaro dreader
            Dim drProducto As MySqlDataReader

            'Traigo datos de la BD
            drProducto = comando.ExecuteReader

            If drProducto.HasRows() Then
                drProducto.Close()
                Conexion.Close()
                MsgBox("Ya llegue")
                Call CargarDataGrid()
                Exit Sub
            Else
                drProducto.Close()
                MsgBox("El codigo ingresado no existe")

            End If
            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If dgvBusqueda.SelectedRows.Count > 0 Then
            Dim fila As DataGridViewRow = dgvBusqueda.SelectedRows(0)

            ' Obtiene los valores de las columnas
            idVariante = fila.Cells("id").Value
            cantidad = fila.Cells("stock").Value

            MsgBox("ID seleccionado: " & idVariante & vbCrLf & "Cantidad: " & cantidad)
        Else
            MsgBox("Debe seleccionar una fila primero.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        If Val(txtCantidad.Text) < cantidad Then
            Call CargarDataGridVenta()
        ElseIf txtCantidad.Text > cantidad Then
            MsgBox("La cantidad ingresada es mayor al stock disponible", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If



    End Sub
End Class