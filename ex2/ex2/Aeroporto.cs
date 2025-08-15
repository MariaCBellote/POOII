using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    internal class Aeroporto
    {
       
        Transporte Transp { get; set; }
       

        public bool aceitar(Transporte voando, string o, string d, int p)
        {
            if(Transp != null) {
                Console.WriteLine("Aeroporto ocupado");
                return false;
        }
            Transp = voando;
            Transp.voar(o, d, p);
            return true;
    }
        public void limpar()
        {
            Transp = null;
        }
}
