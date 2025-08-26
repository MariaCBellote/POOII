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

namespace RedeAmigos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Amigo> migs = new List<Amigo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void apelido_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cadastro_Click(object sender, RoutedEventArgs e)
        {
            Amigo a = new Amigo();
            if (apelido.Text != null && email.Text != null && telefone.Text != null)
            {
                a.Apelido = apelido.Text;
                a.Email = email.Text;
                a.Numero = telefone.Text;
                migs.Add(a);
            }
        }

        private void busca_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            
            if (apelido.Text != null && email.Text != null && telefone.Text != null)
            {
                
                
            }
        }
    }
}