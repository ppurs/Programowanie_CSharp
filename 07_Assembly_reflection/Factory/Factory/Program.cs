using System.Reflection;

namespace Factory
{
    public class Program
    {

        public static void Main(string[] args)
        {
            foreach( string arg in args )
            {
                var temp = arg.Replace('\"', '\0').Split(';');

                var assembly = Assembly.LoadFrom(@temp[0]);

                Type? type = assembly.GetType("BeerProcessor.ZleceniePiwo") ?? assembly.GetType("SandwichProcessor.ZlecenieKanapka") ?? null;
                
                if ( type != null )
                {
                    dynamic? zlecenie = Activator.CreateInstance(type);

                    PropertyInfo? info = type.GetProperty("Tytul");
                    info?.SetValue(zlecenie, temp[1]);

                    zlecenie?.Process();

                    Console.WriteLine();
                }
               
            }
        }
    }
}