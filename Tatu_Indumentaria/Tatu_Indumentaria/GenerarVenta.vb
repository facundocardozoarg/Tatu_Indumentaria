Imports MySql.Data.MySqlClient



Public Class GenerarVenta
    Public idVariante As Integer
    Public cantidadEnStock As Integer
    Public id_venta As Integer

    Public id_cliente As Integer
    Public id_empleado As Integer
    Public id_envio As Integer
    Public id_medio_pago As Integer


    Sub LimpiarCampos()
        ' Limpia labels de cliente
        lblCliente.Text = ""
        lblDNI.Text = ""
        lblSubtotal.Text = "0.00"
        lblPrecioTotal.Text = "0.00"
        lblFecha.Text = Date.Now.ToLongDateString() & " - " & TimeOfDay.ToLongTimeString()
        lblUser.Text = Login.usuario

        ' Limpia textboxes
        txtBuscarCliente.Clear()
        txtBuscarproducto.Clear()
        txtCantidad.Clear()
        txtDescuento.Clear()

        ' Limpia los DataGridView
        dgvVenta.Rows.Clear()
        dgvBusqueda.Rows.Clear()

        ' Reinicia variables globales
        id_cliente = 0
        idVariante = 0
        id_venta = 0
        cantidadEnStock = 0
    End Sub



    Sub CalcularTotal()
        Dim total As Decimal = 0

        ' Recorre todas las filas del DataGridView
        For Each fila As DataGridViewRow In dgvVenta.Rows
            ' Verifica que la celda "subtotal" tenga un valor numérico válido
            If Not IsDBNull(fila.Cells("SubtotalUnit").Value) AndAlso IsNumeric(fila.Cells("SubtotalUnit").Value) Then
                total += Convert.ToDecimal(fila.Cells("SubtotalUnit").Value)
            End If
        Next

        ' Muestra el total formateado con dos decimales
        lblSubtotal.Text = total.ToString("N2")

        lblPrecioTotal.Text = total.ToString("N2")
    End Sub




    Sub GenerarVenta()
        Try
            'conecto a la BD
            Conexion.Open()

            'declaro objeto comand
            Dim Comando As New MySqlCommand

            'indico cual es la conexion activa
            Comando.Connection = Conexion

            'indico el tipo instruccion
            Comando.CommandType = CommandType.Text

            'cargo la instruccion SQL
            Comando.CommandText = "insert into venta (fecha_venta,id_cliente,id_empleado,id_medio_pago,id_envio)values(@fecha_venta,@id_cliente,@id_empleado,@id_medio_pago,@id_envio)"

            Comando.Parameters.AddWithValue("@fecha_venta", DateTime.Now)
            Comando.Parameters.AddWithValue("@id_cliente", id_cliente)
            Comando.Parameters.AddWithValue("@id_empleado", 1)
            Comando.Parameters.AddWithValue("@id_medio_pago", 1)
            Comando.Parameters.AddWithValue("@id_envio", 1)

            Comando.ExecuteNonQuery()

            Comando.Parameters.Clear()

            Comando.CommandText = "select last_insert_id()"

            id_venta = Comando.ExecuteScalar


            For i = 0 To dgvVenta.Rows.Count - 1
                Dim id_var As Integer = CInt(dgvVenta.Rows(i).Cells("id_variante").Value)
                Dim cantidad As Integer = CInt(dgvVenta.Rows(i).Cells("cant").Value)
                Dim precio_unitario As Integer = CDec(dgvVenta.Rows(i).Cells("precio_unitario").Value)

                cantidadEnStock = 0

                ' ahora usás idVariante y cantidad para insertar el detalle y actualizar stock
                Comando.Parameters.Clear()

                'Obtengo stock del producto 
                Comando.CommandText = "select stock_unitario from variante_producto where id_variante_producto = @id_variante_producto"
                Comando.Parameters.AddWithValue("id_variante_producto", id_var)

                cantidadEnStock = Comando.ExecuteScalar



                If cantidadEnStock >= cantidad Then

                    Comando.Parameters.Clear()

                    'Inserto cada detalle de venta
                    Comando.CommandText = "insert into detalle_venta(id_venta,id_variante_producto,cantidad,descuento,subtotal)values(@id_venta,@id_variante_producto,@cantidad,@descuento,@subtotal)"
                    Comando.Parameters.AddWithValue("@id_venta", id_venta)
                    Comando.Parameters.AddWithValue("@id_variante_producto", id_var)
                    Comando.Parameters.AddWithValue("@cantidad", cantidad)
                    Comando.Parameters.AddWithValue("@descuento", 0)
                    Comando.Parameters.AddWithValue("@subtotal", (precio_unitario * cantidad))
                    Comando.ExecuteNonQuery()
                    Comando.Parameters.Clear()



                    'Actualizo el stock
                    Comando.CommandText = "update variante_producto set stock_unitario=@cantidad where id_variante_producto = @id_variante_producto"
                    Comando.Parameters.AddWithValue("@cantidad", (cantidadEnStock - cantidad))
                    Comando.Parameters.AddWithValue("@id_variante_producto", id_var)

                    Comando.ExecuteNonQuery()
                Else
                    MsgBox("No se proceso la compra porque la cantidad ingresada es mayor al stock disponible")
                End If
            Next

            Conexion.Close()
            frmFactura.ShowDialog()
            Call LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
        
    End Sub


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
            Do While drVariante.Read

                dgvVenta.Rows.Add(drVariante("id_variante_producto"), drVariante("codigo_producto").ToString, drVariante("descripcion"), drVariante("nombre_talle"), drVariante("nombre_color"), txtCantidad.Text, drVariante("precio_unitario"), Val(txtCantidad.Text) * drVariante("precio_unitario"))
                Call CalcularTotal()
            Loop

            drVariante.Close()

        End If
        txtCantidad.Text = ""
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
        Call Conectar()
        lblFecha.Text = Date.Now.ToLongDateString() & " - " & TimeOfDay.ToLongTimeString()
        lblUser.Text = Login.usuario
        Timer1.Start()
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
            comando.CommandText = "select id_cliente,dni,nombre,apellido,estado from cliente where dni = @dni;"

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
                    id_cliente = drCliente("id_cliente")
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
        If Val(txtCantidad.Text) <= 0 Or txtCantidad.Text = "" Then
            Exit Sub
        End If

        If dgvBusqueda.SelectedRows.Count > 0 Then
            Dim fila As DataGridViewRow = dgvBusqueda.SelectedRows(0)

            ' Obtiene los valores de las columnas
            idVariante = fila.Cells("id").Value
            cantidadEnStock = fila.Cells("stock").Value

            MsgBox("ID seleccionado: " & idVariante & vbCrLf & "stock: " & cantidadEnStock)
        Else
            MsgBox("Debe seleccionar una fila primero.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        If Val(txtCantidad.Text) < cantidadEnStock Then

            Call CargarDataGridVenta()
        ElseIf txtCantidad.Text > cantidadEnStock Then
            MsgBox("La cantidad ingresada es mayor al stock disponible", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If



    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If dgvVenta.RowCount <= 0 Then
            Exit Sub
        End If

        Call GenerarVenta()
    End Sub

    Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCliente.Click
        ABMClientes.ShowDialog()

    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
       If Val(lblSubtotal.Text) = 0 Or Val(txtDescuento.Text) = 0 Then Exit Sub

        Dim subtotal As Double = CDbl(Replace(lblSubtotal.Text, ".", ""))
        Dim descuento As Double = CDbl(txtDescuento.Text)

        Dim total As Double = subtotal - (subtotal * descuento / 100)
        lblPrecioTotal.Text = Format(total, "N2")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblFecha.Text = Date.Now.ToLongDateString() & " - " & TimeOfDay.ToLongTimeString()

    End Sub
End Class