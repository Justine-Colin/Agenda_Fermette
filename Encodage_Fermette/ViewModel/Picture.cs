using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace Encodage_Fermette.ViewModel
{
    public class Picture
    {
        public void AjouterPhoto(string NomDossier, string NomFichier)
        {
            OpenFileDialog PicDlg = new OpenFileDialog
            { Filter = "Photo (*.PNG)|*.PNG;" };
            if (PicDlg.ShowDialog() == true)
            {
                // Sauvegarde de la photo dans le dossier "~\Pictures\Beneficiaires\"
                string PicFullPath = PicDlg.FileName;
                string FileName = Path.GetFileName(PicFullPath); // On récupère uniquement le nom du fichier et son extension du chemin entré dans le dialog
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Pictures\\" + NomDossier); // On génère le chemin du dossier "~\Images\Evenements\"
                Directory.CreateDirectory(path); // Si les dossiers n'existent pas encore, ils sont créés
                // Vérification qu'un fichier du même nom n'existe pas déjà
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.Copy(PicFullPath, path); // Et on copie le fichier sélectionné dans "~\Images\Personnes\"
            }
        }

    }
}
