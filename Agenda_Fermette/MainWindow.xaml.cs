using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda_Fermette
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Il faut s'arranger pour gérer la taille des éléments en relatif

        public MainWindow()
        {            
            InitializeComponent();
            AfficherJourBouton();
            AfficherImportant();
            Jour_Click(J_0, null);
        }

        public void AfficherJourBouton()
        //Change le nom des jours sur les boutons selon le jour d'ajd
        {
            string Jour;
            DateTime Ajd = new DateTime();
            //Récupère la date du jour
            Ajd = DateTime.Now;
            //Notifie le programme que la langue à utiliser est le français
            var Langue = new System.Globalization.CultureInfo("fr-FR");
            //Boucle pour la semaine
            for(int i = 0; i < 7; i++)
            {
                int Num = (int)Ajd.DayOfWeek + i; //Détermine le numéro du jour
                /*Va rechercher le jour d'aujourd'hui en anglais avec DayOfWeek
                 * Puis ajoute i pour arriver au jour souhaité
                 * puis traduit en français 
                 */
                 if(Num <= 6) //Les numéros des jours vont de 0 à 6 (Dim -> Sam) Si plus haut : out of range
                 {
                    Jour = Langue.DateTimeFormat.GetDayName(Ajd.DayOfWeek + i);
                 }                    
                 else //Si le num est plus grand que 6, on fait -7 pour le ramener dans le range
                 {
                    Jour = Langue.DateTimeFormat.GetDayName(Ajd.DayOfWeek + i - 7);
                 }
                //Ajoute les jours pour changer la date
                DateTime Date = Ajd.AddDays(i);
                //Remplace la première lettre par une majuscule et ajoute la date derrière /!\ MM donne le mois mm donne les minutes
                Jour = char.ToUpper(Jour[0]) + Jour.Substring(1) + " " + Date.ToString("dd/MM");
                //Recrée le nom du bouton à utiliser
                string Nom = "J_" + i;
                //Va rechercher ce bouton
                Button Bouton = (Button)FindName(Nom);
                //Remplace le texte
                Bouton.Content = Jour;
            } 
        }

        public void AfficherImportant()
         //Affiche les events importants de la semaine (sur tous les jours)
        {
            /*foreach(var Evenement in T_Event)
            {
                DateTime Jour = DateTime.MinValue;
                //Date de demain
                DateTime Demain = DateTime.Now.AddDays(1);
                //Date d'une semaine + tard
                DateTime Semaine = DateTime.Now.AddDays(7);
                //Evenement à afficher 1 jour à l'avance a priorité 1
                if (Evenement.Ev_Priorite == 1) 
                {
                    //On va rechercher la date
                    foreach(var Liaison in T_Li_Event)
                    {
                        if(Liaison.ID_Event == Evenement.ID_Event)
                        {
                            foreach(var Date in T_Date)
                            {
                                if(Liaison.ID_Date = Date.ID_Date)
                                {
                                    Jour = Date.ID_Date;
                                }
                            }
                        }
                    }
                    //On vérifie si on doit afficher l'événement dans important
                    if(Jour == Demain)
                    {
                        //Affichage dans des textbox
                        Important.Children.Add(new TextBox
                        {
                            Text = Evenement.Ev_Titre + " : " + Evenement.Ev_Descriptif
                        });
                    }
                }

                //Evenement à afficher 1 semaine à l'avance a priorité 2
                if (Evenement.Ev_Priorite == 2)
                {
                    foreach (var Liaison in T_Li_Event)
                    {
                        if (Liaison.ID_Event == Evenement.ID_Event)
                        {
                            foreach (var Date in T_Date)
                            {
                                if (Liaison.ID_Date = Date.ID_Date)
                                {
                                    Jour = Date.ID_Date;
                                }
                            }
                        }
                    }
                    //On vérifie si on doit afficher l'événement dans important
                    if (Jour == Semaine)
                    {
                        //Affichage dans des textbox
                        Important.Children.Add(new TextBox
                        {
                            Text = Evenement.Ev_Titre + " : " + Evenement.Ev_Descriptif
                        });
                    }
                }
            }*/
        }

        public void AfficherMenu(DateTime Jour)
        //Affiche le menu du jour sur la droite
        {
            /*DateTime jour = DateTime.MinValue;
            //On va rechercher la date
            foreach (var Date in T_Date)
            {
                if (Date.D_Jour == Jour)
                {
                    foreach(var Menus in T_Menu)
                    {
                        if(Menus.ID_Menu == Date.ID_Menu)
                        {
                            foreach(var Nour in T_Nourriture)
                            {
                                //Affichage entrée
                                if(Nour.ID_Nourriture == Menus.ID_Entree)
                                {
                                    Menu.Children.Add(new TextBox
                                    {
                                        Text = "Entrée : " + Nour.No_Nom
                                    });
                                    string path = @"Images/Menu/Entrée/" + Nour.No_Nom;
                                    Menu.Children.Add(new Image
                                    {
                                        Source = new BitmapImage(new Uri(path, UriKind.Relative))
                                    });
                                }
                                //Affichage plat
                                if (Nour.ID_Nourriture == Menus.ID_Plat)
                                {
                                    Menu.Children.Add(new TextBox
                                    {
                                        Text = "Plat : " + Nour.No_Nom
                                    });
                                    string path = @"Images/Menu/Plat/" + Nour.No_Nom;
                                    Menu.Children.Add(new Image
                                    {
                                        Source = new BitmapImage(new Uri(path, UriKind.Relative))
                                    });
                                }
                                //Affichage Dessert
                                if (Nour.ID_Nourriture == Menus.ID_Dessert)
                                {
                                    Menu.Children.Add(new TextBox
                                    {
                                        Text = "Dessert : " + Nour.No_Nom
                                    });
                                    string path = @"Images/Menu/Dessert/" + Nour.No_Nom;
                                    Menu.Children.Add(new Image
                                    {
                                        Source = new BitmapImage(new Uri(path, UriKind.Relative))
                                    });
                                }
                                //Affichage collation
                                if (Nour.ID_Nourriture == Menus.ID_Collation)
                                {
                                    Menu.Children.Add(new TextBox
                                    {
                                        Text = "Collation : " + Nour.No_Nom
                                    });
                                    string path = @"Images/Menu/Collation/" + Nour.No_Nom;
                                    Menu.Children.Add(new Image
                                    {
                                        Source = new BitmapImage(new Uri(path, UriKind.Relative))
                                    });
                                }
                            }
                        }

                    }
                }
            }*/            
        }

        public void AfficherAnnif(DateTime Jour)
        //Affiche les anniversaires à gauche
        {
            /*DateTime jour = DateTime.MinValue;
            //Evenement à afficher 1 jour à l'avance a priorité 1
            //On va rechercher la date
            foreach (var Liaison in T_Li_Event)
            {
                if (Liaison.ID_Event == Evenement.ID_Event)
                {
                    foreach (var Date in T_Date)
                    {
                        if (Liaison.ID_Date = Date.ID_Date)
                        {
                            jour = Date.ID_Date;
                        }
                    }
                }
            }
            //On vérifie si on doit afficher l'événement
            if (Jour == jour)
            {
                //Affichage dans des textbox
                Important.Children.Add(new TextBox
                {
                    Text = Evenement.Ev_Titre
                });
            }*/
        }

        public void AfficherInfo(DateTime Jour)
        //Affiche les info au milieu
        {
           /* foreach (var Evenement in T_Event)
            {
                DateTime jour = DateTime.MinValue;              
                //Evenement à afficher 1 jour à l'avance a priorité 1
                //On va rechercher la date
                foreach (var Liaison in T_Li_Event)
                {
                    if (Liaison.ID_Event == Evenement.ID_Event)
                    {
                        foreach (var Date in T_Date)
                        {
                            if (Liaison.ID_Date = Date.ID_Date)
                            {
                                    jour = Date.ID_Date;
                            }
                        }
                    }
                }
                //On vérifie si on doit afficher l'événement
                if (Jour == Jour)
                {
                    //Affichage dans des textbox
                    Important.Children.Add(new TextBox
                    {
                        Text = Evenement.Ev_Titre
                    });
                }
            }*/
        }

        private void Jour_Click(object sender, RoutedEventArgs e)
        //Clic sur un bouton => changement affichage
        {
            //Récupère le contenu du bouton (jour + date)
            string content = (sender as Button).Content.ToString();
            //Split sur l'espace pour séparer jour et date dans un tableau
            string[] tab = content.Split(' ');
            //Transforme le string en DateTime
            string Jour = tab[1];
            DateTime Date = DateTime.Parse(Jour);
            //Lance les 3 fonctions d'affichage dépendant du jour
            AfficherMenu(Date);
            AfficherAnnif(Date);
            AfficherInfo(Date);
        }
    }
}
