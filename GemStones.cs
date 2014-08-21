//John has discovered various rocks. Each rock is composed of various elements, and each element is represented by a lowercase latin letter from 'a' to 'z'.
//An element can be present multiple times in a rock. An element is called a 'gem-element' if it occurs at least once in each of the rocks.

//Given the list of rocks with their compositions, display the number of gem-elements that exist in those rocks.

//Input Format 
//The first line consists of N, the number of rocks. 
//Each of the next N lines contain rocks' composition. Each composition consists of lowercase letters of English alphabet.

//Output Format 
//Print the number of gem-elements that are common in these rocks.

//Constraints 
//1 ≤ N ≤ 100 
//Each composition consists of only small latin letters ('a'-'z'). 
//1 ≤ Length of each composition ≤ 100

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class GemStones
    {
        int numberOfRocks;
        String[] rocks;

        public void getInput()
        {
            numberOfRocks = Convert.ToInt32(Console.ReadLine());
            rocks = new String[numberOfRocks];
            for (int i = 0; i < numberOfRocks; i++)
            {
                rocks[i] = Console.ReadLine();
            }
        }

        public void printResult()
        {
            String gemElements = convertStringToDistinctCharString(rocks[0]);
            for (int i = 1; i < numberOfRocks; i++)
            {
                gemElements = leaveCommonElementsOnly(gemElements, rocks[i]);
            }
            Console.WriteLine(gemElements.Length);
        }

        private String leaveCommonElementsOnly(string gemElements, string p)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < gemElements.Length; i++)
            {
                if (p.Contains(gemElements[i].ToString()))
                {
                    result.Append(gemElements[i]);
                }
            }
            return result.ToString();
        }

        private string convertStringToDistinctCharString(String s)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++){
            
                if(!result.ToString().Contains(s[i].ToString()))
                {
                    result.Append(s[i]);
                }
            }
            return result.ToString();
        }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            GemStones gs = new Gemstones();
            gs.getInput();
            gs.printResult();
            Console.ReadKey();
        }
    }
}