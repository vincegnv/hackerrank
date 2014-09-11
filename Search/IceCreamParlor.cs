//Sunny and Johnny together have M dollars and want to spend the amount at an ice cream parlour.
//The parlour offers N flavors, and they want to choose 2 flavors so that they end up spending the whole amount.

//You are given a list of cost of these N flavors.
//The cost of ith flavor is denoted by (ci).
//You have to display the indices of two flavors whose sum is M.

//Input Format

//The first line of the input contains T, T test cases follow. 
//Each test case follows the format: The first line contains M.
//The second line contains N. The third line contains N single space separated integers denoting the price of each flavor.
//Here, ith integer denotes ci.

//Output Format

//Output two integers, each of which is a valid index of the flavor.
//The lower index must be printed first. Indices are indexed from 1 to N.

//Constraints

//1 ≤ T ≤ 50 
//2 ≤ M ≤ 10000 
//2 ≤ N ≤ 10000 
//1 ≤ ci ≤ 10000 
//The prices of two items may be same and each test case has a unique solution.

//Sample Input

//2
//4
//5
//1 4 5 3 2
//4
//4
//2 2 4 3
//Sample Output

//1 4
//1 2
//Explanation

//The sample input has two test cases. 
//For the 1st, the amount M = 4 and there are 5 flavors at the store.
//The flavors indexed at 1 and 4 sums to 4. For the 2nd test case, the amount M = 4 and the flavors indexed at 1 and 2 sums to 4.

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
            int numberOfTestCases;
            TestCase[] testCases;

            public Problem() { }

            public void run()
            {

                getInput();

                foreach (TestCase tc in testCases)
                {
                    Console.WriteLine(tc.FindPriceIndexesThatSolveTheProblem());
                }

                Console.ReadKey();
            }


            private void getInput()
            {
                numberOfTestCases = Convert.ToInt32(Console.ReadLine());
                testCases = new TestCase[numberOfTestCases];

                for (int i = 0; i < numberOfTestCases; i++)
                {
                    int money = Convert.ToInt32(Console.ReadLine());
                    int flavors = Convert.ToInt32(Console.ReadLine());
                    string[] prices = Console.ReadLine().Split(' ');

                    TestCase testCase = new TestCase(money, flavors);

                    for (int j = 0; j < flavors; j++)
                    {
                        testCase[j] = Convert.ToInt32(prices[j]);
                    }

                    testCases[i] = testCase;
                }


            }


        }

        public class TestCase
        {
            private int[] priceList;
            public int[] PriceList
            {
                set
                {
                    this.priceList = value;
                }
            }
            public int Money
            {
                get;
                set;
            }
            public int Flavors
            {
                get;
                set;
            }


            public TestCase(int money, int flavors)
            {
                this.Money = money;
                this.Flavors = flavors;
                this.priceList = new int[flavors];
            }

            public int this[int i]
            {
                get
                {
                    int result = 0;
                    if (isValidIndex(i))
                    {
                        result = this.priceList[i];
                    }
                    return result;
                }
                set
                {
                    if (isValidIndex(i))
                    {
                        this.priceList[i] = value;
                    }
                }
            }

            private bool isValidIndex(int index){
                return index >= 0 && index < priceList.Count();
            }

            public string FindPriceIndexesThatSolveTheProblem()
            {
                string result = "";

                Dictionary<int, int> affordableFlavors = GetFlavorsInPriceRange();

                List<KeyValuePair<int, int>> sortedAffordableFlavors = affordableFlavors.ToList();
                sortedAffordableFlavors.Sort((firstPair, nextPair) => 
                    {
                        return firstPair.Value.CompareTo(nextPair.Value);
                    }
                );

                int forwardIndex = 0;
                int backwardIndex = sortedAffordableFlavors.Count() - 1;

                while (forwardIndex < backwardIndex)
                {
                    int sum = sortedAffordableFlavors[forwardIndex].Value + sortedAffordableFlavors[backwardIndex].Value;
                    if (sum == Money)
                    {
                        int first = sortedAffordableFlavors[forwardIndex].Key + 1;
                        int second = sortedAffordableFlavors[backwardIndex].Key + 1;
                        if (first > second)
                        {
                            first += second;
                            second = first - second;
                            first -= second;
                        }
                        result = String.Format("{0} {1}", first, second);
                        break;
                    }
                    else if (sum < Money) forwardIndex++;
                    else backwardIndex--;
                }

                return result;
            }

            private Dictionary<int, int> GetFlavorsInPriceRange()
            {
                Dictionary<int, int> result = new Dictionary<int, int>();
                for (int i = 0; i < priceList.Count(); i++)
                {
                    if (priceList[i] < Money)
                    {
                        result.Add(i, priceList[i]);
                    }
                }

                return result;
            }

        }
    }
