namespace Homework_Csharp_11_12.BankCard;
using Homework_Csharp_11_12.Bank;

using static System.Console;







class Program
{
    static void Main()
    {
        try
        {
            Bank bank = Data();

            while (true)
            {
                string? Name, PIN;
                EnterData(out Name, out PIN);

                bool check;
                Client client;
                (check, client) = SignIn(bank, Name, PIN);


                if (check)
                {
                    while (true)
                    {
                        string input = Choice();

                        if (int.TryParse(input, out int choice))
                        {
                            if (choice == 0)
                                break;
                            switch (choice)
                            {
                                case 1:
                                    bank.ShowCardBalance(client);
                                    break;
                                case 2:
                                    string input2 = AmountChoice();
                                    if (int.TryParse(input2, out int choice2))
                                    {
                                        if (choice2 == 0)
                                            break;
                                        switch (choice2)
                                        {
                                            case 1:
                                                WriteLine($"{bank.WithdrawMoney(client, 10)}\n");
                                                break;
                                            case 2:
                                                WriteLine($"{bank.WithdrawMoney(client, 20)}\n");
                                                break;
                                            case 3:
                                                WriteLine($"{bank.WithdrawMoney(client, 50)}\n");
                                                break;
                                            case 4:
                                                WriteLine($"{bank.WithdrawMoney(client, 100)}\n");
                                                break;
                                            case 5:
                                                Write("\nEnter amount: ");
                                                decimal amount = Convert.ToInt64(ReadLine());
                                                WriteLine($"{bank.WithdrawMoney(client, amount)}\n");
                                                break;
                                            default:
                                                WriteLine("Bele secim movcud deyil!!!");
                                                break;
                                        }
                                    }
                                    else
                                        WriteLine("Bele secim yoxdur");
                                    break;
                                case 3:
                                    PulKocurmek(bank, client);
                                    break;
                                default:
                                    WriteLine("\nBele secim yoxdur");
                                    break;
                            }
                        }
                        else
                        {
                            WriteLine("Reqem daxil edin\n");
                            continue;
                        }
                    }
                }

            }


        }
        catch (SystemException ex)
        {
            WriteLine(ex.ToString());
        }
        catch (Exception ex)
        {
            WriteLine(ex.ToString());
        }
    }



    //////////////////////////////////////////////////////////////////////////////////////////

    private static void PulKocurmek(Bank bank, Client client)
    {
        Write("Kart nomresini daxil edin daxil edin: ");
        string PAN = ReadLine()!;

        if (string.IsNullOrEmpty(PAN))
            throw new ArgumentNullException("Enter reply PAN");

        if (PAN.Length != 16)
            throw new ArgumentOutOfRangeException("the length of the pan is less than 16");

        foreach (var cl1 in bank.GetClients())
        {
            if (cl1.BankCard.PAN == PAN)
            {
                Write("\nEnter amount: ");
                decimal amount = Convert.ToInt64(ReadLine());

                bank.WithdrawMoney(client, amount);
                cl1.BankCard.Balans += amount;
                break;
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////

    private static string Choice()
    {
        WriteLine("\nChoice: ");
        WriteLine("1. Balans");
        WriteLine("2. Nagd pul");
        WriteLine("3. Kartdan Kart kocurme");
        WriteLine("0. Cixmaq");

        Write("\nEnter Choice: ");
        string input = ReadLine()!;
        return input;
    }

    //////////////////////////////////////////////////////////////////////////////////////////

    private static string AmountChoice()
    {
        WriteLine("\nChoice");
        WriteLine("1. 10 azn");
        WriteLine("2. 20 azn");
        WriteLine("3. 50 azn");
        WriteLine("4. 100 azn");
        WriteLine("5. Diger");
        WriteLine("0. Cixmaq");
        Write("\nEnter Choice: ");

        string input2 = ReadLine()!;
        return input2;
    }

    //////////////////////////////////////////////////////////////////////////////////////////

    private static Bank Data()
    {
        BankCard bankCard1 = new("1Kart", "Kapital", "1234567891234567", "2022", "123", "11/25", 15000);
        BankCard bankCard2 = new("Leo", "Unibank", "2222444466668888", "1947", "222", "09/27", 5000);
        BankCard bankCard3 = new("Atb Bank", "Azer Turk Bank", "1111333355557777", "1902", "111", "01/28", 8000);
        BankCard bankCard4 = new("Pul Kart", "YapiKredi", "9999777755553333", "2000", "999", "09/24", 6000);
        BankCard bankCard5 = new("Albali", "Unibank", "2222333344445555", "5555", "555", "05/25", 3000);



        Client client1 = new(new Guid(), "Kamran", "Karimzada", new DateOnly(1999, 03, 27), 25000, bankCard1);
        Client client2 = new(new Guid(), "Kenan", "Muradov", new DateOnly(2005, 01, 01), 20000, bankCard2);
        Client client3 = new(new Guid(), "Vasif", "Babazade", new DateOnly(2004, 09, 01), 15000, bankCard3);
        Client client4 = new(new Guid(), "ALI", "Samilzade", new DateOnly(2006, 08, 18), 10000, bankCard4);
        Client client5 = new(new Guid(), "Elsad", "Hasanov", new DateOnly(2004, 09, 07), 5000, bankCard5);

        Bank bank = new("Merkezi Bank");

        bank.AddClient(client1);
        bank.AddClient(client2);
        bank.AddClient(client3);
        bank.AddClient(client4);
        bank.AddClient(client5);
        return bank;
    }

    //////////////////////////////////////////////////////////////////////////////////////////

    private static void EnterData(out string? Name, out string? PIN)
    {
        Write("\nEnter Name: ");
        Name = ReadLine()?.ToString();
        Write("Enter PIN: ");
        PIN = ReadLine()?.ToString();
    }

    //////////////////////////////////////////////////////////////////////////////////////////

    private static (bool, Client) SignIn(Bank bank, string? Name, string? PIN)
    {
        foreach (var client in bank.GetClients())
        {
            if (client.Name == Name)
                if (client.BankCard.PIN == PIN)
                {
                    WriteLine($"\n{client.Name} {client.Surname} Welcome\n");

                    return (true, client);

                }
        }
        throw new Exception("Bele MElumat yoxdur!!");
    }

}