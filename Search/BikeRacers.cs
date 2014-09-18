//There are N bikers present in a city (shaped as a grid) having M bikes.
//All the bikers want to participate in the HackerRace competition, 
//but unfortunately only K bikers can be accommodated in the race.
//Jack is organizing the HackerRace and wants to start the race as soon as possible.
//He can instruct any biker to move towards any bike in the city.
//In order to minimize the time to start the race,
//Jack instructs the bikers in such a way that first K bikes are acquired in the minimum time.

//Every biker moves with a unit speed and one bike can be acquired by only one biker.
//A biker can proceed in any direction. Consider distance between bike and bikers as euclidean distance.

//Jack would like to know the square of required time to start the race as soon as possible.

//Input Format 
//The first line contains three integers - N,M,K separated by a single space. 
//Following N lines will contain N pairs of integers denoting the co-ordinates of N bikers.
//Each pair of integers is separated by a single space. 
//The next M pairs of lines will denote the co-ordinates of M bikes.

//Output Format 
//A single line containing the square of required time.

//Constraints 
//1 <= N <= 250 
//1 <= M <= 250 
//1 <= K <= min(N,M) 
//0 <= xi,yi <= 107

//Sample Input #00:

//3 3 2
//0 1
//0 2
//0 3
//100 1
//200 2 
//300 3
//Sample Output #00:

//40000
//Explanation #00: 
//There's need for two bikers for the race. 
//The first biker (0,1) will be able to reach the first bike (100,1) in 100 time units.
//The second biker (0,2) will be able to reach the second bike (200,2) in 200 time units.
//This is the most optimal solution and will take 200 time units.
//So output will be 2002 = 40000.

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
            private int numberCandidates, numberBikes, neededBikers;
            private Point[] bikes;
            private Point[] candidates;
            private long[,] bikerBikesDistances;

            public void run()
            {
                getInput();

                Console.WriteLine(GetMinTime());

                Console.ReadKey();
            }
            
            private void getInput()
            {
                string[] line = Console.ReadLine().Split(' ');
                numberCandidates = Convert.ToInt32(line[0]);
                numberBikes = Convert.ToInt32(line[1]);
                neededBikers = Convert.ToInt32(line[2]);
                candidates = new Point[numberCandidates];
                bikes = new Point[numberBikes];

                for (int i = 0; i < numberCandidates; i++)
                {
                    candidates[i] = ReadCoordinates();
                }

                for (int i = 0; i < numberBikes; i++)
                {
                    bikes[i] = ReadCoordinates();
                }

                SetBikerBikeDistances();
            }

            private Point ReadCoordinates()
            {
                string[] line = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(line[0]);
                int y = Convert.ToInt32(line[1]);

                return new Point(x, y);
            }

            private void SetBikerBikeDistances()
            {
                bikerBikesDistances = new long[numberCandidates, numberBikes];

                for(int i = 0; i < numberCandidates; i++){
                    for(int j = 0; j < numberBikes; j++){
                        bikerBikesDistances[i, j] = GetTimeSquare(candidates[i], bikes[j]);
                    }
                }
            }

            private long GetTimeSquare(Point a, Point b)
            {
                return (long)(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            }

            private long GetMinTime()
            {
                long bottom = 0;
                long top = (long)Math.Pow(10, 16);
                while (bottom < top)
                {
                    long middle = (top + bottom) / 2;
                    if (CanAccomodateBikersInGivenTime(middle))
                    {
                        top = middle;
                    }
                    else
                    {
                        bottom = middle + 1;
                    }
                }

                return top;
            }

            private bool CanAccomodateBikersInGivenTime(long middle)
            {
                return MaximumBipartiteMatching(BuildBipartiteGraph(middle)) >= neededBikers;
            }

            private bool[,] BuildBipartiteGraph(long timeLimit)
            {
                bool[,] timeGraph = new bool[numberCandidates, numberBikes];
                for (int i = 0; i < numberCandidates; i++)
                {
                    for (int j = 0; j < numberBikes; j++)
                    {
                        if (bikerBikesDistances[i, j] <= timeLimit)
                        {
                            timeGraph[i, j] = true;
                        }
                        else
                        {
                            timeGraph[i, j] = false;
                        }
                    }
                }

                return timeGraph;
            }

            private int MaximumBipartiteMatching(bool[,] graph)
            {
                int bikersAccomodated = 0;
                //when bike is assinged we set the index of the biker from the bikers array in its cell
                int[] matchBikersWithBikes = new int[numberBikes];
                //initialize the match array, -1 represents a bike that is still available
                SetArrayToSingleValue(matchBikersWithBikes, -1);

                for (int i = 0; i < numberCandidates; i++)
                {
                    bool[] bikesTaken = new bool[numberBikes];
                    SetArrayToSingleValue(bikesTaken, false);
                    // Find if the candidate can get a bike
                    if (CanBikerGetABike(graph, i, bikesTaken, matchBikersWithBikes))
                    {
                        bikersAccomodated++;
                    }
                }

                return bikersAccomodated;
            }

            private bool CanBikerGetABike(bool[,] graph, int bikerIndex, bool[] bikesTaken, int[] matchBikersWithBikes)
            {
                for (int i = 0; i < numberBikes; i++)
                {
                    if (graph[bikerIndex, i] && !bikesTaken[i])
                    {
                        bikesTaken[i] = true;
                        //if bike i is not already taken OR the biker that took it can find another bike, assign bike to biker and return true.
                        //since the bike is marked as taken in bikesTaken, the recursive search for substitute bike will not offer that bike
                        if (matchBikersWithBikes[i] < 0 || CanBikerGetABike(graph, matchBikersWithBikes[i], bikesTaken, matchBikersWithBikes))
                        {
                            matchBikersWithBikes[i] = bikerIndex;

                            return true;
                        }
                    }
                }

                return false;
            }

            private void SetArrayToSingleValue<T>(T[] array, T value)
            {
                for (int i = 0; i < array.Count(); i++)
                {
                    array[i] = value;
                }
            }
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point() { }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

    }
