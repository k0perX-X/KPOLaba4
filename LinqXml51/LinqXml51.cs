using System.Xml.Linq;

namespace LinqXml51
{
    public class LinqXml51
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            var xElements = xDocument.Root.DescendantsAndSelf().Where(el => el.FirstNode?.GetType() == typeof(XText)).ToList();
            foreach (var xElement in xElements)
            {
                var date = DateTime.Parse(xElement.Value);
                xElement.FirstNode.Remove();
                xElement.SetAttributeValue("year", date.Year);
                xElement.Add(new XElement("day",date.Day));
            }
            xDocument.Save(outputXmlFilePath);
        }
    }
}