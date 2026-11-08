Imports System.Data.OleDb

Public Class ConnexionAppli

    Private Sub ConnexionAppli_Load(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        TextBox2.UseSystemPasswordChar = True

    End Sub


    '==========================================================
    ' BOUTON SE CONNECTER
    '==========================================================
  Private Sub Button1_Click(ByVal sender As System.Object,
                            ByVal e As System.EventArgs) Handles Button1.Click

        Dim cnn As New OleDbConnection(
            "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" &
            Application.StartupPath & "\DatabaseFac1.mdb")

        Try

            cnn.Open()

            Dim cmd As New OleDbCommand(
                "SELECT COUNT(*) FROM [Connexion] " &
                "WHERE [Login] = ? AND [MotPasse] = ?",
                cnn)

            cmd.Parameters.Add(
                "?",
                OleDbType.VarWChar,
                255).Value = TextBox1.Text.Trim()

            cmd.Parameters.Add(
                "?",
                OleDbType.VarWChar,
                255).Value = TextBox2.Text.Trim()

            Dim resultat As Integer =
                Convert.ToInt32(cmd.ExecuteScalar())

            If resultat > 0 Then

                MessageBox.Show(
                    "Connexion réussie !",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Dim commande As New Commande()
                commande.Show()
                Me.Hide()

            Else

                MessageBox.Show(
                    "Email ou mot de passe incorrect.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Erreur de connexion : " & ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try

    End Sub
End Class