using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API_RestSharp
{
    internal class TestArrays
    {
        [TestClass]
        public class ArrayTests
        {
            // 1. Array Initialization
            [TestMethod]
            public void Test_ArrayInitialization()
            {
                int[] numbers = new int[] { 5, 3, 8, 1, 9 };

                Assert.AreEqual(5, numbers.Length);
                Assert.AreEqual(5, numbers[0]);
            }

            // 2. Iterating through array
            [TestMethod]
            public void Test_IterateArray()
            {
                string[] browsers = new string[] { "Chrome", "Firefox", "Edge" };

                foreach (var browser in browsers)
                {
                    Console.WriteLine("Testing on browser: " + browser);
                    Assert.IsNotNull(browser);
                }
            }

            // 3. Searching an element in array
            [TestMethod]
            public void Test_SearchElement()
            {
                string[] testCases = { "Login", "Signup", "Checkout", "Logout" };

                bool exists = testCases.Contains("Checkout");

                Assert.IsTrue(exists, "Expected 'Checkout' to be present in the array.");
            }

            // 4. Sorting an array
            [TestMethod]
            public void Test_SortArray()
            {
                int[] unsorted = { 9, 4, 1, 3, 7 };
                Array.Sort(unsorted);

                int[] expected = { 1, 3, 4, 7, 9 };

                Assert.AreEqual(expected, unsorted);
            }

            // 5. Finding index of an element
            [TestMethod]
            public void Test_FindIndex()
            {
                string[] statuses = { "Passed", "Failed", "Skipped" };

                int index = Array.IndexOf(statuses, "Failed");

                Assert.AreEqual(1, index);
            }

            // 6. Multi-dimensional array
            [TestMethod]
            public void Test_MultiDimensionalArray()
            {
                int[,] matrix = new int[2, 2] { { 1, 2 }, { 3, 4 } };

                Assert.AreEqual(1, matrix[0, 0]);
                Assert.AreEqual(4, matrix[1, 1]);
            }

            // 7. Using LINQ with arrays
            [TestMethod]
            public void Test_LinqArrayOperations()
            {
                int[] scores = { 75, 89, 91, 68, 99 };

                var highScores = scores.Where(score => score > 80).ToArray();

                CollectionAssert.AreEqual(new[] { 89, 91, 99 }, highScores);
            }
        }
    }
}
