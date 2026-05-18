public class Singleton
{
    private static Singleton _instance;
    private Singleton()
    {
    }
    public static Singleton GetInstance()
    {
        if (_instance == null)
        { _instance = new Singleton(); }
        return _instance;
    }
}

class Program
{
    static void Main()
    {
        Singleton obj1 = Singleton.GetInstance();
        Singleton obj2 = Singleton.GetInstance();
        // now check two object are same or not... definitely will same. 
        Console.WriteLine(obj1 == obj2);
    }
}