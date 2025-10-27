using Microsoft.Data.SqlClient;
using System;
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

namespace DadosDeEmpregados
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection? conexao = null;
        public MainWindow()
        {
            InitializeComponent();
            String URL= "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DBDadosEmpregados; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";

            try
            {
                conexao = new SqlConnection(URL);
                conexao.Open();
                status.Content = "Conexão OK";
            }
            catch (Exception ex) 
            {
                status.Content = "Conexão NÃO OK";
                Console.WriteLine(ex.Message);
            
            
            }
        
        }

        private void pesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            Empregado emp = new() {
                CPF = cpf.Text,
                Nome = nome.Text,
                Endereco = endereco.Text

            };

            if(conexao !=null && VerificarCampos())
            {
            emp.salvar(conexao);
            status.Content= "Salvo OK";
            LimparCampos();
            }
            else
            {
            status.Content= "Não Salvo";
            }

        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void limpar_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

