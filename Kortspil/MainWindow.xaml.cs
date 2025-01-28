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

        if (kortnummer < 1 || kortnummer > 52)
        {
            Console.WriteLine("Kortnummer skal være mellem 1 og 52.");
            kortnummer = 1;
        }

        string[] farver = { "Spar", "Ruder", "Klør", "Hjerter" };
        string[] nummer = { "Es", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Knægt", "Dame", "Konge" };

        // Opretter farveindex (0 = spar, 1 = ruder, 2 = klør, 3 = hjerter)
        int farveindex = (kortnummer - 1) / 13;
        string farve = farver[farveindex];

        // Opretter rangindex ved brug af modulus operator
        int rangIndex = (kortnummer - 1) % 13;
        string rang = nummer[rangIndex];

        // Construct the filename
        return $"{rang}-{farve}.jpg";
         
         }
    }
}
