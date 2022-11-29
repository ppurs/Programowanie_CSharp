namespace Zadanie_05
{
    public class InvalidPeselException : Exception
    {
        public InvalidPeselException(string message) : base(message) { }
    }
}
