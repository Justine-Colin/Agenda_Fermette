﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CoucheClasse;
using CoucheAcces;
using CoucheGestion;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
using Microsoft.Win32;
using System.Windows;
using
    System.IO;


namespace Encodage_Fermette.ViewModel
{
    public class VM_Beneficiaire : BasePropriete
    {

        #region Données Ecran 
        private string chConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Windows.Forms.Application.StartupPath + @"\Database1.mdf';Integrated Security=True;Connect Timeout=30";
        private int nAjout;
        private bool _ActiverUneFiche;
        public bool ActiverUneFiche
        {
            get { return _ActiverUneFiche; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche = !ActiverUneFiche;
            }
        }
        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Beneficiaire _BeneficiairefSelectionne;
        public C_T_Beneficiaire BeneficiairefSelectionne
        {
            get { return _BeneficiairefSelectionne; }
            set { AssignerChamp<C_T_Beneficiaire>(ref _BeneficiairefSelectionne, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Donnéees extérieur
        private VM_Un_Beneficiaire _UnBeneficiaire;
        public VM_Un_Beneficiaire UnBeneficiaire
        {
            get { return _UnBeneficiaire; }
            set { AssignerChamp<VM_Un_Beneficiaire>(ref _UnBeneficiaire, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Beneficiaire> _BcpBeneficiaire = new ObservableCollection<C_T_Beneficiaire>();
        public ObservableCollection<C_T_Beneficiaire> BcpBeneficiaire
        {
            get { return _BcpBeneficiaire; }
            set { _BcpBeneficiaire = value; }
        }
        #endregion

        #region Commandes 
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cAjouterPhoto { get; set; }
             #endregion

        public VM_Beneficiaire()
        {
            UnBeneficiaire = new VM_Un_Beneficiaire();
            UnBeneficiaire.ID = 24;
            UnBeneficiaire.Pre = "Prenom";
            UnBeneficiaire.Nom = "Nom";
            UnBeneficiaire.Sexe = false;
            UnBeneficiaire.Nai = DateTime.Today;
            BcpBeneficiaire = ChargerBeneficaire(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cAjouterPhoto = new BaseCommande(AjouterPhoto);
        }

        private ObservableCollection<C_T_Beneficiaire> ChargerBeneficaire(string chConn)
        {
            ObservableCollection<C_T_Beneficiaire> rep = new ObservableCollection<C_T_Beneficiaire>();
            List<C_T_Beneficiaire> lTmp = new G_T_Beneficiaire(chConn).Lire("ID");
            foreach (C_T_Beneficiaire Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (UnBeneficiaire.Nom != null && UnBeneficiaire.Pre != null)
            {
                if (nAjout == -1)
                {
                    UnBeneficiaire.ID = new G_T_Beneficiaire(chConnexion).Ajouter(UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                    BcpBeneficiaire.Add(new C_T_Beneficiaire(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe));
                }
                else
                {
                    new CoucheGestion.G_T_Beneficiaire(chConnexion).Modifier(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                    BcpBeneficiaire[nAjout] = new C_T_Beneficiaire(UnBeneficiaire.ID, UnBeneficiaire.Nom, UnBeneficiaire.Pre, UnBeneficiaire.Nai, UnBeneficiaire.Sexe);
                }
                ActiverUneFiche = false;
            }
            else
                System.Windows.MessageBox.Show("Veuillez remplir les champs Nom/Prenom");
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnBeneficiaire = new VM_Un_Beneficiaire();
            UnBeneficiaire.Nai = new DateTime(1999, 01, 01);
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (BeneficiairefSelectionne != null)
            {
                C_T_Beneficiaire Tmp = new G_T_Beneficiaire(chConnexion).Lire_ID(BeneficiairefSelectionne.ID_Beneficiaire);
                UnBeneficiaire = new VM_Un_Beneficiaire();
                UnBeneficiaire.ID = Tmp.ID_Beneficiaire;
                UnBeneficiaire.Pre = Tmp.B_Prenom;
                UnBeneficiaire.Nom = Tmp.B_Nom;
                UnBeneficiaire.Nai = Tmp.B_Annif;
                nAjout = BcpBeneficiaire.IndexOf(BeneficiairefSelectionne);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (BeneficiairefSelectionne != null)
            {
                if (new CoucheGestion.G_Verification(chConnexion).Verification_Beneficiaire_Event(BeneficiairefSelectionne.ID_Beneficiaire).Count == 0)
                {
                    if (new CoucheGestion.G_Verification(chConnexion).Verification_Beneficiaire_Equipe(BeneficiairefSelectionne.ID_Beneficiaire).Count == 0)
                    {
                        new CoucheGestion.G_T_Beneficiaire(chConnexion).Supprimer(BeneficiairefSelectionne.ID_Beneficiaire);
                        BcpBeneficiaire.Remove(BeneficiairefSelectionne);
                    }
                    else
                        System.Windows.MessageBox.Show("Beneficiaire non supprimable car utilisé dans equipe !");

                }
                else
                    System.Windows.MessageBox.Show("Beneficiaire non supprimable car utilisé dans event !");
            }
        }
        public void PersonneSelectionnee2UnePersonne()
        {
            UnBeneficiaire.Nom = BeneficiairefSelectionne.B_Nom;
            UnBeneficiaire.Pre = BeneficiairefSelectionne.B_Prenom;
            UnBeneficiaire.Nai = BeneficiairefSelectionne.B_Annif;
            UnBeneficiaire.Sexe = BeneficiairefSelectionne.B_Sexe;
        }
        public class VM_Un_Beneficiaire : BasePropriete
        {
            private int _ID;
            private string _Nom, _Pre;
            private DateTime _Nai;
            private bool _Sexe;
            public int ID
            {
                get { return _ID; }
                set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string Pre
            {
                get { return _Pre; }
                set { AssignerChamp<string>(ref _Pre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public string Nom
            {
                get { return _Nom; }
                set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public DateTime Nai
            {
                get { return _Nai; }
                set { AssignerChamp<DateTime>(ref _Nai, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
            public bool Sexe
            {
                get { return _Sexe; }
                set { AssignerChamp<bool>(ref _Sexe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }

        public void AjouterPhoto()
        {
            if (BeneficiairefSelectionne != null)
            {
                OpenFileDialog PicDlg = new OpenFileDialog
                { Filter = "Photo (*.PNG;*.JPG;*.jpeg)|*.PNG;*.JPG;*.jpeg" };
                if (PicDlg.ShowDialog() == true)
                {
                    // Sauvegarde de la photo dans le dossier "~\Pictures\Beneficiaires\"
                    string PicFullPath = PicDlg.FileName;
                    string FileName = Path.GetFileName(PicFullPath); // On récupère uniquement le nom du fichier et son extension du chemin entré dans le dialog
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Pictures\\Beneficiaires"); // On génère le chemin du dossier "~\Images\Evenements\"
                    Directory.CreateDirectory(path); // Si les dossiers n'existent pas encore, ils sont créés
                    path = Path.Combine(path, FileName); // On rajoute le nom du fichier au path
                                                         // Vérification qu'un fichier du même nom n'existe pas déjà
                    string TestPath = path;
                    int Count = 0;
                    while (File.Exists(TestPath))
                    {
                        string tempFileName = string.Format("{0}({1})", Path.GetFileNameWithoutExtension(path), Count++);
                        TestPath = Path.Combine(Path.GetDirectoryName(path), tempFileName + Path.GetExtension(path));
                    }
                    path = TestPath;
                    File.Copy(PicFullPath, path); // Et on copie le fichier sélectionné dans "~\Images\Personnes\"

                    /*
                    // MàJ de la DB
                    int ID = new G_PhotoEvenement(sChConn).Ajouter(this.IDevenement, path, false);
                    // MàJ locale
                    PhotosEvenement.Add(new C_PhotoEvenement(ID, this.IDevenement, path, false));
                    */
                }
            }
            else
                System.Windows.MessageBox.Show("Veuillez choisir un beneficiaire !");
        }
    }
}