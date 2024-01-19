using BankProject_SSMS.Models;

namespace Bank_Project;

interface IBankRepository
{
     public void NewAccount(PrernaSbaccount acc);
    List<PrernaSbaccount> GetAllAccounts();
    PrernaSbaccount GetAccountDetails(int accno);
    public void DepositAmount(int accno, decimal amt);
    public void WithdrawAmount(int accno, decimal amt);
    List<PrernaSbtransaction> GetTransactions(int accno);
}

