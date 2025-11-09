using BenchmarkDotNet.Attributes;
using System.Text;

namespace XmlBenchmark;

[MemoryDiagnoser]
public class XmlReadBenchmarks
{
    private string xml = "";

    [GlobalSetup]
    public void Setup()
    {
        //xml = Xmls.SmallXml;
        xml = Xmls.LargeXml;
    }

    [Benchmark(Description = "ReadOnlySpan")]
    public List<string> V17() => XmlSpanReader.ExtractDbValues(xml);

    [Benchmark(Description = "ReadOnlySpanV2")]
    public List<string> V20() => XmlSpanReader.ExtractDbValuesV2(xml);

    //[Benchmark(Description = "Unsafe")]
    //public List<string> V18() => UltraFastDbExtractorUnsafe.ExtractDbValuesUnsafe(xml);

    //[Benchmark(Description = "Simd")]
    //public List<string> V19() => DbSimdExtractor.Extract(Encoding.UTF8.GetBytes(xml));

    //[Benchmark(Description = "XmlReader ReadContentAsString Equals Ordinal")]
    //public List<string> V1()
    //    => XmlReaders.V1_XmlReaderReadContentAsStringEqualsOrdinal(xml);

    //[Benchmark(Description = "XmlReader ReadContentAsString")]
    //public List<string> V2() => XmlReaders.V2_XmlReaderReadContentAsString(xml);

    //[Benchmark(Description = "XmlReader static settings ReferenceEquals")]
    //public List<string> V16_GetDbValues()
    //    => XmlReaders.V16_GetDbValues(xml);

    //[Benchmark(Description = "IEnumerable ToList Async")]
    //public List<string> V12_IEnumerableXmlReaderStingReaderSettingsAsyncToList()
    //    => [.. XmlReaders.V12_IEnumerableXmlReaderStingReaderSettingsAsync(xml)];

    //[Benchmark(Description = "XmlReader - StringReader")]
    //public List<string> V2_XmlReaderStingReader()
    //    => XmlReaders.V2_XmlReaderStingReader(xml);

    //[Benchmark(Description = "XmlReader StringReader Settings Async")]
    //public List<string> V11_XmlReaderStingReaderSettingsAsync()
    //    => XmlReaders.V11_XmlReaderStingReaderSettingsAsync(xml);

    //[Benchmark(Description = "XmlReader - StringReader + Settings")]
    //public List<string> V1_XmlReaderStingReaderSettings()
    //    => XmlReaders.V1_XmlReaderStingReaderSettings(xml);

    //[Benchmark(Description = "XmlReader - MemoryStream")]
    //public List<string> V7_XmlReaderMemoryStream()
    //    => XmlReaders.V7_XmlReaderMemoryStream(xml);

    //[Benchmark(Description = "XmlReader - StringReader + Async")]
    //public Task<List<string>> V10_XmlReaderStingReaderAsync()
    //    => XmlReaders.V10_XmlReaderStingReaderAsync(xml);

    //[Benchmark(Description = "XPathDocument")]
    //public List<string> V6_XPathDocumentStingReader()
    //    => XmlReaders.V6_XPathDocumentStingReader(xml);

    //[Benchmark(Description = "XDocument - LINQ")]
    //public List<string> V3_XDocument() => XmlReaders.V3_XDocument(xml);

    //[Benchmark(Description = "XElement - LINQ")]
    //public List<string> V4_XElement() => XmlReaders.V4_XElement(xml);

    //[Benchmark(Description = "XmlDocument - Navigator")]
    //public List<string> V9_XmlDocumentNavigator()
    //    => XmlReaders.V9_XmlDocumentNavigator(xml);

    //[Benchmark(Description = "XmlDocument - DOM")]
    //public List<string> V5_XmlDocument() => XmlReaders.V5_XmlDocument(xml);

    //[Benchmark(Description = "XDocument - XPath")]
    //public List<string> V8_XDocumentXPath() => XmlReaders.V8_XDocumentXPath(xml);
}