using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ConsoleAppParsing.ServiseRestApi.XmlConfig
{
    class XmlSettings
    {
        XmlDocument xmlDoc = new XmlDocument();
        private readonly string xmlFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\ServiseRestApi\XmlConfig\ServiseConfig.xml";
        private readonly string CSVFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\Options.csv";
        private DateTime _dateTime = new DateTime();
        //отображение данных файла xml
        public void GetXML()
        {
            xmlDoc.Load(xmlFilePath);
            XmlElement xmlElement = xmlDoc.DocumentElement;
            foreach (XmlNode xmlNode in xmlElement)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    XmlNode attr = xmlNode.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        Console.WriteLine(attr.Value);
                    }
                }
                foreach (XmlNode cldnode in xmlNode.ChildNodes)
                {
                    if (cldnode.Name == "type")
                    {
                        Console.WriteLine($"type: {cldnode.InnerText}");
                    }
                }
            }
        }
        //Заполнение данные файла xml
        public void Save(string typeName)
        {
            string tpName = typeName;
            _dateTime = DateTime.Now;
            xmlDoc.Load(xmlFilePath);
            XmlElement xmlElement = xmlDoc.DocumentElement;
            XmlElement filesElement = xmlDoc.CreateElement("files");
            XmlAttribute nameAttr = xmlDoc.CreateAttribute("name");
            XmlElement typeElement = xmlDoc.CreateElement("type");
            if(tpName == "wb")
            {
                XmlText nameText = xmlDoc.CreateTextNode($"Bonds_{_dateTime}");
                XmlText typeText = xmlDoc.CreateTextNode("wb");
                nameAttr.AppendChild(nameText);
                typeElement.AppendChild(typeText);
                filesElement.Attributes.Append(nameAttr);
                filesElement.AppendChild(typeElement);
                xmlElement.AppendChild(filesElement);
            }
            if(tpName == "jse")
            {
                XmlText nameText = xmlDoc.CreateTextNode($"Oprions_{_dateTime}");
                XmlText typeText = xmlDoc.CreateTextNode("jse");
                nameAttr.AppendChild(nameText);
                typeElement.AppendChild(typeText);
                filesElement.Attributes.Append(nameAttr);
                filesElement.AppendChild(typeElement);
                xmlElement.AppendChild(filesElement);
            }
            xmlDoc.Save(xmlFilePath);
        }
    }
}
