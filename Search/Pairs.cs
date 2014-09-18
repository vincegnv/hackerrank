//Given N integers, count the number of pairs of integers whose difference is K.

//Input Format 
//The 1st line contains N & K (integers). 
//The 2nd line contains N numbers of the set. All the N numbers are distinct.

//Output Format 
//An integer that tells the number of pairs of integers whose difference is K.

//Constraints: 
//N <= 105 
//0 < K < 109 
//Each integer will be greater than 0 and at least K smaller than 231-1

//Sample Input #00:

//5 2  
//1 5 3 4 2  
//Sample Output #00:

//3
//Sample Input #01:

//10 1  
//363374326 364147530 61825163 1073065718 1281246024 1399469912 428047635 491595254 879792181 1069262793 
//Sample Output #01:

//0

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
            private int K;
            private int[] numbers;
            private Dictionary<int, int> workNumbers;
            private int result;

            public void run()
            {
                getInput();
                solveTheProblem();
                printResult();
                Console.ReadKey();
            }

            private void printResult()
            {
                Console.WriteLine(result);
            }

            private void solveTheProblem()
            {
                Array.Sort(numbers);
                result = 0;
                setWorkNumbers();
                int maxNumber = numbers[numbers.Count() - 1];
                int i = 0;
                while(numbers[i] + K <= maxNumber)
                {
                    if (workNumbers.ContainsKey(numbers[i] + K)) result++;
                    i++;
                }
            }

            private void setWorkNumbers()
            {

                workNumbers = new Dictionary<int, int>();
                for (int i = 0; i < numbers.Count(); i++)
                {
                    workNumbers.Add(numbers[i], i);
                }
            }

            private void getInput()
            {
                string[] firstLine = Console.ReadLine().Split(' ');
                string[] secondLine = Console.ReadLine().Split(' ');

                K = Convert.ToInt32(firstLine[1]);
                numbers = new int[Convert.ToInt32(firstLine[0])];
                for (int n = 0; n < secondLine.Count(); n++ )
                    numbers[n] = Convert.ToInt32(secondLine[n]);
            }
        }

    }
