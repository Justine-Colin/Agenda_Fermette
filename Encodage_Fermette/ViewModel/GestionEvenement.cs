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
        private ObservableCollection<C_Vue_ID_Descr> _ListTitre;
        public ObservableCollection<C_Vue_ID_Descr> ListeTitre
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

        public void ChargementEvenementDujour(DateTime Datetime)
        {
            var date = Datetime.Date;
            // System.Windows.MessageBox.Show(date.Date.ToString());
            ListEvent = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Dujour(date);
        }
        public void ChargementEvenement()
        {
            C_T_Event tmp = new CoucheGestion.G_T_Event(chConnexion).Lire_ID(EventSelectionne.ID_Ev);
            UnEvent.ID_Event = EventSelectionne.ID_Ev;
            UnEvent.Lieu = EventSelectionne.Li_Descr; 
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
        public VM_GestionEvenement()
        {
            UnEvent = new VM_Un_Event();
            ListeTitre = ChargerTitres(chConnexion);
            ListLieux = ChargerLieux();
            foreach (C_Vue_ID_Descr t in ListLieux)
                System.Windows.MessageBox.Show(t.Descr);

        }
    }

    public class VM_Un_Event : BasePropriete
    {
        private int _ID_Event, _ID_Titre, _ID_Lieu, _Priorite;
        private string _Titre, _Descriptif, _Lieu;
        private bool _Recurrent;
        private TimeSpan _HeureDebut, _HeureFin;

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
}
