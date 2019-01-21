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
        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        int ajoutclassement;
        int najoutevent;
        int ajoutmenu;
        private bool _ActiverUneFicheDate;
        public bool ActiverUneFicheDate
        {
            get { return _ActiverUneFicheDate; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFicheDate, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverCalendrierDate = !ActiverUneFicheDate;
            }
        }
        public bool _ActiverFicheMenu;
        public bool ActiverFicheMenu
        {
            get { return _ActiverUneFicheDate; }
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
            {AssignerChamp<bool>(ref _ActiverCalendrierDate, value, System.Reflection.MethodBase.GetCurrentMethod().Name);}
        }
        private bool _ActiverAjoutClassement;
        public bool ActiverAjoutClassement
        {
            get { return _ActiverAjoutClassement; }
            set { AssignerChamp<bool>(ref _ActiverAjoutClassement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private bool _ActiverModifClassement;
        public bool ActiverModifClassement
        {
            get { return _ActiverModifClassement; }
            set { AssignerChamp<bool>(ref _ActiverModifClassement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
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
        private List<C_Vue_Event> _ListEvent;
        public List<C_Vue_Event> ListEvent
        {
            get { return _ListEvent; }
            set { AssignerChamp<List<C_Vue_Event>>(ref _ListEvent, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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

        // Liste de gestion des Menu
        private ObservableCollection<C_Vue_Menu> _ListMenu;
        public ObservableCollection<C_Vue_Menu> ListMenu
        {
            get { return _ListMenu; }
            set { AssignerChamp<ObservableCollection<C_Vue_Menu>>(ref _ListMenu, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_Menu _MenuDuJour;
        public C_Vue_Menu MenuDuJour
        {
            get { return _MenuDuJour; }
            set { AssignerChamp<C_Vue_Menu>(ref _MenuDuJour, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_Vue_Menu _MenuSelectionne;
        public C_Vue_Menu MenuSelectionne
        {
            get { return _MenuSelectionne; }
            set { AssignerChamp<C_Vue_Menu>(ref _MenuSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
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

        //Liste Classement 
        private ObservableCollection<C_T_Equipe> _ListEquipe;
        public ObservableCollection<C_T_Equipe> ListEquipe
        {
            get { return _ListEquipe; }
            set { AssignerChamp<ObservableCollection<C_T_Equipe>>(ref _ListEquipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Equipe _Equipe1Selectionne;
        public C_T_Equipe Equipe1Selectionne
        {
            get { return _Equipe1Selectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _Equipe1Selectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Equipe _Equipe2Selectionne;
        public C_T_Equipe Equipe2Selectionne
        {
            get { return _Equipe2Selectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _Equipe2Selectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Equipe _Equipe3Selectionne;
        public C_T_Equipe Equipe3Selectionne
        {
            get { return _Equipe3Selectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _Equipe3Selectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Equipe _EquipeListSelectionne;
        public C_T_Equipe EquipeListSelectionne
        {
            get { return _EquipeListSelectionne; }
            set { AssignerChamp<C_T_Equipe>(ref _EquipeListSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }



        public void ChargementEvenementDujour(DateTime Datetime)
        {
            var date = Datetime.Date;

            ListEvent = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Dujour(date);
            if (ListEvent.Count == 0)
                najoutevent = -1; // on ajout un event car il n'y en a pas
            MenuDuJour = new CoucheGestion.G_Vue_Menu(chConnexion).Lire_Menu_DuJour(date);
            if (MenuDuJour.ID_Menu <1)
            {
                ajoutmenu = -1; // on ajout un menu car il n'y en a pas
            }
            else
            ajoutmenu = 1; // on modif un event car il n'y en a pas

        }
        public void ChargementEvenement()
        {
            C_T_Event tmp = new CoucheGestion.G_T_Event(chConnexion).Lire_ID(EventSelectionne.ID_Ev);
            UnEvent.ID_Event = EventSelectionne.ID_Ev;
            UnEvent.Lieu = EventSelectionne.Li_Descr;
            UnEvent.Titre = EventSelectionne.Ti_Descr;
            UnEvent.Lieu = EventSelectionne.Li_Descr;
            UnEvent.Descriptif = EventSelectionne.Ev_Descr;
            UnEvent.Recurrent = EventSelectionne.Recurent;
            UnEvent.Priorite = EventSelectionne.Prio;
            UnEvent.HeureDebut = EventSelectionne.Ev_HeureDebut;
            UnEvent.HeureFin = EventSelectionne.Ev_HeureFin;

            ListEquipe = ChargerEquipe();
            ListStaffParticipant = ChargerStaffsParticipants(UnEvent.ID_Event);
            ListBenefiaireParticipant = ChargerBeneficiairesParticipants(UnEvent.ID_Event);
            ChargerClassement(UnEvent.ID_Event);
        }
        public ObservableCollection<C_T_Equipe> ChargerEquipe()
        {
            ObservableCollection<C_T_Equipe> rep = new ObservableCollection<C_T_Equipe>();
            List<C_T_Equipe> lTmp = new CoucheGestion.G_T_Equipe(chConnexion).Lire("");
            foreach (C_T_Equipe Tmp in lTmp)
            {
                C_T_Equipe titretmp = new C_T_Equipe(Tmp.ID_Equipe, Tmp.Eq_Nom);
                rep.Add(titretmp);
            }
            return rep;

        }
        public ObservableCollection<C_Vue_ID_Descr> ChargerTitres(string co)
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
        public ObservableCollection<C_Vue_ID_Descr> ChargerLieux()
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
                C_T_Event ev;
            }
            return rep;
        }
        public void ChargerClassement(int idev)
        {
            C_Vue_Classement Class = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Classement_Nom_Equipe(idev);

            if (Class != null)
            {
                ajoutclassement = 1; // va permettre la modif
                System.Windows.MessageBox.Show(Class.Eq1_Nom);
                UnEvent.ID_Classement = Class.ID_Classement;
                UnEvent.Equipe1 = Class.Eq1_Nom;
                UnEvent.Equipe2 = Class.Eq2_Nom;
                UnEvent.Equipe3 = Class.Eq3_Nom;
                ActiverModifClassement = true;
                ActiverAjoutClassement = false;
            }
            else
            {
                ActiverModifClassement = false;
                ActiverAjoutClassement = true;
            }

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

        public BaseCommande cAjouterStaffParticipant { get; set; }
        public BaseCommande cSupprimerStaffParticipan { get; set; }
        public BaseCommande cAjouterBeneficiaireParticipant { get; set; }
        public BaseCommande cSupprimerBeneficiaireParticipan { get; set; }

        public BaseCommande cModifierEquipe1 { get; set; }
        public BaseCommande cModifierEquipe2 { get; set; }
        public BaseCommande cModifierEquipe3 { get; set; }

        public BaseCommande cAjouterClassement { get; set; }
        public BaseCommande cConfirmerClassement { get; set; }
        public BaseCommande cSupprimerClassement { get; set; }

        public BaseCommande cModifierMenu { get; set; }
        public BaseCommande cSupprimerMenu { get; set; }

        public BaseCommande cGestionMenu { get; set; }
        public BaseCommande cGestionEvent { get; set; }

        public void AjouterStaffParticipant()
        {
            if (StaffSelectionneList != null) // on va envoyer dans l'équipe
            {
                if (ListStaffParticipant.FirstOrDefault(item => item.ID_Personne1 == StaffSelectionneList.ID_Personne1) == null) // si il n'est pas présent dans l'équipe
                {
                    StaffSelectionneList.ID_Personne1 = new CoucheGestion.G_T_Li_Staff(chConnexion).Ajouter(UnEvent.ID_Event, StaffSelectionneList.ID_Personne1);
                    ListStaffParticipant.Add(StaffSelectionneList);
                }
                else
                    System.Windows.MessageBox.Show("Il est dans l'event dans l'équipe");
            }
        }
        public void SupprimerStaffParticipan()
        {
            if (StaffParticipantSelectionne != null && StaffParticipantSelectionne.ID_Personne1 != 0) // on va envoyer dans l'équipe
            {
                List<C_T_Li_Staff> tmp = new CoucheGestion.G_T_Li_Staff(chConnexion).Lire(""); // on charge toutes les liaisons
                foreach (C_T_Li_Staff t in tmp)
                {
                    if (t.ID_Event == UnEvent.ID_Event && t.ID_Staff == StaffParticipantSelectionne.ID_Personne1)
                    {
                         new CoucheGestion.G_T_Li_Eq_Benef(chConnexion).Supprimer(t.ID_Li_Staff);
                        ListStaffParticipant.Remove(StaffParticipantSelectionne);
                        System.Windows.MessageBox.Show("Liaison supprimé");
                        StaffParticipantSelectionne = new C_Personne();
                        StaffParticipantSelectionne.ID_Personne1 = 0;
                        break;
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("pas de membres");

        }
        public void AjouterBeneficiaireParticipant()
        {
            if (BeneficiaireSelectionneList != null) // on va envoyer dans l'équipe
            {
                if (ListBenefiaireParticipant.FirstOrDefault(item => item.ID_Personne1 == BeneficiaireSelectionneList.ID_Personne1) == null) // si il n'est pas présent dans l'équipe
                {
                    // StaffSelectionneList.ID_Personne1 = new CoucheGestion.G_T_Li_Staff(chConnexion).Ajouter(UnEvent.ID_Event, StaffSelectionneList.ID_Personne1);
                    ListBenefiaireParticipant.Add(BeneficiaireSelectionneList);
                }
                else
                    System.Windows.MessageBox.Show("Il est dans l'event dans l'équipe");
            }

        }
        public void SupprimerBeneficiaireParticipan()
        {
            if (BeneficiaireParticipantSelectionne != null && BeneficiaireParticipantSelectionne.ID_Personne1 != 0) // on va envoyer dans l'équipe
            {
                List<C_T_Li_Ben> tmp = new CoucheGestion.G_T_Li_Ben(chConnexion).Lire(""); // on charge toutes les liaisons
                foreach (C_T_Li_Ben t in tmp)
                {
                    if (t.ID_Event == UnEvent.ID_Event && t.ID_Beneficiaire == BeneficiaireParticipantSelectionne.ID_Personne1)
                    {
                        new CoucheGestion.G_T_Li_Ben(chConnexion).Supprimer(t.ID_Li_Ben);
                        ListBenefiaireParticipant.Remove(BeneficiaireParticipantSelectionne);
                        System.Windows.MessageBox.Show("Liaison supprimé");
                        BeneficiaireParticipantSelectionne = new C_Personne();
                        BeneficiaireParticipantSelectionne.ID_Personne1 = 0;
                        break;
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("pas de membres");
        }
        public void ModifierEquipe1()
        {
            if (UnEvent.ID_Classement != 0 && EquipeListSelectionne != null)
            {
                System.Windows.MessageBox.Show("Equipe 1 modifié !");
                Equipe1Selectionne = EquipeListSelectionne;
                UnEvent.Equipe1 = Equipe1Selectionne.Eq_Nom;

            }
            else
            {
                System.Windows.MessageBox.Show("Classement supprimé ou il faut selectionner une equipe !");
            }
        }
        public void ModifierEquipe2()
        {
            if (UnEvent.ID_Classement != 0 && EquipeListSelectionne != null)
            {
                System.Windows.MessageBox.Show("Equipe 2  modifié !");
                Equipe2Selectionne = EquipeListSelectionne;
                UnEvent.Equipe2 = Equipe2Selectionne.Eq_Nom;
            }
            else
            {
                System.Windows.MessageBox.Show("Classement supprimé ou il faut selectionner une equipe !");
            }
        }
        public void ModifierEquipe3()
        {
            if (UnEvent.ID_Classement != 0 && EquipeListSelectionne != null)
            {
                System.Windows.MessageBox.Show("Equipe 3 modifié !");
                Equipe3Selectionne = EquipeListSelectionne;
                UnEvent.Equipe3 = Equipe3Selectionne.Eq_Nom;
            }
            else
            {
                System.Windows.MessageBox.Show("Classement supprimé ou il faut selectionner une equipe !");
            }
        }

        public void AjouterClassement()
        {
            ajoutclassement = -1;
            // a tester 
        }
        public void ConfirmerClassement()
        {
            if (ajoutclassement > 0) //modif
            {
                
                int i  = new CoucheGestion.G_T_Classement(chConnexion).Modifier(UnEvent.ID_Classement, UnEvent.ID_Event, Equipe1Selectionne.ID_Equipe, Equipe2Selectionne.ID_Equipe, Equipe3Selectionne.ID_Equipe);
                ActiverAjoutClassement = false;
                ActiverModifClassement = false;
                System.Windows.MessageBox.Show("Classement Modifié !" + UnEvent.ID_Classement.ToString());
            }
            else
            {
                UnEvent.ID_Classement = new CoucheGestion.G_T_Classement(chConnexion).Ajouter( UnEvent.ID_Event, Equipe1Selectionne.ID_Equipe, Equipe2Selectionne.ID_Equipe, Equipe3Selectionne.ID_Equipe);
                System.Windows.MessageBox.Show("Classement Ajouté !");
            }
        }
        public void SupprimerClassement()
        {
            if (UnEvent.ID_Classement == 0)
            {
                UnEvent.ID_Classement = new CoucheGestion.G_T_Classement(chConnexion).Supprimer(UnEvent.ID_Classement);
                UnEvent.ID_Classement = 0;
                System.Windows.MessageBox.Show("Classement supprimer !");
            }
            else
                System.Windows.MessageBox.Show("Pas de classement a supprimer!");
        }
        public void ModifierMenu()
        {
            if(ajoutmenu == 1)
            {

            }
        }
        public void SupprimerMenu()
        {

        }
        public void GestionEvent()
        {
            ActiverUneFicheDate = true;
        }
        public void GestionMenu()
        {
            ActiverFicheMenu = true;
        }
        public VM_GestionEvenement()
        {
            UnEvent = new VM_Un_Event();
            ActiverUneFicheDate = false;
            ActiverCalendrierDate = true;

            StaffSelectionneList = new C_Personne();
            StaffParticipantSelectionne = new C_Personne();
            BeneficiaireSelectionneList = new C_Personne();
            BeneficiaireParticipantSelectionne = new C_Personne();

            Equipe1Selectionne = new C_T_Equipe(0, "pas d'equipe");
            Equipe2Selectionne = new C_T_Equipe(0, "pas d'equipe");
            Equipe3Selectionne = new C_T_Equipe(0, "pas d'equipe");

            ListeTitre = ChargerTitres(chConnexion);
            ListLieux = ChargerLieux();
            ListMenu = ChargerMenu();
            ListBeneficiaire = ChargerBeneficiaires();
            ListStaff = ChargerStaffs();

            cAjouterStaffParticipant = new BaseCommande(AjouterStaffParticipant);
            cSupprimerStaffParticipan = new BaseCommande(SupprimerStaffParticipan);
            cAjouterBeneficiaireParticipant = new BaseCommande(AjouterBeneficiaireParticipant);
            cSupprimerBeneficiaireParticipan = new BaseCommande(SupprimerBeneficiaireParticipan);

            cAjouterClassement = new BaseCommande(AjouterClassement);
            cConfirmerClassement = new BaseCommande(ConfirmerClassement);
            cSupprimerClassement = new BaseCommande(SupprimerClassement);

            cModifierEquipe1 = new BaseCommande(ModifierEquipe1);
            cModifierEquipe2 = new BaseCommande(ModifierEquipe2);
            cModifierEquipe3 = new BaseCommande(ModifierEquipe3);

            cModifierMenu = new BaseCommande(ModifierMenu);
            cSupprimerMenu = new BaseCommande(SupprimerMenu);

            cGestionEvent = new BaseCommande(GestionEvent);
            cGestionMenu = new BaseCommande(GestionMenu);
        }
}
    public class VM_Un_Event : BasePropriete
    {
        private int _ID_Date,_ID_Event, _ID_Titre, _ID_Lieu, _Priorite,_ID_Classement;
        private string _Titre, _Descriptif, _Lieu;
        private bool _Recurrent;
        private TimeSpan _HeureDebut, _HeureFin;
        private string _Equipe1, _Equipe2, _Equipe3;

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
        public int ID_Classement
        {
            get { return _ID_Classement; }
            set { AssignerChamp<int>(ref _ID_Classement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
}
