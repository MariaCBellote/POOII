namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ProfHorista prof1 = new ProfHorista("Carlos", 12345, 20, 250.0);

            
            ProfDE prof2 = new ProfDE("Ana", 54321, 40);
            Console.WriteLine(prof1.GetBeneficio());
            Console.WriteLine(prof2.GetBeneficio());
        }
    }
}
