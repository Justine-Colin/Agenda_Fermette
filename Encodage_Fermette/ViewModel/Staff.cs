using System;
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
    public class VM_Staff : BasePropriete
    {
        #region Données Ecran 
        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" +  System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
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
        private C_T_Staff _StaffSelectionne;
        public C_T_Staff StaffSelectionne
        {
            get { return _StaffSelectionne; }
            set { AssignerChamp<C_T_Staff>(ref _StaffSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Donnéees extérieur
        private VM_Un_Staff _UnStaff;
        public VM_Un_Staff UnStaff
        {
            get { return _UnStaff; }
            set { AssignerChamp<VM_Un_Staff>(ref _UnStaff, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Staff> _BcpStaff = new ObservableCollection<C_T_Staff>();
        public ObservableCollection<C_T_Staff> BcpStaff
        {
            get { return _BcpStaff; }
            set { _BcpStaff = value; }
        }
        #endregion

        #region Commandes 
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        #endregion

        public VM_Staff()
        {
            UnStaff = new VM_Un_Staff();
            UnStaff.ID = 24;
            UnStaff.Pre = "Prenom";
            UnStaff.Nom = "Nom";
            UnStaff.Sexe = false;
            UnStaff.Nai = DateTime.Today;
            BcpStaff = ChargerStaff(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
        }
        private ObservableCollection<C_T_Staff> ChargerStaff(string chConn)
        {
            ObservableCollection<C_T_Staff> rep = new ObservableCollection<C_T_Staff>();
            List<C_T_Staff> lTmp = new CoucheGestion.G_T_Staff(chConn).Lire("ID");
            foreach (C_T_Staff Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnStaff.ID = new CoucheGestion.G_T_Staff(chConnexion).Ajouter(UnStaff.Nom,UnStaff.Pre,UnStaff.Nai,UnStaff.Sexe,UnStaff.Poste);
                BcpStaff.Add(new C_T_Staff(UnStaff.ID, UnStaff.Nom, UnStaff.Pre, UnStaff.Nai, UnStaff.Sexe, UnStaff.Poste));
            }
            else
            {
                new CoucheGestion.G_T_Staff(chConnexion).Modifier(UnStaff.ID, UnStaff.Nom, UnStaff.Pre, UnStaff.Nai, UnStaff.Sexe, UnStaff.Poste);
                BcpStaff[nAjout] = new C_T_Staff(UnStaff.ID, UnStaff.Nom, UnStaff.Pre, UnStaff.Nai, UnStaff.Sexe, UnStaff.Poste);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnStaff = new VM_Un_Staff();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (StaffSelectionne != null)
            {
                C_T_Staff Tmp = new CoucheGestion.G_T_Staff(chConnexion).Lire_ID(StaffSelectionne.ID_Staff);
                UnStaff = new VM_Un_Staff();
                UnStaff.ID = Tmp.ID_Staff;
                UnStaff.Pre = Tmp.S_Prenom;
                UnStaff.Nom = Tmp.S_Nom;
                UnStaff.Nai = Tmp.S_Annif;
                UnStaff.Poste = Tmp.S_Poste;
                nAjout = BcpStaff.IndexOf(StaffSelectionne);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (StaffSelectionne != null)
            {
                if (new CoucheGestion.G_Verification(chConnexion).Verification_Staff_Event(StaffSelectionne.ID_Staff).Count == 0)
                {
                    new CoucheGestion.G_T_Staff(chConnexion).Supprimer(StaffSelectionne.ID_Staff);
                    BcpStaff.Remove(StaffSelectionne);
                }
                else
                    System.Windows.MessageBox.Show("Staff non supprimable car utilisé dans Event");
            }
        }

        public void PersonneSelectionnee2UnePersonne()
        {
            UnStaff.Nom = StaffSelectionne.S_Nom;
            UnStaff.Pre = StaffSelectionne.S_Prenom;
            UnStaff.Nai = StaffSelectionne.S_Annif;
            UnStaff.Sexe = StaffSelectionne.S_Sexe;
            UnStaff.Poste = StaffSelectionne.S_Poste;
        }
    }
    public class VM_Un_Staff : BasePropriete
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
                set { AssignerChamp<bool>(ref _Sexe, value  , System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
           
    }
}
