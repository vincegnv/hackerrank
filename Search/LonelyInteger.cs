//There are N integers in an array A. All but one integer occur in pairs.
//Your task is to find out the number that occurs only once.

//Input Format

//The first line of the input contains an integer N indicating number of integers. 
//The next line contains N space separated integers that form the array A.

//Constraints

//1 <= N < 100 
//N % 2 = 1 ( N is an odd number ) 
//0 <= A[i] <= 100, ∀ i ∈ [1, N]

//Output Format

//Output S, the number that occurs only once.

//Sample Input:1

//1
//1
//Sample Output:1

//1
//Sample Input:2

//3
//1 1 2
//Sample Output:2

//2
//Sample Input:3

//5
//0 0 1 2 1
//Sample Output:3

//2
//Explanation

//In the first input, we see only 1 element and that element is the answer (1). 
//In the second input, we see 3 elements, 1 is repeated twice. The element that occurs only once is 2. 
//In the third input, we see 5 elements, 1 and 0 are repeated twice. And the element that occurs only once is 2.

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

            static void Main(string[] args)
            {
                Problem problem = new Problem();
                problem.run();
            
            }
        }


        public class Problem
        {
            int[] numbers;

            public Problem() { }

            public Problem(int[] numbers)
            {
                this.numbers = numbers;
            }

            public void run()
            {

                getInput();
                Console.WriteLine(calculate());

                Console.ReadKey();
            }

            public int calculate()
            {
                int result = numbers[0];

                if (numbers.Count() > 1)
                {
                    Array.Sort(numbers);

                    if (numbers[numbers.Count() - 1] != numbers[numbers.Count() - 2])
                    {
                        result = numbers[numbers.Count() - 1];
                    }
                    else
                    {
                        for (int i = 0; i < numbers.Count(); i += 2)
                        {
                            if (numbers[i] != numbers[i + 1])
                            {
                                result = numbers[i];
                                break;
                            }
                        }
                    }
                }

                return result;
            }

            private void getInput()
            {
                Console.ReadLine();
                string[] numbersString = Console.ReadLine().Split(' ');
                int i = 0;
                numbers = new int[numbersString.Count()];
                foreach (string number in numbersString)
                {
                    numbers[i++] = Convert.ToInt32(number);
                }


            }


        }
    }
