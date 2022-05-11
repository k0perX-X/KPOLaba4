using System.Globalization;
using System.Xml.Linq;

namespace LinqXml41
{
    public class LinqXml41
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            var xElements = xDocument.Root.DescendantsAndSelf().Where(el => el.FirstNode?.GetType() == typeof(XText)).ToList();
            foreach (var xElement in xElements)
            {
                if (!double.TryParse(xElement.Value, out double xResult))
                    continue;
                var currentXElement = xElement;
                while (currentXElement.Parent != null)
                {
                    currentXElement = currentXElement.Parent;
                    var at = currentXElement.Attributes().Where(at => at.Name.LocalName == "sum").FirstOrDefault();
                    if (at != null)
                    {
                        at.Value = Math.Round(double.Parse(at.Value, CultureInfo.InvariantCulture) + xResult, 2).ToString();
                    }
                    else
                    {
                        currentXElement.SetAttributeValue("sum", Math.Round(xResult, 2).ToString());
                    }
                }
            }
            xDocument.Save(outputXmlFilePath);
        }
    }
}