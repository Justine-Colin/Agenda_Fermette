using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using System.Runtime.CompilerServices;

namespace Agenda_Fermette.ViewModels
{
    class Event_VM
    {
        protected string sChConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";

        private int _ID;
        private int _Titre;
        private string _Descriptif;
        private int _Lieu;
        private TimeSpan _HeureDebut;
        private TimeSpan _HeureFin;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                    _ID = value;
                OnPropertyChanged();
            }
        }
        public int Titre
        {
            get { return _Titre; }
            set
            {
                if (_Titre != value)
                    _Titre = value;
                OnPropertyChanged();
            }
        }
        public string Descriptif
        {
            get { return _Descriptif; }
            set
            {
                if (_Descriptif != value)
                    _Descriptif = value;
                OnPropertyChanged();
            }
        }
        public int Lieu
        {
            get { return _Lieu; }
            set
            {
                if (_Lieu != value)
                    _Lieu = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan HeureDebut
        {
            get { return _HeureDebut; }
            set
            {
                if (_HeureDebut != value)
                    _HeureDebut = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan HeureFin
        {
            get { return _HeureFin; }
            set
            {
                if (_HeureFin != value)
                    _HeureFin = value;
                OnPropertyChanged();
            }
        }

        public Event_VM (int ID)
        {
            _ID = ID;
            ChargerEvent();
        }

        public void ChargerEvent()
        {
            C_T_Event Event = new G_T_Event(sChConnexion).Lire_ID(_ID);
            _Titre = Event.ID_Titre;
            _Descriptif = Event.Ev_Descriptif;
            _Lieu = Event.ID_Lieu;
            _HeureDebut = Event.Ev_HeureDebut;
            _HeureFin = Event.Ev_HeureFin;
        }
    }
}
