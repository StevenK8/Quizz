Outils de développement utilisé : 
    Visual Studio Code et Visual studio 

Langage : 
    C#

Technologie : 
   Front :  Boostraps/CSS/HTML 
   Back :   SignalR pour la communication 
            Framework ASPNET Core 
            Javascript côté client
    DB :    MariaDB avec PHPMyAdmin pour la gestion administrateur
            Requêtes en mySQL 

Le code se trouve sur le github dans le dossier Quizz 
Le code de la base de données se trouve également sur le github dans le dossier (nom : quizz.sql)

Déploiement : 
    Debug : 
        Visual Studio 2019 avec modules :
            Développement multiplateforme .NET Core
            Développement web et ASP.NET
        
        Lancer QuizzNoGood.sln
    Production :
        http://server-fraaktal.ddns.net:4343/

        Ou nécessite un server sous windows server 2019 avec bundle net core 5.0 et IIS installés
        Depuis visual studio :
            Solution => publier
            Récupérer les fichiers générés et les envoyer sur le serveur après avoir créé un dossier et un site web dans le manager IIS

    Base de données : 
        importer le fichier Quizz.sql sur PHPMyAdmin

