using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace W4Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            Random ran = new Random();
            int Sum = 0;
            for (int i=0;i<10;i++)
            {
                genericList.Add(ran.Next(3, 30));
            }
            int Max = genericList.Head.Data;
            int Min = genericList.Head.Data;
            Action<int> print = (i) => Console.WriteLine(i);
            Action<int> max = (i) => 
            {
                if (i > Max) Max = i;
                else return;
            };
            Action<int> min = (i) =>
              {
                  if (i < Min) Min = i;
                  else return;
              };
            Action<int> sum = (i) =>
             {
                 Sum += i;
             };
            genericList.forEach(print);
            genericList.forEach(max);
            Console.WriteLine($"MAX={Max}");
            genericList.forEach(min);
            Console.WriteLine($"MIN={Min}");
            genericList.forEach(sum);
            Console.WriteLine($"SUM={Sum}");

        }
    }
    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void forEach(Action<T> action)
        {
            Node<T> p = this.head;
            for (; p != null; p = p.Next)
            {
                action(p.Data);
            }
        } 
    }
}


