using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    internal class Aviao:Transporte
    {
        public String Modelo {  get; set; }
        public void voar(string origem,string destino, int passageiros)
        {
            Console.WriteLine("Voando para: "+ destino);
            Console.WriteLine("Saindo de: "+ origem);
            Console.WriteLine("Passageiros: "+ passageiros);
        }

    }
}
