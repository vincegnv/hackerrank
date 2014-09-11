//Sherlock Holmes is getting paranoid about Professor Moriarty, his archenemy.
//All his efforts to subdue Moriarty have been in vain.
//These days Sherlock is working on a problem with Dr. Watson.
//Watson mentioned that the CIA has been facing weird problems with their supercomputer, 'The Beast', recently.

//This afternoon, Sherlock received a note from Moriarty, saying that he has infected 'The Beast' with a virus.
//Moreover, the note had the number N printed on it. After doing some calculations,
//Sherlock figured out that the key to remove the virus is the largest 'Decent' Number having N digits.

//A 'Decent' Number has -
//1. Only 3 and 5 as its digits.
//2. Number of times 3 appears is divisible by 5.
//3. Number of times 5 appears is divisible by 3.

//Meanwhile, the counter to destruction of 'The Beast' is running very fast. Can you save 'The Beast', and find the key before Sherlock?

//Input Format
//The 1st line will contain an integer T, the number of test cases.
//This is followed by T lines, each containing an integer N i.e. the number of digits in the number 

//Output Format
//Largest Decent number having N digits. If no such number exists, tell Sherlock that he is wrong and print '-1' 

//Constraints
//1<=T<=20
//1<=N<=100000


//Sample Input

//4
//1
//3
//5
//11
//Sample Output

//-1
//555
//33333
//55555533333

//Explanation
//For N=1, there is no such number. 
//For N=3, 555 is only possible number.
//For N=5, 33333 is only possible number.
//For N=11, 55555533333 and all of permutations of digits are valid numbers, among them, the given number is the largest one.

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
        int numberOfTestCases;
        int[] testCases;
        string[] results;

        public void run()
        {
            getInputAndSetArrays();
            for (int testIndex = 0; testIndex < numberOfTestCases; testIndex++)
            {
                results[testIndex] = findMaxDecentNumber(testCases[testIndex]);
            }
            printResults();
            Console.ReadKey();
        }

        private void printResults()
        {
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }

        private string findMaxDecentNumber(int numberOfDigits)
        {
            string result = "-1";
            if (numberOfDigits % 3 == 0)
            {
                result = buildNumber(numberOfDigits, numberOfDigits);
            }
            else
            {
                int numberOfFives = (numberOfDigits / 3) * 3;
                int numberOfThrees = numberOfDigits % 3;
                while (numberOfThrees % 5 != 0 && numberOfFives >= 0)
                {
                    numberOfFives -= 3;
                    numberOfThrees += 3;
                }
                if (numberOfFives >= 0)
                {
                    result = buildNumber(numberOfDigits, numberOfFives);
                }
            }

            return result;
        }


        private string buildNumber(int numberOfDigits, int numberOfFives)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= numberOfDigits; i++)
            {
                if (i <= numberOfFives)
                {
                    result.Append('5');
                }
                else
                {
                    result.Append('3');
                }
            }
            return result.ToString();
        }

        private void getInputAndSetArrays()
        {
            numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            testCases = new int[numberOfTestCases];
            results = new string[numberOfTestCases];
            for (int testIndex = 0; testIndex < numberOfTestCases; testIndex++)
            {
                testCases[testIndex] = Convert.ToInt32(Console.ReadLine());
            }
        }

    }
}
