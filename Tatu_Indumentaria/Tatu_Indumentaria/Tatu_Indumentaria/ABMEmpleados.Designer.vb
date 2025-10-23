<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMEmpleados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMEmpleados))
        Me.txtDniEmpleado = New System.Windows.Forms.TextBox()
        Me.txtCorreoEmpleado = New System.Windows.Forms.TextBox()
        Me.dtpFechaNac = New System.Windows.Forms.DateTimePicker()
        Me.btnGrillaEmpleados = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.txtTelefonoEmpleado = New System.Windows.Forms.TextBox()
        Me.txtDireccionEmpleado = New System.Windows.Forms.TextBox()
        Me.txtApellidoEmpleado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstEmpleados = New System.Windows.Forms.ListBox()
        Me.txtIdEmpleado = New System.Windows.Forms.TextBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.cmbGenero = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnInactivo = New System.Windows.Forms.Button()
        Me.chkNombre = New System.Windows.Forms.CheckBox()
        Me.chkDni = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDniEmpleado
        '
        Me.txtDniEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtDniEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDniEmpleado.Location = New System.Drawing.Point(295, 200)
        Me.txtDniEmpleado.MaxLength = 50
        Me.txtDniEmpleado.Name = "txtDniEmpleado"
        Me.txtDniEmpleado.Size = New System.Drawing.Size(148, 25)
        Me.txtDniEmpleado.TabIndex = 3
        '
        'txtCorreoEmpleado
        '
        Me.txtCorreoEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtCorreoEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtCorreoEmpleado.Location = New System.Drawing.Point(295, 290)
        Me.txtCorreoEmpleado.MaxLength = 50
        Me.txtCorreoEmpleado.Name = "txtCorreoEmpleado"
        Me.txtCorreoEmpleado.Size = New System.Drawing.Size(148, 25)
        Me.txtCorreoEmpleado.TabIndex = 7
        '
        'dtpFechaNac
        '
        Me.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNac.Location = New System.Drawing.Point(295, 320)
        Me.dtpFechaNac.MinimumSize = New System.Drawing.Size(4, 25)
        Me.dtpFechaNac.Name = "dtpFechaNac"
        Me.dtpFechaNac.Size = New System.Drawing.Size(148, 25)
        Me.dtpFechaNac.TabIndex = 6
        '
        'btnGrillaEmpleados
        '
        Me.btnGrillaEmpleados.BackColor = System.Drawing.Color.LightCyan
        Me.btnGrillaEmpleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnGrillaEmpleados.Location = New System.Drawing.Point(329, 499)
        Me.btnGrillaEmpleados.Name = "btnGrillaEmpleados"
        Me.btnGrillaEmpleados.Size = New System.Drawing.Size(120, 49)
        Me.btnGrillaEmpleados.TabIndex = 229
        Me.btnGrillaEmpleados.Text = "Detalle Empleados"
        Me.btnGrillaEmpleados.UseVisualStyleBackColor = False
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
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.Color.SeaShell
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(295, 440)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(148, 25)
        Me.cmbPais.TabIndex = 11
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BackColor = System.Drawing.Color.SeaShell
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(295, 410)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(148, 25)
        Me.cmbProvincia.TabIndex = 10
        '
        'cmbCiudad
        '
        Me.cmbCiudad.BackColor = System.Drawing.Color.SeaShell
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(295, 380)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(148, 25)
        Me.cmbCiudad.TabIndex = 9
        '
        'txtTelefonoEmpleado
        '
        Me.txtTelefonoEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtTelefonoEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtTelefonoEmpleado.Location = New System.Drawing.Point(295, 260)
        Me.txtTelefonoEmpleado.MaxLength = 50
        Me.txtTelefonoEmpleado.Name = "txtTelefonoEmpleado"
        Me.txtTelefonoEmpleado.Size = New System.Drawing.Size(148, 25)
        Me.txtTelefonoEmpleado.TabIndex = 5
        '
        'txtDireccionEmpleado
        '
        Me.txtDireccionEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtDireccionEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDireccionEmpleado.Location = New System.Drawing.Point(295, 230)
        Me.txtDireccionEmpleado.MaxLength = 50
        Me.txtDireccionEmpleado.Name = "txtDireccionEmpleado"
        Me.txtDireccionEmpleado.Size = New System.Drawing.Size(148, 25)
        Me.txtDireccionEmpleado.TabIndex = 4
        '
        'txtApellidoEmpleado
        '
        Me.txtApellidoEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtApellidoEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtApellidoEmpleado.Location = New System.Drawing.Point(295, 170)
        Me.txtApellidoEmpleado.MaxLength = 50
        Me.txtApellidoEmpleado.Name = "txtApellidoEmpleado"
        Me.txtApellidoEmpleado.Size = New System.Drawing.Size(148, 25)
        Me.txtApellidoEmpleado.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(173, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 19)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Código Empleado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 19)
        Me.Label1.TabIndex = 208
        Me.Label1.Text = "Empleados"
        '
        'lstEmpleados
        '
        Me.lstEmpleados.BackColor = System.Drawing.Color.SeaShell
        Me.lstEmpleados.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lstEmpleados.FormattingEnabled = True
        Me.lstEmpleados.ItemHeight = 17
        Me.lstEmpleados.Location = New System.Drawing.Point(8, 142)
        Me.lstEmpleados.Name = "lstEmpleados"
        Me.lstEmpleados.Size = New System.Drawing.Size(144, 327)
        Me.lstEmpleados.TabIndex = 213
        '
        'txtIdEmpleado
        '
        Me.txtIdEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtIdEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtIdEmpleado.Location = New System.Drawing.Point(295, 110)
        Me.txtIdEmpleado.Name = "txtIdEmpleado"
        Me.txtIdEmpleado.ReadOnly = True
        Me.txtIdEmpleado.Size = New System.Drawing.Size(29, 25)
        Me.txtIdEmpleado.TabIndex = 214
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
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.BackColor = System.Drawing.Color.SeaShell
        Me.txtNombreEmpleado.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(295, 140)
        Me.txtNombreEmpleado.MaxLength = 50
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(148, 25)
        Me.txtNombreEmpleado.TabIndex = 1
        '
        'cmbGenero
        '
        Me.cmbGenero.BackColor = System.Drawing.Color.SeaShell
        Me.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGenero.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbGenero.FormattingEnabled = True
        Me.cmbGenero.Location = New System.Drawing.Point(295, 350)
        Me.cmbGenero.Name = "cmbGenero"
        Me.cmbGenero.Size = New System.Drawing.Size(148, 25)
        Me.cmbGenero.TabIndex = 8
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
        'chkNombre
        '
        Me.chkNombre.AutoSize = True
        Me.chkNombre.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.chkNombre.Location = New System.Drawing.Point(311, 57)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(82, 23)
        Me.chkNombre.TabIndex = 242
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
        Me.chkDni.TabIndex = 241
        Me.chkDni.Text = "DNI"
        Me.chkDni.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(8, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 19)
        Me.Label15.TabIndex = 240
        Me.Label15.Text = "Buscar Clientes"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.LightCyan
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(477, 35)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(120, 40)
        Me.btnBuscar.TabIndex = 239
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BackColor = System.Drawing.Color.SeaShell
        Me.txtBusqueda.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtBusqueda.Location = New System.Drawing.Point(154, 35)
        Me.txtBusqueda.Multiline = True
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(134, 30)
        Me.txtBusqueda.TabIndex = 238
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(173, 443)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 19)
        Me.Label13.TabIndex = 253
        Me.Label13.Text = "País ___________"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(173, 413)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 19)
        Me.Label12.TabIndex = 252
        Me.Label12.Text = "Provincia ______"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(173, 383)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 251
        Me.Label11.Text = "Ciudad ________"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(173, 353)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 19)
        Me.Label10.TabIndex = 249
        Me.Label10.Text = "Genero ________"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(173, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 19)
        Me.Label9.TabIndex = 250
        Me.Label9.Text = "Correo _________"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(173, 323)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 19)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Fecha Nac _____"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(173, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 19)
        Me.Label7.TabIndex = 247
        Me.Label7.Text = "Telefono _______"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(173, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 19)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "Dirección ______"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(173, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 19)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "Dni  ____________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(173, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 19)
        Me.Label4.TabIndex = 244
        Me.Label4.Text = "Apellido _______"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(173, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 19)
        Me.Label3.TabIndex = 243
        Me.Label3.Text = "Nombre _______"
        '
        'ABMEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(610, 560)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkNombre)
        Me.Controls.Add(Me.chkDni)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.btnInactivo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.cmbGenero)
        Me.Controls.Add(Me.txtDniEmpleado)
        Me.Controls.Add(Me.txtCorreoEmpleado)
        Me.Controls.Add(Me.dtpFechaNac)
        Me.Controls.Add(Me.btnGrillaEmpleados)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.cmbPais)
        Me.Controls.Add(Me.cmbProvincia)
        Me.Controls.Add(Me.cmbCiudad)
        Me.Controls.Add(Me.txtTelefonoEmpleado)
        Me.Controls.Add(Me.txtDireccionEmpleado)
        Me.Controls.Add(Me.txtApellidoEmpleado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstEmpleados)
        Me.Controls.Add(Me.txtIdEmpleado)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtNombreEmpleado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ABMEmpleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empleados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDniEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtCorreoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGrillaEmpleados As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents txtTelefonoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstEmpleados As System.Windows.Forms.ListBox
    Friend WithEvents txtIdEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents cmbGenero As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnInactivo As System.Windows.Forms.Button
    Friend WithEvents chkNombre As System.Windows.Forms.CheckBox
    Friend WithEvents chkDni As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
