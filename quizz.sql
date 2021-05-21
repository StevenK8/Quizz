-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 192.168.1.23
-- Généré le : ven. 21 mai 2021 à 12:30
-- Version du serveur :  10.5.10-MariaDB-0ubuntu0.21.04.1
-- Version de PHP : 7.2.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `quizz`
--

-- --------------------------------------------------------

--
-- Structure de la table `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `idt` int(11) NOT NULL,
  `question` varchar(255) NOT NULL,
  `answer` varchar(255) NOT NULL,
  `false1` varchar(255) NOT NULL,
  `false2` varchar(255) DEFAULT NULL,
  `false3` varchar(255) DEFAULT NULL,
  `difficulty` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `questions`
--

INSERT INTO `questions` (`id`, `idt`, `question`, `answer`, `false1`, `false2`, `false3`, `difficulty`) VALUES
(1, 8, 'Complétez la chanson : Boys, Boys, ...', 'Boys', 'Pigs', 'Dogs', 'Girls', 1),
(2, 2, 'Quel film a été récompensé par l\'oscar du meilleur film en 1985 ?', 'Amadeus', 'Forrest Gump', 'Black swan', 'Parasite', 3),
(3, 11, 'Qui a marqué le 3eme but en finale de la coupe du monde 1998 ?', 'Emmanuel Petit', 'Zinedine Zidane', 'Thierry Henry', 'Lilian Thuram', 2),
(4, 8, 'En quelle année est sorti l\'album \"L\'école du micro d\'argent\" de IAM', '1997', '2000', '1976', '1995', 3),
(5, 9, 'Combien de temps a duré le mandat de Jacques Chirac ?', '12', '14', '10', '7', 2),
(6, 8, 'Complétez cette chanson du taulier : \"On a tous quelque chose en nous de ...\"', 'Tenessee', 'Dakota du sud', 'Virginie', 'New Jersey', 1),
(7, 6, 'Quel est l\'aliment le plus consommé au monde', 'Les frites ', 'Le coca-cola', 'Le café', 'La vache qui rit', 3),
(8, 3, 'Quelle est la méduse la plus dangereuse au monde ?', 'La méduse-boîte d\'Australie', 'La méduse-carton d\'Indonésie', 'La galère portugaise', 'La méduse abyssale', 2),
(9, 12, 'En quelle année est sortie Marios Bros ?', '1983 ', '1979', '1995 ', '2001', 2),
(10, 10, 'Quelle est la capitale du Mexique ?', 'Mexico', 'Chihuahua', 'Guadalajara', 'Monterrey', 2),
(11, 10, 'Combien y a-t-il d\'états aux Etats-Unis ?', '50', '51', '52', '53', 2),
(12, 10, 'Quelle est le plus grand état des Etats-Unis ?', 'Alaska', 'Washington ', 'La Californie  ', 'La Floride', 3),
(13, 10, 'Quelle est la population de la Russie ?', '144 millions ', '307 millions', '175 millions', '71 millions ', 2),
(14, 10, 'A quel continent fait partie l\'île de Tuvalu ? ', 'Océanie', 'Asie', 'Afrique', 'Amérique', 2),
(15, 10, 'Quel pays possède le meilleur IDH (Indice de Développement Humain) ? ', 'Norvège', 'Etats-Unis ', 'Hongrie', 'Japon', 1),
(16, 10, 'Dans quel pays est situé le Machu Picchu ? ', 'Pérou', 'France', 'Espagne', 'Mexique', 1),
(17, 13, 'En quelle année a commencé la guerre de Corée ?', '1950', '1960', '1970', '1980', 2),
(18, 13, 'En quelle année a eu lieu le sacre de Charlemagne ? ', '800', '1300', '590', '-134 av JC', 1),
(19, 13, 'La bataille de Bouvines, qui a lieu en 1214, a opposé le roi français Philippe Auguste à … ', 'Otton IV ', 'Henri le Lion ', 'Henri VIII ', 'Richard Cœur de Lion ', 2),
(20, 12, 'Comment s\'appelle le personnage de minecraft ?', 'Steve', 'Bob', 'Jean kévin', 'Patrick', 1),
(21, 12, 'Dans quel jeu pouvons nous retrouver Pikachu ?', 'Pokémon', 'monstre et compagnie', 'goat simulator', 'farming simulator', 1),
(22, 12, 'Quel animal est Sonic ?', 'hérisson', 'porc-epic', 'rat', 'ragondin', 2),
(23, 12, 'Qu\'aime cuisiner Papyrus dans Undertale', 'des spaghettis', 'des hot dogs', 'des lasagnes', 'des sandwichs', 3),
(24, 12, 'Quel est le nom des soeurs doigts de fée (Animal crossing) ?', 'Layette, Cousette et Tiquette', 'Balayette, Causette et Tiquette', 'Minette, Causette et Ginette', 'Suzette, Linette et Touqette', 3),
(25, 12, 'Quel est le nom du chapeau dans Mario Odissey', 'Cappy', 'Chapo', 'Capo', 'Kappa', 2),
(26, 6, 'L\'île flottant est servie sur :', 'une crème anglaise', 'une crème patissiere', 'une mousse au chocolat', 'un biscuit', 1),
(27, 6, 'd\'ou vient la piperade ?', 'pays basque', 'grenoble', 'marseille', 'Lyon', 1),
(28, 6, 'De quelle forme est le savarin ?', 'Triangle', 'Rectangle', 'Couronne', 'Hexagonal', 1),
(29, 6, 'Qu\'est-ce que le xéres ?', 'Vin', 'Eau de vie', 'Fruit', 'Légume', 2),
(30, 6, 'Quelle épice colore la paella ?', 'Le Curry', 'Le Cumin', 'Le Safran', 'vide', 1),
(31, 6, 'Le mot Tortilla désigne plusieurs plats, mais en Espagne de quoi s\'agit-il ?', 'Une omelette de pommes de terre', 'Une sucette entortillée de fête foraine', 'Une galette de blé', 'Une galette de sarazin', 1),
(32, 6, 'Qu\'est-ce qui distingue la crème catalane de la crème brulée ?', 'Des zestes de citron ou d\'orange et de la cannelle', 'Des amandes', 'Des noisettes', 'Il n\'y a aucune différence', 1),
(33, 6, 'Quel apéritif étant Espagnol est composé de Vin rouge, de morceaux de fruits ainsi que de limonade ?', 'La Sangria', 'Le Picasso', 'Le Bamboo', 'Le punch', 1),
(34, 6, 'Comment s\'appelle la célèbre confiserie que l\'on déguste en Espagne ? ', 'Le Turron', 'Le massepain', 'Le loukoum', 'Berlingo', 1),
(35, 6, 'Quelle est la spécialité du chef espagnol Ferran adria ?', 'La cuisine moléculaire', 'La cuisine chimique', 'La cuisine ionique', 'La cuisine régionale', 2),
(36, 6, 'Que mangez-vous si je vous sers des tapas ? ', 'Des amuses bouche variés', 'De fines escalopes de veau', 'Des fruits sec tapés et écrasés', 'Des gâteaux apéros', 1),
(37, 6, 'Avec quoi est coloré l\'arroz negro (Riz noir) ?', 'L\'encre de seiche', 'Du charbon', 'Du colorant alimentaire', 'De l\'encre noire', 1),
(38, 6, 'Les Falafels libanais sont réalisés à base de  :', 'Fèves', 'Cacahuètes', 'Noix', 'Noisettes', 3),
(39, 6, 'Au Mali, le râgout de mouton est-il réalisé à partir de :', '12 épices', '24 épices', '36 épices', '48 épices', 3),
(40, 6, 'A Marrakech, les brochettes de mouton sont cuites :', 'Au feu de bois', 'Sur les braises', 'Au four', 'A la poêle', 3),
(41, 6, 'A Bangkok, que mangent les enfants à la sortie de l\'école :', 'Des blinis sauce coco', 'De la purée de fraises', 'De la pastèque', 'Du melon', 3),
(42, 3, 'Comment s\'appelle la femelle du sanglier ?', 'La laie', 'La truie', 'La sanglière', 'La cochonne', 1),
(43, 3, 'Comment s\'appellent les pieux sur lesquels, en Vendée et dans le Cotentin, les moules grossissent ?', 'Les bouchots', ' Les bouchons', ' Les bouchoirs', 'Les poteaux', 3),
(44, 3, 'Quelle est la papavéracée commune des champs de céréales ?', 'Le coquelicot', ' Le bleuet', 'Le trèfle', 'La tulipe', 1),
(45, 3, 'De combien de tentacules est muni le poulpe ?', '8', '10', '12', '14', 2),
(46, 3, 'Quel parc s\'est ouvert à Saint-Ours-les-Roches en 2002 ?', 'Vulcania', 'Micropolis', 'Le puy du fou', 'La Cité des Etoiles', 2),
(47, 3, 'Qui est Pyros venu de Slovénie pour vivre en Ariège depuis 1997 ?', 'Un ours', 'Un loup', 'Un lynx', 'Un panda', 2),
(48, 3, 'Combien pesait le silure, le plus gros poisson de rivière jamais pêché en France, en 1990 ?', '55 Kg', '35 Kg', '70 Kg', '85 Kg', 3),
(49, 3, 'Qu\'est-ce qu\'une vitelotte ?', 'Une variété de pomme de terre', 'Une petite souris des champs', 'Une grenouille des marais', 'vide', 3),
(50, 3, 'Qu\'est-ce que la chevrette à Tahiti ?', 'Une crevette d\'eau douce', 'Une petite chèvre', 'Une petite poule', 'Un petit agneau', 2),
(51, 3, 'Quel est l\'arbre le plus répandu de la forêt française ?', 'Le chêne', 'Le sapin', 'Le hêtre', 'Le bouleau', 1),
(52, 3, 'Quels sont les animaux domestiques les plus nombreux en France ?', 'Les poissons rouges', 'Les chiens', 'Les chats', 'Les lapins', 1),
(53, 3, 'Quel phénomène naturel tire son nom d\'un mot provençal signifiant \'magistral\' ?', 'Le mistral', 'La tramontane', 'L\'autan', 'Le marin', 1),
(54, 3, 'Quelle fleur a donné son nom à une préparation avec des oeufs durs hachés ?', 'Le mimosa', 'Le lilas', 'La tulipe', 'Le coquelicot', 1),
(55, 3, 'Comment s\'appelle le petit du saumon ?', 'Un tacon', 'un poissinet', 'Une civelle', 'Un saumonet', 2),
(56, 3, 'Quelle est la chose la plus précieuse qu\'on peut trouver au pied des chênes ?', 'Des truffes', 'Des cèpes', 'Des trompettes de la mort', 'Des champignons de paris', 1),
(57, 3, 'Quel animal glougloute ?', 'Le dindon', 'Le paon', 'La tourterelle', 'Le pigeon', 1),
(58, 3, 'Dans quelle région française restent-ils des flamants roses ?', 'En Camargue', 'La baie de Somme', 'En Corse', 'En Normandie', 2),
(59, 3, 'A midi, quel animal vient chanter 3 fois en battant des ailes sur l\'horloge de la cathédrale de Strasbourg ?', 'Un coq', 'Un coucou', 'Une cigogne', 'Une tourterelle', 3),
(60, 3, 'Quel nom fleuri porte la grosse crevette rose bretonne ?', 'Le bouquet', 'La rose', 'La pensée', 'vide', 2),
(61, 3, 'Comment les poissonniers appellent-ils les burcins qu\'ils mettent sur leurs étals ?', 'Les bulots', 'Les escargots de mer', 'Les bigorneaux', 'vide', 2),
(62, 3, 'Qu\'est-ce que la coulemelle, également appelée lépiote ?', 'Un champignon', 'Une fleur formée de clochettes qui onte l\'air de couler en grappe', 'Un petit oiseau gris et marron', 'vide', 3),
(63, 3, 'Quelle est la fleur blanche la plus prisée de Guérande ?', 'La fleur de sel', 'La marguerite', 'Le lys', 'vide', 1),
(64, 3, 'Quel type de maïs, produit par Novartis, fit beaucoup parler de lui à la fin des années 90 ?', 'Le maïs transgénique', 'Le maïs ordinaire qu\'on mange grillé avec du beurre', 'Le maïs de différentes couleurs (bleu, rose, vert etc. )', 'Le maïs en popcorn', 1),
(65, 3, 'Qu\'est-ce qui est apprécié chez le mérinos ?', 'Sa laine', 'Sa viande', 'Son lait', 'Ses sabots', 1),
(66, 3, 'De quel animal vient le lait utilisé dans la fabrication du roquefort ?', 'Brebis', 'Vache', 'Chèvre', 'Mouton', 2),
(67, 3, 'Quel animal hybride naît de l\'accouplement d\'une ânesse et d\'un cheval ?', 'Un bardot', 'Un mulet', 'Un ânon', 'Un âne', 2),
(68, 3, 'Quel chien était initialement élevé pour combattre les taureaux ?', 'Le pitbull', 'Le bulldog', 'Le léonberg', 'Le berger Allemand', 3),
(69, 3, 'Que sont les noctules ?', 'Des chauves-souris', 'Des grenouilles', 'Des lucioles', 'Des chenilles', 2),
(70, 3, 'Quel poisson de mer est le plus vendu en France ?', 'Le saumon', 'Le cabillaud', 'Le colin', 'La sole', 2),
(71, 4, 'Qui prononce cette phrase dans le film Fight Club « Les choses que l’on possède finissent par nous posséder » ?', 'Brad Pitt', 'Edward Norton', 'Meat Loaf', 'Jared Leto', 3),
(72, 4, 'Quelle actrice a obtenu la Palme de la meilleure actrice au Festival de Cannes 2014 ?', 'Julianne Moore', 'Drew Barrymore', 'Kate Winslet', 'Susan Sarandon', 3),
(73, 4, 'À quel réalisateur doit-on le film « Maps to the Stars » ?', 'Davind Cronenberg', 'James Cameron', 'Jim Jarmusch', 'Michael Winterbottom', 3),
(74, 4, 'Quel acteur français prononce cette phrase dans le film dans Astérix et Obélix : Mission Cléopâtre « Excusez-moi d’en faire un sac, mais je vais finir dans un crocodile peut-être ! »', 'Jamel Debouzze', 'Alain Chabat', 'Edouard Baer', 'Gérard Darmon', 1),
(75, 4, 'Dans la série des X-Men, quel acteur incarne Wolverine ?', 'Hugh Jackman', 'Ben Affleck', 'Matt Damon', 'Matthew Fox', 2),
(76, 4, 'Qui a réalisé le film « Né un 4 juillet » ?', 'Oliver Stone', 'David Lynch', 'Jerry Bruckheimer', 'Robert Altman', 3),
(77, 4, 'Quel mois est sortie le film « Né un 4 juillet » ?', 'Décembre', 'Juillet', 'Mars', 'Mai', 3),
(78, 4, 'Dans quel film de Tarantino entend-on cette réplique « C’est à une demi-heure d’ici. J’y suis dans dix minutes » ?', 'Pulp Fiction', 'Reservoir Dogs', 'Jackie Brown', 'Kill Bill', 2),
(79, 4, 'Quel acteur de la Comédie française a réalisé le film « Les garçons et Guillaume, à table ! » ?', 'Guillaume Galienne', 'Pascal Elbé', 'Lorànt Deutsch', 'Clovis Cornillac', 2),
(80, 4, 'Quelle actrice incarne Mary Jane Watson dans la trilogie Spider-Man ?', 'Kirsten Dunst', 'Eva Green', 'Diane Kruger', 'Cate Blanchett', 2),
(81, 4, 'Dans quel film entend-on cette réplique « J’adore l’odeur du napalm au petit matin » ?', 'Apocalypse Now', 'Full Metal Jacket', 'Voyage au bout de l’Enfer', 'Les Sentiers de la Gloire', 2),
(82, 4, 'Qui a réalisé le film « Jurassic Park » ?', 'Steven Spielberg', 'Ridley Scott', 'Robert Zemeckis', 'Tim Burton', 1),
(83, 4, 'Comment s\'apelle la société d\'élevage de poulets dans OSS117 : Le Caire Nid d\'espion', 'La SCEP', 'La SBEP', 'La SEEP', 'La POULE', 1),
(84, 2, 'Avec qui Luis Fonsi fait-il un duo sur Despacito ?', 'Daddy Yankee', 'Nicky James', 'Enrique Iglessias', 'Jay Santos', 1),
(85, 2, 'Quel est le titre de Afro trap pt.8 d\'MHD ?', 'Never', 'La puissance', 'OKLM', 'Le mouv', 2),
(86, 2, 'Qui a fait Watch out fid is / Light it up / Run up ?', 'Major Lazer', 'Dj Hamida', 'Avicii', 'David Guetta', 1),
(87, 2, 'Quelle chanteuse interprète la chanson  \" Bette Davis Eyes \" en 1981 ?', 'Kim Carnes', 'Bonnie Tyler', 'Joan Baez', 'vide', 1),
(88, 2, 'Quel duo a chanté  \" Besoin de rien , envie de toi \" en 1984 ?', 'Peter et Sloane', 'Stone et Charden', 'Sony et Cher', 'vide', 1),
(89, 2, 'Quel est le titre de la chanson qui fait connaitre Jeanne Mas dans les années 80 ?', 'Toute première fois', 'Toute derniere fois', 'La derniere fois', 'Toute simple fois', 2),
(90, 2, 'Quel est le vrai titre de la chanson de Gilbert Montagné ?', 'Sous les Sunlights des tropiques', 'Viens danserf', 'Les sunlights de Bali', 'vide', 1),
(91, 2, 'Qui chante le titre \"Fallait pas commencer\" ?', 'Lio', 'Caroline Loeb', 'Sabrina', 'vide', 2),
(92, 2, 'En quelle année Michael Jackson chante t\'il \"Thriller\" ?', '1982', '1984', '1985', '1988', 3),
(93, 2, 'Qui a interprété la chanson \"Words\" ?', 'F.R. David', 'Phil Collins', 'Phil Barney', 'Jean-pierre Mader', 3),
(94, 2, 'De quelle chanson sont ces paroles ? You put the boom boom into my heart , You send my soul sky high when your loving starts ', 'Wake me up before you Go Go', 'Careless whisper', 'Don\'t Let The Sun Go Down On Me', 'vide', 3),
(95, 2, 'Quel artiste chantait \" Boys boys boys \" ?', 'Sabrina Salerno', 'Cookie Dingler', 'Nicole Croisille', 'vide', 1),
(96, 2, 'Qui chante la chanson \"Femme Libérée\" ?', 'Cookie Dingler', 'Phil Barney', 'Jean-pierre Mader', 'vide', 1),
(97, 7, 'Quel roman d’Anna Gavalda a été adapté au cinéma ?', 'Ensemble c’est tout', 'Je l\'aimais', 'Je voudrais que quelqu\'un m\'attende quelque part', 'vide', 2),
(98, 7, 'Quel roman n’a pas été condamné, ou son auteur condamné ?', 'Madame Bovary, de Gustave Flaubert', 'Les fleurs du mal, de Charles Baudelaire', 'Nana, d\'Emile Zola', 'vide', 2),
(99, 7, 'Auteur d’«Une ténébreuse affaire », il est considéré comme le père du roman policier français :', 'Honoré de Balzac', 'Emile Gaboriau', 'Gérard de Nerval', 'vide', 2),
(100, 7, 'Lequel de ces écrivains français n’est pas prix Nobel de Littérature ?', 'André Malraux', 'Albert Camus', 'Claude Simon', 'vide', 2),
(101, 7, 'Un seul de ces auteurs n’a pas écrit d’Antigone :', 'Corneille', 'Henri Bauchau', 'Jean Anouilh', 'vide', 2),
(102, 7, 'On le surnomme le Céline nord-américain. Il s’agit de :', 'Hubert Selby Jr pour Last Exit to Brooklyn', 'Jonh Fante pour Les Compagnons de la Grappe', 'Tenesse Williams pour un Tramway nommé désir', 'vide', 2),
(103, 7, 'Qui sont les gentils dans la saga du Seigneur des Anneaux de JRR Tolkien ?', 'Aragorn, Gandalf et Arwenn', 'Frodon, Sméagol et Gondor', 'Gandalf, Frodon et Saroumane', 'vide', 2),
(104, 7, 'Quelle héroïne est commune à Tennessee Williams, Pier Paolo Pasolini et Daphné du Maurier ?', 'Stella', 'Bella', 'Rebecca', 'Stéphanie', 2),
(105, 7, 'De qui sont les vers « Les sanglots longs des violons de l’automne blessent mon cœur d’une langueur monotone… »', 'Verlaine', 'Apollinaire', 'Rimbaud', 'vide', 2),
(106, 7, 'Il a mis en scène et réalisé lui-même l’une de ses bandes-dessinées :', 'Enki Bilal', 'Franquin', 'Goscinny', 'vide', 2),
(107, 7, 'Dans le Journal de Bridget Jones, d’Helen Fielding, l’héroïne hésite entre :', 'Daniel Cleaver et Mark Darcy', 'Hugh Bealer et Jonh Pearce', 'Jonh Cheese et Daniel Percy', 'vide', 2),
(108, 7, 'Günter Grass a écrit le Tambour ainsi que :', 'Le Turbot', 'Le recueil du chat', 'Les contes du crapaud', 'vide', 2),
(109, 7, 'Qui a écrit « L’Ile au Trésor » ?', 'R.L. Stevenson', 'Charles Dickens', 'James Fenimore Cooper', 'vide', 2),
(110, 7, 'Les Trois Mousquetaires, Vingt ans après… quel est le roman d’Alexandre Dumas qui complète cette histoire ?', 'Le Vicomte de Bragelonne', 'Il n\'y en a pas', 'Le Comte de Cheverny', 'vide', 2),
(111, 7, '« Les âmes grises » l’ont révélé, « La petite fille de Monsieur Linh » a confirmé le formidable talent de Philippe Claudel. De quelle région est originaire cet écrivain ?', 'Lorraine', 'Bourgogne', 'Normandie', 'vide', 2),
(112, 7, 'Quel personnage n’est pas de Jules Verne :', 'Le Capitaine Achab', 'Michel Strogoff', 'Phileas Fogg', 'vide', 2),
(113, 7, 'Fred Vargas est l’une des reines du polar français. Comment s’appelle l’un de ses héros récurrents ?', 'Commissaire Adamsberg', 'Comissaire Montalbano', 'Lieutenant Carlsberg', 'vide', 2),
(114, 7, 'L’auteure Justine Lévy, qui a écrit « Rien de grave », est la fille de :', 'Bernard-Henry Lévy', 'François Mitterrand', 'Marc Lévy', 'vide', 2),
(115, 7, 'Complétez le titre de ce livre de Michel Houellebecq : Les particules…', 'élémentaires', 'alimentaire', 'associées', 'vide', 2),
(116, 7, 'Quel est l’auteur de « La Psychanalyse du conte de fées » ?', 'Bruno Bettelheim', 'Françoise Dolto', 'Sigmund Freud', 'vide', 2),
(118, 11, 'Split, Spare, Strike... Vous pouvez entendre ces termes...', 'Au bowling', 'A la pétanque', 'Au curling', 'Au frisbee', 1),
(119, 11, 'Pour quel sport les arbitres sont-ils obligés d\'utiliser la langue française ?', 'L\'escrime', 'La luutte', 'La boxe', 'L\'équitation', 3),
(120, 11, 'De ces quatre disciplines, laquelle utilise la plus petite surface de jeu ?', 'Le tennis', 'Le basket-ball', 'Le volley-ball', 'Le handball', 2),
(121, 11, 'Si vous entrez dans un magasin de sport en demandant un \"sand wedge\", vous ressortirez avec...', 'Un club de golf', 'Une cravache', 'Une planche à voile', 'Une tranche de jambon entre deux tranches de pain', 3),
(122, 11, 'Au judo, quel est le grade le plus élevé parmi ces ceintures ?', 'Bleue', 'Orange', 'Verte', 'Jaune', 1),
(123, 11, 'En motocyclisme, combien de temps dure le \"Bol d\'or\" ?', '24 heures', '90 minutes', '2 fois 12 heures', '1440 minutes', 2),
(124, 11, 'A quel sport doit-on jouer pendant 2 mi-temps de 40 minutes ?', 'Au rugby', 'Au football', 'Au handall', 'Au basket-ball', 1),
(125, 11, 'Quel numéro de maillot de l\'équipe de France Zidane a t\'il porté ?', '10', '9', '8', '5', 1),
(126, 11, 'Combien y a-t-il de joueurs sur le terrain dans une équipe de hockey sur glace ?', '6', '8', '10', '11', 2),
(127, 11, 'Au judo, avec quelle ceinture débute-t-on ?', 'Blanche', 'Jaune', 'Orange', 'Bleu', 1),
(128, 11, 'Combien y a-t-il de joueurs dans une équipe de handball ?', '7', '6', '8', '9', 2),
(129, 11, 'Du côté de l\'haltérophilie, la catégorie de poids mouche est jusqu\'à :', '51 Kg', '49 Kg', '50 Kg', '52 Kg', 2),
(130, 11, 'De combien de joueurs est composée une équipe de hockey ?', '11', '10', '12', '13', 2),
(131, 11, 'La longueur maximale d\'une épée à l\'escrime est :', '1m10', '1m', '1m15', '1m20', 3),
(132, 11, 'Combien y a-t-il d\'épreuves dans le décathlon ?', '10', '8', '9', '11', 1),
(133, 11, 'Quelle est la distance du marathon ?', ' 42,195 km', ' 30,1 km', ' 50 km', '21 km', 1),
(134, 11, 'Les Jeux olympiques (été ou hiver) sont organisés :', ' Tous les quatre ans', ' Tous les ans', ' Tous les cinq ans', 'Tous les trois ans', 1),
(135, 11, 'En bowling, quel est le score parfait (pour douze strikes consécutifs) ?', '300 points', ' 350 points', ' 400 points', '450 points', 1),
(136, 11, 'Avant un combat de sumo, que jettent les lutteurs sur la zone de combat ?', ' Du sel', ' Du sable', ' De l’eau', 'Du sucre', 2),
(138, 11, 'La Coupe du monde de football se déroule :', 'Tous les quatre ans', 'Tous les ans', 'Tous les deux ans', 'Tous les trois ans', 1),
(139, 11, 'Où se tient toujours le Grand Prix de France de Formule 1 ?', 'Le circuit peut changer d’une année à l’autre', ' Au circuit Magny-Cours près de Nevers', 'Au circuit Paul-Ricard dans le Var', 'A Monaco', 1),
(157, 6, 'Les Falafels libanais sont réalisés à base de  :', 'Fèves', 'Cacahuètes', 'Noix', 'Noisettes', 3),
(162, 3, 'Comment s\'appellent les pieux sur lesquels, en Vendée et dans le Cotentin, les moules grossissent ?', 'Les bouchots', ' Les bouchons', ' Les bouchoirs', 'Les poteaux', 3),
(163, 3, 'Où trouve-t-on des palétuviers ?', 'Dans la mangrove', 'Dans la savane', 'Dans la forêt tropicale', 'vide', 1),
(165, 3, 'De combien de tentacules est muni le poulpe ?', '8', '10', '12', '14', 2),
(192, 4, 'Quel acteur tient le rôle de Christian dans le film \" Moulin Rouge \" ?', 'Ewan McGregore', 'Colin Farrell', 'Edward Norton', 'Jim carrey', 1),
(213, 2, 'En quelle année Michael Jackson chante t\'il \"Thriller\" ?', '1982', '1984', '1985', '1988', 3),
(227, 7, 'Il a mis en scène et réalisé lui-même l’une de ses bandes-dessinées :', 'Enki Bilal', 'Franquin', 'Goscinny', 'vide', 2),
(232, 7, '« Les âmes grises » l’ont révélé, « La petite fille de Monsieur Linh » a confirmé le formidable talent de Philippe Claudel. De quelle région est originaire cet écrivain ?', 'Lorraine', 'Bourgogne', 'Normandie', 'vide', 2),
(236, 7, 'Complétez le titre de ce livre de Michel Houellebecq : Les particules…', 'élémentaires', 'alimentaire', 'associées', 'vide', 2),
(238, 11, 'De combien de joueurs se compose une équipe de basket-ball ?', '5', '4', '6', '7', 1),
(251, 11, 'De combien de joueurs est composée une équipe de hockey ?', '11', '10', '12', '13', 2),
(258, 11, 'Quelles sont les deux disciplines composant le biathlon ?', 'Ski de fond et tir à la carabine', 'Cyclisme et course à pied', 'Natation et course à pied', 'Natation et cyclisme', 2),
(261, 14, 'Quel est l\'autre nom de la gouache ?', 'L\'aquarelle opaque', 'L\'acrylique diluable', 'Peinture glycéro', '', 2),
(262, 14, 'En quelle année le plafond de la chapelle Sixtine a - elle été finie?', '1512', '1508', '1483', '1499', 1),
(263, 14, 'Quel est le support traditionnel de la peinture à l\'huile?', 'Le bois', 'Une toile de lin', 'Une toile de coton', 'Une feuille de papier', 1),
(264, 14, 'Par qui a été réalisé La Naissance de Vénus (1485)?', 'Sandro Botticeli', 'Léonard De Vinci', 'Michel-Ange', 'Giovanni Bellini', 2),
(265, 14, 'Le fusain est - il un médium sec?', 'VRAI', 'FAUX', '', '', 1),
(266, 14, 'L\'acrylique peut-elle se réactiver après avoir sécher?', 'Oui', 'Non', '', '', 1);

-- --------------------------------------------------------

--
-- Structure de la table `score`
--

CREATE TABLE `score` (
  `id` int(11) NOT NULL,
  `idu` int(11) NOT NULL,
  `idt` int(11) NOT NULL,
  `maxscore` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `themes`
--

CREATE TABLE `themes` (
  `id` int(11) NOT NULL,
  `theme` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `themes`
--

INSERT INTO `themes` (`id`, `theme`) VALUES
(2, 'Années 80'),
(3, 'Faune et flore'),
(4, 'Cinéma'),
(5, 'Divertissements'),
(6, 'Cuisine'),
(7, 'Litterature'),
(8, 'Musique'),
(9, 'Politique'),
(10, 'Géographie'),
(11, 'Sport'),
(12, 'Jeux vidéos'),
(13, 'Histoire'),
(14, 'Art');

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` binary(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'admin', 0x0a000000b000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000),
(2, 'Test', 0x243261243130246e4659784a51637943555457716c304e46524e69552e6f6c4d6872336a69356655654b4937636377637a38337a30316142584a3253),
(4, 'Lucas', 0x24326124313024424536546774396d544f454859695976584d624b412e59616e744a7773376e433549474c622f6d67744e48463743693456554c3143),
(10, 'TestPassword', 0x24326124313024692e49575a457a4948366d674c4230302f325657642e717a55574a624c766f633877497a486430753230795170664e37614c6d636d),
(18, 'k', 0x243261243130246c48396f63487067566b4957567667386c744e4d5a2e66565830726938556a724d54484d6e53675357484677644a65533569564547),
(19, 'pseudotest', 0x2432612431302456586c736348494348376678614965366a5674313575336d7039374c45436e5a5a506c634874626c4b556d655a6d556447374e672e),
(20, 'Damien', 0x243261243130244c50656e38426c447171396f3266704972792e2f317569613550446658693966714b776a6b31655a2f365265786575486133624753),
(21, 'Claire', 0x2432612431302461386f704c5a656d49576a6f36736a785a4b744852753847565a5a7749384d3272342f4b38545667644461534536572e6170707269),
(22, 'tom', 0x243261243130247836524138524a69444556324274644e5869396a5a756a2f315649645a7266746c376538442f5a35707a683151445a433930304736),
(29, 'Fraaktal', 0x24326124313024797a35624f6f3867707770554d676353483931496a4f467a36346e756c576849396f766d6f7462366446724e327342426f2e4c684b),
(30, 'user', 0x2432612431302454434e626f4b676861456349354a6b6c57346f77464f44362e57686e313430787a4d49424b706a56784a4e7133464e6a4f37712e57),
(35, 'test1234', 0x24326124313024704f39364433556c7976644e2e6e63536f4f6974424f743570536c413572696f436267576e666c38335a5256506c6a496537565761),
(37, '<h1>mdr</h1>', 0x243261243130247239505773556b50766c2e5a46616d32455465704d4f4b583133764b4d71612f53715375342f713750346d38674a50774a4a6e6a43),
(38, 'damzer', 0x243261243130247278373369545962386446544c373753396f554b704f2e41695367476b6e6234442f7a77317247426a6a76766e7973495272324161),
(39, 'steven', 0x24326124313024344e33326e3276675558333863513459553374336d4f6e4b613644722f4534397869786637563836655259577547574b6d42576865),
(40, 'juju773', 0x2432612431302432306f526d52316532635166574971705861314a6365443736323432704c4472302f51574f4b497550593649473556534678453136),
(42, 'Hikari', 0x2432612431302465503779416a68316c756b464276525962646b554875492e6d776c376e76584d6d524d6d4f535435316c5665316345345a76513161),
(43, 'CB', 0x2432612431302463585976654f6b723136707175464d4b70523333712e4456617864747757514466645767354936513033617855456263704f6e6336),
(44, '<h1>silvain</h1>', 0x24326124313024796a62797335546b727a4b6a31692f6d49746f3248752f465a6c6f3670566e366b696b6e5469615376414a6850387a6b476c34512e),
(45, 'KevinJteDeteste', 0x2432612431302431464d6e564257627163416234327054327648666d4f734f2f4f774e6430644f5545376a76373153665776792f427a706537364f75),
(46, '#emeraude', 0x2432612431302455446644657235574745797443754e4f54614d6f702e5942457861305359754b57306d6a6a46676147446e5551343341324a585857),
(47, 'WallerJteDeteste', 0x2432612431302430664366684d682e4452755879327a4f7132484a766568455152542e5437444734554d49395158656c5033764a59626b344e6c4a4b),
(48, '<h1>coucou</h1>', 0x243261243130247378515764346761737947787275732e6950487248653542793344447946593361683662664577534e4c6c65694b5a5442527a3043),
(49, 'Wololo', 0x243261243130245151747a4d633744657a3747364856594d59556b314f6365356d55464e557854746d54547867617735763555693657634564364a36),
(50, '<u>test</u>', 0x2432612431302461644f48786d7234664243576f6b45484a67306269657237416b303462676e5730796945385769424d523136457475546b50516b32),
(51, 'rrrrr', 0x2432612431302458666f67392f394f363836706239564a56796f73682e6d68557a343056793978497872555351743778484e7a763946457a58326e65),
(52, 'GlHf', 0x243261243130247856374858702f794158504779416e70444a4d72562e724f30377262382e4c576a42473750306e6e51596b4b6133444c4174613279),
(53, '', 0x24326124313024764a2f5475472f6666666e7041734e4459526b48397551494a7169557935535373417768663837486d4c58763154586d6c79536469),
(54, 'z', 0x243261243130247a47535178654237756b486d384d566750354a536e65776a354f6f317748615443586c67664b37796a6671767a3556783552303871),
(56, '᲼᲼᲼᲼᲼᲼', 0x24326124313024385a626e7068412e334d426f4f467656667959316d2e6274796331733864546144576a4b384e635a364742633138384c3945303847);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idt` (`idt`);

--
-- Index pour la table `score`
--
ALTER TABLE `score`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idu` (`idu`),
  ADD KEY `idt` (`idt`);

--
-- Index pour la table `themes`
--
ALTER TABLE `themes`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=267;

--
-- AUTO_INCREMENT pour la table `score`
--
ALTER TABLE `score`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `themes`
--
ALTER TABLE `themes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `theme` FOREIGN KEY (`idt`) REFERENCES `themes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `score`
--
ALTER TABLE `score`
  ADD CONSTRAINT `themes` FOREIGN KEY (`idt`) REFERENCES `themes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user` FOREIGN KEY (`idu`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
