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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            addEditWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

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
    }
}

