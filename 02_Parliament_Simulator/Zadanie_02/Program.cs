namespace Zadanie_02
{
    public class Zadanie_02
    {
        private static void ConductVoting(int noParliamentarians, string topic)
        {
            Parliament parliament = new Parliament(noParliamentarians);
            parliament.ConductVoting(topic);

            printResult(parliament.GetVotingResult());
        }

        public static void printResult((string, int, int) result)
        {
            Console.WriteLine($"\nGłosowanie nad {result.Item1}:\n  Głosów za: {result.Item2}\n  Głosów przeciw: {result.Item3}");
        }

        static void Main(String[] args)
        {
            int noParliamentarians = 0;

            Console.Write("Podaj liczbę parlamentarzystów: ");
            Int32.TryParse(Console.ReadLine(), out noParliamentarians);

            Console.Write("Podaj temat głosowania: ");
            string topic = Console.ReadLine();

            ConductVoting(noParliamentarians, topic);
        }
    }
}
