using BenchmarkDotNet.Attributes;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarks
{
    public class Class1Benchmarks2
    {
        [Benchmark]
        public void Sleep15ms() => Class1.MySleep(15);

        [Benchmark]
        public void Sleep25ms() => Class1.MySleep(25);
    }
}
