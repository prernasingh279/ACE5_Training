namespace Bank_Project
{
    public class AccNotFoundException:ApplicationException
    {
        public AccNotFoundException(string Message): base(Message)
        {

        }
    }

    public class InsufficientBalanceException:ApplicationException
    {
        public InsufficientBalanceException(string Message): base(Message){}
    }
}