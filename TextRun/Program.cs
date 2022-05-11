using System.Text;
using System.Xml.Linq;
//1
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("1");
Console.ResetColor();
LinqXml1.LinqXml1.Main(@"59495692.txt",@"output.xml");
Console.WriteLine("Done!");
//11
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("11");
Console.ResetColor();
var array = LinqXml11.LinqXml11.Main(@"XMLFile1.xml");
Console.WriteLine("[{0}]", string.Join(", ", array));
Console.WriteLine("[{0}]", string.Join(", ", LinqXml11.LinqXml11.LinqMethod(@"XMLFile1.xml")));
Console.WriteLine("Done!");
//21
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("21");
Console.ResetColor();
LinqXml21.LinqXml21.Main(@"output.xml", @"output-2.xml", "line");
Console.WriteLine("Done!");
//31
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("31");
Console.ResetColor();
LinqXml31.LinqXml31.Main(@"XMLFile1.xml", @"XMLFile1-3.xml", "q", "q1");
Console.WriteLine("Done!");
//41
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("41");
Console.ResetColor();
LinqXml41.LinqXml41.Main(@"XMLFile1.xml", @"XMLFile1-4.xml");
Console.WriteLine("Done!");
//51
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("51");
Console.ResetColor();
Console.Write("Generate and save xml. ");
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
new XDocument(
    new XDeclaration("1.0", "windows-1251", "yes"),
    new XElement("newRoot",
        new XElement("root",
            new XElement("date", DateTime.Now)),
        new XElement("newUtcDate", DateTime.UtcNow))
    ).Save("GeneratedXml.xml");
Console.WriteLine("Done!");
LinqXml51.LinqXml51.Main(@"GeneratedXml.xml", @"GeneratedXml-5.xml");
Console.WriteLine("Done!");
//61
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("61");
Console.ResetColor();
LinqXml61.LinqXml61.Main(@"XMLFile2.xml", @"XMLFile2-6.xml");
Console.WriteLine("Done!");
//71
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("71");
Console.ResetColor();
LinqXml71.LinqXml71.Main(@"XMLFile3.xml", @"XMLFile3-7.xml");
Console.WriteLine("Done!");
//81
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("81");
Console.ResetColor();
LinqXml81.LinqXml81.Main(@"XMLFile4.xml", @"XMLFile4-8.xml");
Console.WriteLine("Done!");

Console.Write("Press any key to close this window . . .");
Console.ReadKey();