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
    /// Logique d'interaction pour GarageOptions.xaml
    /// </summary>
    public partial class GarageOptions : Window
    {
        public GarageOptions()
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);
        }

        //Checkers garage accroché / décroché
        private void chkPosGarageAccro_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkPosGarageDecro.IsChecked = false;
            Fonctions.garageAccroche = true;
        }
        private void chkPosGarageDecro_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkPosGarageAccro.IsChecked = false;
            Fonctions.garageAccroche = false;
        }

        //Bouton de validation
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Autre actions avant de fermer la fenêtre
        }

        //Bouton du calcul du prix du garage (Calcul uniquement
        //en fonction de la superficie du garage et du type (Hors sol, semi enterré, enterré.)
        private void btnCalculPrixGarage_Click(object sender, RoutedEventArgs e)
        {
            //En cas de clic multiples sur le bouton, pour pas que les valeurs de type de garage (20, 30, 40)
            //s'additionnent et faussent le prix.
            Fonctions.prixGarage -= Fonctions.prixTypeGarage;
            Fonctions.prixTypeGarage = 0;
            Fonctions.prixGarage -= Fonctions.prixTypeGarage;

            #region POUR GARAGE HORS SOL
            if (chkTypeHorsSol.IsChecked == true)
            {
                //Si le garage est accolé
                if (chkPosGarageAccro.IsChecked == true)
                {
                    //Conditions imbriquées capacité garage
                    if (chkVoiture1.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                    else if (chkVoiture2.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) * 
                            Fonctions.valeurApproxGarageAccro;
                    }
                    else if (chkVoiturePlus.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }   
                }

                //Si le garage est séparé
                if (chkPosGarageDecro.IsChecked == true)
                {
                    //Conditions imbriquées capacité garage
                    if (chkVoiture1.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                    else if (chkVoiture2.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                    else if (chkVoiturePlus.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                }

                Fonctions.prixTypeGarage = 20;
                Fonctions.prixGarage += Fonctions.prixTypeGarage;

            }
            #endregion
            #region POUR GARAGE SEMI-ENTERRE
            else if (chkTypeSemiEnterre.IsChecked == true)
            {
                //Si le garage est accolé
                if (chkPosGarageAccro.IsChecked == true)
                {
                    //Conditions imbriquées capacité garage
                    if (chkVoiture1.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                    else if (chkVoiture2.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                    else if (chkVoiturePlus.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                }

                //Si le garage est séparé
                if (chkPosGarageDecro.IsChecked == true)
                {
                    //Conditions imbriquées capacité garage
                    if (chkVoiture1.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                    else if (chkVoiture2.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                    else if (chkVoiturePlus.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                }

                Fonctions.prixTypeGarage = 30;
                Fonctions.prixGarage += Fonctions.prixTypeGarage;

            }
            #endregion
            #region POUR GARAGE ENTERRE
            else if (chkTypeEnterre.IsChecked == true)
            {

                //Si le garage est accolé
                if (chkPosGarageAccro.IsChecked == true)
                {
                    //Conditions imbriquées capacité garage
                    if (chkVoiture1.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                    else if (chkVoiture2.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                    else if (chkVoiturePlus.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageAccro;
                    }
                }

                //Si le garage est séparé
                if (chkPosGarageDecro.IsChecked == true)
                {
                    //Conditions imbriquées capacité garage
                    if (chkVoiture1.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                    else if (chkVoiture2.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                    else if (chkVoiturePlus.IsChecked == true)
                    {
                        Fonctions.prixGarage = (Convert.ToDouble(cbxSuperficieGarage.SelectedValue)) *
                            Fonctions.valeurApproxGarageDecro;
                    }
                }

                Fonctions.prixTypeGarage = 40;
                Fonctions.prixGarage += Fonctions.prixTypeGarage;

            }
            #endregion  

            labelPrixGarage.Content = Fonctions.prixGarage.ToString();
        }

        //Lorsque l'on sélectionne un type 1 voiture
        private void chkVoiture1_Checked(object sender, RoutedEventArgs e)
        {
            //Ré-active la combobox de la superficie du garage.
            cbxSuperficieGarage.IsEnabled = true;
            btnValeurPersoSuperficieGarage.IsEnabled = true;
            chkVoiture2.IsChecked = false;
            chkVoiturePlus.IsChecked = false;
            //La remplie avec les superficies idéales pour un garage 1 véhicule
            cbxSuperficieGarage.Items.Clear();
            for (int i = 0; i < Fonctions.superficiesGarageUneVoiture.Length; i++)
            {
                cbxSuperficieGarage.Items.Add(Fonctions.superficiesGarageUneVoiture[i]);
            }
        }
        //Lorsque l'on sélectionne un type 2 voitures
        private void chkVoiture2_Checked(object sender, RoutedEventArgs e)
        {
            //Ré-active la combobox de la superficie du garage.
            cbxSuperficieGarage.IsEnabled = true;
            btnValeurPersoSuperficieGarage.IsEnabled = true;
            chkVoiture1.IsChecked = false;
            chkVoiturePlus.IsChecked = false;
            //La remplie avec les superficies idéales pour un garage 2 véhicules
            cbxSuperficieGarage.Items.Clear();
            for (int i = 0; i < Fonctions.superficiesGarageDeuxVoitures.Length; i++)
            {
                cbxSuperficieGarage.Items.Add(Fonctions.superficiesGarageDeuxVoitures[i]);
            }
        }
        //Lorsque l'on sélectionne un type +voitures
        private void chkVoiturePlus_Checked(object sender, RoutedEventArgs e)
        {
            //Ré-active la combobox de la superficie du garage.
            cbxSuperficieGarage.IsEnabled = true;
            btnValeurPersoSuperficieGarage.IsEnabled = true;
            chkVoiture1.IsChecked = false;
            chkVoiture2.IsChecked = false;
            //La remplie avec les superficies idéales pour un garage 2 véhicules
            cbxSuperficieGarage.Items.Clear();
            for (int i = 0; i < Fonctions.superficiesGaragePlusVoitures.Length; i++)
            {
                cbxSuperficieGarage.Items.Add(Fonctions.superficiesGaragePlusVoitures[i]);
            }
        }

        //Types garage
        private void chkTypeEnterre_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche les autres choix
            chkTypeSemiEnterre.IsChecked = false;
            chkTypeHorsSol.IsChecked = false;
        }
        private void chkTypeSemiEnterre_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche les autres choix
            chkTypeEnterre.IsChecked = false;
            chkTypeHorsSol.IsChecked = false;
        }
        private void chkTypeHorsSol_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche les autres choix
            chkTypeEnterre.IsChecked = false;
            chkTypeSemiEnterre.IsChecked = false;
        }

        //Quand on sélectionne un item dans la combobox de superficie du garage
        private void cbxSuperficieGarage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {}

        //Evènement du bouton "Valeur personnalisée."
        private void btnValeurPersoSuperficieGarage_Click(object sender, RoutedEventArgs e)
        {
            ValeursPersos vpSuperficieGarage = new ValeursPersos();
            vpSuperficieGarage.ShowDialog();
            Fonctions.superficieGarage = vpSuperficieGarage.ValeurRetournee();

            cbxSuperficieGarage.Items.Add(Fonctions.superficieGarage);
            cbxSuperficieGarage.SelectedIndex = cbxSuperficieGarage.Items.IndexOf(Fonctions.superficieGarage);
        }
    }
}
