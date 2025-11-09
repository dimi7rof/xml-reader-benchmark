## Results

### Large xml (100_000 rows)

| Method                                         | Mean        | Error       | StdDev      | Median      | Gen0      | Gen1      | Gen2     | Allocated   |
|----------------------------------------------- |------------:|------------:|------------:|------------:|----------:|----------:|---------:|------------:|
| ReadOnlySpanV2								 |    569.2 us |     9.88 us |     8.76 us |           - |   89.8438 |         - |        - |   141.61 KB |
| ReadOnlySpan									 |    598.5 us |     9.39 us |     8.32 us |           - |   89.8438 |         - |        - |   141.61 KB |
| Unsafe                                         |  2,877.4 us |    40.47 us |    33.80 us |  2,884.1 us |   70.3125 |   15.6250 |        - |   143.63 KB |
| Simd                                           |  6,049.4 us |   115.54 us |   158.16 us |  6,017.3 us |  406.2500 |  320.3125 | 320.3125 |  3507.43 KB |
| 'XmlReader ReadContentAsString'                | 13,953.1 us |   239.63 us |   200.10 us | 13,959.0 us |   78.1250 |   15.6250 |        - |   175.57 KB |
| 'XmlReader - StringReader'                     | 14,140.5 us |   188.13 us |   319.46 us | 14,093.8 us |   78.1250 |   15.6250 |        - |   178.31 KB |
| 'XmlReader static settings ReferenceEquals'    | 14,269.0 us |   184.93 us |   163.94 us | 14,221.3 us |   62.5000 |   15.6250 |        - |   173.34 KB |
| 'XmlReader StringReader Settings Async'        | 14,337.1 us |   225.20 us |   199.64 us | 14,247.0 us |   78.1250 |   15.6250 |        - |   222.77 KB |
| 'XmlReader - StringReader + Settings'          | 14,381.9 us |   286.43 us |   445.93 us | 14,370.0 us |   31.2500 |         - |        - |   175.57 KB |
| 'IEnumerable ToList Async'                     | 14,814.8 us |   287.52 us |   331.11 us | 14,713.5 us |   93.7500 |   31.2500 |        - |   222.78 KB |
| 'XmlReader ReadContentAsString Equals Ordinal' | 15,020.1 us |   283.87 us |   265.54 us | 15,008.6 us |   78.1250 |   15.6250 |        - |   175.57 KB |
| 'XmlReader - MemoryStream'                     | 18,150.8 us |   354.71 us |   508.72 us | 18,108.5 us |  343.7500 |  281.2500 | 281.2500 |  3554.64 KB |
| 'XmlReader - StringReader + Async'             | 20,461.5 us |   285.79 us |   436.43 us | 20,393.6 us |   93.7500 |         - |        - |   238.78 KB |
| XPathDocument                                  | 52,504.9 us | 1,048.35 us | 1,943.19 us | 52,604.5 us | 1444.4444 | 1000.0000 | 444.4444 | 12195.78 KB |
| 'XDocument - LINQ'                             | 57,787.3 us | 1,147.35 us | 3,022.59 us | 57,547.8 us | 2875.0000 | 1750.0000 | 625.0000 | 14407.88 KB |
| 'XElement - LINQ'                              | 63,132.7 us | 3,203.22 us | 9,293.12 us | 59,965.4 us | 2875.0000 | 1750.0000 | 625.0000 | 14407.53 KB |
| 'XmlDocument - Navigator'                      | 88,791.2 us | 1,772.95 us | 4,315.60 us | 89,194.8 us | 4000.0000 | 2333.3333 | 666.6667 | 21231.97 KB |
| 'XmlDocument - DOM'                            | 91,904.3 us | 1,816.05 us | 4,522.61 us | 92,523.6 us | 4250.0000 | 2500.0000 | 750.0000 | 21297.04 KB |
| 'XDocument - XPath'                            | 97,131.2 us | 2,736.34 us | 7,806.94 us | 97,753.1 us | 4000.0000 | 2250.0000 | 750.0000 | 21241.24 KB |

### Small xml (15 rows)

| Method                                         | Mean     | Error     | StdDev    | Gen0    | Allocated |
|----------------------------------------------- |---------:|----------:|----------:|--------:|----------:|
| 'XmlReader - MemoryStream'                     | 2.177 us | 0.0391 us | 0.0435 us |  2.5597 |   3.92 KB |
| 'XmlReader ReadContentAsString'                | 2.251 us | 0.0374 us | 0.0430 us |  7.0915 |  10.88 KB |
| 'XmlReader - StringReader'                     | 2.302 us | 0.0461 us | 0.0473 us |  7.0915 |  10.85 KB |
| 'XmlReader ReadContentAsString Equals Ordinal' | 2.313 us | 0.0438 us | 0.0410 us |  7.0915 |  10.88 KB |
| 'XmlReader - StringReader + Settings'          | 2.387 us | 0.0472 us | 0.0525 us |  7.1411 |  10.95 KB |
| 'XElement - LINQ'                              | 3.191 us | 0.0421 us | 0.0394 us |  7.7019 |  11.84 KB |
| 'XDocument - LINQ'                             | 3.263 us | 0.0404 us | 0.0358 us |  7.7515 |  11.91 KB |
| 'XDocument - XPath'                            | 4.360 us | 0.0816 us | 0.0763 us |  9.2545 |  14.23 KB |
| 'XmlDocument - Navigator'                      | 4.597 us | 0.0741 us | 0.1278 us |  9.9792 |   15.3 KB |
| 'XmlDocument - DOM'                            | 4.909 us | 0.0940 us | 0.1255 us |  9.9945 |  15.35 KB |
| XPathDocument                                  | 5.542 us | 0.0890 us | 0.0743 us | 15.8691 |   24.2 KB |
| 'XmlReader StringReader Settings Async'        | 5.660 us | 0.0592 us | 0.0524 us | 43.4723 |  66.92 KB |
| 'IEnumerable ToList Async'                     | 5.676 us | 0.1076 us | 0.1007 us | 43.4723 |  66.98 KB |
| 'XmlReader - StringReader + Async'             | 6.470 us | 0.0770 us | 0.0720 us | 43.4723 |  67.06 KB |

### Legend
```
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Gen1      : GC Generation 1 collects per 1000 operations
  Gen2      : GC Generation 2 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)
  1 ms      : 1 Millisecond (0.001 sec)
```

### * Summary *

BenchmarkDotNet v0.15.6, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i3-4170 CPU 3.70GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.306