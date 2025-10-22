<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PantallaPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PantallaPrincipal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.btnProveedores = New System.Windows.Forms.Button()
        Me.lvwStock = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEmpleados = New System.Windows.Forms.Button()
        Me.btnEnvios = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnLocalidades = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(232, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 19)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Buscar productos"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.Location = New System.Drawing.Point(827, 15)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(0, 19)
        Me.lblUsuario.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(665, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 19)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Usuario:"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.LightCyan
        Me.Button10.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Button10.Location = New System.Drawing.Point(603, 67)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(169, 31)
        Me.Button10.TabIndex = 11
        Me.Button10.Text = "Nueva Compra"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.LightCyan
        Me.Button8.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Button8.Location = New System.Drawing.Point(417, 67)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(169, 31)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "Nueva Venta"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.LightCyan
        Me.Button9.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Button9.Location = New System.Drawing.Point(235, 67)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(169, 31)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "Nuevo Producto"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(232, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 19)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Acceso Rápido"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LightCyan
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.Location = New System.Drawing.Point(505, 133)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 31)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'txtBuscador
        '
        Me.txtBuscador.BackColor = System.Drawing.Color.SeaShell
        Me.txtBuscador.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtBuscador.Location = New System.Drawing.Point(235, 133)
        Me.txtBuscador.Multiline = True
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(253, 25)
        Me.txtBuscador.TabIndex = 12
        '
        'btnProveedores
        '
        Me.btnProveedores.BackColor = System.Drawing.Color.LightCyan
        Me.btnProveedores.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnProveedores.Image = CType(resources.GetObject("btnProveedores.Image"), System.Drawing.Image)
        Me.btnProveedores.Location = New System.Drawing.Point(12, 404)
        Me.btnProveedores.Name = "btnProveedores"
        Me.btnProveedores.Size = New System.Drawing.Size(180, 49)
        Me.btnProveedores.TabIndex = 7
        Me.btnProveedores.Text = "Proveedores"
        Me.btnProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProveedores.UseVisualStyleBackColor = False
        '
        'lvwStock
        '
        Me.lvwStock.BackColor = System.Drawing.Color.SeaShell
        Me.lvwStock.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvwStock.FullRowSelect = True
        Me.lvwStock.GridLines = True
        Me.lvwStock.Location = New System.Drawing.Point(235, 180)
        Me.lvwStock.Name = "lvwStock"
        Me.lvwStock.Size = New System.Drawing.Size(837, 327)
        Me.lvwStock.TabIndex = 15
        Me.lvwStock.UseCompatibleStateImageBehavior = False
        Me.lvwStock.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Codigo"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Talle"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Color"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 55
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "En Stock"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Precio unitario"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Descuento"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 77
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Precio Final"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 100
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.LightCyan
        Me.btnLimpiar.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Location = New System.Drawing.Point(921, 513)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(151, 30)
        Me.btnLimpiar.TabIndex = 17
        Me.btnLimpiar.Text = "Limpiar Busqueda"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(766, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 19)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Descuento:"
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.SeaShell
        Me.txtDescuento.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDescuento.Location = New System.Drawing.Point(852, 139)
        Me.txtDescuento.Multiline = True
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(47, 25)
        Me.txtDescuento.TabIndex = 14
        '
        'btnAplicar
        '
        Me.btnAplicar.BackColor = System.Drawing.Color.LightCyan
        Me.btnAplicar.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAplicar.Location = New System.Drawing.Point(931, 132)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(81, 30)
        Me.btnAplicar.TabIndex = 16
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(905, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "%"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.LightCyan
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.Location = New System.Drawing.Point(831, 513)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 30)
        Me.btnSalir.TabIndex = 18
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnEmpleados
        '
        Me.btnEmpleados.BackColor = System.Drawing.Color.LightCyan
        Me.btnEmpleados.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnEmpleados.Image = CType(resources.GetObject("btnEmpleados.Image"), System.Drawing.Image)
        Me.btnEmpleados.Location = New System.Drawing.Point(12, 184)
        Me.btnEmpleados.Name = "btnEmpleados"
        Me.btnEmpleados.Size = New System.Drawing.Size(180, 49)
        Me.btnEmpleados.TabIndex = 3
        Me.btnEmpleados.Text = "Empleados"
        Me.btnEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEmpleados.UseVisualStyleBackColor = False
        '
        'btnEnvios
        '
        Me.btnEnvios.BackColor = System.Drawing.Color.LightCyan
        Me.btnEnvios.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnEnvios.Image = CType(resources.GetObject("btnEnvios.Image"), System.Drawing.Image)
        Me.btnEnvios.Location = New System.Drawing.Point(12, 239)
        Me.btnEnvios.Name = "btnEnvios"
        Me.btnEnvios.Size = New System.Drawing.Size(180, 49)
        Me.btnEnvios.TabIndex = 4
        Me.btnEnvios.Text = "Envios"
        Me.btnEnvios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnvios.UseVisualStyleBackColor = False
        '
        'btnClientes
        '
        Me.btnClientes.BackColor = System.Drawing.Color.LightCyan
        Me.btnClientes.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnClientes.Image = CType(resources.GetObject("btnClientes.Image"), System.Drawing.Image)
        Me.btnClientes.Location = New System.Drawing.Point(12, 67)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(180, 49)
        Me.btnClientes.TabIndex = 1
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClientes.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.LightCyan
        Me.Button5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(12, 129)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(180, 49)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "Compras"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'btnLocalidades
        '
        Me.btnLocalidades.BackColor = System.Drawing.Color.LightCyan
        Me.btnLocalidades.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnLocalidades.Image = CType(resources.GetObject("btnLocalidades.Image"), System.Drawing.Image)
        Me.btnLocalidades.Location = New System.Drawing.Point(11, 294)
        Me.btnLocalidades.Name = "btnLocalidades"
        Me.btnLocalidades.Size = New System.Drawing.Size(180, 49)
        Me.btnLocalidades.TabIndex = 5
        Me.btnLocalidades.Text = "Localidades"
        Me.btnLocalidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLocalidades.UseVisualStyleBackColor = False
        '
        'btnVentas
        '
        Me.btnVentas.BackColor = System.Drawing.Color.LightCyan
        Me.btnVentas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnVentas.Image = CType(resources.GetObject("btnVentas.Image"), System.Drawing.Image)
        Me.btnVentas.Location = New System.Drawing.Point(12, 459)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(180, 49)
        Me.btnVentas.TabIndex = 8
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVentas.UseVisualStyleBackColor = False
        '
        'btnProductos
        '
        Me.btnProductos.BackColor = System.Drawing.Color.LightCyan
        Me.btnProductos.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnProductos.Image = CType(resources.GetObject("btnProductos.Image"), System.Drawing.Image)
        Me.btnProductos.Location = New System.Drawing.Point(12, 349)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(180, 49)
        Me.btnProductos.TabIndex = 6
        Me.btnProductos.Text = "Productos"
        Me.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProductos.UseVisualStyleBackColor = False
        '
        'PantallaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1109, 570)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.lvwStock)
        Me.Controls.Add(Me.btnEmpleados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.btnEnvios)
        Me.Controls.Add(Me.btnClientes)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btnLocalidades)
        Me.Controls.Add(Me.btnVentas)
        Me.Controls.Add(Me.btnProveedores)
        Me.Controls.Add(Me.btnProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PantallaPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEmpleados As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents btnEnvios As System.Windows.Forms.Button
    Friend WithEvents btnClientes As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btnVentas As System.Windows.Forms.Button
    Friend WithEvents btnProveedores As System.Windows.Forms.Button
    Friend WithEvents btnProductos As System.Windows.Forms.Button
    Friend WithEvents lvwStock As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnLocalidades As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
