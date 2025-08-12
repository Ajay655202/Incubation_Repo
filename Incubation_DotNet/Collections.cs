using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class Collections
    {
        static void Main1(string[] args)
        {
            //List
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Mango");

            foreach (var fruit in fruits)
            {
                Console.WriteLine("Fruit: " + fruit);
            }

            //Array List
            ArrayList items = new ArrayList();
            items.Add("Text");
            items.Add(123);       
            items.Add(true);

            foreach (var item in items)
            {
                Console.WriteLine("Item: " + item + " (Type: " + item.GetType() + ")");
            }

            //Dictionary
            Dictionary<int, string> employeeMap = new Dictionary<int, string>();
            employeeMap.Add(101, "Alice");
            employeeMap.Add(102, "Bob");
            employeeMap[103] = "Charlie"; 

            foreach (var kvp in employeeMap)
            {
                Console.WriteLine("ID: " + kvp.Key + ", Name: " + kvp.Value);
            }

            // Searching
            if (employeeMap.ContainsKey(102))
            {
                Console.WriteLine("Employee 102: " + employeeMap[102]);
            }

            // Updating
            employeeMap[101] = "Alicia";
            Console.WriteLine("Updated Employee 101: " + employeeMap[101]);

            // Removing
            employeeMap.Remove(103);
            Console.WriteLine("Removed Employee 103");

            foreach (var kvp in employeeMap)
            {
                Console.WriteLine("ID: " + kvp.Key + ", Name: " + kvp.Value);
            }

        }
    }
}
