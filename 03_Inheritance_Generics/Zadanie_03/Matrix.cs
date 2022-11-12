using System.Runtime.ConstrainedExecution;

namespace Zadanie_03 { 

    //Zadanie 3.5, 3.6

    class Matrix<T> where T : IComparable, IFormattable
    {
        public T[,] Values { get; set; }

        public Matrix(T[,] values)
        {
            this.Values = values;

        }

        public static Matrix<T> operator +( Matrix<T> left, Matrix<T> right )
        {
            if( left == null || right == null)
            {
                return null;       
            }

            if( left.Values.GetLength(0) != right.Values.GetLength(0) || left.Values.GetLength(1) != right.Values.GetLength(1) )
            {
                throw new InvalidOperationException("Matrix addition is not possible because the dimensions are not the same.");
            }

            T[,] result = new T[left.Values.GetLength(0), left.Values.GetLength(1)];

            for ( int i = 0; i < result.GetLength(0); i++ )
            {
                for ( int j = 0; j < result.GetLength(1); j++ )
                {
                    dynamic firstArgument = left.Values[i, j];
                    dynamic secondArgument = right.Values[i, j];

                    result[i, j] = (T)(firstArgument + secondArgument);
                }
            }

            return new Matrix<T>(result);
        }

        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            if (left == null || right == null )
            {
                return null;
            }


            if (left.Values.GetLength(1) != right.Values.GetLength(0))
            {
                throw new InvalidOperationException("Matrix multiplication is not possible due to invalid dimensions.");
            }

            T[,] result = new T[left.Values.GetLength(0), left.Values.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    dynamic temp = 0;

                    for (int k = 0; k < left.Values.GetLength(1); k++)
                    {
                        dynamic firstArgument = left.Values[i, k];
                        dynamic secondArgument = right.Values[k, j];

                        temp += (T)(firstArgument * secondArgument);
                    }

                    result[i, j] = temp;
                }
            }

            return new Matrix<T>(result);
        }

        public T GetElement(int row, int col)
        {
            return Values[row, col];
        }

        public void Display()
        {  
            for( int i = 0; i < Values.GetLength(0); i++ )
            {
                for( int j = 0; j < Values.GetLength(1); j++)
                {
                    Console.Write("{0,-3} ", Values[i, j]);
                    Console.Write("  ");
                }
                Console.Write("\n");
            }
        }
    }
}

