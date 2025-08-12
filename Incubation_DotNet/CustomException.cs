using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class TestFailedException:Exception
    {
        public TestFailedException(string execptionMessage):base(execptionMessage)
        {
            
        }
    }

    public class LoginTestSuite
    {
        public void RunTest()
        {
            Console.WriteLine("Running login test...");

            // Failing test case
            bool loginSuccess = false;

            if (!loginSuccess)
            {
                throw new TestFailedException("Login failed due to invalid credentials.");
            }

            Console.WriteLine("Login test passed.");
        }

        class TestRunner
        {
            public static void Main1()
            {
                var test = new LoginTestSuite();

                try
                {
                    test.RunTest();
                }
                catch (TestFailedException ex)  // Custom exception
                {
                    Console.WriteLine($"TestFailedException Caught: {ex.Message}");
                }
                catch (Exception ex) // General expection
                {
                    Console.WriteLine($" General Exception Caught: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Cleaning up test");
                }

            }
        }
    }
}
