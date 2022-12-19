using Common;

namespace SandwichProcessor
{
    public class ZlecenieKanapka : IZlecenie
    {
        public string Tytul {  get; set; }

        public void Process()
        {
            Console.WriteLine(Tytul);

            Console.WriteLine("Krojenie chleba.");
            Thread.Sleep(1000);
            Console.WriteLine("Smarowanie masłem.");
            Thread.Sleep(1000);
            Console.WriteLine("Wyciągniecie plasterka salami.");
            Thread.Sleep(1000);
            Console.WriteLine("Połozenie salami na kromce.");
            Thread.Sleep(1000);
            Console.WriteLine("Zapakowanie kanapki.");
            Thread.Sleep(1000);
        }
    }
}