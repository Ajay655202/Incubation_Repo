using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    public interface ITestCase
    {
        void Run();
        void Report();
    }

   
    public abstract class BaseTestCase : ITestCase
    {
        public string TestName { get; protected set; }
        public bool Passed { get; protected set; }

        public BaseTestCase(string name)
        {
            TestName = name;
        }
        
        public abstract void Run();

        public virtual void Report()
        {
            Console.WriteLine($"Test Report - {TestName}");
            Console.WriteLine($"Status: {(Passed ? "PASSED" : "FAILED")}");
        }

        
        protected void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class LoginTestss : BaseTestCase
    {
        public LoginTestss() : base("Login Test") { }

        public override void Run()
        {
            Log("Launching browser and navigating to login page...");
            Log("Entering credentials...");

            Passed = true;

            Log("Login successful.");
        }
    }

    public class CheckoutTest : BaseTestCase
    {
        public CheckoutTest() : base("Checkout Test") { }

        public override void Run()
        {
            Log("Opening cart...");
            Log("Proceeding to checkout...");

            Passed = false;

            Log("Checkout failed due to payment error.");
        }
    }

    class Program1
    {
        static void Main1()
        {
            ITestCase[] testCases = new ITestCase[]
            {
                new LoginTestss(),
                new CheckoutTest()
            };

            foreach (var test in testCases)
            {
                test.Run();      
                test.Report();  
                Console.WriteLine("----------------------");
            }
        }
    }
}
