//Watson gives two integers A & B to Sherlock and asks if he can count
//the number of square integers between A and B (both inclusive).

//A square integer is an integer which is the square of any integer.
//For example, 1, 4, 9, 16 are some of the square integers as they are squares of 1, 2, 3, 4 respectively.

//Input Format 
//First line contains T, the number of testcases. T test cases follow, each in a newline. 
//Each testcase contains two space separated integers denoting A and B.

//Output Format 
//For each testcase, print the required answer in a new line.

//Constraints 
//1 ≤ T ≤ 100 
//1 ≤ A ≤ B ≤ 109

//Sample Input

//2
//3 9
//17 24
//Sample output

//2
//0
//Explanation 
//In the first testcase, 4 and 9 are the square numbers. 
//In second testcase no square numbers exist between 17 and 24 (both inclusive).

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

    public class Interval
    {
        private int A, B;

        public Interval(int a, int b)
        {
            setInterval(a, b);
        }

        public void setInterval(int a, int b)
        {
            A = a;
            B = b;
        }

        public int getNumberOfSquaresMethod1()
        {
            int result = 0;
            if(A <= 0) A = 1;
            int i = (int)Math.Floor(Math.Sqrt(A));
            int i2 = i*i;
            while (i2 <= B)
            {
                if(i2 >= A) result++;
                i++;
                i2 = i * i;
            }
            return result;
        }

        public int getNumberOfSquaresMethod2()
        {
            // Return zero if there are obviously no perfect squares
            if (B < 0 || B < A) return 0;

            // Reset the lower bound if required
            if (A <= 0) A = 1;

            // Find the number of perfect squares between A & B (INCLUSIVE)
            return (int)Math.Sqrt(B) - (int)Math.Sqrt(A - 1);  // Now giving the correct count, even when the lower bound value is a whole square (for exp. CountPerfectSquares(1, 25))

        }
		
		public int getNumberOfSquaresMethod3()
        {
            int result = 0;

            if (A <= 0) A = 1;
            int square = (int)Math.Pow(Math.Floor(Math.Sqrt(A)), 2);

            if (square < A) square = (int)Math.Pow(Math.Sqrt(square) + 1, 2);
            int space = (int)Math.Pow(Math.Sqrt(square) + 1, 2) - square;

            while (square <= B)
            {
                result++;
                square += space;
                space += 2;
            }

            return result;
        }
		
    }

    public class Problem
    {
        int numberOfTests;
        Interval[] testCases;

        public void run()
        {
            getInputAndSetArrays();
            printResult();
            Console.ReadKey();
        }

        private void printResult()
        {
            foreach (Interval interval in testCases)
            {
                Console.WriteLine(interval.getNumberOfSquaresMethod1());
            }
        }

        private void getInputAndSetArrays()
        {
            numberOfTests = Convert.ToInt32(Console.ReadLine());
            testCases = new Interval[numberOfTests];

            for (int testIndex = 0; testIndex < numberOfTests; testIndex++)
            {
                string line = Console.ReadLine();
                string[] AB = line.Split(' ');
                testCases[testIndex] = new Interval(Convert.ToInt32(AB[0]), Convert.ToInt32(AB[1]));
            }
        }

    }
}
