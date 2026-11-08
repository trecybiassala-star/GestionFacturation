<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Produit
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnAjouter = New System.Windows.Forms.Button()
        Me.BtnModifier = New System.Windows.Forms.Button()
        Me.BtnSupprimer = New System.Windows.Forms.Button()
        Me.BtnRechercher = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ProduitBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatabaseFac1DataSet = New WindowsApplication1.DatabaseFac1DataSet()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ProduitBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Designation = New System.Windows.Forms.Label()
        Me.Prix = New System.Windows.Forms.Label()
        Me.Quantité = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitTableAdapter = New WindowsApplication1.DatabaseFac1DataSetTableAdapters.ProduitTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.ProduitBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseFac1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAjouter
        '
        Me.BtnAjouter.Location = New System.Drawing.Point(47, 451)
        Me.BtnAjouter.Name = "BtnAjouter"
        Me.BtnAjouter.Size = New System.Drawing.Size(108, 43)
        Me.BtnAjouter.TabIndex = 0
        Me.BtnAjouter.Text = "Ajouter"
        Me.BtnAjouter.UseVisualStyleBackColor = True
        '
        'BtnModifier
        '
        Me.BtnModifier.Location = New System.Drawing.Point(197, 451)
        Me.BtnModifier.Name = "BtnModifier"
        Me.BtnModifier.Size = New System.Drawing.Size(105, 43)
        Me.BtnModifier.TabIndex = 1
        Me.BtnModifier.Text = "Modifier"
        Me.BtnModifier.UseVisualStyleBackColor = True
        '
        'BtnSupprimer
        '
        Me.BtnSupprimer.Location = New System.Drawing.Point(353, 451)
        Me.BtnSupprimer.Name = "BtnSupprimer"
        Me.BtnSupprimer.Size = New System.Drawing.Size(117, 43)
        Me.BtnSupprimer.TabIndex = 2
        Me.BtnSupprimer.Text = "Supprimer"
        Me.BtnSupprimer.UseVisualStyleBackColor = True
        '
        'BtnRechercher
        '
        Me.BtnRechercher.Location = New System.Drawing.Point(511, 451)
        Me.BtnRechercher.Name = "BtnRechercher"
        Me.BtnRechercher.Size = New System.Drawing.Size(110, 43)
        Me.BtnRechercher.TabIndex = 3
        Me.BtnRechercher.Text = "Rechercher"
        Me.BtnRechercher.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource1, "Designation", True))
        Me.TextBox1.Location = New System.Drawing.Point(97, 97)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(484, 26)
        Me.TextBox1.TabIndex = 4
        '
        'ProduitBindingSource1
        '
        Me.ProduitBindingSource1.DataMember = "Produit"
        Me.ProduitBindingSource1.DataSource = Me.DatabaseFac1DataSet
        '
        'DatabaseFac1DataSet
        '
        Me.DatabaseFac1DataSet.DataSetName = "DatabaseFac1DataSet"
        Me.DatabaseFac1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource2, "Prix", True))
        Me.TextBox2.Location = New System.Drawing.Point(97, 212)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(484, 26)
        Me.TextBox2.TabIndex = 5
        '
        'ProduitBindingSource2
        '
        Me.ProduitBindingSource2.DataMember = "Produit"
        Me.ProduitBindingSource2.DataSource = Me.DatabaseFac1DataSet
        '
        'Designation
        '
        Me.Designation.AutoSize = True
        Me.Designation.Location = New System.Drawing.Point(65, 57)
        Me.Designation.Name = "Designation"
        Me.Designation.Size = New System.Drawing.Size(94, 20)
        Me.Designation.TabIndex = 6
        Me.Designation.Text = "Designation"
        '
        'Prix
        '
        Me.Prix.AutoSize = True
        Me.Prix.Location = New System.Drawing.Point(65, 168)
        Me.Prix.Name = "Prix"
        Me.Prix.Size = New System.Drawing.Size(34, 20)
        Me.Prix.TabIndex = 7
        Me.Prix.Text = "Prix"
        '
        'Quantité
        '
        Me.Quantité.AutoSize = True
        Me.Quantité.Location = New System.Drawing.Point(65, 285)
        Me.Quantité.Name = "Quantité"
        Me.Quantité.Size = New System.Drawing.Size(70, 20)
        Me.Quantité.TabIndex = 8
        Me.Quantité.Text = "Quantité"
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "Quantitestocker", True))
        Me.TextBox3.Location = New System.Drawing.Point(97, 344)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(484, 26)
        Me.TextBox3.TabIndex = 9
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.DatabaseFac1DataSet
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(265, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Gestions des produits"
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(623, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Client"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(623, 180)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 37)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Commande"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(623, 306)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(142, 40)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "DetailCommande"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Produit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(790, 536)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Quantité)
        Me.Controls.Add(Me.Prix)
        Me.Controls.Add(Me.Designation)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnRechercher)
        Me.Controls.Add(Me.BtnSupprimer)
        Me.Controls.Add(Me.BtnModifier)
        Me.Controls.Add(Me.BtnAjouter)
        Me.Name = "Produit"
        Me.Text = "Form1"
        CType(Me.ProduitBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseFac1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnAjouter As System.Windows.Forms.Button
    Friend WithEvents BtnModifier As System.Windows.Forms.Button
    Friend WithEvents BtnSupprimer As System.Windows.Forms.Button
    Friend WithEvents BtnRechercher As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Designation As System.Windows.Forms.Label
    Friend WithEvents Prix As System.Windows.Forms.Label
    Friend WithEvents Quantité As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DatabaseFac1DataSet As WindowsApplication1.DatabaseFac1DataSet
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As WindowsApplication1.DatabaseFac1DataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents ProduitBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
