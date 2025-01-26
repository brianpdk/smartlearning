using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int kortnummer = Convert.ToInt32(Kort.Text);
            string filnavn = FindBillede(kortnummer);
            string url = $"/Billeder/{filnavn}";
            Uri uri = new (url, UriKind.Relative);
            BitmapImage image = new(uri);
           
            Billede.Source = image;
            
        }

        private string FindBillede(int kortnummer)
        {
            //string resultat = "2-Spar.jpg";
            //string resultat = $"{kortnummer}-Spar.jpg";
            // Skriv din løsning her...
            string resultat = "";
            if (kortnummer == 1)
            {
                resultat = $"{kortnummer}-Hjerter.jpg";
            }else if (kortnummer >= 2 && kortnummer <= 10)
            {
                resultat = $"{kortnummer}-Spar.jpg";
            }else if (kortnummer == 11)
            {
                resultat = $"{kortnummer}-Ruder.jpg";
            }

            return resultat;
        }
    }
}
