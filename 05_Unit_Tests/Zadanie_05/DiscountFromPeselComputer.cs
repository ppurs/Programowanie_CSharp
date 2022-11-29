namespace Zadanie_05
{
    //zadanie 4, C - implementacja na podstawie testów
    public class DiscountFromPeselComputer : IDiscountFromPeselComputer
    {
        private DateTime getDateFromPesel(string pesel)
        {
            if( pesel.Length != 11 )
            {
                throw new InvalidPeselException("Invalid pesel format: Pesel should contain 11 digits.");
            }
            
            int yearFromPesel = Int32.Parse(pesel.Substring(0, 2));
            int monthFromPesel = Int32.Parse(pesel.Substring(2, 2));
            int dayFromPesel = Int32.Parse(pesel.Substring(4, 2));

            int year = (monthFromPesel / 20 == 0) ? (1900 + yearFromPesel) : (2000 + (((monthFromPesel / 20) - 1) * 100) + yearFromPesel);
            int month = monthFromPesel % 20;

            return new DateTime(year, month, dayFromPesel);
        }

        public bool HasDiscount(string pesel)
        {
            if ( pesel == null )
            {
                throw new ArgumentNullException();
            }

            try 
            {
                DateTime birthDate = getDateFromPesel(pesel);
                DateTime eighteenFromToday = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
                DateTime sixtyFiveFromToday = new DateTime(DateTime.Now.Year - 65, DateTime.Now.Month, DateTime.Now.Day);

                Console.WriteLine(birthDate);
                Console.WriteLine(eighteenFromToday);
                Console.WriteLine(sixtyFiveFromToday);
                return (birthDate.Date > eighteenFromToday.Date) || (birthDate.Date < sixtyFiveFromToday.Date);
            }
           catch (Exception e)
            {
                throw new InvalidPeselException(e.Message);
            }
        }
    }
}
