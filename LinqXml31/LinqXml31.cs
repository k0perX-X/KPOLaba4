using System.Xml.Linq;

namespace LinqXml31
{
    public class LinqXml31
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath, string s1, string s2)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            var xElements = xDocument.Root.Elements(s1).ToList();
            xElements.ForEach(el => el.AddAfterSelf(el));
            xElements.ForEach(el => ((XElement) el.NextNode).Name = s2);
            xDocument.Save(outputXmlFilePath);
        }
    }
}