using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using Encodage_Fermette.ViewModel;
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
        private List<C_Vue_Event> _ListEvent;
        public List<C_Vue_Event> ListEvent
        {
            get { return _ListEvent; }
            set { AssignerChamp<List<C_Vue_Event>>(ref _ListEvent, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        public void ChargementEvenementDujour(DateTime Datetime)
        {
            var date = Datetime.Date;
            System.Windows.MessageBox.Show(date.Date.ToString());
            ListEvent = new CoucheGestion.G_Vue_Event(chConnexion).Lire_Event_Dujour(date);
        }

    }
    public class VM_Un_Event : BasePropriete
    {
        private int ID_Event, ID_Titre, ID_Lieu;
        private string
    }
}
