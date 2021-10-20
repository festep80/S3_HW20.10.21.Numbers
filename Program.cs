using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S3_HW20._10._21.Numbers
{
    class Program
    {
        public class Numbers
        {
            private List<int> factorial;

            public List<int> Factorial
            {
                get { return factorial; }
                set { factorial = value; }
            }
            private List<int> fibonachi;

            public List<int> Fibonachi
            {
                get { return fibonachi; }
                set { fibonachi = value; }
            }
            private List<int> square;

            public List<int> Square
            {
                get { return square; }
                set { square = value; }
            }
            public void UpdateList(object state)
            {
                string name = (string)state;

                if (name == "factorial")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        factorial.Add(Factorial(i));
                    }
                }
                else if (name == "fibonachi")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        fibonachi.Add(Fibonachi(i));
                    }
                }
                else if (name == "square")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        square.Add(Square(i));
                    }
                }
                else
                {
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();
            
            Thread factorialThread = new Thread(new ParameterizedThreadStart(numbers.UpdateList));
            factorialThread.Start("factorial");
            Thread fibonachiThread = new Thread(new ParameterizedThreadStart(numbers.UpdateList));
            factorialThread.Start("fibonachi");
            Thread squareThread = new Thread(new ParameterizedThreadStart(numbers.UpdateList));
            factorialThread.Start("square");

            Console.WriteLine(" i\tFactorial\tFibonachi\tSquare");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(i + "\t" + numbers.Factorial[i] + "\t" + numbers.Fibonachi[i] + "\t" + numbers.Square[i] +"\n");
            }
            Console.WriteLine("------------------------------------------------");
        }
        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        public static int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
        public static int Square(int n)
        {
            return n * n;
        }
       
    }
}
