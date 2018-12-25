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
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Encodage_Fermette.View
{
    /// <summary>
    /// Logique d'interaction pour GestionPersonne.xaml
    /// </summary>
    /// 
    public partial class GestionPersonne : Window
    {
        private ViewModel.VM_Staff LocalStaff;

        public GestionPersonne()
        {
            InitializeComponent();
            LocalStaff = new ViewModel.VM_Staff();
            DataContext = LocalStaff;
        }
        private void dgStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { if (dgStaff.SelectedIndex >= 0) LocalStaff.PersonneSelectionnee2UnePersonne(); }

    }
}
