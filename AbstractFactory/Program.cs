
public interface IFactory
{
    IButton CreateButton();
    ICheckBox CreateCheckBox();
}

public interface ICheckBox
{
    void Check();
}

public interface IButton
{
    void Render();
}

public class WindowsButton : IButton
{
    public void Render()
    {
        System.Console.WriteLine("Windows button rendered...");
    }
}
public class MacButton : IButton
{
    public void Render()
    {
        System.Console.WriteLine("MacBook button rendered...");
    }
}
public class WindowsCheckBox : ICheckBox
{
    public void Check(){System.Console.WriteLine("Windows Checkbox are created...");}
}
public class MacCheckBox : ICheckBox
{
    public void Check(){System.Console.WriteLine("MacCheckBox Checkbox are created...");}
}

public class WindowsFactory : IFactory
{
    public IButton CreateButton()=> new WindowsButton();
    public ICheckBox CreateCheckBox()=> new WindowsCheckBox();
}
public class MacFactory : IFactory
{
    public IButton CreateButton()=> new MacButton();
    public ICheckBox CreateCheckBox()=> new MacCheckBox();
}

class Program
{
    public static void Main()
    {
        IFactory windows = new WindowsFactory();
        var btn = windows.CreateButton();
        btn.Render();
        IFactory mac = new MacFactory();
        var macBtn = mac.CreateButton();
        macBtn.Render();
        
    }
}