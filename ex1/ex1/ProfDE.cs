using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal class ProfDE: Professor
    {

        public ProfDE(string nome, int matricula, int cargaHoraria)
            : base(nome, matricula, cargaHoraria)
        {
            calcularBeneficio();
        }
        public override void calcularBeneficio()
        {
            Beneficio = 3500.0;
        }
    }
}
