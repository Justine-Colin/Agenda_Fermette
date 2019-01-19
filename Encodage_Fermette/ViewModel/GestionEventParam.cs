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

namespace Encodage_Fermette.ViewModel
{
    class VM_GestionEventParam :BasePropriete
    {
        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        private int nAjoutDonne;
        private int typedonnes;
        bool ActiverNouvelleDonnées;

        private C_Vue_ID_Descr _TitreSelectionne;
        public C_Vue_ID_Descr TitreSelectionne
        {
            get { return _TitreSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _TitreSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _LieuxSelectionne;
        public C_Vue_ID_Descr LieuxSelectionne
        {
            get { return _LieuxSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _LieuxSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Equipe _EquipeSelectionne;
        public C_T_Equipe EquipeSelectionne
        {
            get { return _EquipeSelectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _EquipeSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _NouvelleInfo;
        public C_Vue_ID_Descr NouvelleInfo
        {
            get { return _NouvelleInfo; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _NouvelleInfo, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListTitre;
        public ObservableCollection<C_Vue_ID_Descr> ListTitre
        {
            get { return _ListTitre; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListTitre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_ID_Descr> _ListLieux;
        public ObservableCollection<C_Vue_ID_Descr> ListLieux
        {
            get { return _ListLieux; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListLieux, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Equipe> _ListEquipe;
        public ObservableCollection<C_T_Equipe> ListEquipe
        {
            get { return _ListEquipe; }
            set { AssignerChamp<ObservableCollection<C_T_Equipe>>(ref _ListEquipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        // la list total de bénéficiaire
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
        public BaseCommande cAnnulerEquipeMembres { get; set; }
        public BaseCommande cSwitchEquipe { get; set; }

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
            List<C_T_Equipe> lTmp = new CoucheGestion.G_T_Equipe(chConn).Lire("");
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
        #endregion
        #region methode bouton
        public void ConfirmerInfo()
        {
            if (nAjoutDonne == -1) // ajout
            {
                if (typedonnes == 0) // ajout titre
                {
                     C_T_Titre titre = new C_T_Titre();
                    titre.ID_Titre = new CoucheGestion.G_T_Titre(chConnexion).Ajouter(NouvelleInfo.Descr);
                    C_Vue_ID_Descr tmp = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListTitre.Add(tmp);
                }
                else if (typedonnes == 1) // ajout lieux
                {
                    C_T_Lieu lieux = new C_T_Lieu();
                    lieux.ID_Lieu = new CoucheGestion.G_T_Lieu(chConnexion).Ajouter(NouvelleInfo.Descr);
                    C_Vue_ID_Descr tmp = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListTitre.Add(tmp);
                }
                else if (typedonnes == 2) // ajout equipe
                {
                    C_T_Equipe equipe = new C_T_Equipe();
                    equipe.ID_Equipe = new CoucheGestion.G_T_Lieu(chConnexion).Ajouter(NouvelleInfo.Descr);
                    C_Vue_ID_Descr tmp = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListTitre.Add(tmp);
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
                    ListTitre[nAjoutDonne] = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                }
                else if (typedonnes == 2) // modif equipe
                {
                    new CoucheGestion.G_T_Equipe(chConnexion).Modifier(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListTitre[nAjoutDonne] = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                }
                NouvelleInfo = new C_Vue_ID_Descr();
            }
            ActiverNouvelleDonnées = false;
        }
        public void AnnulerInfo()
        {
            ActiverNouvelleDonnées = false;
            NouvelleInfo = new C_Vue_ID_Descr();
        }
        public void AjouterTitre()
        {
            NouvelleInfo = new C_Vue_ID_Descr(0, "Ajouter titre");
            typedonnes = 0;
            ActiverNouvelleDonnées = true;
            nAjoutDonne = -1;
        }
        public void AjouteurLieux()
        {
            NouvelleInfo = new C_Vue_ID_Descr(1, "Ajouter Lieux");
            typedonnes = 1;
            ActiverNouvelleDonnées = true;
            nAjoutDonne = -1;
        }
        public void AjouterEquipe()
        {
            NouvelleInfo = new C_Vue_ID_Descr(2, "Ajouter titre");
            typedonnes = 2;
            ActiverNouvelleDonnées = true;
            nAjoutDonne = -1;
        }
        public void ModifierTitre()
        {
            if (TitreSelectionne != null)
            {
                NouvelleInfo = new C_Vue_ID_Descr(TitreSelectionne.ID, TitreSelectionne.Descr);
                nAjoutDonne = ListTitre.IndexOf(TitreSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 0;
            }
        }
        public void ModifierLieux()
        {
            if (LieuxSelectionne != null)
            {
                NouvelleInfo = new C_Vue_ID_Descr(LieuxSelectionne.ID, LieuxSelectionne.Descr);
                nAjoutDonne = ListLieux.IndexOf(LieuxSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 1;
            }
        }
        public void ModifierEquipe()
        {
            if (EquipeSelectionne != null)
            {
                NouvelleInfo = new C_Vue_ID_Descr(EquipeSelectionne.ID_Equipe, EquipeSelectionne.Eq_Nom);
                nAjoutDonne = ListEquipe.IndexOf(EquipeSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 2;
            }
        }
        public void SupprimerTitre()
        {
            if (TitreSelectionne != null)
            {
                bool found = false;
                List<C_T_Titre> tmp = new CoucheGestion.G_T_Titre(chConnexion).Lire("");
                foreach (C_T_Titre t in tmp)
                {
                    if (t.ID_Titre == TitreSelectionne.ID)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre titre est utilisée dans un event");
                    }
                }
                if (!found)
                {
                    new CoucheGestion.G_T_Titre(chConnexion).Supprimer(TitreSelectionne.ID);
                    ListTitre.Remove(TitreSelectionne);
                }
            }
        }
        public void SupprimerLieux()
        {
            if (LieuxSelectionne != null)
            {
                bool found = false;
                List<C_T_Lieu> tmp = new CoucheGestion.G_T_Lieu(chConnexion).Lire("");
                foreach (C_T_Lieu t in tmp)
                {
                    if (t.ID_Lieu == LieuxSelectionne.ID)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre lieu est utilisée dans un event");
                    }
                }
                if (!found) // si pas trouvé
                {
                    new CoucheGestion.G_T_Lieu(chConnexion).Supprimer(LieuxSelectionne.ID);
                    ListTitre.Remove(LieuxSelectionne);
                }
            }
        }
        public void SupprimerEquipe()
        {
            if (EquipeSelectionne != null)
            {
                bool found = false;
                List<C_T_Equipe> tmp = new CoucheGestion.G_T_Equipe(chConnexion).Lire("");
                foreach (C_T_Equipe t in tmp)
                {
                    if (t.ID_Equipe == EquipeSelectionne.ID_Equipe)
                    {
                        found = true;
                        System.Windows.MessageBox.Show("Votre lieu est utilisée dans un event");
                    }
                }
                if (!found) // si pas trouvé on peut delete l'équipe mais il faut casser la liaison avec la tables benef
                {
                    List<C_T_Li_Eq_Benef> tmpliaison = new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Lire("");
                    List<C_T_Li_Eq_Benef> tmpliaisonadel = new List<C_T_Li_Eq_Benef>();
                    foreach (C_T_Li_Eq_Benef li in tmpliaison)
                    {
                        if (li.ID_Equipe == EquipeSelectionne.ID_Equipe)
                            new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Supprimer(li.ID_Li_Eq_Benef);
                    }
                    new CoucheGestion.G_T_Equipe(chConnexion).Supprimer(EquipeSelectionne.ID_Equipe);
                    ListEquipe.Remove(EquipeSelectionne);
                }
            }
        }
        #endregion


        public VM_GestionEventParam()
        {
            ListTitre = ChargerTItre(chConnexion);
            ListLieux = ChargerLieux(chConnexion);
            ListEquipe = ChargerEquipe(chConnexion);
            ListBeneficiaire = ChargerBenefiaires(chConnexion);
        }
    }
}
