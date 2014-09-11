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