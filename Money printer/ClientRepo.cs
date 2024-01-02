using System.Runtime.CompilerServices;

namespace Money_printer;

public static class ClientRepo
{
    public static int Counter = 0;
    public static readonly List<Client> Clients = new();

    static ClientRepo()
    {
        Clients.Add(new Client("Jules Destrooper", new DateTime(2000, 02, 25)));
        Clients.Add(new Client("Pierre Marcolini", new DateTime(2018, 10, 11)));
        Clients.Add(new Client("Tony Choco", new DateTime(2023, 05, 31)));
        Clients.Add(new Client("Pierre Saey", new DateTime(2015, 11, 02)));
    }
}