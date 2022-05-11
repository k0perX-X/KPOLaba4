using System.Xml.Linq;

namespace LinqXml21
{
    public class LinqXml21
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath, string s)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            xDocument.Root?.Elements(s).ToList().ForEach(el => el.Remove());
            xDocument.Save(outputXmlFilePath);
        }
    }
}