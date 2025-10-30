Imports MySql.Data.MySqlClient

Public Class PantallaPrincipal
    Private Sub btnProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductos.Click
        lvwStock.Items.Clear()
        Productos.Show()
        Me.Hide()

    End Sub

    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        lvwStock.Items.Clear()
        ABMClientes.Show()
        Me.Hide()
    End Sub

    Private Sub PantallaPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()

        Dim log As New Login

        Dim respuesta As DialogResult = Login.ShowDialog

        If (respuesta <> Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If

        lblUsuario.Text = Login.usuario

        If Login.rol = "administrador" Then
            btnProveedores.Visible = False
            btnEmpleados.Visible = False
            btnLocalidades.Visible = False
        End If


    End Sub


    Private Sub btnProveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProveedores.Click
        lvwStock.Items.Clear()
        ABMProveedores.Show()
        Me.Hide()

    End Sub

    Private Sub btnEmpleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleados.Click
        lvwStock.Items.Clear()
        ABMEmpleados.Show()
        Me.Hide()

    End Sub


    Sub CargarGrilla(ByVal orden As String)
        'conecto a la BD
        Conexion.Open()

        'declaro objeto comand
        Dim Comando As New MySqlCommand

        'indico cual es la conexion activa
        Comando.Connection = Conexion

        'indico el tipo instruccion
        Comando.CommandType = CommandType.Text

        'cargo la instruccion SQL
        Comando.CommandText = "select producto.codigo_producto ,producto.descripcion,talle.nombre_talle,color.nombre_color, variante_producto.stock_unitario, variante_producto.precio_unitario from producto join variante_producto on producto.id_producto = variante_producto.id_producto join talle on variante_producto.id_talle = talle.id_talle join color on variante_producto.id_color = color.id_color where producto.descripcion like '" & txtBuscador.Text & "%' order by " & orden & " asc;"


        Dim drVariante As MySqlDataReader

        drVariante = Comando.ExecuteReader

        If drVariante.HasRows Then
            'primero limpio
            lvwStock.Items.Clear()

            'recorro el dreader y cargo
            Dim LV As New ListViewItem

            Do While drVariante.Read

                LV = lvwStock.Items.Add(drVariante("codigo_producto"))
                LV.SubItems.Add(drVariante("descripcion"))
                LV.SubItems.Add(drVariante("nombre_talle"))
                LV.SubItems.Add(drVariante("nombre_color"))
                LV.SubItems.Add(drVariante("stock_unitario"))
                LV.SubItems.Add(drVariante("precio_unitario"))
                LV.SubItems.Add("0")
                LV.SubItems.Add(drVariante("precio_unitario"))

            Loop

            drVariante.Close()

        End If
        Conexion.Close()

    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'cargo grilla
        Call CargarGrilla("codigo_producto")
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lvwStock.Items.Clear()
        txtBuscador.Text = ""
        txtDescuento.Text = ""
    End Sub

    Private Sub lvwStock_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwStock.ColumnClick
        Select Case e.Column
            Case 0
                Call CargarGrilla("codigo_producto")
            Case 1
                Call CargarGrilla("descripcion")
            Case 2
                Call CargarGrilla("nombre_talle")
            Case 3
                Call CargarGrilla("nombre_color")
            Case 4
                Call CargarGrilla("stock_unitario")
            Case 5
                Call CargarGrilla("precio_unitario")
        End Select
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

        ' Verifico que haya al menos un item seleccionado
        If lvwStock.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = lvwStock.SelectedItems(0)

            ' Modifico el valor de la columna 6 (índice 6)
            item.SubItems(6).Text = txtDescuento.Text

            item.SubItems(7).Text -= item.SubItems(7).Text * (Convert.ToInt16(txtDescuento.Text) / 100)
        Else
            MessageBox.Show("Debe seleccionar un producto.")
        End If
    End Sub


    Private Sub btnLocalidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalidades.Click
        Localidades.Show()
        Me.Hide()
    End Sub

    Private Sub btnEnvios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnvios.Click
        MenuEnvios.Show()
        Me.Hide()
    End Sub

    Private Sub btnVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVentas.Click
        MenuVenta.Show()
        Me.Hide()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

  
    Private Sub btnNuevaVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaVenta.Click
        GenerarVenta.Show()
        Me.Hide()
    End Sub
End Class