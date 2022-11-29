namespace Zadanie_05
{   
    /**
        * Interfejs obiektu który sprawdza czy dane słowa są anagramami. 4
        * Anagram jest słowem lub frazą, która powstała
        * przez zmianę kolejności liter w oryginalnym słowie lub frazie.
        * Zobacz kilka przykładów na http://www.wordsmith.org/anagram/hof.html
    */

    public interface IAnagramChecker
    {
        /*Sprawdza czy jedno slowo jest anagramem drugiego.
        * Wszystkie niealfanumeryczne znaki są ignorowane.
        * Wielkość liter nie ma znaczenia.
        * word1 - dowolny niepusty string różny od null.
        * word2 - dowolny niepusty string różny od null.
        * Zwraca true wtedy i tylko wtedy gdy word1 jest anagramem word2.
        */
        bool IsAnagram(string word1, string word2);
    }

}
