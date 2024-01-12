namespace Bank
{
    public class SBTransaction
    {
        public int Transac_Id{get;set;}
        public DateTime Transac_Date{get;set;}
        public int AccountNumber{get;set;}
        public decimal Amount{get;set;}
        public string Transec_Type{get;set;}
         
         public SBTransaction(){}
         public SBTransaction(int tranid,int accno,DateTime td, decimal amount, string trantype)
         {
            this.Transac_Id = tranid;
            this.Transac_Date=td;
            this.AccountNumber= accno;
            this.Amount = amount;
            this.Transec_Type= trantype;
         }

        public override string ToString()
        {
            return $"TransacId : {Transac_Id}, TransacDate : {Transac_Date}, AccountNumber : {AccountNumber}, Amount : {Amount}, Transec_Type : {Transec_Type} ";
        }

    }
}