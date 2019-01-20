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

namespace Encodage_Fermette.View
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class GestionMenu : Window
    {
        private ViewModel.VM_Menu LocalMenu;
        public GestionMenu()
        {
            InitializeComponent();
            LocalMenu = new ViewModel.VM_Menu();
            DataContext = LocalMenu;
        }
        private void dgMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { if (dgMenu.SelectedIndex >= 0) LocalMenu.MenuSelectionne2UnMenu();}
    }
}
