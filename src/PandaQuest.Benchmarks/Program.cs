using BenchmarkDotNet.Running;
using PandaQuest.Benchmarks.Generators;
using PandaQuest.Benchmarks.Physics;

BenchmarkRunner.Run<InfiniteWorldGeneratorBenchmarks>();
//BenchmarkRunner.Run<OverworldPhysicsBenchmarks>();