using System;
using System.Collections.Generic;


namespace W5Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order("Ruby");
            OrderItem orderItem1 = new OrderItem("bag", "001", 5, 90);
            OrderItem orderItem2 = new OrderItem("shoes", "002", 2, 190);
            order1.AddOrderItem(orderItem1);
            order1.AddOrderItem(orderItem2);
            Order order2 = new Order("Arthur");
            OrderItem orderItem3 = new OrderItem("pen", "008", 2, 30);
            OrderItem orderItem4 = new OrderItem("book", "004", 2, 20);
            order2.AddOrderItem(orderItem1);
            order2.AddOrderItem(orderItem2);
            order2.AddOrderItem(orderItem3);
            order2.AddOrderItem(orderItem4);
            OrderService orderService1 = new OrderService();
            Console.WriteLine(order2.ToString());
            orderService1.AddOrder(order1);
            orderService1.AddOrder(order2);
            HashSet<Order> hs = orderService1.SearchByClient("Ruby");
            foreach(Order o in hs)
            {
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine("修改订单请按下列提示操作");
            Console.WriteLine("请输入要修改的订单号");
            string orderID = Console.ReadLine();
            Console.WriteLine("请输入要修改的数据项后的数字");
            Console.WriteLine(String.Format("{0,-10}", "客户名:0") + String.Format("{0,-10}", "商品明细:1"));
            string operation1 = Console.ReadLine();
            string ClientName;
            if (operation1 == "1")
            {
                Console.WriteLine("请输入要修改的商品名称");
                string product = Console.ReadLine();
                Console.WriteLine("请输入要修改的数据项后的数字");
                Console.WriteLine(String.Format("{0,-10}", "商品数量:0") + String.Format("{0,-10}", "商品单价:1"));
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("请输入修改后的商品数量：");
                        int i = 0;
                        if (!int.TryParse(Console.ReadLine(), out i))
                        {
                            Console.WriteLine("输入错误！");
                            return;
                        }
                        else
                        {
                            orderService1.MotifyOrder(orderID, operation1,"2","0",product,i);
                        }

                        break;
                    case "1":
                        Console.WriteLine("请输入修改后的商品单价：");
                        double d = 0;
                        if (!double.TryParse(Console.ReadLine(), out d))
                        {
                            Console.WriteLine("输入错误！");
                            return;
                        }
                        else
                        {
                            orderService1.MotifyOrder(orderID, operation1, "2",product,"1",0,d);

                        }
                        break;

                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }

            }
            else if (operation1 == "0")
            {
                Console.WriteLine("请输入修改后的客户名");
                ClientName = Console.ReadLine();
                orderService1.MotifyOrder(orderID, operation1, ClientName);
            }
            else Console.WriteLine("输入错误");
            

            //orderService1.motifyOrder();
            //Console.WriteLine(order2.toString());
            orderService1.Import();
            Console.WriteLine("--------------------------------------------");
            foreach (Order o in orderService1.orders)
            {
                Console.WriteLine(o.ToString());
            }

        }
 
    }

}

/*
 1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；
  添加一个Import方法可以从XML文件中载入订单。
 2、对订单程序中OrderService的各个Public方法添加测试用例。
 */
