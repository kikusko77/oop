using Microsoft.Win32;
using PharmacyApp.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDataGrid();

        }
        private void SearchBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string searchTerm = SearchBox.Text;

                using (var context = new PharmacyDbContext(this))
                {
                    var drugs = context.drugs.Where(d => d.Name.Contains(searchTerm)).ToList();
                    
                    DatabaseView.Items.Clear();

                    foreach (var drug in drugs)
                    {
                        DatabaseView.Items.Add(drug);
                    }
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDbRecord addDbRecord = new AddDbRecord();
            addDbRecord.ShowDialog();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (DataGridRow)sender;
            var record = (Drugs)row.DataContext;
            EditDbRecord editDbRecord = new EditDbRecord(record);
            editDbRecord.ShowDialog();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "c:\\";
                saveFileDialog1.Filter = "csv file (*.csv)|*.csv";
                saveFileDialog1.ShowDialog();
                string filePath = saveFileDialog1.FileName;
                using (var context = new PharmacyDbContext(this))
                {
                    context.ExportToCsv(context, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "csv file (*.csv)|*.csv";
                openFileDialog1.ShowDialog();
                string filePath = openFileDialog1.FileName; // Assign the value of openFileDialog1.FileName to filePath
                using (var context = new PharmacyDbContext(this))
                {
                    context.ImportFromCsv(context, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadDataGrid()
        {
            Drugs[] DrugDatabase;
            using (var context = new PharmacyDbContext((MainWindow)Application.Current.MainWindow))
            {
                DrugDatabase = context.getAllDrugs(context);
            }

            DatabaseView.Items.Clear();

            foreach (var drug in DrugDatabase)
            {
                DatabaseView.Items.Add(drug);
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = string.Empty;
            SearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "Search";
            SearchBox.Foreground = new SolidColorBrush(Colors.Gray);
        }
    }
}

