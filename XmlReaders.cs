using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlBenchmark;

public static class XmlReaders
{
    public static List<string> V1_XmlReaderStingReaderSettings(string xml)
    {
        var list = new List<string>();
        var settings = new XmlReaderSettings
        {
            IgnoreWhitespace = true,
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            DtdProcessing = DtdProcessing.Prohibit,
            CheckCharacters = false,
            CloseInput = false
        };

        using var reader = XmlReader.Create(new StringReader(xml), settings);

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                {
                    var dbValue = reader.Value;
                    if (dbValue != null) list.Add(dbValue);
                }
            }
        }

        return list;
    }

    public static List<string> V2_XmlReaderStingReader(string xml)
    {
        var list = new List<string>();
        using var stringReader = new StringReader(xml);
        using var reader = XmlReader.Create(stringReader);
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                {
                    var dbValue = reader.Value;
                    if (dbValue != null) list.Add(dbValue);
                }
            }
        }
        return list;
    }

    public static List<string> V3_XDocument(string xml)
    {
        var list = XDocument.Parse(xml)
            .Root?
            .Elements("Entry")
            .Elements("Ref")
            .Elements("DB")
            .Select(db => db.Value)
            .Where(value => value != null)
            .ToList() ?? [];

        return list;
    }

    public static List<string> V4_XElement(string xml)
    {
        var list = XElement.Parse(xml)
            .Elements("Entry")
            .Elements("Ref")
            .Elements("DB")
            .Select(db => db.Value)
            .Where(value => value != null)
            .ToList() ?? [];

        return list;
    }

    public static List<string> V5_XmlDocument(string xml)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml);
        var list = new List<string>();
        var nodes = doc.SelectNodes("/root/Entry/Ref/DB");
        if (nodes != null)
        {
            foreach (XmlNode node in nodes)
            {
                var value = node.InnerText;
                if (value != null)
                {
                    list.Add(value);
                }
            }
        }
        return list;
    }

    public static List<string> V6_XPathDocumentStingReader(string xml)
    {
        using var stringReader = new StringReader(xml);
        var doc = new XPathDocument(stringReader);
        var navigator = doc.CreateNavigator();
        var nodes = navigator.Select("/root/Entry/Ref/DB");
        var list = new List<string>();
        
        while (nodes.MoveNext())
        {
            var value = nodes.Current?.Value;
            if (value != null)
            {
                list.Add(value);
            }
        }

        return list;
    }

    public static List<string> V7_XmlReaderMemoryStream(string xml)
    {
        var list = new List<string>();
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
        using var reader = XmlReader.Create(stream);
        
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                var value = reader.ReadElementContentAsString();
                if (!string.IsNullOrEmpty(value))
                {
                    list.Add(value);
                }
            }
        }

        return list;
    }

    public static List<string> V8_XDocumentXPath(string xml)
    {
        var doc = XDocument.Parse(xml);
        var list = doc.XPathSelectElements("//DB")
            .Select(element => element.Value)
            .Where(value => value != null)
            .ToList();
            
        return list;
    }

    public static List<string> V9_XmlDocumentNavigator(string xml)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml);
        var navigator = doc.CreateNavigator();
        var nodes = navigator!.Select("/root/Entry/Ref/DB");
        var list = new List<string>();
        
        while (nodes!.MoveNext())
        {
            var value = nodes.Current?.Value;
            if (value != null)
            {
                list.Add(value);
            }
        }
        return list;
    }

    public static async Task<List<string>> V10_XmlReaderStingReaderAsync(string xml)
    {
        var list = new List<string>();
        using var stringReader = new StringReader(xml);
        var settings = new XmlReaderSettings { Async = true };
        using var reader = XmlReader.Create(stringReader, settings);
        
        while (await reader.ReadAsync())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                if (await reader.ReadAsync() && reader.NodeType == XmlNodeType.Text)
                {
                    var dbValue = reader.Value;
                    if (dbValue != null) list.Add(dbValue);
                }
            }
        }

        return list;
    }

    public static List<string> V11_XmlReaderStingReaderSettingsAsync(string xml)
    {
        var list = new List<string>();
        var settings = new XmlReaderSettings
        {
            IgnoreWhitespace = true,
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            DtdProcessing = DtdProcessing.Prohibit,
            CheckCharacters = false,
            CloseInput = false,
            Async = true
        };

        using var reader = XmlReader.Create(new StringReader(xml), settings);

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                {
                    var dbValue = reader.Value;
                    if (dbValue != null) list.Add(dbValue);
                }
            }
        }

        return list;
    }

    public static IEnumerable<string> V12_IEnumerableXmlReaderStingReaderSettingsAsync(string xml)
    {
        var list = new List<string>();
        var settings = new XmlReaderSettings
        {
            IgnoreWhitespace = true,
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            DtdProcessing = DtdProcessing.Prohibit,
            CheckCharacters = false,
            CloseInput = false,
            Async = true
        };

        using var reader = XmlReader.Create(new StringReader(xml), settings);

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                {
                    var dbValue = reader.Value;
                    if (dbValue != null)
                    {
                        yield return dbValue;
                    }
                }
            }
        }
    }
}