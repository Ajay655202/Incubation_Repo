using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    internal class KindOfParameters
    {
        //public static void Main()
        //{
        //    //value
        //    int y = 10;
        //    Display(y);
        //    Console.WriteLine(y);

        //    //Ref
        //    Display(ref y);

        //    //params
        //    Result(1, 2, 3);
        //}

        public static void Display(int x)
        {
            x = 100;
        }

        public static void Display(ref int x)
        {
            x = 100;
        }

        //out
        void Add(int x, int y, out int addResult, out int mulResult)
        {
            addResult = x + y;
            mulResult = x * y;
        }


        static void Result(params int[] abc)
        {
            foreach (var item in abc)
            {

            }
        }
    }
}
