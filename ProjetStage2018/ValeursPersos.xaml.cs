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
    /// Logique d'interaction pour ValeursPersos.xaml
    /// </summary>
    public partial class ValeursPersos : Window
    { 
        public double valeurInput = 0;
        public bool canAccept = false;

        //Constructeur
        public ValeursPersos() 
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);
        }

        //Retourne simplement la valeur entrée dans la textbox
        public double ValeurRetournee()
        {
            return valeurInput;
        }

        //Lorsque l'on saisie du texte dans la textbox
        private void txtValeur_TextChanged(object sender, TextChangedEventArgs e)
        {
                if (txtValeur.Text.IsNumeric()) {
                    canAccept = true;
                }
                else {
                canAccept = false;
                }

        }

        //Quand on clique sur le bouton "Valider"
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (canAccept == true) {
                valeurInput = Convert.ToDouble(txtValeur.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nombre.", "Erreur", MessageBoxButton.OK,
                     MessageBoxImage.Exclamation);
            }

            

        }
    }
}
