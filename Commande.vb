Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Commande

    '==========================================================
    ' CONNEXION À LA BASE
    '==========================================================
    Private Function GetConnection() As OleDbConnection
        Return New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
            Application.StartupPath &
            "\DatabaseFac1.mdb")
    End Function

    '==========================================================
    ' CHARGEMENT
    '==========================================================
    Private Sub Commande_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChargerCommandes()
    End Sub

    '==========================================================
    ' RÉCUPÉRER ID COMMANDE
    '==========================================================
    Private Function RecupererIdCommande() As Integer
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Veuillez sélectionner une commande.")
            Return -1
        End If

        Dim idCommande As Integer
        If Integer.TryParse(ComboBox1.Text.Trim(), idCommande) = False Then
            MessageBox.Show("L'identifiant de la commande est invalide.")
            Return -1
        End If

        Return idCommande
    End Function

    '==========================================================
    ' CHARGER LES COMMANDES
    '==========================================================
    Private Sub ChargerCommandes()
        ComboBox1.Items.Clear()
        Using cnn As OleDbConnection = GetConnection()
            Try
                Dim cmd As New OleDbCommand(
                    "SELECT IdCommande FROM Commande ORDER BY IdCommande", cnn)
                cnn.Open()
                Dim dtr As OleDbDataReader = cmd.ExecuteReader()
                While dtr.Read()
                    ComboBox1.Items.Add(dtr("IdCommande").ToString())
                End While
                dtr.Close()
            Catch ex As Exception
                MessageBox.Show("Erreur lors du chargement des commandes :" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    '==========================================================
    ' AJOUTER
    '==========================================================
    Private Sub BtnAjouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAjouter.Click
        Dim idClient As Integer
        If Not Integer.TryParse(InputBox("Entrez l'ID du client :"), idClient) Then
            MessageBox.Show("ID client invalide.")
            Exit Sub
        End If

        Using cnn As OleDbConnection = GetConnection()
            Try
                cnn.Open()
                Dim sql As String = "INSERT INTO [Commande] ([IdClient], [DateCommande]) VALUES (?, ?)"
                Dim cmd As New OleDbCommand(sql, cnn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idClient
                cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Today
                Dim resultat As Integer = cmd.ExecuteNonQuery()
                If resultat > 0 Then
                    MessageBox.Show("Commande ajoutée avec succès !", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChargerCommandes()
                End If
            Catch ex As Exception
                MessageBox.Show("Erreur lors de l'ajout :" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    '==========================================================
    ' SUPPRIMER
    '==========================================================
    Private Sub BtnSupprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSupprimer.Click
        Dim idCommande As Integer = RecupererIdCommande()
        If idCommande = -1 Then Exit Sub

        If MessageBox.Show("Voulez-vous supprimer la commande " & idCommande.ToString() & " ?", "Confirmation",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub

        Using cnn As OleDbConnection = GetConnection()
            Try
                cnn.Open()
                Dim sql As String = "DELETE FROM [Commande] WHERE [IdCommande] = ?"
                Dim cmd As New OleDbCommand(sql, cnn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idCommande
                Dim resultat As Integer = cmd.ExecuteNonQuery()
                If resultat > 0 Then
                    MessageBox.Show("Commande supprimée avec succès !", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Aucune commande trouvée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ChargerCommandes()
            Catch ex As Exception
                MessageBox.Show("Erreur lors de la suppression :" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    '==========================================================
    ' RECHERCHER
    '==========================================================
    Private Sub BtnRechercher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRechercher.Click
        Dim idCommande As Integer = RecupererIdCommande()
        If idCommande = -1 Then Exit Sub

        Using cnn As OleDbConnection = GetConnection()
            Try
                cnn.Open()
                Dim sql As String = "SELECT * FROM [Commande] WHERE [IdCommande] = ?"
                Dim cmd As New OleDbCommand(sql, cnn)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idCommande
                Dim dtr As OleDbDataReader = cmd.ExecuteReader()
                If dtr.Read() Then
                    MessageBox.Show("Commande trouvée !" & vbCrLf &
                                    "ID commande : " & dtr("IdCommande").ToString() & vbCrLf &
                                    "ID client : " & dtr("IdClient").ToString() & vbCrLf &
                                    "Date : " & Convert.ToDateTime(dtr("DateCommande")).ToString("dd/MM/yyyy"),
                                    "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Aucune commande trouvée.", "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                dtr.Close()
            Catch ex As Exception
                MessageBox.Show("Erreur lors de la recherche :" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    '==========================================================
    ' MODIFIER
    '==========================================================
    Private Sub BtnModifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModifier.Click
        Dim idCommande As Integer = RecupererIdCommande()
        If idCommande = -1 Then Exit Sub

        Using cnn As OleDbConnection = GetConnection()
            Try
                cnn.Open()
                Dim sql As String = "UPDATE [Commande] SET [DateCommande] = ? WHERE [IdCommande] = ?"
                Dim cmd As New OleDbCommand(sql, cnn)
                cmd.Parameters.Add("?", OleDbType.Date).Value = Date.Today
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idCommande
                Dim resultat As Integer = cmd.ExecuteNonQuery()
                If resultat > 0 Then
                    MessageBox.Show("Commande modifiée avec succès !" & vbCrLf &
                                    "Nouvelle date : " & Date.Today.ToString("dd/MM/yyyy"),
                                    "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Aucune commande trouvée.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Erreur lors de la modification :" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object,
                          ByVal e As System.EventArgs) Handles Button2.Click

        Dim client As New Client()
        client.Show()
        Me.Hide()

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles Button3.Click

        Dim produit As New Produit()
        produit.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) Handles Button4.Click

        Dim detail As New DetailCommande()
        detail.Show()
        Me.Hide()

    End Sub


End Class
