using System;
using System.Collections.Generic;

namespace Task_13_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"test # {i}");
                TestAdding();
                Console.WriteLine();
            }


            Console.WriteLine("Hello World!");
        }

        static void TestAdding()
        {
            int iterations = 100_000;
            List<int> lst = new();
            System.Diagnostics.Stopwatch timer = new();

            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                lst.Add(i);
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine($"List.Add().\t\t Time taken: + {timeTaken.ToString(@"m\:ss\.fffff")}");

            timer.Restart();
            for (int i = 0; i < iterations; i++)
            {
                lst.Insert(1, i);
            }
            timer.Stop();
            timeTaken = timer.Elapsed;
            Console.WriteLine($"List.Insert().\t\t Time taken: + {timeTaken.ToString(@"m\:ss\.fffff")}");

            LinkedList<int> linked = new LinkedList<int>();

            timer.Restart();
            for (int i = 0; i < iterations; i++)
            {
                linked.AddLast(i);
            }
            timer.Stop();
            timeTaken = timer.Elapsed;
            Console.WriteLine($"Linked List.AddLast().\t Time taken: + {timeTaken.ToString(@"m\:ss\.fffff")}");

            var first = linked.First;
            timer.Restart();

            for (int i = 0; i < iterations; i++)
            {
                linked.AddAfter(first, i);
            }
            timer.Stop();
            timeTaken = timer.Elapsed;
            Console.WriteLine($"Linked List.AddAfter().\t Time taken: + {timeTaken.ToString(@"m\:ss\.fffff")}");

        }
    }
}
