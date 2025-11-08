# XmlBenchmark

This project benchmarks different XML reading methods in .NET using [BenchmarkDotNet](https://benchmarkdotnet.org/).

## Benchmarked Methods

- `XmlReader`
- `XDocument`
- `XmlDocument`

## How to Run

1. Build the project:
   ```
   dotnet build
   ```
2. Run the benchmarks:
   ```
   dotnet run -c Release
   ```

## Sample XML

The file `sample.xml` is used as the input for all benchmarks.

## Requirements

- .NET 9.0 SDK or later

## Output

Benchmark results will be printed to the console and saved in the `BenchmarkDotNet.Artifacts` folder.
