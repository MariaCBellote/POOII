using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosDeEmpregados
{
    internal class Empregado
    {
        public int Matricula {  get; set; }
        public String? Nome { get; set; }
        public String? CPF { get; set; }
        public String? Endereco { get; set; }    

        public Empregado() { }

        public Empregado( string nome, string cPF, string endereco)
        {
            
            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return $"Empregado-> Matrícula: {Matricula} | Nome: {Nome} | CPF: {CPF} | Endereço: {Endereco}.";
            
        }

        public void salvar(SqlConnection conex) {
            Console.WriteLine("==Salvando Empregado==");
            if (Matricula == 0) {
                var cmd= conex.CreateCommand();
                cmd.CommandText = "INSERT INTO Empregado (Nome,CPF,Endereco) VAUES (@nome, @cpf, @endereco)";

                cmd.Parameters.Add(new SqlParameter("nome", Nome));
                cmd.Parameters.Add(new SqlParameter("cpf", CPF));
                cmd.Parameters.Add(new SqlParameter("endereco", Endereco));

                cmd.ExecuteNonQuery();
            }
        }
        public void pesquisar() { }
        public void excluir() { }
        public void alterar() { }
    }
}
