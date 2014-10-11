
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    namespace Hackerrank
    {
        class Program
        {
            private static int[] array;

            static void Main(string[] args)
            {
                GetInput();

                Array.Sort(array);

                PrintResult(SolveProblem());

                    Console.ReadKey();
            }

            private static void PrintResult(List<int> list)
            {
                foreach (int n in list)
                    Console.Write("{0} ", n);
            }

            private static List<int> SolveProblem()
            {
                int minDifference = array.Last() - array[0];
                List<int> pairs = new List<int>();

                for (int i = 0; i < array.Count() - 1; i++)
                {
                    int difference = array[i + 1] - array[i];
                    if (difference <= minDifference)
                    {
                        if (difference < minDifference)
                        {
                            minDifference = difference;
                            pairs.Clear();
                        }
                        pairs.Add(array[i]);
                        pairs.Add(array[i + 1]);
                    }
                }

                return pairs;
            }

            private static void GetInput()
            {
                int size = int.Parse(Console.ReadLine());
                array = new int[size];
                string[] elements = Console.ReadLine().Split(' ');
                for (int i = 0; i < size; i++)
                {
                    array[i] = int.Parse(elements[i]);
                }
            }
        }
    }
