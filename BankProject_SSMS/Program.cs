using BankProject_SSMS.Models;

namespace Bank_Project
{
      public class BankProject {
         public static void Main(string[] args){
            BankRepository bankRepository = new BankRepository();
            bool check = true;

            while (check)
            {
                Console.WriteLine("Choose you options: ");
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Get all account details");
                Console.WriteLine("3. Get Account details");
                Console.WriteLine("4. Deposit amount");
                Console.WriteLine("5. Withdraw amount");
                Console.WriteLine("6. Get all transactions");
                Console.WriteLine("7. Exit");

                int c = Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter name, address and current balance");
                            string? CustomerName = Console.ReadLine();
                            string? CustomerAdd = Console.ReadLine();
                            decimal CurrentBalance =Convert.ToDecimal(Console.ReadLine());

                            PrernaSbaccount newAccount = new()
                            {
                                CustomerName = CustomerName,
                                CustomerAdress = CustomerAdd,
                                CurrentBalance = CurrentBalance
                            };
                            bankRepository.NewAccount(newAccount);

                            break;
                        }
                    case 2:
                        {
                            List<PrernaSbaccount>? acc = bankRepository.GetAllAccounts();

                            
                                if (acc != null)
                                {
                                    Console.WriteLine("All Details are below mentioned");
                                    foreach (PrernaSbaccount i in acc)
                                    {
                                        Console.WriteLine(i.AccountNumber+" "+i.CustomerName+" "+i.CurrentBalance);
                                    }
                                }

                            break;
                        }
                    case 3:
                        {
                            try{
                                 Console.WriteLine("Enter the account number: ");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            PrernaSbaccount? a = bankRepository.GetAccountDetails(accNo);
                                if (a != null)
                                {
                                    Console.WriteLine("Details");
                                    Console.WriteLine(a.AccountNumber+" "+a.CurrentBalance+" "+a.CustomerName);
                                }
                            }
                            catch(Exception ex)
                            {
                                System.Console.WriteLine(ex.Message);
                            }
                           
                            

                            break;
                        }
                    case 4:
                        {
                          try{
                              Console.WriteLine("Enter the account number and amount:");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            decimal amount= Convert.ToDecimal(Console.ReadLine());
                            bankRepository.DepositAmount(accNo, amount);
                          }
                          catch(Exception e)
                          {
                            System.Console.WriteLine(e.Message);
                          }

                            break;
                        }
                    case 5:
                        {
                            try{
                                
                            Console.WriteLine("Enter the account number and amount: ");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            Decimal amount= Convert.ToDecimal(Console.ReadLine());

                            bankRepository.WithdrawAmount(accNo, amount);
                            }
                            catch(Exception e)
                          {
                            System.Console.WriteLine(e.Message);
                          }

                            break;
                        }
                    case 6:
                        {
                            try{
                                Console.WriteLine("Enter the account number");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            List<PrernaSbtransaction>? t = bankRepository.GetTransactions(accNo);

                                if (t != null)
                                {
                                    Console.WriteLine("All transactions details:");
                                    foreach (PrernaSbtransaction i in t)
                                    {
                                       Console.WriteLine(i.AccountNumber+" "+i.TransactionId+" "+i.Amount);
                                    }
                                }
                            }
                            catch(Exception e)
                          {
                            System.Console.WriteLine(e.Message);
                          }

                            break;
                        }
                    default:
                        check = false;
                        break;
                }
            }
        }
      }
}


