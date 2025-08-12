using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class StringBuilderClass
    {
        static void Main1(string[] args)
        {
            StringBuilder sb = new StringBuilder("Hello");

            sb.Append(" World");
            Console.WriteLine("After Append: " + sb);

            sb.AppendLine();
            sb.AppendLine("Welcome to C# StringBuilder.");
            Console.WriteLine("\nAfter AppendLine:\n" + sb);

            sb.Insert(6, "Beautiful ");
            Console.WriteLine("\nAfter Insert: " + sb);

            sb.Replace("Beautiful", "Amazing");
            Console.WriteLine("\nAfter Replace: " + sb);

            sb.Remove(6, 8); // removes "Amazing "
            Console.WriteLine("\nAfter Remove: " + sb);

            string finalString = sb.ToString();
            Console.WriteLine("\nFinal string: " + finalString);

            sb.Clear();
            Console.WriteLine("\nAfter Clear: '" + sb + "'");
        }
    }
}
