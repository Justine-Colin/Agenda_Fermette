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
    /// Logique d'interaction pour GestionBeneficiaires.xaml
    /// </summary>
    public partial class GestionBeneficiaires : Window
    {
        private ViewModel.VM_Beneficiaire LocalBeneficiaire;

        public GestionBeneficiaires()
        {
            InitializeComponent();
            LocalBeneficiaire = new ViewModel.VM_Beneficiaire();
            DataContext = LocalBeneficiaire;
        }
        private void dgBeneficiaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { if (dgBeneficiaire.SelectedIndex >= 0) LocalBeneficiaire.PersonneSelectionnee2UnePersonne(); }

    }
}
