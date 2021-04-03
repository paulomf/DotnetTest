using BenchmarkDotNet.Attributes;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarks
{
    public class Class1Benchmarks
    {
        [Benchmark]
        public void Sleep10ms() => Class1.MySleep(10);

        [Benchmark]
        public void Sleep20ms() => Class1.MySleep(20);
    }
}
