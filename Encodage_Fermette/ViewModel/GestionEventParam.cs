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
        private ObservableCollection<C_Personne> _ListBeneficiaireEqSave;
        public ObservableCollection<C_Personne> ListBeneficiaireEqSave
        {
            get { return _ListBeneficiaireEqSave; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListBeneficiaireEqSave, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
                    ListLieux[nAjoutDonne] = new C_Vue_ID_Descr(NouvelleInfo.ID, NouvelleInfo.Descr);
                }
                else if (typedonnes == 2) // modif equipe
                {
                    new CoucheGestion.G_T_Equipe(chConnexion).Modifier(NouvelleInfo.ID, NouvelleInfo.Descr);
                    ListEquipe[nAjoutDonne] = new C_T_Equipe(NouvelleInfo.ID, NouvelleInfo.Descr);
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
            if (TitreSelectionne != null && TitreSelectionne.ID !=0)
            {
                NouvelleInfo = new C_Vue_ID_Descr(TitreSelectionne.ID, TitreSelectionne.Descr);
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
            if (LieuxSelectionne != null && LieuxSelectionne.ID != 0)
            {
                NouvelleInfo = new C_Vue_ID_Descr(LieuxSelectionne.ID, LieuxSelectionne.Descr);
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
            if (EquipeSelectionne != null && EquipeSelectionne.ID_Equipe != 0)
            {
                NouvelleInfo = new C_Vue_ID_Descr(EquipeSelectionne.ID_Equipe, EquipeSelectionne.Eq_Nom);
                nAjoutDonne = ListEquipe.IndexOf(EquipeSelectionne);
                ActiverNouvelleDonnées = true;
                typedonnes = 2;
            }
            else
            {
                System.Windows.MessageBox.Show("Il n'y a pas d'équipe ");
            }

        }
        public void SupprimerTitre()
        {
            if (TitreSelectionne != null && TitreSelectionne.ID != 0)
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
                TitreSelectionne = new C_Vue_ID_Descr(0, "");
            }
            else
                System.Windows.MessageBox.Show("pas de titres a supprimer");
        }
        public void SupprimerLieux()
        {
            if (LieuxSelectionne != null && LieuxSelectionne.ID != 0)
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
                LieuxSelectionne = new C_Vue_ID_Descr(0, "Lieux");

            }
            else
                System.Windows.MessageBox.Show("pas de lieux a supprimer");
        }
        public void SupprimerEquipe()
        {
            if (EquipeSelectionne != null && EquipeSelectionne.ID_Equipe !=0 )
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
                EquipeSelectionne = new C_T_Equipe(0, "Equipe");
            }
            else
                System.Windows.MessageBox.Show("pas d'équipe a supprimer");

        }
        public void ModifierEquipeMembres()
        {
            if (EquipeSelectionne != null && EquipeSelectionne.ID_Equipe != 0)
            {
                ListBeneficiaireEqSave = new ObservableCollection<C_Personne>() ;
                ListBeneficiaireEqSave = ListBenefiaireEq; // on sauvegarde, ça nous permettra de faire nos suppressions et ajout tout a l'heure
                foreach(C_Personne p in ListBeneficiaireEqSave)
                {
                    System.Windows.MessageBox.Show(p.Nom1);

                }
                ActiverGestionEquipe = true;
            }
            else
                System.Windows.MessageBox.Show("Pas d'équipe");
        }
        public void ConfirmerInfoEquipe()
        {
            bool found = false;

            // on va donc comparer les deux lists la sauvegarder avec l'autre
            // phase d'ajout
            // on compare la nouvelle équipe a l'ancienne
            // si des éléments ne sont pas trouvé on les add
            foreach (C_Personne t in ListBenefiaireEq) // on parcourt la nouvelle équipe 
            {
                foreach (C_Personne ts in ListBeneficiaireEqSave)
                {
                    System.Windows.MessageBox.Show(ts.Nom1 + t.Nom1);

                    if (t.ID_Personne1 == ts.ID_Personne1)
                    {
                        // la personne existe
                        found = true;
                    }
                }
                if (!found)
                {
                    System.Windows.MessageBox.Show("Liaison  ajouter : " + t.Nom1);
                    int liaisonEqBene = new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Ajouter(EquipeSelectionne.ID_Equipe, t.ID_Personne1);
                }
                found = false;

            }
            // phase de suppresion 
            // on compare l'ancienne liste a la nouvelle
            // si des élement ne osnt plus trouvé, ils otnt été supprimé 
            // il faut les supprimer 
            foreach (C_Personne t in ListBeneficiaireEqSave)
            {
                if (ListBenefiaireEq.FirstOrDefault(item => item.ID_Personne1 == t.ID_Personne1) == null)
                // si il n'est pas présent dans la nouvelle équipe, il faut alors le supprimer
                {
                    // il faut le supprimer la liaison avec l'équipe
                    List<C_T_Li_Eq_Benef> ltmp = new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Lire("");
                    foreach ( C_T_Li_Eq_Benef  tl in ltmp)
                    {
                        if (tl.ID_Beneficiaire == t.ID_Personne1 && tl.ID_Equipe == EquipeSelectionne.ID_Equipe) // il a trouve la liaison a delete
                        {
                            int liaisonEqBene = new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Supprimer(tl.ID_Li_Eq_Benef);
                            System.Windows.MessageBox.Show("Liaison supp : " + t.Nom1);
                        }
                    }
                }
                else
                    System.Windows.MessageBox.Show("Liaison  non supp : " + t.Nom1);
            }
            ActiverGestionEquipe = false;
            EquipeSelectionne = new C_T_Equipe(0, "Equipe");
           
        }
        public void AnnulerInfoEquipe()
        {

            ActiverGestionEquipe = false;
            EquipeSelectionne = new C_T_Equipe(0, "Equipe");
        }
        public void Switch()
        {
            if(BeneficiaireSelectionneList!=null) // on va envoyer dans l'équipe
            {

                if ( ListBenefiaireEq.FirstOrDefault(item => item.ID_Personne1 == BeneficiaireSelectionneList.ID_Personne1) == null) // si il n'est pas présent dans l'équipe
                {
                    ListBenefiaireEq.Add(BeneficiaireSelectionneList);
                }
                else
                    System.Windows.MessageBox.Show("Il est déjà dans l'équipe");
            }
            else if (BeneficiaireSelectionneEq!=null) // on va retirer de l'équipe
            {
                ListBenefiaireEq.Remove(BeneficiaireSelectionneEq);
            }
        }
        #endregion
        public VM_GestionEventParam()
        {
            ListTitre = ChargerTItre(chConnexion);
            ListLieux = ChargerLieux(chConnexion);
            ListEquipe = ChargerEquipe(chConnexion);
            ListBeneficiaire = ChargerBenefiaires(chConnexion);
            TitreSelectionne = new C_Vue_ID_Descr(0, "Titres");
            LieuxSelectionne = new C_Vue_ID_Descr(0, "Lieux");
            EquipeSelectionne = new C_T_Equipe(0, "Equipe");
            ActiverNouvelleDonnées = false;

            cConfirmerInfo = new BaseCommande(ConfirmerInfo);
            cAnnulerInfo = new BaseCommande(AnnulerInfo);
            cConfirmerEquipeMembres = new BaseCommande(ConfirmerInfoEquipe);
            cAnnulerEquipeMembres = new BaseCommande(AnnulerInfoEquipe);
            cSwitchEquipe = new BaseCommande(Switch);

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
