using System;

namespace W1Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0;
            double result = 0;
            checked
            {
                try
                {
                    Console.WriteLine("输入第一个运算数字");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("输入另一个运算数字");
                    num2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("数值过大！");
                    return;
                }
            }

            Console.WriteLine("请输入运算符：+、-、*、/");
            switch (Console.ReadLine())
            {
                case "+":
                    result = num1 + num2;
                    Console.WriteLine("计算结果为：" + result);
                    break;
                case "-":
                    result = num1 - num2;
                    Console.WriteLine("计算结果为：" + result);
                    break;
                case "*":
                    result = num1 * num2;
                    Console.WriteLine("计算结果为：" + result);
                    break;
                case "/":
                    try
                    {
                        result = num1 / num2;
                        Console.WriteLine("计算结果为：" + result);
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine("除数不能为零");
                        return;
                    }
                    break;

            }
        }
    }
}
