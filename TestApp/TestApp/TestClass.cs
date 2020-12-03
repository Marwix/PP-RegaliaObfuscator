using System;

namespace TestApp
{
    public class TestClass
    {
        public int giveMeNumber()
        {
            Random sv = new Random();
            return sv.Next(1, 30);
        }

        public void printText()
        {
            doSomething();
        }

        public void doSomething()
        {
            Console.WriteLine(getText());
            Console.WriteLine(randomText());
        }
        private string getText()
        {
            return "This is my first example string";
        }

        private string randomText()
        {
            return "This is my second example string";
        }
    }
}
