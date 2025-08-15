namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aviao aviao = new Aviao();
            Helicoptero helicoptero = new Helicoptero();
            Gripho gripho = new Gripho();
            Aeroporto aeroporto = new Aeroporto("A");
            aeroporto.aceitar(aviao);
            aeroporto.aceitar(gripho);
            
        }
    }
}
