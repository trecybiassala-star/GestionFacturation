'==========================================================
' REFERENCES
'==========================================================
Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Client

    '==========================================================
    ' CHAINE DE CONNEXION
    '==========================================================
    Private chaineConnexion As String =
        "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
        Application.StartupPath & "\DatabaseFac1.mdb"


    '==========================================================
    ' CHARGEMENT DU FORMULAIRE
    '==========================================================
    Private Sub Client_Load(ByVal sender As System.Object,
                            ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'DatabaseFac1DataSet1.Client'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ClientTableAdapter.Fill(Me.DatabaseFac1DataSet1.Client)

        Me.ClientTableAdapter.Fill(Me.DatabaseFac1DataSet1.Client)

    End Sub


    '==========================================================
    ' BOUTON AJOUTER
    '==========================================================
    Private Sub BtnAjouter_Click(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) Handles BtnAjouter.Click

        ' Vérification des champs
        If TextBox1.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir le nom.")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir le prénom.")
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir le téléphone.")
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox4.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir l'adresse.")
            TextBox4.Focus()
            Exit Sub
        End If

        If TextBox5.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir l'email.")
            TextBox5.Focus()
            Exit Sub
        End If


        Dim chemin As String = Application.StartupPath & "\DatabaseFac1.mdb"

        Dim cnn As New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" & chemin)

        Try

            cnn.Open()

            ' Vérifier si l'email existe déjà
            Dim cmdVerification As New OleDbCommand(
                "SELECT COUNT(*) FROM Client WHERE Email = ?", cnn)

            cmdVerification.Parameters.AddWithValue("?", TextBox5.Text.Trim())

            Dim existe As Integer = CInt(cmdVerification.ExecuteScalar())

            If existe > 0 Then

                MessageBox.Show("Ce client existe déjà.")

                Exit Sub

            End If


            ' Ajouter le client
            ' IdClient n'est pas indiqué car il est en NuméroAuto
            Dim cmdAjout As New OleDbCommand(
                "INSERT INTO Client (Nom, Prenom, Telephone, Adresse, Email) " &
                "VALUES (?, ?, ?, ?, ?)", cnn)

            cmdAjout.Parameters.AddWithValue("?", TextBox1.Text.Trim())
            cmdAjout.Parameters.AddWithValue("?", TextBox2.Text.Trim())
            cmdAjout.Parameters.AddWithValue("?", TextBox3.Text.Trim())
            cmdAjout.Parameters.AddWithValue("?", TextBox4.Text.Trim())
            cmdAjout.Parameters.AddWithValue("?", TextBox5.Text.Trim())

            Dim resultat As Integer = cmdAjout.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show("Client ajouté avec succès !")

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()

                TextBox1.Focus()

            Else

                MessageBox.Show("Le client n'a pas été ajouté.")

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de l'ajout :" & vbCrLf & ex.Message,
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
    ' BOUTON RECHERCHER
    '==========================================================
    Private Sub BtnRechercher_Click(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles BtnRechercher.Click

        If TextBox5.Text.Trim() = "" Then

            MessageBox.Show("Veuillez saisir l'email du client.")

            TextBox5.Focus()

            Exit Sub

        End If


        Dim cnn As New OleDbConnection(chaineConnexion)

        Try

            cnn.Open()


            Dim cmd As New OleDbCommand(
                "SELECT * FROM Client WHERE Email = ?", cnn)

            cmd.Parameters.AddWithValue(
                "?", TextBox5.Text.Trim())


            Dim dtr As OleDbDataReader =
                cmd.ExecuteReader()


            If dtr.Read() Then

                MessageBox.Show(
                    "Client trouvé !",
                    "Recherche",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)


                TextBox1.Text =
                    dtr("Nom").ToString()

                TextBox2.Text =
                    dtr("Prenom").ToString()

                TextBox3.Text =
                    dtr("Telephone").ToString()

                TextBox4.Text =
                    dtr("Adresse").ToString()

                TextBox5.Text =
                    dtr("Email").ToString()

            Else

                MessageBox.Show(
                    "Aucun client ne correspond à cet email.",
                    "Recherche",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            End If


            dtr.Close()


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la recherche :" &
                Environment.NewLine &
                ex.Message,
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
    Private Sub BtnModifier_Click(ByVal sender As System.Object,
                                  ByVal e As System.EventArgs) Handles BtnModifier.Click

        If TextBox5.Text.Trim() = "" Then

            MessageBox.Show(
                "Veuillez saisir l'email du client.")

            TextBox5.Focus()

            Exit Sub

        End If


        Dim cnn As New OleDbConnection(chaineConnexion)

        Try

            cnn.Open()


            Dim cmd As New OleDbCommand(
                "UPDATE Client SET " &
                "Nom = ?, " &
                "Prenom = ?, " &
                "Telephone = ?, " &
                "Adresse = ? " &
                "WHERE Email = ?", cnn)


            cmd.Parameters.AddWithValue(
                "?", TextBox1.Text.Trim())

            cmd.Parameters.AddWithValue(
                "?", TextBox2.Text.Trim())

            cmd.Parameters.AddWithValue(
                "?", TextBox3.Text.Trim())

            cmd.Parameters.AddWithValue(
                "?", TextBox4.Text.Trim())

            cmd.Parameters.AddWithValue(
                "?", TextBox5.Text.Trim())


            Dim resultat As Integer =
                cmd.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show(
                    "Modification effectuée avec succès !",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)


                'Actualiser les données
                Me.ClientTableAdapter.Fill(Me.DatabaseFac1DataSet1.Client)

            Else

                MessageBox.Show(
                    "Aucun client trouvé avec cet email.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la modification :" &
                Environment.NewLine &
                ex.Message,
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
    Private Sub BtnSupprimer_Click(ByVal sender As System.Object,
                                   ByVal e As System.EventArgs) Handles BtnSupprimer.Click

        If TextBox5.Text.Trim() = "" Then

            MessageBox.Show(
                "Veuillez saisir l'email du client.")

            TextBox5.Focus()

            Exit Sub

        End If


        Dim reponse As DialogResult

        reponse = MessageBox.Show(
            "Voulez-vous vraiment supprimer ce client ?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)


        If reponse = DialogResult.No Then
            Exit Sub
        End If


        Dim cnn As New OleDbConnection(chaineConnexion)

        Try

            cnn.Open()


            Dim cmd As New OleDbCommand(
                "DELETE FROM Client WHERE Email = ?", cnn)

            cmd.Parameters.AddWithValue(
                "?", TextBox5.Text.Trim())


            Dim resultat As Integer =
                cmd.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show(
                    "Client supprimé avec succès !",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)


                'Actualiser le DataSet
                Me.ClientTableAdapter.Fill(Me.DatabaseFac1DataSet1.Client)


                'Effacer les champs
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()

                TextBox1.Focus()

            Else

                MessageBox.Show(
                    "Aucun client trouvé avec cet email.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de la suppression :" &
                Environment.NewLine &
                ex.Message,
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
    ' BUTTON 1 → DÉCONNEXION
    '==========================================================
    Private Sub Button1_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles Button1.Click

        Dim reponse As DialogResult

        reponse = MessageBox.Show(
            "Voulez-vous vraiment vous déconnecter ?",
            "Déconnexion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If reponse = DialogResult.Yes Then

            Dim connexion As New ConnexionAppli()
            connexion.Show()

            Me.Close()

        End If

    End Sub


    '==========================================================
    ' BUTTON 2 → COMMANDE
    '==========================================================
    Private Sub Button2_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles Button2.Click

        Dim commande As New Commande()
        commande.Show()

        Me.Hide()

    End Sub


    '==========================================================
    ' BUTTON 3 → DETAIL COMMANDE
    '==========================================================
    Private Sub Button3_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles Button3.Click

        Dim detail As New DetailCommande()
        detail.Show()

        Me.Hide()

    End Sub


    '==========================================================
    ' BUTTON 4 → PRODUIT
    '==========================================================
    Private Sub Button4_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles Button4.Click

        Dim produit As New Produit()
        produit.Show()

        Me.Hide()

    End Sub
End Class