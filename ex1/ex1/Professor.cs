using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal abstract class Professor
    {
        public String Nome {  get; set; }
        public int Matricula {  get; set; }
        public int CargaHoraria { get; set; }
        public double Beneficio { get; set; }

        public Professor (string nome, int matricula, int cargaHoraria )
        {
            Nome = nome;
            Matricula = matricula;
            CargaHoraria = cargaHoraria;
           
        }

        public abstract void calcularBeneficio();
        public double GetBeneficio()
        {
            return Beneficio;
            
        }

        

        
    }
}
