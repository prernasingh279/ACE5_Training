namespace Bank
{
    public class InsufficientBalanceException :ApplicationException
    {
        public InsufficientBalanceException(string Message):base(Message){}
    }
}