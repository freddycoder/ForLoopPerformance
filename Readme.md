``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1348 (20H2/October2020Update)
Intel Core i7-2670QM CPU 2.20GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET Core 3.1.21 (CoreCLR 4.700.21.51404, CoreFX 4.700.21.51508), X64 RyuJIT
  DefaultJob : .NET Core 3.1.21 (CoreCLR 4.700.21.51404, CoreFX 4.700.21.51508), X64 RyuJIT


```
|                      Method |       Mean |    Error |   StdDev |
|---------------------------- |-----------:|---------:|---------:|
| ParallelForNoInitialisation |         NA |       NA |       NA |
|   ParallelForInitialisation | 8,259.6 ns | 87.33 ns | 72.92 ns |
|            ParallelForArray | 6,653.0 ns | 97.91 ns | 91.58 ns |
|            EnumerableToList | 1,083.1 ns |  3.08 ns |  2.40 ns |
|           EnumerableToArray |   930.4 ns | 18.60 ns | 18.27 ns |

Benchmarks with issues:
  ForLoopPerformance.ParallelForNoInitialisation: DefaultJob
