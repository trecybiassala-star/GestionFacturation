Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Access

Class DetailCommande
    '==========================================================
    ' CONNEXION
    '===Public=======================================================
    Private Function GetConnection() As OleDbConnection

        Return New OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" & System.Windows.Forms.Application.StartupPath & "\DatabaseFac1.mdb")

    End Function


    '==========================================================
    ' CHARGEMENT DU FORMULAIRE
    '==========================================================
    Private Sub DetailCommande_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ChargerCommandes()
        ChargerProduits()

        TextBox2.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True

    End Sub


    '==========================================================
    ' CHARGER LES COMMANDES
    '==========================================================
    Private Sub ChargerCommandes()

        ComboBox1.Items.Clear()

        Dim cnn As OleDbConnection = GetConnection()

        Try

            Dim cmd As New OleDbCommand(
                "SELECT IdCommande FROM Commande ORDER BY IdCommande",
                cnn)

            cnn.Open()

            Dim dtr As OleDbDataReader = cmd.ExecuteReader()

            While dtr.Read()

                If Not IsDBNull(dtr("IdCommande")) Then
                    ComboBox1.Items.Add(
                        dtr("IdCommande").ToString())
                End If

            End While

            dtr.Close()

        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors du chargement des commandes :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub


    '==========================================================
    ' CHARGER LES PRODUITS
    '==========================================================
    Private Sub ChargerProduits()

        ComboBox2.Items.Clear()

        Dim cnn As OleDbConnection = GetConnection()

        Try

            Dim cmd As New OleDbCommand(
                "SELECT IdProduit FROM Produit ORDER BY IdProduit",
                cnn)

            cnn.Open()

            Dim dtr As OleDbDataReader = cmd.ExecuteReader()

            While dtr.Read()

                If Not IsDBNull(dtr("IdProduit")) Then
                    ComboBox2.Items.Add(
                        dtr("IdProduit").ToString())
                End If

            End While

            dtr.Close()

        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors du chargement des produits :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub


    '==========================================================
    ' CHOIX DU PRODUIT
    ' RÉCUPÉRER LE PRIX
    '==========================================================
    Private Sub ComboBox2_SelectedIndexChanged(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim idProduit As Integer

        If Not Integer.TryParse(
            ComboBox2.Text.Trim(),
            idProduit) Then

            Exit Sub

        End If

        Dim cnn As OleDbConnection = GetConnection()

        Try

            Dim cmd As New OleDbCommand(
                "SELECT Prix FROM Produit WHERE IdProduit = ?",
                cnn)

            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value = idProduit

            cnn.Open()

            Dim dtr As OleDbDataReader =
                cmd.ExecuteReader()

            If dtr.Read() Then

                If Not IsDBNull(dtr("Prix")) Then

                    TextBox2.Text =
                        Convert.ToDecimal(
                            dtr("Prix")).ToString("0.00")

                Else

                    TextBox2.Clear()

                End If

            Else

                TextBox2.Clear()

                MessageBox.Show(
                    "Aucun prix trouvé pour ce produit.")

            End If

            dtr.Close()

        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la récupération du prix :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub


    '==========================================================
    ' CALCUL AUTOMATIQUE DU MONTANT TVA
    '
    ' TextBox3 = SousTotal
    ' TextBox4 = Remise
    ' TextBox5 = TVA
    ' TextBox6 = MontantTva
    ' TextBox7 = Total
    '==========================================================
    Private Sub TextBox3_TextChanged(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles TextBox3.TextChanged

        CalculerMontantTVAAutomatique()

    End Sub


    Private Sub TextBox4_TextChanged(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles TextBox4.TextChanged

        CalculerMontantTVAAutomatique()

    End Sub


    Private Sub TextBox5_TextChanged(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles TextBox5.TextChanged

        CalculerMontantTVAAutomatique()

    End Sub


    '==========================================================
    ' CALCUL AUTOMATIQUE DU MONTANT TVA
    '==========================================================
    Private Sub CalculerMontantTVAAutomatique()

        Dim sousTotal As Decimal
        Dim remise As Decimal
        Dim tva As Decimal

        '----------------------------------------------
        ' Sous-total
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox3.Text,
            sousTotal) Then

            TextBox6.Clear()
            Exit Sub

        End If


        '----------------------------------------------
        ' Remise
        '----------------------------------------------
        If TextBox4.Text.Trim() = "" Then

            remise = 0

        ElseIf Not Decimal.TryParse(
            TextBox4.Text,
            remise) Then

            TextBox6.Clear()
            Exit Sub

        End If


        '----------------------------------------------
        ' TVA
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox5.Text,
            tva) Then

            TextBox6.Clear()
            Exit Sub

        End If


        '----------------------------------------------
        ' Vérification
        '----------------------------------------------
        If remise < 0 Or remise > 100 Then

            TextBox6.Clear()
            Exit Sub

        End If


        If tva < 0 Or tva > 100 Then

            TextBox6.Clear()
            Exit Sub

        End If


        '----------------------------------------------
        ' Montant après remise
        '----------------------------------------------
        Dim montantApresRemise As Decimal

        montantApresRemise =
            sousTotal -
            (sousTotal * remise / 100)


        '----------------------------------------------
        ' Montant TVA
        '----------------------------------------------
        Dim montantTVA As Decimal

        montantTVA =
            montantApresRemise * tva / 100


        TextBox6.Text =
            montantTVA.ToString("0.00")

    End Sub


    '==========================================================
    ' BOUTON CALCULER
    '
    ' Calcule le TOTAL
    '==========================================================
    Private Sub BtnCalculer_Click(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BtnCalculer.Click

        CalculerTotal()

    End Sub


    '==========================================================
    ' CALCUL DU TOTAL
    '==========================================================
    Private Function CalculerTotal() As Boolean

        Dim sousTotal As Decimal
        Dim remise As Decimal
        Dim tva As Decimal
        Dim montantTVA As Decimal


        '----------------------------------------------
        ' Sous-total
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox3.Text,
            sousTotal) Then

            MessageBox.Show(
                "Veuillez saisir un sous-total valide.")

            TextBox3.Focus()

            Return False

        End If


        '----------------------------------------------
        ' Remise
        '----------------------------------------------
        If TextBox4.Text.Trim() = "" Then

            remise = 0

        ElseIf Not Decimal.TryParse(
            TextBox4.Text,
            remise) Then

            MessageBox.Show(
                "La remise est invalide.")

            TextBox4.Focus()

            Return False

        End If


        '----------------------------------------------
        ' TVA
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox5.Text,
            tva) Then

            MessageBox.Show(
                "La TVA est invalide.")

            TextBox5.Focus()

            Return False

        End If


        '----------------------------------------------
        ' Vérification
        '----------------------------------------------
        If remise < 0 Or remise > 100 Then

            MessageBox.Show(
                "La remise doit être comprise entre 0 et 100 %.")

            TextBox4.Focus()

            Return False

        End If


        If tva < 0 Or tva > 100 Then

            MessageBox.Show(
                "La TVA doit être comprise entre 0 et 100 %.")

            TextBox5.Focus()

            Return False

        End If


        '----------------------------------------------
        ' Montant après remise
        '----------------------------------------------
        Dim montantApresRemise As Decimal

        montantApresRemise =
            sousTotal -
            (sousTotal * remise / 100)


        '----------------------------------------------
        ' Montant TVA
        '----------------------------------------------
        montantTVA =
            montantApresRemise * tva / 100

        TextBox6.Text =
            montantTVA.ToString("0.00")


        '----------------------------------------------
        ' TOTAL À PAYER
        '----------------------------------------------
        Dim total As Decimal

        total =
            montantApresRemise + montantTVA

        TextBox7.Text =
            total.ToString("0.00")


        Return True

    End Function


    '==========================================================
    ' BOUTON AJOUTER
    '==========================================================
    Private Sub BtnAjouter_Click(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BtnAjouter.Click

        If ComboBox1.SelectedIndex = -1 Then

            MessageBox.Show(
                "Veuillez sélectionner une commande.")

            ComboBox1.Focus()

            Exit Sub

        End If


        If ComboBox2.SelectedIndex = -1 Then

            MessageBox.Show(
                "Veuillez sélectionner un produit.")

            ComboBox2.Focus()

            Exit Sub

        End If


        Dim quantite As Integer
        Dim prix As Decimal
        Dim remise As Decimal
        Dim tva As Decimal
        Dim sousTotal As Decimal
        Dim montantTVA As Decimal
        Dim total As Decimal


        '----------------------------------------------
        ' Quantité
        '----------------------------------------------
        If Not Integer.TryParse(
            TextBox1.Text,
            quantite) Then

            MessageBox.Show(
                "La quantité est invalide.")

            TextBox1.Focus()

            Exit Sub

        End If


        '----------------------------------------------
        ' Prix
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox2.Text,
            prix) Then

            MessageBox.Show(
                "Le prix unitaire est invalide.")

            TextBox2.Focus()

            Exit Sub

        End If


        '----------------------------------------------
        ' Remise
        '----------------------------------------------
        If TextBox4.Text.Trim() = "" Then

            remise = 0

        ElseIf Not Decimal.TryParse(
            TextBox4.Text,
            remise) Then

            MessageBox.Show(
                "La remise est invalide.")

            TextBox4.Focus()

            Exit Sub

        End If


        '----------------------------------------------
        ' TVA
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox5.Text,
            tva) Then

            MessageBox.Show(
                "La TVA est invalide.")

            TextBox5.Focus()

            Exit Sub

        End If


        '----------------------------------------------
        ' Sous-total
        '----------------------------------------------
        If Not Decimal.TryParse(
            TextBox3.Text,
            sousTotal) Then

            MessageBox.Show(
                "Veuillez saisir un sous-total valide.")

            TextBox3.Focus()

            Exit Sub

        End If


        '----------------------------------------------
        ' Calcul
        '----------------------------------------------
        Dim montantApresRemise As Decimal

        montantApresRemise =
            sousTotal -
            (sousTotal * remise / 100)

        montantTVA =
            montantApresRemise * tva / 100

        total =
            montantApresRemise + montantTVA


        TextBox6.Text =
            montantTVA.ToString("0.00")

        TextBox7.Text =
            total.ToString("0.00")


        '----------------------------------------------
        ' INSERTION
        '----------------------------------------------
        Dim cnn As OleDbConnection = GetConnection()

        Try

            Dim cmd As New OleDbCommand(
                "INSERT INTO DetailCommande " &
                "(IdCommande, IdProduit, Quantite, PrixUnitaire, " &
                "Remise, TVA, MontantTva, SousTotal, Total) " &
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
                cnn)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                Convert.ToInt32(ComboBox1.Text)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                Convert.ToInt32(ComboBox2.Text)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                quantite


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                prix


            cmd.Parameters.Add(
                "?",
                OleDbType.Double).Value =
                remise


            cmd.Parameters.Add(
                "?",
                OleDbType.Double).Value =
                tva


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                montantTVA


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                sousTotal


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                total


            cnn.Open()

            Dim resultat As Integer =
                cmd.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show(
                    "Détail ajouté avec succès !",
                    "Ajout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                ViderChamps()

            Else

                MessageBox.Show(
                    "Le détail n'a pas été ajouté.")

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de l'ajout :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub

    Private Sub BtnRechercher_Click(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BtnRechercher.Click

        Dim idCommande As Integer
        Dim idProduit As Integer

        '==========================================================
        ' VERIFICATION COMMANDE
        '==========================================================

        If Not Integer.TryParse(
            ComboBox1.Text.Trim(),
            idCommande) Then

            MessageBox.Show(
                "Veuillez sélectionner une commande.",
                "Recherche",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            ComboBox1.Focus()
            Exit Sub

        End If


        '==========================================================
        ' VERIFICATION PRODUIT
        '==========================================================

        If Not Integer.TryParse(
            ComboBox2.Text.Trim(),
            idProduit) Then

            MessageBox.Show(
                "Veuillez sélectionner un produit.",
                "Recherche",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            ComboBox2.Focus()
            Exit Sub

        End If


        '==========================================================
        ' CONNEXION
        '==========================================================

        Dim cnn As OleDbConnection = GetConnection()


        Try

            Dim sql As String =
                "SELECT Quantite, PrixUnitaire, Remise, TVA, " &
                "MontantTva, SousTotal, Total " &
                "FROM DetailCommande " &
                "WHERE IdCommande = ? AND IdProduit = ?"


            Dim cmd As New OleDbCommand(sql, cnn)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value = idCommande

            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value = idProduit


            cnn.Open()


            Dim dtr As OleDbDataReader =
                cmd.ExecuteReader()


            '======================================================
            ' DETAIL TROUVE
            '======================================================

            If dtr.Read() Then


                '----------------------------------------------
                ' QUANTITE
                '----------------------------------------------

                If Not IsDBNull(dtr("Quantite")) Then

                    TextBox1.Text =
                        Convert.ToInt32(
                            dtr("Quantite")).ToString()

                Else

                    TextBox1.Clear()

                End If


                '----------------------------------------------
                ' PRIX UNITAIRE
                '----------------------------------------------

                If Not IsDBNull(dtr("PrixUnitaire")) Then

                    TextBox2.Text =
                        Convert.ToDecimal(
                            dtr("PrixUnitaire")).ToString("0.00")

                Else

                    TextBox2.Clear()

                End If


                '----------------------------------------------
                ' REMISE
                '----------------------------------------------

                If Not IsDBNull(dtr("Remise")) Then

                    TextBox4.Text =
                        Convert.ToDecimal(
                            dtr("Remise")).ToString("0.##")

                Else

                    TextBox4.Text = "0"

                End If


                '----------------------------------------------
                ' TVA
                '----------------------------------------------

                If Not IsDBNull(dtr("TVA")) Then

                    TextBox5.Text =
                        Convert.ToDecimal(
                            dtr("TVA")).ToString("0.##")

                Else

                    TextBox5.Clear()

                End If


                '----------------------------------------------
                ' SOUS-TOTAL
                '----------------------------------------------

                If Not IsDBNull(dtr("SousTotal")) Then

                    TextBox3.Text =
                        Convert.ToDecimal(
                            dtr("SousTotal")).ToString("0.00")

                Else

                    TextBox3.Clear()

                End If


                '----------------------------------------------
                ' MONTANT TVA
                '----------------------------------------------

                If Not IsDBNull(dtr("MontantTva")) Then

                    TextBox6.Text =
                        Convert.ToDecimal(
                            dtr("MontantTva")).ToString("0.00")

                Else

                    TextBox6.Clear()

                End If


                '----------------------------------------------
                ' TOTAL
                '----------------------------------------------

                If Not IsDBNull(dtr("Total")) Then

                    TextBox7.Text =
                        Convert.ToDecimal(
                            dtr("Total")).ToString("0.00")

                Else

                    TextBox7.Clear()

                End If


                MessageBox.Show(
                    "Détail trouvé.",
                    "Recherche",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)


            Else

                MessageBox.Show(
                    "Aucun détail trouvé pour :" &
                    vbCrLf &
                    "Commande : " & idCommande &
                    vbCrLf &
                    "Produit : " & idProduit,
                    "Recherche",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            End If


            dtr.Close()


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la recherche :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub


    '==========================================================
    ' BOUTON MODIFIER
    '==========================================================
    Private Sub BtnModifier_Click(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BtnModifier.Click

        If ComboBox1.SelectedIndex = -1 Or
           ComboBox2.SelectedIndex = -1 Then

            MessageBox.Show(
                "Sélectionnez une commande et un produit.")

            Exit Sub

        End If


        If Not CalculerTotal() Then
            Exit Sub
        End If


        Dim quantite As Integer
        Dim prix As Decimal
        Dim remise As Decimal
        Dim tva As Decimal
        Dim sousTotal As Decimal
        Dim montantTVA As Decimal
        Dim total As Decimal


        If Not Integer.TryParse(
            TextBox1.Text,
            quantite) Then

            MessageBox.Show("La quantité est invalide.")
            Exit Sub

        End If


        If Not Decimal.TryParse(
            TextBox2.Text,
            prix) Then

            MessageBox.Show("Le prix est invalide.")
            Exit Sub

        End If


        Decimal.TryParse(TextBox4.Text, remise)
        Decimal.TryParse(TextBox5.Text, tva)
        Decimal.TryParse(TextBox3.Text, sousTotal)
        Decimal.TryParse(TextBox6.Text, montantTVA)
        Decimal.TryParse(TextBox7.Text, total)


        Dim cnn As OleDbConnection = GetConnection()


        Try

            Dim cmd As New OleDbCommand(
                "UPDATE DetailCommande SET " &
                "Quantite = ?, " &
                "PrixUnitaire = ?, " &
                "Remise = ?, " &
                "TVA = ?, " &
                "MontantTva = ?, " &
                "SousTotal = ?, " &
                "Total = ? " &
                "WHERE IdCommande = ? AND IdProduit = ?",
                cnn)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                quantite


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                prix


            cmd.Parameters.Add(
                "?",
                OleDbType.Double).Value =
                remise


            cmd.Parameters.Add(
                "?",
                OleDbType.Double).Value =
                tva


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                montantTVA


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                sousTotal


            cmd.Parameters.Add(
                "?",
                OleDbType.Currency).Value =
                total


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                Convert.ToInt32(ComboBox1.Text)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                Convert.ToInt32(ComboBox2.Text)


            cnn.Open()

            Dim resultat As Integer =
                cmd.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show(
                    "Modification effectuée avec succès !",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            Else

                MessageBox.Show(
                    "Aucun détail trouvé.")

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la modification :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub


    '==========================================================
    ' BOUTON SUPPRIMER
    '==========================================================
    Private Sub BtnSupprimer_Click(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles BtnSupprimer.Click

        If ComboBox1.SelectedIndex = -1 Or
           ComboBox2.SelectedIndex = -1 Then

            MessageBox.Show(
                "Sélectionnez une commande et un produit.")

            Exit Sub

        End If


        Dim reponse As DialogResult

        reponse = MessageBox.Show(
            "Voulez-vous vraiment supprimer ce détail ?",
            "Suppression",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)


        If reponse <> DialogResult.Yes Then
            Exit Sub
        End If


        Dim cnn As OleDbConnection = GetConnection()


        Try

            Dim cmd As New OleDbCommand(
                "DELETE FROM DetailCommande " &
                "WHERE IdCommande = ? AND IdProduit = ?",
                cnn)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                Convert.ToInt32(ComboBox1.Text)


            cmd.Parameters.Add(
                "?",
                OleDbType.Integer).Value =
                Convert.ToInt32(ComboBox2.Text)


            cnn.Open()

            Dim resultat As Integer =
                cmd.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show(
                    "Suppression effectuée avec succès !",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Me.DetailCommandeTableAdapter.Fill(
          Me.DatabaseFac1DataSet.DetailCommande)

                ViderChamps()

            Else

                MessageBox.Show(
                    "Aucun détail trouvé.")

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la suppression :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub


    '==========================================================
    ' VIDER LES CHAMPS
    '==========================================================
    Private Sub ViderChamps()

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()

        ComboBox1.Focus()

    End Sub

    Private Sub BtnCommande_Click(ByVal sender As System.Object,
                           ByVal e As System.EventArgs) Handles BtnCommande.Click

        Dim commande As New Commande()
        commande.Show()
        Me.Hide()

    End Sub
    Private Sub BtnEnregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnregistrer.Click
        Dim cnn As New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" & System.Windows.Forms.Application.StartupPath & "\DatabaseFac1.mdb")

        Try

            Dim idCommande As Integer
            Dim idProduit As Integer
            Dim quantite As Integer
            Dim prixUnitaire As Decimal
            Dim remise As Decimal
            Dim tva As Decimal
            Dim montantTva As Decimal
            Dim sousTotal As Decimal
            Dim total As Decimal

            If Not Integer.TryParse(ComboBox1.Text.Trim(), idCommande) Then
                MessageBox.Show("Veuillez sélectionner une commande.")
                Exit Sub
            End If

            If Not Integer.TryParse(ComboBox2.Text.Trim(), idProduit) Then
                MessageBox.Show("Veuillez sélectionner un produit.")
                Exit Sub
            End If

            If Not Integer.TryParse(TextBox1.Text.Trim(), quantite) Then
                MessageBox.Show("Quantité invalide.")
                Exit Sub
            End If

            If Not Decimal.TryParse(TextBox2.Text.Trim(), prixUnitaire) Then
                MessageBox.Show("Prix unitaire invalide.")
                Exit Sub
            End If

            If Not Decimal.TryParse(TextBox4.Text.Trim(), remise) Then
                MessageBox.Show("Remise invalide.")
                Exit Sub
            End If

            If Not Decimal.TryParse(TextBox5.Text.Trim(), tva) Then
                MessageBox.Show("TVA invalide.")
                Exit Sub
            End If

            If Not Decimal.TryParse(TextBox6.Text.Trim(), montantTva) Then
                MessageBox.Show("Montant TVA invalide.")
                Exit Sub
            End If

            If Not Decimal.TryParse(TextBox3.Text.Trim(), sousTotal) Then
                MessageBox.Show("Sous-total invalide.")
                Exit Sub
            End If

            If Not Decimal.TryParse(TextBox7.Text.Trim(), total) Then
                MessageBox.Show("Total invalide.")
                Exit Sub
            End If


            cnn.Open()

            Dim sql As String =
                "INSERT INTO DetailCommande " &
                "([IdCommande], [IdProduit], [Quantite], [PrixUnitaire], " &
                "[Remise], [TVA], [MontantTva], [SousTotal], [Total]) " &
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"

            Dim cmd As New OleDbCommand(sql, cnn)

            cmd.Parameters.Add("?", OleDbType.Integer).Value = idCommande
            cmd.Parameters.Add("?", OleDbType.Integer).Value = idProduit
            cmd.Parameters.Add("?", OleDbType.Integer).Value = quantite
            cmd.Parameters.Add("?", OleDbType.Currency).Value = prixUnitaire
            cmd.Parameters.Add("?", OleDbType.Double).Value = remise
            cmd.Parameters.Add("?", OleDbType.Double).Value = tva
            cmd.Parameters.Add("?", OleDbType.Currency).Value = montantTva
            cmd.Parameters.Add("?", OleDbType.Currency).Value = sousTotal
            cmd.Parameters.Add("?", OleDbType.Currency).Value = total

            cmd.ExecuteNonQuery()

            MessageBox.Show(
                "Détail de la commande enregistré avec succès !",
                "Enregistrement",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de l'enregistrement :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub

    Private Sub BtnImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimer.Click
        Try

            Dim cheminBase As String = System.Windows.Forms.Application.StartupPath & "\DatabaseFac1.mdb"

            Dim accessApp As New Microsoft.Office.Interop.Access.Application()

            accessApp.OpenCurrentDatabase(cheminBase)

            accessApp.DoCmd.OpenReport(
                "E_DetailCommande",
                AcView.acViewPreview)

            accessApp.Visible = True

        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de l'ouverture de l'état :" &
                vbCrLf & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub
End Class