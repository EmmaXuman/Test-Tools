using System;

namespace CbaseTest
{
    class Program
    {
        static void Main( string[] args )
        {
            int[] arr = { 3, 6, 4, 2, 11, 10, 5 };
            //一共遍历多少次
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //每次遍历元素
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            Console.WriteLine(Fibonacci(5));

        }

        //计算n以内的数字的和
        static int Sum( int n )
        {
            if (n <= 1)
            {
                return 1;
            }
            return Sum(n - 1) + n;
        }

        static int Fibonacci( int n )
        {
            if (n <= 1)
            {
                return 0;
            }
            if (n == 2)
            { return 1; }

            return Fibonacci(n-1) + Fibonacci(n -2);
        }
    }
}
