namespace Homework_Csharp_11_12.BankCard;






class BankCard
{
    private string? _fullname = "empty";
    private string? _bankName = "empty";


    public string? FullName
    {
        get
        {
            if (_fullname == null)
                throw new ArgumentNullException("Enter FullName please");
            return _fullname;
        }
        set
        {
            if (_fullname == null)
                throw new ArgumentNullException("Enter FullName please");

            _fullname = value;
        }
    }
    public string? BankName
    {
        get
        {
            if (_bankName == null)
                throw new ArgumentNullException();
            return _bankName;
        }

        set
        {
            if (_bankName == null)
                throw new ArgumentNullException();

            if (_bankName.Length < 3)
                throw new ArgumentException("Wrong Bank Name!!!");
            _bankName = value;
        }
    }
    public string? PAN { get; set; }

    public string? PIN { get; set; }

    public string? CVC { get; set; }
    public string? ExpireDate { get; set; }
    public decimal Balans { get; set; }

    public BankCard(string? fullName, string? bankName, string? pAN, string? pIN, string? cVC, string? expireDate, decimal balans)
    {
        if (pAN == null || pIN == null || cVC == null)
            throw new ArgumentNullException("Null!!!");


        if (pAN.Length != 16)
            throw new Exception("PAN length == 16");


        if (pIN.Length != 4)
            throw new Exception("PIN length == 4");


        if (cVC.Length != 3)
            throw new Exception("CVC length == 4");


        FullName = fullName;
        BankName = bankName;
        PAN = pAN;
        PIN = pIN;
        CVC = cVC;
        ExpireDate = expireDate;
        Balans = balans;
    }





    public override string ToString() => $@"
FullName: {FullName}
BankName: {BankName}
PAN: {PAN}
PIN: {PIN}
CVC: {CVC}
Expire Date: {ExpireDate}
Balans: {Balans}
";
}
