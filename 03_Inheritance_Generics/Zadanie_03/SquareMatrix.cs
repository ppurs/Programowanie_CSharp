using System.Reflection.Metadata.Ecma335;

namespace Zadanie_03
{
    //Zadanie 3.5 

    class SquareMatrix<T> : Matrix<T> where T : IComparable, IFormattable
    {
        public SquareMatrix(T[,] values) : base(values)
        {
            if ( values.GetLength(0) != values.GetLength(1))
            {
                throw new Exception("Cannot create SquareMatrix object: matrix is not square.");
            }
        }

        public bool IsDiagonal()
        {

            for ( int i = 0; i < Values.GetLength(0); i++ )
            {
                for ( int j = 0; j < Values.GetLength(1); j++ )
                {
                    if( i != j &&  ( (dynamic)Values[i, j] != (dynamic)0 || (dynamic)Values[i, j] != (dynamic)0 ) )
                    {
                        return false;
                    } 
                }
            }

            return true;
        }
        
    }
}
