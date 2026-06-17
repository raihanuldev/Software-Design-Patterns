public interface IPaymentGateway
{
    public void ProccessPayment(double amount);
}

// StripeGateWay
public class StripeGateWay : IPaymentGateway
{
    public void ProccessPayment(double amount)
    {
        System.Console.WriteLine($"Proccess Payment {amount} by Stripe");
    }
}
//UPIPayment
public class UPIPaymentGateWay : IPaymentGateway
{
    public void ProccessPayment(double amount)
    {
        System.Console.WriteLine($"Proccess Payment {amount} by UPIPaymentGateWay");
    }
}

public abstract class PaymentMethod
{
    public IPaymentGateway _gateway;
    public PaymentMethod(IPaymentGateway gateway)
    {
        _gateway = gateway;
    }
    public abstract void Pay(double amount);
}

public class CardPayment : PaymentMethod
{
    public CardPayment(IPaymentGateway _gateway):base(_gateway){}
    public override void Pay(double amount)
    {
        System.Console.WriteLine("card Payment.....");
        _gateway.ProccessPayment(amount);
        
    }
}
public class UPIPayment : PaymentMethod
{
    public UPIPayment(IPaymentGateway _gateway):base(_gateway){}
    public override void Pay(double amount)
    {
        System.Console.WriteLine("UPIPayment Payment.....");
        _gateway.ProccessPayment(amount);
        
    }
}
class Program
{
    static void Main()
    {
        PaymentMethod p1 = new CardPayment(new StripeGateWay());
        p1.Pay(500);
        PaymentMethod p2 = new UPIPayment(new UPIPaymentGateWay());
        p2.Pay(1000
        );
    }
}