using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class ObjectComparision
    {
        public static void Main1()
        {
            //Same object
            Employe emp1 = new Employe();
            emp1.Name = "MyName";
            emp1.EMail = "MyName@gmail.com";
            Employe emp2 = emp1;
            Console.WriteLine(emp1.Equals(emp2));
            Console.WriteLine(emp1.GetHashCode() == emp2.GetHashCode());


            //Different Object

            Employe emp3 = new Employe();
            emp3.Name = "MyName";
            emp3.EMail = "MyName@gmail.com";
            Console.WriteLine(emp1.Equals(emp3));
            Console.WriteLine(emp1.GetHashCode() == emp3.GetHashCode());
        }
    }

    public class Employe
    {
        public string Name { get; set; }
        public string EMail { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj is null) return false;

            if (!(obj is Employe)) return false;

            return ((Employe)obj).Name == this.Name && ((Employe)obj).EMail == this.EMail;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.EMail.GetHashCode();
        }
    }
}
