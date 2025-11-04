<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.lstProductos = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.cmbTalle = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtGenero = New System.Windows.Forms.TextBox()
        Me.txtTemporada = New System.Windows.Forms.TextBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.ptbImagen = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.SelectImpre = New System.Windows.Forms.PrintDialog()
        Me.VistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.gpbFicha = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ptbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFicha.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(25, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar producto"
        '
        'txtBuscador
        '
        Me.txtBuscador.BackColor = System.Drawing.Color.SeaShell
        Me.txtBuscador.Location = New System.Drawing.Point(28, 79)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(157, 25)
        Me.txtBuscador.TabIndex = 1
        '
        'lstProductos
        '
        Me.lstProductos.BackColor = System.Drawing.Color.SeaShell
        Me.lstProductos.FormattingEnabled = True
        Me.lstProductos.ItemHeight = 17
        Me.lstProductos.Location = New System.Drawing.Point(11, 19)
        Me.lstProductos.Name = "lstProductos"
        Me.lstProductos.Size = New System.Drawing.Size(157, 225)
        Me.lstProductos.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(219, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Codigo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(219, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descripcion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(219, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 19)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Genero"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(219, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 19)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Temporada"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(219, 156)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 19)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Categoria"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(219, 217)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 19)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Modelo"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(219, 187)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 19)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Marca"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(8, 305)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 19)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Color"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(8, 349)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 19)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Talle"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.SeaShell
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(120, 298)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(121, 25)
        Me.cmbColor.TabIndex = 3
        '
        'cmbTalle
        '
        Me.cmbTalle.BackColor = System.Drawing.Color.SeaShell
        Me.cmbTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTalle.FormattingEnabled = True
        Me.cmbTalle.Location = New System.Drawing.Point(120, 341)
        Me.cmbTalle.Name = "cmbTalle"
        Me.cmbTalle.Size = New System.Drawing.Size(121, 25)
        Me.cmbTalle.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(8, 392)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 19)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Cantidad "
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.SeaShell
        Me.txtCantidad.Location = New System.Drawing.Point(120, 392)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(122, 25)
        Me.txtCantidad.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(8, 441)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 19)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Precio Unitario"
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BackColor = System.Drawing.Color.SeaShell
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(120, 441)
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(122, 25)
        Me.txtPrecioUnitario.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.LightCyan
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(29, 609)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(120, 49)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightCyan
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(151, 609)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 49)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.LightCyan
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.Location = New System.Drawing.Point(422, 635)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(120, 49)
        Me.btnVolver.TabIndex = 20
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.SeaShell
        Me.txtCodigo.Location = New System.Drawing.Point(347, 29)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(197, 25)
        Me.txtCodigo.TabIndex = 21
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.SeaShell
        Me.txtDescripcion.Location = New System.Drawing.Point(347, 59)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(197, 25)
        Me.txtDescripcion.TabIndex = 21
        '
        'txtGenero
        '
        Me.txtGenero.BackColor = System.Drawing.Color.SeaShell
        Me.txtGenero.Location = New System.Drawing.Point(347, 87)
        Me.txtGenero.Name = "txtGenero"
        Me.txtGenero.ReadOnly = True
        Me.txtGenero.Size = New System.Drawing.Size(197, 25)
        Me.txtGenero.TabIndex = 21
        '
        'txtTemporada
        '
        Me.txtTemporada.BackColor = System.Drawing.Color.SeaShell
        Me.txtTemporada.Location = New System.Drawing.Point(347, 122)
        Me.txtTemporada.Name = "txtTemporada"
        Me.txtTemporada.ReadOnly = True
        Me.txtTemporada.Size = New System.Drawing.Size(197, 25)
        Me.txtTemporada.TabIndex = 21
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.SeaShell
        Me.txtCategoria.Location = New System.Drawing.Point(347, 156)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(197, 25)
        Me.txtCategoria.TabIndex = 21
        '
        'txtMarca
        '
        Me.txtMarca.BackColor = System.Drawing.Color.SeaShell
        Me.txtMarca.Location = New System.Drawing.Point(347, 187)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(197, 25)
        Me.txtMarca.TabIndex = 21
        '
        'txtModelo
        '
        Me.txtModelo.BackColor = System.Drawing.Color.SeaShell
        Me.txtModelo.Location = New System.Drawing.Point(347, 217)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(197, 25)
        Me.txtModelo.TabIndex = 21
        '
        'ptbImagen
        '
        Me.ptbImagen.Location = New System.Drawing.Point(347, 287)
        Me.ptbImagen.Name = "ptbImagen"
        Me.ptbImagen.Size = New System.Drawing.Size(194, 207)
        Me.ptbImagen.TabIndex = 22
        Me.ptbImagen.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.LightCyan
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(84, 664)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(120, 45)
        Me.btnImprimir.TabIndex = 23
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'PrintDoc
        '
        '
        'SelectImpre
        '
        Me.SelectImpre.UseEXDialog = True
        '
        'VistaPrevia
        '
        Me.VistaPrevia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.VistaPrevia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.VistaPrevia.ClientSize = New System.Drawing.Size(400, 300)
        Me.VistaPrevia.Enabled = True
        Me.VistaPrevia.Icon = CType(resources.GetObject("VistaPrevia.Icon"), System.Drawing.Icon)
        Me.VistaPrevia.Name = "VistaPrevia"
        Me.VistaPrevia.Visible = False
        '
        'gpbFicha
        '
        Me.gpbFicha.Controls.Add(Me.ptbImagen)
        Me.gpbFicha.Controls.Add(Me.txtModelo)
        Me.gpbFicha.Controls.Add(Me.txtMarca)
        Me.gpbFicha.Controls.Add(Me.txtCategoria)
        Me.gpbFicha.Controls.Add(Me.txtTemporada)
        Me.gpbFicha.Controls.Add(Me.txtGenero)
        Me.gpbFicha.Controls.Add(Me.txtDescripcion)
        Me.gpbFicha.Controls.Add(Me.txtCodigo)
        Me.gpbFicha.Controls.Add(Me.Label17)
        Me.gpbFicha.Controls.Add(Me.txtPrecioUnitario)
        Me.gpbFicha.Controls.Add(Me.txtCantidad)
        Me.gpbFicha.Controls.Add(Me.Label14)
        Me.gpbFicha.Controls.Add(Me.cmbTalle)
        Me.gpbFicha.Controls.Add(Me.cmbColor)
        Me.gpbFicha.Controls.Add(Me.Label13)
        Me.gpbFicha.Controls.Add(Me.Label12)
        Me.gpbFicha.Controls.Add(Me.Label20)
        Me.gpbFicha.Controls.Add(Me.Label21)
        Me.gpbFicha.Controls.Add(Me.Label10)
        Me.gpbFicha.Controls.Add(Me.Label8)
        Me.gpbFicha.Controls.Add(Me.Label6)
        Me.gpbFicha.Controls.Add(Me.Label4)
        Me.gpbFicha.Controls.Add(Me.Label2)
        Me.gpbFicha.Controls.Add(Me.lstProductos)
        Me.gpbFicha.Location = New System.Drawing.Point(17, 103)
        Me.gpbFicha.Name = "gpbFicha"
        Me.gpbFicha.Size = New System.Drawing.Size(555, 502)
        Me.gpbFicha.TabIndex = 24
        Me.gpbFicha.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Symbol", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 19)
        Me.Label3.TabIndex = 146
        Me.Label3.Text = "Stock"
        '
        'Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(646, 740)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gpbFicha)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock"
        CType(Me.ptbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFicha.ResumeLayout(False)
        Me.gpbFicha.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents lstProductos As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTalle As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtGenero As System.Windows.Forms.TextBox
    Friend WithEvents txtTemporada As System.Windows.Forms.TextBox
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents ptbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents SelectImpre As System.Windows.Forms.PrintDialog
    Friend WithEvents VistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents gpbFicha As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
