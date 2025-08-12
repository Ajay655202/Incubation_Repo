using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet
{
    public sealed class SingleTon
    {
        private static readonly SingleTon instance = new SingleTon();

        private SingleTon()
        {

        }

        public static SingleTon Instance
        {
            get
            {
                return instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public sealed class SingleTonLazy
    {
        private static readonly Lazy<SingleTonLazy> instance = new Lazy<SingleTonLazy>(() => new SingleTonLazy());

        private SingleTonLazy()
        {

        }

        public static SingleTonLazy Instance => instance.Value;


        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public sealed class SingleTonThreadSafe
    {
        private static SingleTonThreadSafe instance = null;
        private static readonly object _lock = new object();

        private SingleTonThreadSafe()
        {

        }

        public static SingleTonThreadSafe Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new SingleTonThreadSafe();
                    }
                }
                return instance;
            }
        }


        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class SingleTonProgram
    {
        public static void Main()
        {
            SingleTon.Instance.Log("Test");
            SingleTonLazy.Instance.Log("Test");
        }
    }
}
