//King Robert has 7 kingdoms under his rule. He finds out from a raven that the Dothraki are soon going to wage a war against him.
//But, he knows the Dothraki need to cross the narrow river to enter his dynasty.
//There is only one bridge that connects both sides of the river which is sealed by a huge door.

//The king wants to lock the door so that the Dothraki can't enter. But, to lock the door he needs a key that is an anagram of a certain palindrome string.

//The king has a string composed of lowercase English letters. Help him figure out if any anagram of the string can be a palindrome or not.

//Input Format 
//A single line which contains the input string

//Constraints 
//1<=length of string <= 10^5 
//Each character of the string is a lowercase English letter.

//Output Format 
//A single line which contains YES or NO in uppercase.

//Sample Input : 01

//aaabbbb
//Sample Output : 01

//YES
//Explanation 
//A palindrome permutation of the given string is bbaaabb. 

//Sample Input : 02

//cdefghmnopqrstuvw
//Sample Output : 02

//NO
//Explanation 
//You can verify that the given string has no palindrome permutation. 

//Sample Input : 03

//cdcdcdcdeeeef
//Sample Output : 03

//YES
//Explanation 
//A palindrome permutation of the given string is ddcceefeeccdd .

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Hackerrank
    {
        String input;
        
        static void Main(string[] args)
        {

            Hackerrank h = new Hackerrank();
            h.getInput();
            h.printResult();
            Console.ReadKey();
        }

        public void getInput()
        {
            input = Console.ReadLine();
        }

        public void printResult()
        {
            Dictionary<char, int> letters = letterGroupsToDictionary(input);

            int oddLetterGroups = 0;

            foreach (KeyValuePair<char, int> kvp in letters)
            {
                if (kvp.Value % 2 > 0)
                {
                    oddLetterGroups++;
                    if (oddLetterGroups > 1)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
            
        }

        private Dictionary<char, int> letterGroupsToDictionary(string input)
        {
            Dictionary<char, int> letters = new Dictionary<char,int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (letters.ContainsKey(input[i]))
                {
                    letters[input[i]] = letters[input[i]] + 1;
                }
                else
                {
                    letters.Add(input[i], 1);
                }
            }
            return letters;
        }
        
    }

}
