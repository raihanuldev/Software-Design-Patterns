using System.Xml.Linq;
using Newtonsoft.Json;

public interface IDataProcessor
{
    public void DataProcessor(string processedData);
}

public class JSONDataProccesor : IDataProcessor
{
    public void DataProcessor(string processedData)
    {
        //for example there are proccess logics
        var jsonData = processedData;
        Console.WriteLine(jsonData);
    }
}

public class XMLDataProvider
{
    public string GetXMLData()
    {
        XDocument XmlDoc = new XDocument(
            new XElement("User",
            new XElement("Name","RIHANUL ISLAM"),
            new XElement("Adresss","Cox's Bazar")
            )
        );
        return XmlDoc.ToString();
    }
}


public class XmlTOJsonAdaptar : IDataProcessor
{
    private XMLDataProvider _xmlDataProvider;
    public XmlTOJsonAdaptar(XMLDataProvider xmlDataProvider)
    {
        _xmlDataProvider = xmlDataProvider;
    }
    public void DataProcessor(string processedData)
    {
        string xmldata = _xmlDataProvider.GetXMLData();
        XDocument doc = XDocument.Parse(xmldata);
        string convertedJson = JsonConvert.SerializeXNode(doc,Formatting.Indented,true);
        System.Console.WriteLine(convertedJson);
    }
}

partial class Program
{
    static void Main()
    {
        //normall json procceor
        IDataProcessor jsonProccesor = new JSONDataProccesor();
        jsonProccesor.DataProcessor("Hello world iam native json");

        XMLDataProvider Dataprovider = new XMLDataProvider();
        IDataProcessor xmldata = new XmlTOJsonAdaptar(Dataprovider);
        xmldata.DataProcessor(Dataprovider.GetXMLData());
    }
}