## Results

### Large xml (100_000 rows)

| Method                                         | Mean     | Error    | StdDev   | Median   | Gen0      | Gen1      | Gen2      | Allocated   |
|----------------------------------------------- |---------:|---------:|---------:|---------:|----------:|----------:|----------:|------------:|
| 'XmlReader ReadContentAsString Equals Ordinal' | 14.17 ms | 0.282 ms | 0.289 ms | 14.12 ms |   93.7500 |         - |         - |   175.57 KB |
| 'XmlReader ReadContentAsString'                | 14.27 ms | 0.207 ms | 0.173 ms | 14.31 ms |   78.1250 |   15.6250 |         - |   175.57 KB |
| 'IEnumerable ToList Async'                     | 14.71 ms | 0.165 ms | 0.155 ms | 14.68 ms |   78.1250 |   15.6250 |         - |   222.78 KB |
| 'XmlReader - StringReader'                     | 14.76 ms | 0.203 ms | 0.249 ms | 14.71 ms |   78.1250 |   15.6250 |         - |   178.31 KB |
| 'XmlReader StringReader Settings Async'        | 14.80 ms | 0.281 ms | 0.300 ms | 14.72 ms |   93.7500 |   31.2500 |         - |   222.76 KB |
| 'XmlReader - StringReader + Settings'          | 15.98 ms | 0.829 ms | 2.298 ms | 15.03 ms |   31.2500 |         - |         - |   175.57 KB |
| 'XmlReader - MemoryStream'                     | 18.14 ms | 0.357 ms | 0.451 ms | 18.18 ms |  375.0000 |  281.2500 |  281.2500 |  3554.87 KB |
| 'XmlReader - StringReader + Async'             | 20.18 ms | 0.357 ms | 0.298 ms | 20.14 ms |   93.7500 |         - |         - |   238.83 KB |
| XPathDocument                                  | 49.06 ms | 0.967 ms | 2.317 ms | 49.49 ms | 1250.0000 |  750.0000 |  250.0000 |  12195.9 KB |
| 'XDocument - LINQ'                             | 56.78 ms | 1.092 ms | 2.553 ms | 56.76 ms | 2875.0000 | 1750.0000 |  625.0000 | 14407.85 KB |
| 'XElement - LINQ'                              | 57.27 ms | 1.139 ms | 2.024 ms | 56.93 ms | 2875.0000 | 1750.0000 |  625.0000 | 14409.32 KB |
| 'XmlDocument - Navigator'                      | 88.98 ms | 2.046 ms | 5.635 ms | 88.92 ms | 4000.0000 | 2333.3333 |  666.6667 | 21231.36 KB |
| 'XmlDocument - DOM'                            | 89.92 ms | 1.797 ms | 5.186 ms | 88.83 ms | 4250.0000 | 2500.0000 |  750.0000 | 21295.75 KB |
| 'XDocument - XPath'                            | 93.86 ms | 2.219 ms | 6.472 ms | 93.09 ms | 4000.0000 | 2666.6667 | 1000.0000 | 21242.15 KB |

### Small xml (15 rows)

| Method                                  | Mean     | Error     | StdDev    | Gen0    | Allocated |
|-----------------------------------------|---------:|----------:|----------:|--------:|----------:|
| 'XmlReader - MemoryStream'              | 2.158 us | 0.0431 us | 0.0403 us |  2.5597 |   3.92 KB |
| 'XmlReader - StringReader'              | 2.312 us | 0.0398 us | 0.0333 us |  7.0915 |  10.85 KB |
| 'XmlReader - StringReader + Settings'   | 2.434 us | 0.0459 us | 0.0597 us |  7.1411 |  10.95 KB |
| 'XElement - LINQ'                       | 3.203 us | 0.0555 us | 0.0492 us |  7.7515 |  11.85 KB |
| 'XDocument - LINQ'                      | 3.291 us | 0.0321 us | 0.0268 us |  7.7515 |  11.91 KB |
| 'XDocument - XPath'                     | 4.459 us | 0.0885 us | 0.0909 us |  9.2545 |  14.23 KB |
| 'XmlDocument - Navigator'               | 4.799 us | 0.0948 us | 0.2000 us |  9.8877 |  15.23 KB |
| 'XmlDocument - DOM'                     | 4.841 us | 0.0965 us | 0.1444 us | 10.0250 |  15.42 KB |
| XPathDocument                           | 5.607 us | 0.0704 us | 0.0588 us | 15.8691 |   24.2 KB |
| 'IEnumerable ToList Async'              | 5.684 us | 0.1013 us | 0.0898 us | 43.4723 |  66.98 KB |
| 'XmlReader StringReader Settings Async' | 5.725 us | 0.1133 us | 0.1004 us | 43.4723 |  66.92 KB |
| 'XmlReader - StringReader + Async'      | 6.485 us | 0.0894 us | 0.0793 us | 43.4723 |  67.06 KB |

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