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
    /// Logique d'interaction pour GestionEventParam.xaml
    /// </summary>
    public partial class GestionEventParam : Window
    {
        ViewModel.VM_GestionEventParam LocalEventParam;
        public GestionEventParam()
        {
            InitializeComponent();
            LocalEventParam = new ViewModel.VM_GestionEventParam();
            DataContext = LocalEventParam;
        }

        private void Cbequipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            { if (LocalEventParam.EquipeSelectionne.ID_Equipe !=0 ) 
             LocalEventParam.RemplirdgmembreEquipe(); }

        }

        private void DgBeneficiaireList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgBeneficiaireEq.SelectedItem = null;
        }

        private void DgBeneficiaireEq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgBeneficiaireList.SelectedItem = null;
        }
    }
}
