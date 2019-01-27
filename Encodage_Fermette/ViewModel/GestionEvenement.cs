using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using System.Windows;

namespace Encodage_Fermette.ViewModel
{
    public class VM_GestionEvenement : BasePropriete
    {
        private DateTime datetraitement;

        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        int ajoutclassement;
        int najoutevent;

        #region Gestion affichage 
        private bool _ActiverUneFicheEvent;
        public bool ActiverUneFicheEvent
        {
            get { return _ActiverUneFicheEvent; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFicheEvent, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private bool _ActiverUneFicheDate;
        public bool ActiverUneFicheDate
        {
            get { return _ActiverUneFicheDate; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFicheDate, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private bool _ActiverFicheMenu;
        public bool ActiverFicheMenu
        {
            get { return _ActiverFicheMenu; }
            set
            {
                AssignerChamp<bool>(ref _ActiverFicheMenu, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverCalendrierDate = !ActiverFicheMenu;
            }
        }
        private bool _ActiverCalendrierDate;
        public bool ActiverCalendrierDate
        {
            get { return _ActiverCalendrierDate; }
            set
            { AssignerChamp<bool>(ref _ActiverCalendrierDate, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private bool _ActiverbtnModifClassement;
        public bool ActiverbtnModifClassement
        {
            get { return _ActiverbtnModifClassement; }
            set { AssignerChamp<bool>(ref _ActiverbtnModifClassement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private bool _ActiverModifClassement;
        public bool ActiverModifClassement
        {
            get { return _ActiverModifClassement; }
            set { AssignerChamp<bool>(ref _ActiverModifClassement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Event 
        #region Paramatre Evennement 
        private VM_Un_Event _UnEvent;
        public VM_Un_Event UnEvent
        {
            get { return _UnEvent; }
            set { AssignerChamp<VM_Un_Event>(ref _UnEvent, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_Event _EventSelectionne;
        public C_Vue_Event EventSelectionne
        {
            get { return _EventSelectionne; }
            set { AssignerChamp<C_Vue_Event>(ref _EventSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Vue_Event> _ListEvent;
        public ObservableCollection<C_Vue_Event> ListEvent
        {
            get { return _ListEvent; }
            set { AssignerChamp<ObservableCollection<C_Vue_Event>>(ref _ListEvent, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private C_Vue_ID_Descr _Titre;
        public C_Vue_ID_Descr Titre
        {
            get { return _Titre; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _Titre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        //  gestion du Titre
        private ObservableCollection<C_Vue_ID_Descr> _ListTitre;
        public ObservableCollection<C_Vue_ID_Descr> ListeTitre
        {
            get { return _ListTitre; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListTitre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _TitreSelectionne;
        public C_Vue_ID_Descr TitreSelectionne
        {
            get { return _TitreSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _TitreSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }
        //  gestion du Lieux
        private ObservableCollection<C_Vue_ID_Descr> _ListLieux;
        public ObservableCollection<C_Vue_ID_Descr> ListLieux
        {
            get { return _ListLieux; }
            set { AssignerChamp<ObservableCollection<C_Vue_ID_Descr>>(ref _ListLieux, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_ID_Descr _LieuxSelectionne;
        public C_Vue_ID_Descr LieuxSelectionne
        {
            get { return _LieuxSelectionne; }
            set { AssignerChamp<C_Vue_ID_Descr>(ref _LieuxSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }
        #endregion

        #region Classement 
        //Liste Classement 
        private VM_Un_Classement _UnClassement;
        public VM_Un_Classement UnClassement
        {
            get { return _UnClassement; }
            set { AssignerChamp<VM_Un_Classement> (ref _UnClassement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }


        private ObservableCollection<C_T_Equipe> _ListEquipe;
        public ObservableCollection<C_T_Equipe> ListEquipe
        {
            get { return _ListEquipe; }
            set { AssignerChamp<ObservableCollection<C_T_Equipe>>(ref _ListEquipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Equipe _EquipeListSelectionne;
        public C_T_Equipe EquipeListSelectionne
        {
            get { return _EquipeListSelectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _EquipeListSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #endregion

        #region Menu 
        // Liste de gestion des Menu

        private ObservableCollection<C_Vue_Menu> _ListMenu;
        public ObservableCollection<C_Vue_Menu> ListMenu
        {
            get { return _ListMenu; }
            set { AssignerChamp<ObservableCollection<C_Vue_Menu>>(ref _ListMenu, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private VM_Un_Menu _MenuDuJour;
        public VM_Un_Menu MenuDuJour
        {
            get { return _MenuDuJour; }
            set { AssignerChamp<VM_Un_Menu>(ref _MenuDuJour, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_Menu _MenuSelectionne;
        public C_Vue_Menu MenuSelectionne
        {
            get { return _MenuSelectionne; }
            set { AssignerChamp<C_Vue_Menu>(ref _MenuSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        // List de gestion des bénéficiaire participants
        private ObservableCollection<C_Personne> _ListBeneficiaire;
        public ObservableCollection<C_Personne> ListBeneficiaire
        {
            get { return _ListBeneficiaire; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListBeneficiaire, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Personne> _ListBenefiaireParticipant;
        public ObservableCollection<C_Personne> ListBenefiaireParticipant
        {
            get { return _ListBenefiaireParticipant; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListBenefiaireParticipant, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Personne> _ListBenefiaireParticipantSave;
        public ObservableCollection<C_Personne> ListBenefiaireParticipantSave
        {
            get { return _ListBenefiaireParticipantSave; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListBenefiaireParticipantSave, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Personne _BeneficiaireSelectionneList;
        public C_Personne BeneficiaireSelectionneList
        {
            get { return _BeneficiaireSelectionneList; }
            set { AssignerChamp<C_Personne>(ref _BeneficiaireSelectionneList, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Personne _BeneficiaireParticipantSelectionne;
        public C_Personne BeneficiaireParticipantSelectionne
        {
            get { return _BeneficiaireParticipantSelectionne; }
            set { AssignerChamp<C_Personne>(ref _BeneficiaireParticipantSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        // List de gestion du staff participants
        private ObservableCollection<C_Personne> _ListStaff;
        public ObservableCollection<C_Personne> ListStaff
        {
            get { return _ListStaff; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListStaff, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Personne> _ListStaffParticipant;
        public ObservableCollection<C_Personne> ListStaffParticipant
        {
            get { return _ListStaffParticipant; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListStaffParticipant, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_Personne> _ListStaffParticipantSave;
        public ObservableCollection<C_Personne> ListStaffParticipantSave
        {
            get { return _ListStaffParticipantSave; }
            set { AssignerChamp<ObservableCollection<C_Personne>>(ref _ListStaffParticipantSave, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Personne _StaffSelectionneList;
        public C_Personne StaffSelectionneList
        {
            get { return _StaffSelectionneList; }
            set { AssignerChamp<C_Personne>(ref _StaffSelectionneList, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Personne _StaffParticipantSelectionne;
        public C_Personne StaffParticipantSelectionne
        {
            get { return _StaffParticipantSelectionne; }
            set { AssignerChamp<C_Personne>(ref _StaffParticipantSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        public BaseCommande cAjouterStaffParticipant { get; set; }
        public BaseCommande cSupprimerStaffParticipan { get; set; }
        public BaseCommande cAjouterBeneficiaireParticipant { get; set; }
        public BaseCommande cSupprimerBeneficiaireParticipan { get; set; }

        public BaseCommande cModifierEquipe1 { get; set; }
        public BaseCommande cModifierEquipe2 { get; set; }
        public BaseCommande cModifierEquipe3 { get; set; }

        public BaseCommande cAjouterClassement { get; set; }
        public BaseCommande cModifierClassement { get; set; }
        public BaseCommande cConfirmerClassement { get; set; }
        public BaseCommande cSupprimerClassement { get; set; }
        public BaseCommande cAnnulerClassement { get; set; }

        public BaseCommande cModifierMenu { get; set; }
        public BaseCommande cSupprimerMenu { get; set; }

        public BaseCommande cGestionMenu { get; set; }
        public BaseCommande cGestionEvent { get; set; }
        public BaseCommande cGestionRetourDateMenu { get; set; }
        public BaseCommande cGestionRetourDateEvent { get; set; }

        public BaseCommande cAjouterEvent { get; set; }
        public BaseCommande cModifierEvent { get; set; }
        public BaseCommande cSupprimerEvent { get; set; }
        public BaseCommande cConfirmerEvent { get; set; }
        public BaseCommande cAnnulerEvent { get; set; }

        #region Methodes 
        #region Chargement Données
        public void ChargementEvenementDujour(DateTime Datetime)
        {
            datetraitement = Datetime;
            var date = Datetime.Date;

            ObservableCollection<C_Vue_Event> rep = new ObservableCollection<C_Vue_Event>();
            List<C_Vue_Event> lTmp = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Dujour(date);
            foreach (C_Vue_Event Tmp in lTmp)
                rep.Add(Tmp);
            ListEvent =  rep;

            C_Vue_Menu tmpmenu = new C_Vue_Menu();
            tmpmenu = new CoucheGestion.G_Vue_Menu(chConnexion).Lire_Menu_DuJour(date);

            MenuDuJour.ID_Date = tmpmenu.ID_Date;
            MenuDuJour.ID_Menu = tmpmenu.ID_Menu;
            MenuDuJour.E_Descr = tmpmenu.E_Descr;
            MenuDuJour.P_Descr = tmpmenu.P_Descr;
            MenuDuJour.D_Descr = tmpmenu.D_Descr;
            MenuDuJour.C_Descr = tmpmenu.C_Descr;
        }

        public void ChargementEvenement()
        {
            // on charge l'event

            UnEvent.ID_Event = EventSelectionne.ID_Date;
            UnEvent.ID_Event = EventSelectionne.ID_Ev;
            UnEvent.Lieu = EventSelectionne.Li_Descr;
            UnEvent.Titre = EventSelectionne.Ti_Descr;
            UnEvent.Lieu = EventSelectionne.Li_Descr;
            UnEvent.Descriptif = EventSelectionne.Ev_Descr;
            UnEvent.Recurrent = EventSelectionne.Recurent;
            UnEvent.Priorite = EventSelectionne.Prio;
            UnEvent.HeureDebut = EventSelectionne.Ev_HeureDebut;
            UnEvent.HeureFin = EventSelectionne.Ev_HeureFin;

            ListStaffParticipant = ChargerStaffsParticipants(UnEvent.ID_Event);
            ListBenefiaireParticipant = ChargerBeneficiairesParticipants(UnEvent.ID_Event);
            ChargerClassement(UnEvent.ID_Event);

        }
        public ObservableCollection<C_Vue_ID_Descr> ChargerListTitres(string co)
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConnexion).Lire_All_Titre();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
            {
                C_Vue_ID_Descr titretmp = new C_Vue_ID_Descr(Tmp.ID, Tmp.Descr);
                rep.Add(titretmp);
            }
            return rep;
        }
        public ObservableCollection<C_Vue_ID_Descr> ChargerListLieux()
        {
            ObservableCollection<C_Vue_ID_Descr> rep = new ObservableCollection<C_Vue_ID_Descr>();
            List<C_Vue_ID_Descr> lTmp = new CoucheGestion.G_Vue_ID_Descr(chConnexion).Lire_All_Lieux();
            foreach (C_Vue_ID_Descr Tmp in lTmp)
            {
                C_Vue_ID_Descr lieuxtmp = new C_Vue_ID_Descr(Tmp.ID, Tmp.Descr);
                rep.Add(lieuxtmp);
            }
            return rep;
        }

        public ObservableCollection<C_Vue_Menu> ChargerMenu()
        {
            ObservableCollection<C_Vue_Menu> rep = new ObservableCollection<C_Vue_Menu>();
            List<C_Vue_Menu> lTmp = new CoucheGestion.G_Vue_Menu(chConnexion).Lire_All_Menu();
            foreach (C_Vue_Menu Tmp in lTmp)
            {
                C_Vue_Menu menu = new C_Vue_Menu(Tmp.ID_Menu, Tmp.E_Descr, Tmp.P_Descr, Tmp.D_Descr, Tmp.C_Descr);
                rep.Add(menu);
            }
            return rep;
        }

        public void ChargerClassement(int idev)
        {
            C_Vue_Classement Class = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Classement_Nom_Equipe(idev);

            if (Class.ID_Classement !=0) // il y a un classement 
            {
                System.Windows.MessageBox.Show(Class.Eq1_Nom);
                
                UnClassement.ID_Classement = Class.ID_Classement;
                UnClassement.Equipe1 = Class.Eq1_Nom;
                UnClassement.Equipe2 = Class.Eq2_Nom;
                UnClassement.Equipe3 = Class.Eq3_Nom;

                UnClassement.ID_Equipe1 = Class.ID_Eq1;
                UnClassement.ID_Equipe2 = Class.ID_Eq2;
                UnClassement.ID_Equipe3 = Class.ID_Eq3;
            }
            else
            {
                UnClassement = new VM_Un_Classement();
            }

        }
        public ObservableCollection<C_T_Equipe> ChargerEquipe()
        {
            ObservableCollection<C_T_Equipe> rep = new ObservableCollection<C_T_Equipe>();
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConnexion).Lire("");
            foreach (C_T_Equipe Tmp in lTmp)
            {
                C_T_Equipe titretmp = new C_T_Equipe(Tmp.ID_Equipe, Tmp.Eq_Nom);
                rep.Add(titretmp);
            }
            return rep;

        }

        public ObservableCollection<C_Personne> ChargerBeneficiaires()
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            List<C_Personne> lTmp = new CoucheGestion.G_Vue_Personne(chConnexion).Lire_All_Ben();
            foreach (C_Personne Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public ObservableCollection<C_Personne> ChargerBeneficiairesParticipants(int idev)
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            List<C_Personne> lTmp = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Ben(idev);
            foreach (C_Personne Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public ObservableCollection<C_Personne> ChargerStaffs()
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            List<C_Personne> lTmp = new CoucheGestion.G_Vue_Personne(chConnexion).Lire_All_Staff();
            foreach (C_Personne Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public ObservableCollection<C_Personne> ChargerStaffsParticipants(int idev)
        {
            ObservableCollection<C_Personne> rep = new ObservableCollection<C_Personne>();
            List<C_Personne> lTmp = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Staff(idev);
            foreach (C_Personne Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        #endregion

        #region Bouton
        public void GestionEvent()
        {
            ListeTitre = ChargerListTitres(chConnexion);
            ListLieux = ChargerListLieux();
            ListBeneficiaire = ChargerBeneficiaires();
            ListStaff = ChargerStaffs();
            ListEquipe = ChargerEquipe();

            ActiverUneFicheDate = true;
            ActiverCalendrierDate = false;
        }
        public void GestionMenu()
        {
            ListMenu = ChargerMenu();

            ActiverFicheMenu = true;
            ActiverCalendrierDate = false;
        }
        public void GestionRetourDateEvent()
        {
            ActiverCalendrierDate = true;

            ActiverUneFicheDate = false;
            ActiverFicheMenu = false;
        }
        public void GestionRetourDateMenu()
        {
            ActiverCalendrierDate = true;

            ActiverUneFicheDate = false;
            ActiverFicheMenu = false;
        }
        public void AjouterStaffParticipant()
        {
            if (StaffSelectionneList != null) // on va envoyer dans l'équipe
            {
                if ( UnEvent.ID_Event!=0  && ListStaffParticipant.FirstOrDefault(item => item.ID_Personne1 == StaffSelectionneList.ID_Personne1) == null) 
                    // si il n'est pas présent dans l'équipe
                {
                    // ici l'event est crée, on est en modification
                    StaffSelectionneList.ID_Personne1 = new CoucheGestion.G_T_Li_Staff(chConnexion).Ajouter(UnEvent.ID_Event, StaffSelectionneList.ID_Personne1);
                    ListStaffParticipant.Add(StaffSelectionneList);
                }
                else if (UnEvent.ID_Event == 0 && ListStaffParticipant.FirstOrDefault(item => item.ID_Personne1 == StaffSelectionneList.ID_Personne1) == null)
                    // si il n'est pas présent dans l'équipe
                    {
                    // ici l'event n'est pas encore céer on est en ajout 
                        ListStaffParticipant.Add(StaffSelectionneList);
                    }

                else
                    System.Windows.MessageBox.Show("Il est dans l'event dans l'équipe");
            }
        }
        public void SupprimerStaffParticipan()
        {
            if (StaffParticipantSelectionne != null && StaffParticipantSelectionne.ID_Personne1 != 0 && UnEvent.ID_Event !=0) // on va envoyer dans l'équipe
            {
                // l'event est déjà crée 
                List<C_T_Li_Staff> tmp = new CoucheGestion.G_T_Li_Staff(chConnexion).Lire(""); // on charge toutes les liaisons
                foreach (C_T_Li_Staff t in tmp)
                {
                    if (t.ID_Event == UnEvent.ID_Event && t.ID_Staff == StaffParticipantSelectionne.ID_Personne1)
                    {
                        new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Supprimer(t.ID_Li_Staff);
                        ListStaffParticipant.Remove(StaffParticipantSelectionne);
                        System.Windows.MessageBox.Show("Liaison supprimé");
                        // StaffParticipantSelectionne = new C_Personne();
                        break;
                    }
                }
            }
            else if (StaffParticipantSelectionne != null && StaffParticipantSelectionne.ID_Personne1 != 0 && UnEvent.ID_Event == 0)
            {
                ListStaffParticipant.Remove(StaffParticipantSelectionne);
                System.Windows.MessageBox.Show("Liaison supprimé sans écriture table");
            }
            else
                System.Windows.MessageBox.Show("pas de membres a delete ");

        }
        public void AjouterBeneficiaireParticipant()
        {
            if (BeneficiaireSelectionneList != null) // on va envoyer dans l'équipe
            {
                if (UnEvent.ID_Event != 0 && ListBenefiaireParticipant.FirstOrDefault(item => item.ID_Personne1 == BeneficiaireSelectionneList.ID_Personne1) == null  ) 
                    // si il n'est pas présent dans l'équipe
                {
                    BeneficiaireSelectionneList.ID_Personne1 = new CoucheGestion.G_T_Li_Ben(chConnexion).Ajouter(UnEvent.ID_Event, BeneficiaireSelectionneList.ID_Personne1);
                    ListBenefiaireParticipant.Add(BeneficiaireSelectionneList);
                }
                else if (UnEvent.ID_Event == 0 && ListBenefiaireParticipant.FirstOrDefault(item => item.ID_Personne1 == BeneficiaireSelectionneList.ID_Personne1) == null)
                {
                    // l'event n'existe pas 
                    ListBenefiaireParticipant.Add(BeneficiaireSelectionneList);
                }
                else
                    System.Windows.MessageBox.Show("Il est dans l'event dans l'équipe");
            }
        }
        public void SupprimerBeneficiaireParticipan()
        {
            if (BeneficiaireParticipantSelectionne != null && BeneficiaireParticipantSelectionne.ID_Personne1 != 0 && UnEvent.ID_Event != 0 ) // on va envoyer dans l'équipe
            {
                // l'event existe
                List<C_T_Li_Ben> tmp = new CoucheGestion.G_T_Li_Ben(chConnexion).Lire(""); // on charge toutes les liaisons
                foreach (C_T_Li_Ben t in tmp)
                {
                    if (t.ID_Event == UnEvent.ID_Event && t.ID_Beneficiaire == BeneficiaireParticipantSelectionne.ID_Personne1)
                    {
                        new CoucheGestion.G_T_Li_Ben(chConnexion).Supprimer(t.ID_Li_Ben);
                        ListBenefiaireParticipant.Remove(BeneficiaireParticipantSelectionne);
                        System.Windows.MessageBox.Show("Liaison supprimé");
                        break;
                    }
                }
            }
            else if (BeneficiaireParticipantSelectionne != null && BeneficiaireParticipantSelectionne.ID_Personne1 != 0 && UnEvent.ID_Event == 0) // on va envoyer dans l'équipe
            {
                ListBenefiaireParticipant.Remove(BeneficiaireParticipantSelectionne);
                System.Windows.MessageBox.Show("Liaison supprimée sans écriture table");
            }
            else
                System.Windows.MessageBox.Show("pas de membres");
        }

        public void ModifierEquipe1()
        {
            if ( EquipeListSelectionne != null)
            {
                // permet d'enregister l'équipe dans une variable

                UnClassement.ID_Equipe1 = EquipeListSelectionne.ID_Equipe;
                UnClassement.Equipe1 = EquipeListSelectionne.Eq_Nom;
            }
            else
            {
                System.Windows.MessageBox.Show("Il faut selectionner une equipe !");
            }
        }
        public void ModifierEquipe2()
        {
            if ( EquipeListSelectionne != null)
            {
                // permet d'enregister l'équipe dans une variable

                UnClassement.ID_Equipe2 = EquipeListSelectionne.ID_Equipe;
                UnClassement.Equipe2 = EquipeListSelectionne.Eq_Nom;
            }
            else
            {
                System.Windows.MessageBox.Show("Il faut selectionner une equipe !");
            }
        }
        public void ModifierEquipe3()
        {
            if ( EquipeListSelectionne != null)
            {
                // permet d'enregister l'équipe dans une variable

                UnClassement.ID_Equipe3 = EquipeListSelectionne.ID_Equipe;
                UnClassement.Equipe3 = EquipeListSelectionne.Eq_Nom;
            }
            else
            {
                System.Windows.MessageBox.Show("Il faut selectionner une equipe !");
            }
        }

        public void AjouterClassement()
        {
            if (UnClassement.ID_Classement == 0)
            {
                    ajoutclassement = -1;
                    ActiverModifClassement = true;
                    ActiverUneFicheEvent = false; // on ne permet plus de valider son evenement
            }
            else
                System.Windows.MessageBox.Show("Il existe déjà un classement");
            // a tester 
        }
        public void ModifierClassement()
        {
            ajoutclassement = 1;
            ActiverModifClassement = true;
            ActiverUneFicheEvent = false; // on ne permet plus de valider son evenement
        }
        public void SupprimerClassement()
        {
            if (UnEvent.ID_Event > 0)
            { 
                // l'event existe déjà
                if (UnClassement.ID_Classement != 0)
                {
                    new CoucheGestion.G_T_Classement(chConnexion).Supprimer(UnClassement.ID_Classement);
                    UnClassement = new VM_Un_Classement();
                    ActiverModifClassement = false;
                    System.Windows.MessageBox.Show("Classement supprimé !");
                }
                else
                    System.Windows.MessageBox.Show("Pas de classement a supprimer!");
            }
            else if ( UnEvent.ID_Event ==0)
            {
                UnClassement = new VM_Un_Classement();
                System.Windows.MessageBox.Show("Classement supprimé sans écriture table !");

            }
        }

        public void ConfirmerClassement()
        {
            if (UnEvent.ID_Event > 0)
                // l'event existe déjà, il ne faut pas le créer 
            {
                if (ajoutclassement > 0) //modif
                {
                    new CoucheGestion.G_T_Classement(chConnexion).Modifier(UnClassement.ID_Classement, UnEvent.ID_Event, UnClassement.ID_Equipe1, UnClassement.ID_Equipe2, UnClassement.ID_Equipe3);
                    System.Windows.MessageBox.Show("Classement Modifié !" + UnClassement.ID_Classement.ToString());
                }
                else
                {
                    UnClassement.ID_Classement = new CoucheGestion.G_T_Classement(chConnexion).Ajouter(UnEvent.ID_Event, UnClassement.ID_Equipe1, UnClassement.ID_Equipe2, UnClassement.ID_Equipe3);
                    System.Windows.MessageBox.Show("Classement Ajouté !");
                }
            }
            else
                System.Windows.MessageBox.Show("Classement Ajoute/modifié sans écriture table !");
            ActiverModifClassement = false;
            ActiverUneFicheEvent = true; // on permet de pouvoir valider son evenement
        }
        public void AnnulerClassement()
        {
            ActiverModifClassement = false;
            ActiverUneFicheEvent = true; // on permet de pouvoir valider son evenement
            ChargerClassement(UnEvent.ID_Event);
        }

        public void ModifierMenu()
        {
            if (MenuSelectionne != null)
            {
                if (MenuDuJour.ID_Menu == 0) // ajout du menu a la date
                {
                    // on ajout un menu
                    // il faut vérifier que le jour existe via son id
                    if (MenuDuJour.ID_Date == 0)
                    {
                        // On doit Créer le jour avec la table date
                        // on renvoit le nouvel id 
                        MenuDuJour.ID_Date = new G_T_Date(chConnexion).Ajouter(MenuDuJour.ID_Menu,datetraitement);
                    }
                    else
                    {
                        // la date existe il faut créer le menu et modifier la date
                        new G_T_Date(chConnexion).Modifier(MenuDuJour.ID_Date, datetraitement, MenuDuJour.ID_Menu);
                    }
                }
                else 
                    // il n'existe un menu du jour, on modifier les id de la date
                    new G_T_Date(chConnexion).Modifier(MenuDuJour.ID_Date, datetraitement, MenuSelectionne.ID_Menu);
                System.Windows.MessageBox.Show(datetraitement.ToShortDateString());


                 //on recharge le menu 
                MenuDuJour.E_Descr = MenuSelectionne.E_Descr;
                MenuDuJour.P_Descr = MenuSelectionne.P_Descr;
                MenuDuJour.D_Descr = MenuSelectionne.D_Descr;
                MenuDuJour.C_Descr = MenuSelectionne.C_Descr; 

            }
            else
                System.Windows.MessageBox.Show("Pas de Menu sélectionné ");
            // on modif un event car il n'y en a pas
        }
        public void SupprimerMenu()
        {
            if (MenuDuJour.ID_Menu != 0)
            {
                new G_T_Date(chConnexion).Supprimer(datetraitement);
                System.Windows.MessageBox.Show("Menu supprimé");
                MenuDuJour.ID_Menu = 0;
                MenuDuJour.E_Descr = "";
                MenuDuJour.P_Descr = "";
                MenuDuJour.D_Descr = "";
                MenuDuJour.C_Descr = "";
            }
            else
                System.Windows.MessageBox.Show("Pas de Menu supprimable ");
        }

        public void AjouterEvent()
        {
            // on s'assure de vider tout nos champs au préalable
            UnEvent = new VM_Un_Event();
            UnClassement = new VM_Un_Classement();
            ListStaffParticipant = new ObservableCollection<C_Personne>();
            ListBenefiaireParticipant = new ObservableCollection<C_Personne>();

            najoutevent = -1;
            ActiverUneFicheEvent = true;
            ActiverUneFicheDate = false;
        }
        public void ModifierEvent()
        {
            if (EventSelectionne != null)
            {
                ActiverUneFicheEvent = true;
                ActiverUneFicheDate = false;
            }
            else
                System.Windows.MessageBox.Show("Pas d'event a modifier");
        }
        public void SupprimerEvent()
        {
            if (EventSelectionne != null)
            {
                // il nous faut supprimer la liaison 
                /*
                List<C_T_Li_Event> Lev =  new CoucheGestion.G_T_Li_Event(chConnexion).Lire("");
                foreach( C_T_Li_Event l in Lev)
                    if ( l.ID_Event ==  EventSelectionne.ID_Ev && l.ID_Date == EventSelectionne.ID_Date)
                new CoucheGestion.G_T_Event(chConnexion).Supprimer(EventSelectionne.ID_Ev);
                */
                new CoucheGestion.G_Verification(chConnexion).Suppresion_Event_Dependances(EventSelectionne.ID_Ev);
                ListEvent.Remove(EventSelectionne);
                System.Windows.MessageBox.Show("Event Supprimer");

            }
            else
                System.Windows.MessageBox.Show("Pas d'event a supprimer");
        }
        public void ConfirmerEvent()
        {
            if (TitreSelectionne != null && UnEvent.Descriptif.Count()>0 && LieuxSelectionne != null)
            {
                if (najoutevent == -1) // ajouter
                {
                    C_Vue_Event evenement = new C_Vue_Event();
                    int id = new G_T_Event(chConnexion).Ajouter(TitreSelectionne.ID, UnEvent.Priorite, UnEvent.Recurrent, UnEvent.Descriptif, LieuxSelectionne.ID, UnEvent.HeureDebut, UnEvent.HeureFin);

                    // on veut ajouter un classement 
                    if (ajoutclassement < 0)
                        new G_T_Classement(chConnexion).Ajouter(id, UnClassement.ID_Equipe1, UnClassement.ID_Equipe2, UnClassement.ID_Equipe3);
                    // On ajoute les staff participant
                    foreach (C_Personne ps in ListStaffParticipant)
                        new CoucheGestion.G_T_Li_Staff(chConnexion).Ajouter(id, ps.ID_Personne1);
                    // On ajoute les bénéficiaires Participant 
                    foreach (C_Personne pb in ListBenefiaireParticipant)
                        new CoucheGestion.G_T_Li_Ben(chConnexion).Ajouter(id, pb.ID_Personne1);
                    List<C_T_Date> Ldate = new CoucheGestion.G_T_Date(chConnexion).Lire("");
                    if (Ldate.FirstOrDefault(item => item.D_Date == datetraitement) == null) 
                        // il n'y a pas d'id date correspondant a la date
                    {
                        evenement.ID_Date = new CoucheGestion.G_T_Date(chConnexion).Ajouter(0, datetraitement);
                    }
                    else if (Ldate.FirstOrDefault(item => item.D_Date == datetraitement) != null) 
                        // il y a un id date correspondant a la date
                    {
                        // on renvoie l'id de la date dans l'event 
                        evenement.ID_Date = Ldate.FirstOrDefault(item => item.D_Date == datetraitement).ID_Date;
                    }
                   
                    evenement.ID_Ev = id;
                    evenement.Ti_Descr = UnEvent.Titre;
                    evenement.Li_Descr = UnEvent.Lieu;
                    evenement.Ev_HeureDebut = UnEvent.HeureDebut;
                    evenement.Ev_HeureFin = UnEvent.HeureFin;
                    ListEvent.Add(evenement);
                    // une fois l'event crée, on le lie 
                    int t = new CoucheGestion.G_T_Li_Event(chConnexion).Ajouter(evenement.ID_Date, evenement.ID_Ev);
                    System.Windows.MessageBox.Show(t.ToString()+ evenement.ID_Date.ToString() + evenement.ID_Ev.ToString() + datetraitement.ToShortDateString());
                    System.Windows.MessageBox.Show("Event Ajouté !");

                }

                // modification d'event
                else
                {
                    najoutevent = new CoucheGestion.G_T_Event(chConnexion).Modifier(UnEvent.ID_Event, TitreSelectionne.ID, UnEvent.Priorite, UnEvent.Recurrent, UnEvent.Descriptif, LieuxSelectionne.ID, UnEvent.HeureDebut, UnEvent.HeureFin);
                    C_Vue_Event evenement = new C_Vue_Event();
                    evenement.ID_Ev = UnEvent.ID_Date;
                    evenement.ID_Ev = UnEvent.ID_Event;
                    evenement.Ti_Descr = UnEvent.Descriptif;
                    evenement.Li_Descr = UnEvent.Lieu;
                    evenement.Ev_HeureDebut = UnEvent.HeureDebut;
                    evenement.Ev_HeureFin = UnEvent.HeureFin;
                    ListEvent[najoutevent] = evenement;
                    System.Windows.MessageBox.Show("Event Modifié !");
                }

                ActiverUneFicheEvent = false; // on désactive l'interaction avec event

                ActiverModifClassement = false; // on désative les interactions avec le classement
                ActiverUneFicheDate = true;
            }
            else
                System.Windows.MessageBox.Show("Il faut un titre/descriptif/lieu pour votre fiche evenement");
        }
        public void AnnulerEvent()
        {
            ActiverUneFicheEvent = false;
            ActiverModifClassement = false;
            ActiverUneFicheEvent = true;

            UnEvent = new VM_Un_Event();
            UnClassement = new VM_Un_Classement();
            ListStaffParticipant = new ObservableCollection<C_Personne>();
            ListBenefiaireParticipant = new ObservableCollection<C_Personne>();
        }

        #endregion
        #endregion

        #region Constructeur
        public VM_GestionEvenement()
        {
            UnEvent = new VM_Un_Event();
            MenuDuJour = new VM_Un_Menu();
            UnClassement = new VM_Un_Classement();
            ActiverUneFicheDate = false;
            ActiverCalendrierDate = true;

            StaffSelectionneList = new C_Personne();
            StaffParticipantSelectionne = new C_Personne();
            BeneficiaireSelectionneList = new C_Personne();
            BeneficiaireParticipantSelectionne = new C_Personne();

            #region Commandes
            cAjouterStaffParticipant = new BaseCommande(AjouterStaffParticipant);
            cSupprimerStaffParticipan = new BaseCommande(SupprimerStaffParticipan);
            cAjouterBeneficiaireParticipant = new BaseCommande(AjouterBeneficiaireParticipant);
            cSupprimerBeneficiaireParticipan = new BaseCommande(SupprimerBeneficiaireParticipan);

            cAjouterClassement = new BaseCommande(AjouterClassement);
            cModifierClassement = new BaseCommande(ModifierClassement);
            cConfirmerClassement = new BaseCommande(ConfirmerClassement);
            cSupprimerClassement = new BaseCommande(SupprimerClassement);
            cAnnulerClassement = new BaseCommande(AnnulerClassement);

            cModifierEquipe1 = new BaseCommande(ModifierEquipe1);
            cModifierEquipe2 = new BaseCommande(ModifierEquipe2);
            cModifierEquipe3 = new BaseCommande(ModifierEquipe3);

            cModifierMenu = new BaseCommande(ModifierMenu);
            cSupprimerMenu = new BaseCommande(SupprimerMenu);

            cGestionEvent = new BaseCommande(GestionEvent);
            cGestionMenu = new BaseCommande(GestionMenu);

            cGestionRetourDateMenu = new BaseCommande(GestionRetourDateMenu);
            cGestionRetourDateEvent = new BaseCommande(GestionRetourDateEvent);

            cAjouterEvent = new BaseCommande(AjouterEvent);
            cModifierEvent = new BaseCommande(ModifierEvent);
            cSupprimerEvent = new BaseCommande(SupprimerEvent);
            cConfirmerEvent = new BaseCommande(ConfirmerEvent);
            cAnnulerEvent = new BaseCommande(AnnulerEvent);
            #endregion
        }
        #endregion
    }
    #region VM
    public class VM_Un_Menu : BasePropriete
    {
        private int _ID_Menu,_ID_Date;
        private string _E_Descr, _P_Descr, _D_Descr, _C_Descr;

        public int ID_Date
        {
            get { return _ID_Date; }
            set { AssignerChamp<int>(ref _ID_Date, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Menu
        {
            get { return _ID_Menu; }
            set { AssignerChamp<int>(ref _ID_Menu, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string E_Descr
        {
            get { return _E_Descr; }
            set { AssignerChamp<string>(ref _E_Descr, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string P_Descr
        {
            get { return _P_Descr; }
            set { AssignerChamp<string>(ref _P_Descr, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string D_Descr
        {
            get { return _D_Descr; }
            set { AssignerChamp<string>(ref _D_Descr, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string C_Descr
        {
            get { return _C_Descr; }
            set { AssignerChamp<string>(ref _C_Descr, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
    public class VM_Un_Event : BasePropriete
    {
        private int _ID_Date, _ID_Event, _ID_Titre, _ID_Lieu, _Priorite;
        private string _Titre, _Descriptif, _Lieu;
        private bool _Recurrent;
        private TimeSpan _HeureDebut, _HeureFin;
        public int ID_Date
        {
            get { return _ID_Date; }
            set { AssignerChamp<int>(ref _ID_Date, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Event
        {
            get { return _ID_Event; }
            set { AssignerChamp<int>(ref _ID_Event, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Titre
        {
            get { return _ID_Titre; }
            set { AssignerChamp<int>(ref _ID_Titre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Lieu
        {
            get { return _ID_Lieu; }
            set { AssignerChamp<int>(ref _ID_Lieu, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int Priorite
        {
            get { return _Priorite; }
            set { AssignerChamp<int>(ref _Priorite, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Titre
        {
            get { return _Titre; }
            set { AssignerChamp<string>(ref _Titre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Descriptif
        {
            get { return _Descriptif; }
            set { AssignerChamp<string>(ref _Descriptif, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Lieu
        {
            get { return _Lieu; }
            set { AssignerChamp<string>(ref _Lieu, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public bool Recurrent
        {
            get { return _Recurrent; }
            set { AssignerChamp<bool>(ref _Recurrent, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public TimeSpan HeureDebut
        {
            get { return _HeureDebut; }
            set { AssignerChamp<TimeSpan>(ref _HeureDebut, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public TimeSpan HeureFin
        {
            get { return _HeureFin; }
            set { AssignerChamp<TimeSpan>(ref _HeureFin, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
    public class VM_Un_Classement : BasePropriete
    {
        private int _ID_Equipe1, _ID_Equipe2, _ID_Equipe3,_ID_Classement;
        private string _Equipe1, _Equipe2, _Equipe3;

        public int ID_Classement
        {
            get { return _ID_Classement; }
            set { AssignerChamp<int>(ref _ID_Classement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Equipe1
        {
            get { return _ID_Equipe1; }
            set { AssignerChamp<int>(ref _ID_Equipe1, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Equipe2
        {
            get { return _ID_Equipe2; }
            set { AssignerChamp<int>(ref _ID_Equipe2, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Equipe3
        {
            get { return _ID_Equipe3; }
            set { AssignerChamp<int>(ref _ID_Equipe3, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Equipe1
        {
            get { return _Equipe1; }
            set { AssignerChamp<string>(ref _Equipe1, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Equipe2
        {
            get { return _Equipe2; }
            set { AssignerChamp<string>(ref _Equipe2, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Equipe3
        {
            get { return _Equipe3; }
            set { AssignerChamp<string>(ref _Equipe3, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
    #endregion
}