namespace Money_printer;

public class Client
{
    public int Id { get; }
    public string Name { get; set; }
    public DateTime DateJoined { get; set; }
    
    
    public Client(string name, DateTime dateJoined)
    {
        Id = ++ClientRepo.Counter;
        Name = name;
        DateJoined = dateJoined;
    }
}