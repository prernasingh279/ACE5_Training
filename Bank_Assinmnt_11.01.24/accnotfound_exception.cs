namespace Bank
{
    public class AccNotFoundException :ApplicationException
    {
        public AccNotFoundException(string Message):base(Message){}
    }
}