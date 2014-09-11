//Hermione Granger is lost in the Forbidden Forest while collecting some herbs for her magical potion.
//The forest is magical and has only 1 exit point which magically transports her back to the Hogwarts School of Wizardy and Witch Craft. 
//Forest can be considered as a grid of NxM size.
//Each cell in the forest is either empty (represented by '.') or has a tree (represented by 'X'). 
//Hermione can move through empty cell, but not through cells with tree on it. 
//She can only travel LEFT, RIGHT, UP, DOWN. 
//Her position in the forest is indicated by the marker 'M' and the location of the exit point is indicated by '*'. 
//Top-left corner is indexed (0, 0).

//.X.X......X
//.X*.X.XXX.X
//.XX.X.XM...
//......XXXX.
//In the above forest, Hermione is located at index (2, 7) and exit is at (1, 2).
//Each cell is indexed according to Matrix Convention

//She starts her commute back to the exit and every time she encounters more than one option to move,
//she waves her wand and the correct path is illuminated and she proceeds in that way.
//It is guaranteed that there is only one path to each reachable cell from the starting cell.
//Can you tell us if she waved her wand exactly K times or not?
//Ron will be impressed if she is able to do so.

//Input Format 
//First line contains an integer T. T test cases follow. 
//Each test case starts with two space separated integer N and M. 
//Then next N lines contain a string each length of M which represents the forest. 
//Last line of each single test case is integer K.

//Output Format 
//For each test case, if she could impress Ron then print "Impressed" otherwise print "Oops!".

//All quotes used for the clarifications.

//Constraints 
//1 <= T <= 10 
//1<=N, M<=100 
//0 <= K <= 10000 
//There is exactly one 'M' and one '*' in the graph. 
//At least one path exists between 'M' and '*.'

//Sample Input

//3
//2 3
//*.M
//.X.
//1
//4 11
//.X.X......X
//.X*.X.XXX.X
//.XX.X.XM...
//......XXXX.
//3
//4 11
//.X.X......X
//.X*.X.XXX.X
//.XX.X.XM...
//......XXXX.
//4
//Sample Output

//Impressed
//Impressed
//Oops!
//Explanation

