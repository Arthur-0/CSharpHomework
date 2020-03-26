using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace W5Homework1
{
    class OrderService
    {
        //定义订单列表
        private HashSet<Order> orders;

        //构造函数
        public OrderService()
        {
            this.orders = new HashSet<Order>();
        }

        //增加订单
        public void addOrder(Order order)
        {
            orders.Add(order);
            Console.WriteLine("成功添加订单");
        }

        //删除订单
        public void deleteOrder(string ID)
        {
            orders.Remove(searchByID(ID));
            Console.WriteLine("成功删除订单");
        }

        //修改订单内容
        public void motifyOrder()
        {
            Console.WriteLine("修改订单请按下列提示操作");
            Console.WriteLine("请输入要修改的订单号");
            string orderID = Console.ReadLine();
            Order od;
            try
            {
                od = this.searchByID(orderID);
            }
            catch (InvalidOperationException e)
            {
                
                Console.WriteLine("输入订单号有误");
                throw;
            }
            
            Console.WriteLine("请输入要修改的数据项后的数字");
            Console.WriteLine(String.Format("{0,-10}", "客户名:0") + String.Format("{0,-10}", "商品明细:1"));
            string operation = Console.ReadLine();
            if (operation == "1")
            {
                Console.WriteLine("请输入要修改的商品名称");
                OrderItem item;
                try
                {
                    item = od.searchByProduct(Console.ReadLine());
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine("输入商品名称有误");
                    throw;
                }
                
                if (item == null)
                {
                    Console.WriteLine("输入商品名有误");
                    return;
                }
                Console.WriteLine(String.Format("{0,-10}", "商品数量:0") + String.Format("{0,-10}", "商品单价:1"));
                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("请输入修改后的商品数量：");
                        int i = 0;
                        if(!int.TryParse(Console.ReadLine(),out i))
                        {
                            Console.WriteLine("输入错误！");
                            return;
                        }
                        else
                        {
                            item.num = i;
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
                            item.unitPrice = d;

                        }
                        break;

                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }

            else if(operation == "0")
            {
                Console.WriteLine("请输入修改后的客户名");
                od.client = Console.ReadLine();
            }

            else
            {
                Console.WriteLine("输入错误！");
                return;
            }

        }

        //通过订单号搜索
        public Order searchByID(string ID)
        {
            var query = from order in orders
                        where order.id == ID
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
        public HashSet<Order> searchByClient(string Client)
        {
            var query = from order in orders
                        where order.client == Client
                        orderby order.totalAmount 
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
        public HashSet<Order> searchByProduct(string Product)
        {
            var query = from order1 in orders
                        where (order1.searchByProduct(Product) != null)
                        orderby order1.id
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
    }
}

