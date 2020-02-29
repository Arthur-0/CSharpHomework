using System;

namespace W2Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            prime();
        }
        static void prime()
        {
            int[] a = new int[101];
            for (int i = 0; i < 101; i++)
            {
                a[i] = i;
            }
            a[1] = 0;
            for (int i = 2; i * i < 100; i++)
            {
                for (int j = 2; j < 100; j++)
                {
                    while (a[j] != i && a[j] % i == 0 && a[j] != 0)
                    {
                        a[j] = 0;
                    }
                }
            }
            for (int i = 2; i < 100; i++)
            {
                if (a[i] != 0)
                {
                    Console.Write(a[i]);
                    Console.Write(" ");
                }  
            }
        }
    }
}
