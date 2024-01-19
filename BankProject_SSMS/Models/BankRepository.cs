using System.Security.Cryptography.X509Certificates;
using BankProject_SSMS;
using BankProject_SSMS.Models;

namespace Bank_Project;

    class BankRepository : IBankRepository
    {

        //  private readonly Ace52024Context? db ;
        //  public BankRepository(Ace52024Context _db){
        //     db = _db;
        //  }
        public static Ace52024Context db = new Ace52024Context();
        // BankRepository bankRepository = new BankRepository();
        //  public BankRepository(){
        //     db=null;
        //  }
     

    public void NewAccount(PrernaSbaccount acc)
        {
            db.PrernaSbaccounts.Add(acc);
            db.SaveChanges();   
             System.Console.WriteLine("New Account is added successfully");
        }


        public PrernaSbaccount GetAccountDetails(int accno)
        {
            PrernaSbaccount sc = db.PrernaSbaccounts.Where(x=>x.AccountNumber==accno).SingleOrDefault();
            if(sc==null)
            throw new AccNotFoundException("the account no was not found");

            else
            return sc;


        }


        public void DepositAmount(int accno, decimal amt)
        {
            PrernaSbaccount sc = db.PrernaSbaccounts.Where(x=>x.AccountNumber==accno).SingleOrDefault();
            if(sc==null){
               throw new AccNotFoundException("the account no was not found");
            }
            else{
                
                sc.CurrentBalance=sc.CurrentBalance+amt;
                db.PrernaSbaccounts.Update(sc);
                // PrernaSbtransaction sc1 = db.PrernaSbtransactions.Where(x=>x.AccountNumber==accno).SingleOrDefault();
                 PrernaSbtransaction sc1 = new PrernaSbtransaction();
                sc1.TransactionType="Deposit";
                sc1.TransactionDate=DateTime.Now;
                sc1.Amount = amt;
                sc1.AccountNumber= accno;
                db.PrernaSbtransactions.Add(sc1);
                db.SaveChanges();
                System.Console.WriteLine("YAyyy !! Deposited succesfully");


            }
            
        }

        
        public List<PrernaSbaccount> GetAllAccounts()
        {
            var list = db.PrernaSbaccounts.Where(x=>true).ToList();
            return list;
        }

        public List<PrernaSbtransaction> GetTransactions(int accno)
        {
            var list = db.PrernaSbtransactions.Where(x=>x.AccountNumber==accno).ToList();
            if(list == null)
            {
                throw new AccNotFoundException("no transactions found for this account no");
            }
            return list;
        }

       
        public void WithdrawAmount(int accno, decimal amt)
        {
            PrernaSbaccount a=db.PrernaSbaccounts.Where(x=> x.AccountNumber==accno).SingleOrDefault();
        if(a==null){
            throw new AccNotFoundException("account no not found");
        }
        if(a.CurrentBalance<amt)
        {
            throw new InsufficientBalanceException("Insufficient Balance in the account");
        }
        else
        {
            a.CurrentBalance-=amt;
            db.PrernaSbaccounts.Update(a);
            // PrernaSbtransaction at=db.PrernaSbtransactions.Where(x=>x.AccountNumber==accno).SingleOrDefault();
           PrernaSbtransaction at = new PrernaSbtransaction();
            at.TransactionType="Deposit";
            at.TransactionDate=DateTime.Now;
            at.AccountNumber=accno;
            at.Amount=amt;
            db.PrernaSbtransactions.Add(at);
            db.SaveChanges();
            // Console.WriteLine("Yay!! Withdrawn successfully");
        }
        }
        
    }


