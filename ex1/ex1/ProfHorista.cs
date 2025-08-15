using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal class ProfHorista: Professor
    {
        public double ValorHora { get; set; }

        public ProfHorista(String nome, int matricula, int cargaHoraria, double valorHora)
            : base(nome, matricula, cargaHoraria) {
            ValorHora = valorHora;
            calcularBeneficio();
            GetBeneficio();
        }
        public override void calcularBeneficio()
        {
            Beneficio = ValorHora * CargaHoraria;
        }
    }
}
