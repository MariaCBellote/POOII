using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConversorTemp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string temperatura="";
        public MainWindow()
        {
            InitializeComponent();
        }


        private void tempC_TextChanged(object sender, TextChangedEventArgs e)
        {
            temperatura = tempC.Text;
        }
        private void convert_Click(object sender, RoutedEventArgs e)
        {
            double f;
            if (double.TryParse(temperatura, out f))
            {
                f = f * 1.8 + 32;
                texteTempConvertida.Text= f.ToString("F1") + " Fahrenheit";
            }
            else
            {
                texteTempConvertida.Text = "Valor inválido";
            }
        }

       
    }
}