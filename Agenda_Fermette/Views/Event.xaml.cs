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
using System.Windows.Shapes;
using Agenda_Fermette.ViewModels;

namespace Agenda_Fermette.Views
{
    /// <summary>
    /// Logique d'interaction pour Event.xaml
    /// </summary>
    public partial class Event : Window
    {
        private Event_VM vm;
        public Event(int id)
        {
            InitializeComponent();
             vm = new Event_VM(id);
            Afficher();
        }

        public void Afficher()
        {
            Titre.Text = vm.Titre.ToString();
            Desc.Text = vm.Descriptif.ToString();
            Lieu.Text = "Cela se passe à " + vm.Lieu.ToString();
            Debut.Text = "Cela commence à " + vm.HeureDebut.ToString();
            Fin.Text = "Cela se termine à " + vm.HeureFin.ToString();
        }
    }
}
