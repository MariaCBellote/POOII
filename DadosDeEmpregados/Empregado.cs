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
        public List<Empregado>? pesquisar(int matriculaParametro, SqlConnection conexao) { 

            Console.WriteLine("==Recuperando Empregado==");
            List<Empregado>? EmpregadoLido=null;
            var cmd= conexao.CreateCommand();

            if(matriculaParametro == 0){
                cmd.CommandText="SELECT * FROM Empregado";
            }
            else{
                cmd.CommandText="SELECT * FROM Empregado WHERE Matricula= @matriculaBusca";
                cmd.Parameters.Add(new SqlParameter("matriculaBusca", matriculaParametro));
            }
            var resultado=cmd.ExecuteReader();

            if(resultado!=null){
                EmpregadosLido=new();

                while(resultado.Read()){
                    Empregado EmpregadoLido=new();
                    {
                        Matricula=resultado.GetInt32("Matricula"),
                        CPF=resultado.GetString("CPF"),
                        Nome=resultado.GetString("Nome"),
                        Endereco=resultado.GetString("Endereco")
                        };
                EmpregadosLido.Add(EmpregadoLido);
                  }
                 resultado.Close();
            }
        return EmpregadosLido;
        
        }
        public void excluir() { }
        public void alterar() { }
    }
}

