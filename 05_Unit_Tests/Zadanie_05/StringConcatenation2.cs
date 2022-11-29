namespace Zadanie_05
{
    //zadanie 2
    public class StringConcatenation2
    {
        public string ConcatTwoStrings(string? one, string? two)
        {
            if (one == null)
            {
                throw new ArgumentNullException(nameof(one));
            }

            if (two == null)
            {
                throw new ArgumentNullException(nameof(two));
            }

            return string.Concat(one, two);
        }
    }
}
