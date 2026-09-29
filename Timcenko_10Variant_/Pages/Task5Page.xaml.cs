using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Timcenko_10Variant.Pages
{
    public partial class Task5Page : Page
    {
        private int[,] matrix;
        private int rows, cols;

        public Task5Page()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtRows.Text, out rows) || rows < 1 ||
                !int.TryParse(txtCols.Text, out cols) || cols < 1)
            {
                MessageBox.Show("Введите корректные M и N!");
                return;
            }

            var rnd = new Random();
            matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rnd.Next(-10, 11);

            dgOriginal.ItemsSource = ToDataTable(matrix).DefaultView;
            dgAsc.ItemsSource = null;
            dgDesc.ItemsSource = null;
            txtInfo.Text = "";
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Сначала сгенерируйте массив!");
                return;
            }

            var flat = matrix.Cast<int>().ToList();
            var asc = flat.OrderBy(x => x).ToList();
            var desc = flat.OrderByDescending(x => x).ToList();

            dgAsc.ItemsSource = ToDataTable(ToList2D(asc, rows, cols)).DefaultView;
            dgDesc.ItemsSource = ToDataTable(ToList2D(desc, rows, cols)).DefaultView;

            txtInfo.Text = $"Максимум: {flat.Max()}, Минимум: {flat.Min()}";
        }

        private int[,] ToList2D(List<int> list, int r, int c)
        {
            var res = new int[r, c];
            int k = 0;
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    res[i, j] = list[k++];
            return res;
        }

        private DataTable ToDataTable(int[,] arr)
        {
            var dt = new DataTable();
            int r = arr.GetLength(0), c = arr.GetLength(1);

            for (int j = 0; j < c; j++)
                dt.Columns.Add($"Col{j + 1}", typeof(int));

            for (int i = 0; i < r; i++)
            {
                var row = dt.NewRow();
                for (int j = 0; j < c; j++)
                    row[j] = arr[i, j];
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}