using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class Enacapsulation
    {
        static void Main1(string[] args)
        {
            //Abstraction
            //You can write code somewhere else and call it here or in some methods:
            //Eg:
            Console.WriteLine("Abstraction implementation");


            //Encapsulation

            //Wrapping of data and methods in a container called Encapsulation
            //Responsibility : Data integrity

            Employee employeeObj = new Employee();
            employeeObj._EmpFirstName = "";
        }
    }

    class Employee
    {
        public int EmpId;
        public string EmpFirstName;
        public string EmpLastName;

        //data integrity
        public string _EmpFirstName
        {
            get
            {
                return EmpFirstName;
            }
            set
            {
                if (string.IsNullOrEmpty(EmpFirstName))
                {
                    throw new Exception("First Name should not be empty");
                };
            }
        }

        public void GetEmployeeDetails()
        {

        }
    }
}
