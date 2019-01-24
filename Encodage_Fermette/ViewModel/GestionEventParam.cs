using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using System.Collections.ObjectModel;
using System.Windows;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;


namespace Encodage_Fermette.ViewModel
{
    class VM_GestionEventParam :BasePropriete
    {
        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        private int nAjoutDonne;
        private int typedonnes;
        #region Gestion Fiches
        private bool _ActiverChampsModif;
        public bool ActiverChampsModif
        {
            get { return _ActiverChampsModif; }
            set { AssignerChamp<bool>(ref _ActiverChampsModif, value, System.Reflection.MethodBase.GetCurrentMethod().Name);}
            
        }
        private bool _ActiverNouvelleDonnées;
        public bool ActiverNouvelleDonnées
        {
            get { return _ActiverNouvelleDonnées; }
            set { AssignerChamp<bool>(ref _ActiverNouvelleDonnées, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverChampsModif = !ActiverNouvelleDonnées;
            }
        }
        private bool _ActiverGestionEquipe;
        public bool ActiverGestionEquipe
        {
            get { return _ActiverGestionEquipe; }
            set
            {
                AssignerChamp<bool>(ref _ActiverGestionEquipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverChampsModif = !ActiverGestionEquipe;
            }
        }
        #endregion

        // Va nous permettre d'encoder de nouvelle données 
        private VM_ID_Descr _NouvelleInfo;
        public VM_ID_Descr NouvelleInfo
        {
            get { return _NouvelleInfo; }
            set { AssignerChamp<VM_ID_Descr>(ref _NouvelleInfo, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        //#################################################

        #region Gestion Titre
        private C_Vue_ID_Descr _TitreSelectionne;
        public C_Vue_ID_Descr TitreSelectionne
        {
            get { return _TitreSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _TitreSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListTitre;
        public ObservableCollection<C_Vue_ID_Descr> ListTitre
        {
            get { return _ListTitre; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListTitre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Gestion Lieux
        private C_Vue_ID_Descr _LieuxSelectionne;
        public C_Vue_ID_Descr LieuxSelectionne
        {
            get { return _LieuxSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _LieuxSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListLieux;
        public ObservableCollection<C_Vue_ID_Descr> ListLieux
        {
            get { return _ListLieux; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListLieux, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Gestion Equipe
        private C_T_Equipe _EquipeSelectionne;
        public C_T_Equipe EquipeSelectionne
        {
            get { return _EquipeSelectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _EquipeSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        /* private C_Vue_ID_Descr _NouvelleInfo;
         public C_Vue_ID_Descr NouvelleInfo
         {
             get { return _NouvelleInfo; }
             set { AssignerChamp<C_Vue_ID_Descr>(ref _NouvelleInfo, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
         }
         */
        private ObservableCollection<C_T_Equipe> _ListEquipe;
        public ObservableCollection<C_T_Equipe> ListEquipe
        {
            get { return _ListEquipe; }
            set { AssignerChamp<ObservableCollection<C_T_Equipe>>(ref _ListEquipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion


        private ObservableCollection<C_Personne> _ListBeneficiaire;
        public ObservableCollection<C_Personne> ListBeneficiaire
        {
            get { return _ListBeneficiaire; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListBeneficiaire, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        // list de beneficiaire dans une équipe
        private ObservableCollection<C_Personne> _ListBeneficiaireEq;
        public ObservableCollection<C_Personne> ListBenefiaireEq
        {
            get { return _ListBeneficiaireEq; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListBeneficiaireEq, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Personne> ListBeneficiaireEqSave;

        // beneficiaire selectionné dans la liste de ceux disponibles
        private C_Personne _BeneficiaireSelectionneList;
        public C_Personne BeneficiaireSelectionneList
        {
            get { return _BeneficiaireSelectionneList; }
            set { AssignerChamp<C_Personne>(ref _BeneficiaireSelectionneList, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        // beneficiaire selectionne dans la list id'equipe
        private C_Personne _BeneficiaireSelectionneEq;
        public C_Personne BeneficiaireSelectionneEq
        {
            get { return _BeneficiaireSelectionneEq; }
            set { AssignerChamp<C_Personne>(ref _BeneficiaireSelectionneEq, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #region Commandes 
        public BaseCommande cConfirmerInfo { get; set; }
        public BaseCommande cAnnulerInfo { get; set; }
        public BaseCommande cConfirmerEquipeMembres { get; set; }
        public BaseCommande cAjouterMembreEquipe { get; set; }
        public BaseCommande cSupprimerMembreEquipe { get; set; }


        public BaseCommande cAjouterTitre { get; set; }
        public BaseCommande cAjouterLieux { get; set; }
        public BaseCommande cAjouterEquipe { get; set; }

        public BaseCommande cModifierTitre { get; set; }
        public BaseCommande cModifierLieux { get; set; }
        public BaseCommande cModifierEquipe { get; set; }
        public BaseCommande cModifierEquipeMembres { get; set; }

        public BaseCommande cSupprimerTitre { get; set; }
        public BaseCommande cSupprimerLieux { get; set; }
        public BaseCommande cSupprimerEquipe { get; set; }
        #endregion
        #region Chargement de données
        private ObservableCollection<C_Vue_ID_Descr> ChargerTItre(string chConn)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConn).Lire_All_Titre();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        private ObservableCollection<C_Vue_ID_Descr> ChargerLieux(string chConn)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConn).Lire_All_Lieux();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        private ObservableCollection<C_T_Equipe> ChargerEquipe(string chConn)
        {
            ObservableCollection<C_T_Equipe> rep = new ObservableCollection<C_T_Equipe>();
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConn).Lire("");
            foreach (C_T_Equipe Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        /*
        private ObservableCollection<C_T_Staff> ChargerBeneficiaire(string chConn)
        {
            ObservableCollection<C_T_Staff> rep = new ObservableCollection<C_T_Staff>();
            List<C_T_Staff> lTmp = new CoucheGestion.G_T_Staff(chConn).Lire("ID");
            foreach (C_T_Staff Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        */
        private ObservableCollection<C_Personne> ChargerBeneficiaireEquipe(int id_Eq)
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            List<C_Personne> lTmp = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Classement_Membre_Equipe(id_Eq);
            foreach (C_Personne Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        private ObservableCollection<C_Personne> ChargerBenefiaires(string chConn)
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            List<C_Personne> lTmp = new CoucheGestion.G_Vue_Personne(chConn).Lire_All_Ben();
            foreach (C_Personne Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void RemplirdgmembreEquipe()
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            if (EquipeSelectionne.ID_Equipe != 0 || EquipeSelectionne != null)
            {
                List<C_Personne> lTmp = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Classement_Membre_Equipe(EquipeSelectionne.ID_Equipe);
                foreach (C_Personne Tmp in lTmp)
                    rep.Add(Tmp);
                ListBenefiaireEq = rep;
            }
        }

        #endregion

        #region Methode Bouton

        #region etage supérieur
        public void ConfirmerInfo()
        {
            if (nAjoutDonne == -1) // ajout
            {
                if (typedonnes == 0) // ajout titre
                {
                     C_T_Titre titre = new C_T_Titre();
                    titre.ID_Titre = new CoucheGestion.G_T_Titre(chConnexion).Ajouter(NouvelleInfo.Descr);
                    C_Vue_ID_Descr tmp = new C_Vue_ID_Descr(titre.ID_Titre, NouvelleInfo.Descr);
                    ListTitre.Add(tmp);
                }
                else if (typedonnes == 1) // ajout lieux
                {
                    C_T_Lieu lieux = new C_T_Lieu();
                    lieux.ID_Lieu = new CoucheGestion.G_T_Lieu(chConnexion).Ajouter(NouvelleInfo.Descr);
                    C_Vue_ID_Descr tmp = new C_Vue_ID_Descr(lieux.ID_Lieu, NouvelleInfo.Descr);
                    ListLieux.Add(tmp);
                }
                else if (typedonnes == 2) // ajout equipe
                {
                    C_T_Equipe equipe = new C_T_Equipe();
                    equipe.ID_Equipe = new CoucheGestion.G_T_Equipe(chConnexion).Ajouter(NouvelleInfo.Descr);
                    C_T_Equipe tmp = new C_T_Equipe(equipe.ID_Equipe, NouvelleInfo.Descr);
                    ListEquipe.Add(tmp);
                }
            }
            else // modification 
            {
                if (typedonnes == 0) // modif titre
                {
                    new CoucheGestion.G_T_Titre(chConnexion).Modifier(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListTitre[nAjoutDonne] = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                }
                else if (typedonnes == 1) // modif lieux
                {
                    new CoucheGestion.G_T_Lieu(chConnexion).Modifier(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListLieux[nAjoutDonne] = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                }
                else if (typedonnes == 2) // modif equipe
                {
                    new CoucheGestion.G_T_Equipe(chConnexion).Modifier(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListEquipe[nAjoutDonne] = new C_T_Equipe(NouvelleInfo.ID, NouvelleInfo.Descr);
                }
            }
            ActiverNouvelleDonnées = false;
        }
        public void AnnulerInfo()
        {
            ActiverNouvelleDonnées = false;
        }
        public void AjouterTitre()
        {
            NouvelleInfo.Descr = "Ajouter Equipe";
            typedonnes = 0;
            ActiverNouvelleDonnées = true;
            nAjoutDonne = -1;
        }
        public void AjouteurLieux()
        {
            NouvelleInfo.Descr = "Ajouter Lieux";
            typedonnes = 1;
            ActiverNouvelleDonnées = true;
            nAjoutDonne = -1;
        }
        public void AjouterEquipe()
        {
            NouvelleInfo.Descr = "Ajouter Equipe";

            typedonnes = 2;
            ActiverNouvelleDonnées = true;
            nAjoutDonne = -1;
        }
        public void ModifierTitre()
        {
            if (TitreSelectionne != null )
            {
                NouvelleInfo.ID = TitreSelectionne.ID;
                NouvelleInfo.Descr = TitreSelectionne.Descr;

                nAjoutDonne = ListTitre.IndexOf(TitreSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 0;
            }
            else
            {
                System.Windows.MessageBox.Show("Il n'y a pas de titre ");
            }

        }
        public void ModifierLieux()
        {
            if (LieuxSelectionne != null)
            {
                NouvelleInfo.ID = LieuxSelectionne.ID;
                NouvelleInfo.Descr = LieuxSelectionne.Descr;
                nAjoutDonne = ListLieux.IndexOf(LieuxSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 1;
            }
            else
            {
                System.Windows.MessageBox.Show("Il n'y a pas de lieux");
            }
        }
        public void ModifierEquipe()
        {
            if (EquipeSelectionne != null)
            {
                NouvelleInfo.ID = EquipeSelectionne.ID_Equipe;
                NouvelleInfo.Descr = EquipeSelectionne.Eq_Nom;

                nAjoutDonne = ListEquipe.IndexOf(EquipeSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 2;
            }
            else
            {
                System.Windows.MessageBox.Show("Pas d'équipe selectionnée ");
            }

        }
        public void SupprimerTitre()
        {
            if (TitreSelectionne != null)
            {
                List<int> tmp = new CoucheGestion.G_Verification(chConnexion).Verification_Titre_Event(TitreSelectionne.ID);
                    if (tmp.Count == 0)
                    {
                        new CoucheGestion.G_T_Titre(chConnexion).Supprimer(TitreSelectionne.ID);
                        ListTitre.Remove(TitreSelectionne);
                    }
                    else
                        System.Windows.MessageBox.Show("Votre titre est utilisée dans un event");

            }
            else
                System.Windows.MessageBox.Show("pas de titres a supprimer");
        }
        public void SupprimerLieux()
        {
            if (LieuxSelectionne != null)
            {
                List<int> tmp = new CoucheGestion.G_Verification(chConnexion).Verification_Lieux_Event(LieuxSelectionne.ID);
                if (tmp.Count == 0)
                {
                    new CoucheGestion.G_T_Lieu(chConnexion).Supprimer(LieuxSelectionne.ID);
                    ListLieux.Remove(LieuxSelectionne);
                }
                else
                    System.Windows.MessageBox.Show("Votre Lieux est utilisée dans un event");
            }
            else
                System.Windows.MessageBox.Show("pas de lieux a supprimer");

        }
        public void SupprimerEquipe()
        {
            if (EquipeSelectionne != null)
            {
                List<int> tmp = new CoucheGestion.G_Verification(chConnexion).Verification_Equipe_Classement(EquipeSelectionne.ID_Equipe);
                if (tmp.Count == 0)
                {
                    new CoucheGestion.G_T_Equipe(chConnexion).Supprimer(EquipeSelectionne.ID_Equipe);
                    ListEquipe.Remove(EquipeSelectionne);
                }
                else
                    System.Windows.MessageBox.Show("Votre équipe est utilisée dans un classement");
            }
            else
                System.Windows.MessageBox.Show("pas d'équipe a supprimer");
        }
        #endregion

        #region etage inférieur
        public void ModifierEquipeMembres()
        {
            if (EquipeSelectionne != null && EquipeSelectionne.ID_Equipe != 0)
            {
                ActiverGestionEquipe = true;
            }
            else
                System.Windows.MessageBox.Show("Pas d'équipe");
        }
        public void ConfirmerInfoEquipe()
        {
            ActiverGestionEquipe = false;
            EquipeSelectionne = new C_T_Equipe(0, "Equipe");
        }
        public void AjouterMembreEquipe()
        {
            if (BeneficiaireSelectionneList != null) // on va envoyer dans l'équipe
            {
                if (ListBenefiaireEq.FirstOrDefault(item => item.ID_Personne1 == BeneficiaireSelectionneList.ID_Personne1) == null) // si il n'est pas présent dans l'équipe
                {
                    BeneficiaireSelectionneList.ID_Personne1 = new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Ajouter(EquipeSelectionne.ID_Equipe , BeneficiaireSelectionneList.ID_Personne1);
                    ListBenefiaireEq.Add(BeneficiaireSelectionneList);
                }
                else
                    System.Windows.MessageBox.Show("Il est déjà dans l'équipe");
            }
        }
        public void SupprimerMembreEquipe()
        {
            if (BeneficiaireSelectionneEq != null && BeneficiaireSelectionneEq.ID_Personne1 != 0) // on va envoyer dans l'équipe
            {
                List<C_T_Li_Eq_Benef> tmp = new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Lire(""); // on charge toutes les liaisons
                foreach (C_T_Li_Eq_Benef t in tmp)
                {
                    if (t.ID_Equipe == EquipeSelectionne.ID_Equipe && t.ID_Beneficiaire == BeneficiaireSelectionneEq.ID_Personne1)
                    {
                        new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Supprimer(t.ID_Li_Eq_Benef);
                        ListBenefiaireEq.Remove(BeneficiaireSelectionneEq);
                        System.Windows.MessageBox.Show("Liaison supprimé");
                        BeneficiaireSelectionneEq = new C_Personne();
                        BeneficiaireSelectionneEq.ID_Personne1 = 0;
                        break;
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("pas de membres");
        }
        #endregion

        #endregion
        public class VM_ID_Descr : BasePropriete
        {
            private int _ID, _Type;
            private string _Descr;
           
            public int ID
            {
                get { return _ID; }
                set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public int Type
            {
                get { return _Type; }
                set { AssignerChamp<int>(ref _Type, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string Descr
            {
                get { return _Descr; }
                set { AssignerChamp<string>(ref _Descr, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }

        public VM_GestionEventParam()
        {
            NouvelleInfo = new VM_ID_Descr();

            ListTitre = ChargerTItre(chConnexion);
            ListLieux = ChargerLieux(chConnexion);
            ListEquipe = ChargerEquipe(chConnexion);
            ListBeneficiaire = ChargerBenefiaires(chConnexion);

            ActiverNouvelleDonnées = false;

            cConfirmerInfo = new BaseCommande(ConfirmerInfo);
            cAnnulerInfo = new BaseCommande(AnnulerInfo);
            cConfirmerEquipeMembres = new BaseCommande(ConfirmerInfoEquipe);
            cAjouterMembreEquipe = new BaseCommande(AjouterMembreEquipe);
            cSupprimerMembreEquipe = new BaseCommande(SupprimerMembreEquipe);

            cAjouterTitre = new BaseCommande(AjouterTitre);
            cAjouterLieux = new BaseCommande(AjouteurLieux);
            cAjouterEquipe = new BaseCommande(AjouterEquipe);

            cModifierTitre = new BaseCommande(ModifierTitre);
            cModifierLieux = new BaseCommande(ModifierLieux);
            cModifierEquipe = new BaseCommande(ModifierEquipe);
            cModifierEquipeMembres = new BaseCommande(ModifierEquipeMembres);

            cSupprimerTitre = new BaseCommande(SupprimerTitre);
            cSupprimerLieux = new BaseCommande(SupprimerLieux);
            cSupprimerEquipe = new BaseCommande(SupprimerEquipe);
        }

    }
}
