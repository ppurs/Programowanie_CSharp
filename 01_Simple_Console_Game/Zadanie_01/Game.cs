class Game
{
    private static Game instance;
    private Hero? hero;
    private Location location;

    private Game()
    {
        this.hero = null;
        location = PrepareLocation();
    }

    public static Game GetInstance()
    {
        if( instance is null )
        {
            instance = new Game();
        }

        return instance;
    }
    
    public void StartNewGame()
    {
        SelectHeroName();
        SelectHeroType();

        Console.Clear();
        Console.WriteLine($"{hero.HeroType} {hero.Name} wyrusza na przygodę!\n");

        this.ShowLocation();
    }

    private static bool NameInputValidation(string name)
    {
        bool isValid = true;

        if (name.Length < 2)
        {
            Console.Clear();
            Console.WriteLine("Nazwa powinna zawierać co najmniej 2 znaki.");
            isValid = false;
        }

        if (!name.All(Char.IsLetter))
        {
            if (isValid)
            {
                Console.Clear();
            }
            Console.WriteLine("Nazwa powinna składac się wyłącznie z liter.");
            isValid = false;
        }

        if (!isValid)
        {
            Console.WriteLine("Spróbuj jeszcze raz.\n");
        }

        return isValid;
    }

    private static int OptionInputValidation(string choice, int optionsSize )
    {
        bool isValid = true;
        int option = 0;

        if (!Int32.TryParse(choice, out option))
        {
            isValid = false;
        }
        else
        {
            isValid = (option > 0 && option <= optionsSize);
        }

        if (!isValid)
        {
            Console.Clear();
            Console.WriteLine("Wybrana opcja nie istnieje. Spróbuj jeszcze raz.\n" );
            option = 0;
        }

        return option - 1;
    }

    private Location PrepareLocation()
    {
        HeroDialogPart tempHeroPart;
        NpcDialogPart tempNpcPart;


        NpcDialogPart aragogFirstPart = new NpcDialogPart("Witaj #HERONAME#, czy możesz mi pomóc dostać się do innego miasta?");
        aragogFirstPart.heroParts = new List<HeroDialogPart> 
        {
            new HeroDialogPart("Tak, chętnie pomogę!"),
            new HeroDialogPart("Nie, nie pomogę, żegnaj.")
        };

        tempHeroPart = aragogFirstPart.heroParts[0];
        tempHeroPart.NpcPart = new NpcDialogPart("Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota.");

        tempNpcPart = tempHeroPart.NpcPart;
        tempNpcPart.heroParts = new List<HeroDialogPart>
        {
            new HeroDialogPart("Dam znać jak będę gotowy."),
            new HeroDialogPart("100 sztuk złota to za mało!")
        };

        tempHeroPart = tempNpcPart.heroParts[1];
        tempHeroPart.NpcPart = new NpcDialogPart("Niestety nie mam więcej. Jestem bardzo biedny.");

        tempNpcPart = tempHeroPart.NpcPart;
        tempNpcPart.heroParts = new List<HeroDialogPart>
        {
            new HeroDialogPart("OK, może być 100 sztuk złota."),
            new HeroDialogPart("W takim razie radź sobie sam Aragogu.")
        };

        tempHeroPart = tempNpcPart.heroParts[0];
        tempHeroPart.NpcPart = new NpcDialogPart("Dziękuję #HERONAME#.");


        NpcDialogPart hagridFirstPart = new NpcDialogPart("Witaj #HERONAME#, Aragog mi uciekł. Widziałeś go może?"); //wymyslic
        hagridFirstPart.heroParts = new List<HeroDialogPart>
        {
            new HeroDialogPart("Tak, minąłem go jakiś czas temu"),
            new HeroDialogPart("Niestety nie.")
        };

        tempHeroPart = hagridFirstPart.heroParts[0];
        tempHeroPart.NpcPart = new NpcDialogPart("Pamiętasz w jakim kierunku szedł?");

        tempNpcPart = tempHeroPart.NpcPart;
        tempNpcPart.heroParts = new List<HeroDialogPart>
        {
            new HeroDialogPart("Tam, w stronę Zakazanego Lasu."),
            new HeroDialogPart("Nie, nie znam tych terenów.")
        };

        tempHeroPart = tempNpcPart.heroParts[0];
        tempHeroPart.NpcPart = new NpcDialogPart("Dziękuję #HERONAME#! Trzymaj 100 sztuk złota za pomoc!");

        tempHeroPart = tempNpcPart.heroParts[1];
        tempHeroPart.NpcPart = new NpcDialogPart("No nic, powodzenia w dalszej drodze #HERONAME#!");


        List<NonPlayerCharacter> npcList = new List<NonPlayerCharacter>
        {
            new NonPlayerCharacter("Aragog", aragogFirstPart),
            new NonPlayerCharacter("Hagrid", hagridFirstPart)
        };

        
        return (new Location("The Burrow", npcList));
    }

    private void SelectHeroName()
    {
        string heroName = "";
        Console.Clear();

        do
        {
            Console.Write("Podaj nazwę bohatera: ");
            heroName = String.Concat(Console.ReadLine().Where(c => !Char.IsWhiteSpace(c)));
        } 
        while (!NameInputValidation(heroName));

        this.hero = new Hero(heroName);
    }

    private void SelectHeroType()
    {
        string input = "";
        int type = -1;
        Console.Clear();

        do
        {
            Console.WriteLine($"Witaj {hero.Name}! Wybierz klasę bohatera.");
            foreach (int i in Enum.GetValues(typeof(EHeroClass)))
            {
                Console.WriteLine($"[{i+1}] " + $"{Enum.GetName(typeof(EHeroClass), i)}");
            }

            input = Console.ReadLine();
            type = OptionInputValidation(input, Enum.GetNames(typeof(EHeroClass)).Length);
        } 
        while (type < 0);

        hero.HeroType = (EHeroClass)type;
    }

    private void ShowLocation()
    {
        int option = -1;

        do
        {
            Console.WriteLine($"Znajdujesz się w: {location.Name}. Co chcesz zrobić?");
            foreach (NonPlayerCharacter npc in location.NpcList)
            {
                Console.WriteLine($"[{location.NpcList.IndexOf(npc) + 1}] " + $"Porozmawiaj z {npc.Name}");
            }
            Console.WriteLine("[X] Zamknij program");

            string input = Console.ReadLine();

            if (input.Equals("X", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }

            option = OptionInputValidation(input, location.NpcList.Count);
        }
        while (option < 0);

        this.TalkTo(location.NpcList.ElementAt(option), new DialogParser(hero));
    }

    private void TalkTo(NonPlayerCharacter npc, DialogParser parser)
    {
        NpcDialogPart? currentNpcPart = npc.StartTalking();
        string input = "";
        int option = -1;

        while (currentNpcPart is not null)
        {
            Console.Clear();

            if (currentNpcPart.heroParts is not null)
            {
                do
                {
                    Console.WriteLine($"{npc.Name}: " + parser.ParseDialog(currentNpcPart) + "\n");
                    Console.WriteLine("Wybierz odpowiedź:");
                    foreach (HeroDialogPart heroPart in currentNpcPart.heroParts)
                    {
                        Console.WriteLine($"[{currentNpcPart.heroParts.IndexOf(heroPart) + 1}] " + $"{parser.ParseDialog(heroPart)}");
                    }
                    input = Console.ReadLine();
                    option = OptionInputValidation(input, currentNpcPart.heroParts.Count);
                }
                while (option < 0);

                currentNpcPart = currentNpcPart.heroParts.ElementAt(option).NpcPart;
            }
            else
            {
                Console.WriteLine($"{npc.Name}: " + parser.ParseDialog(currentNpcPart));
                Thread.Sleep(TimeSpan.FromSeconds(1));
                currentNpcPart = null;
            }
        }

        Console.Clear();
        this.ShowLocation();
    }

}
