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

        private DateTime _DateDebut;
        public DateTime DateDebut
        {
            get { return _DateDebut; }
            set { AssignerChamp<DateTime>(ref _DateDebut, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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


        public void ChargementEvenementDujour(DateTime Datetime)
        {
            var date = Datetime.Date;
            // System.Windows.MessageBox.Show(date.Date.ToString());
            ListEvent = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Dujour(date);
            MenuDuJour = new CoucheGestion.G_Vue_Menu(chConnexion).Lire_Menu_DuJour(date);
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

            C_Vue_Classement Classement = ChargerClassement(UnEvent.ID_Event);
             C_T_Equipe tmp1 = new C_T_Equipe(Classement.ID_Eq1,Classement.Eq1_Nom);
            UnEvent.Equipe1 = tmp1;
            C_T_Equipe tmp2 = new C_T_Equipe(Classement.ID_Eq1, Classement.Eq1_Nom);
            UnEvent.Equipe2 = tmp2;
            C_T_Equipe tmp3 = new C_T_Equipe(Classement.ID_Eq1, Classement.Eq1_Nom);
            UnEvent.Equipe3 = tmp3;
            ListEquipe = ChargerEquipe();
            ListStaffParticipant = ChargerStaffsParticipants(UnEvent.ID_Event);
            ListBenefiaireParticipant = ChargerBeneficiairesParticipants(UnEvent.ID_Event);
            foreach (C_Personne p in ListBenefiaireParticipant)
                System.Windows.MessageBox.Show(p.Nom1);
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
        public ObservableCollection<C_Vue_ID_Descr> ChargerTitres( string co)
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
                C_Vue_Menu menu = new C_Vue_Menu(Tmp.ID_Menu,Tmp.E_Descr,Tmp.P_Descr,Tmp.D_Descr,Tmp.C_Descr);
                rep.Add(menu);
                C_T_Event ev;
            }
            return rep;
        }
        public C_Vue_Classement ChargerClassement(int idev)
        {
            C_Vue_Classement Class = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Classement_Nom_Equipe(idev);
            Equipe1Selectionne.ID_Equipe = Class.ID_Eq1;
            Equipe2Selectionne.ID_Equipe = Class.ID_Eq2;
            Equipe3Selectionne.ID_Equipe = Class.ID_Eq3;
            Equipe1Selectionne.Eq_Nom = Class.Eq1_Nom;
            Equipe2Selectionne.Eq_Nom = Class.Eq2_Nom;
            Equipe3Selectionne.Eq_Nom = Class.Eq3_Nom;
            return Class;
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

        public VM_GestionEvenement()
        {
            UnEvent = new VM_Un_Event();
            Equipe1Selectionne= new C_T_Equipe(0, "Equipe1");
            Equipe2Selectionne = new C_T_Equipe(0, "Equipe1");
            Equipe3Selectionne = new C_T_Equipe(0, "Equipe1");

            ListeTitre = ChargerTitres(chConnexion);
            ListLieux = ChargerLieux();
            ListMenu = ChargerMenu();
            ListBeneficiaire = ChargerBeneficiaires();
            ListStaff = ChargerStaffs();
            
        }
    }
    public class VM_Un_Event : BasePropriete
    {
        private int _ID_Event, _ID_Titre, _ID_Lieu, _Priorite;
        private string _Titre, _Descriptif, _Lieu;
        private bool _Recurrent;
        private TimeSpan _HeureDebut, _HeureFin;
        private C_T_Equipe _Equipe1, _Equipe2, _Equipe3;

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
        public C_T_Equipe Equipe1
        {
            get { return _Equipe1; }
            set { AssignerChamp<C_T_Equipe>(ref _Equipe1, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public C_T_Equipe Equipe2
        {
            get { return _Equipe2; }
            set { AssignerChamp<C_T_Equipe>(ref _Equipe2, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public C_T_Equipe Equipe3
        {
            get { return _Equipe3; }
            set { AssignerChamp<C_T_Equipe>(ref _Equipe3, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
}
