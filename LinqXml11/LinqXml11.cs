using System.Xml.Linq;

namespace LinqXml11
{
    public static class LinqXml11
    {

        public static string[]? Main(string xmlFilePath)
        {
            List<string> names = new();
            XDocument xDocument = XDocument.Load(xmlFilePath);
            XElement? xCurrent = xDocument.Root;
            while (xCurrent != null)
            {
                names.Add(xCurrent.Name.LocalName);
                if (xCurrent.FirstNode != null)
                    if (xCurrent.FirstNode.GetType() == typeof(XElement))
                    {
                        xCurrent = (XElement) xCurrent.FirstNode;
                        continue;
                    }
                
                if (xCurrent.NextNode == null)
                {
                    while (xCurrent.Parent.NextNode == null & xCurrent.Parent.Parent != null)
                    {
                        xCurrent = xCurrent.Parent;
                    }

                    xCurrent = (XElement) xCurrent.Parent.NextNode;
                    continue;
                }
                else
                {
                    xCurrent = (XElement) xCurrent.NextNode;
                    continue;
                }
            }

            return names.Distinct().ToArray();
        }

        public static string[]? LinqMethod(string xmlFilePath)
        {
            return XDocument.Load(xmlFilePath).Root?.DescendantsAndSelf().GroupBy(el => el.Name.LocalName).Select(el=> el.Key).ToArray();
        }
    }
}