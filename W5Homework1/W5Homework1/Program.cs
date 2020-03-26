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
            order1.addOrderItem(orderItem1);
            order1.addOrderItem(orderItem2);
            Order order2 = new Order("Arthur");
            OrderItem orderItem3 = new OrderItem("pen", "008", 2, 30);
            OrderItem orderItem4 = new OrderItem("book", "004", 2, 20);
            order2.addOrderItem(orderItem1);
            order2.addOrderItem(orderItem2);
            order2.addOrderItem(orderItem3);
            order2.addOrderItem(orderItem4);
            OrderService orderService1 = new OrderService();
            Console.WriteLine(order2.toString());
            orderService1.addOrder(order1);
            orderService1.addOrder(order2);
            HashSet<Order> hs = orderService1.searchByClient("Ruby");
            foreach(Order o in hs)
            {
                Console.WriteLine(o.toString());
            }
            orderService1.motifyOrder();
            Console.WriteLine(order2.toString());
        }
 
    }

}

