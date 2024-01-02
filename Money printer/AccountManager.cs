namespace Money_printer;

public class AccountManager
{
    public List<Account> GetAccounts()
    {
        return AccountRepo.Accounts;
    }

    public int CreateAccount(int clientId, double balance)
    {
        try
        {
            var newAccount = new Account(clientId, balance);
            AccountRepo.Accounts.Add(newAccount);
            return newAccount.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
        
    }
}