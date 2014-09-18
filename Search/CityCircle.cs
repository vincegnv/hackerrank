//Roy lives in a city that is circular in shape on a 2D plane. 
//The city center is located at origin (0,0) and it has suburbs lying on the lattice points (points with integer coordinates). 
//The city Police Department Headquarters can only protect those suburbs which are located strictly inside the city. 
//The suburbs located on the border of the city are still unprotected. 
//So the police department decides to build at most k additional police stations at some suburbs.
//Each of these police stations can protect the suburb it is located in.

//Given the radius of the city, Roy has to determine if it is possible to protect all the suburbs.

//Input Format 
//The first line of input contains integer t, t testcases follow. 
//Each of next t lines contains two space separated integers: r, the square of the radius of the city and k,
//the maximum number of police stations the headquarters is willing to build.

//Constraints 
//1≤t≤103 
//1≤r≤2×109 
//0≤k≤2×109

//Output Format 
//For each test case, print in a new line possible if it is possible to protect all the suburbs, otherwise print impossible.

//Sample Input

//5
//1 3
//1 4
//4 4
//25 11
//25 12
//Sample Output

//impossible
//possible
//possible
//impossible
//possible

//Vince Ganev : the suburbs can lay only inside the city circle(protected) or its perimeter(unpotected).


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


                //InputFromFile input = new InputFromFile();
                //string[] lines = input.getInputFromFile(@"C:\Users\Vince\Documents\Visual Studio 2013\Projects\Hackerrank\HakerrankTests\test1.txt");
                //if (lines.Count() > 0)
                //{
                //    int tests = Convert.ToInt32(lines[0]);
                //    testCases = new TestCase[tests];
                //    for (int i = 1; i <= tests; i++)
                //    {
                //        testCases[i - 1] = new TestCase(Convert.ToInt32(lines[i].Split(' ')[0]), Convert.ToInt32(lines[i].Split(' ')[1]));
                //    }

                //    lines = input.getInputFromFile(@"C:\Users\Vince\Documents\Visual Studio 2013\Projects\Hackerrank\HakerrankTests\test1results.txt");
                //    Console.WriteLine("{0} lines of result", lines.Count());
                //    Console.WriteLine("{0} test cases", testCases.Count());
                //    for (int i = 0; i < tests; i++)
                //    {
                //        TestCase t = testCases[i];
                //        if (lines[i].CompareTo(t.Result()) != 0) Console.WriteLine("test {0} {1} {2} {3}", i + 1, t.RSqr, t.PC, t.Result() );
                //    }
                //}
                foreach (TestCase tc in testCases)
                {
                    Console.WriteLine(tc.Result());
                }

                    Console.ReadKey();
            }

            private void getInput()
            {
                //read how many test cases
                numberOfTestCases = Convert.ToInt32(Console.ReadLine());
                //read each test case
                testCases = new TestCase[numberOfTestCases];
                for (int testNumber = 0; testNumber < numberOfTestCases; testNumber++)
                {
                    //read N and M ( the size of the grid
                    string line = Console.ReadLine();
                    int r = Convert.ToInt32(line.Split(' ')[0]);
                    int k = Convert.ToInt32(line.Split(' ')[1]);
                    testCases[testNumber] = new TestCase(r, k);

                }
             }
        }

        public struct TestCase
        {
            private int rSqr;
            private double radius;
            private int policeStations;
            public int RSqr
            {
                set { this.rSqr = value; }
                get { return this.rSqr; }
            }
            public int PC
            {
                get { return this.policeStations; }
            }
            /// <summary>
            /// consturctor
            /// </summary>
            /// <param name="rSquare">Square of the radius of the city parameter</param>
            /// <param name="policeStations">max number of additional police stations for the suburbs</param>
            public TestCase(int rSquare, int policeStations)
            {
                this.radius = Math.Sqrt(rSquare);
                this.policeStations = policeStations;
                this.rSqr = rSquare;
            }

            /// <summary>
            /// Calculates the number of suburbs that lay on the city perimeter
            /// </summary>
            /// <returns>The number of unprotected suburbs</returns>
            public int CalculateUnprotectedSuburbs()
            {
                int result = 0;
                //if the radius is integer then there will be at least 4 lattice points on the city perimeter
                if (IsInteger(radius)) result += 4;
                int additionalLatticePoints = 0;
                for (int X = 1; X < radius; X++)
                {
                    double Y = Math.Sqrt(rSqr - X * X);
                    if (IsInteger(Y)) additionalLatticePoints++;
                }
                result += 4 * additionalLatticePoints;

                return result;
            }

            private bool IsInteger(double d)
            {
                return d > 0 && d % 1 == 0;
            }

            public string Result()
            {
                string result;
                if (CalculateUnprotectedSuburbs() > policeStations)
                {
                    result = "impossible";
                }
                else result = "possible";

                return result;
            }

        }

    }
