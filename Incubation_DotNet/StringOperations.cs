using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class StringOperations
    {
        static void Main1()
        {
            string str1 = "Ajay";
            string str2 = "Radam";

            //Concatenation
            string concatenated = str1 + " " + str2 + "!";
            Console.WriteLine(concatenated);

            //Navigation (Indexing and Substring)
            Console.WriteLine("First character of str1: " + str1[0]);
            Console.WriteLine("Substring of str2 (index 1 to 3): " + str2.Substring(1, 3));

            //String Comparison
            string str3 = "hello";
            Console.WriteLine("str1 == str3? " + (str1 == str3));                      
            Console.WriteLine("str1.Equals(str3)? " + str1.Equals(str3));             
            Console.WriteLine("str1.Equals(str3, true)? " +
                              str1.Equals(str3, StringComparison.OrdinalIgnoreCase));  

            //Replacing
            string replaced = str2.Replace("World", "C#");
            Console.WriteLine("Replaced str2: " + replaced);

            string val = "   Trim Me   ";
            Console.WriteLine("Trimmed: '" + val.Trim() + "'");
            Console.WriteLine("To Upper: " + str1.ToUpper());
            Console.WriteLine("To Lower: " + str2.ToLower());

            //Splitting
            string sentence = "C# in Dot Net";
            string[] words = sentence.Split(' ');
            Console.WriteLine("Split words:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            //Joining
            string joined = string.Join("-", words);
            Console.WriteLine(joined);
        }
    }
}
