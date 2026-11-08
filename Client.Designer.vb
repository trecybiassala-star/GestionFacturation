<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Client
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
        Me.Nom = New System.Windows.Forms.Label()
        Me.Prenom = New System.Windows.Forms.Label()
        Me.Telephone = New System.Windows.Forms.Label()
        Me.Adresse = New System.Windows.Forms.Label()
        Me.Email = New System.Windows.Forms.Label()
        Me.BtnAjouter = New System.Windows.Forms.Button()
        Me.BtnModifier = New System.Windows.Forms.Button()
        Me.BtnSupprimer = New System.Windows.Forms.Button()
        Me.BtnRechercher = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ClientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatabaseFac1DataSet1 = New WindowsApplication1.DatabaseFac1DataSet()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ClientBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ClientBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.ClientBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ClientBindingSource5 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClientTableAdapter = New WindowsApplication1.DatabaseFac1DataSetTableAdapters.ClientTableAdapter()
        Me.ClientBindingSource4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.ClientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseFac1DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientBindingSource5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientBindingSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Nom
        '
        Me.Nom.AutoSize = True
        Me.Nom.Location = New System.Drawing.Point(101, 51)
        Me.Nom.Name = "Nom"
        Me.Nom.Size = New System.Drawing.Size(42, 20)
        Me.Nom.TabIndex = 0
        Me.Nom.Text = "Nom"
        '
        'Prenom
        '
        Me.Prenom.AutoSize = True
        Me.Prenom.Location = New System.Drawing.Point(101, 128)
        Me.Prenom.Name = "Prenom"
        Me.Prenom.Size = New System.Drawing.Size(64, 20)
        Me.Prenom.TabIndex = 1
        Me.Prenom.Text = "Prenom"
        '
        'Telephone
        '
        Me.Telephone.AutoSize = True
        Me.Telephone.Location = New System.Drawing.Point(101, 214)
        Me.Telephone.Name = "Telephone"
        Me.Telephone.Size = New System.Drawing.Size(84, 20)
        Me.Telephone.TabIndex = 2
        Me.Telephone.Text = "Telephone"
        '
        'Adresse
        '
        Me.Adresse.AutoSize = True
        Me.Adresse.Location = New System.Drawing.Point(101, 305)
        Me.Adresse.Name = "Adresse"
        Me.Adresse.Size = New System.Drawing.Size(68, 20)
        Me.Adresse.TabIndex = 3
        Me.Adresse.Text = "Adresse"
        '
        'Email
        '
        Me.Email.AutoSize = True
        Me.Email.Location = New System.Drawing.Point(105, 407)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(48, 20)
        Me.Email.TabIndex = 4
        Me.Email.Text = "Email"
        '
        'BtnAjouter
        '
        Me.BtnAjouter.Location = New System.Drawing.Point(98, 588)
        Me.BtnAjouter.Name = "BtnAjouter"
        Me.BtnAjouter.Size = New System.Drawing.Size(91, 33)
        Me.BtnAjouter.TabIndex = 11
        Me.BtnAjouter.Text = "Ajouter"
        Me.BtnAjouter.UseVisualStyleBackColor = True
        '
        'BtnModifier
        '
        Me.BtnModifier.Location = New System.Drawing.Point(240, 588)
        Me.BtnModifier.Name = "BtnModifier"
        Me.BtnModifier.Size = New System.Drawing.Size(107, 33)
        Me.BtnModifier.TabIndex = 12
        Me.BtnModifier.Text = "Modifier"
        Me.BtnModifier.UseVisualStyleBackColor = True
        '
        'BtnSupprimer
        '
        Me.BtnSupprimer.Location = New System.Drawing.Point(404, 588)
        Me.BtnSupprimer.Name = "BtnSupprimer"
        Me.BtnSupprimer.Size = New System.Drawing.Size(96, 33)
        Me.BtnSupprimer.TabIndex = 13
        Me.BtnSupprimer.Text = "Supprimer"
        Me.BtnSupprimer.UseVisualStyleBackColor = True
        '
        'BtnRechercher
        '
        Me.BtnRechercher.Location = New System.Drawing.Point(540, 588)
        Me.BtnRechercher.Name = "BtnRechercher"
        Me.BtnRechercher.Size = New System.Drawing.Size(116, 33)
        Me.BtnRechercher.TabIndex = 14
        Me.BtnRechercher.Text = "Rechercher"
        Me.BtnRechercher.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label1.Location = New System.Drawing.Point(325, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Gestions des clients"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientBindingSource, "Nom", True))
        Me.TextBox1.Location = New System.Drawing.Point(136, 83)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(504, 26)
        Me.TextBox1.TabIndex = 16
        '
        'ClientBindingSource
        '
        Me.ClientBindingSource.DataMember = "Client"
        Me.ClientBindingSource.DataSource = Me.DatabaseFac1DataSet1
        '
        'DatabaseFac1DataSet1
        '
        Me.DatabaseFac1DataSet1.DataSetName = "DatabaseFac1DataSet"
        Me.DatabaseFac1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientBindingSource1, "Prenom", True))
        Me.TextBox2.Location = New System.Drawing.Point(136, 164)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(504, 26)
        Me.TextBox2.TabIndex = 17
        '
        'ClientBindingSource1
        '
        Me.ClientBindingSource1.DataMember = "Client"
        Me.ClientBindingSource1.DataSource = Me.DatabaseFac1DataSet1
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientBindingSource2, "Telephone", True))
        Me.TextBox3.Location = New System.Drawing.Point(136, 261)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(504, 26)
        Me.TextBox3.TabIndex = 18
        '
        'ClientBindingSource2
        '
        Me.ClientBindingSource2.DataMember = "Client"
        Me.ClientBindingSource2.DataSource = Me.DatabaseFac1DataSet1
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientBindingSource3, "Adresse", True))
        Me.TextBox4.Location = New System.Drawing.Point(136, 352)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(504, 26)
        Me.TextBox4.TabIndex = 19
        '
        'ClientBindingSource3
        '
        Me.ClientBindingSource3.DataMember = "Client"
        Me.ClientBindingSource3.DataSource = Me.DatabaseFac1DataSet1
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientBindingSource5, "Email", True))
        Me.TextBox5.Location = New System.Drawing.Point(136, 450)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(504, 26)
        Me.TextBox5.TabIndex = 20
        '
        'ClientBindingSource5
        '
        Me.ClientBindingSource5.DataMember = "Client"
        Me.ClientBindingSource5.DataSource = Me.DatabaseFac1DataSet1
        '
        'ClientTableAdapter
        '
        Me.ClientTableAdapter.ClearBeforeFill = True
        '
        'ClientBindingSource4
        '
        Me.ClientBindingSource4.DataMember = "Client"
        Me.ClientBindingSource4.DataSource = Me.DatabaseFac1DataSet1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(896, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 65)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Deconnexion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(896, 177)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 68)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Commande"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(896, 284)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(146, 63)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "DetailCommande"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(896, 407)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(146, 61)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Produits"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(1080, 651)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnRechercher)
        Me.Controls.Add(Me.BtnSupprimer)
        Me.Controls.Add(Me.BtnModifier)
        Me.Controls.Add(Me.BtnAjouter)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.Adresse)
        Me.Controls.Add(Me.Telephone)
        Me.Controls.Add(Me.Prenom)
        Me.Controls.Add(Me.Nom)
        Me.Name = "Client"
        Me.Text = "z"
        CType(Me.ClientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseFac1DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientBindingSource5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientBindingSource4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Nom As System.Windows.Forms.Label
    Friend WithEvents Prenom As System.Windows.Forms.Label
    Friend WithEvents Telephone As System.Windows.Forms.Label
    Friend WithEvents Adresse As System.Windows.Forms.Label
    Friend WithEvents Email As System.Windows.Forms.Label
    Friend WithEvents BtnAjouter As System.Windows.Forms.Button
    Friend WithEvents BtnModifier As System.Windows.Forms.Button
    Friend WithEvents BtnSupprimer As System.Windows.Forms.Button
    Friend WithEvents BtnRechercher As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents DatabaseFac1DataSet1 As WindowsApplication1.DatabaseFac1DataSet
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ClientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClientTableAdapter As WindowsApplication1.DatabaseFac1DataSetTableAdapters.ClientTableAdapter
    Friend WithEvents ClientBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ClientBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents ClientBindingSource3 As System.Windows.Forms.BindingSource
    Friend WithEvents ClientBindingSource4 As System.Windows.Forms.BindingSource
    Friend WithEvents ClientBindingSource5 As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
