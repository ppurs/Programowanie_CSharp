using Common;
using Microsoft.VisualBasic;

/*
 * W przypadku BeerProcessor metoda process ma wyświetlić tytuł zlecenia oraz w
odstępach co 2 sekundy etapy wytwarzania West coast IPA. Przepis przykąłdowy:
https://wkpd.waw.pl/receptury-west-coast-india-pale-ale/

 */

namespace BeerProcessor
{
    public class ZleceniePiwo : IZlecenie
    {
        public string Tytul { get; set; }

        public void Process()
        {
            Console.WriteLine(Tytul);
            Console.WriteLine("Zacieranie.");
            Thread.Sleep(2000);
            Console.WriteLine("Filtracja zacieru.");
            Thread.Sleep(2000);
            Console.WriteLine("Wysładzanie.");
            Thread.Sleep(2000);
            Console.WriteLine("Chmielenie.");
            Thread.Sleep(2000);
            Console.WriteLine("Fermentacja.");
            Thread.Sleep(2000);
            Console.WriteLine("Chmielenie na zimno.");
            Thread.Sleep(2000);
            Console.WriteLine("Butelkowanie.");
            Thread.Sleep(2000);
            Console.WriteLine("Refrmentacja, leżakowanie.");
            Thread.Sleep(2000);

        }

    }
}