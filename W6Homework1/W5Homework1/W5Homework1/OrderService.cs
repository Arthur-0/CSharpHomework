using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace W5Homework1
{
    public class OrderService
    {
        //定义订单列表
        public HashSet<Order> orders;
        private XmlSerializer xmlSerializer;

        //构造函数
        public OrderService()
        {
            this.orders = new HashSet<Order>();
            xmlSerializer = new XmlSerializer(typeof(HashSet<Order>));
        }

        //增加订单
        public void AddOrder(Order order)
        {
            orders.Add(order);
            Console.WriteLine("成功添加订单");
        }

        //删除订单
        public void DeleteOrder(string ID)
        {
            orders.Remove(SearchByID(ID));
            Console.WriteLine("成功删除订单");
        }

        //修改订单内容
        public void MotifyOrder(String orderID, string operation1, string ClientName ="0",string product="0", string operation2 = "2",int num=0,double uniPrice=0)
        {
            Order od=new Order();
            try
            {
                od = this.SearchByID(orderID);
            }
            catch (InvalidOperationException e)
            {
                
                Console.WriteLine("输入订单号有误");
                throw;
            }
            
            
            if (operation1 == "1")
            {
                
                 OrderItem item=new OrderItem();
                 try
                 {
                     item = od.SearchByProduct(product);
                 }
                 catch (InvalidOperationException e)
                 {
                    Console.WriteLine("输入商品名称有误");
                    throw;
                 }

                switch(operation2)
                { 
                    case "0":
                        item.Num = num;
                        break;
                    case "1":
                        item.UnitPrice = uniPrice;
                        break;
                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }

            else if(operation1 == "0")
            {

                od.Client = ClientName;
            }

            else
            {
                Console.WriteLine("输入错误！");
                return;
            }

        }

        //通过订单号搜索
        public Order SearchByID(string ID)
        {
            var query = from order in orders
                        where order.ID == ID
                        select order;

            if(query==null)
            {
                Console.WriteLine("输入的订单号有误！");
                return null;
            }
            else
            {
                return query.First();
            }
        }

        //通过客户名搜索
        public HashSet<Order> SearchByClient(string Client)
        {
            var query = from order in orders
                        where order.Client == Client
                        orderby order.TotalAmount 
                        select order;

            if (query == null)
            {
                Console.WriteLine("输入的客户名有误！");
                return null;
            }
            else
            {
                return query.ToHashSet();
            }
        }

        //通过商品名搜索
        public HashSet<Order> SearchByProduct(string Product)
        {
            var query = from order1 in orders
                        where (order1.SearchByProduct(Product) != null)
                        orderby order1.ID
                        select order1;

            if (query == null)
            {
                Console.WriteLine("输入的客户名有误！");
                return null;
            }
            else
            {
                return query.ToHashSet();
            }
        }

        public void Export()
        {
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orders);
            }
        }

        public void Import()
        {
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                HashSet<Order> orders1 = (HashSet<Order>)xmlSerializer.Deserialize(fs);
                foreach(Order order1 in orders1)
                {
                    this.orders.Add(order1);
                }
                    
            }
        }
    }
}

/*
 1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；
  添加一个Import方法可以从XML文件中载入订单。
 2、对订单程序中OrderService的各个Public方法添加测试用例。
 */


