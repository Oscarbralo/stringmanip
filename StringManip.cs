using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is a program written for the portfolio of Chris Jones. The purpose of this program is to read in a string and ask for a user input to do a certain action.

            Console.WriteLine("Please enter a string to manipulate: ");
            string str = Console.ReadLine();

            //Default answer = -1, different from all the other answers.
            int answer = -1;

            while (answer != 0)
            {
                Console.WriteLine("\n\nHere are the following options to choose:");
                Console.WriteLine("1. Print out all permutations of the string.");
                Console.WriteLine("2. Print out the score that string would get in a game of scrabble.");
                Console.WriteLine("3. Reverse the order of the string");
                Console.WriteLine("4. Check if the string is a palindrome.");
                Console.WriteLine("5. Different string.");
                Console.WriteLine("0. Exit program.");
                
                //Read in answer. If it's not an integer, use answer = -1.
                string temp = Console.ReadLine();
                if (!int.TryParse(temp, out answer))
                    answer = -1;

                Console.WriteLine(" ");

                switch (answer)
                {
                    case 1:
                        perm(str);
                        break;
                    case 2:
                        scrabble(str);
                        break;
                    case 3:
                        reverse(str);
                        break;
                    case 4:
                        palin(str);
                        break;
                    case 5:
                        //New string
                        Console.WriteLine("Please enter a new string:");
                        str = Console.ReadLine();
                        break;
                    case 0:
                        break;
                    default:
                        //Error check for answer
                        Console.WriteLine("This is not a valid response. Please try again.\n");
                        break;
                }
            }


        }
        //Called function
        static void perm(string a)
        {
            char[] c = a.ToCharArray();
            if (c.Length > 5)
            {
                Console.WriteLine("WARNING: This is a long string and will take a long time to permute. Continune? y/n:");
                char yn = (char)Console.Read();
                if (yn == 'n')
                    return;
            }
            setper(c);
        }

        //Actual permutating recursive functions
        static void swap(ref char a, ref char b)
        {
            if (a == b) return;
            //a = a XOR b
            a ^= b;
            //b = b XOR a
            b ^= a;
            a ^= b;
        }

        static void setper(char[] list)
                  {
                        int x=list.Length-1;
                        go(list,0,x);
                  }

        static void go (char[] list, int k, int m)
                  {
                        int i;
                        if (k == m)
                           {
                                 Console.WriteLine (list);
                            }
                        else
                             for (i = k; i <= m; i++)
                            {
                                   swap (ref list[k],ref list[i]);
                                   go (list, k+1, m);
                                   swap (ref list[k],ref list[i]);
                            }
                   }

        static void scrabble(string a)
        {
            a = a.ToUpper(); //Make sure all characters are upper-cased.
            char[] c = a.ToCharArray();
            int total = 0;

            for (int i = 0; i < c.Length; i++)
            {
                total += checkScrab(c[i]);
            }

            Console.WriteLine("The string " + a + " would be worth " + total + " points in Scrabble.\n\n\n");
        }

        static int checkScrab(char q)
        {
            int ans = 0;
            /* A 26-case switch could be used here, but that would be inefficient to write.*/

            char[] One = new char[] { 'E', 'A', 'I', 'O', 'N', 'R', 'T', 'L', 'S', 'U' };
            char[] Two = new char[] { 'D', 'G' };
            char[] Three = new char[] { 'B', 'C', 'M', 'P' };
            char[] Four = new char[] { 'F', 'H', 'V', 'W', 'Y' };
            char[] Five = new char[] { 'K' };
            char[] Eight = new char[] { 'J', 'X' };
            char[] Ten = new char[] { 'Q', 'Z' };

            if (One.Contains(q))
                ans = 1;
            else if (Two.Contains(q))
                ans = 2;
            else if (Three.Contains(q))
                ans = 3;
            else if (Four.Contains(q))
                ans = 4;
            else if (Five.Contains(q))
                ans = 5;
            else if (Eight.Contains(q))
                ans = 8;
            else if (Ten.Contains(q))
                ans = 10;
            
            return ans;
        }

        static void reverse(string a)
        {
            StringBuilder sr = new StringBuilder("");

            for (int i = a.Length - 1; i >= 0; i--)
            {
                sr.Append(c[i].ToString());
            }
            
            Console.WriteLine("The reverse of " + a + " is " + sr.ToString() + "\n\n\n");
        }

        static void palin(string a)
        {
            a = a.ToUpper();

            char[] c = a.ToCharArray();
            bool answer = true;

            int len = c.Length;

            //the words "a" and "as" are palindromes
            if (len < 3)
            {
                Console.WriteLine("The word " + a + " is a palindrome because it only has 1 or 2 letters.\n\n\n");
                return;
            }

            /*By looking at the pseudocode, it can be seen that it does not matter if the string length is even or odd*/
            int midAR = len / 2;
            for (int i = 0; i < midAR; i++)
            {
                if (!(c[i] == c[len - 1 - i]))  //for AABBAA, check index 0 and 5, then check 1 and 4, then 2 and 3.
                    answer = false;             //If they are not the same at any point, answer = false.
            }

            if (answer)
                Console.WriteLine("The word " + a + " is a paldindrome!\n\n\n");
            else
                Console.WriteLine("The word " + a + " is NOT a paldindrome!\n\n\n");

        }

    }
}
