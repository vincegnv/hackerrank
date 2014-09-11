//You are given an integer, N. Write a program to determine if N is an element of the Fibonacci Sequence.

//The first few elements of fibonacci sequence are 0,1,1,2,3,5,8,13.... A fibonacci sequence is one 
//where every element is a sum of the previous two elements in the sequence.
//The first two elements are 0 and 1.

//Formally:

//fib0 = 0 
//fib1 = 1 
//fibn = fibn-1 + fibn-2 ∀ n > 1

//Input Format 
//The first line contains T, number of test cases. 
//T lines follows. Each line contains an integer N.

//Output Format 
//Display IsFibo if N is a fibonacci number and IsNotFibo if it is not a fibonacci number.
//The output for each test case should be displayed on a new line.

//Constraints 
//1 <= T <= 105 
//1 <= N <= 1010

//Sample Input

//3
//5
//7
//8
//Sample Output

//IsFibo
//IsNotFibo
//IsFibo
//Explanation 
//5 is a Fibonacci number given by fib5 = 3 + 2 
//7 is not a Fibonacci number 
//8 is a Fibonacci number given by fib6 = 5 + 3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        int numberOfTests;
        List<long> fiboNumbers;
        const long upperLimit = 10000000000;

        public void run()
        {
            getInput();
            
            generateFiboList(out fiboNumbers);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberOfTests; i++)
            {
                long number = Int64.Parse(Console.ReadLine());
                sb.Append(isFibo(number));
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }

        private void generateFiboList(out List<long> fiboNumbers)
        {
            long a = 0;
            long b = 1;
            long c = a + b;
            fiboNumbers = new List<long>();
            while (a + b < upperLimit)
            {
                fiboNumbers.Add(a + b);
                a = b;
                b = fiboNumbers[fiboNumbers.Count - 1];

            }
        }

        private string isFibo(long number)
        {
            if (fiboNumbers.Exists(x => x == number))
            {
                return "IsFibo\n";
            }
            else return "IsNotFibo\n";
        }
 
        private void getInput()
        {
            numberOfTests = Convert.ToInt32(Console.ReadLine());
        }

    }
}
