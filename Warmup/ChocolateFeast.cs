//Little Bob loves chocolates, and goes to the store with $N money in his pocket.
//The price of each chocolate is $C. The store offers a discount: for every M wrappers he gives to the store, he gets one chocolate for free.
//How many chocolates does Bob get to eat?

//Input Format: 
//The first line contains the number of test cases T(<=1000). 
//T lines follow, each of which contains three integers N, C and M

//Output Format: 
//Print the total number of chocolates Bob eats.

//Constraints: 
//2≤N≤105 
//1≤C≤N 
//2≤M≤N

//Sample input

//3
//10 2 5
//12 4 4
//6 2 2
//Sample Output

//6
//3
//5
//Explanation 
//In the first case, he can buy 5 chocolates with $10 and exchange the 5 wrappers to get one more chocolate.
//Thus, the total number of chocolates is 6.

//In the second case, he can buy 3 chocolates for $12.
//However, it takes 4 wrappers to get one more chocolate. 
//He can't avail the offer and hence the total number of chocolates remains 3.

//In the third case, he can buy 3 chocolates for $6. Now he can give 2 of this 3 wrappers and get 1 chocolate.
//Again, he can use his 1 unused wrapper and 1 wrapper of new chocolate to get one more chocolate. So the total is 5.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
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
        int numberTests;
        TestCase[] testCases;
        
        public void getInput()
        {
            numberTests = Convert.ToInt32(Console.ReadLine());
            testCases = new TestCase[numberTests];

            for (int i = 0; i < numberTests; i++)
            {
                string input = Console.ReadLine();
                string[] inputArray = input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                testCases[i] = new TestCase(Convert.ToInt32(inputArray[0]), Convert.ToInt32(inputArray[1]), Convert.ToInt32(inputArray[2]));
            }
        }

        public void printResult()
        {
            StringBuilder result = new StringBuilder();
            foreach(TestCase testCase in testCases){
                result.Append(testCase.calculateChocolates());
                result.Append("\n");
            }
                Console.Write(result);
            
        }

        class TestCase
        {
            private int money, price, exchangeRate;

            public TestCase(int money, int price, int wrapers)
            {
                this.money = money;
                this.price = price;
                this.exchangeRate = wrapers;
            }

            public int calculateChocolates()
            {
                int chocolates = money / price;
                int fromWrapers = wrapersToChocolates(chocolates);
                return chocolates+fromWrapers;
            }

            private int wrapersToChocolates(int wrapers)
            {
                int total = 0;
                int w = wrapers;
                while (w >= exchangeRate)
                {
                    total += w / exchangeRate;
                    w = w / exchangeRate + w % exchangeRate;

                }
                return total;
            }
            
        }
    }
        
    }

}