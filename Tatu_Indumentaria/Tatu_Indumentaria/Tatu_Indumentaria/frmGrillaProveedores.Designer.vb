<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrillaProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrillaProveedores))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCorreoProveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefonoProveedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDireccionProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescripcionProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdProveedor = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.lvwProveedores = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.LightCyan
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.Location = New System.Drawing.Point(994, 482)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(120, 49)
        Me.btnVolver.TabIndex = 202
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.Color.SeaShell
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(477, 491)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(148, 24)
        Me.cmbPais.TabIndex = 199
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.SeaShell
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(477, 461)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(148, 24)
        Me.cmbProvincia.TabIndex = 201
        '
        'cmbCiudad
        '
        Me.cmbCiudad.BackColor = System.Drawing.Color.SeaShell
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(477, 431)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(148, 24)
        Me.cmbCiudad.TabIndex = 200
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(368, 498)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 19)
        Me.Label13.TabIndex = 198
        Me.Label13.Text = "País"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(366, 468)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 19)
        Me.Label12.TabIndex = 197
        Me.Label12.Text = "Provincia"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(365, 438)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 19)
        Me.Label11.TabIndex = 196
        Me.Label11.Text = "Ciudad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(368, 396)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 19)
        Me.Label9.TabIndex = 195
        Me.Label9.Text = "Correo"
        '
        'txtCorreoProveedor
        '
        Me.txtCorreoProveedor.BackColor = System.Drawing.Color.SeaShell
        Me.txtCorreoProveedor.Location = New System.Drawing.Point(477, 393)
        Me.txtCorreoProveedor.MaxLength = 50
        Me.txtCorreoProveedor.Name = "txtCorreoProveedor"
        Me.txtCorreoProveedor.Size = New System.Drawing.Size(148, 22)
        Me.txtCorreoProveedor.TabIndex = 194
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(50, 493)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 19)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "Telefono"
        '
        'txtTelefonoProveedor
        '
        Me.txtTelefonoProveedor.BackColor = System.Drawing.Color.SeaShell
        Me.txtTelefonoProveedor.Location = New System.Drawing.Point(159, 488)
        Me.txtTelefonoProveedor.MaxLength = 50
        Me.txtTelefonoProveedor.Name = "txtTelefonoProveedor"
        Me.txtTelefonoProveedor.Size = New System.Drawing.Size(148, 22)
        Me.txtTelefonoProveedor.TabIndex = 192
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(50, 458)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 191
        Me.Label6.Text = "Dirección"
        '
        'txtDireccionProveedor
        '
        Me.txtDireccionProveedor.BackColor = System.Drawing.Color.SeaShell
        Me.txtDireccionProveedor.Location = New System.Drawing.Point(159, 453)
        Me.txtDireccionProveedor.MaxLength = 50
        Me.txtDireccionProveedor.Name = "txtDireccionProveedor"
        Me.txtDireccionProveedor.Size = New System.Drawing.Size(148, 22)
        Me.txtDireccionProveedor.TabIndex = 190
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(50, 421)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 19)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "Descripcion"
        '
        'txtDescripcionProveedor
        '
        Me.txtDescripcionProveedor.BackColor = System.Drawing.Color.SeaShell
        Me.txtDescripcionProveedor.Location = New System.Drawing.Point(159, 416)
        Me.txtDescripcionProveedor.MaxLength = 50
        Me.txtDescripcionProveedor.Name = "txtDescripcionProveedor"
        Me.txtDescripcionProveedor.Size = New System.Drawing.Size(148, 22)
        Me.txtDescripcionProveedor.TabIndex = 188
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(50, 393)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 19)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(31, 358)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 19)
        Me.Label2.TabIndex = 185
        Me.Label2.Text = "Código Proveedor"
        '
        'txtIdProveedor
        '
        Me.txtIdProveedor.BackColor = System.Drawing.Color.SeaShell
        Me.txtIdProveedor.Location = New System.Drawing.Point(159, 358)
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.ReadOnly = True
        Me.txtIdProveedor.Size = New System.Drawing.Size(29, 22)
        Me.txtIdProveedor.TabIndex = 187
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.BackColor = System.Drawing.Color.SeaShell
        Me.txtNombreProveedor.Location = New System.Drawing.Point(159, 390)
        Me.txtNombreProveedor.MaxLength = 50
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(148, 22)
        Me.txtNombreProveedor.TabIndex = 184
        '
        'lvwProveedores
        '
        Me.lvwProveedores.BackColor = System.Drawing.Color.SeaShell
        Me.lvwProveedores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvwProveedores.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lvwProveedores.FullRowSelect = True
        Me.lvwProveedores.GridLines = True
        Me.lvwProveedores.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvwProveedores.Location = New System.Drawing.Point(12, 12)
        Me.lvwProveedores.Name = "lvwProveedores"
        Me.lvwProveedores.Size = New System.Drawing.Size(1089, 313)
        Me.lvwProveedores.TabIndex = 183
        Me.lvwProveedores.UseCompatibleStateImageBehavior = False
        Me.lvwProveedores.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Codigo Proveedor"
        Me.ColumnHeader1.Width = 177
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 110
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Descripcion"
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Direccion"
        Me.ColumnHeader4.Width = 190
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Telefono"
        Me.ColumnHeader5.Width = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Email"
        Me.ColumnHeader6.Width = 190
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Ciudad"
        Me.ColumnHeader7.Width = 190
        '
        'frmGrillaProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1114, 543)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.cmbPais)
        Me.Controls.Add(Me.cmbProvincia)
        Me.Controls.Add(Me.cmbCiudad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCorreoProveedor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTelefonoProveedor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDireccionProveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescripcionProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIdProveedor)
        Me.Controls.Add(Me.txtNombreProveedor)
        Me.Controls.Add(Me.lvwProveedores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGrillaProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGrillaProveedores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCorreoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefonoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lvwProveedores As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
End Class
