using System.Globalization;
using System.Xml.Linq;

namespace LinqXml81
{
    public class LinqXml81
    {
        public static void Main(string initialXmlFilePath, string outputXmlFilePath)
        {
            XDocument xDocument = XDocument.Load(initialXmlFilePath);
            XDocument newXDocument = new XDocument(
                xDocument.Declaration,
                new XElement("root"));
            Dictionary<string, Dictionary<int, List<(int flat, string name, double debt)>>> xDictionary = new();
            foreach (var house in xDocument.Root.Elements())
            {
                if (!xDictionary.ContainsKey(house.Name.LocalName))
                    xDictionary.Add(house.Name.LocalName, new());
                foreach (var flat in house.Elements())
                {
                    int number = int.Parse(flat.Name.LocalName.Remove(0, 4));
                    if (!xDictionary[house.Name.LocalName].ContainsKey(number / 36))
                        xDictionary[house.Name.LocalName].Add(number / 36, new ());
                    xDictionary[house.Name.LocalName][number / 36].Add((number, flat.Attribute("name").Value,
                        double.Parse(flat.Attribute("debt").Value, CultureInfo.InvariantCulture)));
                }
            }

            foreach (var house in xDictionary)
            {
                List<XElement> entrances = new List<XElement>();
                foreach (var entrance in house.Value)
                {
                    List<XElement> debts = new();
                    foreach (var debt in entrance.Value)
                    {
                        XElement debtXElement = new("debt", debt.debt);
                        debtXElement.SetAttributeValue("flat", debt.flat);
                        debtXElement.SetAttributeValue("name", debt.name);
                        debts.Add(debtXElement);
                    }

                    XElement entranceXElement = new XElement("entrance", debts);
                    entranceXElement.SetAttributeValue("number", entrance.Key + 1);
                    entranceXElement.SetAttributeValue("count", debts.Count);
                    entranceXElement.SetAttributeValue("avr-debt",
                        Math.Round(entrance.Value.Select(x => x.debt).Sum() / entrance.Value.Count));
                    entrances.Add(entranceXElement);
                }
                XElement houseXElement = new XElement("house", entrances);
                houseXElement.SetAttributeValue("number", house.Key.Remove(0, 5));
                newXDocument.Root.Add(houseXElement);
            }
            newXDocument.Save(outputXmlFilePath);
        }
    }
}