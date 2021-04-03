using System.Collections.Immutable;
using System.IO;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

namespace OutSystems.Logging.Benchmarks
{
    class Program
    {
        public static void Main(string[] args) => BenchmarkRunner.Run(typeof(Program).Assembly, Config);

        // https://github.com/dotnet/performance/blob/51d8f8483b139bb1edde97f917fa436671693f6f/src/harness/BenchmarkDotNet.Extensions/RecommendedConfig.cs#L17-L20
        public static IConfig Config => DefaultConfig.Instance
            .With(ConfigOptions.JoinSummary)
            .With(Job.Default
                .WithWarmupCount(1) // 1 warmup is enough for our purpose
                .WithIterationTime(TimeInterval.FromMilliseconds(250)) // the default is 0.5s per iteration, which is slighlty too much for us
                .WithMinIterationCount(1)
                .WithMaxIterationCount(10)
                .AsDefault()) // tell BDN that this are our default settings
            .With(MemoryDiagnoser.Default) // MemoryDiagnoser is enabled by default
            .With(JsonExporter.Full) // make sure we export to Json (for BenchView integration purpose)
            .With(StatisticColumn.Median, StatisticColumn.Min, StatisticColumn.Max);
    }
}
