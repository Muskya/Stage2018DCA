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
    public partial class FraisAnnexes : Window
    {
        //Champ pouvant accueillir une instance de ChoixOptions
        //(définie dans la méthode ChoixOptions.FraisAnnexesWindow())
        public ChoixOptions co;

        //Change la valeur du label avec le prix total du devis en prenant comme entrée
        //deux paramètres (ici prixTotalDevis et prixTotalFraisAnnexes)
        public void ActualiserPrixDevis(double p1, double p2)
        {
            co.labelPrixDynamiqueValeur.Content = (p1 + p2).ToString();
        }

        public FraisAnnexes()
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);

            Fonctions.prixAssuranceDO = (1.48 / 100) * Fonctions.prixTotalDevis;
            txtPrixAssuranceDO.Text = Fonctions.prixAssuranceDO.ToString();

            #region Check des checkboxes en fonction du type de terrain
            //Conditions checkboxes Terrassement
            if (Fonctions.terrainPlat == true) {

                chkTerrassementLeger.IsChecked = true;

                labelTerrainPlatTerrassement.Opacity = 1.0;
                labelTerrainSemiPentuTerrassement.Opacity = 0.35; //On repasse les autres labels à 35% d'opacité.
                labelTerrainPentuTerrassement.Opacity = 0.35;

                Fonctions.prixTerrassement = 2000;

            } else if (Fonctions.terrainSemiPentu == true) {

                chkTerrassementModere.IsChecked = true;

                labelTerrainSemiPentuTerrassement.Opacity = 1.0;
                labelTerrainPlatTerrassement.Opacity = 0.35;
                labelTerrainPentuTerrassement.Opacity = 0.35;

                Fonctions.prixTerrassement = 3500;

            } else if (Fonctions.terrainPentu == true) {

                chkTerrassementLourd.IsChecked = true;

                labelTerrainPentuTerrassement.Opacity = 1.0;
                labelTerrainPlatTerrassement.Opacity = 0.35;
                labelTerrainSemiPentuTerrassement.Opacity = 0.35;

                Fonctions.prixTerrassement = 4500;
            }
            #endregion 
        }

        //Checkbox fosse septique
        private void chkAssainissement1_Checked(object sender, RoutedEventArgs e)
        {
            chkAssainissement2.IsChecked = false;
            Fonctions.prixAssainissement = 4500;
        }
        //Checkbox tout-à-l'égout
        private void chkAssainissement2_Checked(object sender, RoutedEventArgs e)
        {
            chkAssainissement1.IsChecked = false;
            Fonctions.prixAssainissement = 1000;
        }

        //Bouton de retourz
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Si on choisit le forfait 30ML pour le raccord EDF
        private void chkRaccordEDF30M_Checked(object sender, RoutedEventArgs e)
        {
            Fonctions.prixRaccordementEdf = 1900;
        }    
        //Si on choisit le forfait 30ML pour le raccord d'eau
        private void chkRaccordEau30M_Checked(object sender, RoutedEventArgs e)
        {
            Fonctions.prixRaccordementEau = 1000;
        }

        //Quand on clique malencontreuseusement sur la textbox du prix assurance DO
        private void txtPrixAssuranceDO_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Oust", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        //Evenement bouton du calcul du prix total des frais annexes
        private void btnCalculFrais_Click(object sender, RoutedEventArgs e)
        {
            Fonctions.prixTotalFraisAnnexes = (Fonctions.prixTerrassement + Fonctions.prixRaccordementEau +
                Fonctions.prixRaccordementEdf + Fonctions.prixAssuranceDO + Fonctions.prixAssainissement);

            labelPrixTotalFraisValeur.Content = Fonctions.prixTotalFraisAnnexes.ToString();
        }
        
        //Evénement du bouton "Valider"
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(labelPrixTotalFraisValeur.Content) != 0)
            {
                //Appel de la méthode permettant l'actualisation du label prixDevisTotal de ChoixOptions();
                ActualiserPrixDevis(Fonctions.prixTotalDevis, Fonctions.prixTotalFraisAnnexes);
                this.Close();
            } else
            {
                MessageBox.Show("Veuillez d'abord calculer un prix.", "Erreur", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }
    }
}
