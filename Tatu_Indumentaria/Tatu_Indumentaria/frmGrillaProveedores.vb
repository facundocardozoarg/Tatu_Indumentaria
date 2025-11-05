Imports MySql.Data.MySqlClient

Public Class frmGrillaProveedores
    Public CiudadElegida As String
    Public id_ciudad As Double
    Public ProvinciaElegida As String


    Sub LimpiarForms()
        txtIdProveedor.Text = ""
        txtNombreProveedor.Text = ""
        txtDescripcionProveedor.Text = ""
        txtDireccionProveedor.Text = ""
        cmbCiudad.SelectedIndex = -1
        txtTelefonoProveedor.Text = ""
        txtCorreoProveedor.Text = ""
    End Sub

    Sub HabilitarCampos()
        txtIdProveedor.ReadOnly = True
        txtNombreProveedor.ReadOnly = False
        txtDescripcionProveedor.ReadOnly = False
        txtDireccionProveedor.ReadOnly = False
        cmbCiudad.Enabled = True
        txtTelefonoProveedor.ReadOnly = False
        txtCorreoProveedor.ReadOnly = False
    End Sub

    Sub DeshabilitarCampos()
        txtIdProveedor.ReadOnly = True
        txtNombreProveedor.ReadOnly = True
        txtDescripcionProveedor.ReadOnly = True
        txtDireccionProveedor.ReadOnly = True
        cmbCiudad.Enabled = False
        txtTelefonoProveedor.ReadOnly = True
        txtCorreoProveedor.ReadOnly = True
    End Sub

    Sub CargarCiudad()
        Try

            cmbCiudad.Items.Clear()
            'Ejecuto la coneccion a la BD
            Conexion.Open()

            'Declaro obejto comand
            Dim comando As New MySqlCommand

            'Configuro la conexion activa.
            comando.Connection = Conexion

            'Indicuto el tipo de instruccion
            comando.CommandType = CommandType.Text

            'Sql muestro nombre de categoria y los ordeno.
            comando.CommandText = "select nombre_ciudad from ciudad join provincia on ciudad.id_provincia = provincia.id_provincia where nombre_provincia = '" & ProvinciaElegida & "';"


            'Declaro Objeto DataReader
            Dim drCiudad As MySqlDataReader

            'Traigo datos desde BD
            drCiudad = comando.ExecuteReader


            'Verifico que haya registros
            If drCiudad.HasRows Then
                'si encuentra registros limpio el list.


                'Recorro el data reader
                Do While drCiudad.Read
                    'Agrego los nombres de categoria a los item del list
                    cmbCiudad.Items.Add(drCiudad("nombre_ciudad"))
                Loop
            End If
            'Cierro Data reader
            drCiudad.Close()

            'Cierro Conexion
            Conexion.Close()
        Catch ex As Exception
            'Imprimo mensaje en caso de error
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Sub CargarGrilla(ByVal Orden As String)
        Try
            'conecto a la BD
            Conexion.Open()

            'declaro objeto comand
            Dim Comando As New MySqlCommand

            'indico cual es la conexion activa
            Comando.Connection = Conexion

            'indico el tipo instruccion
            Comando.CommandType = CommandType.Text

            'cargo la instruccion SQL
            Comando.CommandText = "select proveedor.*, ciudad.nombre_ciudad from proveedor JOIN ciudad ON proveedor.id_ciudad = ciudad.id_ciudad order by " & Orden & ";"

            'declaro objeto DataReader
            Dim drProveedor As MySqlDataReader

            'traido los datos desde la BD
            drProveedor = Comando.ExecuteReader

            'consulto si traigo
            If drProveedor.HasRows Then
                'primero limpio
                lvwProveedores.Items.Clear()

                'recorro el dreader y cargo
                Dim LV As New ListViewItem

                Do While drProveedor.Read
                    LV = lvwProveedores.Items.Add(drProveedor("id_proveedor"))
                    LV.SubItems.Add(drProveedor("nombre_proveedor"))
                    LV.SubItems.Add(drProveedor("descripcion_proveedor"))
                    LV.SubItems.Add(drProveedor("direccion_proveedor"))
                    LV.SubItems.Add(drProveedor("telefono"))
                    LV.SubItems.Add(drProveedor("email"))
                    LV.SubItems.Add(drProveedor("nombre_ciudad"))
                Loop

                drProveedor.Close()

            End If

            Conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Conexion.Close()
        End Try
    End Sub

    Private Sub frmGrillaProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Conectar()
        'cargo grilla
        Call CargarGrilla("nombre_proveedor")
    End Sub

    Private Sub lvwProveedores_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwProveedores.ColumnClick
        'depende la columna que selecciono, ordeno la grilla
        Select Case e.Column
            Case 0
                Call CargarGrilla("id_proveedor")
            Case 1
                Call CargarGrilla("nombre_proveedor")
            Case 2
                Call CargarGrilla("descripcion_proveedor")
            Case 3
                Call CargarGrilla("direccion_proveedor")
            Case 4
                Call CargarGrilla("telefono")
            Case 5
                Call CargarGrilla("email")
            Case 6
                Call CargarGrilla("nombre_ciudad")
        End Select
    End Sub

    Private Sub lvwProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwProveedores.SelectedIndexChanged
        'traigo datos seleccionados a los txt
        txtIdProveedor.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(0).Text.ToString
        txtNombreProveedor.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(1).Text.ToString
        txtDescripcionProveedor.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(2).Text.ToString
        txtDireccionProveedor.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(3).Text.ToString
        txtTelefonoProveedor.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(4).Text.ToString
        txtCorreoProveedor.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(5).Text.ToString
        cmbCiudad.Text = lvwProveedores.Items(lvwProveedores.FocusedItem.Index).SubItems(6).Text.ToString
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
        ABMProveedores.Show()
    End Sub
End Class