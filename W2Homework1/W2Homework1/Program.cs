using System;

namespace W2Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字");
            bool flag = int.TryParse(Console.ReadLine(), out int data);
            while (!flag || data < 0)
            {
                Console.WriteLine("输入错误，请重新输入");
                flag = int.TryParse(Console.ReadLine(), out data);
            }
            if (data == 1 || data == 0)
            {
                Console.WriteLine("该数字没有素数因子");
                return;
            }
            for (int i = 2; i <= data; i++)
            {
                if (data % i == 0)
                {
                    while (data % i == 0)
                    {
                        data /= i;
                    }
                    Console.WriteLine(i);

                }
            }
        }
    }
}
