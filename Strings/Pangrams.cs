
//Roy wanted to increase his typing speed for programming contests.
//So, his friend advised him to type the sentence "The quick brown fox jumps over the lazy dog" repeatedly because it is a pangram.
//( pangrams are sentences constructed by using every letter of the alphabet at least once. )

//After typing the sentence several times, Roy became bored with it.
//So he started to look for other pangrams.

//Given a sentence s, tell Roy if it is a pangram or not.

//Input Format

//Input consists of a line containing s.

//Constraints 
//Length of s can be atmost 103 (1≤|s|≤103) and it may contain spaces,
//lowercase and uppercase letters. 
//Lowercase and uppercase instances of a letter are considered same.

//Output Format

//Output a line containing pangram if s is a pangram, otherwise output not pangram.

//Sample Input #1

//We promptly judged antique ivory buckles for the next prize    
//Sample Output #1

//pangram
//Sample Input #2

//We promptly judged antique ivory buckles for the prize    
//Sample Output #2

//not pangram
//Explanation

//In the first testcase, the answer is pangram because the sentence contains all the letters.

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
            private static string sentence;

            static void Main(string[] args)
            {
                GetInput();

                Console.Write(SolveProblem(sentence));

                Console.ReadKey();
            }

            private static char[] GenerateAlphabet()
            {
                int i = 0;
                char[] alphabet = new char[26];
                alphabet[0] = 'a';
                do
                {
                    i++;
                    alphabet[i] = (char)(alphabet[i - 1] + 1);
                 } while (alphabet[i] != 'z');

                return alphabet;
            }

            private static string SolveProblem(string sentence)
            {
                string result = "pangram";
                char[] alphabet = GenerateAlphabet();

                foreach (char letter in alphabet)
                {
                    if (!sentence.Contains(letter) && !sentence.Contains((char)(letter - 32)))
                    {
                        result = "not " + result;
                        break;
                    }
                }

                return result;
            }


            private static void GetInput()
            {
                sentence = Console.ReadLine();
            }
        }
    }
