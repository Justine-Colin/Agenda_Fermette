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
        }

        public void AfficherJourBouton()
        //Change le nom des jours sur les boutons selon le jour d'ajd
        {
            DateTime Ajd = new DateTime();
            //Récupère la date du jour
            Ajd = DateTime.Now;
            //Notifie le programme que la langue à utiliser est le français
            var Langue = new System.Globalization.CultureInfo("fr-FR");
            //Boucle pour la semaine
            for(int i = 0; i < 7; i++)
            {
                /*Va rechercher le jour d'aujourd'hui en anglais avec DayOfWeek
                 * Puis ajoute i pour arriver au jour souhaité
                 * puis traduit en français 
                 */
                var Jour = Langue.DateTimeFormat.GetDayName(Ajd.DayOfWeek + i);
                //Ajoute les jours pour changer la date
                DateTime Date = Ajd.AddDays(i);
                //Remplace la première lettre par une majuscule et ajoute la date derrière /!\ MM donne le mois mm donne les minutes
                Jour = char.ToUpper(Jour[0]) + Jour.Substring(1) + " " + Date.ToString("dd/MM");
                //Prépare le string de la marge
                //Crée le bouton correspondant
                Button Bouton = new Button
                {
                    Name = "Jour_" + i,                    
                    //Le place sur la page
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 274,
                    Height = 50,
                    Visibility = Visibility.Visible
                };
                //Remplit avec le jour qu'il faut
                Bouton.Content = Jour;
                Semaine.Children.Add(Bouton);
            } 
        }
    }
}
