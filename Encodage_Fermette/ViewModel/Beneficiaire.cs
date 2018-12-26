using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheAcces;
using CoucheClasse;
    using System.Collections.ObjectModel;

namespace Encodage_Fermette.ViewModel
{
    public class VM_Beneficiaire : BasePropriete
    {
        #region Données Écran
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
        private C_T_Beneficiaire _BeneficiaireSelectionnee;
        public C_T_Beneficiaire BeneficiaireSelectionnee
        {
            get { return _BeneficiaireSelectionnee; }
            set { AssignerChamp<C_T_Beneficiaire>(ref _BeneficiaireSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UnBeneficiaire _UnBeneficiaire;
        public VM_UnBeneficiaire UnBeneficiaire
        {
            get { return _UnBeneficiaire; }
            set { AssignerChamp<VM_UnBeneficiaire>(ref _UnBeneficiaire, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Beneficiaire> _BcpBeneficiaires = new ObservableCollection<C_T_Beneficiaire>();
        public ObservableCollection<C_T_Beneficiaire> BcpBeneficiaires
        {
            get { return _BcpBeneficiaires; }
            set { _BcpBeneficiaires = value; }
        }
        #endregion
        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        #endregion
        public VM_Beneficiaire()
        {
            UnBeneficiaire = new VM_UnBeneficiaire();
            UnBeneficiaire.ID = 24;
            UnBeneficiaire.Pre = "Largo";
            UnBeneficiaire.Nom = "Winch";
            UnBeneficiaire.Nai = DateTime.Today;
            UnBeneficiaire.Sexe = false; 
            BcpBeneficiaires = ChargerBeneficiaire(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
        }
        private ObservableCollection<C_T_Beneficiaire> ChargerBeneficiaire(string chConn)
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
                UnBeneficiaire.ID = new CoucheGestion.G_T_Beneficiaire(chConnexion).Ajouter(UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                BcpBeneficiaires.Add(new C_T_Beneficiaire(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe));
            }
            else
            {
                new CoucheGestion.G_T_Beneficiaire(chConnexion).Modifier(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                BcpBeneficiaires[nAjout] = new C_T_Beneficiaire(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnBeneficiaire = new VM_UnBeneficiaire();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (BeneficiaireSelectionnee != null)
            {
                C_T_Beneficiaire Tmp = new CoucheGestion.G_T_Beneficiaire(chConnexion).Lire_ID(BeneficiaireSelectionnee.ID_Beneficiaire);
                UnBeneficiaire = new VM_UnBeneficiaire();
                UnBeneficiaire.ID = Tmp.ID_Beneficiaire;
                UnBeneficiaire.Pre = Tmp.B_Prenom;
                UnBeneficiaire.Nom = Tmp.B_Nom;
                UnBeneficiaire.Nai = Tmp.B_Annif;
                nAjout = BcpBeneficiaires.IndexOf(BeneficiaireSelectionnee);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (BeneficiaireSelectionnee != null)
            {
                new CoucheGestion.G_T_Beneficiaire(chConnexion).Supprimer(BeneficiaireSelectionnee.ID_Beneficiaire);
                BcpBeneficiaires.Remove(BeneficiaireSelectionnee);
            }
        }
        public void PersonneSelectionnee2UnePersonne()
        {
            UnBeneficiaire.ID = BeneficiaireSelectionnee.ID_Beneficiaire;
            UnBeneficiaire.Nom = BeneficiaireSelectionnee.B_Nom;
            UnBeneficiaire.Pre = BeneficiaireSelectionnee.B_Prenom;
            UnBeneficiaire.Nai = BeneficiaireSelectionnee.B_Annif;
        }
    }
    public class VM_UnBeneficiaire : BasePropriete
    {
        private int _ID;
        private string _Nom, _Pre;
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
        public bool Sexe
        {
            get { return _Sexe; }
            set { AssignerChamp<bool>(ref _Sexe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

    }
}
