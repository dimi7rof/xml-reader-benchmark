## Results

### Large xml (100_000 rows)

| Method                     | Mean     | Error    | StdDev   | Gen0      | Allocated   |
|--------------------------- |---------:|---------:|---------:|----------:|------------:|
| 'XmlReader'                | 15.15 ms | 0.289 ms | 0.284 ms |   93.7500 |   178.31 KB |
| 'XmlReader - Stream'       | 18.36 ms | 0.365 ms | 0.512 ms |  375.0000 |  3554.87 KB |
| 'XmlReader - Async'        | 21.55 ms | 0.427 ms | 0.492 ms |   93.7500 |   238.77 KB |
| 'XPathDocument'            | 53.36 ms | 1.056 ms | 2.669 ms | 1250.0000 |  12195.6 KB |
| 'XElement - LINQ to XML'   | 54.57 ms | 1.058 ms | 1.260 ms | 2777.7778 | 14425.39 KB |
| 'XDocument - LINQ to XML'  | 57.41 ms | 1.127 ms | 2.116 ms | 2777.7778 | 14428.82 KB |
| 'XmlDocument - DOM'        | 89.20 ms | 1.931 ms | 5.350 ms | 4250.0000 | 21296.19 KB |
| 'XmlDocument - Navigator'  | 89.44 ms | 2.206 ms | 6.364 ms | 4000.0000 | 21231.46 KB |
| 'XDocument - XPath'        | 96.98 ms | 2.166 ms | 6.319 ms | 4000.0000 | 21275.65 KB |

### Small xml (15 rows)

| Method                    | Mean     | Error     | StdDev    | Gen0    | Allocated |
|-------------------------- |---------:|----------:|----------:|--------:|----------:|
| 'XmlReader'               | 2.429 us | 0.0482 us | 0.0473 us |  7.0915 |  10.85 KB |
| 'XDocument - LINQ to XML' | 3.283 us | 0.0425 us | 0.0417 us |  7.7515 |  11.91 KB |
| 'XElement - LINQ to XML'  | 3.189 us | 0.0302 us | 0.0282 us |  7.7019 |  11.84 KB |
| 'XmlDocument - DOM'       | 4.860 us | 0.0968 us | 0.1356 us | 10.0250 |  15.42 KB |
| 'XPathDocument'           | 5.489 us | 0.0729 us | 0.0810 us | 15.8691 |   24.2 KB |
| 'XmlReader - Stream'      | 2.178 us | 0.0381 us | 0.0357 us |  2.5597 |   3.92 KB |
| 'XDocument - XPath'       | 4.383 us | 0.0560 us | 0.0468 us |  9.2545 |  14.23 KB |
| 'XmlDocument - Navigator' | 4.559 us | 0.0901 us | 0.1001 us |  9.9792 |   15.3 KB |
| 'XmlReader - Async'       | 6.435 us | 0.1208 us | 0.0943 us | 43.4723 |  66.99 KB |

### Legend

  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)