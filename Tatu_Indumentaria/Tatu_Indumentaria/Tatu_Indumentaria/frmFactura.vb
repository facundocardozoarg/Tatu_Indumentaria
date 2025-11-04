Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing


Public Class frmFactura


    Sub CalcularTotal()
        Dim total As Decimal = 0

        ' Recorre todas las filas del DataGridView
        For Each fila As DataGridViewRow In dgvDetalleVenta.Rows
            ' Verifica que la celda "subtotal" tenga un valor numérico válido
            If Not IsDBNull(fila.Cells("subtotal").Value) AndAlso IsNumeric(fila.Cells("subtotal").Value) Then
                total += Convert.ToDecimal(fila.Cells("subtotal").Value)
            End If
        Next

        ' Muestra el total formateado con dos decimales
        lblTotal.Text = total.ToString("N2")
    End Sub


    Sub CargarDetalle(ByVal id_venta)
        Try
            Conexion.Open()

            'declaro objeto comand
            Dim Comando As New MySqlCommand

            'configuro el command

            'Indico conexion activa
            Comando.Connection = Conexion

            'Indico el tipo de instruccion
            Comando.CommandType = CommandType.Text

            'cargo instruccion sql
            Comando.CommandText = "select producto.codigo_producto, producto.descripcion,talle.nombre_talle,color.nombre_color,cantidad,descuento,variante_producto.precio_unitario,subtotal,detalle_venta.id_variante_producto,id_detalle_venta  from detalle_venta join variante_producto on detalle_venta.id_variante_producto = variante_producto.id_variante_producto join talle on variante_producto.id_talle = talle.id_talle join color on variante_producto.id_color = color.id_color join producto on variante_producto.id_producto = producto.id_producto where id_venta = @id_venta"


            Comando.Parameters.AddWithValue("@id_venta", id_venta)
            Dim drDetalle As MySqlDataReader

            drDetalle = Comando.ExecuteReader

            If drDetalle.HasRows Then
                Do While drDetalle.Read
                    dgvDetalleVenta.Rows.Add(drDetalle("id_variante_producto"), drDetalle("id_detalle_venta"), drDetalle("codigo_producto"), drDetalle("descripcion") + " " + drDetalle("nombre_talle") + " " + drDetalle("nombre_color"), drDetalle("cantidad"), drDetalle("descuento"), drDetalle("precio_unitario"), drDetalle("subtotal"))
                Loop
                drDetalle.Close()
            End If

            Conexion.Close()
            Call CalcularTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub



    Sub CargarCabecera(ByVal id_venta As Integer)
        Try
            Conexion.Open()

            'declaro objeto comand
            Dim Comando As New MySqlCommand

            'configuro el command

            'Indico conexion activa
            Comando.Connection = Conexion

            'Indico el tipo de instruccion
            Comando.CommandType = CommandType.Text

            'cargo instruccion sql
            Comando.CommandText = "select cliente.nombre as nombre_cliente,cliente.apellido as apellido_cliente,cliente.dni ,cliente.direccion,cliente.telefono, empleado.nombre as nombre_empleado,empleado.apellido as apellido_empleado, venta.fecha_venta,venta.id_venta from venta join cliente on venta.id_cliente = cliente.id_cliente join empleado on venta.id_empleado = empleado.id_empleado where venta.id_venta = @id_venta;"

            'Indico parametros 
            Comando.Parameters.AddWithValue("@id_venta", id_venta)

            Dim drVenta As MySqlDataReader

            drVenta = Comando.ExecuteReader



            If drVenta.HasRows Then
                drVenta.Read()

                lblNumComprobante.Text = drVenta("id_venta").ToString
                lblFecha.Text = CDate(drVenta("fecha_venta")).ToLongDateString()
                lblVendedor.Text = drVenta("nombre_empleado").ToString + " " + drVenta("apellido_empleado").ToString
                lblCliente.Text = drVenta("nombre_cliente").ToString + " " + drVenta("apellido_cliente").ToString
                lblDNI.Text = drVenta("dni").ToString
                lblDireccion.Text = drVenta("direccion").ToString
                lblTelefono.Text = drVenta("telefono").ToString
                drVenta.Close()
            End If


            Conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        Call CargarCabecera(GenerarVenta.id_venta)
        Call CargarDetalle(GenerarVenta.id_venta)
    End Sub

End Class
