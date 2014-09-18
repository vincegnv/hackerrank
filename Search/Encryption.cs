//One classic method for composing secret messages is called a square code. 
//The spaces are removed from the english text and the characters are written into a square (or rectangle). 
//The width and height of the rectangle have the constraint,

//floor(sqrt( len(word) )) <= width, height <= ceil(sqrt( len(word) ))

//Among the possible squares, choose the one with the minimum area.

//In case of a rectangle, the number of rows will always be smaller than the number of columns.
//For example, the sentence "if man was meant to stay on the ground god would have given us roots" is 54 characters long,
//so it is written in the form of a rectangle with 7 rows and 8 columns. Many more rectangles can accomodate these characters;
//choose the one with minimum area such that: length * width >= len(word)

//                ifmanwas 
//                meanttos         
//                tayonthe 
//                groundgo 
//                dwouldha 
//                vegivenu 
//                sroots

//The coded message is obtained by reading the characters in a column,
//inserting a space, and then moving on to the next column towards the right.
//For example, the message above is coded as:

//imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau

//You will be given a message in English with no spaces between the words.
//The maximum message length can be 81 characters. Print the encoded message.

//Here are some more examples:

//Sample Input:

//haveaniceday

//Sample Output:

//hae and via ecy

//Sample Input:

//feedthedog    

//Sample Output:

//fto ehg ee dd

//Sample Input:

//chillout

//Sample Output:

//clu hlt io

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
            private string word;
            private string code;

            public Problem() { }

            public Problem(string word)
            {
                this.word = word;
            }

            public void run()
            {
                getInput();
                solveTheProblem();
                printResult();
                Console.ReadKey();
            }

            private void printResult()
            {
                Console.Write(code);
            }

            private void solveTheProblem()
            {
                code = "";
                int floor = (int)Math.Floor(Math.Sqrt(word.Length));
                int ceil = (int)Math.Ceiling(Math.Sqrt(word.Length));
                int rows = floor;
                int columns = floor;

                if (floor < ceil)
                {
                    if (rows * columns < word.Length) columns++;
                    if (rows * columns < word.Length) rows++;
                }

                string[] matrix = getMatrix(rows, columns);
                code = getCode(matrix);
            }

            public string getCode(string[] matrix)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    foreach (string line in matrix)
                    {
                        if (i < line.Length)
                        {
                            sb.Append(line[i]);
                        }
                    }
                    sb.Append(' ');
                }

                return sb.ToString().Trim();
            }

            public string[] getMatrix(int rows, int columns)
            {
                string[] result = new string[rows];
                for (int row = 0; row < rows; row++)
                {
                    if (row * columns + columns >= word.Length)
                        result[row] = word.Substring(row*columns);
                    else result[row] = word.Substring(row * columns, columns);
                }

                return result;
            }

            private void getInput()
            {
                word = Console.ReadLine();
             }
        }

    }