//Case1: Hermione waves her wand at (0,2) hence #Wand waved = K = 1. 
//Case2: Hermione waves her wand at (2,9) (0,5) and (3,3) hence #Wand waved = K = 3. 
//Case3: Same as above case. But here K = 4, which doesn't match times Wand is waved.

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
                    int n = Convert.ToInt32(line.Split(' ')[0]);
                    int m = Convert.ToInt32(line.Split(' ')[0]);
                    //read the map
                    string[] map = new string[n];
                    for (int mapLine = 0; mapLine < n; mapLine++)
                    {
                        map[mapLine] = Console.ReadLine();
                    }
                    //read Ron's expectations
                    int wandWaves = Convert.ToInt32(Console.ReadLine());
                    //create the test object
                    testCases[testNumber] = new TestCase(n, m, new MapContainer(map), wandWaves);
                }
             }
        }

        public class TestCase
        {
            private int n, m;
            private int wandWavesToMatch;
            private MapContainer map;

            public TestCase(int n, int m, MapContainer map, int waves)
            {
                this.n = n;
                this.m = m;
                this.wandWavesToMatch = waves;
                this.map = map;
            }

            public string Result()
            {
                string result = "Oops!";
                if (map.GetWandWaves() == wandWavesToMatch) result = "Impressed";
                return result;
            }

            //for test purposes
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("Grid size: {0} x {1}.\n", n, m));
                foreach (string s in map.Map)
                {
                    sb.Append(String.Format("{0}\n", s));
                }
                sb.Append(String.Format("Ron hopes she will get there with {0} wand waves.\n", wandWavesToMatch));

                return sb.ToString();
            }

            private bool isEmptySpace(string s)
            {
                return s.CompareTo(".") == 0;
            }
        }

        public class MapContainer
        {
            private MyPoint root;
            private MyPoint destination;
            private string[] map;
            private int height;
            private int length;

            public MapContainer(string[] map)
            {
                this.map = map;
                destination = null;
                root = null;
                height = map.Count();
                length = map.Count() > 0 ? map[0].Count() : 0;
            }

            public string[] Map
            {
                get
                {
                    return this.map;
                }
            }

            public int GetWandWaves()
            {
                BuildDestinationTree();
                int waves = -1;

                if (destination != null && root != null)
                {
                    MyPoint node = destination.Parent;
                    waves = root.Children.Count > 1 ? 1 : 0;
                    while (!node.Equals(root))
                    {
                        if (node.Children.Count > 1) waves++;
                        node = node.Parent;
                    }
                }

                return waves;
            }

            private void BuildDestinationTree()
            {
                this.root = FindStartPosition();
                GetChildren(root);
            }

            private void GetChildren(MyPoint node)
            {
                List<MyPoint> children = new List<MyPoint>()
            {
                ReadPointUp(node),
                ReadPointRight(node),
                ReadPointDown(node),
                ReadPointLeft(node)
            };
                foreach (MyPoint child in children)
                {
                    if ((IsRoad(child) || IsDestination(child)) && !child.Equals(node.Parent))
                    {
                        child.Parent = node;
                        node.Children.Add(child);
                        if (!IsDestination(child))
                        {
                            GetChildren(child);
                        }
                        else
                        {
                            destination = child;
                        }
                    }
                }

            }


            private MyPoint FindStartPosition()
            {
                return FindPositionInMap("M");
            }

            private MyPoint FindPositionInMap(string s)
            {
                int x = -1;
                int y = -1;

                for (int lineNumber = 0; lineNumber < map.Length; lineNumber++)
                {
                    if (map[lineNumber].Contains(s))
                    {
                        y = lineNumber;
                        x = map[lineNumber].IndexOf(s);
                        break;
                    }
                }

                return new MyPoint(x, y);
            }

            private MyPoint ReadPointLeft(MyPoint p)
            {
                if (p.X > 0)
                {
                    return new MyPoint(p.X - 1, p.Y);
                }
                return null;
            }

            private MyPoint ReadPointRight(MyPoint p)
            {
                if (p.X < length - 1)
                {
                    return new MyPoint(p.X + 1, p.Y);
                }
                return null;
            }

            private MyPoint ReadPointUp(MyPoint p)
            {
                if (p.Y > 0)
                {
                    return new MyPoint(p.X, p.Y - 1);
                }
                return null;
            }

            private MyPoint ReadPointDown(MyPoint p)
            {
                if (p.Y < height - 1)
                {
                    return new MyPoint(p.X, p.Y + 1);
                }
                return null;
            }

            private bool IsDestination(MyPoint p)
            {
                return ReadValue(p).CompareTo("*") == 0;
            }

            private bool IsRoad(MyPoint p)
            {
                return ReadValue(p).CompareTo(".") == 0;
            }

            private string ReadValue(MyPoint point)
            {
                string result = "";
                if (point != null && point.X >= 0 && point.X < length && point.Y >= 0 && point.Y < height)
                {
                    result = map[point.Y][point.X].ToString();
                }

                return result;
            }
        }

        public class MyPoint
        {
            public int X
            {
                get;
                set;
            }
            public int Y
            {
                get;
                set;
            }
            public MyPoint Parent
            {
                get;
                set;
            }
            public List<MyPoint> Children { get; set; }

            public MyPoint(int x, int y)
            {
                X = x;
                Y = y;
                Parent = null;
                Children = new List<MyPoint>();
            }

            public override bool Equals(object obj)
            {
                if (obj == null || this.GetType() != obj.GetType())
                {
                    return false;
                }
                else
                {
                    MyPoint p = (MyPoint)obj;
                    return p.X == this.X && p.Y == this.Y;
                }
            }

            public override int GetHashCode()
            {
                return X ^ Y;
            }
        }
    }
