using System.Net.Mime;

namespace Money_printer;

public class Dashboard
{
    private ClientManager ClientManager { get; } = new();
    private AccountManager AccountManager { get; } = new();

    public void Start()
    {
        DisplayMenu();
        var actionInput = Console.ReadLine();
        if (int.TryParse(actionInput, out var action))
        {
            RunAction(action);
        }
        else
        {
            Console.WriteLine("Unknown option");
            DisplayMenu();
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("What do you want to do ? ");
        Console.WriteLine(@"
            1. Display Clients
            2. Display Bank Accounts
            3. Create Client
            4. Create Account
            5. Exit
        ");
    }

    private void RunAction(int action)
    {
        switch (action)
        {
            case 1:
                DisplayClient();
                break;
            case 2:
                DisplayAccounts();
                break;
            case 3:
                NewClient();
                break;
            case 4:
                NewAccount();
                break;
            case 5:
                Console.WriteLine("Bye ...");
                break;
            default:
                Console.WriteLine("Unknown option");
                Start();
                break;
        }
    }

    private void DisplayClient()
    {
        var clients = ClientManager.GetClients();
        Printer.PrintLine();
        Printer.PrintRow("ClientId", "Name", "Joined at", "Accounts Ids", "Accounts Names");
        clients.ForEach(c => { Printer.PrintRow(c.Id.ToString(), c.Name, c.DateJoined.ToShortDateString(), "", ""); });
        Printer.PrintLine();
        Console.ReadLine();
        Start();
    }

    private void DisplayAccounts()
    {
        var accounts = AccountManager.GetAccounts();
        Printer.PrintLine();
        Printer.PrintRow("Account Id", "Client Id", "Client Name", "Balance");
        accounts.ForEach(a =>
        {
            var clientName = GetClientName(a.ClientId);
            Printer.PrintRow(a.Id.ToString(), a.ClientId.ToString(), clientName, a.Balance.ToString());
        });
        Printer.PrintLine();
        Console.ReadLine();
        Start();
    }

    private string GetClientName(int clientId)
    {
        try
        {
            return ClientManager.GetClientById(clientId).Name;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "";
        }
    }

    private void NewClient()
    {
        var nameInput = AskName();
        var joinedAt = AskJoinDate();

        var newClient = ClientManager.CreateClient(nameInput, joinedAt);
        Console.WriteLine("Client created. Id : " + newClient);
        DisplayClient();
    }

    private DateTime AskJoinDate()
    {
        var res = DateTime.UtcNow;
        var isJoinValid = true;
        do
        {
            Console.WriteLine("Enter the date when the client joined the bank. Press Enter if now : ");
            var joinedAtInput = Console.ReadLine();
            if (joinedAtInput != null && joinedAtInput.Trim().Length != 0)
                isJoinValid = DateTime.TryParse(joinedAtInput, out res);
        } while (!isJoinValid);

        return res;
    }

    private string AskName()
    {
        var res = "";
        do
        {
            Console.WriteLine("Enter the name of the Client : ");
            res = Console.ReadLine();
        } while (!IsNameValid(res));

        return res;
    }

    private bool IsNameValid(string? nameInput)
    {
        return nameInput != null && nameInput.Trim().Length > 3;
    }

    private void NewAccount()
    {
        var clientId = AskClientId();
        var balance = AskBalance();
        var res = AccountManager.CreateAccount(clientId, balance);
        if (res == -1)
            Console.WriteLine("An error occurred- Account not created");
        else
        {
            Console.WriteLine("New Account created : " + res);
        }

        Console.ReadLine();
        DisplayAccounts();
    }

    private double AskBalance()
    {
        bool isDouble;
        double balance;
        do
        {
            Console.WriteLine("Enter the balance of the account : ");
            var inputBalance = Console.ReadLine();
            isDouble = double.TryParse(inputBalance, out balance);
        } while (!isDouble || balance < 0 || balance > 100000000000);

        return balance;
    }

    private int AskClientId()
    {
        var inputId = "";
        do
        {
            Console.WriteLine("Enter the id of the account's owner (client Id) : ");
            inputId = Console.ReadLine();
        } while (!IsValidClientId(inputId));

        return int.Parse(inputId);
    }

    private bool IsValidClientId(string? inputId)
    {
        var res = false;
        if (inputId != null && int.TryParse(inputId, out var id))
            res = ClientRepo.Clients.Exists(c => c.Id == id);
        return res;
    }
}