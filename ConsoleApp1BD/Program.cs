using Microsoft.Data.SqlClient;

namespace ConsoleApp1BD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            SqlConnection conexao;

            conexao = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyUniversidadeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            conexao.Open();
            Console.WriteLine("Conexão OK");

            Console.WriteLine("== Salvando dados no BD ==");
            
            var insertCmd = conexao.CreateCommand();
            insertCmd.CommandText = "INSERT INTO Cursos (Nome, Periodo, Categoria) VALUES (@nome, @per, @cat)";

            //var paramNome = new SqlParameter("nome", "POO2");
            //insertCmd.Parameters.Add(paramNome);

            //var paramPeriodo = new SqlParameter("per", 20);
            //insertCmd.Parameters.Add(paramPeriodo);

            insertCmd.Parameters.Add(new SqlParameter("nome", "POO3"));

            insertCmd.Parameters.Add(new SqlParameter("per", 30));

            insertCmd.Parameters.Add(new SqlParameter("cat", "Maneiro3"));

            insertCmd.ExecuteNonQuery();

            conexao.Close();
            



        }
    }
}
