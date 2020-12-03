using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Test File";
            TestClass test = new TestClass();
            Console.WriteLine("Your number is: " + test.giveMeNumber());
            test.printText();
            Console.ReadKey();
        }
    }
}
