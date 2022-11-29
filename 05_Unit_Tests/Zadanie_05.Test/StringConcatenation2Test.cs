namespace Zadanie_05.Test
{
    //zadanie 2

    [TestFixture]
    public class StringConcatenation2Test
    {
        [Test, Category("ConcatTwoStringsException")]
        public void RegularUseCase_NoneArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.DoesNotThrow(() => stringConcatenation2.ConcatTwoStrings("other string", "randomString"));
        }

        [Test, Category("ConcatTwoStringsException")]
        public void FirstArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => stringConcatenation2.ConcatTwoStrings(null, "randomString"));
        }

        [Test, Category("ConcatTwoStringsException")]
        public void SecondArgumentIsNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => stringConcatenation2.ConcatTwoStrings("randomString", null));
        }

        [Test, Category("ConcatTwoStringsException")]
        public void BothArgumentsAreNull()
        {
            //Arrange:
            var stringConcatenation2 = new StringConcatenation2();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => stringConcatenation2.ConcatTwoStrings(null, null));
        }
    }
}
