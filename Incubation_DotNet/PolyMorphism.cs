using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class PolyMorphism
    {
        public static void Main2()
        {
            //Base class reference can hold all the child class objects

            //Method Hiding
            Parent C1 = new Child1();
            C1.printMethod();

            Parent C2 = new Child2();
            C2.printMethod();


            //Method Overriding
            Parent R1 = new Child1();
            R1.OverrideMethod();

            Parent R2 = new Child2();
            R2.OverrideMethod();

            List<Parent> allChilds = new List<Parent> { new Child1(), new Child2() };

            foreach (Parent child in allChilds)
            {
                child.OverrideMethod();
            }
        }
    }

    public class Parent
    {
        public void printMethod()
        {
            Console.WriteLine("Base class print method is calling");
        }

        public virtual void OverrideMethod()
        {
            Console.WriteLine("Base class override method is calling");
        }
    }

    public class Child1 : Parent
    {
        public new void printMethod()
        {
            Console.WriteLine("Child 1 class print method is calling");
        }

        public override void OverrideMethod()
        {
            Console.WriteLine("Child 1 class override method is calling");
        }
    }

    public class Child2 : Parent
    {
        public new void printMethod()
        {
            Console.WriteLine("Child 2 class print method is calling");
        }

        public override void OverrideMethod()
        {
            Console.WriteLine("Child 2 class override method is calling");
        }
    }
}
