namespace Bank
{
    public class BankClient
    {
        public static void Main(){
  
             IBankRepository client = new BankRepository();
             while(true)
             {
                
             System.Console.WriteLine("Enter the choice :\n1. Create new account\n2. Get all account\n3. Get acc details\n4. Deposit Amt\n5. Withdraw amt\n6. Get Transactions\n7. exit");

             int n = Convert.ToInt32(Console.ReadLine());
       
             switch(n)
             {
                case 1:
                  System.Console.WriteLine("Enter the Account no , Name , Adress, and Initial Balance");
                  int accno = Convert.ToInt32(Console.ReadLine());
                  string name = Console.ReadLine();
                  string adress = Console.ReadLine();
                  decimal balance = Convert.ToDecimal(Console.ReadLine());
                  SBAccount sc = new SBAccount(accno,name,adress,balance);
                  client.NewAccount(sc);
                  break;

                case 2:
                  List<SBAccount> list = client.GetAllAccounts();
                  foreach(var item in list){
                    // System.Console.WriteLine($"Account no : {item.AccountNumber}\nCustomer Name : {item.CustomerName}\nCustomer Adress : {item.Cust_Address}\nCurrent Balance : {item.CurrBalance}");
                    System.Console.WriteLine(item.ToString());          
                  }
                  break;

                case 3:
                try{
                   System.Console.WriteLine("Enter the acc no");
                   int acc = Convert.ToInt32(Console.ReadLine());
                   SBAccount account = client.GetAccountDetails(acc);
                   System.Console.WriteLine(account.ToString());
                }
                catch(Exception e){
                       System.Console.WriteLine(e.Message);
                }
                   break;

                case 4:
                try{
                  System.Console.WriteLine("Enter the amount and account no");
                  decimal amount = Convert.ToDecimal(Console.ReadLine());
                  int accountno = Convert.ToInt32(Console.ReadLine());
                  client.DepositAmount(accountno, amount);
                }
                catch(Exception e){
                    System.Console.WriteLine(e.Message);
                }
                  break;

                case 5:
                try{
                  System.Console.WriteLine("Enter the amount and account no");
                  decimal withdrawamount = Convert.ToDecimal(Console.ReadLine());
                  int accountsno = Convert.ToInt32(Console.ReadLine());
                  client.WithdrawAmount(accountsno, withdrawamount);
                }
                catch(Exception e){
                    System.Console.WriteLine(e.Message);
                }
                  break;

                case 6:
                try{
                 System.Console.WriteLine("Enter the account no");
                 int tranaccno = Convert.ToInt32(Console.ReadLine());
                 List<SBTransaction> list2 = client.GetTransactions(tranaccno);
                 foreach(var item in list2)
                 {
                    System.Console.WriteLine(item.ToString());
                 }
                }
                catch(Exception e)
                {System.Console.WriteLine(e.Message);}
                 break;

                 case 7:
                  System.Console.WriteLine("exitinggg ......");
                  Environment.Exit(0);
                 break;

                 default:
                 System.Console.WriteLine("Invalid choice, enter a valid choice");
                 break;

  }

             }
        }
    }
}