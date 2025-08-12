using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    public class TestCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPassed { get; set; }
    }

    public class TestCaseCollection : IEnumerable<TestCase>
    {
        private List<TestCase> _testCases = new List<TestCase>();

        // Add method
        public void Add(TestCase testCase)
        {
            _testCases.Add(testCase);
        }

        public IEnumerator<TestCase> GetEnumerator()
        {
            return _testCases.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program12
    {
        static void Main1(string[] args)
        {
            TestCaseCollection testCases = new TestCaseCollection();

            testCases.Add(new TestCase { Id = 1, Name = "Login Test", IsPassed = true });
            testCases.Add(new TestCase { Id = 2, Name = "Search Test", IsPassed = false });
            testCases.Add(new TestCase { Id = 3, Name = "Checkout Test", IsPassed = true });

            foreach (TestCase tc in testCases)
            {
                Console.WriteLine(tc);
            }

            foreach (TestCase tc in testCases)
            {
                if (tc.IsPassed)
                    Console.WriteLine(tc.Name);
            }
        }
    }
}
