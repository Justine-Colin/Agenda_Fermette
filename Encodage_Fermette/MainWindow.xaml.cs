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

namespace Encodage_Fermette
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void btn_Gestion_Staff(object sender, RoutedEventArgs e)
        {
            View.GestionStaff f = new View.GestionStaff();
            f.ShowDialog();
        }
        public void btn_Gestion_Beneficiaire(object sender, RoutedEventArgs e)
        {
            View.GestionBeneficiaires f = new View.GestionBeneficiaires();
            f.ShowDialog();
        }

        private void btn_Gestion_Menu(object sender, RoutedEventArgs e)
        {
            View.GestionMenu f = new View.GestionMenu();
            f.ShowDialog();
        }
    }
}
