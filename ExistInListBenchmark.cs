using BenchmarkDotNet.Attributes;
using System.Xml;

namespace XmlBenchmark;

//| Method                             | Mean          | Error       | StdDev        | Gen0    | Allocated |
//|----------------------------------- |--------------:|------------:|--------------:|--------:|----------:|
//| 'LINQ Exists'                      |      3.013 ns |   0.0745 ns |     0.0697 ns |       - |         - |
//| 'LINQ Any'                         |      6.000 ns |   0.1561 ns |     0.1533 ns |       - |         - |
//| 'LINQ FirstOrDefault'              |      6.688 ns |   0.1117 ns |     0.0990 ns |       - |         - |
//| 'foreach Equals'                   |  3,316.318 ns |  42.8931 ns |    35.8177 ns |       - |         - |
//| 'foreach Equals Ordinal'           |  3,321.247 ns |  40.6089 ns |    31.7048 ns |       - |         - |
//| 'foreach == '                      |  3,543.234 ns |  70.4720 ns |    86.5459 ns |       - |         - |
//| 'foreach Equals OrdinalIgnoreCase' |  3,748.694 ns |  34.1304 ns |    31.9256 ns |       - |         - |
//| 'LINQ ToHashSet Any'               | 50,362.119 ns | 821.6222 ns | 1,178.3462 ns | 29.3579 |   46968 B |

[MemoryDiagnoser]

public class ExistInListBenchmark
{
    private List<string> data = [];

    [GlobalSetup]
    public void Setup()
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
            NameTable = null
        };

        using var reader = XmlReader.Create(new StringReader(Xmls.LargeXml), settings);

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
            {
                if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                {
                    var dbValue = reader.ReadContentAsString();
                    if (dbValue != null) list.Add(dbValue);
                }
            }
        }

        data = list;
    }

    [Benchmark(Description = "foreach == ")]
    public bool V1()
    {
        var isValid = true;
        foreach (var item in data)
        {
            if (item == "MEDLINE")
            {
                isValid = true;
            }
        }
        return isValid;
    }

    [Benchmark(Description = "foreach Equals")]
    public bool V2()
    {
        var isValid = true;
        foreach (var item in data)
        {
            if (item.Equals("MEDLINE"))
            {
                isValid = true;
            }
        }
        return isValid;
    }

    [Benchmark(Description = "foreach Equals OrdinalIgnoreCase")]
    public bool V3()
    {
        var isValid = true;
        foreach (var item in data)
        {
            if (item.Equals("MEDLINE", StringComparison.OrdinalIgnoreCase))
            {
                isValid = true;
            }
        }
        return isValid;
    }

    [Benchmark(Description = "foreach Equals Ordinal")]
    public bool V4()
    {
        var isValid = true;
        foreach (var item in data)
        {
            if (item.Equals("MEDLINE", StringComparison.Ordinal))
            {
                isValid = true;
            }
        }
        return isValid;
    }

    [Benchmark(Description = "LINQ Any")]
    public bool V5()
    {
        var isValid = data.Any(x => x.Equals("MEDLINE", StringComparison.Ordinal));
        return isValid;
    }

    [Benchmark(Description = "LINQ Exists")]
    public bool V6()
    {
        var isValid = data.Exists(x => x.Equals("MEDLINE", StringComparison.Ordinal));
        return isValid;
    }

    [Benchmark(Description = "LINQ ToHashSet Any")]
    public bool V7()
    {
        var isValid = data.ToHashSet().Any(x => x.Equals("MEDLINE", StringComparison.Ordinal));
        return isValid;
    }

    [Benchmark(Description = "LINQ FirstOrDefault")]
    public bool V8()
    {
        var isValid = data.FirstOrDefault(x => x.Equals("MEDLINE", StringComparison.Ordinal));
        return isValid is not null;
    }
}
