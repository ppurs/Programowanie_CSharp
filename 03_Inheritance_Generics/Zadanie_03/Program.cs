
namespace Zadanie_03 {
    class Program
    {
        static int[,] getRandomFilledArrayInt(int width, int height)
        {
            int[,] result = new int[height, width];
            Random random = new Random();

            for( int i = 0; i < height; i++ )
            {
                for( int j = 0; j < width; j++)
                {
                    result[i, j] = random.Next(100);
                }
            }

            return result;
        }

        static Complex<int>[,] getRandomFilledArrayComplexInt(int width, int height)
        {
            Complex<int>[,] result = new Complex<int>[height, width];
            Random random = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result[i, j] = new Complex<int>(random.Next(10), random.Next(10));
                }
            }

            return result;
        }
        static void Main(String[] args )
        {
            
             int[,] identity = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
             SquareMatrix<int> identityMatrix = new SquareMatrix<int>(identity);
             Matrix<int> m1 = new Matrix<int>( getRandomFilledArrayInt(3, 2));
             Matrix<int> m2 = new Matrix<int>(getRandomFilledArrayInt(3, 2));
             Matrix<int> m3 = new Matrix<int>(getRandomFilledArrayInt(2, 4)); 

             Console.WriteLine("----------------------ADDITION(INT)------------------------");

             m1.Display();
             Console.WriteLine();
             
             m2.Display();
             Console.WriteLine();
             
             Console.WriteLine("Result:");
             try
             {
                (m1+m2).Display();
                Console.WriteLine();
             }
             catch ( InvalidOperationException e)
             {
                Console.WriteLine(e.Message);
             }
             

             Console.WriteLine("----------------------MULTIPLICATION(INT)------------------------");

             m3.Display();
             Console.WriteLine();

             m2.Display();
             Console.WriteLine();

             Console.WriteLine("Result:");
             try
             {
                 (m3 * m2).Display();
                 Console.WriteLine();
             }
             catch (InvalidOperationException e)
             {
                 Console.WriteLine(e.Message);
             }

            Console.WriteLine("----------------------SQUARE MATRIX------------------------");

             identityMatrix.Display();
             Console.WriteLine();
             Console.WriteLine( "IsDiagonal: " + identityMatrix.IsDiagonal());
             Console.WriteLine();

             Console.WriteLine("----------------------MATRIX(COMPLEX<INT>)------------------------");

             try
             {
                 SquareMatrix<Complex<int>> c1 = new SquareMatrix<Complex<int>>(getRandomFilledArrayComplexInt(2, 2));
                 SquareMatrix<Complex<int>> c2 = new SquareMatrix<Complex<int>>(getRandomFilledArrayComplexInt(2, 2));

                c1.Display();
                Console.WriteLine();

                c2.Display();
                Console.WriteLine();

                Console.WriteLine("Result of addition:");
                try
                {
                    (c1 + c2).Display();
                    Console.WriteLine();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }
             
           
        }
    }
}