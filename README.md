# Application de gestion clients et commandes

Application de bureau (Windows) développée en **VB.NET (Windows Forms)** avec une base de données **Microsoft Access**. Elle permet de gérer les clients, les commandes, les produits et le détail des commandes, après une connexion par identifiant et mot de passe.

Projet universitaire réalisé à l'Université Gaston Berger (UGB), Licence 3 Génie Informatique.

## Fonctionnalités

- **Connexion** : écran d'authentification (login et mot de passe)
- **Gestion des clients** : ajouter, modifier, supprimer et rechercher un client (nom, prénom, téléphone, adresse, email)
- **Gestion des commandes** : ajouter, modifier, supprimer et rechercher une commande liée à un client, avec sa date
- **Gestion des produits**
- **Détail des commandes**
- **Navigation** entre les écrans (Client, Commande, Produits, DétailCommande) et déconnexion

## Technologies

- VB.NET, Windows Forms (.NET Framework)
- ADO.NET (`System.Data.OleDb`) avec requêtes paramétrées
- Base de données Microsoft Access : `DatabaseFac1.mdb`
- Visual Studio

## Structure du projet

| Fichier | Rôle |
|---|---|
| `ConnexionAppli` | Écran de connexion |
| `Client` | Gestion des clients |
| `Commande` | Gestion des commandes |
| `Produit` | Gestion des produits |
| `DetailCommande` | Détail des commandes |
| `DatabaseFac1.mdb` | Base de données Access, placée à côté de l'exécutable |

## Installation et lancement

1. Cloner le dépôt et ouvrir la solution dans Visual Studio.
2. Placer le fichier `DatabaseFac1.mdb` dans le dossier de l'exécutable (`bin\Debug`). L'application le cherche à cet endroit.
3. Le fournisseur `Microsoft.Jet.OLEDB.4.0` fonctionne uniquement en 32 bits : dans les propriétés du projet, régler la plateforme cible sur **x86**.
4. Compiler et lancer l'application (F5). L'écran de connexion s'affiche en premier.

## Exemple d'utilisation

1. Se connecter avec un compte valide.
2. Dans **Client**, ajouter un client.
3. Dans **Commande**, cliquer sur « Ajouter », saisir l'identifiant du client : la commande est créée avec la date du jour.
4. Utiliser « Rechercher » pour afficher les informations d'une commande, « Modifier » pour mettre à jour sa date, « Supprimer » pour la retirer (après confirmation).

## Auteure

Trecy Biassala
