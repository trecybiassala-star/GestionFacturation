<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailCommande
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DetailCommandeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatabaseFac1DataSet = New WindowsApplication1.DatabaseFac1DataSet()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BtnAjouter = New System.Windows.Forms.Button()
        Me.BtnModifier = New System.Windows.Forms.Button()
        Me.BtnSupprimer = New System.Windows.Forms.Button()
        Me.BtnRechercher = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.BtnCalculer = New System.Windows.Forms.Button()
        Me.DetailCommandeTableAdapter = New WindowsApplication1.DatabaseFac1DataSetTableAdapters.DetailCommandeTableAdapter()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnCommande = New System.Windows.Forms.Button()
        Me.BtnEnregistrer = New System.Windows.Forms.Button()
        Me.BtnImprimer = New System.Windows.Forms.Button()
        CType(Me.DetailCommandeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseFac1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(154, 61)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 28)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Commande"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Produit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Quantité"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(436, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Prix"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(154, 144)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 28)
        Me.ComboBox2.TabIndex = 6
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DetailCommandeBindingSource, "Quantite", True))
        Me.TextBox1.Location = New System.Drawing.Point(154, 233)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(163, 26)
        Me.TextBox1.TabIndex = 7
        '
        'DetailCommandeBindingSource
        '
        Me.DetailCommandeBindingSource.DataMember = "DetailCommande"
        Me.DetailCommandeBindingSource.DataSource = Me.DatabaseFac1DataSet
        '
        'DatabaseFac1DataSet
        '
        Me.DatabaseFac1DataSet.DataSetName = "DatabaseFac1DataSet"
        Me.DatabaseFac1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DatabaseFac1DataSet, "DetailCommande.PrixUnitaire", True))
        Me.TextBox2.Location = New System.Drawing.Point(569, 64)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(163, 26)
        Me.TextBox2.TabIndex = 8
        '
        'BtnAjouter
        '
        Me.BtnAjouter.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnAjouter.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BtnAjouter.Location = New System.Drawing.Point(161, 345)
        Me.BtnAjouter.Name = "BtnAjouter"
        Me.BtnAjouter.Size = New System.Drawing.Size(139, 42)
        Me.BtnAjouter.TabIndex = 9
        Me.BtnAjouter.Text = "Ajouter"
        Me.BtnAjouter.UseVisualStyleBackColor = False
        '
        'BtnModifier
        '
        Me.BtnModifier.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnModifier.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BtnModifier.Location = New System.Drawing.Point(446, 345)
        Me.BtnModifier.Name = "BtnModifier"
        Me.BtnModifier.Size = New System.Drawing.Size(106, 42)
        Me.BtnModifier.TabIndex = 10
        Me.BtnModifier.Text = "Modifier"
        Me.BtnModifier.UseVisualStyleBackColor = False
        '
        'BtnSupprimer
        '
        Me.BtnSupprimer.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnSupprimer.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BtnSupprimer.Location = New System.Drawing.Point(680, 345)
        Me.BtnSupprimer.Name = "BtnSupprimer"
        Me.BtnSupprimer.Size = New System.Drawing.Size(117, 42)
        Me.BtnSupprimer.TabIndex = 11
        Me.BtnSupprimer.Text = "Supprimer"
        Me.BtnSupprimer.UseVisualStyleBackColor = False
        '
        'BtnRechercher
        '
        Me.BtnRechercher.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnRechercher.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BtnRechercher.Location = New System.Drawing.Point(50, 557)
        Me.BtnRechercher.Name = "BtnRechercher"
        Me.BtnRechercher.Size = New System.Drawing.Size(108, 42)
        Me.BtnRechercher.TabIndex = 12
        Me.BtnRechercher.Text = "Rechercher"
        Me.BtnRechercher.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(442, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Détails des commandes"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Menu
        Me.Button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Button1.Location = New System.Drawing.Point(67, 460)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 42)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Ajouter"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 442)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Sous Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(436, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Remise"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(430, 442)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(442, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 20)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "TVA"
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DatabaseFac1DataSet, "DetailCommande.SousTotal", True))
        Me.TextBox3.Location = New System.Drawing.Point(174, 442)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(126, 26)
        Me.TextBox3.TabIndex = 18
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DatabaseFac1DataSet, "DetailCommande.Remise", True))
        Me.TextBox4.Location = New System.Drawing.Point(569, 141)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(167, 26)
        Me.TextBox4.TabIndex = 19
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DatabaseFac1DataSet, "DetailCommande.TVA", True))
        Me.TextBox5.Location = New System.Drawing.Point(595, 227)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(155, 26)
        Me.TextBox5.TabIndex = 20
        '
        'TextBox6
        '
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DatabaseFac1DataSet, "DetailCommande.MontantTva", True))
        Me.TextBox6.Location = New System.Drawing.Point(936, 64)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(156, 26)
        Me.TextBox6.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(804, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 20)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Montant TVA"
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DatabaseFac1DataSet, "DetailCommande.Total", True))
        Me.TextBox7.Location = New System.Drawing.Point(550, 442)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(266, 26)
        Me.TextBox7.TabIndex = 23
        '
        'BtnCalculer
        '
        Me.BtnCalculer.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnCalculer.Location = New System.Drawing.Point(510, 567)
        Me.BtnCalculer.Name = "BtnCalculer"
        Me.BtnCalculer.Size = New System.Drawing.Size(111, 42)
        Me.BtnCalculer.TabIndex = 24
        Me.BtnCalculer.Text = "Calculer"
        Me.BtnCalculer.UseVisualStyleBackColor = False
        '
        'DetailCommandeTableAdapter
        '
        Me.DetailCommandeTableAdapter.ClearBeforeFill = True
        '
        'BtnCommande
        '
        Me.BtnCommande.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnCommande.Location = New System.Drawing.Point(246, 567)
        Me.BtnCommande.Name = "BtnCommande"
        Me.BtnCommande.Size = New System.Drawing.Size(185, 35)
        Me.BtnCommande.TabIndex = 25
        Me.BtnCommande.Text = "commande"
        Me.BtnCommande.UseVisualStyleBackColor = False
        '
        'BtnEnregistrer
        '
        Me.BtnEnregistrer.Location = New System.Drawing.Point(739, 567)
        Me.BtnEnregistrer.Name = "BtnEnregistrer"
        Me.BtnEnregistrer.Size = New System.Drawing.Size(115, 41)
        Me.BtnEnregistrer.TabIndex = 26
        Me.BtnEnregistrer.Text = "Enregistrer"
        Me.BtnEnregistrer.UseVisualStyleBackColor = True
        '
        'BtnImprimer
        '
        Me.BtnImprimer.Location = New System.Drawing.Point(953, 567)
        Me.BtnImprimer.Name = "BtnImprimer"
        Me.BtnImprimer.Size = New System.Drawing.Size(119, 43)
        Me.BtnImprimer.TabIndex = 27
        Me.BtnImprimer.Text = "Imprimer"
        Me.BtnImprimer.UseVisualStyleBackColor = True
        '
        'DetailCommande
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(1194, 670)
        Me.Controls.Add(Me.BtnImprimer)
        Me.Controls.Add(Me.BtnEnregistrer)
        Me.Controls.Add(Me.BtnCommande)
        Me.Controls.Add(Me.BtnCalculer)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnRechercher)
        Me.Controls.Add(Me.BtnSupprimer)
        Me.Controls.Add(Me.BtnModifier)
        Me.Controls.Add(Me.BtnAjouter)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "DetailCommande"
        Me.Text = "So"
        CType(Me.DetailCommandeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseFac1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnAjouter As System.Windows.Forms.Button
    Friend WithEvents BtnModifier As System.Windows.Forms.Button
    Friend WithEvents BtnSupprimer As System.Windows.Forms.Button
    Friend WithEvents BtnRechercher As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents BtnCalculer As System.Windows.Forms.Button
    Friend WithEvents DatabaseFac1DataSet1 As WindowsApplication1.DatabaseFac1DataSet
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DatabaseFac1DataSet As WindowsApplication1.DatabaseFac1DataSet
    Friend WithEvents DetailCommandeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DetailCommandeTableAdapter As WindowsApplication1.DatabaseFac1DataSetTableAdapters.DetailCommandeTableAdapter
    Friend WithEvents BtnCommande As System.Windows.Forms.Button
    Friend WithEvents BtnEnregistrer As System.Windows.Forms.Button
    Friend WithEvents BtnImprimer As System.Windows.Forms.Button
End Class
