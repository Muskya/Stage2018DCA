using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetStage2018
{
    /// <summary>
    /// Logique d'interaction pour ToitureOptions.xaml
    /// </summary>
    public partial class ToitureOptions : Window
    {
        //Cette fenêtre s'ouvre théoriquement lorsque le choix de toiture
        //"Toit-terrasse"
        public ToitureOptions()
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);

            //Affichage de la superficie de la maison
            labelSuperficieTTValeur.Content = Fonctions.superficieMaison.ToString();
            
            //Dégrisage + affichage de la superficie de la terrasse
            //si on a coché le fait que le client veuille une terrasse avant
            if (Fonctions.possedeTerrasse == true)
            {
                labelSuperficieTerrasse.IsEnabled = true;
                labelSuperficieTerrasse2.IsEnabled = true;
                labelSuperficieTerrasseValeur.IsEnabled = true;
                labelSuperficieTerrasseValeur.Content = Fonctions.superficieTerrasse.ToString();
            }
        }

        //Clic sur le bouton Valider
        private void btnValiderOptionsToiture_Click(object sender, RoutedEventArgs e)
        {
            //Ferme la fenêtre des options toit-terrasse
            this.Close();
        }

        //Bouton calcul prix
        private void btnCalculPrixTT_Click(object sender, RoutedEventArgs e)
        {

            //Calcul du prix total du toit-terrasse (en fonction de si le client possède une terrase oui ou non)
            if (Fonctions.possedeTerrasse == true) {
                Fonctions.prixToitTerasse = Fonctions.prixTerrasse + (100 * Fonctions.superficieMaison);
            } else {
                Fonctions.prixToitTerasse = (100 * Fonctions.superficieMaison);
            }

            //Affichage du prix approximatif du toit-terrasse dans le label
            labelPrixTotal.Content = Fonctions.prixToitTerasse.ToString();
        }
    }
}
