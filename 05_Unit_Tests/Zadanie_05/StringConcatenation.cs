namespace Zadanie_05
{
    //zadanie 1
    public class StringConcatenation
    {
        public string? ConcatTwoStrings(string? one, string? two)
        {
            if (one == null || two == null)
            {
                return null;
            }

            return string.Concat(one, two);
        }
    }
}
