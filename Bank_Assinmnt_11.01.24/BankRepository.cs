
namespace Bank
{
    public class BankRepository : IBankRepository
    {
        int transaction_id =0 ; 
        Boolean flag = false;
        public List<SBAccount> sbaccounts;
        public List<SBTransaction> sbtransactions;

        public BankRepository(){
            sbaccounts = new List<SBAccount>();
            sbtransactions = new List<SBTransaction>();
        }
        
        public void NewAccount(SBAccount acc)
        {
            sbaccounts.Add(acc);
            System.Console.WriteLine("New Account is added successfully");
        }
        
         public SBAccount GetAccountDetails(int accno)
        {
            foreach(var item in sbaccounts)
            {
                if(item.AccountNumber==accno){
                    return item;
                }
            }
            // SBAccount sbacc = new SBAccount();
            // return sbacc;
            // return new SBAccount();
            throw new AccNotFoundException("the account no was not found");
        }
        
        public void DepositAmount(int accno, decimal amt)
        {
            transaction_id++;
            string trastype = "Deposit";
            foreach(var item in sbaccounts){
                if(item.AccountNumber==accno)
                {
                     item.CurrBalance+=amt;
                     System.Console.WriteLine($"The new amount is : {item.CurrBalance} ");
                     sbtransactions.Add(new SBTransaction(transaction_id,accno,DateTime.Now,amt,trastype));
                     return ;
                }
            
            }
            // SBTransaction cs = new SBTransaction(transaction_id,accno,DateTime.Now,amt,trastype);
            // sbtransactions.Add(cs);
            
            throw new AccNotFoundException("the account no was not found");
        }

       

        public List<SBAccount> GetAllAccounts()
        {
            return sbaccounts;
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            List<SBTransaction> alltrans = new List<SBTransaction>();
            foreach(var item in sbtransactions)
            {
                if(item.AccountNumber==accno){
                    flag = true ;
                    alltrans.Add(item);
                }
            }
          
           if(alltrans.Count == 0)
            {
                throw new AccNotFoundException("no transactions found for this account no");
            }
             
                return alltrans;
        }

        

        public void WithdrawAmount(int accno, decimal amt)
        {
            
            string trastype = "Withdraw";
          #region  // foreach(var item in sbaccounts){
            //     if(item.AccountNumber==accno && item.CurrBalance>=amt)
            //     {
            //          item.CurrBalance-=amt;
            //          System.Console.WriteLine($"The new amount is : {item.CurrBalance} ");
            //     }
    
         #endregion   // }
            foreach(var item in sbaccounts){
                if(item.AccountNumber == accno){
                    if(item.CurrBalance<amt)
                    {
                        throw new InsufficientBalanceException("Insufficient Balance in the account");
                    }
                    else{
                        transaction_id++;
                        item.CurrBalance-=amt;
                        System.Console.WriteLine($"The new amount is : {item.CurrBalance} ");

                    }
                    sbtransactions.Add(new SBTransaction(transaction_id,accno,DateTime.Now,amt,trastype));
                    return;
                }
                // SBTransaction cs = new SBTransaction(transaction_id,accno,DateTime.Now,amt,trastype);
            // sbtransactions.Add(cs);
            
            }
            throw new AccNotFoundException("account no not found");
            
        }
    }
}