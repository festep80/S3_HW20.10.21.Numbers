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
            public Numbers()
            {
                factorial = new List<int>();
                fibonachi = new List<int>();
                square = new List<int>();
            }
            public void UpdateList(object state)
            {
                string name = (string)state;

                if (name == "factorial")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        factorial.Add(GetFactorial(i));
                    }
                }
                else if (name == "fibonachi")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        fibonachi.Add(GetFibonachi(i));
                    }
                }
                else if (name == "square")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        square.Add(GetSquare(i));
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
            fibonachiThread.Start("fibonachi");
            
            Thread squareThread = new Thread(new ParameterizedThreadStart(numbers.UpdateList));
            squareThread.Start("square");
            
            Console.WriteLine(" i\tSquare\tFibonachi\tFactorial");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(i + "\t" + numbers.Square[i] + "\t" + numbers.Fibonachi[i] + "\t\t" + numbers.Factorial[i] +"\n");
            }
            Console.WriteLine("------------------------------------------------");
        }

        public static int GetFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * GetFactorial(n - 1);
            }
        }

        public static int GetFibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return GetFibonachi(n - 1) + GetFibonachi(n - 2);
            }
        }

        public static int GetSquare(int n)
        {
            return n * n;
        }

    }
}
