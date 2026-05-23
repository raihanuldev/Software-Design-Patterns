public interface ICoffee
{
    string GetDescription();
    double GetPrice();
}

public class PlainCoffee : ICoffee
{
    public string GetDescription() => "This is Plain Coffee";
    public double GetPrice() => 23.50;
}

//Abstract Decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _wrappedCoffee;
    //we pass the coffee which we want to decorate
    public CoffeeDecorator(ICoffee coffee)
    {
        _wrappedCoffee = coffee;
    }
    public virtual string GetDescription() => _wrappedCoffee.GetDescription();
    public virtual double GetPrice() => _wrappedCoffee.GetPrice();
}

// Milk Decorato
public class MilkDecoretor : CoffeeDecorator
{
    public MilkDecoretor(ICoffee coffee) : base(coffee){}
    public override string GetDescription() => base.GetDescription() + ", Milk";
    public override double GetPrice() => base.GetPrice() + 5.50; // Add milk cost
}

partial class Program
{
    static void Main()
    {
        ICoffee myCoffee = new PlainCoffee();
        Console.WriteLine($"{myCoffee.GetDescription()} = ${myCoffee.GetPrice()}");

        myCoffee = new MilkDecoretor(myCoffee);
        Console.WriteLine($"{myCoffee.GetDescription()} = ${myCoffee.GetPrice()}");

    }
}