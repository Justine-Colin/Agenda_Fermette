using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;

namespace Encodage_Fermette.ViewModel
{
    public class VM_Beneficiaire : BasePropriete
    {
        #region Données Ecran 
        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        private int nAjout;
        private bool _ActiverUneFiche;
        public bool ActiverUneFiche
        {
            get { return _ActiverUneFiche; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche = !ActiverUneFiche;
            }
        }
        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Beneficiaire _BeneficiairefSelectionne;
        public C_T_Beneficiaire BeneficiairefSelectionne
        {
            get { return _BeneficiairefSelectionne; }
            set { AssignerChamp<C_T_Beneficiaire>(ref _BeneficiairefSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Donnéees extérieur
        private VM_Un_Beneficiaire _UnBeneficiaire;
        public VM_Un_Beneficiaire UnBeneficiaire
        {
            get { return _UnBeneficiaire; }
            set { AssignerChamp<VM_Un_Beneficiaire>(ref _UnBeneficiaire, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Beneficiaire> _BcpBeneficiaire = new ObservableCollection<C_T_Beneficiaire>();
        public ObservableCollection<C_T_Beneficiaire> BcpBeneficiaire
        {
            get { return _BcpBeneficiaire; }
            set { _BcpBeneficiaire = value; }
        }
        #endregion

        #region Commandes 
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        #endregion

        private ObservableCollection<C_T_Beneficiaire> ChargerBeneficaire(string chConn)
        {
            ObservableCollection<C_T_Beneficiaire> rep = new ObservableCollection<C_T_Beneficiaire>();
            List<C_T_Beneficiaire> lTmp = new CoucheGestion.G_T_Beneficiaire(chConn).Lire("ID");
            foreach (C_T_Beneficiaire Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnBeneficiaire.ID = new G_T_Beneficiaire(chConnexion).Ajouter(UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                BcpBeneficiaire.Add(new C_T_Beneficiaire(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe));
            }
            else
            {
                new CoucheGestion.G_T_Beneficiaire(chConnexion).Modifier(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                BcpBeneficiaire[nAjout] = new C_T_Beneficiaire(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
            }
            ActiverUneFiche = false;
        }

        public class VM_Un_Beneficiaire : BasePropriete
        {
            private int _ID;
            private string _Nom, _Pre, _Poste;
            private DateTime _Nai;
            private bool _Sexe;

            public int ID
            {
                get { return _ID; }
                set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string Pre
            {
                get { return _Pre; }
                set { AssignerChamp<string>(ref _Pre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string Nom
            {
                get { return _Nom; }
                set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public DateTime Nai
            {
                get { return _Nai; }
                set { AssignerChamp<DateTime>(ref _Nai, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string Poste
            {
                get { return _Poste; }
                set { AssignerChamp<string>(ref _Poste, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public bool Sexe
            {
                get { return _Sexe; }
                set { AssignerChamp<bool>(ref _Sexe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

        }

    }
}
