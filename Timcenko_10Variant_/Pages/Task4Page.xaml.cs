using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Timcenko_10Variant.Pages
{
    public partial class Task4Page : Page
    {
        public Task4Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtSize.Text, out int n) || n < 1)
            {
                MessageBox.Show("Введите корректный размер N!");
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

            txtOriginal.Text = string.Join(" ", a);

            int primeIdx = -1, perfectIdx = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (primeIdx == -1 && IsPrime(a[i])) primeIdx = i;
                if (perfectIdx == -1 && IsPerfect(a[i])) perfectIdx = i;
            }

            if (primeIdx == -1 || perfectIdx == -1)
            {
                txtResult.Text = "В массиве нет простого и/или совершенного числа";
                return;
            }

            (a[primeIdx], a[perfectIdx]) = (a[perfectIdx], a[primeIdx]);
            txtResult.Text = string.Join(" ", a);
        }

        private bool IsPrime(int x)
        {
            if (x < 2) return false;
            for (int d = 2; d * d <= x; d++)
                if (x % d == 0) return false;
            return true;
        }

        private bool IsPerfect(int x)
        {
            if (x < 2) return false;
            int sum = 0;
            for (int d = 1; d <= x / 2; d++)
                if (x % d == 0) sum += d;
            return sum == x;
        }
    }
}