using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetStage2018
{
    /// <summary>
    /// Logique d'interaction pour PlansModeles.xaml
    /// </summary>
    public partial class PlansModeles : Window
    {
        public PlansModeles()
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);

            //if (Fonctions.superficieMaison > 60 && Fonctions.prixTotalDevis > 150000)
            //{
            //    imgPlan.Source = new BitmapImage(new Uri("rouedentee.png", UriKind.Relative));
            //}
        }

        //Lors du clic sur le bouton de recherche de fichier (pour ajouter
        //de nouveaux projets à l'application)
        private void btnFichier_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("oui");
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            //Si on a bien sélectionné un fichier
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Après avoir sélectionné un fichier
                string selectedFileName = dlg.FileName;
                labelCheminFichier.Content = selectedFileName;
                imgPlan.Source = new BitmapImage(new Uri(selectedFileName));
                //Properties.Resources.NomFichier :)))))))
            }
        }

        //Clic sur le bouton retour
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
