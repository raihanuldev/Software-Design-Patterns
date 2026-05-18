public class Computer
{
    public string GPU { get; set; }
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string SSD { get; set; }
    public void Show()
    {
        Console.WriteLine($"...\nGPU: {GPU}...\n CPU: {CPU}...\n RAM: {RAM}...\n SSD: {RAM}...\n");
    }
}
public interface IComputerBuilder
{
    void SetGPU();
    void SetCPU();
    void SetSSD();
    void SetRAM();
    Computer GetComputer();
}
public class GamingComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();
    public void SetCPU()
    {
        _computer.CPU = "intel core i9";
    }

    public void SetGPU()
    {
        _computer.GPU = "intel UHD Grpahic";
    }

    public void SetRAM()
    {
        _computer.RAM = "16gb";
    }

    public void SetSSD()
    {
        _computer.SSD = "512 GB";
    }

    Computer IComputerBuilder.GetComputer()
    {
        return _computer;
    }
}
public class User
{
    public void BuildComputer(IComputerBuilder builder)
    {
        builder.SetCPU();
        builder.SetGPU();
        builder.SetRAM();
        builder.SetSSD();
    }
}

class Program
{
    static void Main()
    {
        User user = new User();
        IComputerBuilder builder = new GamingComputerBuilder();
        user.BuildComputer(builder);
        Computer computer = builder.GetComputer();
        computer.Show();

    }

}
