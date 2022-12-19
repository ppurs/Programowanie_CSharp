using System.Reflection;

namespace Zadanie_06
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var type = Type.GetType("Zadanie_06.Customer");

            /*-----------------------------------------------zadanie 1------------------------------------------------------*/

            Console.WriteLine("Fields: ");                          //lista pól w klasie Pogrupowane względem dostępu
            
            Console.WriteLine("-- Public: ");                       //publiczne
            foreach( var f in type.GetFields() ) {
                Console.WriteLine($"     Type: \"{f.FieldType.Name}\"; name: \"{f.Name}\"");
            }

            Console.WriteLine("-- Non Public: ");                   //niepubliczne 
            foreach ( var f in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance ) ) {
                Console.WriteLine($"     Type: \"{f.FieldType.Name}\"; name: \"{f.Name}\"");
            }
           
            Console.WriteLine("Methods: ");                         //Lista metod
            foreach (var m in type.GetMethods())
            {
                Console.WriteLine($"   {m.Name}");
            }
            
            Console.WriteLine("Nested types: ");                    //typy zagnieżdżone
            foreach (var n in type.GetNestedTypes())
            {
                Console.WriteLine($"   {n.Name}");
            }
            
            Console.WriteLine("Properties: ");                      //propercje
            foreach (var p in type.GetProperties())
            {
                Console.WriteLine($"   Type: \"{p.PropertyType.Name}\"; name: \"{p.Name}\"");
            }

            Console.WriteLine("Members: ");                         //Członkowie
            foreach (var m in type.GetMembers())
            {
                Console.WriteLine($"   {m.Name}");
            }

            /*-----------------------------------------------zadanie 2------------------------------------------------------*/

            var customer = Activator.CreateInstance(type, "Nazwa obiektu customer");

            PropertyInfo adrInfo = type.GetProperty("Address");
            adrInfo.SetValue(customer, "Przykladowy adres");

            PropertyInfo someInfo = type.GetProperty("SomeValue");
            someInfo.SetValue(customer, 15);

            PropertyInfo nameInfo = type.GetProperty("Name");

            Console.WriteLine($"\nProperties po ustawieniu wartości:\n" +
                              $"   Name: \"{nameInfo.Name}\"; value: \"{nameInfo.GetValue(customer)}\"\n" +
                              $"   Name: \"{adrInfo.Name}\"; value: \"{adrInfo.GetValue(customer)}\"\n" +
                              $"   Name: \"{someInfo.Name}\"; value: \"{someInfo.GetValue(customer)}\"");
        }
    }
}
