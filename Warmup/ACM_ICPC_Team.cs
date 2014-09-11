//You are given a list of N people who are attending ACM-ICPC World Finals.
//Each of them are either well versed in a topic or they are not.
//Find out the maximum number of topics a 2-people team can know.
//And also find out how many teams can know that maximum number of topics?

//Input Format

//The first line contains two integers N and M separated by a single space,
//where N represents the number of people, and M represents the number of topics. N lines follow.
//Each line contains a binary string of length M. In this string, 1 indicates that the ith person knows a particular topic,
//and 0 indicates that the ith person does not know the topic.

//Output Format

//On the first line, print the maximum number of topics a 2-people team can know. 
//On the second line, print the number of teams that can know the maximum number of topics. 

//Constraints

//2 ≤ N ≤ 500 

//1 ≤ M ≤ 500
//Sample Input

//4 5
//10101
//11100
//11010
//00101
//Sample Output

//5
//2
//Explanation

//(1, 3) and (3, 4) know all the 5 topics. So the maximal topics a 2-people team knows is 5, and only 2 teams can acheive this.

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
        int numberOfPeople;
        int numberOfTopics;
        string[] knowledge;
        int maxTopics;
        int teams;

        public void run()
        {
            getInput();
            calculate();
            Console.Write("{0}\n{1}", maxTopics, teams);
            Console.ReadKey();
        }

        private void calculate()
        {
            maxTopics = 0;
            teams = 0;

            for (int i = 0; i < knowledge.Length - 1; i++)
            {
                for (int j = i + 1; j < knowledge.Length; j++)
                {
                    int topics = countTopics(knowledge[i], knowledge[j]);
                    if (topics == maxTopics) teams++;
                    else if (topics > maxTopics)
                    {
                        teams = 1;
                        maxTopics = topics;
                    }
                }
            }
        }

        public int countTopics(string p1, string p2)
        {
            int result = 0;

            for (int i = 0; i < p1.Length; i++)
            {
                if (p1[i] == '1' || p2[i] == '1') result++;
            }

                return result;
        }


        private void getInput()
        {
            string line = Console.ReadLine();
            numberOfPeople = Convert.ToInt32(line.Split(' ')[0]);
            numberOfTopics = Convert.ToInt32(line.Split(' ')[1]);
            knowledge = new string[numberOfPeople];
            for (int i = 0; i < numberOfPeople; i++)
            {
                knowledge[i] = Console.ReadLine();
            }
        }

    }
}
