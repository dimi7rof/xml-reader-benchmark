using BenchmarkDotNet.Running;
using XmlBenchmark;

var summary = BenchmarkRunner.Run<XmlReadBenchmarks>();
