using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Timcenko_10Variant.Pages
{
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            if (!long.TryParse(txtInput.Text, out long number))
            {
                MessageBox.Show("Введите корректное целое число!");
                return;
            }

            string numberStr = Math.Abs(number).ToString();
            Dictionary<char, int> digitCount = new Dictionary<char, int>();

            foreach (char digit in numberStr)
            {
                if (digitCount.ContainsKey(digit)) digitCount[digit]++;
                else digitCount[digit] = 1;
            }

            var repeated = digitCount.Where(kv => kv.Value > 1)
                                     .Select(kv => kv.Key)
                                     .OrderBy(c => c)
                                     .ToList();

            txtResult.Text = repeated.Count == 0
                ? "Нет повторяющихся цифр"
                : string.Join(", ", repeated);
        }
    }
}