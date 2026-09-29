using System.Windows;
using System.Windows.Controls;

namespace Timcenko_10Variant.Pages
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void btnTask1_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Task1Page());
        private void btnTask2_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Task2Page());
        private void btnTask3_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Task3Page());
        private void btnTask4_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Task4Page());
        private void btnTask5_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Task5Page());
    }
}