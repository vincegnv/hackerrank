//You and your K-1 friends want to buy N flowers.
//Flower number i has cost ci. Unfortunately the seller does not want just one customer to buy a lot of flowers, 
//so he tries to change the price of flowers for customers who have already bought some flowers.
//More precisely, if a customer has already bought x flowers, he should pay (x+1)*ci dollars to buy flower number i. 
//You and your K-1 friends want to buy all N flowers in such a way that you spend the least amount of money. 
//You can buy the flowers in any order.

//Input:

//The first line of input contains two integers N and K (K <= N).
//The next line contains N space separated positive integers c1,c2,...,cN.

//Output:

//Print the minimum amount of money you (and your friends) have to pay in order to buy all N flowers.

//Sample input :

//3 3 
//2 5 6

//Sample output :

//13

//Explanation : 
//In this example, all of you should buy one flower each. Hence, you'll have to pay 13 dollars.

//Constraint :

//1 <= N, K  <= 100 
//Any ci is not more than 1,000,000

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
            int flowers;
            int friends;
            int[] prices;

            public void run()
            {

                getInput();
                Console.WriteLine(calculate());

                Console.ReadKey();
            }

            public long calculate()
            {
                long total = 0;
                Array.Sort(prices);
                Array.Reverse(prices);

                for (int flowerIndex = 0; flowerIndex < flowers; flowerIndex++)
                {
                    total += (flowerIndex / friends + 1) * prices[flowerIndex];
                }

                    return total;
            }

            private void getInput()
            {
                string line = Console.ReadLine();
                flowers = Convert.ToInt32(line.Split(' ')[0]);
                friends = Convert.ToInt32(line.Split(' ')[1]);

                prices = new int[flowers];
                line = Console.ReadLine();
                string[] elements = line.Split(' ');
                for (int i = 0; i < flowers; i++)
                {
                    prices[i] = Convert.ToInt32(elements[i]);
                }

            }


        }
    }
