<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuVenta))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnGestionEnvio = New System.Windows.Forms.Button()
        Me.btnMedioPago = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(52, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 18
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
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnGestionEnvio
        '
        Me.btnGestionEnvio.BackColor = System.Drawing.Color.LightCyan
        Me.btnGestionEnvio.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnGestionEnvio.Image = CType(resources.GetObject("btnGestionEnvio.Image"), System.Drawing.Image)
        Me.btnGestionEnvio.Location = New System.Drawing.Point(29, 145)
        Me.btnGestionEnvio.Name = "btnGestionEnvio"
        Me.btnGestionEnvio.Size = New System.Drawing.Size(147, 49)
        Me.btnGestionEnvio.TabIndex = 2
        Me.btnGestionEnvio.Text = "Gestion venta"
        Me.btnGestionEnvio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGestionEnvio.UseVisualStyleBackColor = False
        '
        'btnMedioPago
        '
        Me.btnMedioPago.BackColor = System.Drawing.Color.LightCyan
        Me.btnMedioPago.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnMedioPago.Image = CType(resources.GetObject("btnMedioPago.Image"), System.Drawing.Image)
        Me.btnMedioPago.Location = New System.Drawing.Point(29, 82)
        Me.btnMedioPago.Name = "btnMedioPago"
        Me.btnMedioPago.Size = New System.Drawing.Size(147, 49)
        Me.btnMedioPago.TabIndex = 1
        Me.btnMedioPago.Text = "Medios P."
        Me.btnMedioPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMedioPago.UseVisualStyleBackColor = False
        '
        'MenuVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(218, 339)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnGestionEnvio)
        Me.Controls.Add(Me.btnMedioPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MenuVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MenuVenta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents btnGestionEnvio As System.Windows.Forms.Button
    Friend WithEvents btnMedioPago As System.Windows.Forms.Button
End Class
