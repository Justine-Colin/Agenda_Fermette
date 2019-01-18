using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;

namespace Encodage_Fermette.ViewModel
{
     public class VM_GestionEvenement : BasePropriete
    {
        private DateTime _DateDebut;
        public DateTime DateDebut
        {
            get { return _DateDebut; }
            set { AssignerChamp<DateTime>(ref _DateDebut, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
}
