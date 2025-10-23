<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Localidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Localidades))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnCiudad = New System.Windows.Forms.Button()
        Me.btnProvincia = New System.Windows.Forms.Button()
        Me.btnPais = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(52, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Seleccione uno"
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.LightCyan
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.Location = New System.Drawing.Point(45, 278)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(120, 49)
        Me.btnVolver.TabIndex = 4
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnCiudad
        '
        Me.btnCiudad.BackColor = System.Drawing.Color.LightCyan
        Me.btnCiudad.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnCiudad.Image = CType(resources.GetObject("btnCiudad.Image"), System.Drawing.Image)
        Me.btnCiudad.Location = New System.Drawing.Point(29, 209)
        Me.btnCiudad.Name = "btnCiudad"
        Me.btnCiudad.Size = New System.Drawing.Size(147, 49)
        Me.btnCiudad.TabIndex = 3
        Me.btnCiudad.Text = "Ciudad"
        Me.btnCiudad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCiudad.UseVisualStyleBackColor = False
        '
        'btnProvincia
        '
        Me.btnProvincia.BackColor = System.Drawing.Color.LightCyan
        Me.btnProvincia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnProvincia.Image = CType(resources.GetObject("btnProvincia.Image"), System.Drawing.Image)
        Me.btnProvincia.Location = New System.Drawing.Point(29, 145)
        Me.btnProvincia.Name = "btnProvincia"
        Me.btnProvincia.Size = New System.Drawing.Size(147, 49)
        Me.btnProvincia.TabIndex = 2
        Me.btnProvincia.Text = "Provincia"
        Me.btnProvincia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProvincia.UseVisualStyleBackColor = False
        '
        'btnPais
        '
        Me.btnPais.BackColor = System.Drawing.Color.LightCyan
        Me.btnPais.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnPais.Image = CType(resources.GetObject("btnPais.Image"), System.Drawing.Image)
        Me.btnPais.Location = New System.Drawing.Point(29, 82)
        Me.btnPais.Name = "btnPais"
        Me.btnPais.Size = New System.Drawing.Size(147, 49)
        Me.btnPais.TabIndex = 1
        Me.btnPais.Text = "Pais"
        Me.btnPais.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPais.UseVisualStyleBackColor = False
        '
        'Localidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(218, 339)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnCiudad)
        Me.Controls.Add(Me.btnProvincia)
        Me.Controls.Add(Me.btnPais)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Localidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Localidades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents btnCiudad As System.Windows.Forms.Button
    Friend WithEvents btnProvincia As System.Windows.Forms.Button
    Friend WithEvents btnPais As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
