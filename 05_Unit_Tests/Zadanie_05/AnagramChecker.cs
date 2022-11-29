using System.Text.RegularExpressions;

namespace Zadanie_05
{
    //zadanie 3
    public class AnagramChecker : IAnagramChecker
    {
        public bool IsAnagram(string word1, string word2)
        {
            string temp1 = Regex.Replace(word1, "[^a-zA-Z0-9]", String.Empty).ToLower();
            string temp2 = Regex.Replace(word2, "[^a-zA-Z0-9]", String.Empty).ToLower();

            temp1 = String.Concat(temp1.OrderBy(x => x));
            temp2 = String.Concat(temp2.OrderBy(x => x));

            return temp1.Equals( temp2 );
        }
    }
}
