using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using System.Windows;
namespace Encodage_Fermette.ViewModel
{
    class VM_Menu : BasePropriete 
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
        private C_Vue_Menu _MenuSelectionne;
        public C_Vue_Menu MenuSelectionne
        {
            get { return _MenuSelectionne; }
            set { AssignerChamp<C_Vue_Menu>(ref _MenuSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _EntreeSelectionne;
        public C_Vue_ID_Descr EntreeSelectionne
        {
            get { return _EntreeSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _EntreeSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _PlatSelectionne;
        public C_Vue_ID_Descr PlatSelectionne
        {
            get { return _PlatSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _PlatSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _DessertSelectionne;
        public C_Vue_ID_Descr DessertSelectionne
        {
            get { return _DessertSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _DessertSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _CollationSelectionne;
        public C_Vue_ID_Descr CollationSelectionne
        {
            get { return _CollationSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _CollationSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string NouvelleEntree
        {

            set
            {
                if ( EntreeSelectionne != null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(value))
                {
                    // test avant d'entrer dans la base
                    C_Vue_ID_Descr tmpentree = new C_Vue_ID_Descr(0, value);
                    ListEntree.Add(tmpentree);
                    EntreeSelectionne = tmpentree;
                }
            }
        }
        public string NouveauPlat
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // test avant d'entrer dans la base
                    ListPlat.Add(new C_Vue_ID_Descr(0, value));
                }
            }
        }
        public string NouveauDessert
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // test avant d'entrer dans la base
                    ListDessert.Add(new C_Vue_ID_Descr(0, value));
                }
            }
        }
        public string NouvelleCollation
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // test avant d'entrer dans la base
                    ListCollation.Add(new C_Vue_ID_Descr(0, value));
                }
            }
        }

        #endregion
        #region Donnees Extérieurs
        private VM_Un_Menu _UnMenu;
        public VM_Un_Menu UnMenu
        {
            get { return _UnMenu; }
            set { AssignerChamp<VM_Un_Menu>(ref _UnMenu, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_Menu> _BcpMenu = new ObservableCollection<C_Vue_Menu>();
        public ObservableCollection<C_Vue_Menu> BcpMenu
        {
            get { return _BcpMenu; }
            set { _BcpMenu = value; }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListEntree;
        public ObservableCollection<C_Vue_ID_Descr> ListEntree
        {
            get { return _ListEntree; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListEntree, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListPlat;
        public ObservableCollection<C_Vue_ID_Descr> ListPlat
        {
            get { return _ListPlat; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListPlat, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListDessert;
        public ObservableCollection<C_Vue_ID_Descr> ListDessert
        {
            get { return _ListDessert; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListDessert, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListCollation ;
        public ObservableCollection<C_Vue_ID_Descr> ListCollation
        {
            get { return _ListCollation; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListCollation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Commandes 
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cSupprimerEntree { get; set; }
        public BaseCommande cSupprimerPlat { get; set; }
        public BaseCommande cSupprimerDessert { get; set; }
        public BaseCommande cSupprimerCollatione { get; set; }
        #endregion

        public VM_Menu()
        {
            UnMenu = new VM_Un_Menu();
            /*
            UnMenu.NomE = "Ecrire/choisir le nom de l'entrée";
            UnMenu.DescrE = "Ecrire le descriptif de l'entrée";
            UnMenu.NomP = "Ecrire/choisir le nom du plat";
            UnMenu.DescrP = "Ecrire le descriptif du plat";
            UnMenu.NomD = "Ecrire/choisir le nom du Dessert";
            UnMenu.DescrD = "Ecrire le descriptif du Dessert";
            UnMenu.NomC = "Ecrire/choisir le nom de la collation ";
            UnMenu.DescrC = "Ecrire le descriptif de la collation";
            */
            ActiverUneFiche = false;
            BcpMenu = ChargerMenu(chConnexion);
            ListEntree = ChargerEntree(chConnexion);
            ListPlat = ChargerPlat(chConnexion);
            ListDessert = ChargerDessert(chConnexion);
            ListCollation = ChargerCollation(chConnexion);

            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cSupprimerEntree = new BaseCommande(SupprimerEntree);
            cSupprimerPlat = new BaseCommande(Supprimer);
            cSupprimerDessert = new BaseCommande(Supprimer);
            cSupprimerCollatione = new BaseCommande(Supprimer);
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnMenu.ID = new G_T_Menu(chConnexion).Ajouter(UnMenu.IDE,UnMenu.IDP,UnMenu.IDD,UnMenu.IDC);
                // on ajout notre menu
                C_Vue_Menu tmpMenu = new C_Vue_Menu();
                tmpMenu.ID_Menu = UnMenu.IDE;
                tmpMenu.ID_Entree = UnMenu.IDE;
                tmpMenu.ID_Plat = UnMenu.IDP;
                tmpMenu.ID_Dessert = UnMenu.IDD;
                tmpMenu.ID_Collation = UnMenu.IDC;
                tmpMenu.E_Descr = UnMenu.DescrE;
                tmpMenu.P_Descr = UnMenu.DescrP;
                tmpMenu.D_Descr = UnMenu.DescrD;
                tmpMenu.C_Descr = UnMenu.DescrC;

                BcpMenu.Add(tmpMenu);
            }
            else
            {
                new CoucheGestion.G_T_Menu(chConnexion).Modifier(UnMenu.ID, UnMenu.IDE, UnMenu.IDP, UnMenu.IDD, UnMenu.IDC);
                C_Vue_Menu tmpMenu = new C_Vue_Menu();
                tmpMenu.ID_Menu = UnMenu.IDE;
                tmpMenu.ID_Entree = UnMenu.IDE;
                tmpMenu.ID_Plat = UnMenu.IDP;
                tmpMenu.ID_Dessert = UnMenu.IDD;
                tmpMenu.ID_Collation = UnMenu.IDC;
                tmpMenu.E_Descr = UnMenu.DescrE;
                tmpMenu.P_Descr = UnMenu.DescrP;
                tmpMenu.D_Descr = UnMenu.DescrD;
                tmpMenu.C_Descr = UnMenu.DescrC;

                BcpMenu[nAjout] = tmpMenu;
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnMenu = new VM_Un_Menu();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (MenuSelectionne != null)
            {
                // C_T_Staff Tmp = new CoucheGestion.G_T_Staff(chConnexion).Lire_ID(StaffSelectionne.ID_Staff);
                UnMenu = new VM_Un_Menu();
                UnMenu.ID = MenuSelectionne.ID_Menu;
                UnMenu.IDE = MenuSelectionne.ID_Entree;
                UnMenu.IDP = MenuSelectionne.ID_Plat;
                UnMenu.IDD = MenuSelectionne.ID_Dessert;
                UnMenu.IDC = MenuSelectionne.ID_Collation;
                UnMenu.NomE = MenuSelectionne.E_Descr;
                UnMenu.NomP = MenuSelectionne.P_Descr;
                UnMenu.NomD = MenuSelectionne.D_Descr;
                UnMenu.NomC = MenuSelectionne.C_Descr;

                nAjout = BcpMenu.IndexOf(MenuSelectionne);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (MenuSelectionne != null)
            {
                bool found = false;
                List<C_T_Date> ldatetmp = new CoucheGestion.G_T_Date(chConnexion).Lire("D_Jour");
                foreach(C_T_Date date in ldatetmp)
                {
                    if (date.ID_Menu == MenuSelectionne.ID_Menu)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre menu est utilisé pour une date");
                    }
                }

                if (!found)
                {
                    new CoucheGestion.G_T_Menu(chConnexion).Supprimer(MenuSelectionne.ID_Menu);
                    BcpMenu.Remove(MenuSelectionne);
                }
            }
        }
        public void SupprimerEntree()
        {
            if (EntreeSelectionne != null)
            {
                bool found = false;
                List<C_T_Menu> lmenutmp = new CoucheGestion.G_T_Menu(chConnexion).Lire("");
                foreach (C_T_Menu menu in lmenutmp)
                {
                    if (menu.ID_Entree == EntreeSelectionne.ID)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre entrée est utilisée dans un plat");
                    }
                }

                if (!found)
                {
                    new CoucheGestion.G_T_Menu(chConnexion).Supprimer(MenuSelectionne.ID_Menu);
                    BcpMenu.Remove(MenuSelectionne);
                }
            }

        }
        public void SupprimerPlat()
        {
        }
        public void SupprimerDessert()
        {
        }
        public void SupprimerCollation()
        {
        }
        public void MenuSelectionne2UnMenu()
        {
            EntreeSelectionne = new C_Vue_ID_Descr(MenuSelectionne.ID_Entree, MenuSelectionne.E_Descr);
            NouvelleEntree = MenuSelectionne.E_Descr;
            UnMenu.IDP = MenuSelectionne.ID_Plat;
            UnMenu.IDD = MenuSelectionne.ID_Dessert;
            UnMenu.IDC = MenuSelectionne.ID_Collation;
            UnMenu.NomE = MenuSelectionne.E_Descr;
            UnMenu.NomP = MenuSelectionne.P_Descr;
            UnMenu.NomD = MenuSelectionne.D_Descr;
            UnMenu.NomC = MenuSelectionne.C_Descr;
        }
        #region chargement data 
        private ObservableCollection<C_Vue_Menu> ChargerMenu(string chConn)
        {
            ObservableCollection<C_Vue_Menu> rep = new ObservableCollection<C_Vue_Menu>();
            List<C_Vue_Menu> lTmp = new CoucheGestion.G_Vue_Menu(chConn).Lire_All_Menu();
            foreach (C_Vue_Menu Tmp in lTmp)
            {
                C_Vue_Menu menutmp = new C_Vue_Menu(Tmp.ID_Menu, Tmp.E_Descr, Tmp.P_Descr, Tmp.D_Descr, Tmp.C_Descr);
                rep.Add(menutmp);
            }
            return rep;
        }
        private ObservableCollection<C_Vue_ID_Descr> ChargerEntree(string chConn)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConn).Lire_All_Entree();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
            {
                C_Vue_ID_Descr entreetmp = new C_Vue_ID_Descr(Tmp.ID,Tmp.Descr);
                rep.Add(entreetmp);
            }
            return rep;
        }
        private ObservableCollection<C_Vue_ID_Descr> ChargerPlat(string chConn)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConn).Lire_All_Plat();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
            {
                C_Vue_ID_Descr entreetmp = new C_Vue_ID_Descr(Tmp.ID, Tmp.Descr);
                rep.Add(entreetmp);
            }
            return rep;
        }
        private ObservableCollection<C_Vue_ID_Descr> ChargerDessert(string chConn)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConn).Lire_All_Dessert();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
            {
                C_Vue_ID_Descr entreetmp = new C_Vue_ID_Descr(Tmp.ID, Tmp.Descr);
                rep.Add(entreetmp);
            }
            return rep;
        }
        private ObservableCollection<C_Vue_ID_Descr> ChargerCollation(string chConn)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConn).Lire_All_Collation();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
            {
                C_Vue_ID_Descr entreetmp = new C_Vue_ID_Descr(Tmp.ID, Tmp.Descr);
                rep.Add(entreetmp);
            }
            return rep;
        }

        #endregion

        #region Modif Data 

        #endregion
        public class VM_Un_Menu : BasePropriete
        {
            private int _ID, _IDE, _IDP, _IDD, _IDC;
            private string _NomE, _DescrE, _NomP, _DescrP, _NomD, _DescrD, _NomC, _DescrC;

            public int ID
            {
                get { return _ID; }
                set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int IDE
            {
                get { return _IDE; }
                set { AssignerChamp<int>(ref _IDE, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int IDP
            {
                get { return _IDP; }
                set { AssignerChamp<int>(ref _IDP, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int IDD
            {
                get { return _IDD; }
                set { AssignerChamp<int>(ref _IDD, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int IDC
            {
                get { return _IDC; }
                set { AssignerChamp<int>(ref _IDC, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string NomE
            {
                get { return _NomE; }
                set { AssignerChamp<string>(ref _NomE, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string DescrE
            {
                get { return _DescrE; }
                set { AssignerChamp<string>(ref _DescrE, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string NomP
            {
                get { return _NomP; }
                set { AssignerChamp<string>(ref _NomP, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string DescrP
            {
                get { return _DescrP; }
                set { AssignerChamp<string>(ref _DescrP, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string NomD
            {
                get { return _NomD; }
                set { AssignerChamp<string>(ref _NomD, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string DescrD
            {
                get { return _DescrD; }
                set { AssignerChamp<string>(ref _DescrD, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string NomC
            {
                get { return _NomC; }
                set { AssignerChamp<string>(ref _NomC, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string DescrC
            {
                get { return _DescrC; }
                set { AssignerChamp<string>(ref _DescrC, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}

