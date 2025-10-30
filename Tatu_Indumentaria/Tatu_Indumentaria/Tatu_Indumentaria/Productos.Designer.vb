<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Productos))
        Me.btnCategorias = New System.Windows.Forms.Button()
        Me.btnTalle = New System.Windows.Forms.Button()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.btnModelos = New System.Windows.Forms.Button()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.cmbModelo = New System.Windows.Forms.ComboBox()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDescipcion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbGenero = New System.Windows.Forms.ComboBox()
        Me.btnImagenes = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cmbTemporada = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnActulizarStock = New System.Windows.Forms.Button()
        Me.lstProductos = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCategorias
        '
        Me.btnCategorias.BackColor = System.Drawing.Color.LightCyan
        Me.btnCategorias.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnCategorias.Image = CType(resources.GetObject("btnCategorias.Image"), System.Drawing.Image)
        Me.btnCategorias.Location = New System.Drawing.Point(12, 12)
        Me.btnCategorias.Name = "btnCategorias"
        Me.btnCategorias.Size = New System.Drawing.Size(118, 48)
        Me.btnCategorias.TabIndex = 11
        Me.btnCategorias.Text = "Categorias"
        Me.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCategorias.UseVisualStyleBackColor = False
        '
        'btnTalle
        '
        Me.btnTalle.BackColor = System.Drawing.Color.LightCyan
        Me.btnTalle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnTalle.Image = CType(resources.GetObject("btnTalle.Image"), System.Drawing.Image)
        Me.btnTalle.Location = New System.Drawing.Point(622, 12)
        Me.btnTalle.Name = "btnTalle"
        Me.btnTalle.Size = New System.Drawing.Size(116, 48)
        Me.btnTalle.TabIndex = 15
        Me.btnTalle.Text = "Talles"
        Me.btnTalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTalle.UseVisualStyleBackColor = False
        '
        'btnMarca
        '
        Me.btnMarca.BackColor = System.Drawing.Color.LightCyan
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(256, 12)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(116, 48)
        Me.btnMarca.TabIndex = 13
        Me.btnMarca.Text = "Marcas"
        Me.btnMarca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMarca.UseVisualStyleBackColor = False
        '
        'btnModelos
        '
        Me.btnModelos.BackColor = System.Drawing.Color.LightCyan
        Me.btnModelos.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnModelos.Image = CType(resources.GetObject("btnModelos.Image"), System.Drawing.Image)
        Me.btnModelos.Location = New System.Drawing.Point(378, 12)
        Me.btnModelos.Name = "btnModelos"
        Me.btnModelos.Size = New System.Drawing.Size(116, 48)
        Me.btnModelos.TabIndex = 14
        Me.btnModelos.Text = "Modelos"
        Me.btnModelos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnModelos.UseVisualStyleBackColor = False
        '
        'btnColor
        '
        Me.btnColor.BackColor = System.Drawing.Color.LightCyan
        Me.btnColor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnColor.Image = CType(resources.GetObject("btnColor.Image"), System.Drawing.Image)
        Me.btnColor.Location = New System.Drawing.Point(134, 12)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(116, 48)
        Me.btnColor.TabIndex = 12
        Me.btnColor.Text = "Color"
        Me.btnColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnColor.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.LightCyan
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.Location = New System.Drawing.Point(515, 547)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(120, 49)
        Me.btnVolver.TabIndex = 17
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'cmbMarca
        '
        Me.cmbMarca.BackColor = System.Drawing.Color.SeaShell
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(375, 379)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(121, 25)
        Me.cmbMarca.TabIndex = 6
        '
        'cmbModelo
        '
        Me.cmbModelo.BackColor = System.Drawing.Color.SeaShell
        Me.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelo.Enabled = False
        Me.cmbModelo.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbModelo.FormattingEnabled = True
        Me.cmbModelo.Location = New System.Drawing.Point(375, 415)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.Size = New System.Drawing.Size(121, 25)
        Me.cmbModelo.TabIndex = 7
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BackColor = System.Drawing.Color.SeaShell
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Enabled = False
        Me.cmbCategoria.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(375, 340)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(121, 25)
        Me.cmbCategoria.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(247, 347)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Categoría"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(247, 386)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Marca"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(247, 422)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 19)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Modelo"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.LightCyan
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(515, 228)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(121, 40)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(247, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 19)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Codigo "
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.SeaShell
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtCodigo.Location = New System.Drawing.Point(375, 191)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(121, 25)
        Me.txtCodigo.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(247, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 19)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Descripcion"
        '
        'txtDescipcion
        '
        Me.txtDescipcion.BackColor = System.Drawing.Color.SeaShell
        Me.txtDescipcion.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDescipcion.Location = New System.Drawing.Point(375, 225)
        Me.txtDescipcion.Name = "txtDescipcion"
        Me.txtDescipcion.ReadOnly = True
        Me.txtDescipcion.Size = New System.Drawing.Size(121, 25)
        Me.txtDescipcion.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(247, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 19)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Genero"
        '
        'cmbGenero
        '
        Me.cmbGenero.BackColor = System.Drawing.Color.SeaShell
        Me.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGenero.Enabled = False
        Me.cmbGenero.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbGenero.FormattingEnabled = True
        Me.cmbGenero.Location = New System.Drawing.Point(375, 263)
        Me.cmbGenero.Name = "cmbGenero"
        Me.cmbGenero.Size = New System.Drawing.Size(121, 25)
        Me.cmbGenero.TabIndex = 3
        '
        'btnImagenes
        '
        Me.btnImagenes.BackColor = System.Drawing.Color.LightCyan
        Me.btnImagenes.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnImagenes.Image = CType(resources.GetObject("btnImagenes.Image"), System.Drawing.Image)
        Me.btnImagenes.Location = New System.Drawing.Point(500, 12)
        Me.btnImagenes.Name = "btnImagenes"
        Me.btnImagenes.Size = New System.Drawing.Size(116, 48)
        Me.btnImagenes.TabIndex = 16
        Me.btnImagenes.Text = "Imagenes"
        Me.btnImagenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImagenes.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.LightCyan
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(515, 320)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 40)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'cmbTemporada
        '
        Me.cmbTemporada.BackColor = System.Drawing.Color.SeaShell
        Me.cmbTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemporada.Enabled = False
        Me.cmbTemporada.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbTemporada.FormattingEnabled = True
        Me.cmbTemporada.Location = New System.Drawing.Point(375, 300)
        Me.cmbTemporada.Name = "cmbTemporada"
        Me.cmbTemporada.Size = New System.Drawing.Size(121, 25)
        Me.cmbTemporada.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(247, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 19)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Temporada"
        '
        'btnActulizarStock
        '
        Me.btnActulizarStock.BackColor = System.Drawing.Color.LightCyan
        Me.btnActulizarStock.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnActulizarStock.Image = CType(resources.GetObject("btnActulizarStock.Image"), System.Drawing.Image)
        Me.btnActulizarStock.Location = New System.Drawing.Point(305, 484)
        Me.btnActulizarStock.Name = "btnActulizarStock"
        Me.btnActulizarStock.Size = New System.Drawing.Size(176, 39)
        Me.btnActulizarStock.TabIndex = 10
        Me.btnActulizarStock.Text = "Stock"
        Me.btnActulizarStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnActulizarStock.UseVisualStyleBackColor = False
        '
        'lstProductos
        '
        Me.lstProductos.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProductos.FormattingEnabled = True
        Me.lstProductos.ItemHeight = 20
        Me.lstProductos.Location = New System.Drawing.Point(25, 116)
        Me.lstProductos.Name = "lstProductos"
        Me.lstProductos.Size = New System.Drawing.Size(194, 324)
        Me.lstProductos.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Codigos de Producto"
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.LightCyan
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(515, 182)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(121, 40)
        Me.btnNuevo.TabIndex = 8
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.LightCyan
        Me.btnEditar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(515, 274)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(121, 40)
        Me.btnEditar.TabIndex = 8
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.SeaShell
        Me.TextBox1.Location = New System.Drawing.Point(375, 153)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 25)
        Me.TextBox1.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(247, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 19)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Buscar"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightCyan
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(516, 364)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 40)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Eliminar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(756, 626)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstProductos)
        Me.Controls.Add(Me.txtDescipcion)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTemporada)
        Me.Controls.Add(Me.cmbGenero)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.cmbModelo)
        Me.Controls.Add(Me.cmbMarca)
        Me.Controls.Add(Me.btnActulizarStock)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.btnModelos)
        Me.Controls.Add(Me.btnMarca)
        Me.Controls.Add(Me.btnImagenes)
        Me.Controls.Add(Me.btnTalle)
        Me.Controls.Add(Me.btnCategorias)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCategorias As System.Windows.Forms.Button
    Friend WithEvents btnTalle As System.Windows.Forms.Button
    Friend WithEvents btnMarca As System.Windows.Forms.Button
    Friend WithEvents btnModelos As System.Windows.Forms.Button
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cmbModelo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDescipcion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbGenero As System.Windows.Forms.ComboBox
    Friend WithEvents btnImagenes As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbTemporada As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnActulizarStock As System.Windows.Forms.Button
    Friend WithEvents lstProductos As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
