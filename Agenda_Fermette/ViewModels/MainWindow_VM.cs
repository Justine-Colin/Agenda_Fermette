﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Agenda_Fermette.ViewModels
{
    class MainWindow_VM
    {
        #region Déclarations et accesseurs
        public string RessourcesImages = Directory.GetCurrentDirectory() + @"\Ressources\Images\"; //Images du programme
        //?private DateTime _Date = DateTime.Parse("01-01"); //Date des events à afficher, initialisée au 1er janvier
        protected string sChConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Liste des gens ayant leurs anniversaires
        public List<C_Personne> Liste_Annif = new List<C_Personne>();
        //Liste des infos importantes
        public List<C_Vue_Event> ListeSemaine = new List<C_Vue_Event>();
        public List<C_Vue_Event> ListeDemain = new List<C_Vue_Event>();
        //Liste des infos du jour
        public List<C_Vue_Event> ListeInfo = new List<C_Vue_Event>();

        //Menu
        private string _Entree;
        private string _Plat;
        private string _Dessert;
        private string _Collation;

        /*?public DateTime Date
        {
            get { return _Date; }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                }
            }
        }*/
        public string Entree
        {
            get { return _Entree; }
            set
            {
                if (_Entree != value)
                    _Entree = value;
                OnPropertyChanged();
            }
        }
        public string Plat
        {
            get { return _Plat; }
            set
            {
                if (_Plat != value)
                    _Plat = value;
                OnPropertyChanged();
            }
        }
        public string Dessert
        {
            get { return _Dessert; }
            set
            {
                if (_Dessert != value)
                    _Dessert = value;
                OnPropertyChanged();
            }
        }
        public string Collation
        {
            get { return _Collation; }
            set
            {
                if (_Collation != value)
                    _Collation = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructeur
        public MainWindow_VM()
        {

        }
        #endregion

        #region Méthodes
        public void ChargerMenu(DateTime date)
        {
            C_Vue_Menu MenuAffiche = new G_Vue_Menu(sChConnexion).Lire_Menu_DuJour(date);
            if (MenuAffiche.E_Descr != null) //Si qqch est chargé
            {
                Entree = MenuAffiche.E_Descr.ToString();
                Plat = MenuAffiche.P_Descr.ToString();
                Dessert = MenuAffiche.D_Descr.ToString();
                Collation = MenuAffiche.C_Descr.ToString();
            }
            else Plat = "Surprise !";
        }

        public void ChargerAnnif(DateTime date)
        {
            int Mois = date.Month, Jour = date.Day;
            List<C_Personne> List_Ben = new G_Vue_Personne(sChConnexion).Lire_Annif_Ben(Mois, Jour);
            List<C_Personne> List_Staff = new G_Vue_Personne(sChConnexion).Lire_Annif_Staff(Mois, Jour);
            foreach(var ben in List_Ben)
            {
                Liste_Annif.Add(ben);
            }
            foreach (var staff in List_Staff)
            {
                Liste_Annif.Add(staff);
            }
        }

        public void ChargerEvents(DateTime date)
        {
            List<C_Vue_Event> List_Events = new G_Vue_Event(sChConnexion).Lire_Event_Dujour(date);
            foreach(var info in List_Events)
            {
                ListeInfo.Add(info);
            }
        }

        public void ChargerImportant(DateTime date)
        {
            List<C_Vue_Event> List_Demain = new G_Vue_Event(sChConnexion).Lire_Event_Prio_Date_DF(1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1));
            List<C_Vue_Event> List_Semaine = new G_Vue_Event(sChConnexion).Lire_Event_Prio_Date_DF(1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(7));
            foreach (var Dem in List_Demain)
            {
                ListeDemain.Add(Dem);
            }
            foreach (var Sem in List_Semaine)
            {
                ListeDemain.Add(Sem);
            }
        }
        #endregion
    }
}
