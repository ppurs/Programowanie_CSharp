using System.Collections.Generic;

namespace Zadanie_04
{
    class Program
    {

        //zadanie 1
        static void createCollection( int N )
        {
            var collection = Enumerable.Range(1, N)
                        .Where( x => ( (x != 9) && (x != 5) && ( x % 2 == 1 || x % 7 == 0)))
                        .Select(x => x * x);

            Console.WriteLine($"\nSuma elementow: {collection.Sum()}");
            Console.WriteLine($"Liczba elementow: {collection.Count()}");
            Console.WriteLine($"Pierwszy element kolekcji: {collection.First()}");
            Console.WriteLine($"Ostatni element kolekcji: {collection.Last()}");

            if (collection.Count() >= 3)
            {
                Console.WriteLine($"Trzeci element kolekcji: {collection.ElementAt(2)}");
            }
        }

        //zadanie 2
        static void SumOfElementsRandomMatrix(int N, int M)
        {
            Random random = new Random();

            List<List<int>> listOfLists = Enumerable.Range(0, N)
                        .Select(y => Enumerable.Range(1, M)
                                                .Select(x => random.Next(0, 1000))
                                                .ToList())
            .ToList();

            Console.WriteLine("\nMacierz: ");
            int sumOfElements = listOfLists.SelectMany( list => { Console.WriteLine( "\t" + string.Join("  ", list)); 
                                                                    return list; 
                                                                }).Sum();

            Console.WriteLine($"Suma elementów: {sumOfElements}");
        }

        //Zadanie 3
        static void GroupCitiesByFirstNameLetter()
        {
            var input = new List<string>();

            string city = Console.ReadLine();
            while (!city.Equals("X"))
            {
                input.Add(city);
                city = Console.ReadLine();
            }

            var cities = input.GroupBy(x => x.ToUpper().First())
                                .ToDictionary(x => x.Key, x => x.Distinct().OrderBy(x => x.ToUpper()).ToList());

            char letter = char.Parse(Console.ReadLine().ToUpper());
            while (letter != 'X')
            {
                if (cities.ContainsKey(letter))
                {
                    Console.WriteLine( string.Join(", ", cities[letter]));
                }
                else
                {
                    Console.WriteLine("PUSTE");
                }

                letter = char.Parse(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            int N, M;

            /*Console.WriteLine("------------------------ ZADANIE 1 ---------------------------");

            Console.Write("Podaj N: ");
            N = Int32.Parse(Console.ReadLine());

            createCollection(N);*/

            Console.WriteLine("------------------------ ZADANIE 2 ---------------------------");

            Console.Write("Podaj N: ");
            N = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj M: ");
            M = Int32.Parse(Console.ReadLine());

            SumOfElementsRandomMatrix(N, M);

            Console.WriteLine("------------------------ ZADANIE 3 ---------------------------");

            GroupCitiesByFirstNameLetter();
        }
    }
}
