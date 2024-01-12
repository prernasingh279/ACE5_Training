namespace Bank
{
    public class SBAccount
    {
        public int AccountNumber{get;set;}
        public string CustomerName{get;set;}
        public string Cust_Address{get;set;}
        public decimal CurrBalance{get;set;}

        public SBAccount(){}
        public SBAccount(int accno, string custname, string adress, decimal currbalance )
        {
            this.AccountNumber= accno;
            this.CustomerName= custname;
            this.Cust_Address= adress;
            this.CurrBalance = currbalance;
        }
        public override string ToString()
        {
            return $"AccountNumber : {AccountNumber}, CustomerName : {CustomerName}, Cust_Address : {Cust_Address}, CurrBalance : {CurrBalance} ";
        }


    }
}