//Manasa is out on a hike with friends.
//She finds a trail of stones with numbers on them.
//She starts following the trail and notices that two consecutive stones have a difference of either a or b.
//Legend has it that there is a treasure trove at the end of the trail and if Manasa can guess the value of the last stone,
// the treasure would be hers. Given that the number on the first stone was 0,
// find all the possible values for the number on the last stone.

//Note : The numbers on the stones are in increasing order

//Input Format 
//The first line contains an integer T i.e. the number of Test cases. T testcases follow. 
//Each testcase has 3 lines.
//The first line contains n ( the number of stones ) The second line contains a.The third line contains b.

//Output Format 
//Space separated list of numbers which are the possible values of the last stone in increasing order.

//Constraints 
//1 ≤ T ≤ 10 
//1 ≤ n, a, b ≤ 103

//Sample Input 00

//2
//3 
//1
//2
//4
//10
//100
//Sample Output 00

//2 3 4 
//30 120 210 300 
//Explanation

//All possible series for first test cases are given below.

//0,1,2
//0,1,3
//0,2,3
//0,2,4
//Hence the answer 2 3 4.

//Series with different number of final step for second test cases are

//0, 10, 20, 30
//0, 10, 20, 120
//0, 10, 110, 120
//0, 10, 110, 210
//0, 100, 110, 120
//0, 100, 110, 210
//0, 100, 200, 210
//0, 100, 200, 300
//hence the answer 30 120 210 300

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
class Program
{
    static void Main(string[] args)
    {
        Hackerrank h = new Hackerrank();
        h.getInput();
        h.printResult();
        Console.ReadKey();
    }
    public class Hackerrank
    {
        int numberOfTests;
        TestCase[] testCases;


        public void getInput()
        {
            numberOfTests = Convert.ToInt32(Console.ReadLine());

            testCases = new TestCase[numberOfTests];

            for (int i = 0; i < numberOfTests; i++)
            {
                int stones = Convert.ToInt32(Console.ReadLine());
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                //string[] inputArray = input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                testCases[i] = new TestCase(stones, a, b);
            }
        }

        public void printResult()
        {
            StringBuilder result = new StringBuilder();
            foreach(TestCase testCase in testCases){
                result.Append(testCase.getNumbers());
                result.Append("\n");
            }
                Console.Write(result);
            
        }

        class TestCase
        {
            private int stones, a, b;

            public TestCase(int stones, int a, int b)
            {
                this.stones = stones;
                this.a = a;
                this.b = b;
            }

            public string getNumbers()
            {
                List<int> lastStoneNumbers = new List<int>();
                for (int i = stones-1; i >= (stones/2); i--)
                {
                    int caseA = i*a+(stones-1-i)*b;
                    int caseB = i*b+(stones-1-i)*a;
                    if(!lastStoneNumbers.Contains(caseA)) lastStoneNumbers.Add(caseA);
                    if(!lastStoneNumbers.Contains(caseB)) lastStoneNumbers.Add(caseB);
                }
                lastStoneNumbers.Sort();

                return listToString(lastStoneNumbers);
            }

            private string listToString(List<int> list)
            {
                StringBuilder sb = new StringBuilder();
                foreach (int number in list)
                {
                    sb.Append(number.ToString());
                    sb.Append(" ");
                }
                return sb.ToString();
            }
        }
      
    }
}

}