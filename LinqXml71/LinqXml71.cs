using System.Xml.Linq;

namespace LinqXml71
{
    public class LinqXml71
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            XDocument newXDocument = new XDocument(
                xDocument.Declaration,
                new XElement("root"));
            var xElements = xDocument.Root.Elements();
            foreach (var xElement in xElements)
            {
                if (xElement.Name != "station") continue;
                string brand = "b" + xElement.Element("info").Attribute("brand").Value;
                string price = "p" + xElement.Element("info").Attribute("price").Value;
                if (newXDocument.Root.Element(brand) == null)
                    newXDocument.Root.Add(new XElement(brand));
                if (newXDocument.Root.Element(brand).Element(price) == null)
                    newXDocument.Root.Element(brand).Add(new XElement(price));
                newXDocument.Root.Element(brand).Element(price).Add(new XElement("info",
                    new XAttribute("street", xElement.Attribute("street").Value),
                    new XAttribute("company", xElement.Attribute("company").Value)));
            }
            newXDocument.Save(outputXmlFilePath);
        }
    }
}