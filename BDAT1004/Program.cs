using System;
using System.Collections.Generic;
using System.Linq;

namespace BDAT1004
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new Question1();

            Console.WriteLine("BDAT1004 Problem Set Question 1: Angry Professor");
            class1.AngryProfessor();

            Console.WriteLine("BDAT1004 Problem Set Question 2: Get Total X");
            class1.getTotalX();
            Console.ReadLine();
        }
    }
    class Question1
    {
        public void getTotalX()
        {
            int[] lengths = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] b = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            if (a.Length < 1 || a.Length > 10 || b.Length < 1 || b.Length > 10)
            {
                Console.WriteLine("Array Lengths are outside the boundaries (1-10");
                Console.ReadLine();
            }
            else
            {
                if (lengths[0] != a.Length || lengths[1] != b.Length)
                {
                    Console.WriteLine("Warning! User inputted arrays do not match length declaration");
                }
                var factors = new List<int>();
                foreach (int x in b)
                {
                    if (x < 1 || x > 100)
                    {
                        Console.WriteLine("Integer values in line 2 are outside the boundaries (1-100)");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        for (int i = 1; i <= x; i++)
                        {
                            if (x % i == 0)
                            {
                                factors.Add(i);
                            }
                        } 
                    }
                }
                var count = factors.GroupBy(e => e).Where(e => e.Count() == b.Length).Select(e => e.First());
                foreach (int y in a)
                {
                    if (y < 1 || y > 100)
                    {
                        Console.WriteLine("Integer values in line 1 are outside the boundaries (1-100)");
                        Console.ReadLine();
                        break;
                    }
                }
                var factors2 = new List<int>();
                foreach (int z in count)
                {
                    foreach (int y in a)
                    {
                        if (z % y == 0)
                        {
                            factors2.Add(z);
                        }
                    }
                }
                var count2 = factors2.GroupBy(e => e).Where(e => e.Count() == a.Length).Select(e => e.First());
                Console.WriteLine(count2.Count());
            }
        }

        public void AngryProfessor()
        {
            var list1 = new List<Array>();
            var list2 = new List<Array>();
            int testTotal = Int32.Parse(Console.ReadLine());

            if (testTotal>0 && testTotal < 11)
            {
                for (int q = 0; q < testTotal; q++)
                {
                    string[] a = Console.ReadLine().Split();
                    int[] numbers = Array.ConvertAll(a, int.Parse);

                    string[] b = Console.ReadLine().Split();
                    int[] times = Array.ConvertAll(b, int.Parse);

                    list1.Add(numbers);
                    list2.Add(times);
                }
                if (list1.Count == testTotal && list2.Count == testTotal)
                {
                    foreach (Array item in list1)
                    {
                        int[] n = item as int[];
                        if (n[0] < 1 || n[0] > 1000)
                        {
                            Console.WriteLine("The number of students is not within the boundaries (1-1000)");
                            break;
                        }
                        if (n[1] > n[0] || n[1] < 1)
                        {
                            Console.WriteLine("The cancellation threshold exceeds the number of students or is less than 1");
                            break;
                        }
                    }
                    for (int g = 0; g < testTotal; g++)
                    {
                        int[] n = (list1[g] as int[]);
                        int[] t = (list2[g] as int[]);
                        int counter = 0;
                        foreach (int f in t)
                        {
                            if (f < -100 || f > 100)
                            {
                                Console.WriteLine("The arrival times are not within the boundaries (-100-100)");
                                break;
                            }
                            else
                            {
                                if (f <= 0)
                                {
                                    counter += 1;
                                }
                            }
                        }
                        if (counter >= n[1]) { Console.WriteLine("NO"); }
                        else { Console.WriteLine("YES"); }
                    }
                }
                else
                {
                    Console.WriteLine("The number of test cases does not equal the inputs given");
                }
            }
            else
            {
                Console.WriteLine("The number of test cases are not within the boundaries (1-10)");
            }
        }   
    }
}
