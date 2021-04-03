using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ClassLibrary1
{
    public class Class1
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MySleep(int i) => Thread.Sleep(i*5);
    }
}
