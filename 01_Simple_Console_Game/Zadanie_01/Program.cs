using System;
public class Zadanie_01
{
    static void Main(string[] args)
    {
        Game game = Game.GetInstance();

        Console.WriteLine("Witaj w grze Zadanie_01!");

        do
        {
            Console.Write("[1] Zacznij nową grę\n" +
                          "[X] Zamknij program\n");
            string input = Console.ReadLine();

            if (input.Length == 1)
            {
                if (input.Equals("1"))
                {
                    game.StartNewGame();
                    break;
                }
                else if (input.Equals("X", StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(0);
                }
            }

            Console.Clear();
            Console.WriteLine("Wybrana opcja jest niepoprawna. Spróbuj jeszcze raz.");
        } while (true);
    }
}


