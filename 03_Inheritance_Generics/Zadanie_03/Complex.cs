namespace Zadanie_03
{
    //Zadanie 3.4, 3.6

    class Complex<T> : IComparable, IFormattable where T : IComparable, IFormattable
    {
        T realPart;
        T imaginaryPart;

        public Complex(T x, T y) 
        {
            this.realPart = x;
            this.imaginaryPart = y;
        }

        public Complex(T x)
        {
            this.realPart = x;
            this.imaginaryPart = (dynamic)0;
        }

        public T GetRealPart()
        {
            return realPart;
        }

        public T GetImaginaryPart()
        {
            return imaginaryPart;
        }

        public static Complex<T> operator +(Complex<T> left, Complex<T> right)
        {
            if (left == null || right == null)
            {
                return null;
            }

            T real = (T)((dynamic)left.realPart + (dynamic)right.realPart);
            T imaginary = (T)((dynamic)left.imaginaryPart + (dynamic)right.imaginaryPart);

            return new Complex<T>( real, imaginary );
        }

        public static Complex<T> operator *(Complex<T> left, Complex<T> right)
        {
            if (left == null || right == null)
            {
                return null;
            }

            dynamic leftReal = left.realPart;
            dynamic leftImaginary = left.imaginaryPart;
            dynamic rightReal = right.realPart;
            dynamic rightImaginary = right.imaginaryPart;

            T real = (T)((leftReal * rightReal) - (leftImaginary * rightImaginary));
            T imaginary = (T)((leftReal * rightImaginary) + (leftImaginary * rightReal));

            return new Complex<T>(real, imaginary);
        }

        public static bool operator ==(Complex<T> left, T right)
        {
            if (left == null || right == null )
            {
                return false;
            }

            if ( (dynamic)left.imaginaryPart != 0 )
            {
                return false;
            }

            return (dynamic)left.realPart == right ? true : false;
        }

        public static bool operator !=(Complex<T> left, T right)
        {
            return !(left == right);
        }

        public int CompareTo(object? obj)
        {
            //comparison based on vectors' length square 

            T leftVectorLength = (dynamic)realPart * (dynamic)realPart + (dynamic)imaginaryPart * (dynamic)imaginaryPart;

            dynamic secondObject = obj;
            T rightVectorLength = (dynamic)secondObject.realPart * (dynamic)secondObject.realPart + (dynamic)secondObject.imaginaryPart * (dynamic)secondObject.imaginaryPart;

            if ((dynamic)leftVectorLength == (dynamic)rightVectorLength)
            {
                return 0;
            }

            return (dynamic)leftVectorLength < (dynamic)rightVectorLength ? -1 : 1;

        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            dynamic imaginary = imaginaryPart;

            if( imaginary == 0 )
            {
                return realPart.ToString();
            }
            else if ( imaginary > 0 )
            {
                return imaginary == 1 ? (realPart + "+i") : (realPart + "+" + imaginaryPart + "i");
            }
            else
            {
                return imaginary == -1 ? (realPart + "-i") : (realPart.ToString() + imaginaryPart + "i");
            }
        }
    }
}
