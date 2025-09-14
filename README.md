======ПЕРВОЕ ЗАДАНИЕ======
Каждую часть кода вставляем в следующую конструкцию:


    int iterations = 100;
    List<TimeSpan> times = new List<TimeSpan>();
    for (int k = 0; k <= iterations; k++)
    double[,] a = new double[10000, 10000];
    DateTime t1 = DateTime.Now;
    
  ...ЦИКЛ...
    
    DateTime t2 = DateTime.Now;
        TimeSpan dt = t2 - t1;
        times.Add(dt);
        {
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


В качестве циклов берем:
1)     for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
          a[i, j] = i / (j + 1);
2)     for (int j = 0; j < N; j++)
          for (int i = 0; i < N; i++)
          a[i, j] = i / (j + 1);
3)      for (int i = N - 1; i >= 0; i--)
          for (int j = N - 1; j >= 0; j--)
            a[i, j] = i / (j + 1);
4)     for (int j = N - 1; j >= 0; j--)
        for (int i = N - 1; i >= 0; i--)
          a[i, j] = i / (j + 1);

======ВТОРОЕ ЗАДАНИЕ======

