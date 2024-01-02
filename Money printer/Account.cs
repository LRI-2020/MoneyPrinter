namespace Money_printer;

public class Account
{
    public int ClientId { get; set; }
    public int Id { get; set; }
    public double Balance { get; set; } = 0;

    public Account(int clientId, double balance)
    {
        if (!ClientRepo.Clients.Exists(c => c.Id == clientId))
            throw new Exception("Client does not exist");
        Id = ++AccountRepo.Counter;
        ClientId = clientId;
        Balance = balance;
    }
}