//let's go face the problem
using System.ComponentModel.DataAnnotations.Schema;

class InventoryService477
{
    public void checkStock()
    {
        System.Console.WriteLine("Stock Checked");
    }
}
class PaymentService
{
    public void ProcessPayment()
    {
        System.Console.WriteLine("Payment Proccessing....");
    }
}
class OrderService
{
    public void PlaceOrder()
    {
        System.Console.WriteLine("Order Placed");
    }
}


// Facade
class orderFacade
{
    private InventoryService _inventory;
    private PaymentService _payment;
    private OrderService _order;

    public orderFacade()
    {
        _inventory = new InventoryService();
        _payment = new PaymentService();
        _order = new OrderService();
    }
    public void PlaceOrder()
    {
        _inventory.checkStock();
        _payment.ProcessPayment();
        _order.PlaceOrder();
    }
}


class Program
{
    public static void Main()
    {
        //before applying Facade
        // InventoryService inventory = new InventoryService();
        // PaymentService payment = new PaymentService();
        // OrderService order = new OrderService();

        // inventory.checkStock();
        // payment.ProcessPayment();
        // order.PlaceOrder();

        // After applying Facade
        orderFacade order = new orderFacade();
        order.PlaceOrder();
    }
}

