using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
     internal class TestUtils
    {
        public static readonly string TestSuitName = "LoginTest"; //static readonly

        public string test;
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    interface ITest
    {
        void Run();
    }

    public class LoginTest : ITest
    {
        public void Run()
        {
            Console.WriteLine("This is login test");
        }
    }

    public class InValidTest : ITest
    {
        public void Run()
        {
            throw new Exception("This is invalid test case");  //throw
        }
    }

    public class program
    {
        public static void Main1()
        {
            ITest[] tests = new ITest[]
            {
                new LoginTest(),
                new InValidTest(),
                new LoginTest(),
                new LoginTest()
            };

            int testNumber = 0;                                   //Instance

            foreach (var test in tests)
            {
                try
                {
                    testNumber++;
                    if (test is LoginTest)
                    {
                        TestUtils.Log("This is Login Test suite");
                    }

                    if (testNumber == 2)
                    {
                        TestUtils.Log("Skipping the test");
                        continue;                                    //continue
                    }

                    test.Run();
                   
                    if (testNumber == 3)
                    {
                        TestUtils.Log("Breaking the test loop early");
                        break;                                        //break;
                    }
                }
                catch(Exception e) 
                {
                    TestUtils.Log("Cant run this testsuite");
                } 
                finally                                                //Finally
                {
                    //Cleanup
                    TestUtils.Log("Do cleanup for test cases");
                }
            }

        }
    }

    public class NormalClass
    {
        public virtual void Method1()
        {
            int b = 10;
        }
    }

    public class NextClass : NormalClass
    {
        public override void Method1()
        {
            int a = 10;
        }
    }

    public class NextNormalClass : NextClass
    {
        public override void Method1()
        {
            int c = 10;
        }
    }
}
