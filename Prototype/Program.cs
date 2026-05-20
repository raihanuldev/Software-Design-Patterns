
public class Circle
{
    public string color { get; set; }
    public int radius { get; set; }
    public Circle DeepClone()
    {
        return (Circle)this.MemberwiseClone();
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Circle c1 = new Circle();

        c1.color = "Red";
        c1.radius = 5;

        Circle c2 = (Circle) c1.DeepClone();

        System.Console.WriteLine($"c1 Color: {c1.color}");
        System.Console.WriteLine($"c2 Color: {c2.color}");
        // c2.color = "YELLOW";
        // System.Console.WriteLine($"c2 Color: {c2.color}");

    }
}