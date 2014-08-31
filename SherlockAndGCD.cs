//Sherlock is stuck. He has an array A1,A2,...,AN.
//He wants to know if there exists a subset, B={Ai1,Ai2,…,Aik} where 1≤i1<i2<…<ik≤N, of this array which follows the property

//B is non-empty subset.
//There exists no integer x(x>1) which divides all elements of B. Note that x may or may not be an element of A.
//Input Format 
//First line contains T, the number of testcases. Each testcase consists of N in one line.
//The next line contains N integers denoting the array A.

//Output 
//Print YES or NO, if there exists any such subset or not, respectively.

//Constraints 
//1≤T≤10 
//1≤N≤100 
//1≤Ai≤105 ∀1≤i≤N

//Sample input
//2
//3
//1 2 3
//2
//2 4

//Sample output
//YES
//NO

//Explanation 
//In first testcase, S={1},S={1,2},S={1,3},S={2,3} and S={1,2,3} are all the possible subsets which satisfy the given condition. 
//In second testcase, no non-empty subset exists which satisfies the given condition.

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
        int[][] testCases;

        public void run()
        {
            getInputAndSetArrays();
            foreach(int[] testCase in testCases)
            {
                Console.WriteLine(doesSuchSubsetExist(testCase));
            }
            Console.ReadKey();
        }

        public string doesSuchSubsetExist(int[] testCase)
        {
            string answer = "NO";

            if (thereIsOneInTheArray(testCase))
            {
                answer = "YES";
            }
            else
            {
                for (int i = 0; i < testCase.Length - 1; i++)
                {
                    for (int j = i + 1; j < testCase.Length; j++)
                    {
                        if (!arrayElementsHaveCommonDivider(new int[] { testCase[i], testCase[j] }))
                        {
                            answer = "YES";
                            break;
                        }
                    }
                    if (answer.Equals("YES", StringComparison.Ordinal))
                    {
                        break;
                    }
                }
            }

            return answer;
        }

        

        public bool thereIsOneInTheArray(int[] array)
        {
            List<int> arrayToList = array.ToList();
            return arrayToList.Any(number => number == 1);
        }

        public bool arrayElementsHaveCommonDivider(int[] array)
        {
            bool result = false;

            for (int i = 2; i <= array[array.Length - 1]; i++)
            {
                if (arrayElementsAllDivideByNumber(array, i))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool arrayElementsAllDivideByNumber(int[] array, int number)
        {
            bool result = true;

            foreach (int element in array)
            {
                if (element % number != 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private void getInputAndSetArrays()
        {
            numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            testCases = new int[numberOfTestCases][];

            for (int testIndex = 0; testIndex < numberOfTestCases; testIndex++)
            {
                int testCaseArraySize = Convert.ToInt32(Console.ReadLine());
                string arrayElements = Console.ReadLine();
                string[] arrayString = arrayElements.Split(' ');
                testCases[testIndex] = new int[testCaseArraySize];

                for (int i = 0; i < testCaseArraySize; i++)
                {
                    testCases[testIndex][i] = Convert.ToInt32(arrayString[i]);
                }
                Array.Sort(testCases[testIndex]);
            }
        }
    }
}
