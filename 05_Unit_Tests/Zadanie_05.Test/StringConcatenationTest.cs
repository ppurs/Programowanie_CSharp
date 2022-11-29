namespace Zadanie_05.Test
{
    //zadanie 1
 
    [TestFixture]
    public class StringConcatenationTest
    {
        [Test, Category("ConcatTwoStrings")]
        public void RegularUseCase_ResultIsNotNull()
        {
            //Arrange:
            var stringConcatenation = new StringConcatenation();

            //Act:
            string? result = stringConcatenation.ConcatTwoStrings("random", "randomString");

            //Assert:
            Assert.NotNull(result);
        }

        [Category("ConcatTwoStrings")]
        [TestCase("first", "Second", ExpectedResult = "firstSecond")]
        [TestCase("string   ", "with spaces", ExpectedResult = "string   with spaces")]
        [TestCase("lower_case", "_letters", ExpectedResult = "lower_case_letters")]
        [TestCase("UPPER_CASE", "_LETTERS", ExpectedResult = "UPPER_CASE_LETTERS")]
        [TestCase("MixedCase", "Letters", ExpectedResult = "MixedCaseLetters")]
        [TestCase("With numbers: ", "1 2 3 4", ExpectedResult = "With numbers: 1 2 3 4")] 
        public string? RegularUseCase( string firstPart, string secondPart ) 
        {
            StringConcatenation stringConcatenation = new StringConcatenation();

            return stringConcatenation.ConcatTwoStrings(firstPart, secondPart);
        }

        [Test, Category("ConcatTwoStrings")]
        public void FirstArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation = new StringConcatenation();

            //Act:
            string? result = stringConcatenation.ConcatTwoStrings(null, "randomString");

            //Assert:
            Assert.IsNull(result);
        }

        [Test, Category("ConcatTwoStrings")]
        public void SecondArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation = new StringConcatenation();

            //Act:
            string? result = stringConcatenation.ConcatTwoStrings("other random string", null); ;

            //Assert:
            Assert.IsNull(result);
        }

        [Test, Category("ConcatTwoStrings")]
        public void BothArgumentsAreNull()
        {
            //Arrange:
            var stringConcatenation = new StringConcatenation();

            //Act:
            string? result = stringConcatenation.ConcatTwoStrings(null, null);

            //Assert:
            Assert.IsNull(result);
        }

    }
} 