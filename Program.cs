using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForLoopPerformance
{
    [MarkdownExporter]
    public class ForLoopPerformance
    {
        private object[] _array;

        public ForLoopPerformance()
        {
            _array = new object[100];
        }

        [Benchmark]
        public List<object> ParallelForNoInitialisation()
        {
            var list = new List<object>();

            Parallel.ForEach(_array, (obj) =>
            {
                list.Add(obj);
            });

            return list;
        }

        [Benchmark]
        public List<object> ParallelForInitialisation()
        {
            var list = new List<object>(_array.Length);

            Parallel.ForEach(_array, (obj) =>
            {
                list.Add(obj);
            });

            return list;
        }

        [Benchmark]
        public object[] ParallelForArray()
        {
            var list = new object[_array.Length];

            Parallel.For(0, _array.Length, (i) =>
            {
                list[i] = _array[i];
            });

            return list;
        }

        [Benchmark]
        public List<object> EnumerableToList()
        {
            return _array.Select(a => a).ToList();
        }

        [Benchmark]
        public object[] EnumerableToArray()
        {
            return _array.Select(a => a).ToArray();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
