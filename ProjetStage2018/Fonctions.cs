using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetStage2018
{
    static class Fonctions
    {
        //Prix total du devis (calculé à la toute fin théoriquement)
        public static double prixTotalDevis;
        public static double prixTauxEloignement; //Le prix du taux d'éloignement (prixTotalDevis*(tauxEloignement/100))
        public static double tauxEloignement; //Le taux d'éloignement en %

        //Contient le budget du client (défini à la première fenêtre)
        public static double budgetClient;
        public static double[] budgetsDispo = new double[] { 100000, 200000, 300000, 400000, 500000 };

        //Superficie, prix de la maison, etc...
        public static double superficieMaison;
        public static double prixSuperficieMaison; //Inclus dans prixTotalDevis

        //Listes d'éléments des valeurs d'options
        //Ajouter les options "pas de préférence" et "valeur personnalisée" 
        public static String[] niveaux = new String[] { "Demi sous-sol", "Sous-sol complet", "Plain-pied", "Etage",
        "Sans préférence" };
        public static String[] styles = new String[] { "En L", "Rectangulaire", "Angle cassé", "En 'T'",
        "Sans préférence" };
        public static String[] toitures = new String[] { "Toit-terrasse", "2 pentes", "4 pentes", "Plat",
        "Sans préférence" };
        public static double[] superficies = new double[] { 50, 70, 90, 110, 130 }; // (m²)
        public static String[] terrains = new String[] { "Plat", "Semi-pentu", "Pentu" };
        public static Int32[] chambres = new Int32[] { 1, 2, 3, 4, 5, 6 };

        //Tout ce qui concerne les frais annexes
        public static double prixTotalFraisAnnexes; //Contient le prix total calculé des frais annexes
        public static double prixTerrassement; //~2000€ pour léger, ~3500€ pour modéré, ~4500€ pour lourd
        public static double prixAssainissement; //Fosse septique: ~5000€, Tout-à-l'égout: ~1000€
        public static double prixRaccordementEau; //Prix connu fixe ~1000€ pour 30ML
        public static double prixRaccordementEdf; //Prix connu fixe ~1900€ pour 30ML
        public static double prixAssuranceDO; //1.48% du prix total de la construction

        //Superficie, prix de la terrasse, etc...
        public static bool terrasseCouverte = false;
        public static double superficieTerrasse;
        public static double prixTerrasse; //Inclus dans prixTotalDevis
        public static double[] superficiesTerrasse = new double[] { 20, 30, 40 };
        public static double prixToitTerasse; //Inclus dans prixTotalDevis

        //Superficie, prix du garage, etc...
        public static double superficieGarage; //Compte aussi la superficie de la toiture de celui-ci
        public static double[] superficiesGarageUneVoiture = new double[] { 15, 25 }; // (m²)
        public static double[] superficiesGarageDeuxVoitures = new double[] { 30, 40 }; // (m²) 
        public static double[] superficiesGaragePlusVoitures = new double[] { 45, 55 }; // (m²)
        public static double prixGarage; //Inclus dans prixTotalDevis
        public static bool garageAccroche = false;
        public static double prixTypeGarage = 0; //Contient 20, 30, 40 pour horsSol, SemiEnterre, Enterre
        //prixTypeGarage initialisé à 0 pour pas avoir d'erreur de logique d'exécution.
        public static double valeurApproxGarageAccro = 800;
        public static double valeurApproxGarageDecro = 900;

        //Possède une terrasse / un garage
        public static bool possedeTerrasse = false;
        public static bool possedeGarage = false;

        //Tout ce qui concerne le terrain
        public static bool terrainPlat = false;
        public static bool terrainSemiPentu = false;
        public static bool terrainPentu = false;

        //Méthode permettant le centrage à l'écran d'une fenêtre (générique écrans)
        public static void CenterWindowOnScreen(Window window)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        //Méthode permettant le calcul du prix de la superficie de la maison
        //A remplacer par un calcul local ? 
        public static double calculSuperficieMaison(double sper)
        {
            double superficieMaisonValeur = 0;
            superficieMaisonValeur = 1625 * sper;
            return superficieMaisonValeur;
        }

        //Méthode permettant de vérifier si la chaîne entrée en paramètres
        //est un nombre/est composée de chiffres
        public static bool IsNumeric(this string s)
        {
            foreach (char c in s) {
                if (!char.IsDigit(c) && c != '.') {
                    return false;
                }
            }
            return true;
        }
    }
}
