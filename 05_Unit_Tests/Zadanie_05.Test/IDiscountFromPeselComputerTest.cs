namespace Zadanie_05.Test
{
    //zadanie 4

    // Formularz zawiera pole "PESEL", system udziela zniżki osobom poniżej 18 i powyżej 65lat."
    // pesel -> 11 cyfr

    [TestFixture]
    public class IDiscountFromPeselComputerTest
    {
        [Test, Category("HasDiscount")]
        public void ArgumentIsNull()
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();

            //Act and Assert:
            Assert.Throws<ArgumentNullException>(() => discountComputer.HasDiscount(null));
        }

        [Test, Category("HasDiscount_PeselFormat")]
        [TestCase("")]
        [TestCase("0123456789")]       //10 cyfr
        [TestCase("012345678901")]     //12 cyfr
        public void ArgumentIsNotCorrect_Length( String argument )
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();

            //Act and Assert:
            Assert.Throws<InvalidPeselException>(() => discountComputer.HasDiscount(argument));
        }

        [Test, Category("HasDiscount_PeselFormat")]
        [TestCase("00004567891")]      //miesiac 00
        [TestCase("01134567892")]      //miesiac 13
        [TestCase("01334567893")]
        [TestCase("01204567894")]
        public void ArgumentIsNotCorrect_MonthCodeIsNotCorrect(String argument)
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();

            //Act and Assert:
            Assert.Throws<InvalidPeselException>(() => discountComputer.HasDiscount(argument));

        }

        [Test, Category("HasDiscount_PeselFormat")]
        [TestCase("00013267891")]         //miesiace: 31dni
        [TestCase("00033267891")]
        [TestCase("00053267891")]
        [TestCase("00073267891")]
        [TestCase("00083267891")]
        [TestCase("00103267891")]
        [TestCase("00123267891")]

        [TestCase("00213267891")]
        [TestCase("00233267891")]
        [TestCase("00253267891")]
        [TestCase("00273267891")]
        [TestCase("00283267891")]
        [TestCase("00303267891")]
        [TestCase("00323267891")]

        [TestCase("00043167891")]         //miesiace: 30dni
        [TestCase("00063167891")]
        [TestCase("00093167891")]
        [TestCase("00113167891")]

        [TestCase("00243167891")]         
        [TestCase("00263167891")]
        [TestCase("00293167891")]
        [TestCase("00313167891")]

        [TestCase("00023067891")]         //luty
        [TestCase("00023167891")]
        [TestCase("00223067891")]
        [TestCase("00223167891")]

        public void ArgumentIsNotCorrect_MonthAndDayCodeIsNotCorrect(String argument)
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();

            //Act and Assert:
            Assert.Throws<InvalidPeselException>(() => discountComputer.HasDiscount(argument));
        }

        //faza A - implementacja testów -> nasuwa się pytanie jak przykryć zależność zniżki od daty tak, aby testy były 
        //                                 zawsze aktualne, a nie tylko w dniu/roku implementacji
        //                                 -> pomysł: rozdzielenie tego i przekazywania aktualnej daty argumentem/wstrzykniecie/stworzenie pola z datą/provider;
        //                                      jednak interfejs nam tego nie zapewnia, wszystko zalezy od implementacji kokretnej klasy

        [Test, Category("HasDiscount")]  
        public void RegularUseCase_LessThan18YearsOld()
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();
            string argument = getPeselYear(17) + "210112345";

            //Act:
            bool result = discountComputer.HasDiscount(argument);

            //Assert:
            Assert.AreEqual(true, result);
        }
       
        [Test, Category("HasDiscount")]
        public void RegularUseCase_MoreThan65YearsOld()
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();
            string argument = getPeselYear(66) + "010112345";

            //Act 
            bool result = discountComputer.HasDiscount(argument);      

            //Assert:
            Assert.AreEqual(true, result);
        }

        [Test, Category("HasDiscount")]
        public void RegularUseCase_Equal18YearsOld()
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();

            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string temp = getPeselYear(18);

            temp = temp + (month+20);
            temp = (day < 10) ? (temp + "0" + day) : (temp + day);

            string argument = temp + "12345";

            //Act 
            bool result = discountComputer.HasDiscount(argument);

            //Assert:
            Assert.AreEqual(false, result);
        }

        [Test, Category("HasDiscount")]
        public void RegularUseCase_Equal65YearsOld()
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();

            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string temp = getPeselYear(65);

            temp = (month < 10) ? (temp + "0" + month) : (temp + month); 
            temp = (day < 10) ? (temp + "0" + day) : (temp + day);

            string argument = temp + "12345";

            //Act 
            bool result = discountComputer.HasDiscount(argument);

            //Assert:
            Assert.AreEqual(false, result);
        }

        [Test, Category("HasDiscount")]
        public void RegularUseCase_MoreThan18_LessThan65_YearsOld()
        {
            //Arrange:
            var discountComputer = new DiscountFromPeselComputer();
            string argument = getPeselYear(35) + "010112345";

            //Act 
            bool result = discountComputer.HasDiscount(argument);

            //Assert:
            Assert.AreEqual(false, result);
        }

        private string getPeselYear(int numberToSubstract)
        {
            int year = DateTime.Now.Year;
            year = year % 100;

            int temp = (year - numberToSubstract);

            if(temp < 0 )
            {
                return (100 + temp).ToString();
            }

            if (temp < 10)
            {
                return "0" + temp.ToString();
            }

            return temp.ToString();
        }
    }
}
