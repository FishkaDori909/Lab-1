using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Csharp
{
    internal class Program
    {
        static void Posledov_Massive(string[] args)
        {
            int[] a = new int[21];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
                Console.WriteLine(a[i]);
            }

            int[] b = new int[21];
            float f = 1.789f;
            for (int i = 0; i < b.Length; i++) {
                double sum = 0;
                for (int j = 0; j <= i; j++)
                {
                    sum += Math.Pow(a[j], f);
                }
                b[i] = (int)sum;
                Console.WriteLine(b[i]);
            }
        }
        static void Parallel_Massive(string[] args)
        {

            int size = 1000;
            int[] array = new int[size];

            int numThreads = 4; // количество потоков
            int chunkSize = size / numThreads; // сколько элементов на поток

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.For(0, numThreads, threadIndex =>
            {
                int start = threadIndex * chunkSize;
                int end = (threadIndex == numThreads - 1) ? size : start + chunkSize;

                for (int i = start; i < end; i++)
                {
                    array[i] = i;
                }
            });

            stopwatch.Stop();

            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} ms");
        }
        static void Main(string[] args)
        {
            //Posledov_Massive(args);
            Parallel_Massive(args);
            
        }
        
    }
}
