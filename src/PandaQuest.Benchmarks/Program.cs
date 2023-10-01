using BenchmarkDotNet.Running;
using PandaQuest.Benchmarks.Generators;

BenchmarkRunner.Run<InfiniteWorldGeneratorBenchmarks>();

// For breakpoint.
_ = 1;