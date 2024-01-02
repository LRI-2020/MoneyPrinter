namespace Money_printer;

public class AccountManager
{
    public List<Account> GetAccounts()
    {
        return AccountRepo.Accounts;
    }
}