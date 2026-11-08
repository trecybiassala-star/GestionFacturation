Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Produit

    '==========================================================
    ' VARIABLES
    '==========================================================
    Public cnn As OleDbConnection
    Public cmd As OleDbCommand
    Public dtr As OleDbDataReader
    Public dta As New OleDbDataAdapter
    Public dts As New DataSet
    Private cmb As New OleDbCommandBuilder
    Private strSQL, strConn As String


    '==========================================================
    ' CHARGEMENT DU FORMULAIRE
    '==========================================================
    Private Sub Produit_Load(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'DatabaseFac1DataSet.Produit'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ProduitTableAdapter.Fill(Me.DatabaseFac1DataSet.Produit)

    End Sub


    '==========================================================
    ' BOUTON AJOUTER
    '==========================================================
    Private Sub BtnAjouter_Click(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) Handles BtnAjouter.Click

        ' Vérification des champs
        If TextBox1.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir la désignation.")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir le prix.")
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text.Trim() = "" Then
            MessageBox.Show("Veuillez saisir la quantité.")
            TextBox3.Focus()
            Exit Sub
        End If


        ' Vérifier que le prix est bien numérique
        Dim prix As Decimal

        If Not Decimal.TryParse(TextBox2.Text, prix) Then
            MessageBox.Show("Le prix doit être un nombre.")
            TextBox2.Focus()
            Exit Sub
        End If


        ' Vérifier que la quantité est un nombre entier
        Dim quantite As Integer

        If Not Integer.TryParse(TextBox3.Text, quantite) Then
            MessageBox.Show("La quantité doit être un nombre entier.")
            TextBox3.Focus()
            Exit Sub
        End If


        Dim cnn As New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
            Application.StartupPath & "\DatabaseFac1.mdb")


        Try

            cnn.Open()


            ' Vérifier si le produit existe déjà
            Dim cmdVerification As New OleDbCommand(
                "SELECT COUNT(*) FROM Produit WHERE Designation = ?", cnn)

            cmdVerification.Parameters.AddWithValue("?", TextBox1.Text.Trim())

            Dim existe As Integer = CInt(cmdVerification.ExecuteScalar())

            If existe > 0 Then

                MessageBox.Show("Ce produit existe déjà.")
                Exit Sub

            End If


            ' Ajouter le produit
            ' IdProduit est en NuméroAuto donc on ne l'indique PAS
            Dim cmdAjout As New OleDbCommand(
                "INSERT INTO Produit (Designation, Prix, Quantitestocker) " &
                "VALUES (?, ?, ?)", cnn)

            cmdAjout.Parameters.AddWithValue("?", TextBox1.Text.Trim())
            cmdAjout.Parameters.AddWithValue("?", prix)
            cmdAjout.Parameters.AddWithValue("?", quantite)

            Dim resultat As Integer = cmdAjout.ExecuteNonQuery()


            If resultat > 0 Then

                MessageBox.Show("Produit ajouté avec succès !")

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()

                TextBox1.Focus()

            Else

                MessageBox.Show("Le produit n'a pas été ajouté.")

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Erreur lors de l'ajout :" & vbCrLf &
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
    ' BOUTON RECHERCHER
    '==========================================================
    Private Sub BtnRechercher_Click(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles BtnRechercher.Click

        'Ici on utilise la désignation pour rechercher
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir la désignation du produit.")
            TextBox1.Focus()
            Exit Sub
        End If


        Dim cnn As New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
            Application.StartupPath & "\DatabaseFac1.mdb")


        Dim cmd As New OleDbCommand(
            "SELECT * FROM Produit WHERE Designation = ?", cnn)

        cmd.Parameters.AddWithValue("?", TextBox1.Text)

        cnn.Open()

        Dim dtr As OleDbDataReader = cmd.ExecuteReader()


        If dtr.Read() Then

            MessageBox.Show("Le produit existe.")

            TextBox1.Text = dtr("Designation").ToString()
            TextBox2.Text = dtr("Prix").ToString()
            TextBox3.Text = dtr("Quantitestocker").ToString()

        Else

            MessageBox.Show("Aucun produit trouvé.")

            TextBox2.Clear()
            TextBox3.Clear()

        End If


        dtr.Close()
        cnn.Close()

    End Sub


    '==========================================================
    ' BOUTON MODIFIER
    '==========================================================
    Private Sub BtnModifier_Click(ByVal sender As System.Object,
                                  ByVal e As System.EventArgs) Handles BtnModifier.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir la désignation du produit.")
            TextBox1.Focus()
            Exit Sub
        End If


        Dim cnn As New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
            Application.StartupPath & "\DatabaseFac1.mdb")


        Dim cmd As New OleDbCommand(
            "UPDATE Produit SET Prix = ?, Quantitestocker = ? " &
            "WHERE Designation = ?", cnn)


        cmd.Parameters.AddWithValue("?", TextBox2.Text)
        cmd.Parameters.AddWithValue("?", TextBox3.Text)
        cmd.Parameters.AddWithValue("?", TextBox1.Text)


        cnn.Open()

        Dim resultat As Integer = cmd.ExecuteNonQuery()


        If resultat > 0 Then
            MessageBox.Show("Modification effectuée !")
        Else
            MessageBox.Show("Aucun produit trouvé.")
        End If


        cnn.Close()

    End Sub


    '==========================================================
    ' BOUTON SUPPRIMER
    '==========================================================
    Private Sub BtnSupprimer_Click(ByVal sender As System.Object,
                                   ByVal e As System.EventArgs) Handles BtnSupprimer.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir la désignation du produit.")
            TextBox1.Focus()
            Exit Sub
        End If


        Dim reponse As DialogResult

        reponse = MessageBox.Show(
            "Voulez-vous vraiment supprimer ce produit ?",
            "Suppression",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)


        If reponse = DialogResult.Yes Then

            Dim cnn As New OleDbConnection(
                "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
                Application.StartupPath & "\DatabaseFac1.mdb")


            Dim cmd As New OleDbCommand(
                "DELETE FROM Produit WHERE Designation = ?", cnn)

            cmd.Parameters.AddWithValue("?", TextBox1.Text)


            cnn.Open()

            Dim resultat As Integer = cmd.ExecuteNonQuery()


            If resultat > 0 Then
                MessageBox.Show("Suppression effectuée !")
            Else
                MessageBox.Show("Aucun produit trouvé.")
            End If


            cnn.Close()


            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()

            TextBox1.Focus()

        End If

    End Sub

    '==========================================================
    ' BUTTON 1 → CLIENT
    '==========================================================
    Private Sub Button1_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles Button1.Click

        Dim client As New Client()
        client.Show()
        Me.Hide()

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


End Class