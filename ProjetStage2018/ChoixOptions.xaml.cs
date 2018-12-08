using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class ChoixOptions : Window
    {
        Brush colorBorder = new SolidColorBrush(Color.FromArgb(100, 216, 0, 0));
        //Lorsque la fenêtre s'ouvre. (Théoriquement après avoir cliqué sur le bouton Valider 
        //de la première fenêtre.
        public ChoixOptions()
        {
            InitializeComponent();

            //Recentre la fenêtre lors de l'affichage
            Fonctions.CenterWindowOnScreen(this);
            #region Remplissage des comboboxes
            //Remplie les combobox des options
            for (int i = 0; i < Fonctions.niveaux.Length; i++)
            {
                cbxNiveaux.Items.Add(Fonctions.niveaux[i]);
            }

            for (int i = 0; i < Fonctions.styles.Length; i++)
            {
                cbxStyle.Items.Add(Fonctions.styles[i]);
            }

            for (int i = 0; i < Fonctions.toitures.Length; i++)
            {
                cbxToiture.Items.Add(Fonctions.toitures[i]);
            }

            for (int i = 0; i < Fonctions.superficies.Length; i++)
            {
                cbxSuperficie.Items.Add(Fonctions.superficies[i]);
            }

            for (int i = 0; i < Fonctions.terrains.Length; i++)
            {
                cbxTerrain.Items.Add(Fonctions.terrains[i]);
            }

            for (int i = 0; i < Fonctions.chambres.Length; i++)
            {
                cbxChambres.Items.Add(Fonctions.chambres[i]);
            }
            #endregion

        }

        //Méthode crééant une référence de la classe ChoixOptions au champ "co" de type
        //ChoixOptions dans la classe FraisAnnexes.
        public void FraisAnnexesWindow(FraisAnnexes frais)
        {
            frais.co = this;
        }

        // ------------------------------------------------ //
        // ---------------- CHECKBOXES -------------------- //
        // ------------------------------------------------ //
        #region Checkboxes

        //Lorsque la case "Oui" pour le garage est cochée
        private void chkGarageOui_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkGarageNon.IsChecked = false;

            GarageOptions garageOptions = new GarageOptions();
            garageOptions.ShowDialog();

            Fonctions.possedeGarage = true;
        }
        //Lorsque la case "Non" pour le garage est cochée
        private void chkGarageNon_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkGarageOui.IsChecked = false;

            Fonctions.possedeGarage = false;
        }
        //Lorsque la case "Oui" pour la terrasse est cochée
        private void chkTerrasseOui_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkTerrasseNon.IsChecked = false;

            //Possède une terrasse
            Fonctions.possedeTerrasse = true;

            TerrasseOptions optionsTerrasse = new TerrasseOptions();
            optionsTerrasse.ShowDialog();
        }
        //Lorsque la case "Non" pour la terrasse est cochée
        private void chkTerrasseNon_Checked(object sender, RoutedEventArgs e)
        {
            //Décoche l'autre choix
            chkTerrasseOui.IsChecked = false;

            //Ne possède pas de terrasse
            Fonctions.possedeTerrasse = false;
        }

        #endregion

        // ------------------------------------------------ //
        // ---------------- COMBOBOXES -------------------- //
        // ------------------------------------------------ //
        #region Comboboxes

        //Après avoir choisi une superficie en m2 ..
        private void cbxSuperficie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fonctions.superficieMaison = Convert.ToDouble(cbxSuperficie.SelectedValue);
            Fonctions.prixSuperficieMaison = Fonctions.calculSuperficieMaison(Fonctions.superficieMaison);

        }
        //Après avoir sélectionner la toiture ..
        private void cbxToiture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Si l'on a choisi l'option "Toit-terrasse"
            if (cbxToiture.SelectedIndex == 0)
            {
                //Ouvre les options de la toiture
                ToitureOptions optionsToiture = new ToitureOptions();
                optionsToiture.ShowDialog();
            }
        }
        //Clic gauche sur la combobox des toitures
        private void cbxToiture_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Fonctions.superficieMaison == 0 || (chkTerrasseOui.IsChecked == false && chkTerrasseNon.IsChecked == false))
            {
                MessageBox.Show("Veuillez d'abord sélectionner une superficie de maison et \n" +
                     "faire un choix pour la terrasse.", "Erreur",
                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        //Lorsque l'on sélectionne une valeur dans la combobox des Terrains
        private void cbxTerrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbxTerrain.SelectedValue)
            {
                case "Plat":
                    Fonctions.terrainPlat = true;
                    //Instructions additionnelles pour éviter les mauvaises logiques d'exécution
                    Fonctions.terrainSemiPentu = false;
                    Fonctions.terrainPentu = false;
                    break;
                case "Semi-pentu":
                    Fonctions.terrainSemiPentu = true;
                    Fonctions.terrainPlat = false;
                    Fonctions.terrainPentu = false;
                    break;
                case "Pentu":
                    Fonctions.terrainPentu = true;
                    Fonctions.terrainPlat = false;
                    Fonctions.terrainSemiPentu = false;
                    break;
            }
        }

        #endregion

        // ------------------------------------------------ //
        // ------------------ BUTTONS --------------------- //
        // ------------------------------------------------ //
        #region Buttons

        //Lors du clic sur le bouton de calcul du prix
        private void btnPrixDynamique_Click(object sender, RoutedEventArgs e)
        {
            //Addition de tous les prix calculés plus tôt dans le programme.
            Fonctions.prixTotalDevis = 
                (
                 Fonctions.prixToitTerasse 
                +Fonctions.prixTerrasse 
                +Fonctions.prixSuperficieMaison 
                +Fonctions.prixGarage 
                +Fonctions.prixTauxEloignement
                +Fonctions.prixTotalFraisAnnexes
                );

            labelPrixDynamiqueValeur.Content = Fonctions.prixTotalDevis.ToString();

            if (Fonctions.budgetClient < Fonctions.prixTotalDevis)
            {
                borderPrixDynamique.Background = Brushes.Red; //Change le border color background en rouge
                MessageBox.Show("Votre budget est inférieur au prix calculé !" +
                    "\nBudget: " + Fonctions.budgetClient + "€" + 
                    "\nDifférence de " + (Fonctions.prixTotalDevis - Fonctions.budgetClient).ToString() + "€.",
                    "Budget trop faible", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

            borderPrixDynamique.Background = colorBorder;
        }
        //Autres actions pour le bouton de calcul du devis.
        private void btnPrixDynamique_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        //Evènement bouton "Retour"
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            options.Close();
        }
        //Clic sur le bouton paramètres
        private void btnParametres_Click(object sender, RoutedEventArgs e)
        {
            Settings param = new Settings();
            param.ShowDialog();
        }
        //Clic sur le bouton de recherches de projets
        private void btnRechercheModeles_Click(object sender, RoutedEventArgs e)
        {
            PlansModeles plansModeles = new PlansModeles();
            plansModeles.ShowDialog();
        }
        //Evenement du bouton "Valeur personnalisée".
        private void btnValeurPersoSuperficieMaison_Click(object sender, RoutedEventArgs e)
        {
            ValeursPersos vpSuperficieMaison = new ValeursPersos();
            vpSuperficieMaison.ShowDialog();
            Fonctions.superficieMaison = vpSuperficieMaison.ValeurRetournee();

            cbxSuperficie.Items.Add(Fonctions.superficieMaison);
            cbxSuperficie.SelectedIndex = cbxSuperficie.Items.IndexOf(Fonctions.superficieMaison);
        }
        //Bouton appliquer du taux d'éloignement
        private void btnAppliquerTauxEloignement_Click(object sender, RoutedEventArgs e)
        {
            //Si un prix a déjà été calculé
            if (Convert.ToDouble(labelPrixDynamiqueValeur.Content) != 0)
            {
                //Test de la valeur du taux
                if (Fonctions.tauxEloignement == 5)
                {
                    Fonctions.prixTauxEloignement = Fonctions.prixTotalDevis * (Fonctions.tauxEloignement / 100);
                }
                else if (Fonctions.tauxEloignement == 10)
                {
                    Fonctions.prixTauxEloignement = Fonctions.prixTotalDevis * (Fonctions.tauxEloignement / 100);
                }

                MessageBox.Show("Le taux a bien été calculé. Refaites à présent un calcul du \n" +
                "prix total pour s'y voir ajouter le taux.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                //Sinon:
            }
            else
            {
                MessageBox.Show("Veuillez d'abord faire des choix d'options \net calculer un prix!",
                    "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Evenement du bouton "Afficher valeurs"
        private void btnCalculPrixTaux_Click(object sender, RoutedEventArgs e)
        {
            if (Fonctions.prixTauxEloignement != 0)
            {
                MessageBox.Show("Prix du taux d'éloignement: " + Fonctions.prixTauxEloignement.ToString());
            }
            else
            {
                MessageBox.Show("Veuillez d'abord calculer un prix de taux", "Erreur", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }

        }
        //Ouvre la fenêtre des frais annexes
        private void btnFraisAnnexes_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(labelPrixDynamiqueValeur.Content) != 0)
            {
                FraisAnnexes fraisAnnexes = new FraisAnnexes();
                FraisAnnexesWindow(fraisAnnexes); //Appel de la méthode pour passer la référence à ChoixOptions.co;
                fraisAnnexes.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez d'abord calculer un prix total, avec au préalable \n" +
                    "un type de terrain choisi.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        //Bouton d'export sous une spreadsheet excel
        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                //Création des variables pointant les worksheets créées
                var construction = excel.Workbook.Worksheets.Add("Devis");
                var frais = excel.Workbook.Worksheets.Add("Frais_annexes");

                //Table de la feuille 
                var entetes = new List<string[]>
                {
                    //Première ligne [1, 1]
                    new string[] { "Option", "Valeur", "Coût" },
                    //Deuxième ligne [2, 1] etc...
                    new string[] { "Niveaux", cbxNiveaux.SelectedValue.ToString(), "" },
                    new string[] { "Style", cbxStyle.SelectedValue.ToString(), "" },
                    new string[] { "Terrain", cbxTerrain.SelectedValue.ToString(), "" },
                    new string[] { "Chambres", cbxChambres.SelectedValue.ToString(), "" },

                    new string[] { "Toiture", cbxToiture.SelectedValue.ToString(),
                                   (cbxToiture.SelectedValue.ToString() == "Toit-terrasse")
                                   ? Fonctions.prixToitTerasse.ToString() : "" },

                    new string[] { "Superficie", cbxSuperficie.SelectedValue.ToString(),
                                   Fonctions.prixSuperficieMaison.ToString() },

                    new string[] { "Terrasse", (chkTerrasseOui.IsChecked == true) ? "Oui" : "Non",
                                   (chkTerrasseOui.IsChecked == true)
                                   ? Fonctions.prixTerrasse.ToString() : "" },

                    new string[] { "Garage", (chkGarageOui.IsChecked == true) ? "Oui" : "Non",
                                   (chkGarageOui.IsChecked == true)
                                   ? Fonctions.prixGarage.ToString() : "" }
                };

                //Affiche la grille entetes à partir de 1, 1
                construction.Cells[1, 1].LoadFromArrays(entetes);
                //Change le style des entêtes
                construction.Cells["A1:C1"].Style.Font.Bold = true;
                construction.Cells["A1:C1"].Style.Font.Size = 14;
                construction.Cells["A1:C1"].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                //Yellow background pour les entêtes
                construction.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                construction.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                //Borders pour toutes les cellules
                construction.Cells["A1:C15"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                construction.Cells["A1:C15"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                construction.Cells["A1:C15"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                construction.Cells["A1:C15"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                //Auto-adjusts les tailles des colonnes (des cellules quoi)
                construction.Cells.AutoFitColumns();

                //Overwrite / enregistre / créer le fichier .xlsx à l'url spécifiée
                FileInfo file = new FileInfo(@"C:\Users\Théo\Desktop\test.xlsx");

                excel.SaveAs(file);
                System.Diagnostics.Process.Start(@"C:\Users\Théo\Desktop\test.xlsx");
            }
        }

        #endregion

        // ------------------------------------------------ //
        // ------------------ OTHERS ---------------------- //
        // ------------------------------------------------ //

        //Quand on ajuste le slider (la marge d'éloignement)
        private void sliderEloignement_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //If imbriqués qui ajustent en temps réel le taux par rapport à la distance
            if (sliderEloignement.Value >= 0 && sliderEloignement.Value <= 25) {
                txtTauxEloignement.Text = "0";
                Fonctions.tauxEloignement = Convert.ToDouble(txtTauxEloignement.Text);
            }
            else if (sliderEloignement.Value > 25 && sliderEloignement.Value <= 50) {
                txtTauxEloignement.Text = "5";
                Fonctions.tauxEloignement = Convert.ToDouble(txtTauxEloignement.Text);
            }
            else if (sliderEloignement.Value > 50) {
                txtTauxEloignement.Text = "10";
                Fonctions.tauxEloignement = Convert.ToDouble(txtTauxEloignement.Text);
            }
        }
        

        
    }
}
