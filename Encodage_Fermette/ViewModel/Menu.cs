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
        private int nNourriteAjout;
        private bool _ActiverUneFiche;
        public bool ActiverUneFiche
        {
            get { return _ActiverUneFiche; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if ( !ActiverFicheNourriture)
                ActiverBcpFiche = !ActiverUneFiche;
            }
        }
        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private bool _ActiverFicheNourriture;
        public bool ActiverFicheNourriture
        {
            get { return _ActiverFicheNourriture; }
            set { AssignerChamp<bool>(ref _ActiverFicheNourriture, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
        private C_T_Nourriture _NouveauNourriture;
        public C_T_Nourriture NouveauNourriture
        {
            get { return _NouveauNourriture; }
            set { AssignerChamp<C_T_Nourriture>(ref _NouveauNourriture, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _NouvelleEntree;
        public C_Vue_ID_Descr NouvelleEntree
        {
            get { return _NouvelleEntree; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _NouvelleEntree, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _NouveauPlat;
        public C_Vue_ID_Descr NouveauPlat
        {
            get { return _NouveauPlat; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _NouveauPlat, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _NouveauDessert;
        public C_Vue_ID_Descr NouveauDessert
        {
            get { return _NouveauDessert; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _NouveauDessert, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _NouvelleCollation;
        public C_Vue_ID_Descr NouvelleCollation
        {
            get { return _NouvelleCollation; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _NouvelleCollation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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

        public BaseCommande cConfirmerNourriture { get; set; }
        public BaseCommande cAnnulerNourriture { get; set; }

        public BaseCommande cAjouterEntree { get; set; }
        public BaseCommande cAjouterPlat { get; set; }
        public BaseCommande cAjouterDessert { get; set; }
        public BaseCommande cAjouterCollation { get; set; }

        public BaseCommande cSupprimerEntree { get; set; }
        public BaseCommande cSupprimerPlat { get; set; }
        public BaseCommande cSupprimerDessert { get; set; }
        public BaseCommande cSupprimerCollation { get; set; }

        public BaseCommande cModifierEntree { get; set; }
        public BaseCommande cModifierPlat { get; set; }
        public BaseCommande cModifierDessert { get; set; }
        public BaseCommande cModifierCollation { get; set; }

        public BaseCommande CAjouterPhotoEntree { get; set; }
        public BaseCommande CAjouterPhotoPlat { get; set; }
        public BaseCommande CAjouterPhotoDessert { get; set; }
        public BaseCommande CAjouterPhotoCollation { get; set; }

        #endregion

        public void AjouterPhotoEntree()
        {
            if (EntreeSelectionne != null)
            {
                Picture p = new Picture();
                p.AjouterPhoto("Entrees", EntreeSelectionne.ID.ToString());
            }
            else
                System.Windows.MessageBox.Show("Veuillez Selectionner une Entree");
        }
        public void AjouterPhotoPlat()
        {
            if (PlatSelectionne != null)
            {
                Picture p = new Picture();
                p.AjouterPhoto("Plats", PlatSelectionne.ID.ToString());
            }
            else
                System.Windows.MessageBox.Show("Veuillez Selectionner un Plat");
        }
        public void AjouterPhotoDessert()
        {
            if (DessertSelectionne != null)
            {
                Picture p = new Picture();
                p.AjouterPhoto("Desserts", DessertSelectionne.ID.ToString());
            }
            else
                System.Windows.MessageBox.Show("Veuillez Selectionner un Dessert");
        }
        public void AjouterPhotoCollation()
        {
            if (CollationSelectionne != null)
            {
                Picture p = new Picture();
                p.AjouterPhoto("Collations", CollationSelectionne.ID.ToString());
            }
            else
                System.Windows.MessageBox.Show("Veuillez Selectionner un Collations");

        }
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

            ActiverUneFiche = ActiverFicheNourriture = false;
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

            CAjouterPhotoEntree = new BaseCommande(AjouterPhotoEntree);
            CAjouterPhotoPlat = new BaseCommande(AjouterPhotoPlat);
            CAjouterPhotoDessert = new BaseCommande(AjouterPhotoDessert);
            CAjouterPhotoCollation = new BaseCommande(AjouterPhotoCollation);

            cAjouterEntree = new BaseCommande(AjouteurEntree);
            cSupprimerEntree = new BaseCommande(SupprimerEntree);
            cModifierEntree = new BaseCommande(ModifierEntree);

            cAjouterPlat = new BaseCommande(AjouterPlat);
            cSupprimerPlat = new BaseCommande(SupprimerPlat);
            cModifierPlat = new BaseCommande(ModifierPlat);

            cAjouterDessert = new BaseCommande(AjouteDessert);
            cSupprimerDessert = new BaseCommande(SupprimerDessert);
            cModifierDessert = new BaseCommande(ModifierDessert);

            cAjouterCollation = new BaseCommande(AjouteCollation);
            cSupprimerCollation = new BaseCommande(SupprimerCollation);
            cModifierCollation = new BaseCommande(ModifierCollation);

            cConfirmerNourriture = new BaseCommande(ConfirmerNourriture);
            cAnnulerNourriture = new BaseCommande(AnnulerNourriture);
        }
        public void Confirmer()
        {
            if (EntreeSelectionne != null && PlatSelectionne != null && DessertSelectionne != null && CollationSelectionne != null)
            {
                if (nAjout == -1)
                {
                    // ajout
                    //System.Windows.Forms.MessageBox.Show(EntreeSelectionne.ID.ToString() + PlatSelectionne.ID.ToString() + DessertSelectionne.ID.ToString() + CollationSelectionne.ID.ToString());
                    UnMenu.ID = new CoucheGestion.G_T_Menu(chConnexion).Ajouter((int)EntreeSelectionne.ID, (int)PlatSelectionne.ID, (int)DessertSelectionne.ID, (int)CollationSelectionne.ID);
                    // on ajout notre menu
                    C_Vue_Menu tmpMenu = new C_Vue_Menu();
                    tmpMenu.ID_Menu = UnMenu.ID;
                    tmpMenu.ID_Entree = EntreeSelectionne.ID;
                    tmpMenu.ID_Plat = PlatSelectionne.ID;
                    tmpMenu.ID_Dessert = DessertSelectionne.ID;
                    tmpMenu.ID_Collation = CollationSelectionne.ID;
                    tmpMenu.E_Descr = EntreeSelectionne.Descr;
                    tmpMenu.P_Descr = PlatSelectionne.Descr;
                    tmpMenu.D_Descr = DessertSelectionne.Descr;
                    tmpMenu.C_Descr = CollationSelectionne.Descr;

                    BcpMenu.Add(tmpMenu);
                }
                else
                {
                    // modification
                    new CoucheGestion.G_T_Menu(chConnexion).Modifier(MenuSelectionne.ID_Menu, EntreeSelectionne.ID, PlatSelectionne.ID, DessertSelectionne.ID, CollationSelectionne.ID);
                    C_Vue_Menu tmpMenu = new C_Vue_Menu();
                    tmpMenu.ID_Menu = MenuSelectionne.ID_Menu;
                    tmpMenu.ID_Entree = EntreeSelectionne.ID;
                    tmpMenu.ID_Plat = PlatSelectionne.ID;
                    tmpMenu.ID_Dessert = DessertSelectionne.ID;
                    tmpMenu.ID_Collation = CollationSelectionne.ID;
                    tmpMenu.E_Descr = EntreeSelectionne.Descr;
                    tmpMenu.P_Descr = PlatSelectionne.Descr;
                    tmpMenu.D_Descr = DessertSelectionne.Descr;
                    tmpMenu.C_Descr = CollationSelectionne.Descr;
                    BcpMenu.Clear();
                    ChargerMenu(chConnexion);
                }
                ActiverUneFiche = false;
            }
            else
                System.Windows.MessageBox.Show("Il faut que le menu soit complet !");
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
                if (MenuSelectionne != null)
                {
                    List<DateTime> LD = new CoucheGestion.G_Verification(chConnexion).Verification_Menu_Date(MenuSelectionne.ID_Menu);
                    if (LD.Count == 0)
                    {
                        new CoucheGestion.G_T_Menu(chConnexion).Supprimer(MenuSelectionne.ID_Menu);
                        BcpMenu.Remove(MenuSelectionne);
                    }
                    else
                        System.Windows.MessageBox.Show("Menu non supprimable car utilisé pour une journée ( ex :" + LD[0].ToShortDateString() + " )");
                }

            }
        }
        public void ConfirmerNourriture()
        {
            if (NouveauNourriture.No_Descriptif != null)
            {
                if (nNourriteAjout == -1) // ajout
                {
                    NouveauNourriture.ID_Nourriture = new CoucheGestion.G_T_Nourriture(chConnexion).Ajouter(NouveauNourriture.No_Descriptif, NouveauNourriture.No_Type);
                    C_Vue_ID_Descr tmp = new C_Vue_ID_Descr(NouveauNourriture.ID_Nourriture, NouveauNourriture.No_Descriptif);
                    if (NouveauNourriture.No_Type == 0)
                        ListEntree.Add(tmp);
                    else if (NouveauNourriture.No_Type == 1)
                        ListPlat.Add(tmp);
                    else if (NouveauNourriture.No_Type == 2)
                        ListDessert.Add(tmp);
                    else if (NouveauNourriture.No_Type == 3)
                        ListCollation.Add(tmp);
                    System.Windows.MessageBox.Show("Votre Nourriture a été ajoutée");

                }
                else // modification 
                {
                    new CoucheGestion.G_T_Nourriture(chConnexion).Modifier(NouveauNourriture.ID_Nourriture, NouveauNourriture.No_Descriptif, NouveauNourriture.No_Type);
                    EntreeSelectionne = ListEntree[nAjout] = new C_Vue_ID_Descr(NouveauNourriture.ID_Nourriture, NouveauNourriture.No_Descriptif);
                    BcpMenu.Clear();
                    BcpMenu = ChargerMenu(chConnexion);
                }
                ActiverFicheNourriture = false;
                ActiverUneFiche = true;
            }
            else
                System.Windows.MessageBox.Show("Il faut un nom pour votre nouveaux plat");


        }
        public void AnnulerNourriture()
        {
            ActiverFicheNourriture = false;
            ActiverUneFiche = true;
            NouveauNourriture = new C_T_Nourriture();
        }
        public void AjouteurEntree()
        {
            NouveauNourriture = new C_T_Nourriture();
            NouveauNourriture.No_Type = 0;
            ActiverFicheNourriture = true;
            ActiverUneFiche = false;
                nNourriteAjout = -1;
        }
        public void ModifierEntree()
        {
           if (EntreeSelectionne != null)
            {
                NouveauNourriture = new C_T_Nourriture( EntreeSelectionne.ID ,EntreeSelectionne.Descr,0);
                nAjout = ListEntree.IndexOf(EntreeSelectionne);
                ActiverFicheNourriture = true;
                ActiverUneFiche = false;
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
                    new CoucheGestion.G_T_Nourriture(chConnexion).Supprimer(EntreeSelectionne.ID);
                    ListEntree.Remove(EntreeSelectionne);
                }
            }
        }

        public void AjouterPlat()
        {
            NouveauNourriture = new C_T_Nourriture();
            NouveauNourriture.No_Type = 1;
            ActiverFicheNourriture = true;
            ActiverUneFiche = false;
            nNourriteAjout = -1;
        }
        public void ModifierPlat()
        {
            if (PlatSelectionne != null)
            {
                NouveauNourriture = new C_T_Nourriture(PlatSelectionne.ID, PlatSelectionne.Descr, 1);
                nAjout = ListPlat.IndexOf(PlatSelectionne);
                ActiverFicheNourriture = true;
                ActiverUneFiche = false;
            }
        }
        public void SupprimerPlat()
        {
            if (PlatSelectionne != null)
            {
                bool found = false;
                List<C_T_Menu> lmenutmp = new CoucheGestion.G_T_Menu(chConnexion).Lire("");
                foreach (C_T_Menu menu in lmenutmp)
                {
                    if (menu.ID_Plat == PlatSelectionne.ID)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre plat est utilisée dans un menu");
                    }
                }
                if (!found)
                {
                    new CoucheGestion.G_T_Nourriture(chConnexion).Supprimer(PlatSelectionne.ID);
                    ListPlat.Remove(PlatSelectionne);
                }
            }
        }

        public void AjouteDessert()
        {
            NouveauNourriture = new C_T_Nourriture();
            ActiverFicheNourriture = true;
            NouveauNourriture.No_Type = 2;

            ActiverUneFiche = false;
            nNourriteAjout = -1;
        }
        public void ModifierDessert()
        {
            if (DessertSelectionne != null)
            {
                NouveauNourriture = new C_T_Nourriture(DessertSelectionne.ID, DessertSelectionne.Descr, 2);
                nAjout = ListDessert.IndexOf(DessertSelectionne);
                ActiverFicheNourriture = true;
                ActiverUneFiche = false;
            }
        }
        public void SupprimerDessert()
        {
            if (DessertSelectionne != null)
            {
                bool found = false;
                List<C_T_Menu> lmenutmp = new CoucheGestion.G_T_Menu(chConnexion).Lire("");
                foreach (C_T_Menu menu in lmenutmp)
                {
                    if (menu.ID_Dessert == DessertSelectionne.ID)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre Dessert est utilisée dans un plat");
                    }
                }
                if (!found)
                {
                    new CoucheGestion.G_T_Nourriture(chConnexion).Supprimer(DessertSelectionne.ID);
                    ListDessert.Remove(DessertSelectionne);
                }
            }
        }

        public void AjouteCollation()
        {
            NouveauNourriture = new C_T_Nourriture();
            ActiverFicheNourriture = true;
            ActiverUneFiche = false;
            NouveauNourriture.No_Type = 3;

            nNourriteAjout = -1;
        }

        public void ModifierCollation()
        {
            if (CollationSelectionne != null)
            {
                NouveauNourriture = new C_T_Nourriture(CollationSelectionne.ID, CollationSelectionne.Descr, 3);
                nAjout = ListCollation.IndexOf(CollationSelectionne);
                ActiverFicheNourriture = true;
                ActiverUneFiche = false;
            }
        }
        public void SupprimerCollation()
        {
            if (CollationSelectionne != null)
            {
                bool found = false;
                List<C_T_Menu> lmenutmp = new CoucheGestion.G_T_Menu(chConnexion).Lire("");
                foreach (C_T_Menu menu in lmenutmp)
                {
                    if (menu.ID_Collation == CollationSelectionne.ID)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre Collation est utilisée dans un plat");
                    }
                }
                if (!found)
                {
                    new CoucheGestion.G_T_Nourriture(chConnexion).Supprimer(CollationSelectionne.ID);
                    ListCollation.Remove(CollationSelectionne);
                }
            }
        }

        public void MenuSelectionne2UnMenu()
        {
            UnMenu.ID = MenuSelectionne.ID_Menu;
            UnMenu.IDE = MenuSelectionne.ID_Entree;
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
            private string _NomE,_NomP, _NomD, _NomC;

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
            public string NomP
            {
                get { return _NomP; }
                set { AssignerChamp<string>(ref _NomP, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string NomD
            {
                get { return _NomD; }
                set { AssignerChamp<string>(ref _NomD, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string NomC
            {
                get { return _NomC; }
                set { AssignerChamp<string>(ref _NomC, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
    }
}

