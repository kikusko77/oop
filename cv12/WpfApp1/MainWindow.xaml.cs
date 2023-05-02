using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebApi;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient _client;
        public MainWindow()
        {
            InitializeComponent();



            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7092/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }   

        public async void Button_click(object sender,RoutedEventArgs e)
        {
                CalcDTO calcDTO = new CalcDTO();
                calcDTO.Operand1 = Convert.ToDecimal(operand1TextBox.Text);
                calcDTO.Operand2 = Convert.ToDecimal(operand2TextBox.Text);
            calcDTO.Operation = ((ComboBoxItem)operaceComboBox.SelectedValue).Tag.ToString();
                HttpResponseMessage response = await _client.PostAsJsonAsync($"api/calc", calcDTO);
                response.EnsureSuccessStatusCode();
            string returnValue = await response.Content.ReadAsStringAsync();
                vysledok.Content = returnValue;
            
        }

        private void minus_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
