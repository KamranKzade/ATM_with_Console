namespace Homework_Csharp_11_12.Bank;

using Homework_Csharp_11_12.BankCard;
using static System.Console;

class Bank
{
    public string? Name { get; set; }
    List<Client> clients = new();


    public Bank(string? name)
    {
        Name = name;
    }


    public int GetClientSize() => clients.Count;
    public List<Client> GetClients() => clients;
    public void AddClient(Client client)
    {
        clients.Add(client);
    }

    public decimal WithdrawMoney(Client clientw, decimal x)
    {
        foreach (var client in clients)
        {
            if (client.BankCard == clientw.BankCard)
            {
                if (client.BankCard.Balans >= x)
                {
                    client.BankCard.Balans -= x;
                    return client.BankCard.Balans;
                }
            }
            
        }
        throw new Exception("Bele Kart yoxdur");
    }


    public void ShowCardBalance(Client clientw)
    {
        foreach (var client in clients)
        {
            if (client.BankCard == clientw.BankCard)
                WriteLine($@"
Balans: {client.BankCard.Balans}
");
        }
    }




}
