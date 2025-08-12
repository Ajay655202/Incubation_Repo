using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet.Linq
{
    internal static class List
    {
        public static void Main1()
        {
            List<Employee> lstEmployee = new List<Employee>()
            {
             new Employee(){Id=101,Name="Ajay",City="Hyderabad",Salary=90000 },
             new Employee(){Id=102,Name="Ashish",City="Chennai",Salary=80000 },
             new Employee(){Id=103,Name="Alameen",City="Banglore",Salary=60000 },
             new Employee(){Id=104,Name="Senthil",City="Chennai",Salary=90000 },
             new Employee(){Id=105,Name="Vinod",City="Hyderabad",Salary=40000 },
             new Employee(){Id=106,Name="Nikil",City="Vizag",Salary=50000 },
             new Employee(){Id=107,Name="Vijay",City="Hyderabad",Salary=20000 },
             new Employee(){Id=108,Name="Lavan",City="Banglore",Salary=30000 },
            };

            //Find
            lstEmployee.Find(a => a.City.Equals("Hyderabad"));

            //FindAll
            lstEmployee.FindAll(a => a.City.Equals("Hyderabad"));

            //First
            var val=lstEmployee.First(a => a.City.Equals("Hyderabad"));
            Console.WriteLine(val);

            //FirstorDefault
           var val2= lstEmployee.FirstOrDefault(a => a.City.Equals("Hyderabad"));
            Console.WriteLine(val2);

            //All
            bool isNameFound = lstEmployee.All(a => a.Salary > 10000);
            Console.WriteLine(isNameFound);

            //Chaining
            bool flag = lstEmployee.FindAll(a => a.City.Equals("Hyderabad")).All(b => b.Salary > 20000);
            Console.WriteLine(flag);

            //Any
            bool isAvailable = lstEmployee.Any(a => a.City.Equals("mumbai"));
            Console.WriteLine(isAvailable);

            //Where  -- Filter the data based on condition
            //Select -- Convert the each element into a new form
            var empDetails = lstEmployee.Where(a => a.City.StartsWith("H")).Select(b => b.Name);
            Console.WriteLine(empDetails);

            //Get multiple values
            var details = lstEmployee.Where(a => a.City.StartsWith("H")).Select(b => new { b.Name, b.Id });
            Console.WriteLine(details);

            var ownerDetails = lstEmployee.Where(a => a.Name.StartsWith("R")).Select(b => b.Id);
            Console.WriteLine(ownerDetails);

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public double Salary { get; set; }
    }
}
