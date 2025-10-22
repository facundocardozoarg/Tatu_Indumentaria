<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMClientes))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstClientes = New System.Windows.Forms.ListBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnInactivo = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtApellidoCliente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDniCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.cmbGenero = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpFechaNac = New System.Windows.Forms.DateTimePicker()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.chkNombre = New System.Windows.Forms.CheckBox()
        Me.chkDni = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(173, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 19)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Nombre _______"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(173, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 19)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Código Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Clientes"
        '
        'lstClientes
        '
        Me.lstClientes.BackColor = System.Drawing.Color.SeaShell
        Me.lstClientes.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lstClientes.FormattingEnabled = True
        Me.lstClientes.ItemHeight = 17
        Me.lstClientes.Location = New System.Drawing.Point(8, 142)
        Me.lstClientes.Name = "lstClientes"
        Me.lstClientes.Size = New System.Drawing.Size(144, 327)
        Me.lstClientes.TabIndex = 110
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.SeaShell
        Me.txtIdCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtIdCliente.Location = New System.Drawing.Point(295, 110)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(29, 25)
        Me.txtIdCliente.TabIndex = 111
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.LightCyan
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(477, 285)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(120, 45)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.LightCyan
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(477, 120)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(120, 45)
        Me.btnNuevo.TabIndex = 12
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnInactivo
        '
        Me.btnInactivo.BackColor = System.Drawing.Color.LightCyan
        Me.btnInactivo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnInactivo.Image = CType(resources.GetObject("btnInactivo.Image"), System.Drawing.Image)
        Me.btnInactivo.Location = New System.Drawing.Point(477, 340)
        Me.btnInactivo.Name = "btnInactivo"
        Me.btnInactivo.Size = New System.Drawing.Size(120, 45)
        Me.btnInactivo.TabIndex = 16
        Me.btnInactivo.Text = "Eliminar"
        Me.btnInactivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInactivo.UseVisualStyleBackColor = False
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.Color.LightCyan
        Me.btnBorrar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.Location = New System.Drawing.Point(477, 395)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(120, 45)
        Me.btnBorrar.TabIndex = 17
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.LightCyan
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(477, 175)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(120, 45)
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.Color.SeaShell
        Me.txtNombreCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtNombreCliente.Location = New System.Drawing.Point(295, 140)
        Me.txtNombreCliente.MaxLength = 50
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(148, 25)
        Me.txtNombreCliente.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(173, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 19)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Apellido _______"
        '
        'txtApellidoCliente
        '
        Me.txtApellidoCliente.BackColor = System.Drawing.Color.SeaShell
        Me.txtApellidoCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtApellidoCliente.Location = New System.Drawing.Point(295, 170)
        Me.txtApellidoCliente.MaxLength = 50
        Me.txtApellidoCliente.Name = "txtApellidoCliente"
        Me.txtApellidoCliente.Size = New System.Drawing.Size(148, 25)
        Me.txtApellidoCliente.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(173, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 19)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Dni  ____________"
        '
        'txtDniCliente
        '
        Me.txtDniCliente.BackColor = System.Drawing.Color.SeaShell
        Me.txtDniCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDniCliente.Location = New System.Drawing.Point(295, 200)
        Me.txtDniCliente.MaxLength = 50
        Me.txtDniCliente.Name = "txtDniCliente"
        Me.txtDniCliente.Size = New System.Drawing.Size(148, 25)
        Me.txtDniCliente.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(173, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 19)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Dirección ______"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.SeaShell
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDireccion.Location = New System.Drawing.Point(295, 230)
        Me.txtDireccion.MaxLength = 50
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(148, 25)
        Me.txtDireccion.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(173, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 19)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Telefono _______"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.SeaShell
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtTelefono.Location = New System.Drawing.Point(295, 260)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(148, 25)
        Me.txtTelefono.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(173, 323)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 19)
        Me.Label8.TabIndex = 121
        Me.Label8.Text = "Fecha Nac _____"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(173, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 19)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "Correo _________"
        '
        'txtCorreo
        '
        Me.txtCorreo.BackColor = System.Drawing.Color.SeaShell
        Me.txtCorreo.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtCorreo.Location = New System.Drawing.Point(295, 290)
        Me.txtCorreo.MaxLength = 50
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(148, 25)
        Me.txtCorreo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(173, 353)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 19)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "Genero ________"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(173, 383)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Ciudad ________"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(173, 413)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 19)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "Provincia ______"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(173, 443)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 19)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "País ___________"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.BackColor = System.Drawing.Color.SeaShell
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(295, 383)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(148, 25)
        Me.cmbCiudad.TabIndex = 9
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.SeaShell
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(295, 413)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(148, 25)
        Me.cmbProvincia.TabIndex = 10
        '
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.Color.SeaShell
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(295, 443)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(148, 25)
        Me.cmbPais.TabIndex = 11
        '
        'cmbGenero
        '
        Me.cmbGenero.BackColor = System.Drawing.Color.SeaShell
        Me.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGenero.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbGenero.FormattingEnabled = True
        Me.cmbGenero.Location = New System.Drawing.Point(295, 353)
        Me.cmbGenero.Name = "cmbGenero"
        Me.cmbGenero.Size = New System.Drawing.Size(148, 25)
        Me.cmbGenero.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(8, 521)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 19)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "Total de Clientes"
        '
        'dtpFechaNac
        '
        Me.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNac.Location = New System.Drawing.Point(295, 320)
        Me.dtpFechaNac.MinimumSize = New System.Drawing.Size(4, 25)
        Me.dtpFechaNac.Name = "dtpFechaNac"
        Me.dtpFechaNac.Size = New System.Drawing.Size(148, 25)
        Me.dtpFechaNac.TabIndex = 7
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.LightCyan
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.Location = New System.Drawing.Point(477, 495)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(120, 45)
        Me.btnVolver.TabIndex = 18
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.LightCyan
        Me.btnEditar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(477, 230)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(120, 45)
        Me.btnEditar.TabIndex = 14
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(8, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 19)
        Me.Label15.TabIndex = 134
        Me.Label15.Text = "Buscar Clientes"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BackColor = System.Drawing.Color.SeaShell
        Me.txtBusqueda.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtBusqueda.Location = New System.Drawing.Point(154, 35)
        Me.txtBusqueda.Multiline = True
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(134, 30)
        Me.txtBusqueda.TabIndex = 132
        '
        'chkNombre
        '
        Me.chkNombre.AutoSize = True
        Me.chkNombre.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.chkNombre.Location = New System.Drawing.Point(311, 57)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(82, 23)
        Me.chkNombre.TabIndex = 244
        Me.chkNombre.Text = "Nombre"
        Me.chkNombre.UseVisualStyleBackColor = True
        '
        'chkDni
        '
        Me.chkDni.AutoSize = True
        Me.chkDni.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.chkDni.Location = New System.Drawing.Point(311, 25)
        Me.chkDni.Name = "chkDni"
        Me.chkDni.Size = New System.Drawing.Size(56, 23)
        Me.chkDni.TabIndex = 243
        Me.chkDni.Text = "DNI"
        Me.chkDni.UseVisualStyleBackColor = True
        '
        'ABMClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 560)
        Me.Controls.Add(Me.chkNombre)
        Me.Controls.Add(Me.chkDni)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.dtpFechaNac)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbGenero)
        Me.Controls.Add(Me.cmbPais)
        Me.Controls.Add(Me.cmbProvincia)
        Me.Controls.Add(Me.cmbCiudad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDniCliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtApellidoCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstClientes)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnInactivo)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ABMClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstClientes As System.Windows.Forms.ListBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnInactivo As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtApellidoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDniCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGenero As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents chkNombre As System.Windows.Forms.CheckBox
    Friend WithEvents chkDni As System.Windows.Forms.CheckBox
End Class
