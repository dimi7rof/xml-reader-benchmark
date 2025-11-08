## Results

### Large xml (100_000 rows)

| Method                                  | Mean     | Error    | StdDev   | Median   | Gen0      | Gen1      | Gen2     | Allocated   |
|-----------------------------------------|---------:|---------:|---------:|---------:|----------:|----------:|---------:|------------:|
| 'XmlReader StringReader Settings Async' | 14.39 ms | 0.146 ms | 0.122 ms | 14.40 ms |   78.1250 |   15.6250 |        - |   222.77 KB |
| 'IEnumerable ToList Async'              | 14.88 ms | 0.294 ms | 0.314 ms | 14.91 ms |   93.7500 |   31.2500 |        - |   222.78 KB |
| 'XmlReader - StringReader + Settings'   | 14.93 ms | 0.279 ms | 0.451 ms | 14.87 ms |   62.5000 |         - |        - |   175.57 KB |
| 'XmlReader - StringReader'              | 14.95 ms | 0.291 ms | 0.444 ms | 14.94 ms |   78.1250 |   15.6250 |        - |   178.31 KB |
| 'XmlReader - MemoryStream'              | 18.86 ms | 0.374 ms | 0.594 ms | 18.97 ms |  375.0000 |  281.2500 | 281.2500 |  3554.87 KB |
| 'XmlReader - StringReader + Async'      | 20.69 ms | 0.396 ms | 0.456 ms | 20.61 ms |   93.7500 |         - |        - |   238.77 KB |
| XPathDocument                           | 53.36 ms | 1.063 ms | 2.648 ms | 53.85 ms | 1500.0000 | 1000.0000 | 500.0000 |  12196.2 KB |
| 'XDocument - LINQ'                      | 56.86 ms | 1.129 ms | 2.834 ms | 56.62 ms | 2750.0000 | 1750.0000 | 625.0000 | 14408.26 KB |
| 'XElement - LINQ'                       | 56.77 ms | 1.126 ms | 2.423 ms | 56.31 ms | 2875.0000 | 1625.0000 | 500.0000 | 14408.12 KB |
| 'XmlDocument - DOM'                     | 96.82 ms | 3.022 ms | 8.814 ms | 94.42 ms | 4000.0000 | 2250.0000 | 750.0000 | 21296.23 KB |
| 'XmlDocument - Navigator'               | 93.17 ms | 2.022 ms | 5.802 ms | 93.27 ms | 4000.0000 | 2250.0000 | 750.0000 | 21232.69 KB |
| 'XDocument - XPath'                     | 97.54 ms | 2.125 ms | 6.198 ms | 98.09 ms | 4000.0000 | 2333.3333 | 666.6667 | 21241.99 KB |

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