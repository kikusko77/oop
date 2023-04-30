using PharmacyApp.EFCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for AddDbRecord.xaml
    /// </summary>
    public partial class AddDbRecord : Window
    {
        public AddDbRecord()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int id;
            string name;
            string brand;
            string manufacturer;
            decimal price;
            int quantity;
            try
            {
                id = int.Parse(Id.Text);
                name = Name.Text;
                brand = Brand.Text;
                manufacturer = Manufacturer.Text;
                price = decimal.Parse(Price.Text);
                quantity = int.Parse(Quantity.Text);
            }
            catch (System.FormatException)
            {
                Close();
                return;
            }

            DbUpdate(id, name, brand, manufacturer, price, quantity);
            Close();
        }

        public void DbUpdate(int id, string name, string brand, string manufacturer, decimal price, int quantity)
        {
            using (var context = new PharmacyDbContext((MainWindow)Application.Current.MainWindow))
            {
                context.addDrug(context, id, name, brand, manufacturer, price, quantity);
            }
        }
    

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

