using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace W5Homework1
{
    [Serializable]
    public class Order
    {
        //定义属性
        public string ID;
        public double TotalAmount;
        public DateTime TradingTime;
        public string Client;
        public HashSet<OrderItem> OrderItems;

        //构造函数
        public Order(string client)
        {
            this.Client = client;
            this.TradingTime = DateTime.Now;
            Random rd = new Random();
            this.ID = DateTime.Now.ToString("yyyyMMddhhmmss") + rd.Next(1, 10);
            this.OrderItems = new HashSet<OrderItem>();
        }

        public Order() { }
       

        //增加订单明细
        public void AddOrderItem(OrderItem orderItem)
        {
            
            OrderItems.Add(orderItem);
            Console.WriteLine("成功增加订单明细:"+orderItem.Name);
            TotalAmount = TotalAmount + orderItem.UnitPrice * orderItem.Num; 
        }

        //删除订单明细
        public void DeleteOrderItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
            Console.WriteLine("成功删除订单明细:"+ orderItem.Name);
            TotalAmount = TotalAmount - orderItem.UnitPrice * orderItem.Num;
        }

        //通过商品名搜索订单明细
        public OrderItem SearchByProduct(string Product)
        {
            var query = from orderItem1 in OrderItems
                        where orderItem1.Name == Product
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

        override public String ToString()
        {
            string orderItemString = "";
            foreach(OrderItem o in OrderItems)
            {
                orderItemString = orderItemString + o.ToString();
            }

            return "Order ID:" + this.ID + "\n"
                + "Time:" + this.TradingTime.ToShortDateString() + "\n"
                + "Client:" + this.Client + "\n"
                + "product ID" + "   " + "Name" + "   " + "num" + "   " + "unitPrice" + "   " + "TotalAmount" + "\n"
                + orderItemString ;
        }
    }
}
