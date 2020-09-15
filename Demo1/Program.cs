using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public class Program
    {
        public static int test;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public Program(int a)
        {

        }

        public Program(string a)
        {

        }

        private int myVar;

        #region

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int MyProperty2 { get; set; }


        public void Test()
        {
            MyProperty = 10;
        }

        
        private string myVar2;

        public string MyProperty3
        {
            get { return myVar2; }
            set { myVar2 = value; }
        }

    }
}
