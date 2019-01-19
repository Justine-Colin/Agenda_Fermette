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
        private int nAjout;

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

        public VM_GestionEventParam()
        {
            ListTitre = ChargerTItre(chConnexion);
            ListLieux = ChargerLieux(chConnexion);
            ListEquipe = ChargerEquipe(chConnexion);
            ListBeneficiaire = ChargerBenefiaires(chConnexion);
        }
    }
}
