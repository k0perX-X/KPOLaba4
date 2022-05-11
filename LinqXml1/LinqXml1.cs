using System.Text;
using System.Xml.Linq;
namespace LinqXml1;

public static class LinqXml1
{
    public static void Main(string textFilePath, string xmlFilePath, string textEncoding = @"windows-1251", string xmlEncoding = @"windows-1251")
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var text = File.ReadAllLines(textFilePath, Encoding.GetEncoding(@"windows-1251")).Select(b => (new XElement("line", b)));
        XDocument xDocument = new XDocument(
            new XDeclaration("1.0", xmlEncoding, "yes"),
            new XElement("root", text));
        xDocument.Save(xmlFilePath);
    }
}


