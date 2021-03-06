//You are given N sticks, where each stick is of positive integral length.
//A cut operation is performed on the sticks such that all of them are reduced by 
//the length of the smallest stick.

//Suppose we have 6 sticks of length

//5 4 4 2 2 8
//then in one cut operation we make a cut of length 2 from each of the 6 sticks. 
//For next cut operation 4 sticks are left (of non-zero length), whose length are

//3 2 2 6
//Above step is repeated till no sticks are left.

//Given length of N sticks, print the number of sticks that are cut in subsequent cut operations.

//Input Format 
//The first line contains a single integer N. 
//The next line contains N integers: a0, a1,...aN-1 separated by space, 
//where ai represents the length of ith stick.

//Output Format 
//For each operation, print the number of sticks that are cut in separate line.

//Constraints 
//1 ≤ N ≤ 1000 
//1 ≤ ai ≤ 1000

//Sample Input #00

//6
//5 4 4 2 2 8
//Sample Output #00

//6
//4
//2
//1
//Sample Input #01

//8
//1 2 3 4 3 3 2 1
//Sample Output #01

//8
//6
//4
//1
//Explanation

//Sample Case #00 :

//sticks-length        length-of-cut   sticks-cut
//5 4 4 2 2 8             2               6
//3 2 2 _ _ 6             2               4
//1 _ _ _ _ 4             1               2
//_ _ _ _ _ 3             3               1
//_ _ _ _ _ _           DONE            DONE
//Sample Case #01

//sticks-length         length-of-cut   sticks-cut
//1 2 3 4 3 3 2 1         1               8
//_ 1 2 3 2 2 1 _         1               6
//_ _ 1 2 1 1 _ _         1               4
//_ _ _ 1 _ _ _ _         1               1
//_ _ _ _ _ _ _ _       DONE            DONE

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
        int numberOfSticks;
        List<int> sticks;

        public void run()
        {
            getInputAndSetArrays();
            cutTheSticks();
            Console.ReadKey();
        }

        private void cutTheSticks()
        {
            while (sticks.Count > 0)
            {
                Console.WriteLine(sticks.Count);
                int shortestLength = sticks.Min();
                for (int i = 0; i < sticks.Count; i++)
                {
                    if (sticks[i] > 0) sticks[i] -= shortestLength;
                }
                sticks.RemoveAll(x => x == 0);
            }
        }

        private void getInputAndSetArrays()
        {
            numberOfSticks = Convert.ToInt32(Console.ReadLine());
            sticks = new List<int>();

            string line = Console.ReadLine();
            string[] stickLengths = line.Split(' ');
            foreach (string stickLength in stickLengths)
            {
                sticks.Add(Int32.Parse(stickLength));
            }
        }

    }
}
