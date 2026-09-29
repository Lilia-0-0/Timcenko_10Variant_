using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Timcenko_10Variant.Pages
{
    public partial class Task3Page : Page
    {
        public Task3Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtSize.Text, out int n) || n < 10)
            {
                MessageBox.Show("Введите N (не меньше 10)!");
                return;
            }

            var parts = txtArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != n)
            {
                MessageBox.Show($"Нужно ввести ровно {n} чисел!");
                return;
            }

            int[] a;
            try { a = parts.Select(int.Parse).ToArray(); }
            catch { MessageBox.Show("Все элементы должны быть целыми!"); return; }

            int first = a[0];
            int tenth = a[9];
            int result = 0;

            for (int i = 1; i < n; i++)
            {
                if (a[i] > first && a[i] < tenth)
                {
                    result = i + 1;
                    break;
                }
            }

            txtResult.Text = result.ToString();
        }
    }
}