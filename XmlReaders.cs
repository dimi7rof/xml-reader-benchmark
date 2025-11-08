using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlBenchmark;

public static class XmlReaders
{
    public static int ReadWithXmlReader(string xml)
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
        return list.Count;
    }

    public static int ReadWithXDocument(string xml)
    {
        var list = XDocument.Parse(xml)
            .Root?
            .Elements("Entry")
            .Elements("Ref")
            .Elements("DB")
            .Select(db => db.Value)
            .Where(value => value != null)
            .ToList() ?? [];

        return list.Count;
    }

    public static int ReadWithXElement(string xml)
    {
        var list = XElement.Parse(xml)
            .Elements("Entry")
            .Elements("Ref")
            .Elements("DB")
            .Select(db => db.Value)
            .Where(value => value != null)
            .ToList() ?? [];

        return list.Count;
    }

    public static int ReadWithXmlDocument(string xml)
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
        return list.Count;
    }

    // New method using XPathDocument - optimized for XPath queries
    public static int ReadWithXPathDocument(string xml)
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
        return list.Count;
    }

    // New method using XmlReader with Stream
    public static int ReadWithXmlReaderStream(string xml)
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
        return list.Count;
    }

    // New method using XDocument with XPath
    public static int ReadWithXDocumentXPath(string xml)
    {
        var doc = XDocument.Parse(xml);
        var list = doc.XPathSelectElements("//DB")
            .Select(element => element.Value)
            .Where(value => value != null)
            .ToList();
            
        return list.Count;
    }

    // New method using XmlDocument with XPath navigator
    public static int ReadWithXmlDocumentNavigator(string xml)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml);
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
        return list.Count;
    }

    // New method using async streaming approach
    public static async Task<int> ReadWithXmlReaderAsync(string xml)
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
        return list.Count;
    }
}