using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    public enum TestStatus
    {
        Passed,
        Failed,
        Skipped,
        NotRun
    }

    public class BaseTest
    {
        private string _testId = Guid.NewGuid().ToString();

        public TestStatus Status { get; protected set; }

        protected string TestName;

        internal DateTime CreatedOn = DateTime.Now;

        protected internal string Owner = "QA_Team";


        public BaseTest(string name)
        {
            TestName = name;
            Status = TestStatus.NotRun;
        }

        public virtual void RunTest()
        {
            Console.WriteLine($"Running test: {TestName}");
            Status = TestStatus.Passed;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Test ID: {_testId}");               // private
            Console.WriteLine($"Created On: {CreatedOn}");          // internal
            Console.WriteLine($"Owner: {Owner}");                   // protected internal
        }
    }

    public class LoginTestS : BaseTest
    {
        public LoginTestS() : base("Login Test") { }

        public override void RunTest()
        {
            Console.WriteLine($"Running derived test: {TestName}");  // protected
            Status = TestStatus.Failed;                              // public
        }
    }

    class Program
    {
        static void Main1()
        {
            BaseTest test1 = new LoginTestS();

            test1.RunTest();
            test1.PrintDetails();

            Console.WriteLine($"Test Status: {test1.Status}");

           
            // Console.WriteLine(test1._testId);        // private
            // Console.WriteLine(test1.TestName);       // protected
            Console.WriteLine($"Created On: {test1.CreatedOn}");   // internal
            Console.WriteLine($"Owner is: {test1.Owner}");   // protected internal
        }
    }
}
