using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderManager
{
    [Serializable]
    public class Order
    {
        //定义属性
        public string ID
        {
            get;set;
        }
        public double TotalAmount
        {
            get; set;
        }
        public DateTime TradingTime
        {
            get; set;
        }
        public string Client
        {
            get; set;
        }
        public List<OrderItem> OrderItems
        {
            get;set;
        }

        //构造函数
        public Order(string client)
        {
            this.Client = client;
            this.TradingTime = DateTime.Now;
            Random rd = new Random();
            this.ID = DateTime.Now.ToString("yyyyMMddhhmmss") + rd.Next(1, 10);
            this.OrderItems = new List<OrderItem>();
        }

        public Order() {
            this.OrderItems = new List<OrderItem>();
            this.TradingTime = DateTime.Now;
            Random rd = new Random();
            this.ID = DateTime.Now.ToString("yyyyMMddhhmmss") + rd.Next(1, 10);
        }
       

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
                return query.ToList().First();
            }
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

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   ID == order.ID;
        }

        public override int GetHashCode()
        {
            return 1213502048 + EqualityComparer<string>.Default.GetHashCode(ID);
        }
    }
}
