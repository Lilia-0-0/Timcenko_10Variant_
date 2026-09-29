using System.Windows;

namespace Timcenko_10Variant
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new Pages.MenuPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrmMain.CanGoBack)
                FrmMain.GoBack();
        }
    }
}