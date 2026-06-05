// Proxy Design Pattern => 
/**
 Real-life Example
    in ATM Machine;
        Subject = BANK ACCOUNT
        PROXY   = ATM CARD
        CLIENT  = CUSTOMER
*/

public interface IBankAccount
{
    public void ShowAccount();
    public void WithDraw(double amount);
}

public class BankAccountMain : IBankAccount
{
    private double balance;

    public BankAccountMain(double amount)
    {
        balance = amount;
    }

    public void ShowAccount()
    {
        Console.WriteLine($"account Balance = {balance}  ");
    }

    public void WithDraw(double amount)
    {
        balance = balance - amount;
        Console.WriteLine($"account WITHDRAWN = {amount}");
        Console.WriteLine($"account Balance = {balance}  ");
    }
}

public class Proxy : IBankAccount
{
    private BankAccountMain _account;

    public Proxy(double amount)
    {
        _account = new BankAccountMain(amount);
    }

    public void ShowAccount()
    {
        Console.WriteLine("ATM Card Verification Success");
        _account.ShowAccount();
    }

    public void WithDraw(double amount)
    {
        if (amount > 500)
        {
            Console.WriteLine("Daily limit exceeded");
            return;
        }
        Console.WriteLine("ATM Card Verification Success");
        _account.WithDraw(amount);
    }
}


class Program
{
    static void Main()
    {
        Proxy atmcard = new Proxy(1000);
        atmcard.ShowAccount();
        atmcard.WithDraw(200);

    }
}