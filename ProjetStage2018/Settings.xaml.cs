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
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Fonctions.CenterWindowOnScreen(this);
        }

        //Quitte la fenêtre.
        private void btnRetourSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Lorsque l'on change la valeur de la marge
        private void sliderMarge_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Ajuster tous les prix, mais par quoi commencer. .. xD 
        }
    }
}
