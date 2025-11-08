using BenchmarkDotNet.Attributes;

namespace XmlBenchmark;

[MemoryDiagnoser]
public class XmlReadBenchmarks
{
    private string xml;

    [GlobalSetup]
    public void Setup()
    {
        xml = Xmls.SmallXml;
    }

    [Benchmark(Description = "XmlReader")]
    public int ReadWithXmlReader()
    {
        return XmlReaders.ReadWithXmlReader(xml);
    }

    [Benchmark(Description = "XDocument - LINQ to XML")]
    public int ReadWithXDocument()
    {
        return XmlReaders.ReadWithXDocument(xml);
    }

    [Benchmark(Description = "XElement - LINQ to XML")]
    public int ReadWithXElement()
    {
        return XmlReaders.ReadWithXElement(xml);
    }

    [Benchmark(Description = "XmlDocument - DOM")]
    public int ReadWithXmlDocument()
    {
        return XmlReaders.ReadWithXmlDocument(xml);
    }

    [Benchmark(Description = "XPathDocument")]
    public int ReadWithXPathDocument()
    {
        return XmlReaders.ReadWithXPathDocument(xml);
    }

    [Benchmark(Description = "XmlReader - Stream")]
    public int ReadWithXmlReaderStream()
    {
        return XmlReaders.ReadWithXmlReaderStream(xml);
    }

    [Benchmark(Description = "XDocument - XPath")]
    public int ReadWithXDocumentXPath()
    {
        return XmlReaders.ReadWithXDocumentXPath(xml);
    }

    [Benchmark(Description = "XmlDocument - Navigator")]
    public int ReadWithXmlDocumentNavigator()
    {
        return XmlReaders.ReadWithXmlDocumentNavigator(xml);
    }

    [Benchmark(Description = "XmlReader - Async")]
    public Task<int> ReadWithXmlReaderAsync()
    {
        return XmlReaders.ReadWithXmlReaderAsync(xml);
    }
}