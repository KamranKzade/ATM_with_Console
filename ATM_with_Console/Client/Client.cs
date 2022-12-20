namespace Homework_Csharp_11_12.BankCard;




class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateOnly Age { get; set; }
    public double Salary { get; set; }
    public BankCard BankCard { get; init; }

    public Client(Guid ıd, string? name, string? surname, DateOnly age, double salary, BankCard? bankCard)
    {
        if (name == null || surname == null || bankCard == null)
            throw new ArgumentNullException("Value is Null");


        if (salary < 0)
            throw new ArgumentOutOfRangeException("Salary is negative");

        if (name.Length <= 3 && surname.Length <= 3)
            throw new Exception("Name, Surname lenght <= 3");


        Id = ıd;
        Name = name;
        Surname = surname;
        Age = age;
        Salary = salary;
        BankCard = bankCard!;
    }


    public override string ToString() => $@"
Id: {Id}
Name: {Name}
Surname: {Surname}
Age: {Age}
Salary: {Salary}
BankCard Info: 
{BankCard}
";

}
