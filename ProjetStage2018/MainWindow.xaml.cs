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
using System.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetStage2018
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Lorsque l'on a choisit un budget
        private void cbxBudgetMaison_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Enregistre dans budgetClient (membre de Fonctions.cs) le budget sélectionné dans la combobox
            Fonctions.budgetClient = Convert.ToDouble(cbxBudgetMaison.SelectedValue);
            //Débloque le bouton "Valider"
            btnBudgetsClient.IsEnabled = true;
        }

        //Lorsque l'utilisateur clique sur le bouton "Valider" au niveau du choix du budget.
        private void btnBudgetsClient_Click(object sender, RoutedEventArgs e)
        {
            //Affichage de la prochaine fenêtre (choix des options pour la maison)
            ChoixOptions choixOptions = new ChoixOptions();
            //SystemSounds.Question.Play();
            choixOptions.ShowDialog();
        }

        //Premier démarrage du programme.
        public MainWindow()
        {
            InitializeComponent();

            //Ajout des budgets disponibles dans la comboBox des budgets
            for (int i = 0; i < Fonctions.budgetsDispo.Length; i++)
            {
                cbxBudgetMaison.Items.Add(Fonctions.budgetsDispo[i]);
            }
            //Différentes choses à initialiser..
        }

        //Bouton valeur personnalisée pour le budgetClient
        private void btnVPBudget_Click(object sender, RoutedEventArgs e)
        {
            ValeursPersos vpBudgetClient = new ValeursPersos();
            vpBudgetClient.ShowDialog();
            Fonctions.budgetClient = vpBudgetClient.ValeurRetournee();

            cbxBudgetMaison.Items.Add(Fonctions.budgetClient);
            cbxBudgetMaison.SelectedIndex = cbxBudgetMaison.Items.IndexOf(Fonctions.budgetClient);
        }
    }

}
