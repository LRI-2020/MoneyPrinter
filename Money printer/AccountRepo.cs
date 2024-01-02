namespace Money_printer;

public static class AccountRepo
{
    public static int Counter = 0;
    public static readonly List<Account> Accounts = new();

    static AccountRepo()
    {
        Accounts.Add(new Account(1, 1000));
        Accounts.Add(new Account(2, 1500));
        Accounts.Add(new Account(3, 200));
    }
}