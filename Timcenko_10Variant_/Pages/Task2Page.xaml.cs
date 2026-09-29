using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Timcenko_10Variant.Pages
{
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите предложение!");
                return;
            }

            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '—', '\t', '\n' };
            string[] words = txtInput.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                txtResult.Text = "Слова не найдены";
                return;
            }

            string longest = words.OrderByDescending(w => w.Length).First();
            txtResult.Text = longest;
        }
    }
}