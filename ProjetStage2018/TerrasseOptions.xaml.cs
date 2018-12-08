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
    /// Logique d'interaction pour TerrasseOptions.xaml
    /// </summary>
    public partial class TerrasseOptions : Window
    {
        public TerrasseOptions()
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);

            //Remplie la combobox des superficies de terrasse
            for (int i = 0; i < Fonctions.superficiesTerrasse.Length; i++) {
                cbxSuperficieTerrasse.Items.Add(Fonctions.superficiesTerrasse[i]);
            }
        }

        //Après avoir choisi une superficie pour la terrasse
        private void cbxSuperficieTerrasse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Enregistrement de la superficie en fonction de celle choisie
            switch (cbxSuperficieTerrasse.SelectedIndex)
            {
                case 0:
                    Fonctions.superficieTerrasse = 20;
                    break;
                case 1:
                    Fonctions.superficieTerrasse = 30;
                    break;
                case 2:
                    Fonctions.superficieTerrasse = 40;
                    break;

            }
        }

        //Bouton de validation des options de la terrasse
        private void btnValiderOptionsTerrasse_Click(object sender, RoutedEventArgs e)
        {
            //S'occupe de simplement fermer la fenêtre car toutes les variables
            //contiennent déjà les valeurs dont on a besoin
            this.Close();
        }
        private void chkTerrasseCouverte_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkTerrasseDecouverte.IsChecked = false;

            Fonctions.terrasseCouverte = true;
        }
        private void chkTerrasseDecouverte_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkTerrasseCouverte.IsChecked = false;

            Fonctions.terrasseCouverte = false;
        }

        //Clic sur le bouton de calcul du prix
        private void btnCalculPrixTerrasse_Click(object sender, RoutedEventArgs e)
        {
            //Calcul du prix et affichage dans le label
            Fonctions.prixTerrasse = (80 * Fonctions.superficieTerrasse);
            labelPrixTotalTerrasse.Content = Fonctions.prixTerrasse.ToString();
        }

        //Evenement du bouton "Valeur personnalisée"
        private void btnValeurPersoSuperficieTerrasse_Click(object sender, RoutedEventArgs e)
        {
            ValeursPersos vpSuperficieTerrasse = new ValeursPersos();
            vpSuperficieTerrasse.ShowDialog();
            Fonctions.superficieTerrasse = vpSuperficieTerrasse.ValeurRetournee();

            cbxSuperficieTerrasse.Items.Add(Fonctions.superficieTerrasse);
            cbxSuperficieTerrasse.SelectedIndex = cbxSuperficieTerrasse.Items.IndexOf(Fonctions.superficieTerrasse);
        }
    }
}
