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

    public double GetBalance(int accountId)
    {
        var account = AccountRepo.Accounts.Find(a => a.Id == accountId);
        if (account == null)
            throw new Exception("no account found");
        return account.Balance;
    }

    public bool Deposit(int accountId, double amount)
    {
        var account = AccountRepo.Accounts.Find(a => a.Id == accountId);
            if (account == null) 
            return false;
        
        account.Balance+= amount;
        return true;

    }    
    
    public bool Withdrawal(int accountId, double amount)
    {
        var account = AccountRepo.Accounts.Find(a => a.Id == accountId);
            if (account == null || account.Balance < amount ) 
            return false;
        account.Balance-= amount;
        return true;

    }
}