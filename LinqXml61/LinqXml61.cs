using System.Xml.Linq;

namespace LinqXml61
{
    public class LinqXml61
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            var xElements = xDocument.Root.Elements();
            foreach (var xElement in xElements)
            {
                xElement.Element("time").SetAttributeValue("id", xElement.Element("id").Value);
                var date = DateTime.Parse(xElement.Element("date").Value);
                xElement.Element("time").SetAttributeValue("year", date.Year);
                xElement.Element("time").SetAttributeValue("month", date.Month);
                xElement.Elements().Where(el => el.Name.LocalName != "time").ToList().ForEach(el => el.Remove());
            }
            xDocument.Save(outputXmlFilePath);
        }
    }
}