using System;

namespace W2Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 9, 2, 6, 3, 8 };
            Console.WriteLine("数组为：{ 1, 9, 2, 6, 3, 8 }" );
            double average;
            Console.WriteLine("数组的最大值为："+Max(a));
            Console.WriteLine("数组的最小值为：" + Min(a));
            Console.WriteLine("数组的所有元素的和为："+Sum(a, out average));
            Console.WriteLine("数组的所有元素的平均值为：" + average);
        }
        static int Max(int[] array)
        {
            int Max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (Max < array[i])
                    Max = array[i];
            }
            return Max;
        }

        static int Min(int[] array)
        {
            int Min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (Min > array[i])
                    Min = array[i];
            }
            return Min;
        }

        static int Sum(int[] array, out double average)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            average = (double)sum / (double)array.Length;
            return sum;
        }
    }
}
