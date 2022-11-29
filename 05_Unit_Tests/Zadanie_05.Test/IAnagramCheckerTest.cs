namespace Zadanie_05.Test
{
    //zadanie 3

    [TestFixture]
    public class IAnagramCheckerTest
    {
        [Category("IsAnagram")]
        [TestCase("admirer", "married", ExpectedResult = "true")]
        public bool BothArgumentsLowerCase(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();

            return anagramChecker.IsAnagram(word1, word2);
        }

        [Category("IsAnagram")]
        [TestCase("ELVIS", "LIVES", ExpectedResult = "true")]
        public bool BothArgumentsUpperCase(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();

            return anagramChecker.IsAnagram(word1, word2);
        }

        [Category("IsAnagram")]
        [TestCase("Dictionary", "IndicaTory", ExpectedResult = "true")]             //dzięki temu przypadkowi odnaleziony błąd po implementacji klasy
        [TestCase("eLVIS", "LiVEs", ExpectedResult = "true")]                       // => dopisany przy poprawianiu błędu
        [TestCase("123", "312", ExpectedResult = "true")]
        [TestCase("Schoolmaster48", "TheClassroom48", ExpectedResult = "true")]     //dodany w trakcie implementacji
        public bool ArgumentsWithAlfanumericCharsOnly(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();

            return anagramChecker.IsAnagram(word1, word2);
        }

        [Category("IsAnagram")]
        [TestCase("", "", ExpectedResult = "true")]
        [TestCase("  ", "", ExpectedResult = "true")]
        [TestCase(",&*^%$#@~`=-[]';", "???*-+^! )", ExpectedResult = "true")]
        public bool ArgumentsWithoutAlfanumericChars(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();

            return anagramChecker.IsAnagram(word1, word2);
        }

        [Category("IsAnagram")]
        [TestCase("Christmas tree", "Search, Set, Trim", ExpectedResult = "true")] 
        [TestCase("\"Be Like Water\"", "We break tile", ExpectedResult = "true")]
        [TestCase("Isn't rearrangement rave?", "Internet___ Anagram* Server", ExpectedResult = "true")] 
        public bool ArgumentsWithNonAlfanumericCharsOnly(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();

            return anagramChecker.IsAnagram(word1, word2);
        }

        [Category("IsAnagram")]
        [TestCase("ELVIS", "LIVE", ExpectedResult = "false")]
        [TestCase("admirer", "maried", ExpectedResult = "false")]
        [TestCase("Dictionary", "IndcaTory", ExpectedResult = "false")]
        public bool ArgumentsAreNotAnagrams(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();

            return anagramChecker.IsAnagram(word1, word2);
        }

        [Test, Category("IsAnagram")]
        public void FirstArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => stringConcatenation2.ConcatTwoStrings(null, "randomString"));
        }

        [Test, Category("IsAnagram")]
        public void SecondArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => stringConcatenation2.ConcatTwoStrings("randomString", null));
        }

        [Test, Category("IsAnagram")]
        public void BothArgumentsAreNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => stringConcatenation2.ConcatTwoStrings(null, null));
        }
    }
}
