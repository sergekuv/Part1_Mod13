using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace Part1_Mod13
{
    class Program
    {
        static void Main(string[] args)
        {

            //var months = new[] {   "Jan", "Feb", "Mar", "Apr", "May" , "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};

            //var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            // ArrayList al = new ArrayList();
            // for (int i = 0; i< months.Length; i++)
            // {
            //     //Console.WriteLine(months[i] + numbers[i]);
            //     al.Add(months[i]);
            //     al.Add(numbers[i]);
            // }
            // foreach (object o in al)
            // {
            //     Console.WriteLine(o.ToString());
            // }

            //string txt = File.ReadAllText("file.txt");
            //char[] delims = {' ', '\r', '\n' };
            //string[] words = txt.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine(words.Length);


            //List<Contact> pb = new List<Contact>();
            //Contact c1 = new("a1", 1, "m1");
            //Contact c2 = new("a2", 2, "m2");
            //Contact c3 = new("a2", 2, "m2");


            //AddUnique(c1, pb);
            //AddUnique(c2, pb);
            //AddUnique(c3, pb);

            //var months = new List<string>() {"Jan", "Feb", "Mar", "Apr", "May"};
            //var missing = new ArrayList() {1, 2, 3, 5, "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};

            //foreach (object o in missing)
            //{
            //    if (o is string)
            //    {
            //        months.Add((string)o);
            //    }
            //}
            //foreach (string s in months)
            //{
            //    Console.WriteLine(s);
            //}

            //while (true)
            //{
            //    string s = Console.ReadLine();//"Подсчитайте, сколько уникальных с1имволов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";
            //    HashSet<char> hs = new HashSet<char>(s);
            //    Console.WriteLine(hs.Count);
            //    //foreach (char c in hs)
            //    //{
            //    //    Console.WriteLine(c);
            //    //}

            //    HashSet<char> n = new HashSet<char> { '1', '2', '3', '4' };
            //    hs.ExceptWith(n);
            //    Console.WriteLine(hs.Count);
            //    HashSet<char> punkt = new HashSet<char> { ',', '.', ' ' };
            //    hs.ExceptWith(punkt);
            //    Console.WriteLine(hs.Count);

            //}


            //Dictionary<string, string> ud = new Dictionary<string, string>();
            //var stw = System.Diagnostics.Stopwatch.StartNew();
            //for (int i = 100000; i > 0; i--)
            //{
            //    ud.Add(i.ToString(), i.ToString());
            //}
            //Console.WriteLine(stw.Elapsed.TotalMilliseconds);
            //Console.WriteLine();


            //SortedDictionary<string, string> sd = new SortedDictionary<string, string>();
            //var stw1 = System.Diagnostics.Stopwatch.StartNew();
            //for (int i = 100000; i > 0; i--)
            //{
            //    sd.Add(i.ToString(), i.ToString());
            //}
            //Console.WriteLine(stw1.Elapsed.TotalMilliseconds);


            Stack<string> sta = new();
            while (true)
            {
                string s = Console.ReadLine();
                switch (s)
                {
                    case "pop":
                        Console.WriteLine(sta.TryPop(out string res) + " " + res);
                        break;
                    case "peek":
                        Console.WriteLine(sta.Peek());
                        break;

                    default:
                        sta.Push(s);
                        break;
                }
                Console.Write("Stack:");
                foreach (string st in sta)
                {
                    Console.Write(st + "\t");
                }
                Console.WriteLine();

            }

            Console.WriteLine("Hello World!");
        }

        static  void AddUnique(Contact contact, List<Contact> phoneBook)
        {
            Console.WriteLine();
            bool nameExists = false;
            foreach (Contact c in phoneBook)
            {
                if (c.Name == contact.Name)
                {
                    nameExists = true;
                    break;
                }
            }
            if (!nameExists)
            {
                phoneBook.Add(contact);
                phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
            }

            foreach (Contact c in phoneBook)
            {
                Console.WriteLine(c.Name + " " + c.PhoneNumber + " " + c.Email);
            }

        }

        public class Contact // модель класса
        {
            public Contact(string name, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
    }
}
