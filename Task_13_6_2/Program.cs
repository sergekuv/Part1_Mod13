using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Task_13_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data\Text1.txt";
            string initialText = File.ReadAllText(path).ToLower();

            StringBuilder sb = new StringBuilder();
            foreach (char c in initialText)
            {
                if (! Char.IsPunctuation(c))
                    sb.Append(c);
            }
            string[] words = sb.ToString().Split();
            Console.WriteLine($"Total items in array: {words.Length}");

            TenMostUsed1(words);
            TenMostUsed2(words);
        }

        /// <summary>
        /// Используем  LINQ 
        /// </summary>
        /// <param name="words"></param>
        private static void TenMostUsed2(string[] words)
        {
            Console.WriteLine("\nMethod 2");
            System.Diagnostics.Stopwatch timer = new();
            timer.Start();

            string[] uniqueWords = words.Distinct().ToArray();

            var groups = words.GroupBy(w => w).OrderByDescending(w => w.Count());

            int j = 0;
            foreach (var group in groups)
            {
                Console.WriteLine($"{j++}: {group.Count()} {group.Key}");
                if (j > 10) break;

            }

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine($"Time taken by Method 2: + {timeTaken.ToString(@"m\:ss\.fffff")}");
        }

        /// <summary>
        /// Первый вариант: сортируем список и в цикле выснем количество вхождений каждого слова
        /// </summary>
        /// <param name="words"></param>
        private static void TenMostUsed1(string[] words)
        {
            Console.WriteLine("\nMethod 1");
            System.Diagnostics.Stopwatch timer = new();
            timer.Start();
            Array.Sort(words);
            List<WordCount> counts = new();

            string w = words[0];
            int c = 0;

            foreach(string s in words)
            {
                if (s == w)
                {
                    c++;
                }
                else
                {
                    WordCount wc = new (w, c);
                    counts.Add(wc);
                    w = s;
                    c = 1;
                }
            }

            int j = 0;
            counts.Sort();
            foreach (WordCount item in counts)
            {
                Console.WriteLine($"{j++}: {item.ToString()}");
                if (j > 10)
                    break;
            }

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine($"Time taken by Method 1: + {timeTaken.ToString(@"m\:ss\.fffff")}");
        }

        class WordCount : IComparable<WordCount>
        {
            string word;
            int count;
            public WordCount(string word, int count)
            {
                this.word = word;
                this.count = count;
            }

            public int CompareTo(WordCount other)
            {
                if (this.count > other.count)
                    return -1;
                if (this.count < other.count)
                    return 1;
                return 0;
            }

            public string ToString()
            {
                return this.count + " " + this.word;
            }
        }
        
    }
}
