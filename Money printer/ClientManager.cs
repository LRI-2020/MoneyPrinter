namespace Money_printer;

public class ClientManager
{
    public  List<Client> GetClients()
    {
        return ClientRepo.Clients;
    }

    public int CreateClient(string nameInput, DateTime joinedAt)
    {
        var newClient = new Client(nameInput, joinedAt);
        ClientRepo.Clients.Add(newClient);
        return newClient.Id;
    }

    public Client GetClientById(int id)
    {
        var res = ClientRepo.Clients.Find(c => c.Id == id);
        if (res != null)
            return res;
        throw new Exception("no client found");
    }
}