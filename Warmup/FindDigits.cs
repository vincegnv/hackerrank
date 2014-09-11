//Problem Statement 
//You are given a number N, you need to print the number of positions where digits exactly divides N.

//Input format

//The first line contains T (number of test cases followed by T lines each containing N).

//Constraints 
//1 <=T <= 15 
//0 < N < 1010

//Output Format 
//Number of positions in N where digits in that number exactly divides the number N.

//Input

//1  
//12
//Output

//2
//Explanation 
//2 digits in the number 12 divide the number exactly.
//Digits at ten's place, 1, divides 12 exactly in 12 parts, and digit at one's place, 2 divides 12 equally in 6 parts.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hackerrank h = new Hackerrank();
            h.start();
            Console.ReadKey();
        }
    }
        public class Hackerrank
    {
        public void start(){
            int numberOfTests = Convert.ToInt32(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < numberOfTests; i++){
                int numberOfPositions = getNumberOfPositionsThatDivideTheNumber(Convert.ToInt32(Console.ReadLine()));
                sb.Append(numberOfPositions + "\n");
                
            }
            Console.Write(sb);
        }

        private int getNumberOfPositionsThatDivideTheNumber(int number)
        {
            int tempNumber = number;
            int result = 0;
            while (tempNumber > 0)
            {
                int digit = tempNumber % 10;
                if (digit > 0 && (number / digit) * digit == number)
                {
                    result++;
                }
                tempNumber /= 10;
            }
            return result;
        }
     }
}