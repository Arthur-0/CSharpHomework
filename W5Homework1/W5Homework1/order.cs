using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace W5Homework1
{
    class Order
    {
        //定义属性
        private string ID;
        public string id
        {
            get { return ID; }
            set { ID = value; }
        }
        private double TotalAmount;
        public double totalAmount
        {
            get { return TotalAmount; }
            set { TotalAmount = value; }
        }
        private DateTime TradingTime;
        public DateTime tradingTime
        {
            get { return TradingTime; }
            set { TradingTime = value;}
        }
        private string Client;
        public string client
        {
            get { return Client; }
            set { Client = value; }
        }
        private HashSet<OrderItem> orderItems;
        public HashSet<OrderItem> OrderItems
        {
            get { return orderItems; }
            set { orderItems = value; }
        }

        //构造函数
        public Order(string client)
        {
            this.Client = client;
            this.tradingTime = DateTime.Now;
            Random rd = new Random();
            this.ID = DateTime.Now.ToString("yyyyMMddhhmmss") + rd.Next(1, 10);
            this.orderItems = new HashSet<OrderItem>();
        }

        //增加订单明细
        public void addOrderItem(OrderItem orderItem)
        {
            
            orderItems.Add(orderItem);
            Console.WriteLine("成功增加订单明细:"+orderItem.name);
            TotalAmount = TotalAmount + orderItem.unitPrice * orderItem.num; 
        }

        //删除订单明细
        public void deleteOrderItem(OrderItem orderItem)
        {
            orderItems.Remove(orderItem);
            Console.WriteLine("成功删除订单明细:"+ orderItem.name);
            TotalAmount = TotalAmount - orderItem.unitPrice * orderItem.num;
        }

        //通过商品名搜索订单明细
        public OrderItem searchByProduct(string Product)
        {
            var query = from orderItem1 in orderItems
                        where orderItem1.name == Product
                        select orderItem1;
            if (query == null)
            {
                Console.WriteLine("输入的商品名有误！");
                return null;
            }
            else
            {
                return query.ToHashSet().First();
            }
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   ID == order.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public String toString()
        {
            string orderItemString = "";
            foreach(OrderItem o in orderItems)
            {
                orderItemString = orderItemString + o.toString();
            }

            return "Order ID:" + this.ID + "\n"
                + "Time:" + this.TradingTime.ToShortDateString() + "\n"
                + "Client:" + this.Client + "\n"
                + "product ID" + "   " + "Name" + "   " + "num" + "   " + "unitPrice" + "   " + "TotalAmount" + "\n"
                + orderItemString ;
        }
    }
}
