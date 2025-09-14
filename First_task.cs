using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = 100;
            List<TimeSpan> times = new List<TimeSpan>();
            for (int k = 0; k <= iterations; k++)
            {
                double[,] a = new double[10000, 10000];
                DateTime t1 = DateTime.Now;


                for (int j = 10000 - 1; j >= 0; j--)
                    for (int i = 10000 - 1; i >= 0; i--)
                        a[i, j] = i / (j + 1);


                DateTime t2 = DateTime.Now;
                TimeSpan dt = t2 - t1;
                times.Add(dt);

            }
            TimeSpan minTime = times[0];
            TimeSpan maxTime = times[0];
            double totalMilliseconds = 0;

            foreach (var time in times)
            {
                if (time < minTime) minTime = time;
                if (time > maxTime) maxTime = time;
                totalMilliseconds += time.TotalMilliseconds;
            }

            double avgTime = totalMilliseconds / iterations;

            Console.WriteLine("\n=== РЕЗУЛЬТАТЫ ===");
            Console.WriteLine($"Минимальное время: {minTime.TotalMilliseconds:F2} ms");
            Console.WriteLine($"Максимальное время: {maxTime.TotalMilliseconds:F2} ms");
            Console.WriteLine($"Среднее время: {avgTime:F2} ms");
            Console.WriteLine($"Общее время выполнения: {totalMilliseconds / 1000:F2} s");

        }

    }
}
