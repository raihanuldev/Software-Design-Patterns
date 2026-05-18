using System.Diagnostics;

public interface INotification
{
    void Send(string message);
}
public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email::{message}");
    }
}
public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS::{message}");
    }
}


public class FactoryNotification
{
    public static INotification CreateNotification(string type)
    {
       
        return type switch 
        {
            "Email" => new EmailNotification(),
            "SMS" => new SMSNotification(),
            _ => throw new ArgumentException("Invaild Of argument type")
        };
    }
}

class Program
{
    static void Main()
    {
        INotification notification = FactoryNotification.CreateNotification("Email");
        notification.Send("Hello everyone this send by email");
        notification = FactoryNotification.CreateNotification("SMS");
        notification.Send("THIS IS SEND BY SMS");
    }
}
