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
using CoucheAcces;
using CoucheClasse;
using CoucheGestion;
using System.Collections.ObjectModel;
using Agenda_Fermette.ViewModels;

namespace Agenda_Fermette
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //BDD dans Agenda_Fermette/bin/Debug/Database1.mdf
        private string sChConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        private MainWindow_VM vm = new MainWindow_VM();

        public MainWindow()
        {
            InitializeComponent();
            AfficherJourBouton();
            vm.ChargerImportant(DateTime.Now); //! Non implémenté
            AfficherImportant(); //! Non implémenté
            Jour_Click(J_0, null);
            //?AfficherImportant();
        }

        //Enlève les bordures et passe en full screen
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }

        //Permet de quitter le programme si appui sur ESC
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // On veut quitter le programme
                if (MessageBox.Show("Êtes-vous sûr de vouloir quitter ?", "Confirmer", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    this.Close();
            }
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
            for (int i = 0; i < 7; i++)
            {
                int Num = (int)Ajd.DayOfWeek + i; //Détermine le numéro du jour
                                                  /*Va rechercher le jour d'aujourd'hui en anglais avec DayOfWeek
                                                   * Puis ajoute i pour arriver au jour souhaité
                                                   * puis traduit en français 
                                                   */
                if (Num <= 6) //Les numéros des jours vont de 0 à 6 (Dim -> Sam) Si plus haut : out of range
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

        private void Jour_Click(object sender, RoutedEventArgs e)
        //Clic sur un bouton => changement affichage
        {
            //Récupère le contenu du bouton (jour + date)
            string content = (sender as Button).Content.ToString();
            //Split sur l'espace pour séparer jour et date dans un tableau
            string[] tab = content.Split(' ');
            //Récupère la date dans le tableau
            string Jour = tab[1];
            //Transforme le string en DateTime
            DateTime Date = DateTime.Parse(Jour);
            //? L'envoie au ViewModel
            //? vm.Date = Date;
            //Chargement selon date
            //TODO vm.ChargerAnnif(Date); problème dans la couche gestion G_Vue_Personne => boucle infinie
            vm.ChargerEvents(Date);       
            vm.ChargerMenu(Date);
            //Affichage
            AfficherAnnif();
            AfficherInfo();
            AfficherMenu();
            /*?
            //Lance les 3 fonctions d'affichage dépendant du jour
            AfficherMenu(Date);
            AfficherAnnif(Date);
            AfficherInfo(Date);*/
        }

        public void AfficherAnnif()
        {
            int i = 1; //On commence à 1 car Row[0]=Titre colonne
            foreach(var p in vm.Liste_Annif)
            {
                RowDefinition row = new RowDefinition();
                Annif.RowDefinitions.Add(row);
                Viewbox vb = new Viewbox();
                Grid.SetRow(vb, i);
                Grid.SetColumn(vb, 0);
                TextBlock tb = new TextBlock
                {
                    Text = p.Pre1 + " " + p.Nom1
                };
                vb.Child = tb;
                i++;
            }
        }
        public void AfficherInfo()
        {
            int i = 1; //On commence à 1 car Row[0]=Titre colonne
            foreach (var info in vm.ListeInfo)
            {
                RowDefinition row = new RowDefinition();
                Infos.RowDefinitions.Add(row);
                Viewbox vb = new Viewbox();
                Grid.SetRow(vb, i);
                Grid.SetColumn(vb, 0);
                TextBlock tb = new TextBlock
                {
                    Text = info.Ti_Descr
                };
                vb.Child = tb;
                i++;
            }
        }
        public void AfficherMenu()
        {
            Entree.Text = vm.Entree;
            Plat.Text = vm.Plat;
            Dessert.Text = vm.Dessert;
            Collation.Text = vm.Collation;
        }
        public void AfficherImportant()
        {
            /*TODO
             * Afficher la liste d'events important avec sont ayants lieux le lendemain au dessus
             */
        }
        /*******************************************************************************************************************************************************************/
        /*?
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
            }
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
            }            
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
            }
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
            }
        }*/

        
    }
}
