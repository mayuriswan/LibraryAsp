using System.Globalization;
using System.Net;

namespace LibrairieDTICRosemont.Models
{
    public static class SampleDonnes
    {

        // Champ privé pour stocker les livres
        private static List<Livre> listeLivres = new();

        // Propriété statique permettant l'accès en lecture seule à la liste de listeLivres
        // une propriété statique en lecture seule appelée Livres.
        // Cette propriété permet d'accéder à la liste de listeLivres  depuis l'extérieur de la classe SampleDonnes
        public static List<Livre> Livres => listeLivres;
        public static Categorie?[] getCategories()
        {
            DateTime dateEdition = new DateTime();
            Categorie c1 = new Categorie {  Designation = "Java" };
            Categorie c2 = new Categorie {  Designation = "JavaScript" };
            Categorie c3 = new Categorie {  Designation = "C#" };
            Categorie c4 = new Categorie {  Designation = "Angular" };

            Auteur a1 = new Auteur { Nom = "Anne", Prenom = "Tasso" };

            Auteur a2 = new Auteur { Nom = "Olivier", Prenom = "Hondermarck" };

            Auteur a3 = new Auteur { Nom = "Thierry", Prenom = "Groussard" };
            Auteur a4 = new Auteur { Nom = "Nathan", Prenom = "Murray" };
            Auteur a5 = new Auteur { Nom = "Alexandre", Prenom = "Brillant" };
            Auteur a6 = new Auteur { Nom = "Henry", Prenom = "Logié" };
            Auteur a7 = new Auteur { Nom = "Barry", Prenom = "Burd" };
            Auteur a8 = new Auteur { Nom = "Pompidor", Prenom = "Pierre" };
            Auteur a9 = new Auteur { Nom = "Le Morvan", Prenom = "Hervé" };
            Auteur a10 = new Auteur { Nom = "Jérôme", Prenom = "Hugon" };
            Auteur a11 = new Auteur { Nom = "Gérard", Prenom = "Leblanc" };
            Auteur a12 = new Auteur { Nom = "Guérin", Prenom = "Brice - Arnaud " };
            Auteur a13 = new Auteur { Nom = "Djordjevic", Prenom = "Daniel" };
            Auteur a14 = new Auteur { Nom = "Vigouroux", Prenom = "Christian" };
            Auteur a15 = new Auteur { Nom = "LENTZNER", Prenom = "REMY" };


            Editeur e1 = new Editeur { Nom = "EYROLLES" };
            Editeur e2 = new Editeur { Nom = "DUNOD" };
            Editeur e3 = new Editeur { Nom = "ENI" };
            Editeur e4 = new Editeur { Nom = "Gistia" };
            Editeur e5 = new Editeur { Nom = "FIRST" };
            Editeur e6 = new Editeur { Nom = "REMYLENT" };

            c1.livres = new List<Livre>();
            c2.livres = new List<Livre>();
            c3.livres = new List<Livre>();
            c4.livres = new List<Livre>();

            Livre livre1 = new Livre
            {
            
                ISBN = "9782212674866",
                Titre = "java pour les debutants",
                Description = "Pour les débutants qui désirent s'initier à la programmation avec le langage Java comme support d'apprentissage. L'auteure expose les notions communes à tous les langages et propose de découvrir par la pratique les concepts de programmation orientée objet, le fonctionnement des librairies graphiques AWT et Swing, et les applications Java grâce au logiciel NetBeans.",
                Quantite = 5,
                Prix = 54.95m,
                NbPage = 598,
                DateSortie = new DateTime(2017, 12, 08),
                Photo = "img/imgLivre/java-premier-langage.jpg",
                Auteur = a1,
                Editeur = e1,
                Categorie = c1


            };


            c1.livres.Add(livre1);
            listeLivres.Add(livre1);
            Livre livre2 = new Livre
            {
                
                ISBN = "9782100814305",
                Titre = "JavaScript tout",
                Description = "Formation complète pour apprendre à utiliser ce langage informatique ou se perfectionner. Le manuel présente les bases et les bonnes pratiques de la programmation JavaScript à partir de la version ECMAScript 6. Il expose également les différents outils permettant l'interactivité avec les utilisateurs. Avec des exemples et des exercices accessibles sur le site Internet de l'auteur.",
                Quantite = 1,
                Prix = 50.95m,
                NbPage = 448,
                DateSortie = new DateTime(2021, 01, 27),
                Photo = "img/imgLivre/javascript_tout.jpg",
                Auteur = a2,
                Editeur = e1,
                Categorie = c2


            };

            c2.livres.Add(livre2);
            listeLivres.Add(livre2);
            Livre livre3 = new Livre
            {
                
                ISBN = "9782746077102",
                Titre = "C# 5 : les fondamentaux du langage : développer avec Visual Studio 2012",
                Description = "Manuel permettant de maîtriser le langage C# dans sa version 5, il abrode notamment les nouveautés en terme de programmation asynchrone et outils de débogage, très pratique pour finaliser une aplication",
                Quantite = 4,
                Prix = 44.95m,
                NbPage = 645,
                DateSortie = new DateTime(2013, 01, 08),
                Photo = "img/imgLivre/C_5.jpg",
                Auteur = a3,
                Editeur = e3,
                Categorie = c3


            };

            c3.livres.Add(livre3);
            listeLivres.Add(livre3);
            Livre livre4 = new Livre
            {
                
                ISBN = "9781985170285",
                Titre = "ng-book: The complet book of Angular",
                Description = "What if you could master the entire framework - with solid foundations - in less time without beating your head against a wall? Imagine how quickly you could work if you knew the best practices and the best tools?\r\n\r\nStop wasting your time searching and have everything you need to be productive in one, well-organized place, with complete examples to get your project up without needing to resort to endless hours of research.\r\n\r\nYou will learn what you need to know to work professionally with ng-book: The Complete Book on Angular.",
                Quantite = 2,
                Prix = 40.26m,
                NbPage = 626,
                DateSortie = new DateTime(2018, 02, 06),
                Photo = "img/imgLivre/ng-book-cover-ngb-ng-550.png",
                Auteur = a4,
                Editeur = e4,
                Categorie = c4


            };

            c4.livres.Add(livre4);
            listeLivres.Add(livre4);
            Livre livre5 = new Livre
            {
                
                ISBN = "9782746053021",
                Titre = "Java 6",
                Description = "Les bases nécessaires pour se familiariser avec le langage Java. Les exemples cités sont en téléchargement sur le site de l'éditeur. Permet d'acquérir une réelle productivité sur Java 6 en partant des bases du langage jusqu'aux nouveautés de la version 6.0.",
                Quantite = 3,
                Prix = 74.95m,
                NbPage = 645,
                DateSortie = new DateTime(2010, 02, 23),
                Photo = "img/imgLivre/java6.jpg",
                Auteur = a5,
                Editeur = e3,
                Categorie = c1


            };

            c1.livres.Add(livre5);
            listeLivres.Add(livre5);
            Livre livre6 = new Livre
            {
                
                ISBN = "9782746097902",
                Titre = "Java-Eclipse",
                Description = "Ce livre sur Java et Eclipse s'adresse aux développeurs et étudiants en informatique. Il fait le lien entre les connaissances théoriques et pratiques en prenant appui sur le développement d'une application de gestion. De la compréhension des concepts de la POO en passant par l'analyse, le lecteur est guidé pas à pas dans la construction de l'application. Pour la partie développement qui constitue l'essentiel de l'ouvrage, les points forts sont l'exploitation d'une base de données multitables avec MySQL et JPA, l'écriture des principales classes suite à une approche génie logicielle basée sur UML, la mise en œuvre du pattern MVC.",
                Quantite = 2,
                Prix = 59.95m,
                NbPage = 548,
                DateSortie = new DateTime(2016, 01, 05),
                Photo = "img/imgLivre/java-eclipse.jpg",
                Auteur = a6,
                Editeur = e3,
                Categorie = c1


            };


            c1.livres.Add(livre6);
            listeLivres.Add(livre6);

            Livre livre7 = new Livre
            {
                
                ISBN = "9782746075078",
                Titre = "Java-Netbeans",
                Description = "Ce livre sur Java et NetBeans s'adresse aux développeurs, étudiants en informatique et autodidactes confirmés. Il fait le lien entre les connaissances théoriques et pratiques en prenant appui sur le développement d'une application de gestion. De la compréhension des concepts de la POO en passant par l'analyse, le lecteur est guidé pas à pas dans la construction de l'application. Pour la partie développement qui constitue l'essentiel de l'ouvrage, les points forts sont l'exploitation d'une base de données multitables avec MySQL et JDBC, l'écriture des principales classes suite à une approche génie logicielle basée sur UML, et la mise en œuvre du pattern MVC.",
                Quantite = 9,
                Prix = 54.95m,
                NbPage = 426,
                DateSortie = new DateTime(2012, 09, 25),
                Photo = "img/imgLivre/java-et-netbeans.jpg",
                Auteur = a6,
                Editeur = e3,
                Categorie = c1


            };


            c1.livres.Add(livre7);
            listeLivres.Add(livre7);

            Livre livre8 = new Livre
            {
                
                ISBN = "9782212245806",
                Titre = "Java exercices",
                Description = "Vous apprendrez d'abord, à travers des exemples simples en Java, à maîtriser les notions communes à tous les langages : variables, types de données, boucles et instructions conditionnelles, etc. Vous franchirez un nouveau pas en découvrant par la pratique les concepts de la programmation orientée objet (classes, objets, héritage), puis le fonctionnement des librairies graphiques AWT et Swing (fenêtres, gestion de la souris, tracé de graphiques). Cet ouvrage vous expliquera aussi comment réaliser des applications Java dotées d'interfaces graphiques conviviales grâce au logiciel libre NetBeans. Enfin, vous vous initierez au développement d'applications pour téléphones mobiles Android",
                Quantite = 2,
                Prix = 28.84m,
                NbPage = 426,
                DateSortie = new DateTime(2013, 11, 07),
                Photo = "img/imgLivre/java-exercices.jpg",
                Auteur = a1,
                Editeur = e1,
                Categorie = c1


            };


            c1.livres.Add(livre8);
            listeLivres.Add(livre8);

            Livre livre9 = new Livre
            {
                
                ISBN = "9782754058155",
                Titre = "Java-Nuls",
                Description = "Grâce à ce livre, vous allez rapidement écrire rapidement vos premières applets Java, sans pour autant devenir un gourou de la programmation objet. Rassurez-vous, on ne vous assommera pas avec toutes les subtilités du langage Java, mais vous posséderez rapidement les bases nécessaires pour utiliser la panoplie d'outils du parfait programmeur Java.",
                Quantite = 1,
                Prix = 28,
                NbPage = 424,
                DateSortie = new DateTime(2014, 12, 07),
                Photo = "img/imgLivre/java-pour-les-nuls.jpg",
                Auteur = a7,
                Editeur = e5,
                Categorie = c1


            };


            c1.livres.Add(livre9);
            listeLivres.Add(livre9);

            Livre livre10 = new Livre
            {
                
                ISBN = "9782212678406",
                Titre = "Java-Premier",
                Description = "Apprendre Java en douceurVous avez décidé de vous initier à la programmation et souhaitez opter pour un langage largement utilisé dans le monde professionnel ? Java se révèle un choix idéal comme vous le constaterez dans ce livre conçu pour les vrais débutants en programmation.Vous apprendrez d'abord, à travers des exemples simples en Java, à maîtriser les notions communes à tous les langages : variables, types de données, boucles et instructions conditionnelles, etc",
                Quantite = 8,
                Prix = 68,
                NbPage = 426,
                DateSortie = new DateTime(2015, 11, 10),
                Photo = "img/imgLivre/java-premier-langage.jpg",
                Auteur = a1,
                Editeur = e1,
                Categorie = c1


            };


            c1.livres.Add(livre10);
            listeLivres.Add(livre10);


            Livre livre11 = new Livre
            {
                
                ISBN = "B1234453",
                Titre = "Angular",
                Description = "Apprendre Angular",
                Quantite = 1,
                Prix = 89,
                NbPage = 645,
                DateSortie = new DateTime(),
                Photo = "img/imgLivre/angular.png",
                Auteur = a2,
                Editeur = e2,
                Categorie = c4


            };

            c4.livres.Add(livre11);
            listeLivres.Add(livre11);

            dateEdition = new DateTime(2019, 10, 02);
            Livre livre12 = new Livre
            {
                
                ISBN = "9782409019616",
                Titre = "Angular et Node.js",
                Description = "Ce livre s'adresse à tout informaticien qui souhaite optimiser le développement industriel de ses applications web " +
                "avec la mise en place d'une architecture MEAN (basée sur MongoDB, le framework Express," +
                " le framework Angular et un serveur Node.js). L'auteur lui donne les clés pour répondre aux nouvelles exigences de plus" +
                " en plus fortes de ce type de développement, à savoir le besoin de réutiliser des briques logicielles pour augmenter " +
                "la productivité du développement et l'optimisation de la charge des serveurs qui ne cesse d'augmenter.",
                Quantite = 2,
                Prix = 59.95m,
                NbPage = 354,
                DateSortie = dateEdition,
                Photo = "img/imgLivre/angular_nodejs.jpg",
                Auteur = a8,
                Editeur = e2,
                Categorie = c4


            };

            c4.livres.Add(livre12);
            listeLivres.Add(livre12);


            Livre livre13 = new Livre
            {
                
                ISBN = "9782409009280",
                Titre = "C# 7",
                Description = "Découverte de l'environnement des bases du langage de C# 7 et des possibilités les plus avancées offertes par ce langage, Visual studio et le framework. Avec un exemple du code de l'application à télécharger sur Internet.",
                Quantite = 9,
                Prix = 64.95m,
                NbPage = 508,
                DateSortie = new DateTime(2017, 09, 19),
                Photo = "img/imgLivre/C_7.jpg",
                Auteur = a10,
                Editeur = e3,
                Categorie = c3


            };

            c3.livres.Add(livre13);
            listeLivres.Add(livre13);


            Livre livre14 = new Livre
            {
               
                ISBN = "9782212117783",
                Titre = "C# et Net",
                Description = "Un langage et une plate-forme matures. Nouveau langage phare de Microsoft, C# combine les meilleurs aspects des langages C++, Visual Basic et Java, et s'avère en effet d'une facilité incomparable pour créer des applications Windows et Web, même pour des programmeurs non chevronnés. Ce langage a été spécialement conçu pour la plate-forme NET qui, outre Visual Studio.NET, regroupe l'interface ADO.NET simplifiant l'accès aux bases de données et la technologie ASRNET permettant d'implémenter des services Web. Après une première partie consacrée à la syntaxe du langage C# version 2, cet ouvrage explique comment développer des applications Windows et Web avec la plate-forme NET. La troisième partie du livre est consacrée à l'accès aux données avec ADO.NET 2 et la quatrième aux applications et services Web avec ASRNET 2. Les lecteurs tireront ainsi profit des nouveautés introduites dans les logiciels de la famille Visual Studio 2005, tels que les aides au remaniement de programmes, les nouveaux contrôles pour ordinateurs de bureau, PocketPC et Smartphones, les techniques génériques d'accès aux bases de données, ou encore le déploiement CIickOnce de programmes. Le code source de tous les exemples du livre est disponible sur www.editions-eyrolles.com.",
                Quantite = 1,
                Prix = 84.95m,
                NbPage = 645,
                DateSortie = new DateTime(2006, 03, 15),
                Photo = "img/imgLivre/C_Net.jpg",
                Auteur = a11,
                Editeur = e1,
                Categorie = c3


            };

            c3.livres.Add(livre14);
            listeLivres.Add(livre14);


            Livre livre15 = new Livre
            {
                
                ISBN = "9782409040405",
                Titre = "ASP.NET",
                Description = "Etude complète de la technologie ASP.Net et de Visual Studio 2022, fondée sur des exemples fournis en C# : applications IIS, sites MVC, bases de données ADO.Net (avec notamment les composants relatifs à LINQ, entity framework et aux états Reporting services), sécurisation unifiée de sites web OWIN, personnalisation de la navigation, mise en production ou encore infrastructure de supervision.",
                Quantite = 6,
                Prix = 64.95m,
                NbPage = 552,
                DateSortie = new DateTime(2013, 06, 07),
                Photo = "img/imgLivre/ASP.NET.jpg",
                Auteur = a12,
                Editeur = e3,
                Categorie = c3


            };

            c3.livres.Add(livre15);
            listeLivres.Add(livre15);

            dateEdition = new DateTime(2022, 02, 09);
            Livre livre16 = new Livre
            {
                
                ISBN = "9782409034084",
                Titre = "Angular Développez vos applications web avec le framework JavaScript de Google (3e édition)",
                Description = "Ce livre permet aux lecteurs de se lancer dans le développement d'applications web avec le framework Angular (en version 12 au moment de l'écriture). " +
                "Pour une meilleure compréhension de son contenu, " +
                "il est nécessaire d'avoir un minimum de connaissances sur le fonctionnement du web et sur les langages HTML et JavaScript." +
                " Les auteurs ont eu à coeur de rédiger un livre très pragmatique avec de nombreux exemples de code, commentés et expliqués," +
                " qui illustrent de façon très concrète les passages plus théoriques. Conçu pour être un allié efficace au quotidien, " +
                "ce livre à la structure claire constitue un réel référentiel Angular pour le développeur.",
                Quantite = 1,
                Prix = 59.95m,
                NbPage = 356,
                DateSortie = dateEdition,
                Photo = "img/imgLivre/angular_de_google.jpg",
                Auteur = a13,
                Editeur = e3,
                Categorie = c4


            };

            c4.livres.Add(livre16);
            listeLivres.Add(livre16);

            Livre livre17 = new Livre
            {
                
                ISBN = "9782409038341",
                Titre = "JavaScript, Développez efficacement (4e édition)",
                Description = "Ce livre sur JavaScript s'adresse à des développeurs soucieux de progresser dans leurs compétences JavaScript et de passer de " +
                "la maîtrise syntaxique à la maîtrise du cycle de développement complet. " +
                "Une première expérience du développement avec JavaScript," +
                " dans sa syntaxe de base, est indispensable à la bonne compréhension de cet ouvrage.",
                Quantite = 5,
                Prix = 59.95m,
                NbPage = 446,
                DateSortie = new DateTime(2023, 01, 11),
                Photo = "img/imgLivre/javascript_efficacement.png",
                Auteur = a5,
                Editeur = e3,
                Categorie = c2

            };



            Livre livre18 = new Livre
            {
                
                ISBN = "9782746080478",
                Titre = "JavaScript : développez efficacement",
                Description = "Présentation du développement de JavaScript afin de démarrer dans la gestion de projet web pour un usage classique ou mobile. Permet également d'utiliser plus facilement des Frameworks web adaptés au contexte d'exploitation comme JQuery ou Dojo.",
                Quantite = 5,
                Prix = 69.95m,
                NbPage = 430,
                DateSortie = new DateTime(2013, 06, 25),
                Photo = "img/imgLivre/javascript_efficacement.png",
                Auteur = a5,
                Editeur = e3,
                Categorie = c2

            };

            c2.livres.Add(livre18);
            listeLivres.Add(livre18);


            Livre livre19 = new Livre
            {
                
                ISBN = "9782409032837",
                Titre = "Apprendre à développer avec JavaScript",
                Description = "Ce livre sur l'apprentissage du langage JavaScript s'adresse à des lecteurs qui souhaitent maîtriser cette brique incontournable " +
                " et omniprésente dans le développement de sites web (intranet, extranet, internet) et dans celui d’applications hybrides pour smartphones et tablettes" +
                 "En effet, même si des solutions logicielles existent pour contourner la connaissance du langage JavaScript" +
                "sa maîtrise est un atout essentiel pour acquérir une expertise dans le domaine des technologies du Web 2.0.",
                Quantite = 5,
                Prix = 49.95m,
                NbPage = 430,
                DateSortie = new DateTime(2022, 02, 15),
                Photo = "img/imgLivre/javascript-apprendre.png",
                Auteur = a14,
                Editeur = e3,
                Categorie = c2

            };

            c2.livres.Add(livre19);
            listeLivres.Add(livre19);


            dateEdition = new DateTime(2020, 07, 01);
            Livre livre20 = new Livre
            {
                
                ISBN = "9782490275335",
                Titre = "Bien débuter avec JavaScript",
                Description = "Ce livre s'adresse aux personnes qui souhaitent apprendre à écrire du code JavaScript. " +
                "Ce langage est utilisé pour contrôler les éléments des pages Web tout en s'intégrant harmonieusement " +
                "avec le code HTML Vous découvrirez la structure objet du langage " +
                "et son interaction avec le DOM (Document Object Model) qu'on représente par un arbre à balises. " +
                "Vous manipulerez les variables, les expressions conditionnelles," +
                " les boucles tout en vous exerçant grâce aux très nombreux exercices proposés dans ce livre. .",
                Quantite = 1,
                Prix = 48.01m,
                NbPage = 130,
                DateSortie = dateEdition,
                Photo = "img/imgLivre/javascript-bien-demarrer.jpg",
                Auteur = a15,
                Editeur = e6,
                Categorie = c2

            };

            c2.livres.Add(livre20);
            listeLivres.Add(livre20);


            dateEdition = new DateTime(2022, 08, 17);
            Livre livre21 = new Livre
            {
                
                ISBN = "9782409036552",
                Titre = "Java Spring",
                Description = "Ce livre apporte les éléments clés pour se repérer dans les différentes technologies utilisées " +
                "dans les projets basés sur Spring. " +
                "Il prend en compte les différences de configuration liées aux versions de Spring (en version 4.3 et 5.3 " +
                "au moment de l'écriture) et se base sur des exemples concrets d'utilisation. Il permet au lecteur d'être " +
                "très rapidement autonome sur un projet d'entreprise qui utilise Spring, que ce soit au début " +
                "d'un nouveau projet ou pour maintenir un projet existant : compréhension du noyau, accès aux données, " +
                "maîtrise de la couche web. Des connaissances sur le développement Java et notamment " +
                "le développement d'applications web sont un prérequis indispensable pour tirer le meilleur parti possible du livre.",
                Quantite = 1,
                Prix = 79.95m,
                NbPage = 656,
                DateSortie = dateEdition,
                Photo = "img/imgLivre/java_spring.jpg",
                Auteur = a9,
                Editeur = e3,
                Categorie = c1

            };

            c1.livres.Add(livre21);
            listeLivres.Add(livre21);



            return new Categorie?[] { c1, c2, c3, c4 };
        }


    }
}

