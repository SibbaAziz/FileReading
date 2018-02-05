using System;
using System.Text;
using System.Xml;

namespace FileReading.Reading.Xml
{
    public class XmlFileReader : IFileReader
    {
        public string Read(string path)
        {
            var str = new StringBuilder();
            try
            {
                XmlTextReader reader = new XmlTextReader(path);

                if (reader == null)
                    return str.ToString();
                    
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            str.Append("<" + reader.Name);
                            str.Append(">");
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            str.Append(reader.Value);
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            str.Append("</" + reader.Name);
                            str.Append(">");
                            break;
                    }
                }

                return str.ToString();
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
