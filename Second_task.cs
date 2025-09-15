using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 1000;          // размер массива
            int numThreads = 4;        // количество потоков
            bool runSequential = false; // true - запустить последовательную версию
            bool runParallel = true;   // true - запустить параллельную версию


            float f = 1.789f;

            if (runSequential)
            {
                int[] a = new int[size];
                int[] b = new int[size];

                for (int i = 0; i < a.Length; i++)
                    a[i] = i;

                var stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < b.Length; i++)
                {
                    double sum = 0;
                    for (int j = 0; j <= i; j++)
                        sum += Math.Pow(a[j], f);
                    b[i] = (int)sum;
                }

                stopwatch.Stop();
                Console.WriteLine($"Последовательно: {stopwatch.ElapsedMilliseconds} ms (размер: {size})");
            }

            if (runParallel)
            {
                int[] a = new int[size];
                int[] b = new int[size];

                var options = new ParallelOptions { MaxDegreeOfParallelism = numThreads };
                var stopwatch = Stopwatch.StartNew();

                Parallel.For(0, size, options, i => a[i] = i);

                Parallel.For(0, size, options, i =>
                {
                    double sum = 0;
                    for (int j = 0; j <= i; j++)
                        sum += Math.Pow(a[j], f);
                    b[i] = (int)sum;
                });

                stopwatch.Stop();
                Console.WriteLine($"Параллельно ({numThreads} потоков): {stopwatch.ElapsedMilliseconds} ms (размер: {size})");
            }
        }
    }
}